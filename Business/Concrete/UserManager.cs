using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;
public class UserManager: IUserService
{
    private readonly IUserDAL _userDAL;

    public UserManager(IUserDAL userDAL)
    {
        _userDAL = userDAL;
    }

    public async Task<UserDto> Add(UserDto user)
    {

        user.CreatedAt= DateTime.Now;
        user.CreatedBy = 0;
        user.UpdatedAt= DateTime.Now;
        user.UpdatedBy = 0;

        var userEntity = new User()
        {
            Id = 0,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            IsActive = user.IsActive,
            Password = user.Password,
            CreatedAt = user.CreatedAt,
            CreatedBy = user.CreatedBy,
            UpdatedBy = user.UpdatedBy,
            UpdatedAt = user.UpdatedAt
        };

       var result = await _userDAL.Insert(userEntity);

        user.Id = result;

        return user;
    }
    public async Task<bool> Update(UserDto user)
    {
        user.UpdatedAt = DateTime.Now;
        user.UpdatedBy = 0;

        var userEntity = new User()
        {
            Id = user.Id,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            IsActive = user.IsActive,
            Password = user.Password,
            CreatedAt = user.CreatedAt,
            CreatedBy = user.CreatedBy,
            UpdatedBy = user.UpdatedBy,
            UpdatedAt = user.UpdatedAt
        };

        var result = await _userDAL.Update(userEntity);
        return result;
    }
    public async Task<bool> DeleteById(int userId)
    {
        var result = await _userDAL.DeleteById(userId);
        return result;
    }

    public async Task<IEnumerable<UserDto>> GetAll()
    {
        var result = await _userDAL.GetAll();
        return result;
    }
    public async Task<UserDto> GetById(int userId)
    {
        var result = await _userDAL.GetById(userId);
        return result;
    }
}
