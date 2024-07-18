using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SoftLine.Trebol.Application.Exceptions;
using SoftLine.Trebol.Application.Features.Pucs.Queries.Vms;
using SoftLine.Trebol.Application.Persistence;
using SoftLine.Trebol.Domain;


namespace SoftLine.Trebol.Application.Features.Pucs.Queries.GetPucs
{
    public class GetPucsQueryHandlerById : IRequestHandler<GetPucsQueryById, PucsVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<GetPucsQueryHandlerById> _logger;
        public GetPucsQueryHandlerById(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GetPucsQueryHandlerById> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<PucsVm> Handle(GetPucsQueryById request, CancellationToken cancellationToken)
        {
            try
            {
                var pucEntity = await _unitOfWork.Repository<Puc>().GetByIdAsync(request.Id);
                if (pucEntity == null)
                {
                    _logger.LogWarning("PUC with ID {PucId} not found.", request.Id);
                    throw new NotFoundException(nameof(Puc), request.Id);
                }

                return _mapper.Map<PucsVm>(pucEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting PUC by ID");
                throw;
            }
        }
    }      
}
