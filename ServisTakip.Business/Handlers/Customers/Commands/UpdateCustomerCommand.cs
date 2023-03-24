using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.Concrete;
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
                var customerRepo = ServiceTool.ServiceProvider.GetService<ICustomerRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var customer = mapper.Map<Customer>(request.Model);
                customerRepo.Update(customer);
                await customerRepo.SaveChangesAsync();

                var resultCustomer = mapper.Map<CustomerDto>(customer);

                return ResponseMessage<CustomerDto>.Success(resultCustomer);
            }
        }
    }
}
