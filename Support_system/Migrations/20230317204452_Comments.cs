using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Support_system.Migrations
{
    /// <inheritdoc />
    public partial class Comments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Statuses_Cases_CasesId",
                table: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_Statuses_CasesId",
                table: "Statuses");

            migrationBuilder.DropColumn(
                name: "CaseId",
                table: "Statuses");

            migrationBuilder.DropColumn(
                name: "CasesId",
                table: "Statuses");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AddressesId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CommentsId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SteetName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PostalCode = table.Column<string>(type: "char(6)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CaseEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Cases_CaseEntityId",
                        column: x => x.CaseEntityId,
                        principalTable: "Cases",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdateComment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CaseEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Cases_CaseEntityId",
                        column: x => x.CaseEntityId,
                        principalTable: "Cases",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressesId",
                table: "Customers",
                column: "AddressesId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CommentsId",
                table: "Customers",
                column: "CommentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CaseEntityId",
                table: "Addresses",
                column: "CaseEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CaseEntityId",
                table: "Comments",
                column: "CaseEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Addresses_AddressesId",
                table: "Customers",
                column: "AddressesId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Comments_CommentsId",
                table: "Customers",
                column: "CommentsId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Addresses_AddressesId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Comments_CommentsId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Customers_AddressesId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CommentsId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "AddressesId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CommentsId",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "CaseId",
                table: "Statuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CasesId",
                table: "Statuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_CasesId",
                table: "Statuses",
                column: "CasesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Statuses_Cases_CasesId",
                table: "Statuses",
                column: "CasesId",
                principalTable: "Cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
