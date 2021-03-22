using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogTube.Data.Migrations
{
    public partial class CreateVotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vote",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ArticleId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vote_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vote_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vote_ArticleId",
                table: "Vote",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vote_AuthorId",
                table: "Vote",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vote");
        }
    }
}
