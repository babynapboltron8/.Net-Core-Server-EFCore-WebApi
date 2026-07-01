## Checking the .NET SDK

- Check .NET version: `dotnet --version`
- List available SDKs: `dotnet --list-sdks`

## Creating a Web API Project

- Create project: `dotnet new webapi -n *folder name* -controllers`
- Navigate to project: `cd *folder name*`
- Open in VS Code: `code .`

## Building and running the project

- Building the project: `dotnet build`
- Running the project: `dotnet run`
- Support HTTPS: `dotnet dev-certs https --trust`
- Hot reload: `dotnet watch`

## HTTPRepl test APIs

- Install HttpRepl: `dotnet tool install -g Microsoft.dotnet-httprepl`
- Command to connect API: `httprepl http://localhost:5282 (URL application)`
- Command lists endpoints: http://localhost:5282/> `ls or dir`
- CD command to navigate endpoints: `cd (endpoints ex. WeatherForecast)`
- Command get or prefer http method: http://localhost:5091/WeatherForecast> `get`

## Debugging in VSCode

- Setting up debugging: `Ctrl + Shift + P` (.NET: Generate Assets for Build and Debug)

## Asp.Net Codegenerator (Setting up tool to generate file in project and command)

- Install the tool: `dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design --version 8.*` and `dotnet tool install -g dotnet-aspnet-codegenerator --version 8.*`
- Restore and Verify it was added: `dotnet restore` and `dotnet list package`
- Command to generate a controller: `dotnet-aspnet-codegenerator controller -name PostsController -api -outDir Controllers`

## .NET Core CLI - EF Core packages

- Install the dotnet-ef tool: `dotnet tool install --globall dotnet-ef`
- Verify installation: `dotnet ef`
- Install EF Core packages: `dotnet add package Microsoft.EntityFrameworkCore.SqlServer` and `dotnet add package Microsoft.EntityFrameworkCore.Design`

## Creating the database migrationn

- Install the command: `dotnet ef migrations add InitialDb`
- Command to create database: `dotnet ef database update`
- View existing migrations list: `dotnet ef migrations list`
- Remove the last migration: `dotnet ef migrations remove`

## Project Structure After Migration

Migrations/
├── 20260627140333_InitialDb.cs
├── 20260627140333_InitialDb.Designer.cs
└── InvoiceDbContextModelSnapshot.cs

## What Each File Migrations Does

- `InitialDb.cs` — Contains the migration operations (CreateTable, AddColumn, etc.).
- `InitialDb.Designer.cs` — Stores metadata about the migration.
- `InvoiceDbContextModelSnapshot.cs` — Represents the latest database model and is used by EF Core to detect future changes.

## Connecting to SQL Server LocalDB in VS Code

- Open the **SQL Server** extension in VS Code.
- Click **+ Add Connection**.

## Connection Settings

- Server name: `(localdb)\MSSQLLocalDB`
- Authentication: Windows Authentication
- User name: _(leave empty)_
- Password: _(leave empty)_
- Database: `ServerApiEfCore` _(or leave blank to view all databases)_

## Connect

`Click **Connect**.`

## Verify LocalDB Instance

- If the connection fails, verify that the LocalDB instance exists: `sqllocaldb info`

- Start the LocalDB instance if it is stopped: `sqllocaldb start MSSQLLocalDB`

# Scaffolding an ASP.NET Core Web API Controller

Use the ASP.NET Core Code Generator to automatically create a CRUD API controller for an Entity Framework Core model.

## Command

```bash
dotnet-aspnet-codegenerator controller -name InvoicesController -api -outDir Controllers --model Invoice --dataContext InvoiceDbContext -async -actions
```

## Command Breakdown

- `controller` — Create a controller.
- `-name InvoicesController` — Controller name.
- `-api` — Generate an API controller.
- `-outDir Controllers` — Save it in the `Controllers` folder.
- `--model Invoice` — Use the `Invoice` model.
- `--dataContext InvoiceDbContext` — Use the `InvoiceDbContext`.
- `-async` — Generate async methods.
- `-actions` — Generate CRUD actions.

## What Gets Generated?

A new `InvoicesController` containing:

- ✅ GET all invoices
- ✅ GET invoice by ID
- ✅ POST (Create)
- ✅ PUT (Update)
- ✅ DELETE (Remove)

## Purpose

Scaffolding saves development time by automatically generating boilerplate CRUD code. It is commonly used for:

- Learning ASP.NET Core
- Rapid prototyping
- Creating an initial CRUD controller

In production projects, developers often customize or refactor the generated code to match the application's architecture and business requirements.

================================================================================================================================================================================================================================================================================

# ASP.NET Core Web API Development Flow

A practical guide for building an ASP.NET Core Web API from scratch.

---

# Phase 1: Planning

The planning phase focuses on understanding the problem before writing any code.

## 1. Project Idea

**Purpose**

Decide what application you want to build and what problem it solves.

**Example**

- Inventory Management System
- Invoice API
- E-Commerce Backend
- Social Media API

↓

## 2. Analyze Requirements

**Purpose**

Identify what the application should do.

Think about:

- Who will use it?
- What features are required?
- What are the business rules?
- What data needs to be stored?

Example:

- Users can register
- Users can login
- Admin can manage products
- Customers can place orders

↓

## 3. Design Database

**Purpose**

Design how the data will be stored.

Plan:

- Tables
- Columns
- Primary Keys
- Foreign Keys
- Relationships

Example

```
Customers
----------
Id
Name
Email

Invoices
---------
Id
CustomerId
Amount

Relationship

Customer
    │
    └──────< Invoice
```

---

# Phase 2: Development

Now begin building the backend.

↓

## 4. Create ASP.NET Core Web API Project

**Purpose**

Create the backend application.

```bash
dotnet new webapi
```

This creates

```
Controllers/
Program.cs
appsettings.json
```

↓

## 5. Install Required NuGet Packages

**Purpose**

Add the libraries your project needs.

Example

```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Swashbuckle.AspNetCore
```

These packages allow you to

- Connect SQL Server
- Use Entity Framework Core
- Generate Swagger documentation

↓

## 6. Create Models

**Purpose**

Create C# classes that represent database tables.

Example

```csharp
public class Invoice
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public decimal Amount { get; set; }
}
```

Think of Models as

```
Database Table
        ⇅
     C# Class
```

↓

## 7. Create DbContext

**Purpose**

Connect your Models to SQL Server.

Example

```csharp
public class InvoiceDbContext : DbContext
{
    public DbSet<Invoice> Invoices { get; set; }
}
```

DbContext is the bridge

```
Model
   │
DbContext
   │
SQL Server
```

↓

## 8. Configure appsettings.json

**Purpose**

Store application configuration.

Example

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=...;"
  }
}
```

Usually stores

- Connection Strings
- API Keys
- Logging Settings

↓

## 9. Configure Program.cs

**Purpose**

Register services the application needs.

Example

```csharp
builder.Services.AddControllers();

builder.Services.AddDbContext<InvoiceDbContext>();

builder.Services.AddSwaggerGen();
```

Program.cs is the startup file.

It configures

- Dependency Injection
- Controllers
- Swagger
- Authentication
- Authorization
- CORS
- Database

↓

## 10. Create Initial Migration

**Purpose**

Generate SQL based on your Models.

```bash
dotnet ef migrations add InitialCreate
```

Migration compares

```
Models

↓

SQL Script
```

↓

## 11. Update Database

**Purpose**

Create the actual SQL Server database.

```bash
dotnet ef database update
```

Now SQL Server contains your tables.

↓

## 12. Create Controllers

**Purpose**

Create API endpoints.

Example

```
GET /api/invoices

POST /api/invoices

PUT /api/invoices

DELETE /api/invoices
```

Controllers receive HTTP requests.

↓

## 13. Implement CRUD Logic

**Purpose**

Write database operations.

CRUD means

```
Create
Read
Update
Delete
```

Example

```csharp
_context.Invoices.Add();

_context.Invoices.Find();

_context.Update();

_context.Remove();
```

---

# Phase 3: Testing

↓

## 14. Run the Application

Start the API.

```bash
dotnet run
```

The API is now listening for requests.

↓

## 15. Test API

Verify every endpoint.

Common tools

- Swagger
- Postman
- Bruno
- Insomnia

Test

- GET
- POST
- PUT
- DELETE

Make sure every endpoint works correctly.

---

# Phase 4: Production

↓

## 16. Build Frontend

Create the user interface.

Examples

- React
- Blazor
- Next.js
- Angular
- Vue

The frontend communicates with your API.

↓

## 17. Connect Frontend to Backend API

Send HTTP requests.

Example

```
React

↓

Axios

↓

HTTP Request

↓

ASP.NET API
```

Common libraries

- Axios
- Fetch API
- HttpClient

↓

## 18. Deploy Application

Publish your application.

Backend

- IIS
- Azure
- Docker
- VPS
- Railway

Frontend

- Vercel
- Netlify
- Azure Static Web Apps

↓

## 19. Maintain & Add New Features

After deployment

- Fix bugs
- Improve performance
- Add new features
- Refactor code
- Update dependencies

Software development never truly ends.

```
New Feature Requested
        │
        ▼
Analyze Requirements
        │
        ▼
Development
        │
        ▼
Testing
        │
        ▼
Deploy
        │
        └──────────────┐
                       ▼
              Repeat Cycle
```

---

# Complete Development Cycle

```text
1. Project Idea
      │
      ▼
2. Analyze Requirements
      │
      ▼
3. Design Database
      │
      ▼
4. Create ASP.NET Core Web API Project
      │
      ▼
5. Install Required NuGet Packages
      │
      ▼
6. Create Models
      │
      ▼
7. Create DbContext
      │
      ▼
8. Configure appsettings.json
      │
      ▼
9. Configure Program.cs
      │
      ▼
10. Create Initial Migration
      │
      ▼
11. Update Database
      │
      ▼
12. Create Controllers
      │
      ▼
13. Implement CRUD Logic
      │
      ▼
14. Run the Application
      │
      ▼
15. Test API
      │
      ▼
16. Build Frontend
      │
      ▼
17. Connect Frontend to Backend API
      │
      ▼
18. Deploy Application
      │
      ▼
19. Maintain & Add New Features
      │
      └──────────────┐
                     ▼
            Back to Step 2
```

---

# Runtime Request Flow

This is what happens after the application is running.

```text
Frontend (React/Blazor/Next.js)
        │
        ▼
HTTP Request
        │
        ▼
Program.cs
        │
        ▼
Middleware
        │
        ▼
Routing
        │
        ▼
Controller
        │
        ▼
DbContext
        │
        ▼
Entity Framework Core
        │
        ▼
SQL Server
        │
        ▼
Database
        │
        ▲
Query Results
        │
        ▲
Entity Framework Core
        │
        ▲
DbContext
        │
        ▲
Controller
        │
        ▲
JSON Response
        │
        ▲
HTTP Response
        │
        ▲
Frontend
```

---

# Mental Model

Think of ASP.NET Core Web API as four major phases.

```
Planning
---------
• Project Idea
• Analyze Requirements
• Design Database

Development
------------
• Create Project
• Install Packages
• Create Models
• Create DbContext
• Configure appsettings.json
• Configure Program.cs
• Create Migration
• Update Database
• Create Controllers
• Implement CRUD

Testing
--------
• Run Application
• Test API

Production
-----------
• Build Frontend
• Connect Frontend
• Deploy
• Maintain & Improve
```

---

# One-Sentence Summary

> **Plan the application → Design the database → Build the backend → Test the API → Build the frontend → Connect everything → Deploy → Continuously improve.**
