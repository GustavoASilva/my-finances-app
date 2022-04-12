using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFinances.Infra.Migrations
{
    public partial class AlterCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Transactions",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "TransactionCategory",
                table: "Recurrences",
                newName: "TransactionCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Transactions",
                newName: "Category");

            migrationBuilder.RenameColumn(
                name: "TransactionCategoryId",
                table: "Recurrences",
                newName: "TransactionCategory");
        }
    }
}
