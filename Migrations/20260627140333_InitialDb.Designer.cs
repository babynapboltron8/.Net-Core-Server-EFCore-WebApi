#nullable disable
// Disables nullable warnings (EF Core generated code)

namespace ServerApiEfCore.Migrations
// All migration-related files are stored here

{
    [DbContext(typeof(InvoiceDbContext))]
    // This snapshot belongs to InvoiceDbContext

    [Migration("20260627140333_InitialDb")]
    // This links the snapshot to a specific migration version
    // The number is a timestamp-based migration ID

    partial class InitialDb
    // Same name as your migration class
    // But this is NOT the migration logic itself

    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        // This builds the "expected database model" at this migration stage

        {
#pragma warning disable 612, 618
// Suppresses internal EF Core warnings

            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.23");
                // EF Core version used

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);
            // SQL Server identity configuration (auto-increment behavior)

            modelBuilder.Entity("ServerApiEfCore.Models.Invoice", b =>
            // Defines how Invoice entity looked at this migration point

            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");
                // Primary key (auto-generated GUID)

                b.Property<decimal>("Amount")
                    .HasColumnType("decimal(18,2)");
                // Money field

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
                // Enum stored as integer

                b.HasKey("Id");
                // Primary key definition

                b.ToTable("Invoices");
                // Maps entity to SQL table "Invoices"
            });

#pragma warning restore 612, 618
// Restores compiler warnings
        }
    }
}