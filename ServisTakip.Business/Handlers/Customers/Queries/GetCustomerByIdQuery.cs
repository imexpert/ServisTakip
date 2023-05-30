using ServisTakip.Entities.DTOs.Customers;

namespace ServisTakip.Business.Handlers.Customers.Queries
{
    public class GetCustomerByIdQuery : IRequest<ResponseMessage<CustomerDto>>
    {
        public long CustomerId { get; set; }
        public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, ResponseMessage<CustomerDto>>
        {
            public async Task<ResponseMessage<CustomerDto>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
            {
                var customer = await Tools.CustomerRepository.GetCustomerById(request.CustomerId);
                var map = Tools.Mapper.Map<CustomerDto>(customer);
                return ResponseMessage<CustomerDto>.Success(map);
            }
        }
    }
}
