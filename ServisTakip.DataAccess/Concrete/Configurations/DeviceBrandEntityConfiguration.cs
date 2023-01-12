using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.Configurations
{
    public class DeviceBrandEntityConfiguration : IEntityTypeConfiguration<DeviceBrand>
    {
        public void Configure(EntityTypeBuilder<DeviceBrand> builder)
        {
            builder.ToTable("DeviceBrands", MsDbContext.DEFAULT_SCHEMA);
            builder.HasKey(x => x.Id);

            builder.HasOne(s => s.DeviceType).WithMany(s => s.DeviceBrands).HasForeignKey(s => s.DeviceTypeId);
        }
    }
}
