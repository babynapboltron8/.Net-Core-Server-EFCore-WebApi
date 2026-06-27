using ServerApiEfCore.Data;
using Microsoft.EntityFrameworkCore;
// Imports your DbContext (InvoiceDbContext)
// Imports EF Core so you can use UseSqlServer()

var builder = WebApplication.CreateBuilder(args);
// Creates the application builder
// This is where ASP.NET Core registers services (Dependency Injection container)


// -------------------- SERVICES REGISTRATION --------------------

builder.Services.AddControllers();
// Registers MVC Controllers (API endpoints like GET/POST/PUT/DELETE)
// Without this, your API controllers won’t work

builder.Services.AddEndpointsApiExplorer();
// Enables endpoint discovery (used by Swagger)
// Helps automatically detect API routes

builder.Services.AddSwaggerGen();
// Adds Swagger generator
// Swagger = API documentation + testing UI in browser


builder.Services.AddDbContext<InvoiceDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);
// Registers your DbContext (EF Core database service)

// Breakdown:
// AddDbContext<InvoiceDbContext>()
// → tells ASP.NET Core: "I need this database context available via DI"

// UseSqlServer()
// → tells EF Core you're using SQL Server database provider

// GetConnectionString("DefaultConnection")
// → reads connection string from appsettings.json

// -------------------- BUILD APP --------------------

var app = builder.Build();
// Builds the application pipeline (finalizes configuration)


// -------------------- MIDDLEWARE PIPELINE --------------------

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    // Enables Swagger JSON endpoint

    app.UseSwaggerUI();
    // Enables Swagger UI in browser (API testing interface)
}

// Middleware runs in order (VERY IMPORTANT in ASP.NET Core)

app.UseHttpsRedirection();
// Redirects HTTP requests → HTTPS automatically (security feature)

app.UseAuthorization();
// Enables authorization system (but no rules defined yet)
// Used for [Authorize] attributes in controllers

app.MapControllers();
// Maps controller routes to endpoints
// Example: /api/invoice → InvoiceController

// -------------------- RUN APP --------------------

app.Run();
// Starts the web server (Kestrel)
// App is now listening for HTTP requests