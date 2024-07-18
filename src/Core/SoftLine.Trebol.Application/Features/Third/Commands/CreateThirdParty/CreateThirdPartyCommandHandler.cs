using AutoMapper;
using MediatR;
using SoftLine.Trebol.Application.Features.Third.Commands.CreateThirdParty;
using SoftLine.Trebol.Application.Features.Third.Queries.Vms;
using SoftLine.Trebol.Application.Persistence;
using SoftLine.Trebol.Domain;
using Microsoft.Extensions.Logging;
using System;

namespace SoftLine.Trebol.Application.Features.Third.Commands.CreateThird;

public class CreateThirdPartyCommandHandler : IRequestHandler<CreateThirdPartyCommand, ThirdPartyVm>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateThirdPartyCommandHandler> _logger;

    public CreateThirdPartyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateThirdPartyCommandHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<ThirdPartyVm> Handle(CreateThirdPartyCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var thirdPartyEntity = _mapper.Map<ThirdParty>(request);

            if (IsValidNIT(request.NIT))
            {
                thirdPartyEntity.VerificationDigitNIT = CalculateVerificationDigit(request.NIT.ToString());
            }
            else
            {
                _logger.LogWarning("NIT inválido: {NIT}", request.NIT);
                throw new ArgumentException("NIT inválido");
            }

            await _unitOfWork.Repository<ThirdParty>().AddAsync(thirdPartyEntity);
            await _unitOfWork.Complete();

            return _mapper.Map<ThirdPartyVm>(thirdPartyEntity);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al crear el tercero");
            throw;
        }
    }

    private bool IsValidNIT(long nit)
    {
        // Implementar la validación del NIT aquí si es necesario
        return nit > 0; // Ejemplo básico de validación
    }

    private int CalculateVerificationDigit(string nit)
    {
        if (string.IsNullOrWhiteSpace(nit))
        {
            throw new ArgumentException("El NIT no puede ser nulo o vacío.");
        }

        // Verificar que el NIT sea numérico
        if (!long.TryParse(nit, out _))
        {
            throw new ArgumentException("El NIT contiene caracteres no numéricos.");
        }

        int[] coefficients = { 3, 7, 13, 17, 19, 23, 29, 37, 41, 43, 47, 53 }; // Coeficientes para manejar hasta 12 dígitos
        int valorCalculado = 0;
        int aux = nit.Length - 1;

        for (int i = 0; i < nit.Length; i++)
        {
            int digit = int.Parse(nit[aux - i].ToString());
            valorCalculado += digit * coefficients[i];
        }

        int modulo = valorCalculado % 11;

        if (modulo >= 2)
        {
            modulo = 11 - modulo;
        }

        return modulo;
    }
}
