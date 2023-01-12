using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.Configurations
{
    public class DeviceEntityConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.ToTable("Devices", MsDbContext.DEFAULT_SCHEMA);
            builder.HasKey(x => x.Id);

            builder.HasOne(s => s.Address).WithMany(s => s.Devices).HasForeignKey(s => s.AddressId);
            builder.HasOne(s => s.DeviceModel).WithMany(s => s.Devices).HasForeignKey(s => s.DeviceModelId);
        }
    }
}
