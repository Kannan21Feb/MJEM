

--[USP_JobTxnExport]15




DROP Proc [dbo].[USP_JobTxnExport]
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create Proc [USP_JobTxnExport] 
(@id int)
as 
Begin

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

Begin Try

Begin 

Declare  @TempTable table(--[S.No] int identity(1,1),
[Date] varchar(10),Rate varchar(20),[Running Hrs] varchar(20),[Rate * Running Hrs] varchar(20),Advance varchar(20),[Total Bill] varchar(20))

select  CONVERT(nvarchar(10), GETDATE(),103) [Billing Date],b.CustomerName ,b.MobileNumber,b.CustomerAddress,(d.LocationName +' - '+c.LocationName )[Site],'-' [-] from JobSheetTxn a inner join CustomersMst b
on a.CustomerId=b.CustomerId
inner join LocationMst c 
on c.LocationId=a.LocationId
inner join LocationMst d
on d.LocationId=c.ParentLocationId
where a.isdeleted=0 and c.isdeleted=0 and b.isdeleted=0 and d.isdeleted=0 and a.JobSheetTxnId=@id
insert into @TempTable 

select 
CONVERT(nvarchar(10), DateTime ,103)[Date],
convert(decimal(24,2) ,Rate),
convert(int,RunningHours),
convert(decimal(24,2) ,(Rate*RunningHours))[Bill (Rate X RunningHrs)] ,
convert(decimal(24,2) ,(Advance)) ,
convert(decimal(24,2) ,((Rate*RunningHours)-Advance))[Outstanding (Bill - Advance)] 

from JobSheetTxn a inner join 
JobSheetTxnDet b on a.JobSheetTxnId=b.JobSheetTxnId
where a.isdeleted=0 and b.IsDeleted=0 and a.JobSheetTxnId=@id
insert into @TempTable 
values ('','','','','','')
insert into @TempTable ([Date],Rate,[Running Hrs],[Rate * Running Hrs],Advance,[Total Bill])



(select 'Total','',
sum(RunningHours)TotalRunningHours,
sum(b.Rate*b.RunningHours)[Bill (Rate X RunningHours)] ,
sum(b.Advance)Advance,
sum((Rate*RunningHours)-b.Advance)[Outstanding (Bill - Advance)]


from JobSheetTxn a 
inner join JobSheetTxnDet b on a.JobSheetTxnId=b.JobSheetTxnId where a.isdeleted=0 and b.IsDeleted=0 and a.JobSheetTxnId=@id )
select * from @TempTable

End

End Try

Begin catch

End Catch
 
SET NOCOUNT OFF

end