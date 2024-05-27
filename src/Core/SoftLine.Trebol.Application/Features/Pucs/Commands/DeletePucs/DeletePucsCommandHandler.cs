//using MediatR;
//using SendGrid.Helpers.Errors.Model;
//using SoftLine.Trebol.Application.Persistence;
//using SoftLine.Trebol.Domain;


//namespace SoftLine.Trebol.Application.Features.Pucs.Commands.DeletePucs
//{
//    public class DeletePucsCommandHandler : IRequestHandler<DeletePucsCommand>
//    {
//        private readonly IUnitOfWork _unitOfWork;

//        public DeletePucsCommandHandler(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }

//        public async Task<Unit> Handle(DeletePucsCommand request, CancellationToken cancellationToken)
//        {
//            var pucEntity = await _unitOfWork.Repository<Puc>().GetByIdAsync(request.Id);
//            if (pucEntity == null)
//            {
//                throw new NotFoundException(nameof(Puc), request.Id);
//            }

//            await _unitOfWork.Repository<Puc>().DeleteAsync(pucEntity);
//            return Unit.Value;
//        }
//    }
//}
