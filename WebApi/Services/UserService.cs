using Flurl.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using WebApi.Dao;
using WebApi.Models;

namespace WebApi.Services;

public class UserService:IUserService
{
    private readonly IDbContextFactory<UserDbContext> DbContextFactory;

    public UserService(IDbContextFactory<UserDbContext> dbContextFactory)
    {
        DbContextFactory = dbContextFactory;
    }

    public async Task<List<User>> GetUsers(string name, string phone)
    {
        using var context = await DbContextFactory.CreateDbContextAsync();
        
        var reqestUser = new RequestUser
        {
            Name = name,
            CreatedAt = DateTime.Now
        };

        await context.Users.AddAsync(reqestUser);
        await context.SaveChangesAsync();
        var jsonAsync = await "https://jsonplaceholder.typicode.com/users".GetJsonAsync<List<User>>();
        
        var showData = jsonAsync.Select(x => CheckAndUpdateData(x, name, phone)).ToList();
        return showData;
    }

    private User CheckAndUpdateData(User user, string name, string phone)
    {
       if(user.UserName.Contains(name) && user.Phone.Contains(phone))
           return user;
       return new User
       {
           UserName = user.UserName
       };
    }
}