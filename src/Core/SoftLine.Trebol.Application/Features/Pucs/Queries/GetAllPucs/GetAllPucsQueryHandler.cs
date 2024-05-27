

using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SoftLine.Trebol.Application.Features.Pucs.Queries.Vms;
using SoftLine.Trebol.Application.Persistence;
using SoftLine.Trebol.Domain;

namespace SoftLine.Trebol.Application.Features.Pucs.Queries.GetAllPucs;

    public class GetAllPucsQueryHandler : IRequestHandler<GetAllPucsQuery, List<PucsVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllPucsQueryHandler> _logger;

    public GetAllPucsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GetAllPucsQueryHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;

    }

        public async Task<List<PucsVm>> Handle(GetAllPucsQuery request, CancellationToken cancellationToken)
        {
        try
        {
            var pucsEntities = await _unitOfWork.Repository<Puc>().GetAllAsync();
            return _mapper.Map<List<PucsVm>>(pucsEntities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting all PUCs");
            throw; 
        }
    }
    }

