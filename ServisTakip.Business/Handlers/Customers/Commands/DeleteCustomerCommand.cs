using ServisTakip.Entities.DTOs.Customers;

namespace ServisTakip.Business.Handlers.Customers.Commands
{
    public class DeleteCustomerCommand : IRequest<ResponseMessage<CustomerDto>>
    {
        public long Id { get; set; }
        public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, ResponseMessage<CustomerDto>>
        {
            public async Task<ResponseMessage<CustomerDto>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
            {
                var customer = await Tools.CustomerRepository.GetAsync(s => s.Id == request.Id && s.CompanyId == Utils.CompanyId);
                Tools.CustomerRepository.Delete(customer);
                await Tools.CustomerRepository.SaveChangesAsync();

                var resultCustomer = Tools.Mapper.Map<CustomerDto>(customer);

                return ResponseMessage<CustomerDto>.Success(resultCustomer);
            }
        }
    }
}
