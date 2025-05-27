# 📊 ExportPDFExcel: Report Generation in .NET MVC with PostgreSQL, ClosedXML and QuestPDF

![.NET Version](https://img.shields.io/badge/.NET-8.0-blue)
![License](https://img.shields.io/badge/license-MIT-green)
![NuGet ClosedXML](https://img.shields.io/nuget/v/ClosedXML)
![NuGet QuestPDF](https://img.shields.io/nuget/v/QuestPDF)
![NuGet Dapper](https://img.shields.io/nuget/v/Dapper)
![NuGet Npgsql](https://img.shields.io/nuget/v/Npgsql)

Welcome to **ExportPDFExcel**!

This is a sample project that demonstrates how to build an ASP.NET Core MVC web application from scratch, integrating a PostgreSQL database for data management and using **ClosedXML** and **QuestPDF** for flexible report generation in **Excel and PDF** formats, both with and without parameters.

### 🎯 Flexible Report Generation

- **Without Parameters**: Get all data from a table for a complete report.
- **With Parameters**: Filter report data according to specific criteria
  (e.g., minimum product stock, customer date range).

---

## 🛠️ Technologies Used

- .NET 8.0 SDK
- ASP.NET Core MVC
- PostgreSQL
- Npgsql (ADO.NET Data Provider for PostgreSQL)
- Dapper
- ClosedXML
- QuestPDF

---

## ⚙️ Environment Setup

### 1. PostgreSQL Database

Ensure you have a PostgreSQL server running.
Create the `ExportPDFExcel` database and execute the following script:

```sql
-- Create Products table
CREATE TABLE Productos (
    Id SERIAL PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Descripcion TEXT,
    Precio DECIMAL(10, 2) NOT NULL,
    Stock INT NOT NULL
);

-- Insert sample data
INSERT INTO Productos (Nombre, Descripcion, Precio, Stock) VALUES
('Laptop Dell XPS 13', 'Powerful laptop with InfinityEdge display', 1500.00, 50),
('Monitor LG Ultrafine', '4K monitor for professionals', 600.00, 30),
('HyperX Mechanical Keyboard', 'Gaming keyboard with RGB backlight', 120.00, 100),
('Mouse Logitech MX Master 3', 'Ergonomic and customizable mouse', 90.00, 75),
('Webcam Logitech C920', 'Full HD webcam for video calls', 70.00, 60);

-- Create Customers table
CREATE TABLE Clientes (
    Id SERIAL PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    Email VARCHAR(150) UNIQUE NOT NULL,
    FechaRegistro DATE DEFAULT CURRENT_DATE
);

-- Insert sample data
INSERT INTO Clientes (Nombre, Apellido, Email) VALUES
('John', 'Doe', 'john.doe@example.com'),
('Mary', 'Smith', 'mary.smith@example.com'),
('Charles', 'Johnson', 'charles.johnson@example.com');
```

### 2. ASP.NET Core Project Configuration

Edit the `appsettings.Development.json` file with your PostgreSQL connection string:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=ExportPDFExcel;Username=postgres;Password=your_postgres_password"
  }
}
```

> 🔐 **Important!** Replace `your_postgres_password` with your actual PostgreSQL password.

---

## 📦 Dependencies Installation

If you created the project from scratch, install the required packages:

```bash
dotnet add package Npgsql
dotnet add package Dapper
dotnet add package ClosedXML
dotnet add package QuestPDF
```

---

## 🚀 Project Execution

Open the project in **Visual Studio** or **VS Code** and run the following commands:

```bash
dotnet restore
dotnet build
dotnet run
```

Navigate to:

```
https://localhost:XXXX
```

Replace `XXXX` with the port shown in the console.

---

## 📄 Project Structure

```
├── Models/
│   ├── Producto.cs
│   └── Cliente.cs
│
├── ViewModels/
│   ├── ProductoReporteViewModel.cs
│   └── ClienteReporteViewModel.cs
│
├── Services/
│   ├── IProductoService.cs
│   ├── ProductoService.cs
│   ├── IClienteService.cs
│   └── ClienteService.cs
│
├── Reports/
│   ├── ExcelReportGenerator.cs
│   └── PdfReportGenerator.cs
│
├── Controllers/
│   └── ReportesController.cs
│
├── Views/Reportes/
│   └── *.cshtml
│
├── appsettings.Development.json
└── Program.cs
```

---

## 🤝 Contributions

Have suggestions or want to improve this project?  
Open an issue or send a pull request!  
Your collaboration is more welcome than Monday coffee.

---

## 📚 License

This project is available under the MIT license.  
Use it, improve it, and share it fearlessly!

---

Hope this project helps you implement report generation in your own ASP.NET Core applications!
