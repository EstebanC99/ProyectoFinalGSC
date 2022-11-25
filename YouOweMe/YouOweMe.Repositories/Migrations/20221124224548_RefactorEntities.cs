using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YouOweMe.Repositories.Migrations
{
    public partial class RefactorEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaDevolucion",
                table: "Loans");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Things",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Things",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Cantidad",
                table: "Things",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "Telefono",
                table: "Persons",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Persons",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Mail",
                table: "Persons",
                newName: "Lastname");

            migrationBuilder.RenameColumn(
                name: "Apellido",
                table: "Persons",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "FechaPrestamo",
                table: "Loans",
                newName: "ReturnDate");

            migrationBuilder.RenameColumn(
                name: "CantidadPrestada",
                table: "Loans",
                newName: "BorrowedAmount");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Categories",
                newName: "Description");

            migrationBuilder.AddColumn<DateTime>(
                name: "LoanDate",
                table: "Loans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoanDate",
                table: "Loans");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Things",
                newName: "Cantidad");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Things",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Things",
                newName: "Descripcion");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Persons",
                newName: "Telefono");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Persons",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "Persons",
                newName: "Mail");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Persons",
                newName: "Apellido");

            migrationBuilder.RenameColumn(
                name: "ReturnDate",
                table: "Loans",
                newName: "FechaPrestamo");

            migrationBuilder.RenameColumn(
                name: "BorrowedAmount",
                table: "Loans",
                newName: "CantidadPrestada");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Categories",
                newName: "Descripcion");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaDevolucion",
                table: "Loans",
                type: "datetime2",
                nullable: true);
        }
    }
}
