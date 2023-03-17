SET IDENTITY_INSERT ServisTakip.dbo.Customers ON 
GO
insert into ServisTakip.dbo.Customers(Id,CompanyId,SectorId,Title,Status,RecordUsername,RecordDate,UpdateUsername,UpdateDate,Ip)

SELECT [ID]
      ,3
	  ,1
      ,[FIRMAUNVAN]
	  ,1
      ,'aosmanunal@gmail.com'
      ,[RECORDDATE]
      ,'aosmanunal@gmail.com'
      ,[RECORDDATE]
	  ,'1.1.1.1'
  FROM [AvrupaOfis].[dbo].[MUSTERI]

  SET IDENTITY_INSERT ServisTakip.dbo.Customers OFF 