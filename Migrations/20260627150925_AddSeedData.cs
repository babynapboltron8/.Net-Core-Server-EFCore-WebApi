#nullable disable
// Disables nullable warnings in generated migration code

namespace ServerApiEfCore.Migrations
// All migration files are grouped here

{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    // Migration name: "AddSeedData"
    // This means: you're modifying the database by adding initial data

    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        // Up() = APPLY changes (when running database update)

        {
            migrationBuilder.InsertData(
                table: "Invoices",
                // Target table where data will be inserted

                columns: new[] 
                { 
                    "Id", "Amount", "ContactName", "Description",
                    "DueDate", "InvoiceDate", "InvoiceNumber", "Status" 
                },
                // Column names in the table

                values: new object[]
                {
                    new Guid("9ec82f00-56c7-47de-9b98-b82a6995acfb"),
                    // Fixed GUID (NOT random anymore in migrations)

                    100m,
                    // Decimal value (m = decimal literal in C#)

                    "John Doe",
                    "Invoice for the first month",

                    new DateTimeOffset(
                        new DateTime(2024, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        new TimeSpan(0)
                    ),
                    // DueDate with timezone offset

                    new DateTimeOffset(
                        new DateTime(2024, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        new TimeSpan(0)
                    ),
                    // InvoiceDate

                    "INV-001",
                    1
                    // Status = enum stored as integer (1 = AwaitPayment probably)
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        // Down() = REVERSE changes (rollback)

        {
            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: new Guid("9ec82f00-56c7-47de-9b98-b82a6995acfb"));
            // Deletes the seeded record using its primary key
        }
    }
}