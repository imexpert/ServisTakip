using ServisTakip.DataAccess.Abstract;
using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using ServisTakip.Core.DataAccess.EntityFramework;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.EntityFramework
{
    public class ResultCodeRepository : EntityRepositoryBase<ResultCode, ProjectDbContext>, IResultCodeRepository
    {
        public ResultCodeRepository(ProjectDbContext context)
            : base(context)
        {
        }
    }
}
