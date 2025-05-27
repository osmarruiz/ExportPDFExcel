using Dapper; 
using Npgsql;
using ExportPDFExcel.Models;

namespace ExportPDFExcel.Services;

public class ProductoService(NpgsqlConnection connection) : IProductoService
{
    public async Task<IEnumerable<Producto>> GetAllProductosAsync()
    {
        var sql = "SELECT Id, Nombre, Descripcion, Precio, Stock FROM Productos";
        return await connection.QueryAsync<Producto>(sql);
    }

    public async Task<IEnumerable<Producto>> GetProductosByStockAsync(int minStock)
    {
        var sql = "SELECT Id, Nombre, Descripcion, Precio, Stock FROM Productos WHERE Stock >= @MinStock";
        return await connection.QueryAsync<Producto>(sql, new { MinStock = minStock });
    }
}