using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using Shared.Utilities.Hashing;


namespace Business.Concrete;
public class UserManager : IUserService
{
    private readonly IUserDAL _userDAL;
    private readonly IMapper _mapper;
    public UserManager(IUserDAL userDAL, IMapper mapper)
    {
        _userDAL = userDAL;
        _mapper = mapper;
    }

    public async Task<bool> Register(UserForRegisterDto userRegister)
    {
        var result = await GetByEmail(userRegister?.Email);

        if (result is not null)
            return false;


        var entity = _mapper.Map<User>(userRegister);

        HashingHelper.CreatePasswordHash(userRegister?.Password, out byte[] passwordHash, out byte[] passwordSalt);

        entity.PasswordHash = passwordHash;
        entity.PasswordSalt = passwordSalt;
        entity.CreatedAt = DateTime.Now;
        entity.CreatedBy = 1;

        _ = await _userDAL.Insert(entity);

        return true;
    }
    public async Task<bool> Login(UserForLoginDto user)
    {
        var userEntity = await GetByEmail(user?.Email);

        if (userEntity is null)
            return false;


        var passwordMatched = HashingHelper.VerifyPasswordHash(user?.Password, userEntity?.PasswordHash, userEntity?.PasswordSalt);

        if (passwordMatched == false)
            return false;

        return true;
    }

    public async Task<UserDto> Add(UserDto user)
    {

        user.CreatedAt = DateTime.Now;
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

        var entity = _mapper.Map<UserDto>(result);
        return entity;
    }
    public async Task<UserDto> GetByEmail(string? email)
    {
        var result = await _userDAL.GetByEmail(email!);
        return result;
    }
}
