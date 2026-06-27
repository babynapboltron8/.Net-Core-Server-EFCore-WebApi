using ServerApiEfCore.Models;
using Microsoft.EntityFrameworkCore;

namespace ServerApiEfCore.Data;

public class InvoiceDbContext (DbContextOptions<InvoiceDbContext> options) : DbContext(options)
{
    public DbSet<Invoice> Invoices => Set<Invoice>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
     {
               modelBuilder.Entity<Invoice>().HasData   (
                    new Invoice
                    {
                         Id = Guid.NewGuid(),
                         InvoiceNumber = "INV-001",
                         ContactName = "John Doe",
                         Description = "Invoice for the first month",
                         Amount = 100,
                         InvoiceDate = new DateTimeOffset(2024, 6, 27, 0, 0, 0, TimeSpan.Zero),
                         DueDate = new DateTimeOffset(2024, 7, 27, 0, 0, 0, TimeSpan.Zero),
                         Status = InvoiceStatus.AwaitPayment
                    }
               );
     }
}

