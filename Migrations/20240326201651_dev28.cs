using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace contasoft_api.Migrations
{
    public partial class dev28 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyRNC",
                table: "InvoiceIncome");

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AddColumn<string>(
                name: "CompanyRNC",
                table: "InvoiceIncome",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
