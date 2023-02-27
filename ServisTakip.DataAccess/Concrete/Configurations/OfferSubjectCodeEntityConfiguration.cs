using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.Configurations
{
    public class OfferSubjectCodeEntityConfiguration : IEntityTypeConfiguration<OfferSubjectCode>
    {
        public void Configure(EntityTypeBuilder<OfferSubjectCode> builder)
        {
            builder.ToTable("OfferSubjectCodes", MsDbContext.CONST_SCHEMA);
            builder.HasKey(x => x.Id);
        }
    }
}
