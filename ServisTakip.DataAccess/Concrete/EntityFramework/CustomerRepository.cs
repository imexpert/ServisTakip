﻿using Microsoft.EntityFrameworkCore;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.DataAccess.Concrete.EntityFramework.Contexts;
using ServisTakip.Core.DataAccess.EntityFramework;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Concrete.EntityFramework
{
    public class CustomerRepository : EntityRepositoryBase<Customer, ProjectDbContext>, ICustomerRepository
    {
        private readonly ProjectDbContext _context;
        public CustomerRepository(ProjectDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<Customer> GetCustomerById(long id)
        {
            return await _context.Customers
                .Include(s => s.Addresses).ThenInclude(s=>s.Devices).ThenInclude(s=>s.DeviceModel).ThenInclude(s=>s.DeviceBrand).ThenInclude(s=>s.DeviceType)
                .Include(s => s.Addresses).ThenInclude(s=>s.Querter).ThenInclude(s=>s.District).ThenInclude(s=>s.City)
                .Include(s => s.Sector)
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Customer>> GetCustomerByFilterAsync(string filter, CancellationToken cancellationToken)
        {
            return await _context.Customers
                .Include(s => s.Addresses).ThenInclude(s => s.Devices).ThenInclude(s => s.DeviceModel).ThenInclude(s => s.DeviceBrand).ThenInclude(s => s.DeviceType)
                .Include(s => s.Addresses).ThenInclude(s => s.Querter).ThenInclude(s => s.District).ThenInclude(s => s.City)
                .Include(s => s.Sector)
                .Where(s => EF.Functions.Like(s.Title, $"%{filter}%"))
                .ToListAsync();
        }
    }
}
