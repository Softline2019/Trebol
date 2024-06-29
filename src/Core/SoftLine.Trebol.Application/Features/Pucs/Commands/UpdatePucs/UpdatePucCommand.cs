using MediatR;
using SoftLine.Trebol.Domain;

namespace SoftLine.Trebol.Application.Features.Pucs.Commands.UpdatePuc
{
    public class UpdatePucCommand : IRequest
    {
        public int Id { get; set; }
        public string? NombreCorto { get; set; }
        public int Cuenta { get; set; }
        public string? Nombre { get; set; }
        public int TipoId { get; set; }
        public Tipo? Tipo { get; set; }
        public int CodTributario { get; set; }
        public bool Digitable { get; set; }
    }
}
