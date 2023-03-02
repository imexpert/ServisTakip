using ServisTakip.Core.DataAccess;
using ServisTakip.Entities.Concrete;
using ServisTakip.Entities.DTOs.Reports;

namespace ServisTakip.DataAccess.Abstract
{
    public interface IOfferRepository : IEntityRepository<Offer>
    {
        Task<OfferReportModel> GetOfferAsync(long deviceServiceId,
            CancellationToken cancellationToken);
    }
}
