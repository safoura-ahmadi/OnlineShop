using System.ComponentModel.DataAnnotations;

namespace Domain.Entiteis;

public class User
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(10)]
    public required string Password { get; set; }
    [Required]
    [MaxLength(10)]
    public required string UserName { get; set; }
    [MaxLength(60)]
    public string? Email { get; set; }
    [MaxLength(13)]
    public string? Moblie { get; set; }
}
