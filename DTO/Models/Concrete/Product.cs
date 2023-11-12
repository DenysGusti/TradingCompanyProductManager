using DTO.Models.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO.Models.Concrete;

public class Product : EntityBase
{
    public string Name { get; set; } = null!;

    [Column(TypeName = "decimal(6, 2)")]
    public decimal Price { get; set; }

    public virtual Category Category { get; set; } = null!;

    public override string ToString() =>
    $"Id: {Id}\nName: {Name}\nPrice: {Price}\nCategoryId: {Category.Id}\n" +
    $"CreatedOn: {CreatedOn}\nLastModifiedOn: {LastModifiedOn}";
}
