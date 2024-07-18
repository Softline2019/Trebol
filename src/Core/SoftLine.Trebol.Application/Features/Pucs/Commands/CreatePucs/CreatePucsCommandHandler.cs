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

        private readonly int level1 = 2;
        private readonly int level2 = 2;
        private readonly int level3 = 2;
        private readonly int level4 = 0;
        private readonly int level5 = 0;
        private readonly int level6 = 0;
        private readonly int level7 = 0;
        private readonly int level8 = 0;
        //--------------------------------------------------------------------

       // private readonly string[] tiposPermitidos = { "N", "S", "C", "I", "R", "A" };//no creo que sea la falla

        //------------------------inferface---------------------------------------------
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
                throw new ArgumentException("El número de cuenta no es válido.");
            }
            //if (!EsTipoPermitido(request.Tipo))
            //{
            //    throw new ArgumentException("El tipo especificado no es válido.");
            //}

            //request.Digitable = EsTipoValido(request.Tipo);
            //request.Digitable = true;


            var PucsEntity = _mapper.Map<Puc>(request);
            await _unitOfWork.Repository<Puc>().AddAsync(PucsEntity);
            await _unitOfWork.Complete();

            return _mapper.Map<PucsVm>(PucsEntity);

        }
        //private bool EsTipoPermitido(string tipo)
        //{
        //    return tiposPermitidos.Contains(tipo);
        //}

        //private bool EsTipoValido(string tipo)
        //{
        //    // Si el tipo no es 'N', el campo digitable se establece en true
        //    return tipo != "N";
        //}

        private async Task<bool> EsNumeroDeCuentaValido(string cuenta)
        {
            var cuentasPuc = await _unitOfWork.Repository<Puc>().GetAllAsync();
            var cuentasPucStr = cuentasPuc.Select(p => p.Cuenta.ToString()).ToList();

            if (cuenta.Length == 1)
            {
                return !cuentasPucStr.Contains(cuenta);
            }
            else if (cuenta.Length == level1)
            {
                return ExisteClase(cuentasPucStr, cuenta.Substring(0, 1)) && !cuentasPucStr.Contains(cuenta);
            }
            else if (cuenta.Length == level1 + level2)
            {
                return ValidarNivelConPadre(cuentasPuc, cuenta, level1) && !cuentasPucStr.Contains(cuenta);
            }
            else if (cuenta.Length == level1 + level2 + level3)
            {
                return ValidarNivelConPadre(cuentasPuc, cuenta, level1 + level2) && !cuentasPucStr.Contains(cuenta);
            }
            else if (cuenta.Length == level1 + level2 + level3 + level4)
            {
                return ValidarNivelConPadre(cuentasPuc, cuenta, level1 + level2 + level3) && !cuentasPucStr.Contains(cuenta);
            }
            else if (cuenta.Length == level1 + level2 + level3 + level4 + level5)
            {
                return ValidarNivelConPadre(cuentasPuc, cuenta, level1 + level2 + level3 + level4) && !cuentasPucStr.Contains(cuenta);
            }
            else if (cuenta.Length == level1 + level2 + level3 + level4 + level5 + level6)
            {
                return ValidarNivelConPadre(cuentasPuc, cuenta, level1 + level2 + level3 + level4 + level5) && !cuentasPucStr.Contains(cuenta);
            }
            else if (cuenta.Length == level1 + level2 + level3 + level4 + level5 + level6 + level7)
            {
                return ValidarNivelConPadre(cuentasPuc, cuenta, level1 + level2 + level3 + level4 + level5 + level6) && !cuentasPucStr.Contains(cuenta);
            }
            else if (cuenta.Length == level1 + level2 + level3 + level4 + level5 + level6 + level7 + level8)
            {
                return ValidarNivelConPadre(cuentasPuc, cuenta, level1 + level2 + level3 + level4 + level5 + level6 + level7) && !cuentasPucStr.Contains(cuenta);
            }
            else
            {
                throw new ArgumentException("Por favor verifique el número que está ingresando ya que sobrepasa la longitud permitida.");
            }
        }

        private bool ExisteClase(IEnumerable<string> cuentasPucStr, string clase)
        {
            return cuentasPucStr.Any(c => c.StartsWith(clase));
        }

        private bool ExisteNivel(IEnumerable<string> cuentasPucStr, string nivel)
        {
            return cuentasPucStr.Contains(nivel);
        }

        private bool ValidarNivelConPadre(IEnumerable<Puc> cuentasPuc, string cuenta, int longitud)
        {
            string subCuenta = cuenta.Substring(0, longitud);
            var cuentaPadre = cuentasPuc.FirstOrDefault(p => p.Cuenta.ToString() == subCuenta);

            if (cuentaPadre != null && cuentaPadre.Digitable)
            {
                return false;
            }

            return ExisteNivel(cuentasPuc.Select(p => p.Cuenta.ToString()), subCuenta);
        }
    }
}
