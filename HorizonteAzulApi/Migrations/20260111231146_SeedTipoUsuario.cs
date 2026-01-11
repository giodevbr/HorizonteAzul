using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HorizonteAzulApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedTipoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE TipoUsuario

                                   DBCC CHECKIDENT ('TipoUsuario', RESEED, 0);

                                   INSERT INTO TipoUsuario (Descricao) VALUES ('SUPERADMINISTRADOR')
                                   INSERT INTO TipoUsuario (Descricao) VALUES ('ADMINISTRADOR')
                                   INSERT INTO TipoUsuario (Descricao) VALUES ('USUARIO')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE TipoUsuario
                                   DBCC CHECKIDENT ('TipoUsuario', RESEED, 0)");
        }
    }
}
