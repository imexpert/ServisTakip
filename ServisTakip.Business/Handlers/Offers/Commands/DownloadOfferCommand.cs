using MediatR;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.Entities.DTOs.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisTakip.Business.Handlers.Offers.Commands
{
    public class DownloadOfferCommand  : IRequest<ResponseMessage<OfferReport>>
    {
        public class DownloadOfferCommandHandler : IRequestHandler<DownloadOfferCommand, ResponseMessage<OfferReport>>
        {
            public Task<ResponseMessage<OfferReport>> Handle(DownloadOfferCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
