using DTO.Models.Abstract;

namespace DTO.Models.Concrete;

public class Category : EntityBase
{
    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
