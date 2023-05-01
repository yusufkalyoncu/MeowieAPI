using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeowieAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "imdbRatingCount",
                table: "Movies",
                newName: "ImdbRatingCount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImdbRatingCount",
                table: "Movies",
                newName: "imdbRatingCount");
        }
    }
}
