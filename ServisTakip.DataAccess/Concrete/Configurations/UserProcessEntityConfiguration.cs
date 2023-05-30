using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.Configurations
{
    public class UserProcessEntityConfiguration : IEntityTypeConfiguration<UserProcess>
    {
        public void Configure(EntityTypeBuilder<UserProcess> builder)
        {
            builder.ToTable("UserProcesses", MsDbContext.DEFAULT_SCHEMA);
            builder.HasKey(x => x.Id);
        }
    }
}
