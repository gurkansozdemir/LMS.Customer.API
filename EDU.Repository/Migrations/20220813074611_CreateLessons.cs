using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDU.Repository.Migrations
{
    public partial class CreateLessons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LessonId",
                table: "Activities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EducationId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_Educations_EducationId",
                        column: x => x.EducationId,
                        principalTable: "Educations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inspections_ActivityId",
                table: "Inspections",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspections_StudentId",
                table: "Inspections",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_LessonId",
                table: "Activities",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_EducationId",
                table: "Lessons",
                column: "EducationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Lessons_LessonId",
                table: "Activities",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inspections_Activities_ActivityId",
                table: "Inspections",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inspections_Users_StudentId",
                table: "Inspections",
                column: "StudentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Lessons_LessonId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Inspections_Activities_ActivityId",
                table: "Inspections");

            migrationBuilder.DropForeignKey(
                name: "FK_Inspections_Users_StudentId",
                table: "Inspections");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Inspections_ActivityId",
                table: "Inspections");

            migrationBuilder.DropIndex(
                name: "IX_Inspections_StudentId",
                table: "Inspections");

            migrationBuilder.DropIndex(
                name: "IX_Activities_LessonId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "Activities");
        }
    }
}
