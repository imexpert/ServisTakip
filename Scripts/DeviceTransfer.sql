SET IDENTITY_INSERT ServisTakip.dbo.Devices ON 
GO
insert into ServisTakip.dbo.Devices(
	Id,
	AddressId,
	DeviceModelId,
	SerialNumber,
	AssemblyDate,
	Description,
	Status,
	RecordUsername,
	RecordDate,
	UpdateUsername,
	UpdateDate,
	Ip)

SELECT [ID]
      ,ADRESID
	  ,MODELID
	  ,SERINO
	  ,MONTAJTARIHI
	  ,ACIKLAMA
	  ,1
      ,'aosmanunal@gmail.com'
      ,[RECORDDATE]
      ,'aosmanunal@gmail.com'
      ,[RECORDDATE]
	  ,'1.1.1.1'
  FROM [AvrupaOfis].[dbo].[CIHAZ] c 
  WHERE 
	C.MODELID IS NOT NULL AND 
	EXISTS (SELECT * FROM ServisTakip.dbo.DeviceModels m where m.Id = c.MODELID) AND
	EXISTS (SELECT * FROM ServisTakip.dbo.Addresses a where a.Id = c.ADRESID) AND
	c.MONTAJTARIHI is not null

  SET IDENTITY_INSERT ServisTakip.dbo.Devices OFF 