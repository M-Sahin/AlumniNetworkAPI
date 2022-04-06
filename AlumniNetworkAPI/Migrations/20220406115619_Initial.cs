using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlumniNetworkAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    group_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    isPrivate = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.group_id);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    topic_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.topic_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    picture = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    gender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    bio = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    fun_fact = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "GroupUser",
                columns: table => new
                {
                    Groupsgroup_id = table.Column<int>(type: "int", nullable: false),
                    UsersuserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupUser", x => new { x.Groupsgroup_id, x.UsersuserId });
                    table.ForeignKey(
                        name: "FK_GroupUser_Groups_Groupsgroup_id",
                        column: x => x.Groupsgroup_id,
                        principalTable: "Groups",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupUser_Users_UsersuserId",
                        column: x => x.UsersuserId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Post_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Body = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "TopicUser",
                columns: table => new
                {
                    Topicstopic_id = table.Column<int>(type: "int", nullable: false),
                    UsersuserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicUser", x => new { x.Topicstopic_id, x.UsersuserId });
                    table.ForeignKey(
                        name: "FK_TopicUser_Topics_Topicstopic_id",
                        column: x => x.Topicstopic_id,
                        principalTable: "Topics",
                        principalColumn: "topic_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopicUser_Users_UsersuserId",
                        column: x => x.UsersuserId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupUser_UsersuserId",
                table: "GroupUser",
                column: "UsersuserId");

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

            migrationBuilder.CreateIndex(
                name: "IX_TopicUser_UsersuserId",
                table: "TopicUser",
                column: "UsersuserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupUser");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "TopicUser");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
