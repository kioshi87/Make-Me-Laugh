using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GoogleVisionApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "ImageStore",
                columns: table => new
                {
                    ImageStoreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageBase64String = table.Column<string>(nullable: true),
                    JoyLikelihood = table.Column<string>(nullable: true),
                    SorrowLikelihood = table.Column<string>(nullable: true),
                    AngerLikelihood = table.Column<string>(nullable: true),
                    SurpriseLikelihood = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    PlayerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageStore", x => x.ImageStoreId);
                    table.ForeignKey(
                        name: "FK_ImageStore_PlayerModel_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "PlayerModel",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageStore_PlayerId",
                table: "ImageStore",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageStore");

            migrationBuilder.DropTable(
                name: "PlayerModel");
        }
    }
}
