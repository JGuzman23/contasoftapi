using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace contasoft_api.Migrations
{
    public partial class dev22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        

            

            migrationBuilder.DropColumn(
                name: "AccountsNumber",
                table: "Plan");

       

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Invoice607",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Invoice607");

           

            migrationBuilder.AddColumn<string>(
                name: "AccountsNumber",
                table: "Plan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
    }
}
