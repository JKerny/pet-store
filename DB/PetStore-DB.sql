USE [master]
GO

/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [global]    Script Date: 19/07/2018 10:06:30 AM ******/
CREATE LOGIN [global] WITH PASSWORD=N'JwPg7jig2lod7Or+9+GzMxoQenjHRtPFsIykbAmKQk4=', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

ALTER LOGIN [global] DISABLE
GO

drop 
database [PetStore]
create database [PetStore]
go
USE [PetStore]
GO
/****** Object:  Table [dbo].[AnimalTypes]    Script Date: 12/09/2017 3:58:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AnimalTypes](
	[AnimalTypeID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NULL,
 CONSTRAINT [PK_dbo.AnimalTypes] PRIMARY KEY CLUSTERED 
(
	[AnimalTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pets]    Script Date: 12/09/2017 3:58:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pets](
	[AnimalTypeID] [uniqueidentifier] NOT NULL,
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[Weight] [float] NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Pets] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[AnimalTypes] ([AnimalTypeID], [Name]) VALUES (N'dcff12f5-b98e-43e4-9f8b-31612d9f1a1c', N'Donkey')
GO
INSERT [dbo].[AnimalTypes] ([AnimalTypeID], [Name]) VALUES (N'4c2f6df8-b66c-4efd-bf8a-7029d2f1cd26', N'Pigs')
GO
INSERT [dbo].[AnimalTypes] ([AnimalTypeID], [Name]) VALUES (N'2859aa47-2f40-4ae4-b47d-7d492aa8a4f1', N'Elephant')
GO
INSERT [dbo].[AnimalTypes] ([AnimalTypeID], [Name]) VALUES (N'677fa900-bcda-4904-8e5f-dbb300372caf', N'Cat')
GO
INSERT [dbo].[AnimalTypes] ([AnimalTypeID], [Name]) VALUES (N'470df9dd-37ba-43c0-9d22-e9286ed79517', N'Horse')
GO
INSERT [dbo].[Pets] ([AnimalTypeID], [ID], [Name], [DateOfBirth], [Weight], [Description]) VALUES (N'4c2f6df8-b66c-4efd-bf8a-7029d2f1cd26', N'553b35ab-aa7c-487c-9c58-0b263156f4f9', N'miss piggy', CAST(N'2010-01-01 00:00:00.000' AS DateTime), 100, N'ziggy')
GO
INSERT [dbo].[Pets] ([AnimalTypeID], [ID], [Name], [DateOfBirth], [Weight], [Description]) VALUES (N'4c2f6df8-b66c-4efd-bf8a-7029d2f1cd26', N'e70fa1fa-181a-4a31-bbe6-0d178816093c', N'fatty', CAST(N'2002-01-01 00:00:00.000' AS DateTime), 100, N'fat')
GO
INSERT [dbo].[Pets] ([AnimalTypeID], [ID], [Name], [DateOfBirth], [Weight], [Description]) VALUES (N'677fa900-bcda-4904-8e5f-dbb300372caf', N'19bafd73-4c89-4d7d-9492-18f88d3f61a6', N'ronan', CAST(N'2009-01-01 00:00:00.000' AS DateTime), 12, N'poor')
GO
INSERT [dbo].[Pets] ([AnimalTypeID], [ID], [Name], [DateOfBirth], [Weight], [Description]) VALUES (N'470df9dd-37ba-43c0-9d22-e9286ed79517', N'b23c9745-e1ef-4ab0-aa2c-3de84c838d03', N'Qui praese', CAST(N'1997-10-09 00:00:00.000' AS DateTime), 700, N'Est quia aliqua')
GO
INSERT [dbo].[Pets] ([AnimalTypeID], [ID], [Name], [DateOfBirth], [Weight], [Description]) VALUES (N'2859aa47-2f40-4ae4-b47d-7d492aa8a4f1', N'fc3e5ff8-3a59-4328-9fd6-4c3fd30989ea', N'Dolores err', CAST(N'2015-11-09 00:00:00.000' AS DateTime), 500, N'Quia sed')
GO
INSERT [dbo].[Pets] ([AnimalTypeID], [ID], [Name], [DateOfBirth], [Weight], [Description]) VALUES (N'470df9dd-37ba-43c0-9d22-e9286ed79517', N'8bf3335f-5814-4857-a70b-578189297989', N'Mr Ed', CAST(N'2001-01-01 00:00:00.000' AS DateTime), 10, N'100')
GO
INSERT [dbo].[Pets] ([AnimalTypeID], [ID], [Name], [DateOfBirth], [Weight], [Description]) VALUES (N'470df9dd-37ba-43c0-9d22-e9286ed79517', N'cb22663a-9db1-4741-808a-682b9d0aa81d', N'Farr Lap', CAST(N'1942-01-01 00:00:00.000' AS DateTime), 120, N'the best')
GO
INSERT [dbo].[Pets] ([AnimalTypeID], [ID], [Name], [DateOfBirth], [Weight], [Description]) VALUES (N'4c2f6df8-b66c-4efd-bf8a-7029d2f1cd26', N'edb681ce-6c14-4913-928b-6d0ab3011462', N'Toby', CAST(N'2010-01-01 00:00:00.000' AS DateTime), 10, N'noice')
GO
INSERT [dbo].[Pets] ([AnimalTypeID], [ID], [Name], [DateOfBirth], [Weight], [Description]) VALUES (N'2859aa47-2f40-4ae4-b47d-7d492aa8a4f1', N'a395b03b-c178-40e6-af14-6f0b2d72c312', N'bobo', CAST(N'2017-01-01 00:00:00.000' AS DateTime), 700, N'big')
GO
INSERT [dbo].[Pets] ([AnimalTypeID], [ID], [Name], [DateOfBirth], [Weight], [Description]) VALUES (N'470df9dd-37ba-43c0-9d22-e9286ed79517', N'c6efe4f4-64c2-4d48-9757-78b1018eb2f6', N'Voluptate ipsam nisi', CAST(N'2017-01-31 00:00:00.000' AS DateTime), 40, N'Odit occaec')
GO
INSERT [dbo].[Pets] ([AnimalTypeID], [ID], [Name], [DateOfBirth], [Weight], [Description]) VALUES (N'4c2f6df8-b66c-4efd-bf8a-7029d2f1cd26', N'069e8fc5-98b2-47cd-a752-7a74d9dfe5d0', N'piggy', CAST(N'2017-01-01 00:00:00.000' AS DateTime), 400, N'pig')
GO
INSERT [dbo].[Pets] ([AnimalTypeID], [ID], [Name], [DateOfBirth], [Weight], [Description]) VALUES (N'2859aa47-2f40-4ae4-b47d-7d492aa8a4f1', N'85ce4ea9-f22b-40fd-9b68-7c6d568cc554', N'Biggy', CAST(N'2010-01-01 00:00:00.000' AS DateTime), 10, N'smalls')
GO
INSERT [dbo].[Pets] ([AnimalTypeID], [ID], [Name], [DateOfBirth], [Weight], [Description]) VALUES (N'4c2f6df8-b66c-4efd-bf8a-7029d2f1cd26', N'd4172242-e5e1-4dcd-994a-7f2474661dba', N'Porky Pi', CAST(N'2016-01-01 00:00:00.000' AS DateTime), 151, N'big fatty')
GO
INSERT [dbo].[Pets] ([AnimalTypeID], [ID], [Name], [DateOfBirth], [Weight], [Description]) VALUES (N'470df9dd-37ba-43c0-9d22-e9286ed79517', N'317b80b2-34dc-473d-92d5-973773e5ed5b', N'In sit volu', CAST(N'2009-12-14 00:00:00.000' AS DateTime), 800, N'Vel veniam ')
GO
INSERT [dbo].[Pets] ([AnimalTypeID], [ID], [Name], [DateOfBirth], [Weight], [Description]) VALUES (N'2859aa47-2f40-4ae4-b47d-7d492aa8a4f1', N'a49cd2e6-3c4c-4139-8127-97ba554efc4d', N'bob', CAST(N'2001-01-01 00:00:00.000' AS DateTime), 15, NULL)
GO
INSERT [dbo].[Pets] ([AnimalTypeID], [ID], [Name], [DateOfBirth], [Weight], [Description]) VALUES (N'677fa900-bcda-4904-8e5f-dbb300372caf', N'fe06a00b-9cb1-44c6-9168-b6bb7bb21cf3', N'fred', CAST(N'2010-01-01 00:00:00.000' AS DateTime), 10, N'c')
GO
INSERT [dbo].[Pets] ([AnimalTypeID], [ID], [Name], [DateOfBirth], [Weight], [Description]) VALUES (N'677fa900-bcda-4904-8e5f-dbb300372caf', N'683dfc90-492f-4396-94b8-b7299996e05c', N'Tinsel', CAST(N'2017-05-05 00:00:00.000' AS DateTime), 10, N'nice kitty')
GO
INSERT [dbo].[Pets] ([AnimalTypeID], [ID], [Name], [DateOfBirth], [Weight], [Description]) VALUES (N'470df9dd-37ba-43c0-9d22-e9286ed79517', N'3d294890-17c7-4406-8dd7-b97b8b34247b', N'mr teds', CAST(N'2010-01-01 00:00:00.000' AS DateTime), 15, N'asd')
GO
INSERT [dbo].[Pets] ([AnimalTypeID], [ID], [Name], [DateOfBirth], [Weight], [Description]) VALUES (N'2859aa47-2f40-4ae4-b47d-7d492aa8a4f1', N'2d6dcd17-276f-4a8b-acbb-c7210afe8f13', N'shorty', CAST(N'2014-01-01 00:00:00.000' AS DateTime), 500, N't')
GO
INSERT [dbo].[Pets] ([AnimalTypeID], [ID], [Name], [DateOfBirth], [Weight], [Description]) VALUES (N'2859aa47-2f40-4ae4-b47d-7d492aa8a4f1', N'b24c9fd0-a106-424f-a5aa-d688dfb50123', N'Lorem illo quia voluptatem Qui minim aut ut excepteur', CAST(N'1977-04-25 00:00:00.000' AS DateTime), 20, N'Dolor ullam dignissimos ad qui in')
GO
INSERT [dbo].[Pets] ([AnimalTypeID], [ID], [Name], [DateOfBirth], [Weight], [Description]) VALUES (N'4c2f6df8-b66c-4efd-bf8a-7029d2f1cd26', N'20859542-f422-49a9-9370-d9a8608a267c', N'Mr Pig', CAST(N'2017-05-05 00:00:00.000' AS DateTime), 18, N'great pet')
GO
INSERT [dbo].[Pets] ([AnimalTypeID], [ID], [Name], [DateOfBirth], [Weight], [Description]) VALUES (N'470df9dd-37ba-43c0-9d22-e9286ed79517', N'4c356c7b-17ad-44a7-b784-e2f1411a0b56', N'ed', CAST(N'2011-01-01 00:00:00.000' AS DateTime), 200, N'big')
GO
INSERT [dbo].[Pets] ([AnimalTypeID], [ID], [Name], [DateOfBirth], [Weight], [Description]) VALUES (N'dcff12f5-b98e-43e4-9f8b-31612d9f1a1c', N'3ae74038-6162-4943-8f12-e349a34fbc19', N'Dobee', CAST(N'2009-01-01 00:00:00.000' AS DateTime), 100, N'grey old')
GO
INSERT [dbo].[Pets] ([AnimalTypeID], [ID], [Name], [DateOfBirth], [Weight], [Description]) VALUES (N'470df9dd-37ba-43c0-9d22-e9286ed79517', N'a7e7bce0-0fbc-48fe-9200-f1e2ce23e7db', N'long face', CAST(N'2012-01-01 00:00:00.000' AS DateTime), 400, N'big')
GO
ALTER TABLE [dbo].[Pets]  WITH CHECK ADD  CONSTRAINT [FK_Pets_AnimalTypes] FOREIGN KEY([AnimalTypeID])
REFERENCES [dbo].[AnimalTypes] ([AnimalTypeID])
GO
ALTER TABLE [dbo].[Pets] CHECK CONSTRAINT [FK_Pets_AnimalTypes]
GO
