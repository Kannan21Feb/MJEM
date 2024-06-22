USE [MJEM]
GO

INSERT INTO [dbo].[MJEMSysLov]
           ([ScreenName]
           ,[FieldName]
           ,[LovKey]
           ,[FieldCode]
           ,[FieldValue]
           ,[Remarks]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[IsDeleted])
     VALUES
           ('JobSheetTxn','DieselFrom','DiselProviderType'
           ,1
           ,'Own'
           ,''
           ,1
           ,GETDATE()
           ,0),
		    ('JobSheetTxn'
           ,'DieselFrom'
           ,'DiselProviderType'
           ,2
           ,'Customer'
           ,''
           ,1
           ,GETDATE()
           ,0)
GO


