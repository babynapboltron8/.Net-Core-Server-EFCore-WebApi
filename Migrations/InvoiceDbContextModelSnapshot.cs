#nullable disable
// Disables nullable reference warnings in this generated file

namespace ServerApiEfCore.Migrations
// This namespace is automatically created by EF Core for migrations

{
    [DbContext(typeof(InvoiceDbContext))]
    // Tells EF Core: this snapshot belongs to InvoiceDbContext

    partial class InvoiceDbContextModelSnapshot : ModelSnapshot
    // Snapshot = "current state of your database model"
    // EF Core uses this to compare changes when you run migrations

    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        // EF Core uses this method to rebuild your model in memory

        {
#pragma warning disable 612, 618
// Suppresses old API warnings (EF Core internal usage)

            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.23");
                // EF Core version used to generate this snapshot

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);
            // Configures SQL Server identity behavior (auto-increment style behavior)

            modelBuilder.Entity("ServerApiEfCore.Models.Invoice", b =>
            // Defines the Invoice table structure (from your Invoice model)

            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");
                // Primary key column (GUID generated when new row is added)

                b.Property<decimal>("Amount")
                    .HasColumnType("decimal(18,2)");
                // Money field with precision (18 digits, 2 decimals)

                b.Property<string>("ContactName")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");
                // Required string column (cannot be NULL)

                b.Property<string>("Description")
                    .HasColumnType("nvarchar(max)");
                // Optional string column

                b.Property<DateTimeOffset>("DueDate")
                    .HasColumnType("datetimeoffset");

                b.Property<DateTimeOffset>("InvoiceDate")
                    .HasColumnType("datetimeoffset");

                b.Property<string>("InvoiceNumber")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("Status")
                    .HasColumnType("int");
                // Enum stored as integer in database

                b.HasKey("Id");
                // Primary key definition

                b.ToTable("Invoices");
                // Table name in SQL database

                b.HasData(
                    new
                    {
                        Id = new Guid("9ec82f00-56c7-47de-9b98-b82a6995acfb"),
                        Amount = 100m,
                        ContactName = "John Doe",
                        Description = "Invoice for the first month",
                        DueDate = new DateTimeOffset(...),
                        InvoiceDate = new DateTimeOffset(...),
                        InvoiceNumber = "INV-001",
                        Status = 1
                    });
                // Seed data inserted when migration runs
                // This is the compiled version of your HasData() from DbContext
            });

#pragma warning restore 612, 618
// Restores compiler warnings
        }
    }
}