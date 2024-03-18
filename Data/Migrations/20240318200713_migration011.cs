using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JNFinalProject.Data.Migrations
{
    public partial class migration011 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationSent",
                table: "Job");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ApplicationSent",
                table: "Job",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
