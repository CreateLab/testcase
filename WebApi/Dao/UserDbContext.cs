using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Dao;

public class UserDbContext : DbContext
{
    public DbSet<RequestUser> Users { get; set; }


    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
        this.Database.EnsureCreated();
    }
}