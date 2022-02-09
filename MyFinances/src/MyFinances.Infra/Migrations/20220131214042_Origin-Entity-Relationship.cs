using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFinances.Infra.Migrations
{
    public partial class OriginEntityRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Transactions_OriginId",
                table: "Transactions",
                column: "OriginId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Origins_OriginId",
                table: "Transactions",
                column: "OriginId",
                principalTable: "Origins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Origins_OriginId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_OriginId",
                table: "Transactions");
        }
    }
}
