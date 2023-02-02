using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eHomeschool.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EducationalStages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false),
                    StageName = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalStages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InstructorsInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfilePictureURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Profession = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorsInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lectures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Week = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Syllabi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Objective = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Outcome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssessmentMethods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LearningMethods = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Syllabi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Short_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EducationalStageId = table.Column<int>(type: "int", nullable: false),
                    SyllabusId = table.Column<int>(type: "int", nullable: false),
                    InstructorInformationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_EducationalStages_EducationalStageId",
                        column: x => x.EducationalStageId,
                        principalTable: "EducationalStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courses_InstructorsInformation_InstructorInformationId",
                        column: x => x.InstructorInformationId,
                        principalTable: "InstructorsInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courses_Syllabi_SyllabusId",
                        column: x => x.SyllabusId,
                        principalTable: "Syllabi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lectures_Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    LectureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectures_Courses", x => new { x.LectureId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_Lectures_Courses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lectures_Courses_Lectures_LectureId",
                        column: x => x.LectureId,
                        principalTable: "Lectures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_EducationalStageId",
                table: "Courses",
                column: "EducationalStageId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_InstructorInformationId",
                table: "Courses",
                column: "InstructorInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_SyllabusId",
                table: "Courses",
                column: "SyllabusId");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_Courses_CourseId",
                table: "Lectures_Courses",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lectures_Courses");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Lectures");

            migrationBuilder.DropTable(
                name: "EducationalStages");

            migrationBuilder.DropTable(
                name: "InstructorsInformation");

            migrationBuilder.DropTable(
                name: "Syllabi");
        }
    }
}
