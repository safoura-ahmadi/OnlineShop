using Domain.Entiteis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasData(

            new Category()
            { Id = 1, Name = "دیجیتال" },
            new Category()
            { Id = 2, Name = "کتاب" },
            new Category()
            { Id = 3, Name = "ورزش و سلامتی" }

        );

    }
}
