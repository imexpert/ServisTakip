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
using ServisTakip.Entities.Concrete;
using System.IO;
using AutoMapper;
using ServisTakip.Entities.DTOs.DeviceServiceParts;

namespace ServisTakip.Business.Handlers.DeviceServices.Queries
{
    public class GetOrderReceiptReportQuery : IRequest<ResponseMessage<TechnicianDeviceServiceReport>>
    {
        public long DeviceServiceId { get; set; }
        public class GetOrderReceiptReportQueryHandler : IRequestHandler<GetOrderReceiptReportQuery, ResponseMessage<TechnicianDeviceServiceReport>>
        {
            public async Task<ResponseMessage<TechnicianDeviceServiceReport>> Handle(GetOrderReceiptReportQuery request, CancellationToken cancellationToken)
            {
                var deviceServiceRepo = ServiceTool.ServiceProvider.GetService<IDeviceServiceRepository>();
                var offerRepo = ServiceTool.ServiceProvider.GetService<IOfferRepository>();
                var userRepo = ServiceTool.ServiceProvider.GetService<IUserRepository>();
                var deviceServicePartRepo = ServiceTool.ServiceProvider.GetService<IDeviceServicePartRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var deviceService = await deviceServiceRepo.GetDeviceServiceWithId(request.DeviceServiceId, cancellationToken);

                var deviceServiceParts = await deviceServicePartRepo.GetListAsync(s => s.DeviceServiceId == request.DeviceServiceId);

                var offer = await offerRepo.GetOfferAsync(request.DeviceServiceId, cancellationToken);

                var user = await userRepo.GetAsync(s => s.Email == offer.UpdateUsername);

                var parts = mapper.Map<List<DeviceServicePartDto>>(deviceServiceParts);

                RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));


                Report report = Report.FromFile($"ReportFiles/OrderReceipts/{Utils.CompanyId}.frx");
                report.Dictionary.Clear();

                report.Dictionary.Report.RegisterData(parts.ToList().ToDataSet("DeviceServiceParts"), "DeviceServiceParts", true);

                report.Dictionary.Report.RegisterData(offer.ToDataSet("VW_Offer"), "VW_Offer", true);

                DataBand band = report.FindObject("Data1") as DataBand; 
                band.DataSource = report.GetDataSource("DeviceServiceParts");

                decimal devicePartsTotal = parts.Sum(s => s.TotalPrice);
                decimal discountTotal = offer.DiscountRate.HasValue
                    ? (devicePartsTotal / 100) * offer.DiscountRate.Value
                    : 0;
                decimal kdv = (devicePartsTotal - discountTotal) * Convert.ToDecimal(0.18);

                report.Parameters.Clear();

                Parameter paramUnvan = new Parameter("Unvan");
                paramUnvan.DataType = typeof(string);
                paramUnvan.Value = deviceService.Device.Address.Customer.Title;
                report.Parameters.Add(paramUnvan);

                Parameter paramCariKod = new Parameter("CariKod");
                paramCariKod.DataType = typeof(string);
                paramCariKod.Value = deviceService.Device.Address.AccountCode;
                report.Parameters.Add(paramCariKod);

                Parameter paramSiparisVeren = new Parameter("SiparisVeren");
                paramSiparisVeren.DataType = typeof(string);
                paramSiparisVeren.Value = $"{user.Firstname} {user.Lastname}";
                report.Parameters.Add(paramSiparisVeren);

                Parameter paramKdv = new Parameter("Kdv");
                paramKdv.DataType = typeof(decimal);
                paramKdv.Value = kdv;
                report.Parameters.Add(paramKdv);

                Parameter paramTotalWithDiscount = new Parameter("TotalWithDiscount");
                paramTotalWithDiscount.DataType = typeof(decimal);
                paramTotalWithDiscount.Value = "0";
                report.Parameters.Add(paramTotalWithDiscount);

                Parameter paramDiscountTotal = new Parameter("DiscountTotal");
                paramDiscountTotal.DataType = typeof(decimal);
                paramDiscountTotal.Value = discountTotal;
                report.Parameters.Add(paramDiscountTotal);

                Parameter paramTotalPrice = new Parameter("TotalPrice");
                paramTotalPrice.DataType = typeof(decimal);
                paramTotalPrice.Value = kdv + (devicePartsTotal - discountTotal);
                report.Parameters.Add(paramTotalPrice);

                Parameter paramDevicePartsTotal = new Parameter("DevicePartsTotal");
                paramDevicePartsTotal.DataType = typeof(decimal);
                paramDevicePartsTotal.Value = parts.Sum(s => s.TotalPrice);
                report.Parameters.Add(paramDevicePartsTotal);

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
