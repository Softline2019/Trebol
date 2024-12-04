using MediatR;

namespace SoftLine.Trebol.Application.Features.Pucs.Commands.DeletePuc
{
    public class DeletePucCommand : IRequest
    {
        public int Id { get; set; }

        public DeletePucCommand(int id)
        {
            Id = id;
        }
    }
}






