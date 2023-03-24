using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.Configurations
{
    public class AddressEntityConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses", MsDbContext.DEFAULT_SCHEMA);
            builder.HasKey(x => x.Id);

            builder.HasOne(s => s.Customer).WithMany(s => s.Addresses).HasForeignKey(s => s.CustomerId);
            builder.HasOne(s => s.District).WithMany(s => s.Addresses).HasForeignKey(s => s.DistrictId);
        }
    }
}
