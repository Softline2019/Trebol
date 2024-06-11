using System.ComponentModel.DataAnnotations;

namespace SoftLine.Trebol.Application.Features.Receipts.Queries.Vms;

public class ReceiptsVm
{
    [Key]
    public int NR { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "CmpInt debe ser un número positivo")]
    public int CompInt { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Comprobante debe ser un número positivo")]
    public int Receipts { get; set; }

    public string? CompanyShortName { get; set; }

    [Required(ErrorMessage = "El nombre es requerido")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El nombre solo debe contener letras")]
    public string? Name { get; set; }

    public bool DocRef { get; set; }
    public bool ReceiptClosing { get; set; }
    public bool ConseOblig { get; set; }

    public int Consecutive { get; set; }
}