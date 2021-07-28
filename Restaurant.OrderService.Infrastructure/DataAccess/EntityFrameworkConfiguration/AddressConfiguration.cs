using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.OrderService.Domain;

namespace Restaurant.OrderService.Infrastructure.DataAccess.EntityFrameworkConfiguration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");

            builder.HasKey(address => address.Id);

            builder.Property(address => address.Id).IsRequired().HasColumnType("BIGINT").UseIdentityColumn();

            builder.Property(address => address.City).IsRequired().HasColumnType("VARHCAR(255)");

            builder.Property(address => address.District).IsRequired().HasColumnType("VARHCAR(255)");

            builder.Property(address => address.State).IsRequired().HasColumnType("VARHCAR(255)");
        }
    }
}
