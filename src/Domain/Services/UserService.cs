using Domain.Contracts.Repository;
using Domain.Contracts.Sevices;
using Domain.Dtos;
using Domain.Entiteis;
using Domain.Utilities;
using Infrastructure;
using System.Text.RegularExpressions;

namespace Domain.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;

    public Result Register(string userName, string password, string? email = null, string? mobile = null)
    {
        if (!IsUserNameVaild(userName))
            return new Result(false, "نام کاربری در دسترس نیست.");
        if (!IsPasswordValid(password))
            return new Result(false, "پسورد باید حداقل شامل هفت کاکتر متشکل از اعداد و حروف باشد");
        if (email != null && !ValidationService.IsEmailValid(email))
            return new Result(false, "ایمیل نامعتبر است");
        if (mobile != null && !ValidationService.IsMobileValid(mobile))
            return new Result(false, "تلفن همراه نامعتبر");
        var user = new User()
        {
            UserName = userName,
            Password = password,
            Email = email,
            Moblie = mobile

        };
        if (!_userRepository.Creat(user))
            return new Result(false, "Something Wrong in Sql!");
        return new Result(true, "ثبت نام با موفقیت انجام شد.");

    }
    public bool Login(string username, string password)
    {
        InMemoryDb.OnlineUser = _userRepository.Get(username, password);
        if (InMemoryDb.OnlineUser != null)
            return true;
        return false;
    }
    public bool IsUserNameVaild(string userName)
    {
        if (_userRepository.IsExist(userName) || userName.Contains(' '))
            return false;
        return true;
    }
    public bool IsPasswordValid(string password)
    {
        if (password == null || password.Length < 6
            || password.All(Char.IsDigit) || password.All(Char.IsLetter)
            || password.Contains(' '))
            return false;
        return true;
    }



}
