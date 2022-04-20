using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlumniNetworkAPI.Migrations
{
    public partial class migration06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RepliesReply_Id",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Replies",
                columns: table => new
                {
                    Reply_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Body = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replies", x => x.Reply_Id);
                });

            migrationBuilder.CreateTable(
                name: "PostReplies",
                columns: table => new
                {
                    PostReply_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Postpost_id = table.Column<int>(type: "int", nullable: false),
                    Replyreply_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostReplies", x => x.PostReply_Id);
                    table.ForeignKey(
                        name: "FK_PostReplies_Posts_Postpost_id",
                        column: x => x.Postpost_id,
                        principalTable: "Posts",
                        principalColumn: "Post_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostReplies_Replies_Replyreply_Id",
                        column: x => x.Replyreply_Id,
                        principalTable: "Replies",
                        principalColumn: "Reply_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_RepliesReply_Id",
                table: "Posts",
                column: "RepliesReply_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PostReplies_Postpost_id",
                table: "PostReplies",
                column: "Postpost_id");

            migrationBuilder.CreateIndex(
                name: "IX_PostReplies_Replyreply_Id",
                table: "PostReplies",
                column: "Replyreply_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Replies_RepliesReply_Id",
                table: "Posts",
                column: "RepliesReply_Id",
                principalTable: "Replies",
                principalColumn: "Reply_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Replies_RepliesReply_Id",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "PostReplies");

            migrationBuilder.DropTable(
                name: "Replies");

            migrationBuilder.DropIndex(
                name: "IX_Posts_RepliesReply_Id",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "RepliesReply_Id",
                table: "Posts");
        }
    }
}
