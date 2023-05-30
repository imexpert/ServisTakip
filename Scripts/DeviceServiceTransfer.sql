SET IDENTITY_INSERT ServisTakip.dbo.DeviceServices ON 
GO
insert into ServisTakip.dbo.DeviceServices(
	[Id]
    ,[LinkedDeviceServiceId]
    ,[DeviceId]
    ,[UserId]
    ,[UserAssignDate]
    ,[Name]
    ,[Phone]
    ,[FailureDate]
    ,[ResultDate]
    ,[ServiceBootCode]
    ,[BootDescription]
    ,[DetectionCode]
    ,[DetectionDescription]
    ,[ServiceResultCode]
    ,[CancelDescription]
    ,[ResultDescription]
    ,[WBCount]
    ,[ColorCount]
    ,[Dr]
    ,[Dv]
    ,[Bc]
    ,[Fs]
    ,[Pa]
    ,[Bk]
    ,[Ak]
    ,[TonerType]
    ,[BlackCount]
    ,[BlueCount]
    ,[RedCount]
    ,[YellowCount]
    ,[StatusCode]
    ,[RecordUsername]
    ,[RecordDate]
    ,[UpdateUsername]
    ,[UpdateDate]
    ,[Ip])

SELECT [ID]
      ,NULL
	  ,CIHAZID
	  ,1
	  ,TEKNISYENVERILISZAMAN
	  ,ARIZABILDIRENISIM
	  ,ARIZABILDIRENTELEFON
	  ,ARIZATARIHI
	  ,RECORDDATE
	  ,SERVISKODU
	  ,ACIKLAMA
	  ,TESPITKODU
	  ,TESPITACIKLAMA
	  ,SERVISSONUCKODU
	  ,KAPANISACIKLAMA
	  ,IPTALNEDENACIKLAMA
	  ,SBSAYAC
	  ,RENKLISAYAC
	  ,DR
	  ,DV
	  ,BC
	  ,FS
	  ,PA
	  ,BK
	  ,AK
	  ,TONERTIPI
	  ,SIYAHADEDI
	  ,MAVIADEDI
	  ,KIRMIZIADEDI
	  ,SARIADEDI
	  ,[DURUMKODU]
      ,'aosmanunal@gmail.com'
      ,[RECORDDATE]
      ,'aosmanunal@gmail.com'
      ,[RECORDDATE]
	  ,'1.1.1.1'
  FROM [AvrupaOfis].[dbo].[SERVIS] s
  WHERE 
	s.CIHAZID IS NOT NULL AND 
	EXISTS (SELECT * FROM ServisTakip.dbo.Devices d where d.Id = s.CIHAZID) 

  SET IDENTITY_INSERT ServisTakip.dbo.DeviceServices OFF 