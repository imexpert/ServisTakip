using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.Configurations
{
    public class DetectionCodeEntityConfiguration : IEntityTypeConfiguration<DetectionCode>
    {
        public void Configure(EntityTypeBuilder<DetectionCode> builder)
        {
            builder.ToTable("DetectionCodes", MsDbContext.CONST_SCHEMA);
            builder.HasKey(x => x.Id);
        }
    }
}
