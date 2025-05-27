using ExportPDFExcel.Models;

namespace ExportPDFExcel.Services;

public interface IProductoService
{
    Task<IEnumerable<Producto>> GetAllProductosAsync();
    Task<IEnumerable<Producto>> GetProductosByStockAsync(int minStock);
}