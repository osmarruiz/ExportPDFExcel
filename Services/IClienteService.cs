using ExportPDFExcel.Models;

namespace ExportPDFExcel.Services;

public interface IClienteService
{
    Task<IEnumerable<Cliente>> GetAllClientesAsync();
    Task<IEnumerable<Cliente>> GetClientesByDateRangeAsync(DateTime startDate, DateTime endDate);
}