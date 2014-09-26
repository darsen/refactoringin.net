USE master;
GO

CREATE DATABASE RENTAWHEELS

GO

USE RENTAWHEELS
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Vehicle_Branch]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Vehicle] DROP CONSTRAINT FK_Vehicle_Branch
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Model_Category]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Model] DROP CONSTRAINT FK_Model_Category
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Vehicle_Model]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Vehicle] DROP CONSTRAINT FK_Vehicle_Model
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Branch]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Branch]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Category]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Category]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Model]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Model]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Vehicle]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Vehicle]
GO

CREATE TABLE [dbo].[Branch] (
	[BranchId] [int] IDENTITY (1, 1) NOT NULL ,
	[Name] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Category] (
	[CategoryId] [int] IDENTITY (1, 1) NOT NULL ,
	[Name] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[DailyPrice] [decimal](38, 2) NULL ,
	[WeeklyPrice] [decimal](38, 2) NULL ,
	[MonthlyPrice] [decimal](38, 2) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Model] (
	[ModelId] [int] IDENTITY (1, 1) NOT NULL ,
	[Name] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[CategoryId] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Vehicle] (
	[LicensePlate] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[ModelId] [int] NOT NULL ,
	[BranchId] [int] NOT NULL ,
	[Available] [tinyint] NOT NULL ,
	[Operational] [tinyint] NOT NULL ,
	[Mileage] [int] NULL ,
	[Tank] [tinyint] NULL ,
	[CustomerFirstName] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[CustomerLastName] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[CustomerDocNumber] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[CustomerDocType] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Branch] WITH NOCHECK ADD 
	CONSTRAINT [PK_Branch] PRIMARY KEY  CLUSTERED 
	(
		[BranchId]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Category] WITH NOCHECK ADD 
	CONSTRAINT [PK_Category] PRIMARY KEY  CLUSTERED 
	(
		[CategoryId]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Model] WITH NOCHECK ADD 
	CONSTRAINT [PK_Model] PRIMARY KEY  CLUSTERED 
	(
		[ModelId]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Vehicle] WITH NOCHECK ADD 
	CONSTRAINT [DF_Vehicle_Available] DEFAULT (0) FOR [Available],
	CONSTRAINT [DF_Vehicle_Operational] DEFAULT (0) FOR [Operational],
	CONSTRAINT [PK_Vehicle] PRIMARY KEY  CLUSTERED 
	(
		[LicensePlate]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Model] ADD 
	CONSTRAINT [FK_Model_Category] FOREIGN KEY 
	(
		[CategoryId]
	) REFERENCES [dbo].[Category] (
		[CategoryId]
	)
GO

ALTER TABLE [dbo].[Vehicle] ADD 
	CONSTRAINT [FK_Vehicle_Branch] FOREIGN KEY 
	(
		[BranchId]
	) REFERENCES [dbo].[Branch] (
		[BranchId]
	),
	CONSTRAINT [FK_Vehicle_Model] FOREIGN KEY 
	(
		[ModelId]
	) REFERENCES [dbo].[Model] (
		[ModelId]
	)
GO

CREATE LOGIN RENTAWHEELS_LOGIN
    WITH PASSWORD = 'RENTAWHEELS_PASSWORD_123';

USE RENTAWHEELS;

CREATE USER RENTAWHEELS_USER FOR LOGIN RENTAWHEELS_LOGIN 
    WITH DEFAULT_SCHEMA = RENTAWHEELS;
GO

EXEC sp_addrolemember N'db_datareader', N'RENTAWHEELS_USER'

GO 
EXEC sp_addrolemember N'db_datawriter', N'RENTAWHEELS_USER'
