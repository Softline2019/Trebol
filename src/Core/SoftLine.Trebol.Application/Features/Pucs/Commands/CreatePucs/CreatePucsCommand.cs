

using MediatR;
using SoftLine.Trebol.Application.Features.Pucs.Queries.Vms;

namespace SoftLine.Trebol.Application.Features.Pucs.Commands.CreatePucs;

public class CreatePucsCommand: IRequest<PucsVm>
{
    public int IdCompany { get; set; }
    public string FNCShort { get; set; }
    public int FCAccount { get; set; }
    public string FCName { get; set; }
    public string FCType { get; set; }
    public int FCCodSub { get; set; }
    public string FCDigit { get; set; }

}
