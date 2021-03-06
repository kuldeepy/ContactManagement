CREATE DATABASE Contact;
GO
USE [Contact]
GO
/****** Object:  StoredProcedure [dbo].[GetAllContact]    Script Date: 2/14/2017 5:12:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
-- exec GetAllContact
CREATE PROCEDURE [dbo].[GetAllContact]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Select 
	n.*,
	a.*
	From [dbo].[Name] as n
	inner join [dbo].[SubjectAddress_lnk] as l
	on n.SubjectId = l.SubjectId
	inner join [dbo].[Address] as a
	on a.AddressId = l.AddressId
    
END

GO
/****** Object:  StoredProcedure [dbo].[SaveContact]    Script Date: 2/14/2017 5:12:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SaveContact] 
	@Firstname nvarchar(100),
	@Lastname  nvarchar(100),
	@Mi  nvarchar(20),
	@Suffix  nvarchar(50),
	@Street  nvarchar(50),
	@Direction  nvarchar(100),
	@StreetName  nvarchar(100),
	@StreetType  nvarchar(50),
	@City  nvarchar(50),
	@State  nvarchar(50),
	@Zip int
AS
BEGIN
	Declare @AddressId int,@SubjectId int;
	SET NOCOUNT ON;
	Insert into [dbo].[Name]
	(
	 [FirstName]
	,[LastName]
	,[Mi]
	,[Suffix]
	)
	values
	(
	  @Firstname,
	  @Lastname,
	  @Mi,
	  @Suffix
	);
	SET @SubjectId = SCOPE_IDENTITY();

	Insert into [dbo].[Address]
	(
		[Street#]
		,[Direction]
		,[StreetName]
		,[StreetType]
		,[City]
		,[State]
		,[Zip]
	)
	Values
	(
		@Street
		,@Direction
		,@StreetName
		,@StreetType
		,@City
		,@State
		,@Zip
	)
	SET @AddressId = SCOPE_IDENTITY();

	Insert into [dbo].[SubjectAddress_lnk]
	([SubjectId],[AddressId])
	values(@SubjectId,@AddressId);
    
END

GO
/****** Object:  Table [dbo].[Address]    Script Date: 2/14/2017 5:12:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[Street#] [nvarchar](50) NULL,
	[Direction] [nvarchar](100) NULL,
	[StreetName] [nvarchar](100) NULL,
	[StreetType] [nvarchar](50) NULL,
	[City] [nvarchar](50) NOT NULL,
	[State] [nvarchar](50) NOT NULL,
	[Zip] [int] NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Name]    Script Date: 2/14/2017 5:12:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Name](
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[Mi] [nvarchar](20) NULL,
	[Suffix] [nvarchar](50) NULL,
	[SubjectId] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Name_1] PRIMARY KEY CLUSTERED 
(
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubjectAddress_lnk]    Script Date: 2/14/2017 5:12:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectAddress_lnk](
	[SubjectId] [int] NOT NULL,
	[AddressId] [int] NOT NULL,
 CONSTRAINT [PK_SubjectAddress_lnk] PRIMARY KEY CLUSTERED 
(
	[SubjectId] ASC,
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[SubjectAddress_lnk]  WITH CHECK ADD  CONSTRAINT [FK_SubjectAddress_lnk_Address] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Address] ([AddressId])
GO
ALTER TABLE [dbo].[SubjectAddress_lnk] CHECK CONSTRAINT [FK_SubjectAddress_lnk_Address]
GO
ALTER TABLE [dbo].[SubjectAddress_lnk]  WITH CHECK ADD  CONSTRAINT [FK_SubjectAddress_lnk_Name] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Name] ([SubjectId])
GO
ALTER TABLE [dbo].[SubjectAddress_lnk] CHECK CONSTRAINT [FK_SubjectAddress_lnk_Name]
GO
