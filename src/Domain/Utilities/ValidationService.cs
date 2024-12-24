using Domain.Contracts.Repository;
using Domain.Dtos;
using System.Text.RegularExpressions;

namespace Domain.Utilities;

public static class ValidationService
{

    public static bool IsEmailValid(string email)
    {
        var pettern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        if (Regex.IsMatch(email, pettern))
        { return true; }
        return false;
    }

    public static bool IsMobileValid(string mobile)
    {
        var pattern = @"^(0|098|\+98|989)9\d{9}$";

        if (Regex.IsMatch(mobile, pattern))
        { return true; }
        return false;

    }
    public static bool IsPriceValid(decimal price)
    {
        if (price <= 0)
            return false;
        return true;
    }
    public static bool IsNameValid(string name)
    {
        name = name.Trim();
        if (name == null || name == "")
            return false;
        return true;
    }
    public static bool IsQuantityValid(int quantity)
    {
        if (quantity <= 0)
            return false;
        return true;
    }
}
