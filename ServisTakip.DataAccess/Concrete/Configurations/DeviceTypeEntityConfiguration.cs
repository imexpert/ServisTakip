using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.Configurations
{
    public class DeviceTypeEntityConfiguration : IEntityTypeConfiguration<DeviceType>
    {
        public void Configure(EntityTypeBuilder<DeviceType> builder)
        {
            builder.ToTable("DeviceTypes", MsDbContext.DEFAULT_SCHEMA);
            builder.HasKey(x => x.Id);
        }
    }
}
