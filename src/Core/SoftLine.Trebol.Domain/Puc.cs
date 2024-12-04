using SoftLine.Trebol.Domain.Common;

namespace SoftLine.Trebol.Domain;

public class Puc : BaseDomainModel
{
    public string? NombreCorto { get; set; }
    public int Cuenta { get; set; }
    public string? Nombre { get; set; }
    public int TipoId { get; set; }
    public Tipo? Tipo { get; set; }
    public int CodTributario { get; set; }
    public bool Digitable { get; set; }
}
