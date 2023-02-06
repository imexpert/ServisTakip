﻿using ServisTakip.DataAccess.Abstract;
using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using ServisTakip.Core.DataAccess.EntityFramework;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.EntityFramework
{
    public class ContractCodeRepository : EntityRepositoryBase<ContractCode, ProjectDbContext>, IContractCodeRepository
    {
        public ContractCodeRepository(ProjectDbContext context)
            : base(context)
        {
        }
    }
}