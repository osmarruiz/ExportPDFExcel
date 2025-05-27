using Dapper;
using ExportPDFExcel.Models;
using Npgsql;

namespace ExportPDFExcel.Services;

public class ClienteService(NpgsqlConnection connection) : IClienteService
{
    public async Task<IEnumerable<Cliente>> GetAllClientesAsync()
    {
        var sql = "SELECT Id, Nombre, Apellido, Email, FechaRegistro FROM Clientes";
        return await connection.QueryAsync<Cliente>(sql);
    }

    public async Task<IEnumerable<Cliente>> GetClientesByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        var sql = "SELECT Id, Nombre, Apellido, Email, FechaRegistro FROM Clientes WHERE FechaRegistro >= @StartDate AND FechaRegistro <= @EndDate";
        return await connection.QueryAsync<Cliente>(sql, new { StartDate = startDate, EndDate = endDate });
    }
}