﻿using Microsoft.EntityFrameworkCore;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using ServisTakip.Core.DataAccess.EntityFramework;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.EntityFramework
{
    public class AddressRepository : EntityRepositoryBase<Address, ProjectDbContext>, IAddressRepository
    {
        private readonly ProjectDbContext _context;
        public AddressRepository(ProjectDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<Address> GetAddressInfo(long addressId)
        {
            return await _context.Addresses
                .Include(s => s.Customer).ThenInclude(s=>s.Sector)
                .Include(s=>s.Querter).ThenInclude(s=>s.District).ThenInclude(s=>s.City)
                .Where(s => s.Id == addressId)
                .FirstOrDefaultAsync();
        }
    }
}
