using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.OvetimePolicies.Migrations
{
    /// <inheritdoc />
    public partial class vvvvvsdsds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Month",
                schema: "emp",
                table: "Employee_Monthly_Salary",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserSendedDate",
                schema: "emp",
                table: "Employee_Monthly_Salary",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Month",
                schema: "emp",
                table: "Employee_Monthly_Salary");

            migrationBuilder.DropColumn(
                name: "UserSendedDate",
                schema: "emp",
                table: "Employee_Monthly_Salary");
        }
    }
}
