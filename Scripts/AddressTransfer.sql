SET IDENTITY_INSERT ServisTakip.dbo.Addresses ON 
GO
insert into ServisTakip.dbo.Addresses(
	Id,
	CustomerId,
	QuarterId,
	AddressTitle,
	AccountCode,
	NetAddress,
	AuthorizedName,
	AuthorizedTask,
	AuthorizedPhone,
	AuthorizedEmail,
	Department,
	Description,
	Status,
	RecordUsername,
	RecordDate,
	UpdateUsername,
	UpdateDate,
	Ip)

SELECT [ID]
      ,MUSTERIID
	  ,SEMTID
	  ,ACIKADRES
	  ,CARIKODU
	  ,ACIKADRES
	  ,YETKILIADSOYAD
	  ,YETKILIGOREVKODU
	  ,YETKILICEPTEL
	  ,YETKILIMAIL
	  ,DETAY
	  ,NULL
	  ,1
      ,'aosmanunal@gmail.com'
      ,[RECORDDATE]
      ,'aosmanunal@gmail.com'
      ,[RECORDDATE]
	  ,'1.1.1.1'
  FROM [AvrupaOfis].[dbo].[ADRES] A 
  WHERE 
	A.SEMTID IS NOT NULL AND 
	EXISTS (SELECT * FROM ServisTakip.Const.Querters q where q.Id = A.SEMTID) AND
	EXISTS (SELECT * FROM ServisTakip.dbo.Customers c where c.Id = A.MUSTERIID)

  SET IDENTITY_INSERT ServisTakip.dbo.Addresses OFF 