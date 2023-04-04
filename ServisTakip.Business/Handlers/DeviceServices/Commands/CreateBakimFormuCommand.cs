using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Aspects.Autofac.Transaction;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.Concrete;
using ServisTakip.Entities.DTOs.DeviceServices;
using ServisTakip.Entities.Enums;

namespace ServisTakip.Business.Handlers.DeviceServices.Commands
{
    public class CreateBakimFormuCommand : IRequest<ResponseMessage<CreateBakimFormuDto>>
    {
        public CreateBakimFormuDto Model { get; set; }
        public class CreateBakimFormuCommandHandler : IRequestHandler<CreateBakimFormuCommand, ResponseMessage<CreateBakimFormuDto>>
        {
            [TransactionScopeAspectAsync]
            public async Task<ResponseMessage<CreateBakimFormuDto>> Handle(CreateBakimFormuCommand request, CancellationToken cancellationToken)
            {
                var deviceServiceRepo = ServiceTool.ServiceProvider.GetService<IDeviceServiceRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var bakimFormu = mapper.Map<DeviceService>(request.Model);
                bakimFormu.StatusCode = (int)StatusCodes.TalepSonlandirildi;

                deviceServiceRepo.Add(bakimFormu);
                await deviceServiceRepo.SaveChangesAsync();

                return ResponseMessage<CreateBakimFormuDto>.Success(request.Model);
            }
        }
    }
}
