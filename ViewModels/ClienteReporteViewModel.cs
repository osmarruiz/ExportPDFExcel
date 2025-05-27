using System.ComponentModel.DataAnnotations;

namespace ExportPDFExcel.ViewModels;

public class ClienteReporteViewModel
{
    [Required(ErrorMessage = "La fecha de inicio es obligatoria.")]
    [DataType(DataType.Date)]
    [Display(Name = "Fecha de Inicio")]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "La fecha fin es obligatoria.")]
    [DataType(DataType.Date)]
    [Display(Name = "Fecha Fin")]
    public DateTime EndDate { get; set; }
}