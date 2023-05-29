using ServisTakip.Entities.DTOs.UserProcesses;

namespace ServisTakip.Business.Handlers.UserProcesses.Commands
{
    public class UpdateUserProcessCommand : IRequest<ResponseMessage<NoContent>>
    {
        public UpdateUserProcessDto Model { get; set; }
        public class UpdateUserProcessCommandHandler : IRequestHandler<UpdateUserProcessCommand, ResponseMessage<NoContent>>
        {
            public async Task<ResponseMessage<NoContent>> Handle(UpdateUserProcessCommand request, CancellationToken cancellationToken)
            {
                var userProcess = await Tools.UserProcessRepository.GetAsync(s => s.UserId == Utils.UserId);
                if (userProcess != null)
                {
                    userProcess.CustomerId = request.Model.CustomerId;
                    userProcess.UserId = Utils.UserId;
                    userProcess.DeviceId = request.Model.DeviceId;
                    userProcess.DeviceServiceId = request.Model.DeviceServiceId;
                    Tools.UserProcessRepository.Update(userProcess);
                    await Tools.UserProcessRepository.SaveChangesAsync();
                }

                return ResponseMessage<NoContent>.Success();
            }
        }
    }
}
