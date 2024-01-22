using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace contasoft_api.Migrations
{
    public partial class dev01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RNC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    period = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountsNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Client_Company_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "O606",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearMonth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_O606", x => x.Id);
                    table.ForeignKey(
                        name: "FK_O606_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "O607",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearMonth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_O607", x => x.Id);
                    table.ForeignKey(
                        name: "FK_O607_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cellphone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Plan_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plan",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Invoice606",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RNCCédulaPasaporte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoID = table.Column<int>(type: "int", nullable: false),
                    TipoBienesYServiciosComprados = table.Column<int>(type: "int", nullable: false),
                    NumeroComprobanteFiscal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroComprobanteFiscalModificado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaComprobante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaPago = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MontoFacturadoEnServicio = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MontoFacturadoEnBienes = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalMontoFacturado = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ITBISFacturado = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ITBISRetenido = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ITBISSujetoaProporcionalidad = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ITBISLlevadoAlCosto = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ITBISPorAdelantar = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ITBISPersividoEnCompras = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TipoRetencionEnISR = table.Column<int>(type: "int", nullable: true),
                    MontoRetencionRenta = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IRSPercibidoEnCompras = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ImpuestoSelectivoAlConsumo = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OtrosImpuestosTasa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MontoPropinaLegal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FormaDePago = table.Column<int>(type: "int", nullable: true),
                    O606Id = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice606", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice606_O606_O606Id",
                        column: x => x.O606Id,
                        principalTable: "O606",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoice607",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RNCCédulaPasaporte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoIdentificación = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroComprobanteFiscal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroComprobanteFiscalModificado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoIngreso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaComprobante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRetención = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MontoFacturado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ITBISFacturado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ITBISRetenidoporTerceros = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ITBISPercibido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RetenciónRentaporTerceros = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISRPercibido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImpuestoSelectivoalConsumo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtrosImpuestos_Tasas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MontoPropinaLegal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Efectivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cheque_Transferencia_Depósito = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TarjetaDébito_Crédito = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VentaACrédito = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BonosOCertificadosRegalo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Permuta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtrasFormasVentas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    O607Id = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice607", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice607_O607_O607Id",
                        column: x => x.O607Id,
                        principalTable: "O607",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserCompany",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCompany", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCompany_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCompany_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_CompanyID",
                table: "Client",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice606_O606Id",
                table: "Invoice606",
                column: "O606Id");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice607_O607Id",
                table: "Invoice607",
                column: "O607Id");

            migrationBuilder.CreateIndex(
                name: "IX_O606_CompanyId",
                table: "O606",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_O607_CompanyId",
                table: "O607",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_User_PlanId",
                table: "User",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCompany_CompanyId",
                table: "UserCompany",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCompany_UserId",
                table: "UserCompany",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Invoice606");

            migrationBuilder.DropTable(
                name: "Invoice607");

            migrationBuilder.DropTable(
                name: "UserCompany");

            migrationBuilder.DropTable(
                name: "O606");

            migrationBuilder.DropTable(
                name: "O607");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Plan");
        }
    }
}
