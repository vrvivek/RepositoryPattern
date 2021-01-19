using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryPatternAPP.Migrations
{
    public partial class StudentRPDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    S_FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    S_LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    S_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    S_EnrollmentNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
