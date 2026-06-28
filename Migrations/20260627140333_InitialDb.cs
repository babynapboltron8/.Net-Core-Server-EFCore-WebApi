using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ServerApiEfCore.Data;


#nullable disable
// Turns off nullable warnings for generated migration code

namespace ServerApiEfCore.Migrations
// EF Core stores all migration files in this namespace

{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    // Migration = a single database change set
    // "InitialDb" = name you gave when running:
    // dotnet ef migrations add InitialDb

    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        // Up() = WHAT TO DO when applying this migration
        // This is executed when you run:
        // dotnet ef database update

        {
            migrationBuilder.CreateTable(
                name: "Invoices",
                // Creates a SQL table called "Invoices"

                columns: table => new
                {
                    Id = table.Column<Guid>(
                        type: "uniqueidentifier",
                        nullable: false),
                    // Primary key column (GUID, NOT NULL)

                    InvoiceNumber = table.Column<string>(
                        type: "nvarchar(max)",
                        nullable: false),
                    // Required text field

                    ContactName = table.Column<string>(
                        type: "nvarchar(max)",
                        nullable: false),

                    Description = table.Column<string>(
                        type: "nvarchar(max)",
                        nullable: true),
                    // Nullable = optional field

                    Amount = table.Column<decimal>(
                        type: "decimal(18,2)",
                        nullable: false),
                    // Decimal money column

                    InvoiceDate = table.Column<DateTimeOffset>(
                        type: "datetimeoffset",
                        nullable: false),

                    DueDate = table.Column<DateTimeOffset>(
                        type: "datetimeoffset",
                        nullable: false),

                    Status = table.Column<int>(
                        type: "int",
                        nullable: false)
                    // Enum stored as integer in SQL
                },

                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    // Sets Id as PRIMARY KEY
                });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        // Down() = HOW TO UNDO this migration
        // Runs when you rollback migration:
        // dotnet ef database update PreviousMigration

        {
            migrationBuilder.DropTable(
                name: "Invoices");
            // Deletes the table if migration is reversed
        }
    }
}