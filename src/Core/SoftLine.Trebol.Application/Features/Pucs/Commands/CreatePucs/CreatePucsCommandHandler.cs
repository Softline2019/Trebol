
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SoftLine.Trebol.Application.Features.Pucs.Queries.Vms;
using SoftLine.Trebol.Application.Persistence;
using SoftLine.Trebol.Domain;

namespace SoftLine.Trebol.Application.Features.Pucs.Commands.CreatePucs;

public class CreatePucsCommandHandler : IRequestHandler<CreatePucsCommand, PucsVm>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<CreatePucsCommandHandler> _logger;

    public CreatePucsCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreatePucsCommandHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    async Task<PucsVm> IRequestHandler<CreatePucsCommand, PucsVm>.Handle(CreatePucsCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var receipstEntity = _mapper.Map<Puc>(request);
            await _unitOfWork.Repository<Puc>().AddAsync(receipstEntity);

            return _mapper.Map<PucsVm>(receipstEntity);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while creating a PUC");
            throw; 
        }
    }
}
