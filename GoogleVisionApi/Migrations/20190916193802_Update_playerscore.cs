using Microsoft.EntityFrameworkCore.Migrations;

namespace GoogleVisionApi.Migrations
{
    public partial class Update_playerscore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Score",
                table: "PlayerModel",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Score",
                table: "PlayerModel",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
