# 📊 ExportPDFExcel: Generación de Reportes en .NET MVC con PostgreSQL, ClosedXML y QuestPDF

![.NET Version](https://img.shields.io/badge/.NET-8.0-blue)
![NuGet ClosedXML](https://img.shields.io/nuget/v/ClosedXML)
![NuGet QuestPDF](https://img.shields.io/nuget/v/QuestPDF)
![NuGet Dapper](https://img.shields.io/nuget/v/Dapper)
![NuGet Npgsql](https://img.shields.io/nuget/v/Npgsql)

¡Bienvenido a **ExportPDFExcel**!  

Este es un proyecto de ejemplo que demuestra cómo construir una aplicación web ASP.NET Core MVC desde cero, integrando una base de datos PostgreSQL para la gestión de datos y utilizando **ClosedXML** y **QuestPDF** para la generación flexible de reportes en formatos **Excel y PDF**, tanto con y sin parámetros.


### 🎯 Generación de Reportes Flexible

- **Sin Parámetros**: Obtén todos los datos de una tabla para un reporte completo.
- **Con Parámetros**: Filtra los datos del reporte según criterios específicos  
  (ej. stock mínimo de productos, rango de fechas de clientes).

---

## 🛠️ Tecnologías Utilizadas

- .NET 8.0 SDK
- ASP.NET Core MVC
- PostgreSQL
- Npgsql (ADO.NET Data Provider para PostgreSQL)
- Dapper
- ClosedXML
- QuestPDF

---

## ⚙️ Configuración del Entorno

### 1. Base de Datos PostgreSQL

Asegúrate de tener un servidor PostgreSQL en funcionamiento.  
Crea la base de datos `ExportPDFExcel` y ejecuta el siguiente script:

```sql
-- Crear la tabla Productos
CREATE TABLE Productos (
    Id SERIAL PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Descripcion TEXT,
    Precio DECIMAL(10, 2) NOT NULL,
    Stock INT NOT NULL
);

-- Insertar datos de ejemplo
INSERT INTO Productos (Nombre, Descripcion, Precio, Stock) VALUES
('Laptop Dell XPS 13', 'Potente laptop con pantalla InfinityEdge', 1500.00, 50),
('Monitor LG Ultrafine', 'Monitor 4K para profesionales', 600.00, 30),
('Teclado Mecánico HyperX', 'Teclado para gaming con retroiluminación RGB', 120.00, 100),
('Mouse Logitech MX Master 3', 'Mouse ergonómico y personalizable', 90.00, 75),
('Webcam Logitech C920', 'Webcam Full HD para videollamadas', 70.00, 60);

-- Crear la tabla Clientes
CREATE TABLE Clientes (
    Id SERIAL PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    Email VARCHAR(150) UNIQUE NOT NULL,
    FechaRegistro DATE DEFAULT CURRENT_DATE
);

-- Insertar datos de ejemplo
INSERT INTO Clientes (Nombre, Apellido, Email) VALUES
('Juan', 'Perez', 'juan.perez@example.com'),
('Maria', 'Gomez', 'maria.gomez@example.com'),
('Carlos', 'Ramirez', 'carlos.ramirez@example.com');
```

### 2. Configuración del Proyecto ASP.NET Core

Edita el archivo `appsettings.Development.json` con tu cadena de conexión PostgreSQL:

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
    "DefaultConnection": "Host=localhost;Port=5432;Database=ExportPDFExcel;Username=postgres;Password=tu_contraseña_postgres"
  }
}
```

> 🔐 **¡Importante!** Reemplaza `tu_contraseña_postgres` por tu contraseña real de PostgreSQL.

---

## 📦 Instalación de Dependencias

Si creaste el proyecto desde cero, instala los paquetes necesarios:

```bash
dotnet add package Npgsql
dotnet add package Dapper
dotnet add package ClosedXML
dotnet add package QuestPDF
```

---

## 🚀 Ejecución del Proyecto

Abre el proyecto en **Visual Studio** o **VS Code** y ejecuta los siguientes comandos:

```bash
dotnet restore
dotnet build
dotnet run
```

Navega a:

```
https://localhost:XXXX
```

Reemplaza `XXXX` por el puerto que indique la consola.

---

## 📄 Estructura del Proyecto

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

## 📚 Licencia

¡Úsalo, mejóralo y compártelo sin miedo!

---

¡Espero que este proyecto te sea útil para implementar la generación de reportes en tus propias aplicaciones ASP.NET Core!