using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Citel.Conecta.Api.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarNomeWorkflowTipoEntidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TTL_NOMWFL",
                table: "TTLPEN",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "TTL_TIPENT",
                table: "TTLPEN",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "TRB_NOMWFL",
                table: "TRBPEN",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "TRB_TIPENT",
                table: "TRBPEN",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CLI_NOMWFL",
                table: "CLIPEN",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CLI_TIPENT",
                table: "CLIPEN",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TTL_NOMWFL",
                table: "TTLPEN");

            migrationBuilder.DropColumn(
                name: "TTL_TIPENT",
                table: "TTLPEN");

            migrationBuilder.DropColumn(
                name: "TRB_NOMWFL",
                table: "TRBPEN");

            migrationBuilder.DropColumn(
                name: "TRB_TIPENT",
                table: "TRBPEN");

            migrationBuilder.DropColumn(
                name: "CLI_NOMWFL",
                table: "CLIPEN");

            migrationBuilder.DropColumn(
                name: "CLI_TIPENT",
                table: "CLIPEN");
        }
    }
}
