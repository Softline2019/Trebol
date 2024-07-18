using SoftLine.Trebol.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace SoftLine.Trebol.Domain;

public class Receipt : BaseDomainModel
{
    [Key]
    public int NR { get; set; } 
    public string? CompanyShortName { get; set; }
    public int CompInt { get; set; }
    public int Receipts { get; set; }
    public string? Name { get; set; }
    public int Consecutive { get; set; }
    public bool DocRef { get; set; }
    public bool ReceiptClosing { get; set; }
    public bool ConseOblig { get; set; }

}