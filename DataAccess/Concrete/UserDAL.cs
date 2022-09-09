using Dapper;
using Dapper.Contrib.Extensions;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System.Data;

namespace DataAccess.Concrete;
public class UserDAL : IUserDAL
{
    private readonly IDbConnection _connection;

    public UserDAL(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<bool> DeleteById(int userId)
    {
        string sqlQuery = "DELETE [User] WHERE Id=@Id";

        var p = new
        {
            Id = userId
        };

        var result = await _connection.ExecuteAsync(sqlQuery, p, commandType: CommandType.Text);
        return result > 0;
    }

    public async Task<IEnumerable<UserDto>> GetAll()
    {
        string sqlQuery = "SELECT * FROM [User]";

        var p = new
        {
        };

        var result = await _connection.QueryAsync<UserDto>(sqlQuery, p, commandType: CommandType.Text);
        return result;
    }

    public async Task<UserDto> GetById(int userId)
    {
        string sqlQuery = "SELECT * FROM [User] WHERE Id=@Id";

        var p = new
        {
            Id = userId
        };

        var result = await _connection.QuerySingleOrDefaultAsync<UserDto>(sqlQuery, p, commandType: CommandType.Text);
        return result;
    }

    public async Task<int> Insert(User user)
    {
        var result = await _connection.InsertAsync<User>(user);
        return result;
    }

    public async Task<bool> Update(User user)
    {
        var result = await _connection.UpdateAsync(user);
        return result;
    }
}
