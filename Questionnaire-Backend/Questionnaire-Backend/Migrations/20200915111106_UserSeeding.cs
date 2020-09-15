using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Questionnaire_Backend.Migrations
{
    public partial class UserSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "RoleId", "Username" },
                values: new object[] { new Guid("076368ce-1ff7-4a58-bbfd-41838eeca5a4"), "TerenceFrade@gmail.com", "asdasd1", 1, "zENJA" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("076368ce-1ff7-4a58-bbfd-41838eeca5a4"));
        }
    }
}
