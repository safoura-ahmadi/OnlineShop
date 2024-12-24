using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entiteis;

public class Product
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(25)]
    public required string Name { get; set; }
    [Required]
    public required decimal Price { get; set; }
    public int Quantity { get; set; }
    public string? CategoryName { get; set; }
    [ForeignKey("Category")]
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
