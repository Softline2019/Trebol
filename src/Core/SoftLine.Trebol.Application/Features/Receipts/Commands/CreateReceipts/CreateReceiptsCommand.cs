using MediatR;
using SoftLine.Trebol.Application.Features.Receipts.Queries.Vms;

namespace SoftLine.Trebol.Application.Features.Receipts.Commands.CreateReceipts;

public class CreateReceiptsCommand : IRequest<ReceiptsVm>
{
    public int IdCompany { get; set; }
    public string FNCShort { get; set; }
    public int fnReceipt { get; set; }
    public string fcName { get; set; }
    public int fnConsec { get; set; }
    public string fcDocRef { get; set; }
    public bool ReceiptClosing { get; set; }



}
