using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.Configurations
{
    public class ContractCodeEntityConfiguration : IEntityTypeConfiguration<ContractCode>
    {
        public void Configure(EntityTypeBuilder<ContractCode> builder)
        {
            builder.ToTable("ContractCodes", MsDbContext.CONST_SCHEMA);
            builder.HasKey(x => x.Id);
        }
    }
}
