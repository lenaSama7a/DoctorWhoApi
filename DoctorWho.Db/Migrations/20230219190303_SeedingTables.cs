using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DoctorWho.Db.Migrations
{
    /// <inheritdoc />
    public partial class SeedingTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Episodes",
                type: "varchar(600)",
                nullable: true,
                defaultValueSql: "Null",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EpisodeDate",
                table: "Episodes",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "Null",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Enemies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValueSql: "Null",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastEpisodeDate",
                table: "Doctors",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "Null",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FirstEpisodeDate",
                table: "Doctors",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "Null",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Doctors",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "Null",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "AuthorName" },
                values: new object[,]
                {
                    { 1, "Edwidge Danticat" },
                    { 2, "Ernest Hemingway" },
                    { 3, "Saul Bellow" },
                    { 4, "Sidney Sheldon" },
                    { 5, "Franz Kafka" }
                });

            migrationBuilder.InsertData(
                table: "Companions",
                columns: new[] { "CompanionId", "CompanionName", "WhoPlayed" },
                values: new object[,]
                {
                    { 1, "Ezra Pound", "Agatha Christie" },
                    { 2, "Tennessee Williams", "Danielle Steel" },
                    { 3, "Willa Cather", "Lord Byron" },
                    { 4, "Langston Hughes", "Somerset Maugham" },
                    { 5, "Joan Didion", "Djuna Barnes" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorId", "DoctorName", "DoctorNumber" },
                values: new object[,]
                {
                    { 1, "Smith", 1 },
                    { 2, "Taylor", 2 },
                    { 3, "Brown", 3 },
                    { 4, "Williams", 4 },
                    { 5, "Barker", 5 }
                });

            migrationBuilder.InsertData(
                table: "Enemies",
                columns: new[] { "EnemyId", "Description", "EnemyName" },
                values: new object[,]
                {
                    { 1, "the killer", "Kingsley Amis" },
                    { 2, "the suspect", "Fannie Flagg" },
                    { 3, "turns into a monster", "Iceberg Slim" },
                    { 4, "the thief", "Camille Paglia" },
                    { 5, "The bully", "Maria Orczy" }
                });

            migrationBuilder.InsertData(
                table: "Episodes",
                columns: new[] { "EpisodeId", "AuthorId", "DoctorId", "EpisodeDate", "EpisodeNumber", "EpisodeType", "SeriesNumber", "Title" },
                values: new object[,]
                {
                    { 1, 1, 2, new DateTime(2000, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "special", 1, "Wednesdays Child Is Full of Woe" },
                    { 2, 2, 2, new DateTime(2002, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Filler", 1, "Woe Is the Loneliest Number" },
                    { 3, 2, 1, new DateTime(2007, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Classic", 2, "Friend or Woe" },
                    { 4, 2, 3, new DateTime(2010, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Filler", 2, "Quid Pro Woe" },
                    { 5, 3, 4, new DateTime(2020, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Classic", 3, "A Murder of Woes" }
                });

            migrationBuilder.InsertData(
                table: "EpisodeCompanions",
                columns: new[] { "EpisodeCompanionId", "CompanionId", "EpisodeId" },
                values: new object[,]
                {
                    { 1, 2, 1 },
                    { 2, 3, 2 },
                    { 3, 5, 2 },
                    { 4, 4, 3 },
                    { 5, 1, 4 },
                    { 6, 3, 5 },
                    { 7, 2, 5 },
                    { 8, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "EpisodeEnemies",
                columns: new[] { "EpisodeEnemyId", "EnemyId", "EpisodeId" },
                values: new object[,]
                {
                    { 1, 3, 1 },
                    { 2, 4, 1 },
                    { 3, 1, 2 },
                    { 4, 3, 2 },
                    { 5, 5, 2 },
                    { 6, 4, 4 },
                    { 7, 3, 4 },
                    { 8, 2, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanions",
                keyColumn: "EpisodeCompanionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanions",
                keyColumn: "EpisodeCompanionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanions",
                keyColumn: "EpisodeCompanionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanions",
                keyColumn: "EpisodeCompanionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanions",
                keyColumn: "EpisodeCompanionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanions",
                keyColumn: "EpisodeCompanionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanions",
                keyColumn: "EpisodeCompanionId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanions",
                keyColumn: "EpisodeCompanionId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemies",
                keyColumn: "EpisodeEnemyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemies",
                keyColumn: "EpisodeEnemyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemies",
                keyColumn: "EpisodeEnemyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemies",
                keyColumn: "EpisodeEnemyId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemies",
                keyColumn: "EpisodeEnemyId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemies",
                keyColumn: "EpisodeEnemyId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemies",
                keyColumn: "EpisodeEnemyId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemies",
                keyColumn: "EpisodeEnemyId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 4);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Episodes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(600)",
                oldNullable: true,
                oldDefaultValueSql: "Null");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EpisodeDate",
                table: "Episodes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "Null");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Enemies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValueSql: "Null");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastEpisodeDate",
                table: "Doctors",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "Null");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FirstEpisodeDate",
                table: "Doctors",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "Null");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Doctors",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "Null");
        }
    }
}
