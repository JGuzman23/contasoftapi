﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using contasoft_api.Data;

#nullable disable

namespace contasoft_api.Migrations
{
    [DbContext(typeof(ContaSoftDbContext))]
    [Migration("20240307193259_dev14")]
    partial class dev14
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("contasoft_api.Models.Bank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bank");
                });

            modelBuilder.Entity("contasoft_api.Models.BankSelected", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AccountName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AccountTypeID")
                        .HasColumnType("int");

                    b.Property<int>("BankId")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CurrencyID")
                        .HasColumnType("int");

                    b.Property<decimal?>("InitialBalance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CurrencyID");

                    b.ToTable("BankSelected");
                });

            modelBuilder.Entity("contasoft_api.Models.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CompanyID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CompanyID");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("contasoft_api.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("RNC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("contasoft_api.Models.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Currency");
                });

            modelBuilder.Entity("contasoft_api.Models.Invoice606", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("FechaComprobante")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaPago")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FormaDePago")
                        .HasColumnType("int");

                    b.Property<decimal?>("IRSPercibidoEnCompras")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ITBISFacturado")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ITBISLlevadoAlCosto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ITBISPersividoEnCompras")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ITBISPorAdelantar")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ITBISRetenido")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ITBISSujetoaProporcionalidad")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ImpuestoSelectivoAlConsumo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<decimal?>("MontoFacturadoEnBienes")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("MontoFacturadoEnServicio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("MontoPropinaLegal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("MontoRetencionRenta")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("NumeroComprobanteFiscal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroComprobanteFiscalModificado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("O606Id")
                        .HasColumnType("int");

                    b.Property<decimal?>("OtrosImpuestosTasa")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("RNCCedulaPasaporte")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoBienesYServiciosComprados")
                        .HasColumnType("int");

                    b.Property<int>("TipoID")
                        .HasColumnType("int");

                    b.Property<int?>("TipoRetencionEnISR")
                        .HasColumnType("int");

                    b.Property<decimal?>("TotalMontoFacturado")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("O606Id");

                    b.ToTable("Invoice606");
                });

            modelBuilder.Entity("contasoft_api.Models.Invoice607", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal?>("BonosOCertificadosRegalo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Cheque_Transferencia_Depósito")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<decimal?>("Efectivo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("FechaComprobante")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaRetención")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("ISRPercibido")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ITBISFacturado")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ITBISPercibido")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ITBISRetenidoporTerceros")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ImpuestoSelectivoalConsumo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<decimal?>("MontoFacturado")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("MontoPropinaLegal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("NumeroComprobanteFiscal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroComprobanteFiscalModificado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("O607Id")
                        .HasColumnType("int");

                    b.Property<decimal?>("OtrasFormasVentas")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("OtrosImpuestos_Tasas")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Permuta")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("RNCCedulaPasaporte")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("RetenciónRentaporTerceros")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TarjetaDébito_Crédito")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("TipoIdentificación")
                        .HasColumnType("int");

                    b.Property<int?>("TipoIngreso")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("VentaACrédito")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("O607Id");

                    b.ToTable("Invoice607");
                });

            modelBuilder.Entity("contasoft_api.Models.O606", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RNC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YearMonth")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("O606");
                });

            modelBuilder.Entity("contasoft_api.Models.O607", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RNC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YearMonth")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("O607");
                });

            modelBuilder.Entity("contasoft_api.Models.O608", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RNC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YearMonth")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("O608");
                });

            modelBuilder.Entity("contasoft_api.Models.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("contasoft_api.Models.Plan", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("ID"), 1L, 1);

                    b.Property<string>("AccountsNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Period")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Plan");
                });

            modelBuilder.Entity("contasoft_api.Models.Roles", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("contasoft_api.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("BankNumberIn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankNumberOut")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Concept")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("NoCheck")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("contasoft_api.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Cellphone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlanId")
                        .HasColumnType("int");

                    b.Property<int?>("RolesId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PlanId");

                    b.HasIndex("RolesId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("contasoft_api.Models.UserCompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("UserId");

                    b.ToTable("UserCompany");
                });

            modelBuilder.Entity("contasoft_api.Models.VoidInvoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("O608Id")
                        .HasColumnType("int");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VoidInvoice");
                });

            modelBuilder.Entity("contasoft_api.Models.BankSelected", b =>
                {
                    b.HasOne("contasoft_api.Models.Bank", "Bank")
                        .WithMany()
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("contasoft_api.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("contasoft_api.Models.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyID");

                    b.Navigation("Bank");

                    b.Navigation("Company");

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("contasoft_api.Models.Client", b =>
                {
                    b.HasOne("contasoft_api.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("contasoft_api.Models.Invoice606", b =>
                {
                    b.HasOne("contasoft_api.Models.O606", "O606")
                        .WithMany()
                        .HasForeignKey("O606Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("O606");
                });

            modelBuilder.Entity("contasoft_api.Models.Invoice607", b =>
                {
                    b.HasOne("contasoft_api.Models.O607", "O607")
                        .WithMany()
                        .HasForeignKey("O607Id");

                    b.Navigation("O607");
                });

            modelBuilder.Entity("contasoft_api.Models.O606", b =>
                {
                    b.HasOne("contasoft_api.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("contasoft_api.Models.O607", b =>
                {
                    b.HasOne("contasoft_api.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("contasoft_api.Models.O608", b =>
                {
                    b.HasOne("contasoft_api.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("contasoft_api.Models.Transaction", b =>
                {
                    b.HasOne("contasoft_api.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("contasoft_api.Models.User", b =>
                {
                    b.HasOne("contasoft_api.Models.Plan", "Plan")
                        .WithMany()
                        .HasForeignKey("PlanId");

                    b.HasOne("contasoft_api.Models.Roles", "Roles")
                        .WithMany()
                        .HasForeignKey("RolesId");

                    b.Navigation("Plan");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("contasoft_api.Models.UserCompany", b =>
                {
                    b.HasOne("contasoft_api.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("contasoft_api.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
