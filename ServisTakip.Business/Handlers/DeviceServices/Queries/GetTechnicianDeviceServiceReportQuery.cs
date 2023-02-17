using FastReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastReport.Data;
using MediatR;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.DataAccess.Abstract;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Extensions;
using FastReport.Export.Pdf;
using FastReport.Utils;
using ServisTakip.Entities.DTOs.Reports;

namespace ServisTakip.Business.Handlers.DeviceServices.Queries
{
    public class GetTechnicianDeviceServiceReportQuery : IRequest<ResponseMessage<TechnicianDeviceServiceReport>>
    {
        public long UserId { get; set; }
        public class GetTechnicianDeviceServiceReportQueryHandler : IRequestHandler<GetTechnicianDeviceServiceReportQuery, ResponseMessage<TechnicianDeviceServiceReport>>
        {
            public async Task<ResponseMessage<TechnicianDeviceServiceReport>> Handle(GetTechnicianDeviceServiceReportQuery request, CancellationToken cancellationToken)
            {
                var deviceServiceRepo = ServiceTool.ServiceProvider.GetService<IDeviceServiceRepository>();
                var deviceServices = await deviceServiceRepo.GetTechnicianDeviceServiceListAsync(request.UserId, cancellationToken);

                RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));


                Report report = Report.FromFile("ReportFiles/TeknisyenRaporu.frx");
                report.Dictionary.Clear();

                report.Dictionary.Report.RegisterData(deviceServices.ToDataSet("VW_TechnicianReport"), "VW_TechnicianReport", true);

                report.Prepare();

                var export = new PDFExport();

                using (MemoryStream ms = new MemoryStream())
                {
                    report.Export(export, ms);

                    byte[] rp = ms.ToArray();

                    string base64String = Convert.ToBase64String(rp, 0, rp.Length);

                    TechnicianDeviceServiceReport rpr = new TechnicianDeviceServiceReport()
                    {
                        Report = ms.ToArray()
                    };

                    return ResponseMessage<TechnicianDeviceServiceReport>.Success(rpr);
                }
            }
        }
    }
}
