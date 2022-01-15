using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Data.Migrations
{
    public partial class AddImageColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "post_image",
                table: "Posts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_post_image",
                table: "Posts",
                column: "post_image");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_PostsImages_post_image",
                table: "Posts",
                column: "post_image",
                principalTable: "PostsImages",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_PostsImages_post_image",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_post_image",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "post_image",
                table: "Posts");
        }
    }
}
