using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GoogleVisionApi.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayerId1",
                table: "ImageStore",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PlayerModel",
                columns: table => new
                {
                    PlayerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlayerName = table.Column<string>(nullable: true),
                    GameStartTimeStamp = table.Column<string>(nullable: true),
                    Win = table.Column<bool>(nullable: false),
                    Score = table.Column<string>(nullable: true),
                    FunniestPictures = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerModel", x => x.PlayerId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageStore_PlayerId1",
                table: "ImageStore",
                column: "PlayerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageStore_PlayerModel_PlayerId1",
                table: "ImageStore",
                column: "PlayerId1",
                principalTable: "PlayerModel",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageStore_PlayerModel_PlayerId1",
                table: "ImageStore");

            migrationBuilder.DropTable(
                name: "PlayerModel");

            migrationBuilder.DropIndex(
                name: "IX_ImageStore_PlayerId1",
                table: "ImageStore");

            migrationBuilder.DropColumn(
                name: "PlayerId1",
                table: "ImageStore");
        }
    }
}
