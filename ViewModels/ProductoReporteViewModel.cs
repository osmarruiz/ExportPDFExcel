using System.ComponentModel.DataAnnotations;

namespace ExportPDFExcel.ViewModels;

public class ProductoReporteViewModel
{
    [Required(ErrorMessage = "El stock mínimo es obligatorio.")]
    [Range(0, int.MaxValue, ErrorMessage = "El stock mínimo no puede ser negativo.")]
    [Display(Name = "Stock Mínimo")]
    public int MinStock { get; set; }
}