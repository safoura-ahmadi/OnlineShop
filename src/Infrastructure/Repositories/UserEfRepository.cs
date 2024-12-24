using Domain.Contracts.Repository;
using Domain.Dtos;
using Domain.Entiteis;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserEfRepository : IUserRepository
{
    private readonly ShopDbContext _context;
    public UserEfRepository()
    {
        _context = new ShopDbContext();
    }
    public bool Creat(User user)
    {
        try
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool IsExist(string username)
    {
        return _context.Users.Any(u => u.UserName == username);
    }
    public GetUserDTO? Get(string username, string password)
    {
        return _context.Users.AsNoTracking()
            .Where(u => u.UserName == username && u.Password == password)
            .Select(u => new GetUserDTO()
            {
                Id = u.Id,
                UserName = u.UserName,
                Password = u.Password,
            })
            .FirstOrDefault();

    }
}
