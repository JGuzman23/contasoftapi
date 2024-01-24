using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace contasoft_api.Migrations
{
    public partial class dev05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RNCCédulaPasaporte",
                table: "Invoice606",
                newName: "RNCCedulaPasaporte");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RNCCedulaPasaporte",
                table: "Invoice606",
                newName: "RNCCédulaPasaporte");
        }
    }
}
