using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddfnEnemies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER FUNCTION fnEnemies (@EpisodeId INT)
                RETURNS VARCHAR(MAX) AS
                BEGIN 
	            DECLARE @Ret AS VARCHAR(MAX)
	            SELECT @Ret=STRING_AGG (EnemyName,',') 
	            FROM fnEnemiesList(@EpisodeId);
	            RETURN @Ret
                END;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION fnEnemies");

        }
    }
}
