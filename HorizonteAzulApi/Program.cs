using HorizonteAzulApi.Data.Interfaces;
using HorizonteAzulApi.Data.Models.HorizonteAzul;
using HorizonteAzulApi.Data.Repositories;
using HorizonteAzulApi.Domain.Interfaces;
using HorizonteAzulApi.Domain.Services;
using HorizonteAzulApi.Extensions.Interfaces;
using HorizonteAzulApi.Extensions.Services;
using HorizonteAzulApi.Resources;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString(StringResources.HorizonteAzulConnection);
builder.Services.AddDbContext<HorizonteAzulContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<INotificadorDominio, NotificadorDominio>();

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddCors(policy =>
                         policy.AddPolicy("Security", builder =>
                                                      builder.AllowAnyOrigin()
                                                             .AllowAnyMethod()
                                                             .AllowAnyHeader()));

var jwtKey = builder.Configuration["Jwt:Key"] ?? throw new InvalidOperationException(StringResources.JwtKeyNaoConfigurado);
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
//{    
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//        ValidIssuer = builder.Configuration["Jwt:Issuer"],
//        ValidAudience = builder.Configuration["Jwt:Audience"],
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtKey)),
//    };
//});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference("/scalar", options =>
{
    options.Layout = ScalarLayout.Classic;
    options.Theme = ScalarTheme.Purple;
    options.Title = "HorizonteAzul API";
    options.ShowDeveloperTools = DeveloperToolsVisibility.Never;
    options.DocumentDownloadType = DocumentDownloadType.None;
    options.HideDarkModeToggle = true;
    options.HiddenClients = true;
    options.HideSearch = true;
    options.HideModels = true;
});

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
