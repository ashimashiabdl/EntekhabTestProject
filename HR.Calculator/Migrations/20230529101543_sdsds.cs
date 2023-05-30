using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.OvetimePolicies.Migrations
{
    /// <inheritdoc />
    public partial class sdsds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employee_NationalNo",
                schema: "emp",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Allowance",
                schema: "emp",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "BasicSalary",
                schema: "emp",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Date",
                schema: "emp",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "NationalNo",
                schema: "emp",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Transportation",
                schema: "emp",
                table: "Employee");

            migrationBuilder.AddColumn<int>(
                name: "CalculatedSalary",
                schema: "emp",
                table: "Employee_Monthly_Salary",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CalculatedSalary",
                schema: "emp",
                table: "Employee_Monthly_Salary");

            migrationBuilder.AddColumn<int>(
                name: "Allowance",
                schema: "emp",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BasicSalary",
                schema: "emp",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                schema: "emp",
                table: "Employee",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "NationalNo",
                schema: "emp",
                table: "Employee",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Transportation",
                schema: "emp",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_NationalNo",
                schema: "emp",
                table: "Employee",
                column: "NationalNo",
                unique: true);
        }
    }
}
