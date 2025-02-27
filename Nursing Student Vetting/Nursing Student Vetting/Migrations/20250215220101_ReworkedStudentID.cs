using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Nursing_Student_Vetting.Migrations
{
    /// <inheritdoc />
    public partial class ReworkedStudentID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassCategories",
                columns: table => new
                {
                    CategoryPrefix = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassCategories", x => x.CategoryPrefix);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EvaluationScore = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GraduationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    TestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradingScale = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.TestID);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassID = table.Column<int>(type: "int", nullable: false),
                    CategoryPrefix = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreditHours = table.Column<int>(type: "int", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => new { x.ClassID, x.CategoryPrefix });
                    table.ForeignKey(
                        name: "FK_Classes_ClassCategories_CategoryPrefix",
                        column: x => x.CategoryPrefix,
                        principalTable: "ClassCategories",
                        principalColumn: "CategoryPrefix",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentTests",
                columns: table => new
                {
                    TestID = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AttemptNumber = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTests", x => new { x.TestID, x.AttemptNumber, x.StudentID });
                    table.ForeignKey(
                        name: "FK_StudentTests_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentTests_Tests_TestID",
                        column: x => x.TestID,
                        principalTable: "Tests",
                        principalColumn: "TestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentClasses",
                columns: table => new
                {
                    ClassID = table.Column<int>(type: "int", nullable: false),
                    CategoryPrefix = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StudentID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LetterGrade = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentClasses", x => new { x.ClassID, x.CategoryPrefix, x.StudentID });
                    table.ForeignKey(
                        name: "FK_StudentClasses_Classes_ClassID_CategoryPrefix",
                        columns: x => new { x.ClassID, x.CategoryPrefix },
                        principalTable: "Classes",
                        principalColumns: new[] { "ClassID", "CategoryPrefix" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentClasses_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ClassCategories",
                columns: new[] { "CategoryPrefix", "CategoryName" },
                values: new object[,]
                {
                    { "ACCT", "Accounting" },
                    { "AGRI", "Agriculture" },
                    { "AGRM", "Agriculture" },
                    { "ANTH", "Anthropology" },
                    { "ART", "Art" },
                    { "ARTP", "Art Performance" },
                    { "ASTR", "Astronomy" },
                    { "BIOL", "Biology" },
                    { "BUSN", "Business" },
                    { "CHEM", "Chemistry" },
                    { "CISP", "Computer Science" },
                    { "CITC", "Computer Info Tech" },
                    { "COMM", "Communications" },
                    { "CRMJ", "Criminal Justice" },
                    { "CULA", "Culinary Arts" },
                    { "DIGM", "Digital Media" },
                    { "ECED", "Early Childhood Education" },
                    { "ECON", "Economics" },
                    { "EDUC", "Education" },
                    { "EETC", "Electrical Engin Tech" },
                    { "EGRT", "Engineering Technology" },
                    { "EMSA", "Emergency Med Service" },
                    { "EMSB", "Emergency Med Service" },
                    { "EMSP", "Emergency Med Serv Para" },
                    { "ENGL", "English" },
                    { "ENGR", "Engineering" },
                    { "ENST", "Engineering Systems Tech" },
                    { "FIRE", "Fire Science" },
                    { "FREN", "French" },
                    { "GEOG", "Geography" },
                    { "GEOL", "Geology" },
                    { "HGMT", "Hospitality Management" },
                    { "HIMT", "Health Information Management" },
                    { "HIST", "History" },
                    { "HLTH", "Health" },
                    { "HUM", "Humanities" },
                    { "INFS", "Information Systems" },
                    { "LEGL", "Paralegal" },
                    { "MATH", "Mathematics" },
                    { "MUS", "Music" },
                    { "NRSG", "Nursing" },
                    { "OTAP", "Occupational Thrpy Asst" },
                    { "PHED", "Physical Education" },
                    { "PHIL", "Philosophy" },
                    { "PHRX", "Pharmacy Technician" },
                    { "PHYS", "Physics" },
                    { "POLS", "Political Science" },
                    { "PSCI", "Physical Science" },
                    { "PSYC", "Psychology" },
                    { "PTAT", "Physical Therapist Asst" },
                    { "READ", "Reading" },
                    { "RELS", "Religion" },
                    { "RESP", "Respiratory Care" },
                    { "SOCI", "Sociology" },
                    { "SPAN", "Spanish" },
                    { "SPED", "Special Education" },
                    { "SURG", "Surgical Technology" },
                    { "SWRK", "Social Work" },
                    { "THEA", "Theatre" },
                    { "WGST", "Women/Gender Studies" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentID", "Address", "DateOfBirth", "Email", "EvaluationScore", "FirstName", "Gender", "GraduationDate", "LastName", "StartDate" },
                values: new object[,]
                {
                    { "W00001001", "123 Example St", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", 0, "John", "Male", new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doe", new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "W00001002", "456 Example Ave", new DateTime(1999, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", 0, "Jane", "Female", null, "Smith", new DateTime(2021, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "TestID", "GradingScale", "TestName" },
                values: new object[,]
                {
                    { 1, 36, "ACT" },
                    { 2, 100, "Designated Test" }
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "CategoryPrefix", "ClassID", "ClassName", "CreditHours", "IsRequired" },
                values: new object[,]
                {
                    { "ACCT", 1010, "Principles of Accounting I", 3, false },
                    { "BIOL", 2010, "Human Anatomy and Physiology I", 3, true }
                });

            migrationBuilder.InsertData(
                table: "StudentTests",
                columns: new[] { "AttemptNumber", "StudentID", "TestID", "Score" },
                values: new object[,]
                {
                    { 1, "W00001001", 1, 22 },
                    { 1, "W00001001", 2, 74 },
                    { 1, "W00001002", 2, 92 },
                    { 2, "W00001002", 2, 94 }
                });

            migrationBuilder.InsertData(
                table: "StudentClasses",
                columns: new[] { "CategoryPrefix", "ClassID", "StudentID", "LetterGrade" },
                values: new object[,]
                {
                    { "ACCT", 1010, "W00001001", "A" },
                    { "ACCT", 1010, "W00001002", "A" },
                    { "BIOL", 2010, "W00001001", "B" },
                    { "BIOL", 2010, "W00001002", "C" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_CategoryPrefix",
                table: "Classes",
                column: "CategoryPrefix");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClasses_StudentID",
                table: "StudentClasses",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTests_StudentID",
                table: "StudentTests",
                column: "StudentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentClasses");

            migrationBuilder.DropTable(
                name: "StudentTests");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "ClassCategories");
        }
    }
}
