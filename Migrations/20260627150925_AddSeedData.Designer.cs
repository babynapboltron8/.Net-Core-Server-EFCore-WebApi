#nullable disable
// Disables nullable warnings for generated code

namespace ServerApiEfCore.Migrations
// EF Core migration-related namespace

{
    [DbContext(typeof(InvoiceDbContext))]
    // Links this snapshot to your DbContext

    [Migration("20260627150925_AddSeedData")]
    // This snapshot belongs to the AddSeedData migration version

    partial class AddSeedData
    // Same name as your migration

    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        // EF Core rebuilds the model as it existed AFTER this migration

        {
#pragma warning disable 612, 618
// Suppresses internal EF Core warnings

            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);
                // Metadata about EF Core version and SQL limitations

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);
            // Configures SQL Server identity behavior

            modelBuilder.Entity("ServerApiEfCore.Models.Invoice", b =>
            // Defines the Invoice table structure

            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<decimal>("Amount")
                    .HasColumnType("decimal(18,2)");

                b.Property<string>("ContactName")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Description")
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTimeOffset>("DueDate")
                    .HasColumnType("datetimeoffset");

                b.Property<DateTimeOffset>("InvoiceDate")
                    .HasColumnType("datetimeoffset");

                b.Property<string>("InvoiceNumber")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("Status")
                    .HasColumnType("int");

                b.HasKey("Id");
                // Primary key

                b.ToTable("Invoices");
                // Table name in SQL Server

                b.HasData(
                // ⭐ THIS IS THE NEW PART (seed data included in model snapshot)

                    new
                    {
                        Id = new Guid("9ec82f00-56c7-47de-9b98-b82a6995acfb"),
                        Amount = 100m,
                        ContactName = "John Doe",
                        Description = "Invoice for the first month",

                        DueDate = new DateTimeOffset(
                            new DateTime(2024, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            new TimeSpan(0)
                        ),

                        InvoiceDate = new DateTimeOffset(
                            new DateTime(2024, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            new TimeSpan(0)
                        ),

                        InvoiceNumber = "INV-001",
                        Status = 1
                    });
                // Seed data is now part of the MODEL definition
            });

#pragma warning restore 612, 618
// Restores compiler warnings
        }
    }
}