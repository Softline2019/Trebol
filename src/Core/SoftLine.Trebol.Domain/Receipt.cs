using SoftLine.Trebol.Domain.Common;

namespace SoftLine.Trebol.Domain;

public class Receipt : BaseDomainModel
{
    /// <summary>
    /// NR (numeric(22, 0)):
    /// </summary>
    public int NR { get; set; }
    /// <summary>
    /// IdCompany: Es el Id de la compañía que hace referencia a la descripción en FNCShort
    /// </summary>
    public int IdCompany { get; set; }
    /// <summary>
    /// FCNCORTO (varchar(5)): Es llamado anteriormente en Zafiro verisión Anterior
    /// </summary>
    public string FNCShort { get; set; }
    /// <summary>
    /// fnComp (numeric(3, 0)): Es llamado anteriormente en Zafiro verisión Anterior
    /// </summary>
    public int fnReceipt { get; set; }
    /// <summary>
    /// fcNombre (varchar(30)): Es llamado anteriormente en Zafiro verisión Anterior
    /// </summary>
    public string fcName { get; set; }
    /// <summary>
    /// fnConsec (numeric(20, 0)): Es llamado anteriormente en Zafiro verisión Anterior
    /// </summary>
    public int fnConsec { get; set; }
    /// <summary>
    /// fcDocRef varchar(20) Dejarlo en nvarchar(1)
    /// </summary>
    public string fcDocRef { get; set; }
    /// <summary>
    /// ComprobanteCierre (bit): Es llamado anteriormente en Zafiro verisión Anterior
    /// </summary>
    public bool ReceiptClosing { get; set; }

}
