using SoftLine.Trebol.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftLine.Trebol.Domain;

public class Category : BaseDomainModel
{
    [Column(TypeName = "NVARCHAR(100)")]
    public string? Nombre { get; set; }
    public virtual ICollection<Product>? Products { get; set; }
}
