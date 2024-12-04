using AutoMapper;
using MediatR;
using SoftLine.Trebol.Application.Features.Pucs.Queries.Vms;
using SoftLine.Trebol.Application.Persistence;
using SoftLine.Trebol.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SoftLine.Trebol.Application.Features.Pucs.Commands.CreatePucs
{
    public class CreatePucsCommandHandler : IRequestHandler<CreatePucsCommand, PucsVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePucsCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PucsVm> Handle(CreatePucsCommand request, CancellationToken cancellationToken)
        {
            string cuentaStr = request.Cuenta.ToString();

            if (!await EsNumeroDeCuentaValido(cuentaStr))
            {
                throw new Exception("El número de cuenta no es válido.");
            }

            var PucsEntity = _mapper.Map<Puc>(request);
            await _unitOfWork.Repository<Puc>().AddAsync(PucsEntity);
            await _unitOfWork.Complete();

            return _mapper.Map<PucsVm>(PucsEntity);
        }

        private async Task<bool> EsNumeroDeCuentaValido(string cuenta)
        {
            var cuentasPuc = await _unitOfWork.Repository<Puc>().GetAllAsync();
            var cuentasPucStr = cuentasPuc.Select(p => p.Cuenta.ToString()).ToList();

            if (cuenta.Length == 1)
            {
                if (cuentasPucStr.Contains(cuenta))
                {
                    return false;
                }
            }
            else if (cuenta.Length == 2)
            {
                char primerNumero = cuenta[0];
                bool claseExiste = cuentasPucStr.Any(c => c.Length == 1 && c[0] == primerNumero);

                if (!claseExiste)
                {
                    return false;
                }

                bool grupoExiste = cuentasPucStr.Contains(cuenta);

                if (grupoExiste)
                {
                    return false;
                }
            }
            else if (cuenta.Length == 4)
            {
                string grupo = cuenta.Substring(0, 2);
                bool grupoExiste = cuentasPucStr.Any(c => c.Length == 2 && c.Substring(0, 2) == grupo);

                if (!grupoExiste)
                {
                    return false;
                }

                bool cuentaExiste = cuentasPucStr.Contains(cuenta);

                if (cuentaExiste)
                {
                    return false;
                }
            }
            else if (cuenta.Length == 6)
            {
                string cuentaBase = cuenta.Substring(0, 4);
                bool cuentaExiste = cuentasPucStr.Any(c => c.Length == 4 && c.Substring(0, 4) == cuentaBase);

                if (!cuentaExiste)
                {
                    return false;
                }

                bool subcuentaExiste = cuentasPucStr.Contains(cuenta);

                if (subcuentaExiste)
                {
                    return false;
                }
            }
            else if (cuenta.Length > 6)
            {
                throw new Exception("Por favor verifique el número que está ingresando ya que sobrepasa la longitud permitida.");
            }

            return true;
        }
    }
}
