﻿using FastReport;
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

                DataBand band = report.FindObject("Data1") as DataBand; 
                band.DataSource = report.GetDataSource("VW_TechnicianReport");

                report.Prepare();

                var export = new PDFExport();

                using MemoryStream ms = new MemoryStream();
                report.Export(export, ms);

                TechnicianDeviceServiceReport rpr = new TechnicianDeviceServiceReport()
                {
                    Report = ms.ToArray()
                };

                return ResponseMessage<TechnicianDeviceServiceReport>.Success(rpr);
            }
        }
    }
}
