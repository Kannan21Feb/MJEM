use MJEM
/****** Object:  Table [dbo].[CustomersMst]    Script Date: 16-05-2020 23:49:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CustomersMst](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](200) NOT NULL,
	[MobileNumber] [varchar](10) NULL,
	[CustomerAddress] [nvarchar](1000) NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[Timestamp] [timestamp] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmplyoeeMst]    Script Date: 16-05-2020 23:49:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EmplyoeeMst](
	[EmplyoeeId] [int] NOT NULL  IDENTITY(1,1),
	[EmplyoeeName] [varchar](200) NULL,
	[MobileNumber] [varchar](200) NULL,
	[GovtId] [varchar](100) NULL,
	[Address] [varchar](1000) NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[Timestamp] [timestamp] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EmplyoeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[JobSheetTxn]    Script Date: 16-05-2020 23:49:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobSheetTxn](
	[JobSheetTxnId] [int] NOT NULL IDENTITY(1,1),
	[CustomerId] [int] NOT NULL,
	[LocationId] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[Timestamp] [timestamp] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[JobSheetTxnId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[JobSheetTxnDet]    Script Date: 16-05-2020 23:49:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobSheetTxnDet](
	[JobTxnSheetDetId] [int] NOT NULL IDENTITY(1,1),
	[JobSheetTxnId] [int] NOT NULL,
	[DateTime] [datetime] NULL,
	[VechileId] [int] NOT NULL,
	[RunningHours] [int] NULL,
	[DieselLtr] [numeric](24, 2) NULL,
	[DieselRate] [numeric](24, 2) NULL,
	[EmplyoeeId] [int] NOT NULL,
	[Advance] [numeric](24, 2) NULL,
	[Rate] [numeric](24, 2) NULL,
	[DriverBeta] [numeric](24, 2) NULL,
	[DieselFrom] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[Timestamp] [timestamp] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[JobTxnSheetDetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LocationMst]    Script Date: 16-05-2020 23:49:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LocationMst](
	[LocationId] [int] NOT NULL IDENTITY(1,1),
	[ParentLocationId] [int] NULL,
	[LocationName] [varchar](1000) NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[Timestamp] [timestamp] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[LocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MaintananceTxn]    Script Date: 16-05-2020 23:49:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaintananceTxn](
	[MaintananceTxnId] [int] NOT NULL IDENTITY(1,1),
	[MaintananceType] [int] NOT NULL,
	[ServiceType] [int] NOT NULL,
	[VechileId] [int] NOT NULL,
	[MaintanceCost] [numeric](24, 2) NULL,
	[MaintananceDate] [datetime] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[Timestamp] [timestamp] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaintananceTxnId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MJEMSysLov]    Script Date: 16-05-2020 23:49:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MJEMSysLov](
	[LovId] [int] NOT NULL IDENTITY(1,1),
	[ParentId] [int] NULL,
	[ScreenName] [varchar](1000) NULL,
	[FieldName] [varchar](1000) NULL,
	[LovKey] [varchar](1000) NULL,
	[FieldCode] [varchar](1000) NULL,
	[FieldValue] [varchar](1000) NULL,
	[Remarks] [varchar](1000) NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[Timestamp] [timestamp] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[LovId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[SparePartsMst]    Script Date: 16-05-2020 23:49:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SparePartsMst](
	[SparePartId] [int] NOT NULL IDENTITY(1,1),
	[AvilableQuantity] [int] NULL,
	[SpartPartType] [int] NULL,
	[SpartPartName] [varchar](1000) NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[Timestamp] [timestamp] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SparePartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[VechileMst]    Script Date: 16-05-2020 23:49:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VechileMst](
	[VechileId] [int] NOT NULL IDENTITY(1,1),
	[VehcileType] [int] NULL,
	[VechileNumber] [nvarchar](100) NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[Timestamp] [timestamp] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[VechileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

GO
ALTER TABLE [dbo].[CustomersMst] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[EmplyoeeMst] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[JobSheetTxn] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[JobSheetTxnDet] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[LocationMst] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[MaintananceTxn] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[MJEMSysLov] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[SparePartsMst] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[VechileMst] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[JobSheetTxn]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[CustomersMst] ([CustomerId])
GO
ALTER TABLE [dbo].[JobSheetTxn]  WITH CHECK ADD FOREIGN KEY([LocationId])
REFERENCES [dbo].[LocationMst] ([LocationId])
GO
ALTER TABLE [dbo].[JobSheetTxnDet]  WITH CHECK ADD FOREIGN KEY([DieselFrom])
REFERENCES [dbo].[MJEMSysLov] ([LovId])
GO
ALTER TABLE [dbo].[JobSheetTxnDet]  WITH CHECK ADD FOREIGN KEY([EmplyoeeId])
REFERENCES [dbo].[EmplyoeeMst] ([EmplyoeeId])
GO
ALTER TABLE [dbo].[JobSheetTxnDet]  WITH CHECK ADD FOREIGN KEY([JobSheetTxnId])
REFERENCES [dbo].[JobSheetTxn] ([JobSheetTxnId])
GO
ALTER TABLE [dbo].[JobSheetTxnDet]  WITH CHECK ADD FOREIGN KEY([VechileId])
REFERENCES [dbo].[VechileMst] ([VechileId])
GO
ALTER TABLE [dbo].[LocationMst]  WITH CHECK ADD FOREIGN KEY([ParentLocationId])
REFERENCES [dbo].[LocationMst] ([LocationId])
GO
ALTER TABLE [dbo].[MaintananceTxn]  WITH CHECK ADD FOREIGN KEY([MaintananceType])
REFERENCES [dbo].[MJEMSysLov] ([LovId])
GO
ALTER TABLE [dbo].[MaintananceTxn]  WITH CHECK ADD FOREIGN KEY([ServiceType])
REFERENCES [dbo].[MJEMSysLov] ([LovId])
GO
ALTER TABLE [dbo].[MaintananceTxn]  WITH CHECK ADD FOREIGN KEY([VechileId])
REFERENCES [dbo].[VechileMst] ([VechileId])
GO
ALTER TABLE [dbo].[MJEMSysLov]  WITH CHECK ADD FOREIGN KEY([ParentId])
REFERENCES [dbo].[MJEMSysLov] ([LovId])
GO
ALTER TABLE [dbo].[SparePartsMst]  WITH CHECK ADD FOREIGN KEY([SpartPartType])
REFERENCES [dbo].[MJEMSysLov] ([LovId])
GO
ALTER TABLE [dbo].[VechileMst]  WITH CHECK ADD FOREIGN KEY([VehcileType])
REFERENCES [dbo].[MJEMSysLov] ([LovId])
GO
USE [master]
GO
ALTER DATABASE [CSAT] SET  READ_WRITE 
GO
