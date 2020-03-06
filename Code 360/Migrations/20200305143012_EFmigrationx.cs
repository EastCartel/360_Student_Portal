using Microsoft.EntityFrameworkCore.Migrations;

namespace Code_360.Migrations
{
    public partial class EFmigrationx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guarantors_Students_StudentId",
                table: "Guarantors");

            migrationBuilder.DropIndex(
                name: "IX_Guarantors_StudentId",
                table: "Guarantors");

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    StudentId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Link = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentGurantors",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    GuarantorsId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentGurantors", x => new { x.StudentId, x.GuarantorsId });
                    table.ForeignKey(
                        name: "FK_StudentGurantors_Guarantors_GuarantorsId",
                        column: x => x.GuarantorsId,
                        principalTable: "Guarantors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentGurantors_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentInBatches",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    BatchId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Grade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentInBatches", x => new { x.StudentId, x.BatchId });
                    table.ForeignKey(
                        name: "FK_StudentInBatches_Batches_BatchId",
                        column: x => x.BatchId,
                        principalTable: "Batches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentInBatches_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_StudentId",
                table: "Project",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGurantors_GuarantorsId",
                table: "StudentGurantors",
                column: "GuarantorsId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInBatches_BatchId",
                table: "StudentInBatches",
                column: "BatchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "StudentGurantors");

            migrationBuilder.DropTable(
                name: "StudentInBatches");

            migrationBuilder.CreateIndex(
                name: "IX_Guarantors_StudentId",
                table: "Guarantors",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guarantors_Students_StudentId",
                table: "Guarantors",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
