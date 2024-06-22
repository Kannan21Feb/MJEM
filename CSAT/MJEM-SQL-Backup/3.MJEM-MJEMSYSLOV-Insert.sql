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
           ,[ModifiedBy]
           ,[ModifiedDate]
           ,[IsDeleted])
     VALUES
           ('VechileMst','VechileTypeBLV','VechileType',1,'JCB',null,1,GETDATE(),null,null,0),
		   ('VechileMst','VechileTypeBLV','VechileType',2,'Car',null,1,GETDATE(),null,null,0),
		   ('VechileMst','VechileTypeBLV','VechileType',3,'Bike',null,1,GETDATE(),null,null,0)
GO






