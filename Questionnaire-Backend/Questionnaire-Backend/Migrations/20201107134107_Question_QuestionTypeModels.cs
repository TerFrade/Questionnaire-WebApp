using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Questionnaire_Backend.Migrations
{
    public partial class Question_QuestionTypeModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestionType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    QuestionText = table.Column<string>(nullable: true),
                    Picture = table.Column<byte[]>(nullable: true),
                    IsRequired = table.Column<bool>(nullable: false),
                    QuestionnaireId = table.Column<Guid>(nullable: false),
                    QuestionTypeId = table.Column<int>(nullable: false),
                    AvailableAnswers = table.Column<string>(nullable: true),
                    Responses = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Question_QuestionType_QuestionTypeId",
                        column: x => x.QuestionTypeId,
                        principalTable: "QuestionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Question_Questionnaires_QuestionnaireId",
                        column: x => x.QuestionnaireId,
                        principalTable: "Questionnaires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "QuestionType",
                columns: new[] { "Id", "TypeName" },
                values: new object[,]
                {
                    { 1, "Mutliple Choice" },
                    { 2, "Dropdown" },
                    { 3, "Short Input" },
                    { 4, "Long Input" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Question_QuestionTypeId",
                table: "Question",
                column: "QuestionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_QuestionnaireId",
                table: "Question",
                column: "QuestionnaireId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "QuestionType");
        }
    }
}
