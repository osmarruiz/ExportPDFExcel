using ExportPDFExcel.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace ExportPDFExcel.Reports;

public class PdfReportGenerator
{
    public byte[] GenerateProductosPdf(IEnumerable<Producto> productos)
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(10));

                    page.Header()
                        .Text("Reporte de Productos")
                        .FontSize(18)
                        .Bold()
                        .FontColor(Colors.Blue.Medium);

                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn(3);
                                columns.RelativeColumn(4);
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            table.Header(header =>
                            {
                                header.Cell().Text("ID").Bold();
                                header.Cell().Text("Nombre").Bold();
                                header.Cell().Text("Descripción").Bold();
                                header.Cell().Text("Precio").Bold();
                                header.Cell().Text("Stock").Bold();
                            });

                            foreach (var producto in productos)
                            {
                                table.Cell().Text(producto.Id.ToString());
                                table.Cell().Text(producto.Nombre);
                                table.Cell().Text(producto.Descripcion);
                                table.Cell().Text($"${producto.Precio:N2}");
                                table.Cell().Text(producto.Stock.ToString());
                            }
                        });

                    page.Footer()
                        .AlignRight()
                        .Text(x =>
                        {
                            x.Span("Página ");
                            x.CurrentPageNumber();
                            x.Span(" de ");
                            x.TotalPages();
                        });
                });
            });

            return document.GeneratePdf();
        }

        public byte[] GenerateClientesPdf(IEnumerable<Cliente> clientes)
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(10));

                    page.Header()
                        .Text("Reporte de Clientes")
                        .FontSize(18)
                        .Bold()
                        .FontColor(Colors.Blue.Medium);

                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(3);
                                columns.RelativeColumn();
                            });

                            table.Header(header =>
                            {
                                header.Cell().Text("ID").Bold();
                                header.Cell().Text("Nombre").Bold();
                                header.Cell().Text("Apellido").Bold();
                                header.Cell().Text("Email").Bold();
                                header.Cell().Text("Fecha Registro").Bold();
                            });

                            foreach (var cliente in clientes)
                            {
                                table.Cell().Text(cliente.Id.ToString());
                                table.Cell().Text(cliente.Nombre);
                                table.Cell().Text(cliente.Apellido);
                                table.Cell().Text(cliente.Email);
                                table.Cell().Text(cliente.FechaRegistro.ToShortDateString());
                            }
                        });

                    page.Footer()
                        .AlignRight()
                        .Text(x =>
                        {
                            x.Span("Página ");
                            x.CurrentPageNumber();
                            x.Span(" de ");
                            x.TotalPages();
                        });
                });
            });

            return document.GeneratePdf();
        }
}