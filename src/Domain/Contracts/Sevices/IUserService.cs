using Domain.Dtos;
using Domain.Utilities;

namespace Domain.Contracts.Sevices;

public interface IUserService
{
    Result Register(string userName, string password, string? email = null, string? mobile = null);
    bool Login(string username, string password);
    public bool IsPasswordValid(string password);
    public bool IsUserNameVaild(string userName);
}
