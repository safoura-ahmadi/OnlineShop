namespace Domain.Utilities;

public class Result(bool isSucces, string? message = null)
{
    public bool IsSuccess { get; set; } = isSucces;
    public string? Message { get; set; } = message;
}
