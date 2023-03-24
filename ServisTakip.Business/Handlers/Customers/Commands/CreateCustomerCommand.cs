using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Extensions;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.Concrete;
using ServisTakip.Entities.DTOs.Customers;

namespace ServisTakip.Business.Handlers.Customers.Commands
{
    public class CreateCustomerCommand : IRequest<ResponseMessage<CustomerDto>>
    {
        public CreateCustomerDto Model { get; set; }
        public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, ResponseMessage<CustomerDto>>
        {
            public async Task<ResponseMessage<CustomerDto>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
            {
                var customerRepo = ServiceTool.ServiceProvider.GetService<ICustomerRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var customer = mapper.Map<Customer>(request.Model);
                customer.CompanyId = Utils.CompanyId;

                customerRepo.Add(customer);
                await customerRepo.SaveChangesAsync();

                var resultCustomer = mapper.Map<CustomerDto>(customer);

                return ResponseMessage<CustomerDto>.Success(resultCustomer);
            }
        }
    }
}
