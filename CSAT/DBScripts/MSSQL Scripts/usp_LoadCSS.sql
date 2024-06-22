USE [CSAT]
GO
/****** Object:  StoredProcedure [dbo].[usp_LoadCSS]
    Script Date: 15-05-2019 3:27:22
	Exec usp_LoadCSS 0,'30c4fc'
	 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Procedure [dbo].[usp_LoadCSS](
@Id int,
@ShortKey varchar(100)= null
)
AS BEGIN

SELECT UserAreaID,Code,Name,FacilityID 
  FROM UserArea 
WHERE RecordStatus = 'A';

SELECT FacilityID,Code,Name 
  FROM Facility 
WHERE RecordStatus = 'A';

	IF (@Id=1)
	BEGIN
		SELECT ComplaintCategoryID,CategoryName 
		  FROM ComplaintCategory 
		WHERE  RecordStatus = 'A';
	END 
	IF (@ShortKey is not null)
	BEGIN 
		SELECT FacilityID,UserAreaID 
		  FROM UserArea 
		WHERE  ShorterURL = @ShortKey and RecordStatus = 'A';
	END 
End

