using AutoMapper;
using MediatR;
using SoftLine.Trebol.Application.Exceptions;
using SoftLine.Trebol.Application.Persistence;
using SoftLine.Trebol.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SoftLine.Trebol.Application.Features.Pucs.Commands.UpdatePuc
{
    public class UpdatePucCommandHandler : IRequestHandler<UpdatePucCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePucCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePucCommand request, CancellationToken cancellationToken)
        {
            var pucEntity = await _unitOfWork.Repository<Puc>().GetByIdAsync(request.Id);
            if (pucEntity == null)
            {
                throw new NotFoundException(nameof(Puc), request.Id);
            }

            pucEntity.NombreCorto = request.NombreCorto;
            pucEntity.Cuenta = request.Cuenta;
            pucEntity.Nombre = request.Nombre;
            pucEntity.TipoId = request.TipoId;
            pucEntity.CodTributario = request.CodTributario;
            pucEntity.Digitable = request.Digitable;

            _unitOfWork.Repository<Puc>().UpdateEntity(pucEntity);
            await _unitOfWork.Complete();

            return Unit.Value;
        }
    }
}
