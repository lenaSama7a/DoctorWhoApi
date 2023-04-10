using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddfnEnemiesList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE OR ALTER FUNCTION fnEnemiesList (@EpsoidId INT)
                RETURNS TABLE AS
                RETURN
	            SELECT n.EnemyName
	            FROM EpisodeEnemies e JOIN Enemies n ON(e.EnemyId=n.EnemyId)
	            WHERE e.EpisodeId = @EpsoidId
                GO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION fnEnemiesList");
        }
    }
}
