﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.Contracts;
using ServisTakip.Entities.DTOs.Reports;

namespace ServisTakip.Business.Handlers.Reports.Queries
{
    public class SozlesmeBasimRaporQuery : IRequest<PagedResult<List<ContractDto>>>
    {
        public SozlesmeBasimRaporFilter Model { get; set; }
        public class SozlesmeBasimRaporQueryHandler : IRequestHandler<SozlesmeBasimRaporQuery, PagedResult<List<ContractDto>>>
        {
            public async Task<PagedResult<List<ContractDto>>> Handle(SozlesmeBasimRaporQuery request, CancellationToken cancellationToken)
            {
                var pagedResult = new PagedResult<List<ContractDto>>();

                var contractRepo = ServiceTool.ServiceProvider.GetService<IContractRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var contractQuery = contractRepo.GetSozlesmeBasimQuery(request.Model);

                if (request.Model.CustomerId.HasValue)
                    contractQuery = contractQuery.Where(s => s.Device.Address.CustomerId == request.Model.CustomerId);

                if (request.Model.SehirId.HasValue)
                    contractQuery = contractQuery.Where(s => s.Device.Address.Querter.District.CityId == request.Model.SehirId);

                if (request.Model.IlceId.HasValue)
                    contractQuery = contractQuery.Where(s => s.Device.Address.Querter.DistrictId == request.Model.IlceId);

                if (request.Model.SemtId.HasValue)
                    contractQuery = contractQuery.Where(s => s.Device.Address.QuarterId == request.Model.SemtId);

                if (request.Model.Model.HasValue)
                    contractQuery = contractQuery.Where(s => s.Device.DeviceModelId == request.Model.Model);

                if (!string.IsNullOrEmpty(request.Model.SerialNo))
                    contractQuery = contractQuery.Where(s =>
                        EF.Functions.Like(s.Device.SerialNumber, $"%{request.Model.SerialNo}%"));

                if(request.Model.BaslangicTarihi.HasValue && request.Model.BaslangicTarihi > DateTime.MinValue)
                    contractQuery = contractQuery.Where(s => s.StartDate >= request.Model.BaslangicTarihi);

                if (request.Model.BitisTarihi.HasValue && request.Model.BitisTarihi > DateTime.MinValue)
                    contractQuery = contractQuery.Where(s => s.EndDate <= request.Model.BitisTarihi);

                if (request.Model.SozlesmeKodlari.Any())
                    contractQuery = contractQuery.Where(s => request.Model.SozlesmeKodlari.Contains(s.ContractCode));

                pagedResult.PageCount = await contractQuery.CountAsync(cancellationToken: cancellationToken);

                contractQuery = contractQuery
                    .Skip((request.Model.CurrentPage - 1) * request.Model.PageSize)
                    .Take(request.Model.PageSize);

                var contracts = await contractQuery
                    .ToListAsync(cancellationToken);

                pagedResult.Data =  mapper.Map<List<ContractDto>>(contracts);
                pagedResult.PageSize = request.Model.PageSize;
                pagedResult.CurrentPage = request.Model.CurrentPage;
                pagedResult.IsSuccess = true;
                return pagedResult;
            }
        }
    }
}
