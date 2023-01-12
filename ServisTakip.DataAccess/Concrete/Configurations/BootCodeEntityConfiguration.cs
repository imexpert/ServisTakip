using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.Configurations
{
    public class BootCodeEntityConfiguration : IEntityTypeConfiguration<BootCode>
    {
        public void Configure(EntityTypeBuilder<BootCode> builder)
        {
            builder.ToTable("BootCodes", MsDbContext.CONST_SCHEMA);
            builder.HasKey(x => x.Id);
        }
    }
}
