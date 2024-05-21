using AutoMapper;
using MediatR;
using SoftLine.Trebol.Application.Features.Receipts.Queries.Vms;
using SoftLine.Trebol.Application.Persistence;
using SoftLine.Trebol.Domain;

namespace SoftLine.Trebol.Application.Features.Receipts.Commands.CreateReceipts;

public class CreateReceiptsCommandHandler : IRequestHandler<CreateReceiptsCommand, ReceiptsVm>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateReceiptsCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }    

    public async Task<ReceiptsVm> Handle(CreateReceiptsCommand request, CancellationToken cancellationToken)
    {
        var receiptsEntity = _mapper.Map<Receipt>(request);
        await _unitOfWork.Repository<Receipt>().AddAsync(receiptsEntity);
        await _unitOfWork.Complete();

        return _mapper.Map<ReceiptsVm>(receiptsEntity);
    }
}
