using ServisTakip.Entities.DTOs.Customers;

namespace ServisTakip.Business.Handlers.Customers.Commands
{
    public class UpdateCustomerCommand : IRequest<ResponseMessage<CustomerDto>>
    {
        public UpdateCustomerDto Model { get; set; }
        public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, ResponseMessage<CustomerDto>>
        {
            public async Task<ResponseMessage<CustomerDto>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
            {
                var customer = Tools.Mapper.Map<Customer>(request.Model);
                Tools.CustomerRepository.Update(customer);
                await Tools.CustomerRepository.SaveChangesAsync();

                var resultCustomer = Tools.Mapper.Map<CustomerDto>(customer);

                return ResponseMessage<CustomerDto>.Success(resultCustomer);
            }
        }
    }
}
