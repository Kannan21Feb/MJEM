USE [master]
GO
/****** Object:  Database [MJEM]    Script Date: 22-05-2020 17:27:16 ******/
CREATE DATABASE [MJEM]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MJEM', FILENAME = N'E:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\MJEM.mdf' , SIZE = 6336KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MJEM_log', FILENAME = N'E:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\MJEM_log.ldf' , SIZE = 2880KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MJEM].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MJEM] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MJEM] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MJEM] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MJEM] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MJEM] SET ARITHABORT OFF 
GO
ALTER DATABASE [MJEM] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MJEM] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [MJEM] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MJEM] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MJEM] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MJEM] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MJEM] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MJEM] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MJEM] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MJEM] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MJEM] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MJEM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MJEM] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MJEM] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MJEM] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MJEM] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MJEM] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MJEM] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MJEM] SET RECOVERY FULL 
GO
ALTER DATABASE [MJEM] SET  MULTI_USER 
GO
ALTER DATABASE [MJEM] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MJEM] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MJEM] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MJEM] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [MJEM]
GO
/****** Object:  Table [dbo].[CustomersMst]    Script Date: 22-05-2020 17:27:16 ******/
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
/****** Object:  Table [dbo].[EmplyoeeMst]    Script Date: 22-05-2020 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EmplyoeeMst](
	[EmplyoeeId] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[JobSheetTxn]    Script Date: 22-05-2020 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobSheetTxn](
	[JobSheetTxnId] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[JobSheetTxnDet]    Script Date: 22-05-2020 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobSheetTxnDet](
	[JobTxnSheetDetId] [int] IDENTITY(1,1) NOT NULL,
	[JobSheetTxnId] [int] NOT NULL,
	[DateTime] [datetime] NULL,
	[VechileId] [int] NOT NULL,
	[RunningHours] [int] NULL,
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
	[DieselLtr] [numeric](24, 2) NULL,
	[DieselRate] [numeric](24, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[JobTxnSheetDetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LocationMst]    Script Date: 22-05-2020 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LocationMst](
	[LocationId] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[MaintananceTxn]    Script Date: 22-05-2020 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaintananceTxn](
	[MaintananceTxnId] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[MJEMSysLov]    Script Date: 22-05-2020 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MJEMSysLov](
	[LovId] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[SparePartsMst]    Script Date: 22-05-2020 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SparePartsMst](
	[SparePartId] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[VechileMst]    Script Date: 22-05-2020 17:27:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VechileMst](
	[VechileId] [int] IDENTITY(1,1) NOT NULL,
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
SET IDENTITY_INSERT [dbo].[CustomersMst] ON 

INSERT [dbo].[CustomersMst] ([CustomerId], [CustomerName], [MobileNumber], [CustomerAddress], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted]) VALUES (1, N'Customer1', N'9876543210', N'Address1', 1, CAST(0x0000ABBE0139A17F AS DateTime), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[CustomersMst] OFF
SET IDENTITY_INSERT [dbo].[EmplyoeeMst] ON 

INSERT [dbo].[EmplyoeeMst] ([EmplyoeeId], [EmplyoeeName], [MobileNumber], [GovtId], [Address], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted]) VALUES (1, N'Employee1', N'83630288', N'not avilable', N'Address1', 1, CAST(0x0000ABC100FADD08 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[EmplyoeeMst] ([EmplyoeeId], [EmplyoeeName], [MobileNumber], [GovtId], [Address], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted]) VALUES (2, N'Employee2', N'982343984', N'23', N'Address2', 1, CAST(0x0000ABC100FD96CE AS DateTime), 1, CAST(0x0000ABC100FDAF8C AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[EmplyoeeMst] OFF
SET IDENTITY_INSERT [dbo].[JobSheetTxn] ON 

INSERT [dbo].[JobSheetTxn] ([JobSheetTxnId], [CustomerId], [LocationId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted]) VALUES (2, 1, 15, 1, CAST(0x0000ABC300D75E24 AS DateTime), 1, CAST(0x0000ABC300F14939 AS DateTime), 1)
INSERT [dbo].[JobSheetTxn] ([JobSheetTxnId], [CustomerId], [LocationId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted]) VALUES (3, 1, 15, 1, CAST(0x0000ABC300D7A7F9 AS DateTime), 1, CAST(0x0000ABC300E537FA AS DateTime), 1)
INSERT [dbo].[JobSheetTxn] ([JobSheetTxnId], [CustomerId], [LocationId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted]) VALUES (4, 1, 15, 1, CAST(0x0000ABC300D85411 AS DateTime), 1, CAST(0x0000ABC300E533AE AS DateTime), 1)
INSERT [dbo].[JobSheetTxn] ([JobSheetTxnId], [CustomerId], [LocationId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted]) VALUES (5, 1, 15, 1, CAST(0x0000ABC300D85B1F AS DateTime), 1, CAST(0x0000ABC300DC60D0 AS DateTime), 1)
INSERT [dbo].[JobSheetTxn] ([JobSheetTxnId], [CustomerId], [LocationId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted]) VALUES (7, 1, 15, 1, CAST(0x0000ABC300F10340 AS DateTime), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[JobSheetTxn] OFF
SET IDENTITY_INSERT [dbo].[JobSheetTxnDet] ON 

INSERT [dbo].[JobSheetTxnDet] ([JobTxnSheetDetId], [JobSheetTxnId], [DateTime], [VechileId], [RunningHours], [EmplyoeeId], [Advance], [Rate], [DriverBeta], [DieselFrom], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted], [DieselLtr], [DieselRate]) VALUES (15, 7, CAST(0x0000ABC300A3D4F8 AS DateTime), 3, 234, 1, CAST(34535.00 AS Numeric(24, 2)), CAST(23.00 AS Numeric(24, 2)), CAST(34234.00 AS Numeric(24, 2)), 5, 1, CAST(0x0000ABC300FEA7B8 AS DateTime), NULL, NULL, 1, CAST(24.00 AS Numeric(24, 2)), CAST(5.00 AS Numeric(24, 2)))
INSERT [dbo].[JobSheetTxnDet] ([JobTxnSheetDetId], [JobSheetTxnId], [DateTime], [VechileId], [RunningHours], [EmplyoeeId], [Advance], [Rate], [DriverBeta], [DieselFrom], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted], [DieselLtr], [DieselRate]) VALUES (16, 7, CAST(0x0000ABC300ADBC47 AS DateTime), 1, 20, 1, CAST(100.00 AS Numeric(24, 2)), CAST(10.00 AS Numeric(24, 2)), CAST(100.00 AS Numeric(24, 2)), 4, 1, CAST(0x0000ABC30108FCA8 AS DateTime), NULL, NULL, 0, CAST(3.00 AS Numeric(24, 2)), CAST(4.00 AS Numeric(24, 2)))
INSERT [dbo].[JobSheetTxnDet] ([JobTxnSheetDetId], [JobSheetTxnId], [DateTime], [VechileId], [RunningHours], [EmplyoeeId], [Advance], [Rate], [DriverBeta], [DieselFrom], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted], [DieselLtr], [DieselRate]) VALUES (17, 7, CAST(0x0000ABC200000000 AS DateTime), 3, 200, 1, CAST(15000.00 AS Numeric(24, 2)), CAST(300.00 AS Numeric(24, 2)), CAST(900.00 AS Numeric(24, 2)), 5, 1, CAST(0x0000ABC3011184E0 AS DateTime), NULL, NULL, 0, CAST(5.00 AS Numeric(24, 2)), CAST(500.00 AS Numeric(24, 2)))
SET IDENTITY_INSERT [dbo].[JobSheetTxnDet] OFF
SET IDENTITY_INSERT [dbo].[LocationMst] ON 

INSERT [dbo].[LocationMst] ([LocationId], [ParentLocationId], [LocationName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted]) VALUES (8, 8, N'A', 1, CAST(0x0000ABC100EB8F95 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[LocationMst] ([LocationId], [ParentLocationId], [LocationName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted]) VALUES (9, 8, N'B', 1, CAST(0x0000ABC100EB8F95 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[LocationMst] ([LocationId], [ParentLocationId], [LocationName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted]) VALUES (10, 8, N'C', 1, CAST(0x0000ABC100EB8F95 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[LocationMst] ([LocationId], [ParentLocationId], [LocationName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted]) VALUES (11, 8, N'D', 1, CAST(0x0000ABC100EB8F95 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[LocationMst] ([LocationId], [ParentLocationId], [LocationName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted]) VALUES (12, 8, N'E', 1, CAST(0x0000ABC100EB8F95 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[LocationMst] ([LocationId], [ParentLocationId], [LocationName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted]) VALUES (13, 8, N'F', 1, CAST(0x0000ABC100EB8F95 AS DateTime), 1, CAST(0x0000ABC100F6DBF7 AS DateTime), 1)
INSERT [dbo].[LocationMst] ([LocationId], [ParentLocationId], [LocationName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted]) VALUES (14, 9, N'CC', 1, CAST(0x0000ABC100F1C9C6 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[LocationMst] ([LocationId], [ParentLocationId], [LocationName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted]) VALUES (15, 10, N'CCC', 1, CAST(0x0000ABC10182E35D AS DateTime), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[LocationMst] OFF
SET IDENTITY_INSERT [dbo].[MJEMSysLov] ON 

INSERT [dbo].[MJEMSysLov] ([LovId], [ParentId], [ScreenName], [FieldName], [LovKey], [FieldCode], [FieldValue], [Remarks], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted]) VALUES (1, NULL, N'VechileMst', N'VechileTypeBLV', N'VechileType', N'1', N'JCB', NULL, 1, CAST(0x0000ABBE013AF11D AS DateTime), NULL, NULL, 0)
INSERT [dbo].[MJEMSysLov] ([LovId], [ParentId], [ScreenName], [FieldName], [LovKey], [FieldCode], [FieldValue], [Remarks], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted]) VALUES (2, NULL, N'VechileMst', N'VechileTypeBLV', N'VechileType', N'2', N'Car', NULL, 1, CAST(0x0000ABBE013AF11D AS DateTime), NULL, NULL, 0)
INSERT [dbo].[MJEMSysLov] ([LovId], [ParentId], [ScreenName], [FieldName], [LovKey], [FieldCode], [FieldValue], [Remarks], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted]) VALUES (3, NULL, N'VechileMst', N'VechileTypeBLV', N'VechileType', N'3', N'Bike', NULL, 1, CAST(0x0000ABBE013AF11D AS DateTime), NULL, NULL, 0)
INSERT [dbo].[MJEMSysLov] ([LovId], [ParentId], [ScreenName], [FieldName], [LovKey], [FieldCode], [FieldValue], [Remarks], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted]) VALUES (4, NULL, N'JobSheetTxn', N'DieselFrom', N'DiselProviderType', N'1', N'Own', N'', 1, CAST(0x0000ABC300FE1BDC AS DateTime), NULL, NULL, 0)
INSERT [dbo].[MJEMSysLov] ([LovId], [ParentId], [ScreenName], [FieldName], [LovKey], [FieldCode], [FieldValue], [Remarks], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted]) VALUES (5, NULL, N'JobSheetTxn', N'DieselFrom', N'DiselProviderType', N'2', N'Customer', N'', 1, CAST(0x0000ABC300FE1BDC AS DateTime), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[MJEMSysLov] OFF
SET IDENTITY_INSERT [dbo].[VechileMst] ON 

INSERT [dbo].[VechileMst] ([VechileId], [VehcileType], [VechileNumber], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted]) VALUES (1, 1, N'TN-43-01234', 1, CAST(0x0000ABBE013BE0DF AS DateTime), NULL, NULL, 0)
INSERT [dbo].[VechileMst] ([VechileId], [VehcileType], [VechileNumber], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted]) VALUES (2, 3, N'TN-43-0121', 1, CAST(0x0000ABBE01441D50 AS DateTime), 1, CAST(0x0000ABBE01476E2A AS DateTime), 1)
INSERT [dbo].[VechileMst] ([VechileId], [VehcileType], [VechileNumber], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted]) VALUES (3, 3, N'TN-43-0121', 1, CAST(0x0000ABBE01478428 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[VechileMst] ([VechileId], [VehcileType], [VechileNumber], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsDeleted]) VALUES (4, 1, N'TN-76-0121', 1, CAST(0x0000ABBE014BDECE AS DateTime), 1, CAST(0x0000ABBE016700EA AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[VechileMst] OFF
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
ALTER TABLE [dbo].[JobSheetTxn]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[CustomersMst] ([CustomerId])
GO
ALTER TABLE [dbo].[JobSheetTxn]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[CustomersMst] ([CustomerId])
GO
ALTER TABLE [dbo].[JobSheetTxn]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[CustomersMst] ([CustomerId])
GO
ALTER TABLE [dbo].[JobSheetTxn]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[CustomersMst] ([CustomerId])
GO
ALTER TABLE [dbo].[JobSheetTxn]  WITH CHECK ADD FOREIGN KEY([LocationId])
REFERENCES [dbo].[LocationMst] ([LocationId])
GO
ALTER TABLE [dbo].[JobSheetTxn]  WITH CHECK ADD FOREIGN KEY([LocationId])
REFERENCES [dbo].[LocationMst] ([LocationId])
GO
ALTER TABLE [dbo].[JobSheetTxn]  WITH CHECK ADD FOREIGN KEY([LocationId])
REFERENCES [dbo].[LocationMst] ([LocationId])
GO
ALTER TABLE [dbo].[JobSheetTxn]  WITH CHECK ADD FOREIGN KEY([LocationId])
REFERENCES [dbo].[LocationMst] ([LocationId])
GO
ALTER TABLE [dbo].[JobSheetTxn]  WITH CHECK ADD FOREIGN KEY([LocationId])
REFERENCES [dbo].[LocationMst] ([LocationId])
GO
ALTER TABLE [dbo].[JobSheetTxnDet]  WITH CHECK ADD FOREIGN KEY([DieselFrom])
REFERENCES [dbo].[MJEMSysLov] ([LovId])
GO
ALTER TABLE [dbo].[JobSheetTxnDet]  WITH CHECK ADD FOREIGN KEY([DieselFrom])
REFERENCES [dbo].[MJEMSysLov] ([LovId])
GO
ALTER TABLE [dbo].[JobSheetTxnDet]  WITH CHECK ADD FOREIGN KEY([DieselFrom])
REFERENCES [dbo].[MJEMSysLov] ([LovId])
GO
ALTER TABLE [dbo].[JobSheetTxnDet]  WITH CHECK ADD FOREIGN KEY([DieselFrom])
REFERENCES [dbo].[MJEMSysLov] ([LovId])
GO
ALTER TABLE [dbo].[JobSheetTxnDet]  WITH CHECK ADD FOREIGN KEY([DieselFrom])
REFERENCES [dbo].[MJEMSysLov] ([LovId])
GO
ALTER TABLE [dbo].[JobSheetTxnDet]  WITH CHECK ADD FOREIGN KEY([EmplyoeeId])
REFERENCES [dbo].[EmplyoeeMst] ([EmplyoeeId])
GO
ALTER TABLE [dbo].[JobSheetTxnDet]  WITH CHECK ADD FOREIGN KEY([EmplyoeeId])
REFERENCES [dbo].[EmplyoeeMst] ([EmplyoeeId])
GO
ALTER TABLE [dbo].[JobSheetTxnDet]  WITH CHECK ADD FOREIGN KEY([EmplyoeeId])
REFERENCES [dbo].[EmplyoeeMst] ([EmplyoeeId])
GO
ALTER TABLE [dbo].[JobSheetTxnDet]  WITH CHECK ADD FOREIGN KEY([EmplyoeeId])
REFERENCES [dbo].[EmplyoeeMst] ([EmplyoeeId])
GO
ALTER TABLE [dbo].[JobSheetTxnDet]  WITH CHECK ADD FOREIGN KEY([EmplyoeeId])
REFERENCES [dbo].[EmplyoeeMst] ([EmplyoeeId])
GO
ALTER TABLE [dbo].[JobSheetTxnDet]  WITH CHECK ADD FOREIGN KEY([JobSheetTxnId])
REFERENCES [dbo].[JobSheetTxn] ([JobSheetTxnId])
GO
ALTER TABLE [dbo].[JobSheetTxnDet]  WITH CHECK ADD FOREIGN KEY([JobSheetTxnId])
REFERENCES [dbo].[JobSheetTxn] ([JobSheetTxnId])
GO
ALTER TABLE [dbo].[JobSheetTxnDet]  WITH CHECK ADD FOREIGN KEY([JobSheetTxnId])
REFERENCES [dbo].[JobSheetTxn] ([JobSheetTxnId])
GO
ALTER TABLE [dbo].[JobSheetTxnDet]  WITH CHECK ADD FOREIGN KEY([JobSheetTxnId])
REFERENCES [dbo].[JobSheetTxn] ([JobSheetTxnId])
GO
ALTER TABLE [dbo].[JobSheetTxnDet]  WITH CHECK ADD FOREIGN KEY([JobSheetTxnId])
REFERENCES [dbo].[JobSheetTxn] ([JobSheetTxnId])
GO
ALTER TABLE [dbo].[JobSheetTxnDet]  WITH CHECK ADD FOREIGN KEY([VechileId])
REFERENCES [dbo].[VechileMst] ([VechileId])
GO
ALTER TABLE [dbo].[JobSheetTxnDet]  WITH CHECK ADD FOREIGN KEY([VechileId])
REFERENCES [dbo].[VechileMst] ([VechileId])
GO
ALTER TABLE [dbo].[JobSheetTxnDet]  WITH CHECK ADD FOREIGN KEY([VechileId])
REFERENCES [dbo].[VechileMst] ([VechileId])
GO
ALTER TABLE [dbo].[JobSheetTxnDet]  WITH CHECK ADD FOREIGN KEY([VechileId])
REFERENCES [dbo].[VechileMst] ([VechileId])
GO
ALTER TABLE [dbo].[JobSheetTxnDet]  WITH CHECK ADD FOREIGN KEY([VechileId])
REFERENCES [dbo].[VechileMst] ([VechileId])
GO
ALTER TABLE [dbo].[LocationMst]  WITH CHECK ADD FOREIGN KEY([ParentLocationId])
REFERENCES [dbo].[LocationMst] ([LocationId])
GO
ALTER TABLE [dbo].[LocationMst]  WITH CHECK ADD FOREIGN KEY([ParentLocationId])
REFERENCES [dbo].[LocationMst] ([LocationId])
GO
ALTER TABLE [dbo].[LocationMst]  WITH CHECK ADD FOREIGN KEY([ParentLocationId])
REFERENCES [dbo].[LocationMst] ([LocationId])
GO
ALTER TABLE [dbo].[LocationMst]  WITH CHECK ADD FOREIGN KEY([ParentLocationId])
REFERENCES [dbo].[LocationMst] ([LocationId])
GO
ALTER TABLE [dbo].[LocationMst]  WITH CHECK ADD FOREIGN KEY([ParentLocationId])
REFERENCES [dbo].[LocationMst] ([LocationId])
GO
ALTER TABLE [dbo].[MaintananceTxn]  WITH CHECK ADD FOREIGN KEY([MaintananceType])
REFERENCES [dbo].[MJEMSysLov] ([LovId])
GO
ALTER TABLE [dbo].[MaintananceTxn]  WITH CHECK ADD FOREIGN KEY([MaintananceType])
REFERENCES [dbo].[MJEMSysLov] ([LovId])
GO
ALTER TABLE [dbo].[MaintananceTxn]  WITH CHECK ADD FOREIGN KEY([MaintananceType])
REFERENCES [dbo].[MJEMSysLov] ([LovId])
GO
ALTER TABLE [dbo].[MaintananceTxn]  WITH CHECK ADD FOREIGN KEY([MaintananceType])
REFERENCES [dbo].[MJEMSysLov] ([LovId])
GO
ALTER TABLE [dbo].[MaintananceTxn]  WITH CHECK ADD FOREIGN KEY([MaintananceType])
REFERENCES [dbo].[MJEMSysLov] ([LovId])
GO
ALTER TABLE [dbo].[MaintananceTxn]  WITH CHECK ADD FOREIGN KEY([ServiceType])
REFERENCES [dbo].[MJEMSysLov] ([LovId])
GO
ALTER TABLE [dbo].[MaintananceTxn]  WITH CHECK ADD FOREIGN KEY([ServiceType])
REFERENCES [dbo].[MJEMSysLov] ([LovId])
GO
ALTER TABLE [dbo].[MaintananceTxn]  WITH CHECK ADD FOREIGN KEY([ServiceType])
REFERENCES [dbo].[MJEMSysLov] ([LovId])
GO
ALTER TABLE [dbo].[MaintananceTxn]  WITH CHECK ADD FOREIGN KEY([ServiceType])
REFERENCES [dbo].[MJEMSysLov] ([LovId])
GO
ALTER TABLE [dbo].[MaintananceTxn]  WITH CHECK ADD FOREIGN KEY([ServiceType])
REFERENCES [dbo].[MJEMSysLov] ([LovId])
GO
ALTER TABLE [dbo].[MaintananceTxn]  WITH CHECK ADD FOREIGN KEY([VechileId])
REFERENCES [dbo].[VechileMst] ([VechileId])
GO
ALTER TABLE [dbo].[MaintananceTxn]  WITH CHECK ADD FOREIGN KEY([VechileId])
REFERENCES [dbo].[VechileMst] ([VechileId])
GO
ALTER TABLE [dbo].[MaintananceTxn]  WITH CHECK ADD FOREIGN KEY([VechileId])
REFERENCES [dbo].[VechileMst] ([VechileId])
GO
ALTER TABLE [dbo].[MaintananceTxn]  WITH CHECK ADD FOREIGN KEY([VechileId])
REFERENCES [dbo].[VechileMst] ([VechileId])
GO
ALTER TABLE [dbo].[MaintananceTxn]  WITH CHECK ADD FOREIGN KEY([VechileId])
REFERENCES [dbo].[VechileMst] ([VechileId])
GO
ALTER TABLE [dbo].[MJEMSysLov]  WITH CHECK ADD FOREIGN KEY([ParentId])
REFERENCES [dbo].[MJEMSysLov] ([LovId])
GO
ALTER TABLE [dbo].[MJEMSysLov]  WITH CHECK ADD FOREIGN KEY([ParentId])
REFERENCES [dbo].[MJEMSysLov] ([LovId])
GO
ALTER TABLE [dbo].[MJEMSysLov]  WITH CHECK ADD FOREIGN KEY([ParentId])
REFERENCES [dbo].[MJEMSysLov] ([LovId])
GO
ALTER TABLE [dbo].[MJEMSysLov]  WITH CHECK ADD FOREIGN KEY([ParentId])
REFERENCES [dbo].[MJEMSysLov] ([LovId])
GO
ALTER TABLE [dbo].[MJEMSysLov]  WITH CHECK ADD FOREIGN KEY([ParentId])
REFERENCES [dbo].[MJEMSysLov] ([LovId])
GO
ALTER TABLE [dbo].[SparePartsMst]  WITH CHECK ADD FOREIGN KEY([SpartPartType])
REFERENCES [dbo].[MJEMSysLov] ([LovId])
GO
ALTER TABLE [dbo].[SparePartsMst]  WITH CHECK ADD FOREIGN KEY([SpartPartType])
REFERENCES [dbo].[MJEMSysLov] ([LovId])
GO
ALTER TABLE [dbo].[SparePartsMst]  WITH CHECK ADD FOREIGN KEY([SpartPartType])
REFERENCES [dbo].[MJEMSysLov] ([LovId])
GO
ALTER TABLE [dbo].[SparePartsMst]  WITH CHECK ADD FOREIGN KEY([SpartPartType])
REFERENCES [dbo].[MJEMSysLov] ([LovId])
GO
ALTER TABLE [dbo].[SparePartsMst]  WITH CHECK ADD FOREIGN KEY([SpartPartType])
REFERENCES [dbo].[MJEMSysLov] ([LovId])
GO
ALTER TABLE [dbo].[VechileMst]  WITH CHECK ADD FOREIGN KEY([VehcileType])
REFERENCES [dbo].[MJEMSysLov] ([LovId])
GO
ALTER TABLE [dbo].[VechileMst]  WITH CHECK ADD FOREIGN KEY([VehcileType])
REFERENCES [dbo].[MJEMSysLov] ([LovId])
GO
ALTER TABLE [dbo].[VechileMst]  WITH CHECK ADD FOREIGN KEY([VehcileType])
REFERENCES [dbo].[MJEMSysLov] ([LovId])
GO
ALTER TABLE [dbo].[VechileMst]  WITH CHECK ADD FOREIGN KEY([VehcileType])
REFERENCES [dbo].[MJEMSysLov] ([LovId])
GO
ALTER TABLE [dbo].[VechileMst]  WITH CHECK ADD FOREIGN KEY([VehcileType])
REFERENCES [dbo].[MJEMSysLov] ([LovId])
GO
USE [master]
GO
ALTER DATABASE [MJEM] SET  READ_WRITE 
GO
