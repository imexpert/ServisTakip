using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServisTakip.Core.Entities.Concrete;
using ServisTakip.Entities.DTOs.Reports;

namespace ServisTakip.DataAccess.Concrete.Configurations
{
    public class TechnicianDeviceServiceReportEntityConfiguration : IEntityTypeConfiguration<TechnicianDeviceServiceReportModel>
    {
        public void Configure(EntityTypeBuilder<TechnicianDeviceServiceReportModel> builder)
        {
            builder.ToView("VW_TechnicianReport", MsDbContext.DEFAULT_SCHEMA);
            builder.HasNoKey();
        }
    }
}
