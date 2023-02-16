using FastReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastReport.Data;
using MediatR;
using ServisTakip.Core.Utilities.Results;
using FastReport.Utils;

namespace ServisTakip.Business.Handlers.DeviceServices.Queries
{
    public class GetTechnicianDeviceServiceReportQuery : IRequest<ResponseMessage<bool>>
    {
        public class GetTechnicianDeviceServiceReportQueryHandler : IRequestHandler<GetTechnicianDeviceServiceReportQuery, ResponseMessage<bool>>
        {
            public async Task<ResponseMessage<bool>> Handle(GetTechnicianDeviceServiceReportQuery request, CancellationToken cancellationToken)
            {
                RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));

                MsSqlDataConnection connection = new MsSqlDataConnection();
                Report report = Report.FromFile("ReportFiles/TeknisyenRaporu.frx");

                

                return ResponseMessage<bool>.Success();
            }
        }
    }
}
