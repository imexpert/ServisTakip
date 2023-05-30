using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServisTakip.Entities.DTOs.Reports;

namespace ServisTakip.DataAccess.Concrete.Configurations
{
    public class OfferReportEntityConfiguration : IEntityTypeConfiguration<OfferReportModel>
    {
        public void Configure(EntityTypeBuilder<OfferReportModel> builder)
        {
            builder.ToView("VW_Offer", MsDbContext.DEFAULT_SCHEMA);
            builder.HasNoKey();
        }
    }
}
