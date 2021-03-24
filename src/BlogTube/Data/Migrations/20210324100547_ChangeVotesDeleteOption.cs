using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogTube.Data.Migrations
{
    public partial class ChangeVotesDeleteOption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Articles_ArticleId",
                table: "Votes");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Articles_ArticleId",
                table: "Votes",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Articles_ArticleId",
                table: "Votes");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Articles_ArticleId",
                table: "Votes",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
