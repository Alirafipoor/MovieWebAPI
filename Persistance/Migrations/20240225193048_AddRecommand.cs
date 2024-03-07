using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddRecommand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Movies_MoviesId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRatings_Movies_MoviesId",
                table: "UserRatings");

            migrationBuilder.DropIndex(
                name: "IX_UserRatings_MoviesId",
                table: "UserRatings");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_MoviesId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "MoviesId",
                table: "UserRatings");

            migrationBuilder.DropColumn(
                name: "MoviesId",
                table: "Reviews");

            migrationBuilder.AddColumn<string>(
                name: "Recommand",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Recommand",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "MoviesId",
                table: "UserRatings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MoviesId",
                table: "Reviews",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRatings_MoviesId",
                table: "UserRatings",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_MoviesId",
                table: "Reviews",
                column: "MoviesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Movies_MoviesId",
                table: "Reviews",
                column: "MoviesId",
                principalTable: "Movies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRatings_Movies_MoviesId",
                table: "UserRatings",
                column: "MoviesId",
                principalTable: "Movies",
                principalColumn: "Id");
        }
    }
}
