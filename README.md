# 📝 Todo Management API

A simple Todo Management API built with ASP.NET Core and Entity Framework Core.

## 📌 Requirements

- .NET 8 or later
- SQL Server
- Postman or Swagger (for testing)
- Optional: Simple frontend using Bootstrap

## 📦 Tech Stack

- ASP.NET Core Web API
- Entity Framework Core (EF Core)
- AutoMapper
- Repository & Unit of Work Pattern
- Swagger (for API docs)
- 
## ✅ Features

- Basic CRUD operations (Create, Read, Update, Delete)
- Filter todos by status (Pending, InProgress, Completed)
- Set priority (Low, Medium, High)
- Optional due date for each todo
- Mark todo as completed
- Basic validation (required fields, valid dates)
  
📁 Project Structure
```
├── Controllers
├── DTOs
├── Enums
├── Mapping
├── Models
├── Repositories
├── Services
├── Unit_of_works
└── Program.cs

```
## 🚀 Getting Started

1. Clone the repository
2. Set your connection string in `appsettings.json`
3. Run database migrations:

### Run the app: dotnet run

### Open Swagger in your browser: https://localhost:5001/swagger

