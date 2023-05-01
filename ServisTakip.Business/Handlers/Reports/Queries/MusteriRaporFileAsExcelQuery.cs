using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.Concrete;
using ServisTakip.Entities.DTOs.Customers;
using ServisTakip.Entities.DTOs.Reports;
using ServisTakip.Core.Extensions;
using Z.EntityFramework.Plus;
using FastReport.Data;
using FastReport.Utils;
using FastReport;
using System.IO;
using FastReport.Export.OoXML;
using FastReport.Export.Pdf;

namespace ServisTakip.Business.Handlers.Reports.Queries
{
    public class MusteriRaporFileAsExcelQuery : IRequest<ResponseMessage<ReportModel>>
    {
        public MusteriRaporFilter Model { get; set; }
        public class MusteriRaporFileQueryHandler : IRequestHandler<MusteriRaporFileAsExcelQuery, ResponseMessage<ReportModel>>
        {
            public async Task<ResponseMessage<ReportModel>> Handle(MusteriRaporFileAsExcelQuery request, CancellationToken cancellationToken)
            {
                var contractRepo = ServiceTool.ServiceProvider.GetService<ICustomerRepository>();
                var data =  await contractRepo.GetCustomerReportFileWithoutPaging(request.Model, cancellationToken);

                RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));


                Report report = Report.FromFile($"ReportFiles/MusteriRaporu.frx");
                report.Dictionary.Clear();
                
                report.Dictionary.Report.RegisterData(data.ToDataSet("VW_MusteriRaporu"), "VW_MusteriRaporu", true);


                DataBand band = report.FindObject("Data1") as DataBand;
                band.DataSource = report.GetDataSource("VW_MusteriRaporu");

                report.Prepare();

                var export = new Excel2007Export();

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
