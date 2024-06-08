using MediatR;
using SoftLine.Trebol.Application.Features.Pucs.Queries.Vms;


namespace SoftLine.Trebol.Application.Features.Pucs.Queries.GetAllPucs;

public class GetAllPucsQuery : IRequest<List<PucsVm>>
{

}
