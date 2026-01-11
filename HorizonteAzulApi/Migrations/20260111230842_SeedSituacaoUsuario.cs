using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HorizonteAzulApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedSituacaoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE SituacaoUsuario

                                   DBCC CHECKIDENT ('SituacaoUsuario', RESEED, 0);

                                   INSERT INTO SituacaoUsuario (Descricao) VALUES ('ATIVO')
                                   INSERT INTO SituacaoUsuario (Descricao) VALUES ('INATIVO')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE SituacaoUsuario
                                   DBCC CHECKIDENT ('SituacaoUsuario', RESEED, 0)");
        }
    }
}
