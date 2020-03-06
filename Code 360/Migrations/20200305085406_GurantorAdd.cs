using Microsoft.EntityFrameworkCore.Migrations;

namespace Code_360.Migrations
{
    public partial class GurantorAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Guarantors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Guarantors");
        }
    }
}
