using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HorizonteAzulApi.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoSession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConteudoTipo",
                table: "Sessao",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Metodo",
                table: "Sessao",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Navegador",
                table: "Sessao",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NavegadorAgente",
                table: "Sessao",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NavegadorTipo",
                table: "Sessao",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NavegadorVersao",
                table: "Sessao",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plataforma",
                table: "Sessao",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Protocolo",
                table: "Sessao",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Server",
                table: "Sessao",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServidorIp",
                table: "Sessao",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioIp",
                table: "Sessao",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConteudoTipo",
                table: "Sessao");

            migrationBuilder.DropColumn(
                name: "Metodo",
                table: "Sessao");

            migrationBuilder.DropColumn(
                name: "Navegador",
                table: "Sessao");

            migrationBuilder.DropColumn(
                name: "NavegadorAgente",
                table: "Sessao");

            migrationBuilder.DropColumn(
                name: "NavegadorTipo",
                table: "Sessao");

            migrationBuilder.DropColumn(
                name: "NavegadorVersao",
                table: "Sessao");

            migrationBuilder.DropColumn(
                name: "Plataforma",
                table: "Sessao");

            migrationBuilder.DropColumn(
                name: "Protocolo",
                table: "Sessao");

            migrationBuilder.DropColumn(
                name: "Server",
                table: "Sessao");

            migrationBuilder.DropColumn(
                name: "ServidorIp",
                table: "Sessao");

            migrationBuilder.DropColumn(
                name: "UsuarioIp",
                table: "Sessao");
        }
    }
}
