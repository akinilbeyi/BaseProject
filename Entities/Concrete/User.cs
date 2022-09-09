using Dapper.Contrib.Extensions;
using Entities.Abstract;

namespace Entities.Concrete;

[Table("[User]")]
public class User:BaseEntity,IEntity
{
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Password { get; set; }
    public bool IsActive { get; set; }
}
