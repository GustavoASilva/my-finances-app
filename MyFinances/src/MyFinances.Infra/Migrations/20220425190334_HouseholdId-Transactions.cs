using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFinances.Infra.Migrations
{
    public partial class HouseholdIdTransactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HouseholdId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HouseholdId",
                table: "Transactions");
        }
    }
}
