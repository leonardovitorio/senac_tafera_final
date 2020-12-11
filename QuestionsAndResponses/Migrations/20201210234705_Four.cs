using Microsoft.EntityFrameworkCore.Migrations;

namespace QuestionsAndResponses.Migrations
{
    public partial class Four : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Questions_QuestionId1",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_Responses_QuestionId1",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "QuestionId1",
                table: "Responses");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "Responses",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_QuestionId",
                table: "Responses",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Questions_QuestionId",
                table: "Responses",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Questions_QuestionId",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_Responses_QuestionId",
                table: "Responses");

            migrationBuilder.AlterColumn<string>(
                name: "QuestionId",
                table: "Responses",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "QuestionId1",
                table: "Responses",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Responses_QuestionId1",
                table: "Responses",
                column: "QuestionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Questions_QuestionId1",
                table: "Responses",
                column: "QuestionId1",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
