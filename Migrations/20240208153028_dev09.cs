using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace contasoft_api.Migrations
{
    public partial class dev09 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "O607");

            migrationBuilder.DropColumn(
                name: "ITBISTotal",
                table: "O607");

            migrationBuilder.DropColumn(
                name: "InvoicedAmount",
                table: "O607");

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Invoice607",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Invoice606",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Invoice607");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Invoice606");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "O607",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ITBISTotal",
                table: "O607",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "InvoicedAmount",
                table: "O607",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
