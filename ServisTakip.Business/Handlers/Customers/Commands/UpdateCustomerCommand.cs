using ServisTakip.Business.Handlers.UserProcesses.Commands;
using ServisTakip.Entities.DTOs.Customers;
using ServisTakip.Entities.DTOs.UserProcesses;

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
