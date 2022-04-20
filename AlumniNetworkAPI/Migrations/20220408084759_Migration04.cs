using Microsoft.EntityFrameworkCore.Migrations;

namespace AlumniNetworkAPI.Migrations
{
    public partial class Migration04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventUserInvites",
                columns: table => new
                {
                    EventUserInviteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventUserInvites", x => x.EventUserInviteId);
                    table.ForeignKey(
                        name: "FK_EventUserInvites_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Event_Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EventUserInvites_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventUserInvites_EventId",
                table: "EventUserInvites",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventUserInvites_UserId",
                table: "EventUserInvites",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventUserInvites");
        }
    }
}
