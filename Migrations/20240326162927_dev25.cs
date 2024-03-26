using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace contasoft_api.Migrations
{
    public partial class dev25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Invoice607");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Invoice607");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "InvoiceIncome",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "InvoiceIncome",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "InvoiceIncome",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "InvoiceIncome",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "InvoiceIncome",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCode",
                table: "InvoiceIncome",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "InvoiceIncome");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "InvoiceIncome");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "InvoiceIncome");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "InvoiceIncome");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "InvoiceIncome");

            migrationBuilder.DropColumn(
                name: "UserCode",
                table: "InvoiceIncome");

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Invoice607",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Invoice607",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
