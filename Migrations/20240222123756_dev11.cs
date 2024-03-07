using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace contasoft_api.Migrations
{
    public partial class dev11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BankNumberOut",
                table: "Transaction",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BankNumberIn",
                table: "Transaction",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "AccountName",
                table: "BankSelected",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountTypeID",
                table: "BankSelected",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrencyID",
                table: "BankSelected",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "InitialBalance",
                table: "BankSelected",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankSelected_CurrencyID",
                table: "BankSelected",
                column: "CurrencyID");

            migrationBuilder.AddForeignKey(
                name: "FK_BankSelected_Currency_CurrencyID",
                table: "BankSelected",
                column: "CurrencyID",
                principalTable: "Currency",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankSelected_Currency_CurrencyID",
                table: "BankSelected");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropIndex(
                name: "IX_BankSelected_CurrencyID",
                table: "BankSelected");

            migrationBuilder.DropColumn(
                name: "AccountName",
                table: "BankSelected");

            migrationBuilder.DropColumn(
                name: "AccountTypeID",
                table: "BankSelected");

            migrationBuilder.DropColumn(
                name: "CurrencyID",
                table: "BankSelected");

            migrationBuilder.DropColumn(
                name: "InitialBalance",
                table: "BankSelected");

            migrationBuilder.AlterColumn<string>(
                name: "BankNumberOut",
                table: "Transaction",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BankNumberIn",
                table: "Transaction",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
