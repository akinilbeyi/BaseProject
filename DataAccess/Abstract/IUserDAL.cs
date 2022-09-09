using Entities.Concrete;
using Entities.Dto;

namespace DataAccess.Abstract;
public interface IUserDAL
{
    Task<UserDto> GetById(int userId);
    Task<IEnumerable<UserDto>> GetAll();
    Task<bool> DeleteById(int userId);
    Task<bool> Update(User user);
    Task<int> Insert(User user);
}
