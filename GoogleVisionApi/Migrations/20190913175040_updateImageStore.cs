using Microsoft.EntityFrameworkCore.Migrations;

namespace GoogleVisionApi.Migrations
{
    public partial class updateImageStore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AngerLikelihood",
                table: "ImageStore",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JoyLikelihood",
                table: "ImageStore",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SorrowLikelihood",
                table: "ImageStore",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SurpriseLikelihood",
                table: "ImageStore",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AngerLikelihood",
                table: "ImageStore");

            migrationBuilder.DropColumn(
                name: "JoyLikelihood",
                table: "ImageStore");

            migrationBuilder.DropColumn(
                name: "SorrowLikelihood",
                table: "ImageStore");

            migrationBuilder.DropColumn(
                name: "SurpriseLikelihood",
                table: "ImageStore");
        }
    }
}
