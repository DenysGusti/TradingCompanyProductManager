using DTO.Models.Abstract;

namespace DTO.Models.Concrete;

public class User : EntityBase
{
    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;
}
