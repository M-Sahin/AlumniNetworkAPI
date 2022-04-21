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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Post_Id",
                table: "Replies");
        }
    }
}
