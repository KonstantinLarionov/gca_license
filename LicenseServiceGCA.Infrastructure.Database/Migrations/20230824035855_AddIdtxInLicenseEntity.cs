using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LicenseServiceGCA.Infrastructure.Database.Migrations
{
    public partial class AddIdtxInLicenseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Idtx",
                table: "Licenses",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Idtx",
                table: "Licenses");
        }
    }
}
