using System.Runtime.Serialization;

namespace SoftLine.Trebol.Domain;

public enum ProductStatus
{
    [EnumMember(Value = "Producto Inactivo")]
    Inactivo,
    [EnumMember(Value = "Producto Activo")]
    Activo
}
