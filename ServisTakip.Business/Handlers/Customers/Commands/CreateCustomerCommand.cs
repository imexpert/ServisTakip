using ServisTakip.Business.Handlers.UserProcesses.Commands;
using ServisTakip.Entities.Concrete;
using ServisTakip.Entities.DTOs.Customers;
using ServisTakip.Entities.DTOs.UserProcesses;

namespace ServisTakip.Business.Handlers.Customers.Commands
{
    public class CreateCustomerCommand : IRequest<ResponseMessage<CustomerDto>>
    {
        public CreateCustomerDto Model { get; set; }
        public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, ResponseMessage<CustomerDto>>
        {
            public async Task<ResponseMessage<CustomerDto>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
            {
                var customer = Tools.Mapper.Map<Customer>(request.Model);
                customer.CompanyId = Utils.CompanyId;

                Tools.CustomerRepository.Add(customer);
                await Tools.CustomerRepository.SaveChangesAsync();

                var resultCustomer = Tools.Mapper.Map<CustomerDto>(customer);

                #region Kullanıcı İşlem Bilgisi Ekleme
                UpdateUserProcessDto userProcess = new UpdateUserProcessDto()
                {
                    CustomerId = customer.Id
                };
                await Tools.Mediator.Send(new UpdateUserProcessCommand() { Model = userProcess }, cancellationToken);
                #endregion

                return ResponseMessage<CustomerDto>.Success(resultCustomer);
            }
        }
    }
}
