using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace contasoft_api.Migrations
{
    public partial class dev27 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "InvoiceProduct",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "RolesId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
           name: "IX_User_RolesId",
           table: "User",
           column: "RolesId");

            migrationBuilder.AddForeignKey(
             name: "FK_User_Roles_RolesId",
             table: "User",
             column: "RolesId",
             principalTable: "Roles",
             principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "InvoiceProduct");

            migrationBuilder.DropForeignKey(
              name: "FK_User_Roles_RolesId",
              table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_RolesId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "RolesId",
                table: "User");




        }
    }
}
