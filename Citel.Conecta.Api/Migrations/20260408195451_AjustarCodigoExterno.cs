using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Citel.Conecta.Api.Migrations
{
    /// <inheritdoc />
    public partial class AjustarCodigoExterno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HRT_QTDPRO",
                table: "HRTBEN");

            migrationBuilder.DropColumn(
                name: "HRT_TIPENT",
                table: "HRTBEN");

            migrationBuilder.DropColumn(
                name: "TTL_CODENT",
                table: "CONECTA_TTLPEN");

            migrationBuilder.DropColumn(
                name: "TRB_CODENT",
                table: "CONECTA_TRBPEN");

            migrationBuilder.DropColumn(
                name: "TRA_CODENT",
                table: "CONECTA_TRAPEN");

            migrationBuilder.DropColumn(
                name: "TBP_CODENT",
                table: "CONECTA_TBPPEN");

            migrationBuilder.DropColumn(
                name: "PRD_CODENT",
                table: "CONECTA_PRDPEN");

            migrationBuilder.DropColumn(
                name: "PRC_CODENT",
                table: "CONECTA_PRCPEN");

            migrationBuilder.DropColumn(
                name: "PED_CODENT",
                table: "CONECTA_PEDPEN");

            migrationBuilder.DropColumn(
                name: "NFE_CODENT",
                table: "CONECTA_NFEPEN");

            migrationBuilder.DropColumn(
                name: "LMC_CODENT",
                table: "CONECTA_LMCPEN");

            migrationBuilder.DropColumn(
                name: "EST_CODENT",
                table: "CONECTA_ESTPEN");

            migrationBuilder.DropColumn(
                name: "CRD_CODENT",
                table: "CONECTA_CRDPEN");

            migrationBuilder.DropColumn(
                name: "CLI_CODENT",
                table: "CONECTA_CLIPEN");

            migrationBuilder.DropColumn(
                name: "CDP_CODENT",
                table: "CONECTA_CDPPEN");

            migrationBuilder.DropColumn(
                name: "ATV_CODENT",
                table: "CONECTA_ATVPEN");

            migrationBuilder.RenameColumn(
                name: "TTL_TIPENT",
                table: "CONECTA_TTLPEN",
                newName: "TTL_CODEXT");

            migrationBuilder.RenameColumn(
                name: "TRB_TIPENT",
                table: "CONECTA_TRBPEN",
                newName: "TRB_CODEXT");

            migrationBuilder.RenameColumn(
                name: "TRA_TIPENT",
                table: "CONECTA_TRAPEN",
                newName: "TRA_CODEXT");

            migrationBuilder.RenameColumn(
                name: "TBP_TIPENT",
                table: "CONECTA_TBPPEN",
                newName: "TBP_CODEXT");

            migrationBuilder.RenameColumn(
                name: "PRD_TIPENT",
                table: "CONECTA_PRDPEN",
                newName: "PRD_CODEXT");

            migrationBuilder.RenameColumn(
                name: "PRC_TIPENT",
                table: "CONECTA_PRCPEN",
                newName: "PRC_CODEXT");

            migrationBuilder.RenameColumn(
                name: "PED_TIPENT",
                table: "CONECTA_PEDPEN",
                newName: "PED_CODEXT");

            migrationBuilder.RenameColumn(
                name: "NFE_TIPENT",
                table: "CONECTA_NFEPEN",
                newName: "NFE_CODEXT");

            migrationBuilder.RenameColumn(
                name: "LMC_TIPENT",
                table: "CONECTA_LMCPEN",
                newName: "LMC_CODEXT");

            migrationBuilder.RenameColumn(
                name: "EST_TIPENT",
                table: "CONECTA_ESTPEN",
                newName: "EST_CODEXT");

            migrationBuilder.RenameColumn(
                name: "CRD_TIPENT",
                table: "CONECTA_CRDPEN",
                newName: "CRD_CODEXT");

            migrationBuilder.RenameColumn(
                name: "CLI_TIPENT",
                table: "CONECTA_CLIPEN",
                newName: "CLI_CODEXT");

            migrationBuilder.RenameColumn(
                name: "CDP_TIPENT",
                table: "CONECTA_CDPPEN",
                newName: "CDP_CODEXT");

            migrationBuilder.RenameColumn(
                name: "ATV_TIPENT",
                table: "CONECTA_ATVPEN",
                newName: "ATV_CODEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TTL_CODEXT",
                table: "CONECTA_TTLPEN",
                newName: "TTL_TIPENT");

            migrationBuilder.RenameColumn(
                name: "TRB_CODEXT",
                table: "CONECTA_TRBPEN",
                newName: "TRB_TIPENT");

            migrationBuilder.RenameColumn(
                name: "TRA_CODEXT",
                table: "CONECTA_TRAPEN",
                newName: "TRA_TIPENT");

            migrationBuilder.RenameColumn(
                name: "TBP_CODEXT",
                table: "CONECTA_TBPPEN",
                newName: "TBP_TIPENT");

            migrationBuilder.RenameColumn(
                name: "PRD_CODEXT",
                table: "CONECTA_PRDPEN",
                newName: "PRD_TIPENT");

            migrationBuilder.RenameColumn(
                name: "PRC_CODEXT",
                table: "CONECTA_PRCPEN",
                newName: "PRC_TIPENT");

            migrationBuilder.RenameColumn(
                name: "PED_CODEXT",
                table: "CONECTA_PEDPEN",
                newName: "PED_TIPENT");

            migrationBuilder.RenameColumn(
                name: "NFE_CODEXT",
                table: "CONECTA_NFEPEN",
                newName: "NFE_TIPENT");

            migrationBuilder.RenameColumn(
                name: "LMC_CODEXT",
                table: "CONECTA_LMCPEN",
                newName: "LMC_TIPENT");

            migrationBuilder.RenameColumn(
                name: "EST_CODEXT",
                table: "CONECTA_ESTPEN",
                newName: "EST_TIPENT");

            migrationBuilder.RenameColumn(
                name: "CRD_CODEXT",
                table: "CONECTA_CRDPEN",
                newName: "CRD_TIPENT");

            migrationBuilder.RenameColumn(
                name: "CLI_CODEXT",
                table: "CONECTA_CLIPEN",
                newName: "CLI_TIPENT");

            migrationBuilder.RenameColumn(
                name: "CDP_CODEXT",
                table: "CONECTA_CDPPEN",
                newName: "CDP_TIPENT");

            migrationBuilder.RenameColumn(
                name: "ATV_CODEXT",
                table: "CONECTA_ATVPEN",
                newName: "ATV_TIPENT");

            migrationBuilder.AddColumn<int>(
                name: "HRT_QTDPRO",
                table: "HRTBEN",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "HRT_TIPENT",
                table: "HRTBEN",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "TTL_CODENT",
                table: "CONECTA_TTLPEN",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "TRB_CODENT",
                table: "CONECTA_TRBPEN",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "TRA_CODENT",
                table: "CONECTA_TRAPEN",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "TBP_CODENT",
                table: "CONECTA_TBPPEN",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PRD_CODENT",
                table: "CONECTA_PRDPEN",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PRC_CODENT",
                table: "CONECTA_PRCPEN",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PED_CODENT",
                table: "CONECTA_PEDPEN",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "NFE_CODENT",
                table: "CONECTA_NFEPEN",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "LMC_CODENT",
                table: "CONECTA_LMCPEN",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "EST_CODENT",
                table: "CONECTA_ESTPEN",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CRD_CODENT",
                table: "CONECTA_CRDPEN",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CLI_CODENT",
                table: "CONECTA_CLIPEN",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CDP_CODENT",
                table: "CONECTA_CDPPEN",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ATV_CODENT",
                table: "CONECTA_ATVPEN",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
