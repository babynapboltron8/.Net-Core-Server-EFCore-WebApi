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
