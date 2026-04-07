using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Citel.Conecta.Api.Migrations
{
    /// <inheritdoc />
    public partial class CorrigirAutoIncrementTabelas : Migration
    {
        private static readonly (string tabela, string coluna)[] Tabelas =
        [
            ("CONECTA_CLIPEN",  "CLI_CODPEN"),
            ("CONECTA_TTLPEN",  "TTL_CODPEN"),
            ("CONECTA_TRBPEN",  "TRB_CODPEN"),
            ("CONECTA_CRDPEN",  "CRD_CODPEN"),
            ("CONECTA_PEDPEN",  "PED_CODPEN"),
            ("CONECTA_PRDPEN",  "PRD_CODPEN"),
            ("CONECTA_ESTPEN",  "EST_CODPEN"),
            ("CONECTA_PRCPEN",  "PRC_CODPEN"),
            ("CONECTA_NFEPEN",  "NFE_CODPEN"),
            ("CONECTA_LMCPEN",  "LMC_CODPEN"),
            ("CONECTA_TRAPEN",  "TRA_CODPEN"),
            ("CONECTA_CDPPEN",  "CDP_CODPEN"),
            ("CONECTA_ATVPEN",  "ATV_CODPEN"),
            ("CONECTA_TBPPEN",  "TBP_CODPEN"),
            ("HRTBEN",          "HRT_CODPEN"),
        ];

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DROP PROCEDURE IF EXISTS _ConectaFixAutoIncrement;
                CREATE PROCEDURE _ConectaFixAutoIncrement(IN p_table VARCHAR(100), IN p_col VARCHAR(100))
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS
                        WHERE TABLE_SCHEMA = DATABASE()
                          AND TABLE_NAME   = p_table
                          AND COLUMN_NAME  = p_col
                    ) THEN
                        -- Se ainda não tem AUTO_INCREMENT, corrige
                        IF NOT EXISTS (
                            SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS
                            WHERE TABLE_SCHEMA = DATABASE()
                              AND TABLE_NAME   = p_table
                              AND COLUMN_NAME  = p_col
                              AND EXTRA LIKE '%auto_increment%'
                        ) THEN
                            -- Limpa a tabela: dados sem AUTO_INCREMENT são lixo de testes
                            SET @sql = CONCAT('TRUNCATE TABLE `', p_table, '`');
                            PREPARE stmt FROM @sql;
                            EXECUTE stmt;
                            DEALLOCATE PREPARE stmt;

                            -- Remove PK existente em outra coluna (se houver)
                            IF EXISTS (
                                SELECT 1 FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
                                WHERE TABLE_SCHEMA    = DATABASE()
                                  AND TABLE_NAME      = p_table
                                  AND CONSTRAINT_TYPE = 'PRIMARY KEY'
                            ) THEN
                                SET @sql = CONCAT('ALTER TABLE `', p_table, '` DROP PRIMARY KEY');
                                PREPARE stmt FROM @sql;
                                EXECUTE stmt;
                                DEALLOCATE PREPARE stmt;
                            END IF;

                            -- Adiciona PK + AUTO_INCREMENT na coluna correta
                            SET @sql = CONCAT('ALTER TABLE `', p_table, '` MODIFY COLUMN `', p_col, '` bigint NOT NULL AUTO_INCREMENT, ADD PRIMARY KEY (`', p_col, '`)');
                            PREPARE stmt FROM @sql;
                            EXECUTE stmt;
                            DEALLOCATE PREPARE stmt;
                        END IF;
                    END IF;
                END;
            ");

            foreach (var (tabela, coluna) in Tabelas)
                migrationBuilder.Sql($"CALL _ConectaFixAutoIncrement('{tabela}', '{coluna}');");

            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS _ConectaFixAutoIncrement;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Não reverte remoção de AUTO_INCREMENT intencionalmente
        }
    }
}
