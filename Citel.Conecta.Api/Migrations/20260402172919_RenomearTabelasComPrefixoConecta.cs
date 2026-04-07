using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Citel.Conecta.Api.Migrations
{
    /// <inheritdoc />
    public partial class RenomearTabelasComPrefixoConecta : Migration
    {
        private static readonly (string antiga, string nova)[] Renomeacoes =
        [
            ("CLIPEN",  "CONECTA_CLIPEN"),
            ("TTLPEN",  "CONECTA_TTLPEN"),
            ("TRBPEN",  "CONECTA_TRBPEN"),
            ("CRDPEN",  "CONECTA_CRDPEN"),
            ("PEDPEN",  "CONECTA_PEDPEN"),
            ("PRDPEN",  "CONECTA_PRDPEN"),
            ("ESTPEN",  "CONECTA_ESTPEN"),
            ("PRCPEN",  "CONECTA_PRCPEN"),
            ("NFEPEN",  "CONECTA_NFEPEN"),
            ("LMCPEN",  "CONECTA_LMCPEN"),
            ("TRAPEN",  "CONECTA_TRAPEN"),
            ("CDPPEN",  "CONECTA_CDPPEN"),
            ("ATVPEN",  "CONECTA_ATVPEN"),
            ("TBPPEN",  "CONECTA_TBPPEN"),
        ];

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Procedure temporária: renomeia apenas se a tabela antiga existir
            // (garante que funciona tanto no banco atual quanto num fresh install)
            migrationBuilder.Sql(@"
                DROP PROCEDURE IF EXISTS _ConectaRenameTable;
                CREATE PROCEDURE _ConectaRenameTable(IN p_old VARCHAR(100), IN p_new VARCHAR(100))
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM INFORMATION_SCHEMA.TABLES
                        WHERE TABLE_SCHEMA = DATABASE() AND TABLE_NAME = p_old
                    ) THEN
                        SET @sql = CONCAT('RENAME TABLE `', p_old, '` TO `', p_new, '`');
                        PREPARE stmt FROM @sql;
                        EXECUTE stmt;
                        DEALLOCATE PREPARE stmt;
                    END IF;
                END;
            ");

            foreach (var (antiga, nova) in Renomeacoes)
                migrationBuilder.Sql($"CALL _ConectaRenameTable('{antiga}', '{nova}');");

            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS _ConectaRenameTable;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DROP PROCEDURE IF EXISTS _ConectaRenameTable;
                CREATE PROCEDURE _ConectaRenameTable(IN p_old VARCHAR(100), IN p_new VARCHAR(100))
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM INFORMATION_SCHEMA.TABLES
                        WHERE TABLE_SCHEMA = DATABASE() AND TABLE_NAME = p_old
                    ) THEN
                        SET @sql = CONCAT('RENAME TABLE `', p_old, '` TO `', p_new, '`');
                        PREPARE stmt FROM @sql;
                        EXECUTE stmt;
                        DEALLOCATE PREPARE stmt;
                    END IF;
                END;
            ");

            foreach (var (antiga, nova) in Renomeacoes)
                migrationBuilder.Sql($"CALL _ConectaRenameTable('{nova}', '{antiga}');");

            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS _ConectaRenameTable;");
        }
    }
}
