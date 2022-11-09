using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeTicketApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class removesemployeeid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeTickets_Employees_EmployeeId",
                table: "TimeTickets");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "TimeTickets",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeTickets_Employees_EmployeeId",
                table: "TimeTickets",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeTickets_Employees_EmployeeId",
                table: "TimeTickets");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "TimeTickets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeTickets_Employees_EmployeeId",
                table: "TimeTickets",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
