namespace ServerApiEfCore.Models;
// Organizes code in a project (Models folder usually contains database entities)
// In ASP.NET Core, this is a "namespace" used to group related classes (like folders in code)

public class Invoice
{
    // Primary key in database table (EF Core uses this to uniquely identify records)
    // In C#, this is a PROPERTY inside a CLASS
    // In ASP.NET Core + EF Core, this becomes a column in a database table
    public Guid Id { get; set; }

    // Used when creating, reading, updating invoices via ASP.NET Core API
    // This is a string PROPERTY (C# type) used in API JSON requests/responses
    public string InvoiceNumber { get; set; } = string.Empty;

    // Stored customer/contact info, used in API responses and database
    // Another PROPERTY inside a MODEL class
    public string ContactName { get; set; } = string.Empty;

    // Optional field used for extra details (can be null in requests/DB)
    // "string?" means nullable type in C# (can hold null value)
    public string? Description { get; set; }

    // Main business value field (used in calculations, reports, API output)
    // decimal is used in C# for accurate financial calculations
    public decimal Amount { get; set; }

    // Used to track when invoice was created; important for filtering/reporting in API
    // DateTimeOffset is a C# struct used for date + timezone support
    public DateTimeOffset InvoiceDate { get; set; }

    // Used for due date logic (e.g., overdue checks in API/business rules)
    public DateTimeOffset DueDate { get; set; }

    // Used for workflow/status control in API (filter paid, pending, overdue invoices)
    // Enum type in C# that restricts allowed values
    public InvoiceStatus Status { get; set; }
}

// Used in ASP.NET Core + EF Core to restrict allowed invoice states
// Helps avoid invalid string values like "payed", "PAIDD", etc.
// This is an ENUM in C# (a fixed set of named constants)
public enum InvoiceStatus
{
    Draft,
    AwaitPayment,
    Paid,
    Overdue,
    Cancelled
}