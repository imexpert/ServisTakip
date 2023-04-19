using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Extensions;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
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
                var customerRepo = ServiceTool.ServiceProvider.GetService<ICustomerRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var customer = await customerRepo.GetAsync(s => s.Id == request.Id && s.CompanyId == Utils.CompanyId);
                customerRepo.Delete(customer);
                await customerRepo.SaveChangesAsync();

                var resultCustomer = mapper.Map<CustomerDto>(customer);

                return ResponseMessage<CustomerDto>.Success(resultCustomer);
            }
        }
    }
}
