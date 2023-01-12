using MediatR;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.Entities.DTOs.Customers;

namespace ServisTakip.Business.Handlers.Customers.Queries
{
    public class GetLastTradedCustomerQuery : IRequest<ResponseMessage<LastTradedCustomerInfoDto>>
    {
        public class GetLastTradedCustomerQueryHandler : IRequestHandler<GetLastTradedCustomerQuery, ResponseMessage<LastTradedCustomerInfoDto>>
        {
            public Task<ResponseMessage<LastTradedCustomerInfoDto>> Handle(GetLastTradedCustomerQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
