using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.Configurations
{
    public class DistrictEntityConfiguration : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.ToTable("Districts", MsDbContext.CONST_SCHEMA);
            builder.HasKey(x => x.Id);

            builder.HasOne(s => s.City).WithMany(s => s.Districts).HasForeignKey(s => s.CityId);
        }
    }
}
