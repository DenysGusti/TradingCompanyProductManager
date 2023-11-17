namespace DTO.Models.Abstract;

public abstract class EntityBase
{
    protected EntityBase()
    {
        CreatedOn = DateTime.Now;
        LastModifiedOn = DateTime.Now;
    }

    public int Id { get; set; }

    public DateTime LastModifiedOn { get; set; }

    public DateTime CreatedOn { get; set; }
}
