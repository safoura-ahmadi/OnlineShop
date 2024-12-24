using Domain.Dtos;
using Domain.Entiteis;

namespace Infrastructure;

public static class InMemoryDb
{
    public static GetUserDTO? OnlineUser { get; set; }
    public static Product? CurrentProduct { get; set; }
}
