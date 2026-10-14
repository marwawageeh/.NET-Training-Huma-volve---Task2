# Advanced EF Core – Task 2

## Training
This project was completed as the **second task** during my training at **Huma Volve**.

## Project Overview
A RESTful Web API built with ASP.NET Core and Entity Framework Core to manage products and their categories using SQL Server.

## Technologies Used
- C#
- ASP.NET Core Web API
- Entity Framework Core (EF Core)
- SQL Server
- Entity Framework Core Migrations
- Swagger / OpenAPI
- Visual Studio

## Main Features
- Manage product data through API endpoints.
- Use DTOs to shape product data returned by the API and accepted for updates.
- Use an `ApplicationDbContext` to connect the application to the database.
- Define `Product` and `Category` models.
- Use EF Core migrations to create and update the database schema.
- Test API endpoints through Swagger.

## Project Structure
```text
Advanced EF Core(Marwa wageeh farraj)/
├── Controllers/
│   └── ProductsController.cs
├── DTOs/
│   ├── ProductDto.cs
│   └── UpdateProductDto.cs
├── DbContext/
│   └── ApplicationDbContext.cs
├── Migrations/
├── Models/
│   ├── Category.cs
│   └── Product.cs
├── Program.cs
└── appsettings.json
```

## API Testing Screenshots

All API request and response outputs have been uploaded to the `screenshots` folder.

## How to Run
1. Clone or download this repository.
2. Open the solution file in Visual Studio.
3. Update the SQL Server connection string in `appsettings.json` to match your local SQL Server instance.
4. Apply the EF Core migrations if the database has not been created yet. In Visual Studio's **Package Manager Console**, run:
   ```powershell
   Update-Database
   ```
5. Run the project.
6. Open the Swagger URL displayed by the application to explore and test the API endpoints.

## Notes
- The SQL Server connection string is machine-specific and may need to be updated.
- Do not commit real passwords, API keys, or other secrets to a public repository.

---
**Training Company:** Huma Volve  
**Task:** Task 2 – Advanced Entity Framework Core
