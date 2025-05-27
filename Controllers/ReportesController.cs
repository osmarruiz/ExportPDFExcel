using ExportPDFExcel.Reports;
using ExportPDFExcel.Services;
using ExportPDFExcel.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ExportPDFExcel.Controllers;

public class ReportesController : Controller
{
    private readonly IProductoService _productoService;
        private readonly IClienteService _clienteService;
        private readonly ExcelReportGenerator _excelGenerator;
        private readonly PdfReportGenerator _pdfGenerator;

        public ReportesController(IProductoService productoService, IClienteService clienteService)
        {
            _productoService = productoService;
            _clienteService = clienteService;
            _excelGenerator = new ExcelReportGenerator(); // Instanciar aquí o inyectar si se registra como Singleton
            _pdfGenerator = new PdfReportGenerator();     // Instanciar aquí o inyectar si se registra como Singleton
        }

        public IActionResult Index()
        {
            return View();
        }

        // Reportes de Productos

        // Reporte de Productos SIN parámetros (Excel)
        public async Task<IActionResult> ProductosExcel()
        {
            var productos = await _productoService.GetAllProductosAsync();
            var excelBytes = _excelGenerator.GenerateProductosExcel(productos);
            return File(excelBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ReporteProductos.xlsx");
        }

        // Reporte de Productos SIN parámetros (PDF)
        public async Task<IActionResult> ProductosPdf()
        {
            var productos = await _productoService.GetAllProductosAsync();
            var pdfBytes = _pdfGenerator.GenerateProductosPdf(productos);
            return File(pdfBytes, "application/pdf", "ReporteProductos.pdf");
        }

        // Reporte de Productos CON parámetros (Stock mínimo - Excel)
        [HttpGet]
        public IActionResult ProductosExcelConParametros()
        {
            return View(new ProductoReporteViewModel()); // Pasa una nueva instancia del ViewModel
        }

        [HttpPost]
        public async Task<IActionResult> ProductosExcelConParametros(ProductoReporteViewModel model) // <-- Cambia el parámetro
        {
            if (!ModelState.IsValid) // <-- Usa la validación del modelo
            {
                return View(model);
            }

            var productos = await _productoService.GetProductosByStockAsync(model.MinStock);
            var excelBytes = _excelGenerator.GenerateProductosExcel(productos);
            return File(excelBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"ReporteProductos_StockMin{model.MinStock}.xlsx");
        }

        // Reporte de Productos CON parámetros (Stock mínimo - PDF)
        [HttpGet]
        public IActionResult ProductosPdfConParametros()
        {
            return View(new ProductoReporteViewModel()); // Pasa una nueva instancia del ViewModel
        }

        [HttpPost]
        public async Task<IActionResult> ProductosPdfConParametros(ProductoReporteViewModel model) // <-- Cambia el parámetro
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var productos = await _productoService.GetProductosByStockAsync(model.MinStock);
            var pdfBytes = _pdfGenerator.GenerateProductosPdf(productos);
            return File(pdfBytes, "application/pdf", $"ReporteProductos_StockMin{model.MinStock}.pdf");
        }

        // Reporte de Clientes CON parámetros (Rango de Fechas - Excel)
        [HttpGet]
        public IActionResult ClientesExcelConParametros()
        {
            return View(new ClienteReporteViewModel()); // Pasa una nueva instancia del ViewModel
        }

        [HttpPost]
        public async Task<IActionResult> ClientesExcelConParametros(ClienteReporteViewModel model) // <-- Cambia el parámetro
        {
            // La validación de fechas:
            // if (model.StartDate > model.EndDate) { ModelState.AddModelError(...); }
            // se puede manejar con Data Annotations personalizadas si quieres
            // o dejarla explícitamente como está, pero después de ModelState.IsValid
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Mueve esta validación después de ModelState.IsValid para que se ejecute solo si los campos requeridos están presentes
            if (model.StartDate > model.EndDate)
            {
                ModelState.AddModelError("StartDate", "La fecha de inicio no puede ser posterior a la fecha fin.");
                return View(model);
            }

            var clientes = await _clienteService.GetClientesByDateRangeAsync(model.StartDate, model.EndDate);
            var excelBytes = _excelGenerator.GenerateClientesExcel(clientes);
            return File(excelBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"ReporteClientes_{model.StartDate:yyyyMMdd}-{model.EndDate:yyyyMMdd}.xlsx");
        }

        // Reporte de Clientes CON parámetros (Rango de Fechas - PDF)
        [HttpGet]
        public IActionResult ClientesPdfConParametros()
        {
            return View(new ClienteReporteViewModel()); // Pasa una nueva instancia del ViewModel
        }

        [HttpPost]
        public async Task<IActionResult> ClientesPdfConParametros(ClienteReporteViewModel model) // <-- Cambia el parámetro
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Mueve esta validación después de ModelState.IsValid
            if (model.StartDate > model.EndDate)
            {
                ModelState.AddModelError("StartDate", "La fecha de inicio no puede ser posterior a la fecha fin.");
                return View(model);
            }

            var clientes = await _clienteService.GetClientesByDateRangeAsync(model.StartDate, model.EndDate);
            var pdfBytes = _pdfGenerator.GenerateClientesPdf(clientes);
            return File(pdfBytes, "application/pdf", $"ReporteClientes_{model.StartDate:yyyyMMdd}-{model.EndDate:yyyyMMdd}.pdf");
        }
}