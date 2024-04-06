using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeoBank.Migrations
{
    /// <inheritdoc />
    public partial class Amount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TransactionStatus",
                table: "Transactions",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "TransactionName",
                table: "Transactions",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "TransactionCategory",
                table: "Transactions",
                newName: "Category");

            migrationBuilder.RenameColumn(
                name: "TransactionAmount",
                table: "Transactions",
                newName: "Amount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Transactions",
                newName: "TransactionStatus");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Transactions",
                newName: "TransactionName");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Transactions",
                newName: "TransactionCategory");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Transactions",
                newName: "TransactionAmount");
        }
    }
}
