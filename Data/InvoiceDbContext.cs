using ServerApiEfCore.Models;
using Microsoft.EntityFrameworkCore;

namespace ServerApiEfCore.Data;

public class InvoiceDbContext (DbContextOptions<InvoiceDbContext> options) : DbContext(options)
{
    public DbSet<Invoice> Invoices => Set<Invoice>();
}