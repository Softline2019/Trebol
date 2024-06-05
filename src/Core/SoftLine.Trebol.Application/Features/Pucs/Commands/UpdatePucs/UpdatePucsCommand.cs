using MediatR;

namespace SoftLine.Trebol.Application.Features.Pucs.Commands.UpdatePucs;

    public class UpdatePucsCommand : IRequest
    {
        public int Id { get; set; }
        public string NombreCorto { get; set; }
        public int Cuenta { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int CodTributario { get; set; }
        public string Digitable { get; set; }
    }

