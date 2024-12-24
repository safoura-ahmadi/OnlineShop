using Domain.Dtos;
using Domain.Entiteis;

namespace Domain.Contracts.Repository;

public interface IUserRepository
{
    //  هنگام ثبت نام کاربر جدید چک کند که یوز نیم وارد شده یونیک باشد
    bool IsExist(string username); 
    //اگر یوزنیم و پسورد درست بود ، و لاگین انچام شد بخش اط اطلاعات یوزر از دیتابیس اورده شود
    GetUserDTO? Get(string username, string password);

    //چون تعداد پراپرتی ها زیاد بود ، داخل سرویس مقدار هی شدند
    bool Creat(User user);
}
