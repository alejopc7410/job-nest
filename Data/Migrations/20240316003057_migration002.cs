using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JNFinalProject.Data.Migrations
{
    public partial class migration002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEmployer",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEmployer",
                table: "AspNetUsers");
        }
    }
}
