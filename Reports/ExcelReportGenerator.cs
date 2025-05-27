using ClosedXML.Excel;
using ExportPDFExcel.Models;

namespace ExportPDFExcel.Reports;

public class ExcelReportGenerator
{
    public byte[] GenerateProductosExcel(IEnumerable<Producto> productos)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Productos");

                // Encabezados
                worksheet.Cell(1, 1).Value = "ID";
                worksheet.Cell(1, 2).Value = "Nombre";
                worksheet.Cell(1, 3).Value = "Descripción";
                worksheet.Cell(1, 4).Value = "Precio";
                worksheet.Cell(1, 5).Value = "Stock";

                // Datos
                int row = 2;
                foreach (var producto in productos)
                {
                    worksheet.Cell(row, 1).Value = producto.Id;
                    worksheet.Cell(row, 2).Value = producto.Nombre;
                    worksheet.Cell(row, 3).Value = producto.Descripcion;
                    worksheet.Cell(row, 4).Value = producto.Precio;
                    worksheet.Cell(row, 5).Value = producto.Stock;
                    row++;
                }

                worksheet.ColumnsUsed().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return stream.ToArray();
                }
            }
        }

        public byte[] GenerateClientesExcel(IEnumerable<Cliente> clientes)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Clientes");

                // Encabezados
                worksheet.Cell(1, 1).Value = "ID";
                worksheet.Cell(1, 2).Value = "Nombre";
                worksheet.Cell(1, 3).Value = "Apellido";
                worksheet.Cell(1, 4).Value = "Email";
                worksheet.Cell(1, 5).Value = "Fecha de Registro";

                // Datos
                int row = 2;
                foreach (var cliente in clientes)
                {
                    worksheet.Cell(row, 1).Value = cliente.Id;
                    worksheet.Cell(row, 2).Value = cliente.Nombre;
                    worksheet.Cell(row, 3).Value = cliente.Apellido;
                    worksheet.Cell(row, 4).Value = cliente.Email;
                    worksheet.Cell(row, 5).Value = cliente.FechaRegistro.ToShortDateString();
                    row++;
                }

                worksheet.ColumnsUsed().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return stream.ToArray();
                }
            }
        }
}