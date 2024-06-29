// Archivo: Trebol/Trebol/src/Core/SoftLine.Trebol.Application/Features/Third/Commands/CreateThirdParty/CreateThirdPartyCommandHandler.cs

using AutoMapper;
using MediatR;
using SoftLine.Trebol.Application.Features.Third.Commands.CreateThirdParty;
using SoftLine.Trebol.Application.Features.Third.Queries.Vms;
using SoftLine.Trebol.Application.Persistence;
using SoftLine.Trebol.Domain;

namespace SoftLine.Trebol.Application.Features.Third.Commands.CreateThird;

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
        var thirdPartyEntity = _mapper.Map<ThirdParty>(request);
        thirdPartyEntity.VerificationDigitNIT = CalculateVerificationDigit(request.NIT.ToString());

        await _unitOfWork.Repository<ThirdParty>().AddAsync(thirdPartyEntity);
        await _unitOfWork.Complete();

        return _mapper.Map<ThirdPartyVm>(thirdPartyEntity);
    }

    private int CalculateVerificationDigit(string documentNumber)
    {
        int[] coefficients = { 3, 7, 13, 17, 19, 23, 29, 37, 41, 43, 47, 53, 59, 67, 71 };
        int sum = 0;
        int length = documentNumber.Length;

        for (int i = 0; i < length; i++)
        {
            int digit = int.Parse(documentNumber[length - i - 1].ToString());
            sum += digit * coefficients[i];
        }

        int mod = sum % 11;
        if (mod == 0 || mod == 1)
        {
            return 0;
        }

        return 11 - mod;
    }
}
