namespace SoftLine.Trebol.Application.Features.Receipts.Queries.Vms;

public class ReceiptsVm
{
    public int Id { get; set; }
    public int NR { get; set; }
    public int IdCompany { get; set; }
    public string FNCShort { get; set; }
    public int fnReceipt { get; set; }
    public string fcName { get; set; }
    public int fnConsec { get; set; }
    public string fcDocRef { get; set; }
    public bool ReceiptClosing { get; set; }
}
