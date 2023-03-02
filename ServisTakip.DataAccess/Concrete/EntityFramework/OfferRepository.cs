using Microsoft.EntityFrameworkCore;
using ServisTakip.Core.DataAccess.EntityFramework;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using ServisTakip.Entities.Concrete;
using ServisTakip.Entities.DTOs.Reports;

namespace ServisTakip.DataAccess.Concrete.EntityFramework
{
    public class OfferRepository : EntityRepositoryBase<Offer, ProjectDbContext>, IOfferRepository
    {
        ProjectDbContext _context;
        public OfferRepository(ProjectDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<OfferReportModel> GetOfferAsync(long deviceServiceId, CancellationToken cancellationToken)
        {
            return await _context.OfferReports
                .Where(s => s.DeviceServiceId == deviceServiceId)
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
