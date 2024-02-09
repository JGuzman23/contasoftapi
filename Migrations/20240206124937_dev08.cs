using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace contasoft_api.Migrations
{
    public partial class dev08 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "O606");

            migrationBuilder.DropColumn(
                name: "ITBISTotal",
                table: "O606");

            migrationBuilder.DropColumn(
                name: "InvoicedAmount",
                table: "O606");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "O606",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ITBISTotal",
                table: "O606",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "InvoicedAmount",
                table: "O606",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
