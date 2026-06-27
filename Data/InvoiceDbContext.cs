using ServerApiEfCore.Models; 
// Imports your own model classes (like Invoice) so you can use them here

using Microsoft.EntityFrameworkCore; 
// Imports Entity Framework Core (EF Core)
// EF Core = ORM (Object Relational Mapper)
// It lets you work with database tables using C# classes instead of SQL

namespace ServerApiEfCore.Data;
// Namespace = logical container to organize your code (like folders in code form)

public class InvoiceDbContext (DbContextOptions<InvoiceDbContext> options) : DbContext(options)
// This is a DbContext class (EF Core core concept)
// DbContext = bridge between your C# app and the database

// (DbContextOptions<InvoiceDbContext> options) → PRIMARY CONSTRUCTOR (C# 12 feature)
// It directly receives configuration (like connection string settings)
// : DbContext(options) → passes options to base class constructor

{
    public DbSet<Invoice> Invoices => Set<Invoice>();
    // DbSet<T> represents a TABLE in the database
    // Invoices = table name (logical)
    // Set<Invoice>() = EF Core method that connects this property to the Invoice entity
    // You use this to query and save data (like SELECT, INSERT, UPDATE)

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    // OnModelCreating = method where you configure database schema
    // Runs when EF Core is building the model (before app uses DB)

    {
        modelBuilder.Entity<Invoice>().HasData(
        // Entity<Invoice>() = configure Invoice table
        // HasData() = SEED DATA (pre-load data into database when migrations run)

            new Invoice
            {
                Id = Guid.NewGuid(),
                // Guid.NewGuid() = generates unique ID (like a primary key)

                InvoiceNumber = "INV-001",
                ContactName = "John Doe",
                Description = "Invoice for the first month",
                Amount = 100,

                InvoiceDate = new DateTimeOffset(2024, 6, 27, 0, 0, 0, TimeSpan.Zero),
                // DateTimeOffset = date + timezone info (important for APIs)

                DueDate = new DateTimeOffset(2024, 7, 27, 0, 0, 0, TimeSpan.Zero),

                Status = InvoiceStatus.AwaitPayment
                // Enum value (InvoiceStatus is likely an enum)
            }
        );
    }
}