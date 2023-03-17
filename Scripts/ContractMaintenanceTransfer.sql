SET IDENTITY_INSERT ServisTakip.dbo.ContractMaintenances ON 
GO
insert into ServisTakip.dbo.ContractMaintenances(
	Id,
	ContractId,
	DeviceServiceId,
	StartDate,
	EndDate,
	MaintenanceDate,
	RecordUsername,
	RecordDate,
	UpdateUsername,
	UpdateDate,
	Ip)

SELECT [ID]
      ,SOZLESMEID
	  ,SERVISID
	  ,BASLANGICTARIHI
	  ,BITISTARIHI
	  ,BAKIMTARIHI
      ,'aosmanunal@gmail.com'
      ,[RECORDDATE]
      ,'aosmanunal@gmail.com'
      ,[RECORDDATE]
	  ,'1.1.1.1'
  FROM [AvrupaOfis].[dbo].[SOZLESMEBAKIM] sb
  WHERE 
	sb.SOZLESMEID IS NOT NULL AND 
	EXISTS (SELECT * FROM ServisTakip.dbo.Contracts c where c.Id = sb.SOZLESMEID)  AND
	EXISTS (SELECT * FROM ServisTakip.dbo.DeviceServices ds where ds.Id = sb.SERVISID)

  SET IDENTITY_INSERT ServisTakip.dbo.ContractMaintenances OFF 