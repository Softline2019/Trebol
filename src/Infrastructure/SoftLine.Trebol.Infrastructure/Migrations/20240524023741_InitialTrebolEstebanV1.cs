using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftLine.Trebol.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialTrebolEstebanV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCompany",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCompany",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCompany",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCompany",
                table: "Countries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCompany",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCompany",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ThirdParties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NIT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Regime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerificationDigitNIT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NITCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EconomicActivityCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasDocument = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMandator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdmissionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserUpdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaxMailbox = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSupplier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsClient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEmployee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsBeneficiary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCompany = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThirdParties", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThirdParties");

            migrationBuilder.DropColumn(
                name: "IdCompany",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "IdCompany",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IdCompany",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "IdCompany",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "IdCompany",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IdCompany",
                table: "Addresses");
        }
    }
}
