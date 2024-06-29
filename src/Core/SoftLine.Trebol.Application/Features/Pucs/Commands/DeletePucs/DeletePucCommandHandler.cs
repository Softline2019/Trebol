using AutoMapper;
using MediatR;
using SoftLine.Trebol.Application.Exceptions;
using SoftLine.Trebol.Application.Persistence;
using SoftLine.Trebol.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SoftLine.Trebol.Application.Features.Pucs.Commands.DeletePuc
{
    public class DeletePucCommandHandler : IRequestHandler<DeletePucCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeletePucCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeletePucCommand request, CancellationToken cancellationToken)
        {
            var pucEntity = await _unitOfWork.Repository<Puc>().GetByIdAsync(request.Id);
            if (pucEntity == null)
            {
                throw new NotFoundException(nameof(Puc), request.Id);
            }

            _unitOfWork.Repository<Puc>().DeleteEntity(pucEntity);
            await _unitOfWork.Complete();

            return Unit.Value;
        }
    }
}
