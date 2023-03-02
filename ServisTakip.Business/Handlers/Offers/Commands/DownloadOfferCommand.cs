using FastReport.Data;
using FastReport.Export.Pdf;
using FastReport.Utils;
using FastReport;
using MediatR;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.Entities.Concrete;
using ServisTakip.Entities.DTOs.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Core;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Extensions;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.DeviceServiceParts;
using Parameter = FastReport.Data.Parameter;
using RichObject = FastReport.RichTextParser.RichObject;

namespace ServisTakip.Business.Handlers.Offers.Commands
{
    public class DownloadOfferCommand  : IRequest<ResponseMessage<OfferReport>>
    {
        public long DeviceServiceId { get; set; }
        public class DownloadOfferCommandHandler : IRequestHandler<DownloadOfferCommand, ResponseMessage<OfferReport>>
        {
            public async Task<ResponseMessage<OfferReport>> Handle(DownloadOfferCommand request, CancellationToken cancellationToken)
            {
                var offerRepo = ServiceTool.ServiceProvider.GetService<IOfferRepository>();
                var deviceServicePartRepo = ServiceTool.ServiceProvider.GetService<IDeviceServicePartRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var deviceServiceParts =
                    await deviceServicePartRepo.GetListAsync(s => s.DeviceServiceId == request.DeviceServiceId);

                var parts = mapper.Map<List<DeviceServicePartDto>>(deviceServiceParts);

                var offer = await offerRepo.GetOfferAsync(request.DeviceServiceId, cancellationToken);

                RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));
                Report report = Report.FromFile($"ReportFiles/OfferReports/{Utils.CompanyId}.frx");
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

                OfferReport rpr = new OfferReport()
                {
                    Report = ms.ToArray()
                };

                return ResponseMessage<OfferReport>.Success(rpr);
            }
        }
    }
}
