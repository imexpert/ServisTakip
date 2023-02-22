﻿using ServisTakip.DataAccess.Abstract;
using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using ServisTakip.Core.DataAccess.EntityFramework;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.EntityFramework
{
    public class DeviceServicePartRepository : EntityRepositoryBase<DeviceServicePart, ProjectDbContext>, IDeviceServicePartRepository
    {
        public DeviceServicePartRepository(ProjectDbContext context)
            : base(context)
        {
        }
    }
}