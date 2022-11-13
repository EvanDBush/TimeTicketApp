using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeTicketApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeTimeTicketStats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.Sql(
                @"CREATE FUNCTION[dbo].[EarliestTimeTicketForEmployee](@EmployeeId int)
                  RETURNS char(30) AS
                  BEGIN
                    DECLARE @ret char(30)
                    SELECT TOP 1 @ret = DateTime
                    FROM TimeTickets
                    WHERE TimeTickets.TimeTicketId IN (SELECT TimeTicketId
                                                       FROM TimeTicketEmployee
                                                       WHERE EmployeeId = @employeeId)
                    ORDER BY DateTime
                    RETURN @ret
                    END");

            migrationBuilder.Sql(
                @"CREATE VIEW dbo EmployeeTimeTicketStats
                  AS
                  SELECT dbo.Employees.Name
                  COUNT (dbo.TimeTicketEmployee.TimeTicketId) AS NumberOfTimeTickets,
                            dbo.EarliestTimeTicketForEmployee(MIN(dbo.Employees.Id))
                       AS EarliestTimeTicket

                  FROM dbo.TimeTicketEmployee INNER JOIN
                        dbo.Employees ON dbo.TimeTicketEmployee.EmployeeId = dbo.Employees.Id
                  GROUP BY dbo.Employees.Name, dbo.TimeTicketEmployee.EmployeeId");*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           /* migrationBuilder.Sql("DROP VIEW dbo.EmployeeTimeTicketStats");
            migrationBuilder.Sql("DROP FUNCTION dbo.EarliestTimeTicketForEmployee");*/


        }
    }
}
