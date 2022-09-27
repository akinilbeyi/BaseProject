using Entities.Concrete;
using Entities.Dto;

namespace Business.Abstract;
public interface IUserService
{
    Task<UserDto> Add(UserDto user);
    Task<bool> Update(UserDto user);
    Task<bool> DeleteById(int userId);
    Task<UserDto> GetById(int userId);
    Task<UserDto> GetByEmail(string? email);
    Task<bool> Register(UserForRegisterDto user);
    Task<bool> Login(UserForLoginDto user);
    Task<IEnumerable<UserDto>> GetAll();
}
