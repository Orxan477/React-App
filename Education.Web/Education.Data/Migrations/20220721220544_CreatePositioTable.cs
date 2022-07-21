using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education.Data.Migrations
{
    public partial class CreatePositioTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "Employees");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false,defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionId",
                table: "Employees",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Position_PositionId",
                table: "Employees",
                column: "PositionId",
                principalTable: "Position",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Position_PositionId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropIndex(
                name: "IX_Employees_PositionId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
