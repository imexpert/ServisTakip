﻿using ServisTakip.Core.DataAccess;
using ServisTakip.Entities.Concrete;

namespace ServisTakip.DataAccess.Abstract
{
    public interface IAddressRepository : IEntityRepository<Address>
    {
        Task<Address> GetAddressInfo(long addressId);
        Task<List<Address>> GetAddressInfoByCustomerId(long customerId, CancellationToken cancellationToken);
    }
}
