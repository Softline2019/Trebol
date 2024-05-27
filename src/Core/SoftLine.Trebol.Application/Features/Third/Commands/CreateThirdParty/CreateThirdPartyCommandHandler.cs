using AutoMapper;
using MediatR;
using SoftLine.Trebol.Application.Features.Receipts.Queries.Vms;
using SoftLine.Trebol.Application.Features.Third.Commands.CreateThirdParty;
using SoftLine.Trebol.Application.Features.Third.Queries.Vms;
using SoftLine.Trebol.Application.Persistence;
using SoftLine.Trebol.Domain;

namespace SoftLine.Trebol.Application.Features.Third.Commands.CreateThird
{
    public class CreateThirdPartyCommandHandler : IRequestHandler<CreateThirdPartyCommand, ThirdPartyVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateThirdPartyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ThirdPartyVm> Handle(CreateThirdPartyCommand request, CancellationToken cancellationToken)
        {
            var thirdPartiesEntity = _mapper.Map<ThirdParty>(request);
            await _unitOfWork.Repository<ThirdParty>().AddAsync(thirdPartiesEntity);
            await _unitOfWork.Complete();

            return _mapper.Map<ThirdPartyVm>(thirdPartiesEntity);
        }
    }
}
