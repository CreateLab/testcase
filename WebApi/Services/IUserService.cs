using WebApi.Models;

namespace WebApi.Services;

public interface IUserService
{
    public Task<List<User>> GetUsers(string name, string phone);
}