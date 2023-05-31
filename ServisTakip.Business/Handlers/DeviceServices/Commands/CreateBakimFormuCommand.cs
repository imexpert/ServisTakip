using ServisTakip.Business.Handlers.UserProcesses.Commands;
using ServisTakip.Core.Aspects.Autofac.Transaction;
using ServisTakip.Entities.Concrete;
using ServisTakip.Entities.DTOs.DeviceServices;
using ServisTakip.Entities.DTOs.UserProcesses;

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
                var bakimFormu = Tools.Mapper.Map<DeviceService>(request.Model);
                bakimFormu.StatusCode = (int)StatusCodes.TalepSonlandirildi;

                bakimFormu.ResultDate = bakimFormu.FailureDate;
                bakimFormu.UserAssignDate = bakimFormu.FailureDate;

                Tools.DeviceServiceRepository.Add(bakimFormu);
                await Tools.DeviceServiceRepository.SaveChangesAsync();

                #region Kullanıcı İşlem Bilgisi Ekleme
                UpdateUserProcessDto userProcess = new UpdateUserProcessDto()
                {
                    DeviceId = bakimFormu.DeviceId
                };
                await Tools.Mediator.Send(new UpdateUserProcessCommand() { Model = userProcess }, cancellationToken);
                #endregion

                return ResponseMessage<CreateBakimFormuDto>.Success(request.Model);
            }
        }
    }
}
