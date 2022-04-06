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
                    SenderUserIduserId = table.Column<int>(type: "int", nullable: false),
                    ReplyParentIdPost_Id = table.Column<int>(type: "int", nullable: true),
                    TargetUserIduserId = table.Column<int>(type: "int", nullable: true),
                    TargetGroupIdgroup_id = table.Column<int>(type: "int", nullable: true),
                    TargetTopicIdtopic_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Post_Id);
                    table.ForeignKey(
                        name: "FK_Post_Groups_TargetGroupIdgroup_id",
                        column: x => x.TargetGroupIdgroup_id,
                        principalTable: "Groups",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_Post_ReplyParentIdPost_Id",
                        column: x => x.ReplyParentIdPost_Id,
                        principalTable: "Post",
                        principalColumn: "Post_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_Topics_TargetTopicIdtopic_id",
                        column: x => x.TargetTopicIdtopic_id,
                        principalTable: "Topics",
                        principalColumn: "topic_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_Users_SenderUserIduserId",
                        column: x => x.SenderUserIduserId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Post_Users_TargetUserIduserId",
                        column: x => x.TargetUserIduserId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Post_ReplyParentIdPost_Id",
                table: "Post",
                column: "ReplyParentIdPost_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Post_SenderUserIduserId",
                table: "Post",
                column: "SenderUserIduserId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_TargetGroupIdgroup_id",
                table: "Post",
                column: "TargetGroupIdgroup_id");

            migrationBuilder.CreateIndex(
                name: "IX_Post_TargetTopicIdtopic_id",
                table: "Post",
                column: "TargetTopicIdtopic_id");

            migrationBuilder.CreateIndex(
                name: "IX_Post_TargetUserIduserId",
                table: "Post",
                column: "TargetUserIduserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Post");
        }
    }
}
