using Dapper.Contrib.Extensions;
using System.Text.Json.Serialization;

namespace Entities.Abstract;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
    [JsonIgnore]
    public DateTime CreatedAt { get; set; }
    [JsonIgnore]
    public int CreatedBy { get; set; }
    [JsonIgnore]
    public DateTime UpdatedAt { get; set; }
    [JsonIgnore]
    public int UpdatedBy { get; set; }
}