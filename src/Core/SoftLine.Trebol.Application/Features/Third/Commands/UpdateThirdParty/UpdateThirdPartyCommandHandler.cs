using AutoMapper;
using MediatR;
using SoftLine.Trebol.Application.Exceptions;
using SoftLine.Trebol.Application.Persistence;
using SoftLine.Trebol.Domain;

namespace SoftLine.Trebol.Application.Features.Third.Commands.UpdateThirdParty
{
    public class UpdateThirdPartyCommandHandler : IRequestHandler<UpdateThirdPartyCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateThirdPartyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateThirdPartyCommand request, CancellationToken cancellationToken)
        {
            var thirdPartyEntity = await _unitOfWork.Repository<ThirdParty>().GetByIdAsync(request.Id);
            if (thirdPartyEntity == null)
            {
                throw new NotFoundException(nameof(ThirdParty), request.Id);
            }

            _mapper.Map(request, thirdPartyEntity);

            _unitOfWork.Repository<ThirdParty>().UpdateEntity(thirdPartyEntity);
            await _unitOfWork.Complete();

            return Unit.Value;
        }
    }
}
