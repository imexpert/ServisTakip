using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServisTakip.Core.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.Configurations
{
    public class UserGroupEntityConfiguration : IEntityTypeConfiguration<UserGroup>
    {
        public void Configure(EntityTypeBuilder<UserGroup> builder)
        {
            builder.ToTable("UserGroups", MsDbContext.DEFAULT_SCHEMA);
            builder.HasKey(x => x.Id);

            builder.HasOne(s => s.Group).WithMany(s => s.UserGroups).HasForeignKey(s => s.GroupId);
            builder.HasOne(s => s.User).WithMany(s => s.UserGroups).HasForeignKey(s => s.UserId);
        }
    }
}
