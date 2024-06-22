USE [MJEM]
GO

INSERT INTO [dbo].[LocationMst]
           ([ParentLocationId]
           ,[LocationName]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[IsDeleted])
     VALUES(null,'A',1,GETDATE(),0),
		   (null,'B',1,GETDATE(),0),
		   (null,'C',1,GETDATE(),0),
		   (null,'D',1,GETDATE(),0),
		   (null,'E',1,GETDATE(),0),
		   (null,'F',1,GETDATE(),0)
GO




update LocationMst set ParentLocationId=8

