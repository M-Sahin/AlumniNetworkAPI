using Microsoft.EntityFrameworkCore.Migrations;

namespace AlumniNetworkAPI.Migrations
{
    public partial class migration07 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Post_Id",
                table: "Replies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PostReply",
                columns: table => new
                {
                    PostsPost_Id = table.Column<int>(type: "int", nullable: false),
                    RepliesReply_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostReply", x => new { x.PostsPost_Id, x.RepliesReply_Id });
                    table.ForeignKey(
                        name: "FK_PostReply_Posts_PostsPost_Id",
                        column: x => x.PostsPost_Id,
                        principalTable: "Posts",
                        principalColumn: "Post_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostReply_Replies_RepliesReply_Id",
                        column: x => x.RepliesReply_Id,
                        principalTable: "Replies",
                        principalColumn: "Reply_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostReply_RepliesReply_Id",
                table: "PostReply",
                column: "RepliesReply_Id");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostReply");

            migrationBuilder.DropColumn(
                name: "Post_Id",
                table: "Replies");
        }


    }
}
