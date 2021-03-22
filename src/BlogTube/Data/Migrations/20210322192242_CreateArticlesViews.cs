﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogTube.Data.Migrations
{
    public partial class CreateArticlesViews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Views",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Views",
                table: "Articles");
        }
    }
}
