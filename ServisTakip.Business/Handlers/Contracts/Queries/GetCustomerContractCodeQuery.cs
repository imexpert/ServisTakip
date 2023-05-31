using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServisTakip.Entities.DTOs.Contracts;

namespace ServisTakip.Business.Handlers.Contracts.Queries
{
    public class GetCustomerContractCodeQuery : IRequest<CustomerContractCode>
    {
        public long DeviceId { get; set; }
        public class GetCustomerContractCodeQueryHandler : IRequestHandler<GetCustomerContractCodeQuery, CustomerContractCode>
        {
            public async Task<CustomerContractCode> Handle(GetCustomerContractCodeQuery request, CancellationToken cancellationToken)
            {
                CustomerContractCode result = new CustomerContractCode();

                var contracts = await Tools.ContractRepository.GetListAsync(s => s.DeviceId == request.DeviceId);

                var lastContract = contracts.MaxBy(s => s.EndDate);
                if (lastContract != null && lastContract.EndDate >= DateTime.Now)
                    result.ContractCode = lastContract?.ContractCode;
                else
                    result.ContractCode = "ÜCRETLİ";

                return result;
            }
        }
    }
}
