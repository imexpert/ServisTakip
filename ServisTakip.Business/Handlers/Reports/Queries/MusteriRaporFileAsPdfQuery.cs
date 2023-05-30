using ServisTakip.Entities.DTOs.Reports;
using FastReport.Data;
using FastReport.Utils;
using FastReport;
using FastReport.Export.Pdf;

namespace ServisTakip.Business.Handlers.Reports.Queries
{
    public class MusteriRaporFileAsPdfQuery : IRequest<ResponseMessage<ReportModel>>
    {
        public MusteriRaporFilter Model { get; set; }
        public class MusteriRaporFileQueryHandler : IRequestHandler<MusteriRaporFileAsPdfQuery, ResponseMessage<ReportModel>>
        {
            public async Task<ResponseMessage<ReportModel>> Handle(MusteriRaporFileAsPdfQuery request, CancellationToken cancellationToken)
            {
                var data =  await Tools.CustomerRepository.GetCustomerReportFileWithoutPaging(request.Model, cancellationToken);

                RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));


                Report report = Report.FromFile($"ReportFiles/MusteriRaporu.frx");
                report.Dictionary.Clear();
                
                report.Dictionary.Report.RegisterData(data.ToDataSet("VW_MusteriRaporu"), "VW_MusteriRaporu", true);


                DataBand band = report.FindObject("Data1") as DataBand;
                band.DataSource = report.GetDataSource("VW_MusteriRaporu");

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
