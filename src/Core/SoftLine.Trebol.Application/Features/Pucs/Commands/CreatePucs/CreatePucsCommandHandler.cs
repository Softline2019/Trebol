
using AutoMapper;
using MediatR;
using SoftLine.Trebol.Application.Features.Pucs.Queries.Vms;
using SoftLine.Trebol.Application.Persistence;
using SoftLine.Trebol.Domain;

namespace SoftLine.Trebol.Application.Features.Pucs.Commands.CreatePucs;

public class CreatePucsCommandHandler : IRequestHandler<CreatePucsCommand, PucsVm>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreatePucsCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    async Task<PucsVm> IRequestHandler<CreatePucsCommand, PucsVm>.Handle(CreatePucsCommand request, CancellationToken cancellationToken)
    {
        var receipstEntity = _mapper.Map<Puc>(request);
        await _unitOfWork.Repository<Puc>().AddAsync(receipstEntity);

        return _mapper.Map<PucsVm>(receipstEntity);
    }
}
