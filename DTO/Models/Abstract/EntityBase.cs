namespace DTO.Models.Abstract;

public abstract class EntityBase
{
    public int Id { get; set; }

    public DateTime LastModifiedOn { get; set; }

    public DateTime CreatedOn { get; set; }
}
