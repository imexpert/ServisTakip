using ServisTakip.DataAccess.Abstract;
using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServisTakip.Core.DataAccess.EntityFramework;
using ServisTakip.Core.Entities.Concrete;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.EntityFramework
{
    public class SectorRepository : EntityRepositoryBase<Sector, ProjectDbContext>, ISectorRepository
    {
        public SectorRepository(ProjectDbContext context)
            : base(context)
        {
        }
    }
}
