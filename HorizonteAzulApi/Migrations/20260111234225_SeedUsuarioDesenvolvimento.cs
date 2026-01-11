using HorizonteAzulApi.Models.HorizonteAzul;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable
namespace HorizonteAzulApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsuarioDesenvolvimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var hasher = new PasswordHasher<Usuario>();
            var hashPassword = hasher.HashPassword(new Usuario(), "senha123");

            migrationBuilder.Sql(@$"DELETE Usuario

                                    DBCC CHECKIDENT ('Usuario', RESEED, 0);

                                    INSERT INTO Usuario (Nome, Email, Senha, SituacaoUsuarioId, DataCadastro, DataUltimoAcesso, TipoUsuarioId)
                                    VALUES ('ADMINISTRADOR', 'ADMIN@ADMIN.COM.BR', '{hashPassword}', 1, '{DateTime.Now}', NULL, 1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE Usuario
                                   DBCC CHECKIDENT ('Usuario', RESEED, 0)");
        }
    }
}
