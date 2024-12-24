using System.ComponentModel.DataAnnotations;

namespace Domain.Entiteis;

public class Category
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(25)]
    public required string Name { get; set; }
    public List<Product> Products { get; set; } = [];
}
