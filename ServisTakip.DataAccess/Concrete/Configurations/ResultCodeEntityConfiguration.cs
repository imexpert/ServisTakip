using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.Configurations
{
    public class ResultCodeEntityConfiguration : IEntityTypeConfiguration<ResultCode>
    {
        public void Configure(EntityTypeBuilder<ResultCode> builder)
        {
            builder.ToTable("ResultCodes", MsDbContext.CONST_SCHEMA);
            builder.HasKey(x => x.Id);
        }
    }
}
