using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.Configurations
{
    public class DeviceServicePartEntityConfiguration : IEntityTypeConfiguration<DeviceServicePart>
    {
        public void Configure(EntityTypeBuilder<DeviceServicePart> builder)
        {
            builder.ToTable("DeviceServiceParts", MsDbContext.DEFAULT_SCHEMA);
            builder.HasKey(x => x.Id);

            builder.HasOne(s => s.DeviceService).WithMany(s => s.DeviceServiceParts).HasForeignKey(s => s.DeviceServiceId);
        }
    }
}
