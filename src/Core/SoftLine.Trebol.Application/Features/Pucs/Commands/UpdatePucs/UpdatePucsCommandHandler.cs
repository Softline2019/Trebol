using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SoftLine.Trebol.Application.Exceptions;
using SoftLine.Trebol.Application.Persistence;
using SoftLine.Trebol.Domain;


namespace SoftLine.Trebol.Application.Features.Pucs.Commands.UpdatePucs;

    public class UpdatePucsCommandHandler : IRequestHandler<UpdatePucsCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdatePucsCommandHandler> _logger;

        public UpdatePucsCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdatePucsCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdatePucsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var pucEntity = await _unitOfWork.Repository<Puc>().GetByIdAsync(request.Id);
                if (pucEntity == null)
                {
                    _logger.LogWarning("PUC with ID {PucId} not found.", request.Id);
                    throw new NotFoundException(nameof(Puc), request.Id);
                }

                _mapper.Map(request, pucEntity);

                await _unitOfWork.Repository<Puc>().UpdateAsync(pucEntity);
                _logger.LogInformation("PUC with ID {PucId} was updated.", request.Id);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating PUC with ID {PucId}.", request.Id);
                throw;
            }
        }
    }

