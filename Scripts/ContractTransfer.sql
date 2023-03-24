SET IDENTITY_INSERT ServisTakip.dbo.Contracts ON 
GO
insert into ServisTakip.dbo.Contracts(
	Id,
	DeviceId,
	StartDate,
	EndDate,
	ContractCode,
	MaintenancePeriod,
	Price,
	CurrencyType,
	Status,
	RecordUsername,
	RecordDate,
	UpdateUsername,
	UpdateDate,
	Ip)

SELECT [ID]
      ,CIHAZID
	  ,BASLANGICTARIH
	  ,BITISTARIH
	  ,SOZLESMEKODU
	  ,BAKIMPERIYODKODU
	  ,FIYAT
	  ,PARABIRIMKODU
	  ,1
      ,'aosmanunal@gmail.com'
      ,[RECORDDATE]
      ,'aosmanunal@gmail.com'
      ,[RECORDDATE]
	  ,'1.1.1.1'
  FROM [AvrupaOfis].[dbo].[SOZLESME] s
  WHERE 
	s.CIHAZID IS NOT NULL AND 
	EXISTS (SELECT * FROM ServisTakip.dbo.Devices d where d.Id = s.CIHAZID) 
	AND s.BAKIMPERIYODKODU <> 'PH'

  SET IDENTITY_INSERT ServisTakip.dbo.Contracts OFF 