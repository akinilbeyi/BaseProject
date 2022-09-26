using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.Concrete;
public class UserManager: IUserService
{
    private readonly IUserDAL _userDAL;
    private readonly IMapper _mapper;
    public UserManager(IUserDAL userDAL, IMapper mapper)
    {
        _userDAL = userDAL;
        _mapper = mapper;
    }

    public async Task<UserDto> Add(UserDto user)
    {

        user.CreatedAt= DateTime.Now;
        user.CreatedBy = 0;


        var entity = _mapper.Map<User>(user);

       var result = await _userDAL.Insert(entity);

        user.Id = result;

        return user;
    }
    public async Task<bool> Update(UserDto user)
    {
        user.UpdatedAt = DateTime.Now;
        user.UpdatedBy = 0;


        var entity = _mapper.Map<User>(user);

        var result = await _userDAL.Update(entity);
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

       var entity =  _mapper.Map<UserDto>(result);
        return entity;
    }
}
