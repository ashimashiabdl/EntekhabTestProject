using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.OvetimePolicies.Migrations
{
    /// <inheritdoc />
    public partial class removeCol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Month",
                schema: "emp",
                table: "Employee_Monthly_Salary");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Month",
                schema: "emp",
                table: "Employee_Monthly_Salary",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
