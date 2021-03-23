using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogTube.Data.Migrations
{
    public partial class CreateVotesDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vote_Articles_ArticleId",
                table: "Vote");

            migrationBuilder.DropForeignKey(
                name: "FK_Vote_AspNetUsers_AuthorId",
                table: "Vote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vote",
                table: "Vote");

            migrationBuilder.RenameTable(
                name: "Vote",
                newName: "Votes");

            migrationBuilder.RenameIndex(
                name: "IX_Vote_AuthorId",
                table: "Votes",
                newName: "IX_Votes_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Vote_ArticleId",
                table: "Votes",
                newName: "IX_Votes_ArticleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Votes",
                table: "Votes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Articles_ArticleId",
                table: "Votes",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_AspNetUsers_AuthorId",
                table: "Votes",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Articles_ArticleId",
                table: "Votes");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_AspNetUsers_AuthorId",
                table: "Votes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Votes",
                table: "Votes");

            migrationBuilder.RenameTable(
                name: "Votes",
                newName: "Vote");

            migrationBuilder.RenameIndex(
                name: "IX_Votes_AuthorId",
                table: "Vote",
                newName: "IX_Vote_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Votes_ArticleId",
                table: "Vote",
                newName: "IX_Vote_ArticleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vote",
                table: "Vote",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vote_Articles_ArticleId",
                table: "Vote",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vote_AspNetUsers_AuthorId",
                table: "Vote",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
