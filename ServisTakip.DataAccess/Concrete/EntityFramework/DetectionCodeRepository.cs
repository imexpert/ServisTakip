﻿using ServisTakip.DataAccess.Abstract;
using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using ServisTakip.Core.DataAccess.EntityFramework;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.EntityFramework
{
    public class DetectionCodeRepository : EntityRepositoryBase<DetectionCode, ProjectDbContext>, IDetectionCodeRepository
    {
        public DetectionCodeRepository(ProjectDbContext context)
            : base(context)
        {
        }
    }
}