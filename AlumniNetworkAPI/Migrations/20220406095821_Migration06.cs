using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlumniNetworkAPI.Migrations
{
    public partial class Migration06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Post_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Body = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", rowVersion: true, nullable: false),
                    SenderUser_Id = table.Column<int>(type: "int", nullable: false),
                    ReplyPost_Id = table.Column<int>(type: "int", nullable: true),
                    TargetUser_Id = table.Column<int>(type: "int", nullable: true),
                    TargetGroup_Id = table.Column<int>(type: "int", nullable: true),
                    TargetTopic_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Post_Id);
                    table.ForeignKey(
                        name: "FK_Post_Groups_TargetGroupIdgroup_id",
                        column: x => x.TargetGroup_Id,
                        principalTable: "Groups",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_Post_ReplyParentIdPost_Id",
                        column: x => x.ReplyPost_Id,
                        principalTable: "Post",
                        principalColumn: "Post_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_Topics_TargetTopicIdtopic_id",
                        column: x => x.TargetTopic_Id,
                        principalTable: "Topics",
                        principalColumn: "topic_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_Users_SenderUserIduserId",
                        column: x => x.SenderUser_Id,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Post_Users_TargetUserIduserId",
                        column: x => x.TargetUser_Id,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Post_ReplyParentIdPost_Id",
                table: "Post",
                column: "ReplyPost_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Post_SenderUserIduserId",
                table: "Post",
                column: "SenderUser_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Post_TargetGroupIdgroup_id",
                table: "Post",
                column: "TargetGroup_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Post_TargetTopicIdtopic_id",
                table: "Post",
                column: "TargetTopic_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Post_TargetUserIduserId",
                table: "Post",
                column: "TargetUser_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Post");
        }
    }
}
