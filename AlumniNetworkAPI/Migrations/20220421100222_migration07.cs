using Microsoft.EntityFrameworkCore.Migrations;

namespace AlumniNetworkAPI.Migrations
{
    public partial class migration07 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostReplyPost_Id",
                table: "Replies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Replies_PostReplyPost_Id",
                table: "Replies",
                column: "PostReplyPost_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_Posts_PostReplyPost_Id",
                table: "Replies",
                column: "PostReplyPost_Id",
                principalTable: "Posts",
                principalColumn: "Post_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Replies_Posts_PostReplyPost_Id",
                table: "Replies");

            migrationBuilder.DropIndex(
                name: "IX_Replies_PostReplyPost_Id",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "PostReplyPost_Id",
                table: "Replies");
        }
    }
}
