using Domain.Entiteis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
             .OnDelete(DeleteBehavior.Cascade);
        builder.Property(p => p.Price)
            .HasColumnType("decimal");
        builder.HasData(

            new Product()
            { Id = 1, Name = "s21 fe", Quantity = 10, Price = 200, CategoryId = 1 },
            new Product()
            { Id = 2, Name = "A55", Quantity = 10, Price = 100, CategoryId = 1 },
             new Product()
             { Id = 3, Name = "قند پهلو", Quantity = 10, Price = 200, CategoryId = 2 },
            new Product()
            { Id = 4, Name = "کفس ورزشی", Quantity = 10, Price = 100, CategoryId = 3 }

        );
    }
}
