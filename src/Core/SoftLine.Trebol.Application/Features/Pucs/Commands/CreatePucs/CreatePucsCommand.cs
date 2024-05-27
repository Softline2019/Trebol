

using MediatR;
using SoftLine.Trebol.Application.Features.Pucs.Queries.Vms;

namespace SoftLine.Trebol.Application.Features.Pucs.Commands.CreatePucs;

public class CreatePucsCommand: IRequest<PucsVm>
{
   
    public string NombreCorto { get; set; }
    public int Cuenta { get; set; }
    public string Nombre { get; set; }
    public string Tipo { get; set; }
    public int CodTributario { get; set; }
    public string Digitable { get; set; }

}
