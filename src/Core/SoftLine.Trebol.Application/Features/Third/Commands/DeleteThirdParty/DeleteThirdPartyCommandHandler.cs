using AutoMapper;
using MediatR;
using SoftLine.Trebol.Application.Exceptions;
using SoftLine.Trebol.Application.Persistence;
using SoftLine.Trebol.Domain;

namespace SoftLine.Trebol.Application.Features.Third.Commands.DeleteThirdParty
{
    public class DeleteThirdPartyCommandHandler : IRequestHandler<DeleteThirdPartyCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteThirdPartyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteThirdPartyCommand request, CancellationToken cancellationToken)
        {
            var thirdPartyEntity = await _unitOfWork.Repository<ThirdParty>().GetByIdAsync(request.Id);
            if (thirdPartyEntity == null)
            {
                throw new NotFoundException(nameof(ThirdParty), request.Id);
            }

            _unitOfWork.Repository<ThirdParty>().DeleteEntity(thirdPartyEntity);
            await _unitOfWork.Complete();

            return Unit.Value;
        }
    }
}
