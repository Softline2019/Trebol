using SoftLine.Trebol.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace SoftLine.Trebol.Domain;

public class Receipt : BaseDomainModel
{
    /// <summary>
    /// NR (numeric(22, 0)):
    /// </summary>
    [Key]
    public int NR { get; set; } //Es el ID de nuestra tabla.
    /// <summary>
    /// FCNCORTO (varchar(5)): Es llamado anteriormente en Zafiro verisión Anterior
    /// </summary>
    public string? CompanyShortName { get; set; }
    public int CompInt { get; set; }
    /// <summary>
    /// fnComp (numeric(3, 0)): Es llamado anteriormente en Zafiro verisión Anterior
    /// </summary>
    public int Receipts { get; set; }
    /// <summary>
    /// fcNombre (varchar(30)): Es llamado anteriormente en Zafiro verisión Anterior
    /// </summary>
    public string? Name { get; set; }
    /// <summary>
    /// fnConsec (numeric(20, 0)): Es llamado anteriormente en Zafiro verisión Anterior
    /// </summary>
    public int Consecutive { get; set; }
    /// <summary>
    /// fcDocRef varchar(20) Dejarlo en nvarchar(1)
    /// </summary>
    public bool DocRef { get; set; }
    /// <summary>
    /// ComprobanteCierre (bit): Es llamado anteriormente en Zafiro verisión Anterior
    /// </summary>
    public bool ReceiptClosing { get; set; }
    public bool ConseOblig { get; set; }

}