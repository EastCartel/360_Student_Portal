using Microsoft.EntityFrameworkCore.Migrations;

namespace Code_360.Migrations
{
    public partial class SemiMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employments_Companies_CompanyId",
                table: "Employments");

            migrationBuilder.DropForeignKey(
                name: "FK_Employments_Students_StudentId",
                table: "Employments");

            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_Employments_EmploymentId",
                table: "Salaries");

            migrationBuilder.DropTable(
                name: "StudentCompany");

            migrationBuilder.DropIndex(
                name: "IX_Salaries_EmploymentId",
                table: "Salaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employments",
                table: "Employments");

            migrationBuilder.DropIndex(
                name: "IX_Employments_StudentId",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "EmploymentId",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Employments");

            migrationBuilder.RenameTable(
                name: "Employments",
                newName: "Employment");

            migrationBuilder.RenameIndex(
                name: "IX_Employments_CompanyId",
                table: "Employment",
                newName: "IX_Employment_CompanyId");

            migrationBuilder.AddColumn<int>(
                name: "EmploymentCompanyId",
                table: "Salaries",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmploymentStudentId",
                table: "Salaries",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Employment",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employment",
                table: "Employment",
                columns: new[] { "StudentId", "CompanyId" });

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_EmploymentStudentId_EmploymentCompanyId",
                table: "Salaries",
                columns: new[] { "EmploymentStudentId", "EmploymentCompanyId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Employment_Companies_CompanyId",
                table: "Employment",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employment_Students_StudentId",
                table: "Employment",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Salaries_Employment_EmploymentStudentId_EmploymentCompanyId",
                table: "Salaries",
                columns: new[] { "EmploymentStudentId", "EmploymentCompanyId" },
                principalTable: "Employment",
                principalColumns: new[] { "StudentId", "CompanyId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employment_Companies_CompanyId",
                table: "Employment");

            migrationBuilder.DropForeignKey(
                name: "FK_Employment_Students_StudentId",
                table: "Employment");

            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_Employment_EmploymentStudentId_EmploymentCompanyId",
                table: "Salaries");

            migrationBuilder.DropIndex(
                name: "IX_Salaries_EmploymentStudentId_EmploymentCompanyId",
                table: "Salaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employment",
                table: "Employment");

            migrationBuilder.DropColumn(
                name: "EmploymentCompanyId",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "EmploymentStudentId",
                table: "Salaries");

            migrationBuilder.RenameTable(
                name: "Employment",
                newName: "Employments");

            migrationBuilder.RenameIndex(
                name: "IX_Employment_CompanyId",
                table: "Employments",
                newName: "IX_Employments_CompanyId");

            migrationBuilder.AddColumn<int>(
                name: "EmploymentId",
                table: "Salaries",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Employments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Employments",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employments",
                table: "Employments",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "StudentCompany",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCompany", x => new { x.StudentId, x.CompanyId });
                    table.ForeignKey(
                        name: "FK_StudentCompany_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCompany_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_EmploymentId",
                table: "Salaries",
                column: "EmploymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employments_StudentId",
                table: "Employments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCompany_CompanyId",
                table: "StudentCompany",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employments_Companies_CompanyId",
                table: "Employments",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employments_Students_StudentId",
                table: "Employments",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Salaries_Employments_EmploymentId",
                table: "Salaries",
                column: "EmploymentId",
                principalTable: "Employments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
