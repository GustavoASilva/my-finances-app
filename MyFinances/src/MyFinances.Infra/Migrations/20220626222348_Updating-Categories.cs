using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFinances.Infra.Migrations
{
    public partial class UpdatingCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TransactionCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Refeição");

            migrationBuilder.UpdateData(
                table: "TransactionCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Pets");

            migrationBuilder.InsertData(
                table: "TransactionCategory",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Outros" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TransactionCategory",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "TransactionCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Alimentação");

            migrationBuilder.UpdateData(
                table: "TransactionCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Outros");
        }
    }
}
