using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddViewEpisodes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER VIEW ViewEpisodes 
                AS
                SELECT a.AuthorName,d.DoctorName, dbo.fnCompanions(e.EpisodeId) AS Companions, dbo.fnEnemies(e.EpisodeId) AS Enemies
                FROM Episodes e LEFT JOIN Authors a ON(e.AuthorID=a.AuthorId)
                LEFT JOIN Doctors d ON(e.DoctorId=d.DoctorId)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Drop View ViewEpisodes");
        }
    }
}
