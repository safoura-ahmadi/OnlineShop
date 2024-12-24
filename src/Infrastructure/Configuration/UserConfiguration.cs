using Domain.Entiteis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(

            new User()
            {

                Id = 1,
                UserName = "safoura",
                Password = "abc123",
                Email = "safoora.ahmadiasl@gmail.com",
                Moblie = "09308762254"

            },
            new User()
            {

                Id = 2,
                UserName = "tahoura",
                Password = "abc123",
                Email = "ta.ahmadiasl@gmail.com",
                Moblie = "09308762884"

            }

        );
    }
}
