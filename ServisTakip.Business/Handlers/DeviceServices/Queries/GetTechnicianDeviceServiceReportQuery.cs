using FastReport;
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
    public class GetTechnicianDeviceServiceReportQuery : IRequest<ResponseMessage<ReportModel>>
    {
        public long UserId { get; set; }
        public class GetTechnicianDeviceServiceReportQueryHandler : IRequestHandler<GetTechnicianDeviceServiceReportQuery, ResponseMessage<ReportModel>>
        {
            public async Task<ResponseMessage<ReportModel>> Handle(GetTechnicianDeviceServiceReportQuery request, CancellationToken cancellationToken)
            {
                var deviceServiceRepo = ServiceTool.ServiceProvider.GetService<IDeviceServiceRepository>();
                var deviceServices = await deviceServiceRepo.GetTechnicianDeviceServiceListAsync(request.UserId, cancellationToken);

                RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));


                Report report = Report.FromFile("ReportFiles/TeknisyenRaporu.frx");
                report.Dictionary.Clear();

                report.Dictionary.Report.RegisterData(deviceServices.ToDataSet("VW_TechnicianReport"), "VW_TechnicianReport", true);

                DataBand band = report.FindObject("Data1") as DataBand; 
                band.DataSource = report.GetDataSource("VW_TechnicianReport");

                Parameter paramTechnicianName = new Parameter("TechnicianName");
                paramTechnicianName.DataType = typeof(string);
                paramTechnicianName.Value = deviceServices.FirstOrDefault().TechnicianName;
                report.Parameters.Add(paramTechnicianName);

                report.Prepare();

                var export = new PDFExport();

                using MemoryStream ms = new MemoryStream();
                report.Export(export, ms);

                ReportModel rpr = new ReportModel()
                {
                    Report = ms.ToArray()
                };

                return ResponseMessage<ReportModel>.Success(rpr);
            }
        }
    }
}
