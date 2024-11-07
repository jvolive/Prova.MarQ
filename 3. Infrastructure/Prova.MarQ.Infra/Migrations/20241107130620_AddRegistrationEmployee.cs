using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prova.MarQ.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddRegistrationEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeRecords_Employees_EmployeeId",
                table: "TimeRecords");

            migrationBuilder.DropIndex(
                name: "IX_TimeRecords_EmployeeId",
                table: "TimeRecords");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "TimeRecords",
                newName: "CreatedAt");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeRegistration",
                table: "TimeRecords",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "TimeRecords",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "Employees",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Registration",
                table: "Employees",
                type: "INTEGER",
                maxLength: 6,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Companies_CompanyId",
                table: "Employees",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Companies_CompanyId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeRegistration",
                table: "TimeRecords");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "TimeRecords");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Registration",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "TimeRecords",
                newName: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeRecords_EmployeeId",
                table: "TimeRecords",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeRecords_Employees_EmployeeId",
                table: "TimeRecords",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
