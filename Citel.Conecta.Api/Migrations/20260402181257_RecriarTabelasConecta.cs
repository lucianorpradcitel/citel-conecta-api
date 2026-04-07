using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Citel.Conecta.Api.Migrations
{
    /// <inheritdoc />
    public partial class RecriarTabelasConecta : Migration
    {
        // Apenas tabelas CONECTA_* — tabelas legado não são tocadas
        private static readonly (string tabela, string prefixo)[] Tabelas =
        [
            ("CONECTA_CLIPEN", "CLI"),
            ("CONECTA_TTLPEN", "TTL"),
            ("CONECTA_TRBPEN", "TRB"),
            ("CONECTA_CRDPEN", "CRD"),
            ("CONECTA_PEDPEN", "PED"),
            ("CONECTA_PRDPEN", "PRD"),
            ("CONECTA_ESTPEN", "EST"),
            ("CONECTA_PRCPEN", "PRC"),
            ("CONECTA_NFEPEN", "NFE"),
            ("CONECTA_LMCPEN", "LMC"),
            ("CONECTA_TRAPEN", "TRA"),
            ("CONECTA_CDPPEN", "CDP"),
            ("CONECTA_ATVPEN", "ATV"),
            ("CONECTA_TBPPEN", "TBP"),
        ];

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            foreach (var (tabela, p) in Tabelas)
            {
                // Drop e recria com estrutura limpa — tabelas legado sem prefixo CONECTA_ não são afetadas
                migrationBuilder.Sql($"DROP TABLE IF EXISTS `{tabela}`;");

                migrationBuilder.Sql($@"
                    CREATE TABLE `{tabela}` (
                        `{p}_CODPEN` bigint        NOT NULL AUTO_INCREMENT,
                        `{p}_NOMCLI` longtext      CHARACTER SET utf8mb4 NOT NULL,
                        `{p}_NOMPLA` longtext      CHARACTER SET utf8mb4 NOT NULL,
                        `{p}_DHUALT` datetime(6)   NOT NULL,
                        `{p}_LOGERR` longtext      CHARACTER SET utf8mb4 NULL,
                        `{p}_CODENT` longtext      CHARACTER SET utf8mb4 NOT NULL,
                        `{p}_CODPLA` longtext      CHARACTER SET utf8mb4 NULL,
                        `{p}_NOMWFL` longtext      CHARACTER SET utf8mb4 NOT NULL DEFAULT '',
                        `{p}_TIPENT` longtext      CHARACTER SET utf8mb4 NOT NULL DEFAULT '',
                        PRIMARY KEY (`{p}_CODPEN`)
                    ) CHARACTER SET utf8mb4;
                ");
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            foreach (var (tabela, _) in Tabelas)
                migrationBuilder.Sql($"DROP TABLE IF EXISTS `{tabela}`;");
        }
    }
}
