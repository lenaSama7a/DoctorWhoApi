using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddfnCompanionsList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE OR ALTER FUNCTION fnCompanionsList (@EpisodeId INT)
                RETURNS Table As
                RETURN
                SELECT C.CompanionName 
                FROM Companions as C INNER JOIN EpisodeCompanions as EC ON  C.CompanionId = EC.CompanionId
                WHERE EpisodeId = @EpisodeId;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP FUNCTION fnCompanionsNamesList");

        }
    }
}
