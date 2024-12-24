﻿namespace Domain.Dtos;

public class GetUserDTO
{
    public int Id { get; set; }
    public required string UserName { get; set; }
    public required string Password { get; set; }
}
