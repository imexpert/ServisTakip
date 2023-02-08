using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Extensions;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.Customers;

namespace ServisTakip.Business.Handlers.Customers.Queries
{
    public class GetCustomerByFilterQuery : IRequest<ResponseMessage<List<SearchCustomerDto>>>
    {
        public string Filter { get; set; }
        public class GetCustomerByFilterQueryHandler : IRequestHandler<GetCustomerByFilterQuery, ResponseMessage<List<SearchCustomerDto>>>
        {
            public async Task<ResponseMessage<List<SearchCustomerDto>>> Handle(GetCustomerByFilterQuery request, CancellationToken cancellationToken)
            {
                var customerRepo = ServiceTool.ServiceProvider.GetService<ICustomerRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                List<SearchCustomerDto> result = new List<SearchCustomerDto>();

                var customerList = await customerRepo.GetCustomerByFilterAsync(request.Filter, cancellationToken);
                foreach ( var customer in customerList ) 
                {
                    SearchCustomerDto cst = new SearchCustomerDto();
                    cst.Title = customer.Title;
                    cst.Id = customer.Id;
                    cst.Sector = customer.Sector.Name;
                    result.Add(cst);
                }

                return ResponseMessage<List<SearchCustomerDto>>.Success(result);
            }
        }
    }
}
