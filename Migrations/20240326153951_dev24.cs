using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace contasoft_api.Migrations
{
    public partial class dev24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RolId",
                table: "User");

            migrationBuilder.CreateTable(
                name: "InvoiceIncome",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Invoice607Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceIncome", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceIncome_Invoice607_Invoice607Id",
                        column: x => x.Invoice607Id,
                        principalTable: "Invoice607",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    InvoiceIncomeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceProduct_InvoiceIncome_InvoiceIncomeId",
                        column: x => x.InvoiceIncomeId,
                        principalTable: "InvoiceIncome",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_VoidInvoice_O608Id",
                table: "VoidInvoice",
                column: "O608Id");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceIncome_Invoice607Id",
                table: "InvoiceIncome",
                column: "Invoice607Id");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceProduct_InvoiceIncomeId",
                table: "InvoiceProduct",
                column: "InvoiceIncomeId");

            migrationBuilder.AddForeignKey(
                name: "FK_VoidInvoice_O608_O608Id",
                table: "VoidInvoice",
                column: "O608Id",
                principalTable: "O608",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VoidInvoice_O608_O608Id",
                table: "VoidInvoice");

            migrationBuilder.DropTable(
                name: "InvoiceProduct");

            migrationBuilder.DropTable(
                name: "InvoiceIncome");

            migrationBuilder.DropIndex(
                name: "IX_VoidInvoice_O608Id",
                table: "VoidInvoice");

            migrationBuilder.AddColumn<int>(
                name: "RolId",
                table: "User",
                type: "int",
                nullable: true);
        }
    }
}
