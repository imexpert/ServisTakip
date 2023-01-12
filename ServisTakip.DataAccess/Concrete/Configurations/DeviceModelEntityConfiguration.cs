using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.Configurations
{
    public class DeviceModelEntityConfiguration : IEntityTypeConfiguration<DeviceModel>
    {
        public void Configure(EntityTypeBuilder<DeviceModel> builder)
        {
            builder.ToTable("DeviceModels", MsDbContext.DEFAULT_SCHEMA);
            builder.HasKey(x => x.Id);

            builder.HasOne(s => s.DeviceBrand).WithMany(s => s.DeviceModels).HasForeignKey(s => s.DeviceBrandId);
        }
    }
}
