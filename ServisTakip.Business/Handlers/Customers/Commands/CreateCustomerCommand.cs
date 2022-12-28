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
    public class CreateCustomerCommand : IRequest<ResponseMessage<CreateCustomerDto>>
    {
        public CreateCustomerDto Model { get; set; }
        public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, ResponseMessage<CreateCustomerDto>>
        {
            public async Task<ResponseMessage<CreateCustomerDto>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
            {
                var customerRepo = ServiceTool.ServiceProvider.GetService<ICustomerRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var customer = mapper.Map<Customer>(request.Model);
                customer.Status = true;
                customer.CompanyId = Utils.CompanyId;

                customerRepo.Add(customer);
                await customerRepo.SaveChangesAsync();
                return ResponseMessage<CreateCustomerDto>.Success();
            }
        }
    }
}
