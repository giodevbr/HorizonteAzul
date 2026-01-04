using HorizonteAzulApi.Extensions.Interfaces;
using HorizonteAzulApi.Extensions.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddScoped<INotificadorDominio, NotificadorDominio>();
builder.Services.AddCors(policy =>
                         policy.AddPolicy("Security", builder =>
                                                      builder.AllowAnyOrigin()
                                                             .AllowAnyMethod()
                                                             .AllowAnyHeader()));

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
app.UseAuthorization();
app.MapControllers();
app.Run();
