using SoftLine.Trebol.Domain.Common;

namespace SoftLine.Trebol.Domain;

public class Address : BaseDomainModel
{
    public string? Direccion { get; set; }
    public string? Ciudad { get; set; }
    public string? Departamento { get; set; }
    public string? CodigoPostal { get; set; }
    public string? UserName { get; set; }
    public string? Pais { get; set; }

}
