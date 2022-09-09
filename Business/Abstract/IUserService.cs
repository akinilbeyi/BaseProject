using Entities.Dto;

namespace Business.Abstract;
public interface IUserService
{
    Task<UserDto> Add(UserDto user);
    Task<bool> Update(UserDto user);
    Task<bool> DeleteById(int userId);
    Task<UserDto> GetById(int userId);
    Task<IEnumerable<UserDto>> GetAll();
}
