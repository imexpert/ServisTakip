using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.Configurations
{
    public class QuerterEntityConfiguration : IEntityTypeConfiguration<Querter>
    {
        public void Configure(EntityTypeBuilder<Querter> builder)
        {
            builder.ToTable("Querters", MsDbContext.CONST_SCHEMA);
            builder.HasKey(x => x.Id);

            builder.HasOne(s => s.District).WithMany(s => s.Querters).HasForeignKey(s => s.DistrictId);
        }
    }
}
