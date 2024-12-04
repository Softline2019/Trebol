using MediatR;

namespace SoftLine.Trebol.Application.Features.Third.Commands.DeleteThirdParty
{
    public class DeleteThirdPartyCommand : IRequest
    {
        public int Id { get; set; }
    }
}

