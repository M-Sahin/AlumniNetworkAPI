using Microsoft.EntityFrameworkCore.Migrations;

namespace AlumniNetworkAPI.Migrations
{
    public partial class keycloak : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_SenderUserId",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "KeycloakId",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SenderUserId",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_SenderUserId",
                table: "Posts",
                column: "SenderUserId",
                principalTable: "Users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_SenderUserId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "KeycloakId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "SenderUserId",
                table: "Posts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_SenderUserId",
                table: "Posts",
                column: "SenderUserId",
                principalTable: "Users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
