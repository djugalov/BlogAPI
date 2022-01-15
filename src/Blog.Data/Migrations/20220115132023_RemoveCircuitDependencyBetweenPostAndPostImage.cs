using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Data.Migrations
{
    public partial class RemoveCircuitDependencyBetweenPostAndPostImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostsImages_Posts_post_id",
                table: "PostsImages");

            migrationBuilder.DropIndex(
                name: "IX_PostsImages_post_id",
                table: "PostsImages");

            migrationBuilder.DropColumn(
                name: "post_id",
                table: "PostsImages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "post_id",
                table: "PostsImages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostsImages_post_id",
                table: "PostsImages",
                column: "post_id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostsImages_Posts_post_id",
                table: "PostsImages",
                column: "post_id",
                principalTable: "Posts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
