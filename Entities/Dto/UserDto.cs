using Entities.Abstract;

namespace Entities.Dto;
public class UserDto : BaseEntity, IDto
{
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    public string? Password { get; set; }
    public bool IsActive { get; set; }
}
