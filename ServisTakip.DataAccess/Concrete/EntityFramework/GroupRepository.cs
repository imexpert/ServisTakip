using ServisTakip.DataAccess.Abstract;
using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServisTakip.Core.DataAccess.EntityFramework;
using ServisTakip.Core.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.EntityFramework
{
    public class GroupRepository : EntityRepositoryBase<Group, ProjectDbContext>, IGroupRepository
    {
        public GroupRepository(ProjectDbContext context)
            : base(context)
        {
        }
    }
}
