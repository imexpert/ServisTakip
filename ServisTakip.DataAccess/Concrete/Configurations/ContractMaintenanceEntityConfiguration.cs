using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.Configurations
{
    public class ContractMaintenanceEntityConfiguration : IEntityTypeConfiguration<ContractMaintenance>
    {
        public void Configure(EntityTypeBuilder<ContractMaintenance> builder)
        {
            builder.ToTable("ContractMaintenances", MsDbContext.DEFAULT_SCHEMA);
            builder.HasKey(x => x.Id);

            builder.HasOne(s => s.Contract).WithMany(s => s.ContractMaintenances).HasForeignKey(s => s.ContractId);
            builder.HasOne(s => s.DeviceService).WithMany(s => s.ContractMaintenances).HasForeignKey(s => s.DeviceServiceId);
        }
    }
}
