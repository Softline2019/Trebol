

using MediatR;

namespace SoftLine.Trebol.Application.Features.Pucs.Commands.DeletePucs;

    public class DeletePucsCommand : IRequest
    {
     public int Id { get; set; }
    }

