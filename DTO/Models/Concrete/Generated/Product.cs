using DTO.Models.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO.Models.Concrete.Generated;

public partial class Product : EntityBase
{
    public string Name { get; set; } = null!;

    [Column(TypeName = "decimal(6, 2)")]
    public decimal Price { get; set; }

    public virtual Category Category { get; set; } = null!;
}
