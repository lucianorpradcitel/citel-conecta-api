using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Citel.Conecta.Api.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarNovasEntidadesHeartbeat : Migration
    {
        private static readonly (string tabela, string prefixo)[] Entidades =
        [
            ("ATVPEN", "ATV"),
            ("CDPPEN", "CDP"),
            ("CRDPEN", "CRD"),
            ("ESTPEN", "EST"),
            ("LMCPEN", "LMC"),
            ("NFEPEN", "NFE"),
            ("PEDPEN", "PED"),
            ("PRCPEN", "PRC"),
            ("PRDPEN", "PRD"),
            ("TBPPEN", "TBP"),
            ("TRAPEN", "TRA"),
        ];

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Helper: procedure temporária para ADD COLUMN apenas se não existir (MySQL <8 não suporta ADD COLUMN IF NOT EXISTS)
            migrationBuilder.Sql(@"
                DROP PROCEDURE IF EXISTS _monit_AddColIfNotExists;
                CREATE PROCEDURE _monit_AddColIfNotExists(
                    IN p_table VARCHAR(100),
                    IN p_col   VARCHAR(100),
                    IN p_def   TEXT
                )
                BEGIN
                    IF NOT EXISTS (
                        SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS
                        WHERE TABLE_SCHEMA = DATABASE()
                          AND TABLE_NAME   = p_table
                          AND COLUMN_NAME  = p_col
                    ) THEN
                        SET @sql = CONCAT('ALTER TABLE `', p_table, '` ADD COLUMN `', p_col, '` ', p_def);
                        PREPARE stmt FROM @sql;
                        EXECUTE stmt;
                        DEALLOCATE PREPARE stmt;
                    END IF;
                END;
            ");

            foreach (var (tabela, p) in Entidades)
            {
                // Cria tabela somente se não existir
                migrationBuilder.Sql($@"
                    CREATE TABLE IF NOT EXISTS `{tabela}` (
                        `{p}_CODPEN` bigint NOT NULL AUTO_INCREMENT,
                        `{p}_NOMCLI` longtext CHARACTER SET utf8mb4 NOT NULL,
                        `{p}_NOMPLA` longtext CHARACTER SET utf8mb4 NOT NULL,
                        `{p}_DHUALT` datetime(6) NOT NULL,
                        `{p}_LOGERR` longtext CHARACTER SET utf8mb4 NULL,
                        `{p}_CODENT` longtext CHARACTER SET utf8mb4 NOT NULL,
                        `{p}_CODPLA` longtext CHARACTER SET utf8mb4 NULL,
                        `{p}_NOMWFL` longtext CHARACTER SET utf8mb4 NOT NULL DEFAULT '',
                        `{p}_TIPENT` longtext CHARACTER SET utf8mb4 NOT NULL DEFAULT '',
                        PRIMARY KEY (`{p}_CODPEN`)
                    ) CHARACTER SET utf8mb4;
                ");

                // Garante as colunas novas em tabelas preexistentes
                migrationBuilder.Sql($"CALL _monit_AddColIfNotExists('{tabela}', '{p}_NOMWFL', 'longtext CHARACTER SET utf8mb4 NOT NULL DEFAULT \\\"\\\"');");
                migrationBuilder.Sql($"CALL _monit_AddColIfNotExists('{tabela}', '{p}_TIPENT', 'longtext CHARACTER SET utf8mb4 NOT NULL DEFAULT \\\"\\\"');");
            }

            // Heartbeat
            migrationBuilder.Sql(@"
                CREATE TABLE IF NOT EXISTS `HRTBEN` (
                    `HRT_CODPEN` bigint NOT NULL AUTO_INCREMENT,
                    `HRT_NOMWFL` longtext CHARACTER SET utf8mb4 NOT NULL,
                    `HRT_TIPENT` longtext CHARACTER SET utf8mb4 NOT NULL,
                    `HRT_DHUEXE` datetime(6) NOT NULL,
                    `HRT_DHUSUC` datetime(6) NULL,
                    `HRT_QTDPRO` int NOT NULL DEFAULT 0,
                    `HRT_CICSEG` int NOT NULL DEFAULT 0,
                    PRIMARY KEY (`HRT_CODPEN`)
                ) CHARACTER SET utf8mb4;
            ");

            // Remove a procedure temporária
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS _monit_AddColIfNotExists;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            foreach (var (tabela, _) in Entidades)
                migrationBuilder.DropTable(name: tabela);

            migrationBuilder.DropTable(name: "HRTBEN");
        }
    }
}
