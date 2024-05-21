using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftLine.Trebol.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialTrebolYersonV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NR = table.Column<int>(type: "int", nullable: false),
                    IdCompany = table.Column<int>(type: "int", nullable: false),
                    FNCShort = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fnReceipt = table.Column<int>(type: "int", nullable: false),
                    fcName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fnConsec = table.Column<int>(type: "int", nullable: false),
                    fcDocRef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiptClosing = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Receipts");
        }
    }
}
