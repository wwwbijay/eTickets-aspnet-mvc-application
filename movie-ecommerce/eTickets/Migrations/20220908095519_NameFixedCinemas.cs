using Microsoft.EntityFrameworkCore.Migrations;

namespace eTickets.Migrations
{
    public partial class NameFixedCinemas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Cinamas_CinemaId",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cinamas",
                table: "Cinamas");

            migrationBuilder.RenameTable(
                name: "Cinamas",
                newName: "Cinemas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cinemas",
                table: "Cinemas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Cinemas_CinemaId",
                table: "Movies",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Cinemas_CinemaId",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cinemas",
                table: "Cinemas");

            migrationBuilder.RenameTable(
                name: "Cinemas",
                newName: "Cinamas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cinamas",
                table: "Cinamas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Cinamas_CinemaId",
                table: "Movies",
                column: "CinemaId",
                principalTable: "Cinamas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
