using ServisTakip.DataAccess.Abstract;
using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using ServisTakip.Core.DataAccess.EntityFramework;
using ServisTakip.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using ServisTakip.Core.Extensions;

namespace ServisTakip.DataAccess.Concrete.EntityFramework
{
    public class DeviceModelRepository : EntityRepositoryBase<DeviceModel, ProjectDbContext>, IDeviceModelRepository
    {
        ProjectDbContext _context;
        public DeviceModelRepository(ProjectDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<List<DeviceModel>> GetModelByFilterAsync(string filter, CancellationToken cancellationToken)
        {
            return await _context.DeviceModels
                .Where(s => EF.Functions.Like(s.Name, $"%{filter}%"))
                .AsNoTracking()
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
