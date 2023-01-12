using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.Configurations
{
    public class DeviceServiceEntityConfiguration : IEntityTypeConfiguration<DeviceService>
    {
        public void Configure(EntityTypeBuilder<DeviceService> builder)
        {
            builder.ToTable("DeviceServices", MsDbContext.DEFAULT_SCHEMA);
            builder.HasKey(x => x.Id);

            builder.HasOne(s => s.LinkedDeviceService).WithMany(s => s.DeviceServices).HasForeignKey(s => s.LinkedDeviceServiceId);
            builder.HasOne(s => s.Device).WithMany(s => s.DeviceServices).HasForeignKey(s => s.DeviceId);
        }
    }
}
