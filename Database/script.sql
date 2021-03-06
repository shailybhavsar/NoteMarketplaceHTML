USE [master]
GO
/****** Object:  Database [NotesMarketPlaceTables]    Script Date: 12-04-2021 20:12:03 ******/
CREATE DATABASE [NotesMarketPlaceTables]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NotesMarketPlaceTables', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\NotesMarketPlaceTables.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NotesMarketPlaceTables_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\NotesMarketPlaceTables_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [NotesMarketPlaceTables] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NotesMarketPlaceTables].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NotesMarketPlaceTables] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NotesMarketPlaceTables] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NotesMarketPlaceTables] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NotesMarketPlaceTables] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NotesMarketPlaceTables] SET ARITHABORT OFF 
GO
ALTER DATABASE [NotesMarketPlaceTables] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NotesMarketPlaceTables] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NotesMarketPlaceTables] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NotesMarketPlaceTables] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NotesMarketPlaceTables] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NotesMarketPlaceTables] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NotesMarketPlaceTables] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NotesMarketPlaceTables] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NotesMarketPlaceTables] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NotesMarketPlaceTables] SET  DISABLE_BROKER 
GO
ALTER DATABASE [NotesMarketPlaceTables] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NotesMarketPlaceTables] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NotesMarketPlaceTables] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NotesMarketPlaceTables] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NotesMarketPlaceTables] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NotesMarketPlaceTables] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NotesMarketPlaceTables] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NotesMarketPlaceTables] SET RECOVERY FULL 
GO
ALTER DATABASE [NotesMarketPlaceTables] SET  MULTI_USER 
GO
ALTER DATABASE [NotesMarketPlaceTables] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NotesMarketPlaceTables] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NotesMarketPlaceTables] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NotesMarketPlaceTables] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NotesMarketPlaceTables] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'NotesMarketPlaceTables', N'ON'
GO
ALTER DATABASE [NotesMarketPlaceTables] SET QUERY_STORE = OFF
GO
USE [NotesMarketPlaceTables]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 12-04-2021 20:12:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[CountryID] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [varchar](100) NOT NULL,
	[CountryCode] [varchar](100) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_AddCountry] PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Downloads]    Script Date: 12-04-2021 20:12:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Downloads](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NoteID] [int] NOT NULL,
	[Seller] [int] NOT NULL,
	[Downloader] [int] NOT NULL,
	[IsSellerHasAllowedDownload] [bit] NOT NULL,
	[AttachmentPath] [varchar](max) NULL,
	[IsAttachmentDownloaded] [bit] NOT NULL,
	[AttachmentDownloadedDate] [datetime] NULL,
	[IsPaid] [bit] NOT NULL,
	[PurchasedPrice] [decimal](18, 0) NULL,
	[NoteTitle] [varchar](100) NOT NULL,
	[NoteCategory] [varchar](100) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
 CONSTRAINT [PK_Downloads] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NoteCategories]    Script Date: 12-04-2021 20:12:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NoteCategories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](50) NOT NULL,
	[Description] [varchar](500) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_AddCategory] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NoteTypes]    Script Date: 12-04-2021 20:12:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NoteTypes](
	[TypeID] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [varchar](25) NOT NULL,
	[Description] [varchar](500) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_AddType] PRIMARY KEY CLUSTERED 
(
	[TypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReferenceData]    Script Date: 12-04-2021 20:12:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReferenceData](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Value] [varchar](100) NOT NULL,
	[DataValue] [varchar](100) NOT NULL,
	[RefCategory] [varchar](100) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_ReferenceData] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SellerNotes]    Script Date: 12-04-2021 20:12:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SellerNotes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SellerID] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[ActionedBy] [int] NULL,
	[AdminRemarks] [varchar](max) NULL,
	[PublishedDate] [datetime] NULL,
	[Title] [varchar](100) NOT NULL,
	[Category] [int] NOT NULL,
	[DisplayPicture] [varchar](500) NULL,
	[NoteType] [int] NULL,
	[NumberOfPages] [int] NULL,
	[Description] [varchar](max) NOT NULL,
	[UniversityName] [varchar](200) NULL,
	[Country] [int] NULL,
	[Course] [varchar](100) NULL,
	[CourseCode] [varchar](100) NULL,
	[Professor] [varchar](100) NULL,
	[IsPaid] [bit] NOT NULL,
	[SellingPrice] [decimal](18, 0) NULL,
	[NotesPreview] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_SellerNotes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SellerNotesAttachments]    Script Date: 12-04-2021 20:12:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SellerNotesAttachments](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NoteID] [int] NOT NULL,
	[FileName] [varchar](100) NOT NULL,
	[FilePath] [varchar](max) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_SellerNotesAttachments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SellerNotesReportedIssues]    Script Date: 12-04-2021 20:12:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SellerNotesReportedIssues](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NoteID] [int] NOT NULL,
	[ReportedByID] [int] NOT NULL,
	[AgainstDownloadID] [int] NOT NULL,
	[Remarks] [varchar](max) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
 CONSTRAINT [PK_SellerNotesReportedIssues] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SellerNotesReviews]    Script Date: 12-04-2021 20:12:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SellerNotesReviews](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NoteID] [int] NOT NULL,
	[ReviewedByID] [int] NOT NULL,
	[AgainstDownloadsID] [int] NOT NULL,
	[Ratings] [decimal](18, 0) NOT NULL,
	[Comments] [varchar](max) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_SellerNotesReviews] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemConfiguration]    Script Date: 12-04-2021 20:12:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemConfiguration](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Key] [varchar](100) NOT NULL,
	[Value] [varchar](max) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_ManageSystemConfiguration] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 12-04-2021 20:12:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProfile](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[DOB] [datetime] NULL,
	[Gender] [int] NULL,
	[SecondaryEmailAddress] [varchar](100) NULL,
	[PhoneNumberCountryCOde] [varchar](5) NOT NULL,
	[PhoneNumber] [varchar](20) NOT NULL,
	[ProfilePicture] [varchar](500) NULL,
	[AddressLine1] [varchar](100) NOT NULL,
	[AddressLine2] [varchar](100) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[State] [varchar](50) NOT NULL,
	[ZipCode] [varchar](50) NOT NULL,
	[Country] [varchar](50) NOT NULL,
	[University] [varchar](100) NULL,
	[College] [varchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
 CONSTRAINT [PK_UserProfile] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 12-04-2021 20:12:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](max) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12-04-2021 20:12:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[EmailID] [varchar](100) NOT NULL,
	[Password] [varchar](24) NOT NULL,
	[IsEmailVerified] [bit] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryCode], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (1, N'India', N'+91', CAST(N'2021-03-06T10:33:35.127' AS DateTime), 3055, NULL, NULL, 1)
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryCode], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (2, N'Australia', N'+61', CAST(N'2021-05-07T11:26:34.223' AS DateTime), 3058, CAST(N'2021-04-07T00:17:51.830' AS DateTime), NULL, 1)
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryCode], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (3, N'USA', N'+1', CAST(N'2021-03-30T23:35:32.847' AS DateTime), 3059, NULL, NULL, 0)
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryCode], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (4, N'United Kingdom', N'+44', CAST(N'2021-03-30T23:35:32.847' AS DateTime), 3060, NULL, NULL, 1)
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryCode], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (5, N'Canada', N'+1', CAST(N'2021-03-30T23:35:32.847' AS DateTime), 3060, NULL, NULL, 1)
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryCode], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (6, N'Germany', N'+49', CAST(N'2021-03-06T10:33:35.127' AS DateTime), 3053, NULL, NULL, 1)
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryCode], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (8, N'Switzerland', N'+41', CAST(N'2021-04-07T00:19:25.330' AS DateTime), 3053, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Country] OFF
GO
SET IDENTITY_INSERT [dbo].[Downloads] ON 

INSERT [dbo].[Downloads] ([ID], [NoteID], [Seller], [Downloader], [IsSellerHasAllowedDownload], [AttachmentPath], [IsAttachmentDownloaded], [AttachmentDownloadedDate], [IsPaid], [PurchasedPrice], [NoteTitle], [NoteCategory], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (1, 33, 3052, 3050, 1, N'D:\Tatvasoft\Project3_tatvasoft\MVC\NotesMarketPlace\NotesMarketPlaceProject\Uploadimg\sample.pdf', 1, CAST(N'2021-03-18T11:25:43.303' AS DateTime), 0, CAST(0 AS Decimal(18, 0)), N'dffs', N'Computer', CAST(N'2021-03-18T11:25:43.303' AS DateTime), 3050, CAST(N'2021-03-18T11:25:43.303' AS DateTime), 3050)
INSERT [dbo].[Downloads] ([ID], [NoteID], [Seller], [Downloader], [IsSellerHasAllowedDownload], [AttachmentPath], [IsAttachmentDownloaded], [AttachmentDownloadedDate], [IsPaid], [PurchasedPrice], [NoteTitle], [NoteCategory], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (2, 33, 3, 3050, 1, N'D:\Tatvasoft\Project3_tatvasoft\MVC\NotesMarketPlace\NotesMarketPlaceProject\Uploadimg\sample.pdf', 1, CAST(N'2021-03-18T11:26:02.973' AS DateTime), 0, CAST(0 AS Decimal(18, 0)), N'dffs', N'Computer', CAST(N'2021-03-18T11:26:02.973' AS DateTime), 3050, CAST(N'2021-03-18T11:26:02.973' AS DateTime), 3050)
INSERT [dbo].[Downloads] ([ID], [NoteID], [Seller], [Downloader], [IsSellerHasAllowedDownload], [AttachmentPath], [IsAttachmentDownloaded], [AttachmentDownloadedDate], [IsPaid], [PurchasedPrice], [NoteTitle], [NoteCategory], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (3, 26, 3, 2023, 1, NULL, 0, CAST(N'2021-03-18T14:38:14.233' AS DateTime), 1, CAST(450 AS Decimal(18, 0)), N'Maths Book', N'IT', CAST(N'2021-03-18T14:38:14.237' AS DateTime), 2023, CAST(N'2021-03-18T14:38:14.237' AS DateTime), 2023)
INSERT [dbo].[Downloads] ([ID], [NoteID], [Seller], [Downloader], [IsSellerHasAllowedDownload], [AttachmentPath], [IsAttachmentDownloaded], [AttachmentDownloadedDate], [IsPaid], [PurchasedPrice], [NoteTitle], [NoteCategory], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (4, 30, 3, 1012, 1, N'D:\Tatvasoft\Project3_tatvasoft\MVC\NotesMarketPlace\NotesMarketPlaceProject\Uploadimg\pages.png', 1, CAST(N'2021-03-20T18:52:03.740' AS DateTime), 1, CAST(350 AS Decimal(18, 0)), N'Computer Science', N'IT', CAST(N'2021-03-18T15:18:18.727' AS DateTime), 1012, CAST(N'2021-03-18T15:18:18.727' AS DateTime), 1012)
INSERT [dbo].[Downloads] ([ID], [NoteID], [Seller], [Downloader], [IsSellerHasAllowedDownload], [AttachmentPath], [IsAttachmentDownloaded], [AttachmentDownloadedDate], [IsPaid], [PurchasedPrice], [NoteTitle], [NoteCategory], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (5, 31, 3, 2028, 1, N'D:\Tatvasoft\Project3_tatvasoft\MVC\NotesMarketPlace\NotesMarketPlaceProject\Uploadimg\pages.png', 1, CAST(N'2021-03-19T23:03:56.883' AS DateTime), 1, CAST(20 AS Decimal(18, 0)), N'Computer Science', N'CS', CAST(N'2021-03-18T15:56:03.617' AS DateTime), 2028, CAST(N'2021-03-18T15:56:03.617' AS DateTime), 2028)
INSERT [dbo].[Downloads] ([ID], [NoteID], [Seller], [Downloader], [IsSellerHasAllowedDownload], [AttachmentPath], [IsAttachmentDownloaded], [AttachmentDownloadedDate], [IsPaid], [PurchasedPrice], [NoteTitle], [NoteCategory], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (6, 31, 3, 2028, 1, N'D:\Tatvasoft\Project3_tatvasoft\MVC\NotesMarketPlace\NotesMarketPlaceProject\Uploadimg\pages.png', 1, CAST(N'2021-03-18T23:00:42.790' AS DateTime), 1, CAST(20 AS Decimal(18, 0)), N'Computer Science', N'CS', CAST(N'2021-03-18T15:56:25.957' AS DateTime), 2028, CAST(N'2021-03-18T15:56:25.957' AS DateTime), 2028)
INSERT [dbo].[Downloads] ([ID], [NoteID], [Seller], [Downloader], [IsSellerHasAllowedDownload], [AttachmentPath], [IsAttachmentDownloaded], [AttachmentDownloadedDate], [IsPaid], [PurchasedPrice], [NoteTitle], [NoteCategory], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (9, 33, 3, 3050, 1, N'D:\Tatvasoft\Project3_tatvasoft\MVC\NotesMarketPlace\NotesMarketPlaceProject\Uploadimg\sample.pdf', 1, CAST(N'2021-03-18T23:09:06.633' AS DateTime), 0, CAST(0 AS Decimal(18, 0)), N'dffs', N'Computer', CAST(N'2021-03-18T23:09:06.633' AS DateTime), 3050, CAST(N'2021-03-18T23:09:06.633' AS DateTime), 3050)
INSERT [dbo].[Downloads] ([ID], [NoteID], [Seller], [Downloader], [IsSellerHasAllowedDownload], [AttachmentPath], [IsAttachmentDownloaded], [AttachmentDownloadedDate], [IsPaid], [PurchasedPrice], [NoteTitle], [NoteCategory], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (10, 30, 3, 1012, 1, N'D:\Tatvasoft\Project3_tatvasoft\MVC\NotesMarketPlace\NotesMarketPlaceProject\Uploadimg\pages.png', 1, CAST(N'2021-03-19T19:20:33.570' AS DateTime), 1, NULL, N'Computer Science', N'IT', CAST(N'2021-03-19T19:20:33.570' AS DateTime), 1012, CAST(N'2021-03-19T19:20:33.570' AS DateTime), 1012)
INSERT [dbo].[Downloads] ([ID], [NoteID], [Seller], [Downloader], [IsSellerHasAllowedDownload], [AttachmentPath], [IsAttachmentDownloaded], [AttachmentDownloadedDate], [IsPaid], [PurchasedPrice], [NoteTitle], [NoteCategory], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (11, 26, 3, 3050, 0, NULL, 0, CAST(N'2021-03-23T23:46:21.543' AS DateTime), 1, CAST(450 AS Decimal(18, 0)), N'Maths Book', N'IT', CAST(N'2021-03-23T23:46:21.543' AS DateTime), 3050, CAST(N'2021-03-23T23:46:21.543' AS DateTime), 3050)
INSERT [dbo].[Downloads] ([ID], [NoteID], [Seller], [Downloader], [IsSellerHasAllowedDownload], [AttachmentPath], [IsAttachmentDownloaded], [AttachmentDownloadedDate], [IsPaid], [PurchasedPrice], [NoteTitle], [NoteCategory], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (12, 26, 3, 3050, 0, NULL, 0, CAST(N'2021-03-23T23:48:18.723' AS DateTime), 1, CAST(450 AS Decimal(18, 0)), N'Maths Book', N'IT', CAST(N'2021-03-23T23:48:18.723' AS DateTime), 3050, CAST(N'2021-03-23T23:48:18.723' AS DateTime), 3050)
INSERT [dbo].[Downloads] ([ID], [NoteID], [Seller], [Downloader], [IsSellerHasAllowedDownload], [AttachmentPath], [IsAttachmentDownloaded], [AttachmentDownloadedDate], [IsPaid], [PurchasedPrice], [NoteTitle], [NoteCategory], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (13, 25, 3, 3, 1, N'D:\Tatvasoft\Project3_tatvasoft\MVC\NotesMarketPlace\NotesMarketPlaceProject\Uploadimg\sample.pdf', 1, CAST(N'2021-03-26T15:54:03.647' AS DateTime), 0, CAST(0 AS Decimal(18, 0)), N'Mathematics', N'MBA', CAST(N'2021-03-26T15:54:03.650' AS DateTime), 3, CAST(N'2021-03-26T15:54:03.650' AS DateTime), 3)
INSERT [dbo].[Downloads] ([ID], [NoteID], [Seller], [Downloader], [IsSellerHasAllowedDownload], [AttachmentPath], [IsAttachmentDownloaded], [AttachmentDownloadedDate], [IsPaid], [PurchasedPrice], [NoteTitle], [NoteCategory], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (14, 26, 3, 3050, 0, NULL, 0, CAST(N'2021-03-27T10:02:02.010' AS DateTime), 1, CAST(450 AS Decimal(18, 0)), N'Maths Book', N'IT', CAST(N'2021-03-27T10:02:02.010' AS DateTime), 3050, CAST(N'2021-03-27T10:02:02.010' AS DateTime), 3050)
INSERT [dbo].[Downloads] ([ID], [NoteID], [Seller], [Downloader], [IsSellerHasAllowedDownload], [AttachmentPath], [IsAttachmentDownloaded], [AttachmentDownloadedDate], [IsPaid], [PurchasedPrice], [NoteTitle], [NoteCategory], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (15, 15, 6, 2027, 1, NULL, 0, CAST(N'2021-03-27T10:28:58.337' AS DateTime), 1, CAST(320 AS Decimal(18, 0)), N'Data Science', N'Computer', CAST(N'2021-03-27T10:28:58.337' AS DateTime), 2027, CAST(N'2021-03-27T10:28:58.337' AS DateTime), 2027)
INSERT [dbo].[Downloads] ([ID], [NoteID], [Seller], [Downloader], [IsSellerHasAllowedDownload], [AttachmentPath], [IsAttachmentDownloaded], [AttachmentDownloadedDate], [IsPaid], [PurchasedPrice], [NoteTitle], [NoteCategory], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (16, 29, 3, 2, 1, N'D:\Tatvasoft\Project3_tatvasoft\MVC\NotesMarketPlace\NotesMarketPlaceProject\Uploadimg\pages.png', 1, CAST(N'2021-04-07T11:28:48.210' AS DateTime), 0, CAST(0 AS Decimal(18, 0)), N'Computer Operating System', N'Computer', CAST(N'2021-03-29T11:14:58.037' AS DateTime), 2, CAST(N'2021-03-29T11:14:58.037' AS DateTime), 2)
INSERT [dbo].[Downloads] ([ID], [NoteID], [Seller], [Downloader], [IsSellerHasAllowedDownload], [AttachmentPath], [IsAttachmentDownloaded], [AttachmentDownloadedDate], [IsPaid], [PurchasedPrice], [NoteTitle], [NoteCategory], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (17, 29, 3, 2, 1, N'D:\Tatvasoft\Project3_tatvasoft\MVC\NotesMarketPlace\NotesMarketPlaceProject\Uploadimg\pages.png', 1, CAST(N'2021-04-07T11:28:48.210' AS DateTime), 0, CAST(0 AS Decimal(18, 0)), N'Computer Operating System', N'Computer', CAST(N'2021-04-07T11:28:48.210' AS DateTime), 2, CAST(N'2021-04-07T11:28:48.210' AS DateTime), 2)
INSERT [dbo].[Downloads] ([ID], [NoteID], [Seller], [Downloader], [IsSellerHasAllowedDownload], [AttachmentPath], [IsAttachmentDownloaded], [AttachmentDownloadedDate], [IsPaid], [PurchasedPrice], [NoteTitle], [NoteCategory], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (18, 31, 3052, 2030, 1, N'D:\Tatvasoft\Project3_tatvasoft\MVC\NotesMarketPlace\NotesMarketPlaceProject\Uploadimg\SCN.pdf', 1, CAST(N'2021-04-10T00:07:08.717' AS DateTime), 1, CAST(20 AS Decimal(18, 0)), N'DSA Book', N'CS', CAST(N'2021-04-09T23:24:45.457' AS DateTime), 2030, CAST(N'2021-04-09T23:24:45.457' AS DateTime), 3052)
INSERT [dbo].[Downloads] ([ID], [NoteID], [Seller], [Downloader], [IsSellerHasAllowedDownload], [AttachmentPath], [IsAttachmentDownloaded], [AttachmentDownloadedDate], [IsPaid], [PurchasedPrice], [NoteTitle], [NoteCategory], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (19, 31, 3052, 2, 0, NULL, 0, CAST(N'2021-04-09T23:34:43.917' AS DateTime), 1, CAST(20 AS Decimal(18, 0)), N'DSA Book', N'CS', CAST(N'2021-04-09T23:34:43.917' AS DateTime), 2, CAST(N'2021-04-09T23:34:43.917' AS DateTime), 2)
INSERT [dbo].[Downloads] ([ID], [NoteID], [Seller], [Downloader], [IsSellerHasAllowedDownload], [AttachmentPath], [IsAttachmentDownloaded], [AttachmentDownloadedDate], [IsPaid], [PurchasedPrice], [NoteTitle], [NoteCategory], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (20, 29, 3, 2023, 1, N'D:\Tatvasoft\Project3_tatvasoft\MVC\NotesMarketPlace\NotesMarketPlaceProject\Uploadimg\XYZ.pdf', 1, CAST(N'2021-04-10T00:19:41.330' AS DateTime), 0, CAST(0 AS Decimal(18, 0)), N'Computer Operating System', N'Computer', CAST(N'2021-04-10T00:19:41.330' AS DateTime), 2023, CAST(N'2021-04-10T00:19:41.330' AS DateTime), 2023)
INSERT [dbo].[Downloads] ([ID], [NoteID], [Seller], [Downloader], [IsSellerHasAllowedDownload], [AttachmentPath], [IsAttachmentDownloaded], [AttachmentDownloadedDate], [IsPaid], [PurchasedPrice], [NoteTitle], [NoteCategory], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (21, 29, 3, 1012, 1, N'D:\Tatvasoft\Project3_tatvasoft\MVC\NotesMarketPlace\NotesMarketPlaceProject\Uploadimg\XYZ.pdf', 1, CAST(N'2021-04-10T00:48:45.323' AS DateTime), 0, CAST(0 AS Decimal(18, 0)), N'Computer Operating System', N'Computer', CAST(N'2021-04-10T00:48:45.323' AS DateTime), 1012, CAST(N'2021-04-10T00:48:45.323' AS DateTime), 1012)
INSERT [dbo].[Downloads] ([ID], [NoteID], [Seller], [Downloader], [IsSellerHasAllowedDownload], [AttachmentPath], [IsAttachmentDownloaded], [AttachmentDownloadedDate], [IsPaid], [PurchasedPrice], [NoteTitle], [NoteCategory], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (22, 21, 6, 1012, 1, N'D:\Tatvasoft\Project3_tatvasoft\MVC\NotesMarketPlace\NotesMarketPlaceProject\Uploadimg\MCWC.pdf', 1, CAST(N'2021-04-10T00:49:10.583' AS DateTime), 0, CAST(0 AS Decimal(18, 0)), N'Automobile', N'IT', CAST(N'2021-04-10T00:49:10.583' AS DateTime), 1012, CAST(N'2021-04-10T00:49:10.583' AS DateTime), 1012)
INSERT [dbo].[Downloads] ([ID], [NoteID], [Seller], [Downloader], [IsSellerHasAllowedDownload], [AttachmentPath], [IsAttachmentDownloaded], [AttachmentDownloadedDate], [IsPaid], [PurchasedPrice], [NoteTitle], [NoteCategory], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (23, 21, 6, 3, 1, N'D:\Tatvasoft\Project3_tatvasoft\MVC\NotesMarketPlace\NotesMarketPlaceProject\Uploadimg\MCWC.pdf', 1, CAST(N'2021-04-10T00:49:57.900' AS DateTime), 0, CAST(0 AS Decimal(18, 0)), N'Automobile', N'IT', CAST(N'2021-04-10T00:49:57.900' AS DateTime), 3, CAST(N'2021-04-10T00:49:57.900' AS DateTime), 3)
INSERT [dbo].[Downloads] ([ID], [NoteID], [Seller], [Downloader], [IsSellerHasAllowedDownload], [AttachmentPath], [IsAttachmentDownloaded], [AttachmentDownloadedDate], [IsPaid], [PurchasedPrice], [NoteTitle], [NoteCategory], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (24, 19, 2, 3050, 1, N'D:\Tatvasoft\Project3_tatvasoft\MVC\NotesMarketPlace\NotesMarketPlaceProject\Uploadimg\sample.pdf', 1, CAST(N'2021-04-10T00:51:19.537' AS DateTime), 0, CAST(0 AS Decimal(18, 0)), N'Nueral Network', N'IT', CAST(N'2021-04-10T00:51:19.537' AS DateTime), 3050, CAST(N'2021-04-10T00:51:19.537' AS DateTime), 3050)
INSERT [dbo].[Downloads] ([ID], [NoteID], [Seller], [Downloader], [IsSellerHasAllowedDownload], [AttachmentPath], [IsAttachmentDownloaded], [AttachmentDownloadedDate], [IsPaid], [PurchasedPrice], [NoteTitle], [NoteCategory], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (25, 11, 6, 3050, 1, N'D:\Tatvasoft\Project3_tatvasoft\MVC\NotesMarketPlace\NotesMarketPlaceProject\Uploadimg\DP_20210409185303.pdf', 1, CAST(N'2021-04-10T00:52:44.450' AS DateTime), 0, CAST(0 AS Decimal(18, 0)), N'Computer Networking', N'Computer', CAST(N'2021-04-10T00:52:44.450' AS DateTime), 3050, CAST(N'2021-04-10T00:52:44.450' AS DateTime), 3050)
INSERT [dbo].[Downloads] ([ID], [NoteID], [Seller], [Downloader], [IsSellerHasAllowedDownload], [AttachmentPath], [IsAttachmentDownloaded], [AttachmentDownloadedDate], [IsPaid], [PurchasedPrice], [NoteTitle], [NoteCategory], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (1018, 31, 3052, 3055, 1, N'D:\Tatvasoft\Project3_tatvasoft\MVC\NotesMarketPlace\NotesMarketPlaceProject\Uploadimg\SCN.pdf', 1, CAST(N'2021-04-11T18:35:22.960' AS DateTime), 0, CAST(0 AS Decimal(18, 0)), N'DSA Book', N'CS', CAST(N'2021-04-11T18:35:22.960' AS DateTime), 3055, CAST(N'2021-04-11T18:35:22.960' AS DateTime), 3055)
INSERT [dbo].[Downloads] ([ID], [NoteID], [Seller], [Downloader], [IsSellerHasAllowedDownload], [AttachmentPath], [IsAttachmentDownloaded], [AttachmentDownloadedDate], [IsPaid], [PurchasedPrice], [NoteTitle], [NoteCategory], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (1019, 29, 3, 2028, 1, N'D:\Tatvasoft\Project3_tatvasoft\MVC\NotesMarketPlace\NotesMarketPlaceProject\Uploadimg\XYZ.pdf', 1, CAST(N'2021-04-12T19:56:40.507' AS DateTime), 0, CAST(0 AS Decimal(18, 0)), N'Computer Operating System', N'Computer', CAST(N'2021-04-12T19:56:40.507' AS DateTime), 2028, CAST(N'2021-04-12T19:56:40.507' AS DateTime), 2028)
INSERT [dbo].[Downloads] ([ID], [NoteID], [Seller], [Downloader], [IsSellerHasAllowedDownload], [AttachmentPath], [IsAttachmentDownloaded], [AttachmentDownloadedDate], [IsPaid], [PurchasedPrice], [NoteTitle], [NoteCategory], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (1020, 21, 6, 2028, 1, N'D:\Tatvasoft\Project3_tatvasoft\MVC\NotesMarketPlace\NotesMarketPlaceProject\Uploadimg\MCWC.pdf', 1, CAST(N'2021-04-12T19:57:06.583' AS DateTime), 0, CAST(0 AS Decimal(18, 0)), N'Automobile', N'IT', CAST(N'2021-04-12T19:57:06.583' AS DateTime), 2028, CAST(N'2021-04-12T19:57:06.583' AS DateTime), 2028)
INSERT [dbo].[Downloads] ([ID], [NoteID], [Seller], [Downloader], [IsSellerHasAllowedDownload], [AttachmentPath], [IsAttachmentDownloaded], [AttachmentDownloadedDate], [IsPaid], [PurchasedPrice], [NoteTitle], [NoteCategory], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (1021, 19, 2, 2028, 1, N'D:\Tatvasoft\Project3_tatvasoft\MVC\NotesMarketPlace\NotesMarketPlaceProject\Uploadimg\sample.pdf', 1, CAST(N'2021-04-12T19:57:13.930' AS DateTime), 0, CAST(0 AS Decimal(18, 0)), N'Nueral Network', N'IT', CAST(N'2021-04-12T19:57:13.933' AS DateTime), 2028, CAST(N'2021-04-12T19:57:13.933' AS DateTime), 2028)
INSERT [dbo].[Downloads] ([ID], [NoteID], [Seller], [Downloader], [IsSellerHasAllowedDownload], [AttachmentPath], [IsAttachmentDownloaded], [AttachmentDownloadedDate], [IsPaid], [PurchasedPrice], [NoteTitle], [NoteCategory], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (1022, 18, 2023, 2028, 1, N'D:\Tatvasoft\Project3_tatvasoft\MVC\NotesMarketPlace\NotesMarketPlaceProject\Uploadimg\sample.pdf', 1, CAST(N'2021-04-12T19:57:21.787' AS DateTime), 0, CAST(0 AS Decimal(18, 0)), N'AI', N'IT', CAST(N'2021-04-12T19:57:21.787' AS DateTime), 2028, CAST(N'2021-04-12T19:57:21.787' AS DateTime), 2028)
INSERT [dbo].[Downloads] ([ID], [NoteID], [Seller], [Downloader], [IsSellerHasAllowedDownload], [AttachmentPath], [IsAttachmentDownloaded], [AttachmentDownloadedDate], [IsPaid], [PurchasedPrice], [NoteTitle], [NoteCategory], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (1023, 17, 2023, 3052, 1, N'D:\Tatvasoft\Project3_tatvasoft\MVC\NotesMarketPlace\NotesMarketPlaceProject\Uploadimg\DP_20210409114945.pdf', 1, CAST(N'2021-04-12T19:58:00.153' AS DateTime), 0, CAST(0 AS Decimal(18, 0)), N'Computer Programming', N'IT', CAST(N'2021-04-12T19:58:00.153' AS DateTime), 3052, CAST(N'2021-04-12T19:58:00.153' AS DateTime), 3052)
SET IDENTITY_INSERT [dbo].[Downloads] OFF
GO
SET IDENTITY_INSERT [dbo].[NoteCategories] ON 

INSERT [dbo].[NoteCategories] ([CategoryID], [CategoryName], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (6, N'IT', N'Books Related to IT', CAST(N'2021-03-04T00:00:00.000' AS DateTime), 3055, NULL, NULL, 1)
INSERT [dbo].[NoteCategories] ([CategoryID], [CategoryName], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (7, N'Computer', N'Books Related to Computer field', CAST(N'2021-03-06T10:33:35.127' AS DateTime), 3058, NULL, NULL, 1)
INSERT [dbo].[NoteCategories] ([CategoryID], [CategoryName], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (8, N'MBA', N'Books Of MBA', CAST(N'2021-03-04T00:00:00.000' AS DateTime), 3059, NULL, NULL, 1)
INSERT [dbo].[NoteCategories] ([CategoryID], [CategoryName], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (9, N'CS', N'Books Of CS', CAST(N'2020-11-27T00:12:30.100' AS DateTime), 3060, NULL, NULL, 1)
INSERT [dbo].[NoteCategories] ([CategoryID], [CategoryName], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (1010, N'Commerce', N'It is a books related to commerce', CAST(N'2021-05-07T11:26:34.223' AS DateTime), 3060, CAST(N'2021-04-06T23:54:43.887' AS DateTime), NULL, 0)
INSERT [dbo].[NoteCategories] ([CategoryID], [CategoryName], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (1011, N'Biology', N'Lorem Ipsum', CAST(N'2021-03-30T23:20:52.620' AS DateTime), 3053, NULL, NULL, 1)
INSERT [dbo].[NoteCategories] ([CategoryID], [CategoryName], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (1012, N'CA', N'Lorem Ipsum', CAST(N'2021-03-30T23:26:46.600' AS DateTime), 3053, NULL, NULL, 1)
INSERT [dbo].[NoteCategories] ([CategoryID], [CategoryName], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (1013, N'MBBS', N'Lorem Ipsum', CAST(N'2021-04-06T23:56:32.657' AS DateTime), 3053, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[NoteCategories] OFF
GO
SET IDENTITY_INSERT [dbo].[NoteTypes] ON 

INSERT [dbo].[NoteTypes] ([TypeID], [TypeName], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (1, N'Handwritten', N'Lorem Ipsum Is Simply Dummy Text', CAST(N'2020-12-12T18:33:38.967' AS DateTime), 3055, NULL, NULL, 1)
INSERT [dbo].[NoteTypes] ([TypeID], [TypeName], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (2, N'StoryBook', N'Lorem Ipsum Is Simply Dummy Text', CAST(N'2020-12-12T18:33:38.967' AS DateTime), 3058, CAST(N'2021-04-06T23:41:32.747' AS DateTime), NULL, 0)
INSERT [dbo].[NoteTypes] ([TypeID], [TypeName], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (3, N'University Notes', N'Lorem Ipsum Is Simply Dummy Text', CAST(N'2020-11-27T00:12:30.100' AS DateTime), 3059, NULL, NULL, 1)
INSERT [dbo].[NoteTypes] ([TypeID], [TypeName], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (4, N'Reference Book', N'Lorem Ipsum Is Simply Dummy Text', CAST(N'2020-11-27T00:12:30.100' AS DateTime), 3060, CAST(N'2021-04-06T23:43:11.330' AS DateTime), NULL, 1)
INSERT [dbo].[NoteTypes] ([TypeID], [TypeName], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (6, N'CSS', N'Lorem Ipsum', CAST(N'2021-03-30T18:30:35.037' AS DateTime), 3060, CAST(N'2021-04-06T23:38:09.417' AS DateTime), NULL, 1)
INSERT [dbo].[NoteTypes] ([TypeID], [TypeName], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (7, N'Professor Book', N'Lorem Ipsum', CAST(N'2021-03-30T23:30:41.190' AS DateTime), 3053, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[NoteTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[ReferenceData] ON 

INSERT [dbo].[ReferenceData] ([ID], [Value], [DataValue], [RefCategory], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (1, N'Male', N'M', N'Gender', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[ReferenceData] ([ID], [Value], [DataValue], [RefCategory], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (2, N'Female', N'Fe', N'Gender', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[ReferenceData] ([ID], [Value], [DataValue], [RefCategory], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (3, N'Unknown', N'U', N'Gender', NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[ReferenceData] ([ID], [Value], [DataValue], [RefCategory], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (4, N'Paid', N'P', N'Selling Mode', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[ReferenceData] ([ID], [Value], [DataValue], [RefCategory], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (5, N'Free', N'F', N'Selling Mode', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[ReferenceData] ([ID], [Value], [DataValue], [RefCategory], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (6, N'Draft', N'Draft', N'Notes Status', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[ReferenceData] ([ID], [Value], [DataValue], [RefCategory], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (7, N'Submitted For Review', N'Submitted For Review', N'Notes Status', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[ReferenceData] ([ID], [Value], [DataValue], [RefCategory], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (8, N'InReview', N'InReview', N'Notes Status', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[ReferenceData] ([ID], [Value], [DataValue], [RefCategory], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (9, N'Published', N'Approved', N'Notes Status', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[ReferenceData] ([ID], [Value], [DataValue], [RefCategory], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (10, N'Rejected', N'Rejected', N'Notes Status', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[ReferenceData] ([ID], [Value], [DataValue], [RefCategory], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (11, N'Removed', N'Removed', N'Notes Status', NULL, NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[ReferenceData] OFF
GO
SET IDENTITY_INSERT [dbo].[SellerNotes] ON 

INSERT [dbo].[SellerNotes] ([ID], [SellerID], [Status], [ActionedBy], [AdminRemarks], [PublishedDate], [Title], [Category], [DisplayPicture], [NoteType], [NumberOfPages], [Description], [UniversityName], [Country], [Course], [CourseCode], [Professor], [IsPaid], [SellingPrice], [NotesPreview], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (7, 6, 7, NULL, NULL, NULL, N'CS', 7, N'twitter', 3, 20, N'ghg', NULL, 2, NULL, NULL, NULL, 0, CAST(0 AS Decimal(18, 0)), NULL, CAST(N'2021-03-03T00:42:41.230' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[SellerNotes] ([ID], [SellerID], [Status], [ActionedBy], [AdminRemarks], [PublishedDate], [Title], [Category], [DisplayPicture], [NoteType], [NumberOfPages], [Description], [UniversityName], [Country], [Course], [CourseCode], [Professor], [IsPaid], [SellingPrice], [NotesPreview], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (8, 1012, 8, NULL, NULL, NULL, N'Biomedical ', 7, N'twitter', 1, 20, N'ghg', NULL, 2, N'htht', NULL, N'gfdg', 0, CAST(0 AS Decimal(18, 0)), NULL, CAST(N'2021-03-03T00:43:31.627' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[SellerNotes] ([ID], [SellerID], [Status], [ActionedBy], [AdminRemarks], [PublishedDate], [Title], [Category], [DisplayPicture], [NoteType], [NumberOfPages], [Description], [UniversityName], [Country], [Course], [CourseCode], [Professor], [IsPaid], [SellingPrice], [NotesPreview], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (9, 6, 8, NULL, NULL, NULL, N'IT', 6, N'Thumbs', 2, 0, N'AAA', NULL, 1, N'CS', NULL, NULL, 0, CAST(0 AS Decimal(18, 0)), NULL, CAST(N'2021-03-03T00:52:27.080' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[SellerNotes] ([ID], [SellerID], [Status], [ActionedBy], [AdminRemarks], [PublishedDate], [Title], [Category], [DisplayPicture], [NoteType], [NumberOfPages], [Description], [UniversityName], [Country], [Course], [CourseCode], [Professor], [IsPaid], [SellingPrice], [NotesPreview], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (10, 6, 7, NULL, NULL, NULL, N'ADA', 6, N'SUCCESS', 1, 0, N'This is a handwritten book', N'LJ', 1, N'ICT', NULL, N'Hemali shah', 1, CAST(20 AS Decimal(18, 0)), NULL, CAST(N'2021-03-03T01:03:42.263' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[SellerNotes] ([ID], [SellerID], [Status], [ActionedBy], [AdminRemarks], [PublishedDate], [Title], [Category], [DisplayPicture], [NoteType], [NumberOfPages], [Description], [UniversityName], [Country], [Course], [CourseCode], [Professor], [IsPaid], [SellingPrice], [NotesPreview], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (11, 6, 9, 3053, NULL, CAST(N'2020-12-12T18:33:38.967' AS DateTime), N'Computer Networking', 7, N'6.jpg', 4, 150, N'It is a perfect book.It covers all the concepts ,simple to understand and easy to learn.', N'L.J.', 1, N'IT', NULL, N'Prayag Patel', 0, CAST(0 AS Decimal(18, 0)), N'ABC.pdf', CAST(N'2021-03-03T11:21:32.387' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[SellerNotes] ([ID], [SellerID], [Status], [ActionedBy], [AdminRemarks], [PublishedDate], [Title], [Category], [DisplayPicture], [NoteType], [NumberOfPages], [Description], [UniversityName], [Country], [Course], [CourseCode], [Professor], [IsPaid], [SellingPrice], [NotesPreview], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (12, 6, 9, NULL, NULL, CAST(N'2020-11-27T00:12:30.100' AS DateTime), N'MCWC', 7, N'2.jpg', 2, 32, N'hghj', NULL, 3, N'ICT', NULL, NULL, 0, CAST(0 AS Decimal(18, 0)), NULL, CAST(N'2021-03-03T11:41:53.790' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[SellerNotes] ([ID], [SellerID], [Status], [ActionedBy], [AdminRemarks], [PublishedDate], [Title], [Category], [DisplayPicture], [NoteType], [NumberOfPages], [Description], [UniversityName], [Country], [Course], [CourseCode], [Professor], [IsPaid], [SellingPrice], [NotesPreview], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (13, 6, 11, 3053, N'It is not Appropriate', CAST(N'2021-01-06T01:01:00.220' AS DateTime), N'MPMC', 6, N'3.jpg', 1, 22, N'bgch', NULL, 1, N'ICT', NULL, NULL, 0, CAST(0 AS Decimal(18, 0)), NULL, CAST(N'2021-03-03T11:42:58.700' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[SellerNotes] ([ID], [SellerID], [Status], [ActionedBy], [AdminRemarks], [PublishedDate], [Title], [Category], [DisplayPicture], [NoteType], [NumberOfPages], [Description], [UniversityName], [Country], [Course], [CourseCode], [Professor], [IsPaid], [SellingPrice], [NotesPreview], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (15, 3050, 9, NULL, NULL, CAST(N'2021-05-07T11:26:34.223' AS DateTime), N'Data Science', 7, N'4.jpg', 1, 53, N'Data Science Book', NULL, 1, N'CS', NULL, NULL, 1, CAST(320 AS Decimal(18, 0)), N'ABC.pdf', CAST(N'2021-03-03T14:24:02.630' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[SellerNotes] ([ID], [SellerID], [Status], [ActionedBy], [AdminRemarks], [PublishedDate], [Title], [Category], [DisplayPicture], [NoteType], [NumberOfPages], [Description], [UniversityName], [Country], [Course], [CourseCode], [Professor], [IsPaid], [SellingPrice], [NotesPreview], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (16, 3050, 9, 3053, NULL, CAST(N'2021-03-06T08:30:33.443' AS DateTime), N'Account', 1010, N'5.jpg', 3, 232, N'Accounts Book', NULL, 3, N'B.COM', NULL, NULL, 1, CAST(90 AS Decimal(18, 0)), N'XYZ.pdf', CAST(N'2021-03-03T14:51:36.660' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[SellerNotes] ([ID], [SellerID], [Status], [ActionedBy], [AdminRemarks], [PublishedDate], [Title], [Category], [DisplayPicture], [NoteType], [NumberOfPages], [Description], [UniversityName], [Country], [Course], [CourseCode], [Professor], [IsPaid], [SellingPrice], [NotesPreview], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (17, 2023, 9, NULL, NULL, CAST(N'2021-03-06T10:33:35.127' AS DateTime), N'Computer Programming', 6, N'6.jpg', 1, 0, N'Lorem Ipsum', NULL, 3, NULL, NULL, NULL, 0, CAST(0 AS Decimal(18, 0)), NULL, CAST(N'2021-03-03T15:36:02.713' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[SellerNotes] ([ID], [SellerID], [Status], [ActionedBy], [AdminRemarks], [PublishedDate], [Title], [Category], [DisplayPicture], [NoteType], [NumberOfPages], [Description], [UniversityName], [Country], [Course], [CourseCode], [Professor], [IsPaid], [SellingPrice], [NotesPreview], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (18, 2023, 9, NULL, NULL, CAST(N'2021-02-23T16:30:39.067' AS DateTime), N'AI', 6, N'3.jpg', 1, 0, N'Lorem Ipsum', NULL, 3, NULL, NULL, NULL, 0, CAST(0 AS Decimal(18, 0)), N'sample.pdf', CAST(N'2021-03-03T15:35:55.737' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[SellerNotes] ([ID], [SellerID], [Status], [ActionedBy], [AdminRemarks], [PublishedDate], [Title], [Category], [DisplayPicture], [NoteType], [NumberOfPages], [Description], [UniversityName], [Country], [Course], [CourseCode], [Professor], [IsPaid], [SellingPrice], [NotesPreview], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (19, 2, 9, NULL, NULL, CAST(N'2021-02-23T16:30:39.067' AS DateTime), N'Nueral Network', 6, N'2.jpg', 1, 0, N'Lorem Ipsum', NULL, 3, NULL, NULL, NULL, 0, CAST(0 AS Decimal(18, 0)), N'XYZ.pdf', CAST(N'2021-03-03T15:36:02.713' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[SellerNotes] ([ID], [SellerID], [Status], [ActionedBy], [AdminRemarks], [PublishedDate], [Title], [Category], [DisplayPicture], [NoteType], [NumberOfPages], [Description], [UniversityName], [Country], [Course], [CourseCode], [Professor], [IsPaid], [SellingPrice], [NotesPreview], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (20, 2, 7, NULL, NULL, NULL, N'Autocad', 6, N'4.jpg', 1, 0, N'Lorem Ipsum', NULL, 3, NULL, NULL, NULL, 0, CAST(0 AS Decimal(18, 0)), NULL, CAST(N'2021-03-03T15:36:02.917' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[SellerNotes] ([ID], [SellerID], [Status], [ActionedBy], [AdminRemarks], [PublishedDate], [Title], [Category], [DisplayPicture], [NoteType], [NumberOfPages], [Description], [UniversityName], [Country], [Course], [CourseCode], [Professor], [IsPaid], [SellingPrice], [NotesPreview], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (21, 6, 9, NULL, NULL, CAST(N'2021-02-23T16:30:39.067' AS DateTime), N'Automobile', 6, N'4.jpg', 1, 0, N'Lorem Ipsum', NULL, 3, NULL, NULL, NULL, 0, CAST(0 AS Decimal(18, 0)), NULL, CAST(N'2021-03-03T15:36:05.440' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[SellerNotes] ([ID], [SellerID], [Status], [ActionedBy], [AdminRemarks], [PublishedDate], [Title], [Category], [DisplayPicture], [NoteType], [NumberOfPages], [Description], [UniversityName], [Country], [Course], [CourseCode], [Professor], [IsPaid], [SellingPrice], [NotesPreview], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (22, 2026, 6, NULL, NULL, NULL, N'History', 1010, N'download', 2, 500, N'It is a Book on history', N'L.J.', 4, N'B.COM', NULL, NULL, 0, CAST(0 AS Decimal(18, 0)), N'download', CAST(N'2021-03-06T17:42:47.413' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[SellerNotes] ([ID], [SellerID], [Status], [ActionedBy], [AdminRemarks], [PublishedDate], [Title], [Category], [DisplayPicture], [NoteType], [NumberOfPages], [Description], [UniversityName], [Country], [Course], [CourseCode], [Professor], [IsPaid], [SellingPrice], [NotesPreview], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (23, 2026, 6, NULL, NULL, NULL, N'Account', 1010, N'customer-4', 3, 23, N'Lorem Ipsum', N'ABC', 2, N'master', NULL, N'K.L.SHAH', 0, CAST(0 AS Decimal(18, 0)), N'favicon', CAST(N'2021-03-06T18:33:38.967' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[SellerNotes] ([ID], [SellerID], [Status], [ActionedBy], [AdminRemarks], [PublishedDate], [Title], [Category], [DisplayPicture], [NoteType], [NumberOfPages], [Description], [UniversityName], [Country], [Course], [CourseCode], [Professor], [IsPaid], [SellingPrice], [NotesPreview], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (24, 3050, 6, NULL, NULL, NULL, N'States', 1010, N'seller', 1, 56, N'About states', NULL, 3, NULL, NULL, NULL, 0, CAST(0 AS Decimal(18, 0)), N'Thumbs', CAST(N'2021-03-06T18:37:42.000' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[SellerNotes] ([ID], [SellerID], [Status], [ActionedBy], [AdminRemarks], [PublishedDate], [Title], [Category], [DisplayPicture], [NoteType], [NumberOfPages], [Description], [UniversityName], [Country], [Course], [CourseCode], [Professor], [IsPaid], [SellingPrice], [NotesPreview], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (25, 3, 10, 3053, N'Not good', NULL, N'Mathematics', 8, N'customer-4', 1, 0, N'Lorem Ipsum', N'MSU', 4, NULL, NULL, NULL, 0, CAST(0 AS Decimal(18, 0)), N'sample.pdf', CAST(N'2021-03-06T21:53:19.370' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[SellerNotes] ([ID], [SellerID], [Status], [ActionedBy], [AdminRemarks], [PublishedDate], [Title], [Category], [DisplayPicture], [NoteType], [NumberOfPages], [Description], [UniversityName], [Country], [Course], [CourseCode], [Professor], [IsPaid], [SellingPrice], [NotesPreview], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (26, 3, 9, 3053, N'', CAST(N'2021-04-06T11:28:48.210' AS DateTime), N'Maths Book', 6, N'3.jpg', 2, 0, N'Lorem Ipsum', N'L.J.', 3, N'MATHS', NULL, NULL, 1, CAST(450 AS Decimal(18, 0)), N'sample.pdf', CAST(N'2021-03-06T21:55:04.307' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[SellerNotes] ([ID], [SellerID], [Status], [ActionedBy], [AdminRemarks], [PublishedDate], [Title], [Category], [DisplayPicture], [NoteType], [NumberOfPages], [Description], [UniversityName], [Country], [Course], [CourseCode], [Professor], [IsPaid], [SellingPrice], [NotesPreview], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (29, 3, 9, NULL, NULL, CAST(N'2021-03-06T18:33:38.967' AS DateTime), N'Computer Operating System', 7, N'5.jpg', 3, 0, N'Book On Computer Operating System', N'Adani', 1, N'IT', NULL, NULL, 0, CAST(0 AS Decimal(18, 0)), N'sample.pdf', CAST(N'2021-03-07T16:37:30.160' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[SellerNotes] ([ID], [SellerID], [Status], [ActionedBy], [AdminRemarks], [PublishedDate], [Title], [Category], [DisplayPicture], [NoteType], [NumberOfPages], [Description], [UniversityName], [Country], [Course], [CourseCode], [Professor], [IsPaid], [SellingPrice], [NotesPreview], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (30, 2026, 9, 3053, N'', CAST(N'2021-04-06T11:28:48.210' AS DateTime), N'COA Book', 6, N'2.jpg', 1, 350, N'Computer Science', N'AU', 1, N'IT', NULL, NULL, 1, CAST(350 AS Decimal(18, 0)), N'XYZ.pdf', CAST(N'2021-03-07T16:39:55.467' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[SellerNotes] ([ID], [SellerID], [Status], [ActionedBy], [AdminRemarks], [PublishedDate], [Title], [Category], [DisplayPicture], [NoteType], [NumberOfPages], [Description], [UniversityName], [Country], [Course], [CourseCode], [Professor], [IsPaid], [SellingPrice], [NotesPreview], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (31, 3052, 9, NULL, NULL, CAST(N'2021-03-06T18:33:38.967' AS DateTime), N'DSA Book', 9, N'4.jpg', 3, 250, N'Computer Science Book', N'GEC', 1, N'CS', NULL, NULL, 1, CAST(20 AS Decimal(18, 0)), N'ABC.pdf', CAST(N'2021-03-07T16:44:02.517' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[SellerNotes] ([ID], [SellerID], [Status], [ActionedBy], [AdminRemarks], [PublishedDate], [Title], [Category], [DisplayPicture], [NoteType], [NumberOfPages], [Description], [UniversityName], [Country], [Course], [CourseCode], [Professor], [IsPaid], [SellingPrice], [NotesPreview], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (33, 3, 7, NULL, NULL, NULL, N'Chemical Book', 7, N'6.jpg', 1, 230, N'Book of Data Structure', NULL, 2, N'ADD', N'055', N'xyz', 1, CAST(40 AS Decimal(18, 0)), N'sample.pdf', CAST(N'2021-03-12T00:46:15.203' AS DateTime), NULL, CAST(N'2021-03-25T17:34:32.303' AS DateTime), NULL, 1)
INSERT [dbo].[SellerNotes] ([ID], [SellerID], [Status], [ActionedBy], [AdminRemarks], [PublishedDate], [Title], [Category], [DisplayPicture], [NoteType], [NumberOfPages], [Description], [UniversityName], [Country], [Course], [CourseCode], [Professor], [IsPaid], [SellingPrice], [NotesPreview], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (34, 6, 10, 3053, N'Bad!!!', NULL, N'Civil', 6, N'banner-with-overlay.jpg', 2, 0, N'Lorem Ipsum', NULL, 1, N'M.COM', NULL, NULL, 0, CAST(0 AS Decimal(18, 0)), N'banner-with-overlay.jpg', CAST(N'2021-03-12T00:55:12.430' AS DateTime), NULL, NULL, NULL, 0)
INSERT [dbo].[SellerNotes] ([ID], [SellerID], [Status], [ActionedBy], [AdminRemarks], [PublishedDate], [Title], [Category], [DisplayPicture], [NoteType], [NumberOfPages], [Description], [UniversityName], [Country], [Course], [CourseCode], [Professor], [IsPaid], [SellingPrice], [NotesPreview], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (41, 2, 7, NULL, NULL, NULL, N'CSS', 7, N'DP_20210409131250.png', 1, 23, N'Lorem Ipsum', NULL, 2, N'Neural Network', N'032', N'Lk', 0, CAST(0 AS Decimal(18, 0)), N'DP_20210409131258.pdf', CAST(N'2021-04-09T13:14:01.707' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[SellerNotes] ([ID], [SellerID], [Status], [ActionedBy], [AdminRemarks], [PublishedDate], [Title], [Category], [DisplayPicture], [NoteType], [NumberOfPages], [Description], [UniversityName], [Country], [Course], [CourseCode], [Professor], [IsPaid], [SellingPrice], [NotesPreview], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (46, 2, 7, NULL, NULL, NULL, N'dfdf', 1010, N'DP_20210410134510.jpg', 1, 23, N'fdg', N'vfdx', 2, N'fds', N'fsd', N'fsdfsd', 0, CAST(0 AS Decimal(18, 0)), NULL, CAST(N'2021-04-10T13:45:10.203' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[SellerNotes] ([ID], [SellerID], [Status], [ActionedBy], [AdminRemarks], [PublishedDate], [Title], [Category], [DisplayPicture], [NoteType], [NumberOfPages], [Description], [UniversityName], [Country], [Course], [CourseCode], [Professor], [IsPaid], [SellingPrice], [NotesPreview], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (49, 2, 7, NULL, NULL, NULL, N'dfsdfsdfsdfs', 6, N'DP_20210410140233.png', 1, 32, N'dffsd', N'skcdsj', 3, NULL, NULL, N'dsfds', 1, CAST(92 AS Decimal(18, 0)), N'DP_20210410140233.pdf', CAST(N'2021-04-10T14:02:33.247' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[SellerNotes] ([ID], [SellerID], [Status], [ActionedBy], [AdminRemarks], [PublishedDate], [Title], [Category], [DisplayPicture], [NoteType], [NumberOfPages], [Description], [UniversityName], [Country], [Course], [CourseCode], [Professor], [IsPaid], [SellingPrice], [NotesPreview], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (56, 2028, 7, NULL, NULL, NULL, N'Hardware of computers', 9, N'DP_20210410204333.jpg', 2, 52, N'Helpful Books', N'GU', 2, N'SCVB', N'052', N'Nirav Patel', 1, CAST(520 AS Decimal(18, 0)), N'DP_20210410204333.pdf', CAST(N'2021-04-10T20:43:33.083' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[SellerNotes] ([ID], [SellerID], [Status], [ActionedBy], [AdminRemarks], [PublishedDate], [Title], [Category], [DisplayPicture], [NoteType], [NumberOfPages], [Description], [UniversityName], [Country], [Course], [CourseCode], [Professor], [IsPaid], [SellingPrice], [NotesPreview], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (59, 2, 6, NULL, NULL, NULL, N'seefsag', 6, NULL, 2, 0, N'rhsrbdhbdt', NULL, 2, NULL, NULL, NULL, 0, CAST(0 AS Decimal(18, 0)), NULL, CAST(N'2021-04-11T17:42:55.183' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[SellerNotes] ([ID], [SellerID], [Status], [ActionedBy], [AdminRemarks], [PublishedDate], [Title], [Category], [DisplayPicture], [NoteType], [NumberOfPages], [Description], [UniversityName], [Country], [Course], [CourseCode], [Professor], [IsPaid], [SellingPrice], [NotesPreview], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (62, 3052, 7, NULL, NULL, NULL, N'Computer Operating System and Haedware', 7, N'DP_20210412200019.jpg', 1, 952, N'Helpful Book', N'L.J.', 1, N'COmputer', N'032', N'Nima Jadav', 1, CAST(52 AS Decimal(18, 0)), N'DP_20210412200019.pdf', CAST(N'2021-04-12T20:00:19.120' AS DateTime), NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[SellerNotes] OFF
GO
SET IDENTITY_INSERT [dbo].[SellerNotesAttachments] ON 

INSERT [dbo].[SellerNotesAttachments] ([ID], [NoteID], [FileName], [FilePath], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (1, 21, N'MCWC.pdf', N'D:\Tatvasoft\Project3_tatvasoft\MVC\NotesMarketPlace\NotesMarketPlaceProject\Uploadimg\DP_20210410140233.pdf', CAST(N'2021-03-06T18:37:42.000' AS DateTime), NULL, NULL, NULL, 0)
INSERT [dbo].[SellerNotesAttachments] ([ID], [NoteID], [FileName], [FilePath], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (2, 19, N'sample.pdf', N'D:\Tatvasoft\Project3_tatvasoft\MVC\NotesMarketPlace\NotesMarketPlaceProject\Uploadimg\DP_20210410140233.pdf', CAST(N'2021-03-06T21:53:19.370' AS DateTime), NULL, NULL, NULL, 0)
INSERT [dbo].[SellerNotesAttachments] ([ID], [NoteID], [FileName], [FilePath], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (3, 26, N'Nirma.pdf', N'D:\Tatvasoft\Project3_tatvasoft\MVC\NotesMarketPlace\NotesMarketPlaceProject\Uploadimg\DP_20210410140233.pdf', CAST(N'2021-03-06T21:55:04.307' AS DateTime), NULL, NULL, NULL, 0)
INSERT [dbo].[SellerNotesAttachments] ([ID], [NoteID], [FileName], [FilePath], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (6, 29, N'XYZ.pdf', N'D:\Tatvasoft\Project3_tatvasoft\MVC\NotesMarketPlace\NotesMarketPlaceProject\Uploadimg\DP_20210410140233.pdf', CAST(N'2021-03-07T16:37:30.160' AS DateTime), NULL, NULL, NULL, 0)
INSERT [dbo].[SellerNotesAttachments] ([ID], [NoteID], [FileName], [FilePath], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (7, 30, N'ABC.pdf', N'D:\Tatvasoft\Project3_tatvasoft\MVC\NotesMarketPlace\NotesMarketPlaceProject\Uploadimg\DP_20210410140233.pdf', CAST(N'2021-03-07T16:39:55.467' AS DateTime), NULL, NULL, NULL, 0)
INSERT [dbo].[SellerNotesAttachments] ([ID], [NoteID], [FileName], [FilePath], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (8, 31, N'SCN.pdf', N'D:\Tatvasoft\Project3_tatvasoft\MVC\NotesMarketPlace\NotesMarketPlaceProject\Uploadimg\DP_20210410140233.pdf', CAST(N'2021-03-07T16:44:02.517' AS DateTime), NULL, NULL, NULL, 0)
INSERT [dbo].[SellerNotesAttachments] ([ID], [NoteID], [FileName], [FilePath], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (10, 18, N'sample.pdf', N'D:\Tatvasoft\Project3_tatvasoft\MVC\NotesMarketPlace\NotesMarketPlaceProject\Uploadimg\sample.pdf', CAST(N'2021-03-12T00:46:15.203' AS DateTime), NULL, NULL, NULL, 0)
INSERT [dbo].[SellerNotesAttachments] ([ID], [NoteID], [FileName], [FilePath], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (11, 17, N'DP_20210409114945.pdf', N'D:\Tatvasoft\Project3_tatvasoft\MVC\NotesMarketPlace\NotesMarketPlaceProject\Uploadimg\6.jpg', CAST(N'2021-03-12T00:55:12.430' AS DateTime), NULL, NULL, NULL, 0)
INSERT [dbo].[SellerNotesAttachments] ([ID], [NoteID], [FileName], [FilePath], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (18, 16, N'DP_20210409110900.pdf', N'D:\Tatvasoft\Project3_tatvasoft\MVC\NotesMarketPlace\NotesMarketPlaceProject\Uploadimg\DP_20210410140233.pdf', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[SellerNotesAttachments] ([ID], [NoteID], [FileName], [FilePath], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (19, 15, N'DP_20210409205831.pdf', N'D:\Tatvasoft\Project3_tatvasoft\MVC\NotesMarketPlace\NotesMarketPlaceProject\Uploadimg\DP_20210410140233.pdf', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[SellerNotesAttachments] ([ID], [NoteID], [FileName], [FilePath], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (20, 12, N'DP_20210409131309.pdf', N'D:\Tatvasoft\Project3_tatvasoft\MVC\NotesMarketPlace\NotesMarketPlaceProject\Uploadimg\DP_20210409131309.pdf', CAST(N'2021-04-09T13:14:09.170' AS DateTime), 2, NULL, NULL, 1)
INSERT [dbo].[SellerNotesAttachments] ([ID], [NoteID], [FileName], [FilePath], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (21, 11, N'DP_20210409185303.pdf', N'D:\Tatvasoft\Project3_tatvasoft\MVC\NotesMarketPlace\NotesMarketPlaceProject\Uploadimg\DP_20210409185303.pdf', CAST(N'2021-04-09T18:53:22.273' AS DateTime), 2, NULL, NULL, 1)
INSERT [dbo].[SellerNotesAttachments] ([ID], [NoteID], [FileName], [FilePath], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (1025, 46, N'DP_20210410134510.pdf', N'D:\Tatvasoft\Project3_tatvasoft\MVC\NotesMarketPlace\NotesMarketPlaceProject\Uploadimg\DP_20210410134510.pdf', CAST(N'2021-04-10T13:45:10.230' AS DateTime), 2, NULL, NULL, 1)
INSERT [dbo].[SellerNotesAttachments] ([ID], [NoteID], [FileName], [FilePath], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (1028, 49, N'DP_20210410140233.pdf', N'D:\Tatvasoft\Project3_tatvasoft\MVC\NotesMarketPlace\NotesMarketPlaceProject\Uploadimg\DP_20210410140233.pdf', CAST(N'2021-04-10T14:02:33.247' AS DateTime), 2, NULL, NULL, 1)
INSERT [dbo].[SellerNotesAttachments] ([ID], [NoteID], [FileName], [FilePath], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (1035, 56, N'DP_20210410204333.pdf', N'D:\Tatvasoft\Project3_tatvasoft\MVC\NotesMarketPlace\NotesMarketPlaceProject\Uploadimg\DP_20210410204333.pdf', CAST(N'2021-04-10T20:43:33.120' AS DateTime), 2028, NULL, NULL, 1)
INSERT [dbo].[SellerNotesAttachments] ([ID], [NoteID], [FileName], [FilePath], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (1038, 59, N'DP_20210411174255.pdf', N'D:\Tatvasoft\Project3_tatvasoft\MVC\NotesMarketPlace\NotesMarketPlaceProject\Uploadimg\DP_20210411174255.pdf', CAST(N'2021-04-11T17:42:55.183' AS DateTime), 2, NULL, NULL, 1)
INSERT [dbo].[SellerNotesAttachments] ([ID], [NoteID], [FileName], [FilePath], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (1041, 62, N'DP_20210412200019.pdf', N'D:\Tatvasoft\Project3_tatvasoft\MVC\NotesMarketPlace\NotesMarketPlaceProject\Uploadimg\DP_20210412200019.pdf', CAST(N'2021-04-12T20:00:19.120' AS DateTime), 3052, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[SellerNotesAttachments] OFF
GO
SET IDENTITY_INSERT [dbo].[SellerNotesReportedIssues] ON 

INSERT [dbo].[SellerNotesReportedIssues] ([ID], [NoteID], [ReportedByID], [AgainstDownloadID], [Remarks], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (3, 30, 1012, 4, N'Not useful', CAST(N'2021-03-22T19:17:40.543' AS DateTime), 1012, NULL, NULL)
INSERT [dbo].[SellerNotesReportedIssues] ([ID], [NoteID], [ReportedByID], [AgainstDownloadID], [Remarks], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (4, 31, 2028, 5, N'Bad', CAST(N'2021-03-23T00:19:34.747' AS DateTime), 2028, NULL, NULL)
INSERT [dbo].[SellerNotesReportedIssues] ([ID], [NoteID], [ReportedByID], [AgainstDownloadID], [Remarks], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (5, 26, 2023, 3, N'BAD', CAST(N'2021-03-23T00:20:10.203' AS DateTime), 2023, NULL, NULL)
INSERT [dbo].[SellerNotesReportedIssues] ([ID], [NoteID], [ReportedByID], [AgainstDownloadID], [Remarks], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (1004, 29, 2, 16, N'Not Good', CAST(N'2021-04-10T03:13:18.603' AS DateTime), 2, NULL, NULL)
INSERT [dbo].[SellerNotesReportedIssues] ([ID], [NoteID], [ReportedByID], [AgainstDownloadID], [Remarks], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (1005, 29, 2, 16, N'Not liked', CAST(N'2021-04-10T03:16:45.813' AS DateTime), 2, NULL, NULL)
INSERT [dbo].[SellerNotesReportedIssues] ([ID], [NoteID], [ReportedByID], [AgainstDownloadID], [Remarks], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (2004, 29, 2, 17, N'Not good', CAST(N'2021-04-10T13:30:19.430' AS DateTime), 2, NULL, NULL)
SET IDENTITY_INSERT [dbo].[SellerNotesReportedIssues] OFF
GO
SET IDENTITY_INSERT [dbo].[SellerNotesReviews] ON 

INSERT [dbo].[SellerNotesReviews] ([ID], [NoteID], [ReviewedByID], [AgainstDownloadsID], [Ratings], [Comments], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (1, 11, 1012, 4, CAST(2 AS Decimal(18, 0)), N'Not good', CAST(N'2021-03-23T00:03:49.547' AS DateTime), 1012, NULL, NULL, 0)
INSERT [dbo].[SellerNotesReviews] ([ID], [NoteID], [ReviewedByID], [AgainstDownloadsID], [Ratings], [Comments], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (2, 12, 3050, 2, CAST(4 AS Decimal(18, 0)), N'Good book', CAST(N'2021-03-23T00:16:24.070' AS DateTime), 3050, NULL, NULL, 0)
INSERT [dbo].[SellerNotesReviews] ([ID], [NoteID], [ReviewedByID], [AgainstDownloadsID], [Ratings], [Comments], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (3, 13, 1012, 4, CAST(4 AS Decimal(18, 0)), N'Nice Book', CAST(N'2021-03-23T00:17:11.097' AS DateTime), 1012, NULL, NULL, 0)
INSERT [dbo].[SellerNotesReviews] ([ID], [NoteID], [ReviewedByID], [AgainstDownloadsID], [Ratings], [Comments], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (4, 15, 1012, 10, CAST(5 AS Decimal(18, 0)), N'Awesome book', CAST(N'2021-03-23T00:18:57.673' AS DateTime), 1012, NULL, NULL, 0)
INSERT [dbo].[SellerNotesReviews] ([ID], [NoteID], [ReviewedByID], [AgainstDownloadsID], [Ratings], [Comments], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (1002, 29, 2, 16, CAST(4 AS Decimal(18, 0)), N'Superb Book', CAST(N'2021-04-09T11:21:10.950' AS DateTime), 2, NULL, NULL, 1)
INSERT [dbo].[SellerNotesReviews] ([ID], [NoteID], [ReviewedByID], [AgainstDownloadsID], [Ratings], [Comments], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (1005, 31, 2028, 5, CAST(4 AS Decimal(18, 0)), N'Nice Book', CAST(N'2021-04-12T19:55:46.163' AS DateTime), 2028, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[SellerNotesReviews] OFF
GO
SET IDENTITY_INSERT [dbo].[SystemConfiguration] ON 

INSERT [dbo].[SystemConfiguration] ([ID], [Key], [Value], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (1, N'SupportEmail', N'aaabhavsar022@gmail.com', CAST(N'2021-02-23T16:30:39.067' AS DateTime), 3066, NULL, NULL, 1)
INSERT [dbo].[SystemConfiguration] ([ID], [Key], [Value], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (2, N'EmailAddress', N'shailyjbhavsar@gmail.com', CAST(N'2021-02-23T16:30:39.067' AS DateTime), 3066, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[SystemConfiguration] OFF
GO
SET IDENTITY_INSERT [dbo].[UserProfile] ON 

INSERT [dbo].[UserProfile] ([ID], [UserID], [DOB], [Gender], [SecondaryEmailAddress], [PhoneNumberCountryCOde], [PhoneNumber], [ProfilePicture], [AddressLine1], [AddressLine2], [City], [State], [ZipCode], [Country], [University], [College], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (4, 3050, CAST(N'1999-01-03T00:00:00.000' AS DateTime), 2, NULL, N'+91', N'9067850290', N'customer-1.png', N'Vishwas society', N'Raipur', N'Ahmedabad', N'Gujarat', N'380058', N'India', N'GTU', N'LJ', NULL, NULL, NULL, NULL)
INSERT [dbo].[UserProfile] ([ID], [UserID], [DOB], [Gender], [SecondaryEmailAddress], [PhoneNumberCountryCOde], [PhoneNumber], [ProfilePicture], [AddressLine1], [AddressLine2], [City], [State], [ZipCode], [Country], [University], [College], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (5, 2023, CAST(N'2021-01-03T00:00:00.000' AS DateTime), 2, NULL, N'+91', N'8866201476', N'customer-2.png', N'Vraj society', N'Bopal', N'Ahmedabad', N'Gujarat', N'380059', N'India', N'GTU', N'PDPU', NULL, NULL, NULL, NULL)
INSERT [dbo].[UserProfile] ([ID], [UserID], [DOB], [Gender], [SecondaryEmailAddress], [PhoneNumberCountryCOde], [PhoneNumber], [ProfilePicture], [AddressLine1], [AddressLine2], [City], [State], [ZipCode], [Country], [University], [College], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (6, 1012, CAST(N'2021-01-03T00:00:00.000' AS DateTime), 1, NULL, N'+91', N'9998886010', N'customer-4.png', N'Shivam Apartment', N'Shahpur', N'Ahmedabad', N'Gujarat', N'380001', N'India', N'GU', N'Nirma', NULL, NULL, NULL, NULL)
INSERT [dbo].[UserProfile] ([ID], [UserID], [DOB], [Gender], [SecondaryEmailAddress], [PhoneNumberCountryCOde], [PhoneNumber], [ProfilePicture], [AddressLine1], [AddressLine2], [City], [State], [ZipCode], [Country], [University], [College], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (7, 2028, CAST(N'2021-03-04T00:00:00.000' AS DateTime), 1, NULL, N'+91', N'7082456012', N'DP_20210329_121747.jpg', N'Aarav Society', N's', N's', N's', N's', N'India', N'a', N'a', NULL, NULL, NULL, NULL)
INSERT [dbo].[UserProfile] ([ID], [UserID], [DOB], [Gender], [SecondaryEmailAddress], [PhoneNumberCountryCOde], [PhoneNumber], [ProfilePicture], [AddressLine1], [AddressLine2], [City], [State], [ZipCode], [Country], [University], [College], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (8, 2027, CAST(N'2021-03-31T00:00:00.000' AS DateTime), 2, NULL, N'+91', N'1111111111', N'6.jpg', N'a', N'b', N'c', N'd', N'380012', N'Australia', N'LJ', N'LJ', NULL, NULL, NULL, NULL)
INSERT [dbo].[UserProfile] ([ID], [UserID], [DOB], [Gender], [SecondaryEmailAddress], [PhoneNumberCountryCOde], [PhoneNumber], [ProfilePicture], [AddressLine1], [AddressLine2], [City], [State], [ZipCode], [Country], [University], [College], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (9, 2, CAST(N'1999-12-14T00:00:00.000' AS DateTime), 2, NULL, N'+91', N'7383123456', N'DP_20210329_120726.jpg', N'C - 89', N'Sterling city', N'Ahmedabad', N'Gujarat', N'380058', N'India', N'GTU', N'LJ', NULL, NULL, CAST(N'2021-04-11T18:23:23.633' AS DateTime), 2)
INSERT [dbo].[UserProfile] ([ID], [UserID], [DOB], [Gender], [SecondaryEmailAddress], [PhoneNumberCountryCOde], [PhoneNumber], [ProfilePicture], [AddressLine1], [AddressLine2], [City], [State], [ZipCode], [Country], [University], [College], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (10, 6, CAST(N'1905-05-28T00:00:00.000' AS DateTime), 1, NULL, N'+91', N'9876543210', N'DP_20210328_030410.png', N'Vishwas society', N'Raipur', N'Ahmedabad', N'Gujarat', N'380058', N'India', N'GTU', N'LJ', NULL, NULL, NULL, NULL)
INSERT [dbo].[UserProfile] ([ID], [UserID], [DOB], [Gender], [SecondaryEmailAddress], [PhoneNumberCountryCOde], [PhoneNumber], [ProfilePicture], [AddressLine1], [AddressLine2], [City], [State], [ZipCode], [Country], [University], [College], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (11, 3052, CAST(N'2008-06-12T00:00:00.000' AS DateTime), 2, NULL, N'+91', N'9974801545', N'DP_20210401184014.png', N'Nilam Society', N'DPD Road', N'Baroda', N'Gujarat', N'380051', N'India', N'GTU', N'LJ', NULL, NULL, NULL, NULL)
INSERT [dbo].[UserProfile] ([ID], [UserID], [DOB], [Gender], [SecondaryEmailAddress], [PhoneNumberCountryCOde], [PhoneNumber], [ProfilePicture], [AddressLine1], [AddressLine2], [City], [State], [ZipCode], [Country], [University], [College], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (12, 2026, CAST(N'2009-04-16T00:00:00.000' AS DateTime), 1, NULL, N'+91', N'9727768541', N'DP_20210402011435.png', N'X 301', N'Bapunagar', N'Ahmedabad', N'Gujarat', N'38001', N'India', N'GTU', N'AU', NULL, NULL, NULL, NULL)
INSERT [dbo].[UserProfile] ([ID], [UserID], [DOB], [Gender], [SecondaryEmailAddress], [PhoneNumberCountryCOde], [PhoneNumber], [ProfilePicture], [AddressLine1], [AddressLine2], [City], [State], [ZipCode], [Country], [University], [College], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (14, 3055, NULL, NULL, NULL, N'+91', N'9974801252', NULL, N'Tatvasoft', N'xxx', N'Ahmedabad', N'Gujarat', N'380056', N'India', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserProfile] ([ID], [UserID], [DOB], [Gender], [SecondaryEmailAddress], [PhoneNumberCountryCOde], [PhoneNumber], [ProfilePicture], [AddressLine1], [AddressLine2], [City], [State], [ZipCode], [Country], [University], [College], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (17, 3058, NULL, NULL, NULL, N'+91', N'9908804541', NULL, N'Tatvasoft', N'xxx', N'Ahmedabad', N'Gujarat', N'380056', N'India', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserProfile] ([ID], [UserID], [DOB], [Gender], [SecondaryEmailAddress], [PhoneNumberCountryCOde], [PhoneNumber], [ProfilePicture], [AddressLine1], [AddressLine2], [City], [State], [ZipCode], [Country], [University], [College], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (18, 3059, NULL, NULL, NULL, N'+91', N'9067255850', NULL, N'Tatvasoft', N'xxx', N'Ahmedabad', N'Gujarat', N'380056', N'India', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserProfile] ([ID], [UserID], [DOB], [Gender], [SecondaryEmailAddress], [PhoneNumberCountryCOde], [PhoneNumber], [ProfilePicture], [AddressLine1], [AddressLine2], [City], [State], [ZipCode], [Country], [University], [College], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (19, 3060, NULL, NULL, NULL, N'+91', N'9911526378', NULL, N'Tatvasoft', N'xxx', N'Ahmedabad', N'Gujarat', N'380056', N'India', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserProfile] ([ID], [UserID], [DOB], [Gender], [SecondaryEmailAddress], [PhoneNumberCountryCOde], [PhoneNumber], [ProfilePicture], [AddressLine1], [AddressLine2], [City], [State], [ZipCode], [Country], [University], [College], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (20, 3051, CAST(N'2005-07-08T00:00:00.000' AS DateTime), 1, NULL, N'+91', N'9898525210', N'DP_20210408194430.jpg', N'viha society', N'saraspur', N'Ahmedabad', N'Gujarat', N'320054', N'Canada', N'GU', N'Nirma university', NULL, NULL, NULL, NULL)
INSERT [dbo].[UserProfile] ([ID], [UserID], [DOB], [Gender], [SecondaryEmailAddress], [PhoneNumberCountryCOde], [PhoneNumber], [ProfilePicture], [AddressLine1], [AddressLine2], [City], [State], [ZipCode], [Country], [University], [College], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (21, 4, CAST(N'1999-07-08T00:00:00.000' AS DateTime), 1, NULL, N'+91', N'9000251234', N'DP_20210408195338.jpg', N'SV society', N'Bopal', N'Ahmedabad', N'Gujarat', N'380025', N'India', N'AU', N'AU', CAST(N'2021-04-08T19:53:38.340' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[UserProfile] ([ID], [UserID], [DOB], [Gender], [SecondaryEmailAddress], [PhoneNumberCountryCOde], [PhoneNumber], [ProfilePicture], [AddressLine1], [AddressLine2], [City], [State], [ZipCode], [Country], [University], [College], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (22, 3, CAST(N'1991-01-09T00:00:00.000' AS DateTime), 2, NULL, N'+91', N'9045236352', N'DP_20210409222535.png', N'Vihar society', N'Ghuma', N'Ahmedabad', N'Gujarat', N'38001', N'Canada', N'AU', N'AU', CAST(N'2021-04-09T22:25:35.687' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[UserProfile] ([ID], [UserID], [DOB], [Gender], [SecondaryEmailAddress], [PhoneNumberCountryCOde], [PhoneNumber], [ProfilePicture], [AddressLine1], [AddressLine2], [City], [State], [ZipCode], [Country], [University], [College], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (23, 2024, CAST(N'2008-06-09T00:00:00.000' AS DateTime), 1, NULL, N'+91', N'9874563210', N'DP_20210409222833.png', N'CS-23', N'Bhopal', N'Ahmedabad', N'Gujarat', N'380058', N'United Kingdom', N'GTU', N'L.J.', CAST(N'2021-04-09T22:28:33.397' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[UserProfile] ([ID], [UserID], [DOB], [Gender], [SecondaryEmailAddress], [PhoneNumberCountryCOde], [PhoneNumber], [ProfilePicture], [AddressLine1], [AddressLine2], [City], [State], [ZipCode], [Country], [University], [College], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (24, 2030, CAST(N'2006-02-09T00:00:00.000' AS DateTime), 1, NULL, N'+91', N'9067255980', N'DP_20210409225243.png', N'Anand Nagar', N'Bapunagr', N'Ahmedabad', N'Gujarat', N'380051', N'India', N'GNU', N'AGEC', CAST(N'2021-04-09T22:52:43.527' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[UserProfile] ([ID], [UserID], [DOB], [Gender], [SecondaryEmailAddress], [PhoneNumberCountryCOde], [PhoneNumber], [ProfilePicture], [AddressLine1], [AddressLine2], [City], [State], [ZipCode], [Country], [University], [College], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (1022, 4066, CAST(N'2000-06-07T00:00:00.000' AS DateTime), 2, NULL, N'+91', N'9067255862', N'DP_20210412145308.png', N'Satellite', N'Bopal', N'Ahmedabad', N'Gujarat', N'380021', N'India', N'GTU', N'Adani', CAST(N'2021-04-12T14:53:08.613' AS DateTime), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[UserProfile] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRoles] ON 

INSERT [dbo].[UserRoles] ([ID], [Name], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (6, N'User', N'User', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UserRoles] ([ID], [Name], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (7, N'Admin', N'Admin', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[UserRoles] ([ID], [Name], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (8, N'SuperAdmin', N'Super Admin', NULL, NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[UserRoles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [RoleID], [FirstName], [LastName], [EmailID], [Password], [IsEmailVerified], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (2, 6, N'Shaily', N'Bhavsar', N'shailyjbhavsar@gmail.com', N'Shaily@3103', 1, CAST(N'2021-02-23T16:30:39.067' AS DateTime), 6, CAST(N'2021-02-23T16:30:39.067' AS DateTime), 6, 1)
INSERT [dbo].[Users] ([ID], [RoleID], [FirstName], [LastName], [EmailID], [Password], [IsEmailVerified], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (3, 6, N'Shreya', N'Bhavsar', N'Shreya@gmail.com', N'Shruu@1412', 1, CAST(N'2021-04-07T11:28:48.210' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[Users] ([ID], [RoleID], [FirstName], [LastName], [EmailID], [Password], [IsEmailVerified], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (4, 6, N'Yashesh', N'Bhavsar', N'yasheshbhavsar@gmail.com', N'Yashesh@123', 1, CAST(N'2021-04-07T11:28:48.210' AS DateTime), NULL, NULL, NULL, 0)
INSERT [dbo].[Users] ([ID], [RoleID], [FirstName], [LastName], [EmailID], [Password], [IsEmailVerified], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (6, 6, N'Setu', N'Patel', N'nirefel424@shzsedu.com', N'Sety#4567', 1, CAST(N'2021-04-07T11:28:48.210' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[Users] ([ID], [RoleID], [FirstName], [LastName], [EmailID], [Password], [IsEmailVerified], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (1012, 6, N'Rahi', N'Patel', N'kevicep637@whyflkj.com', N'Shaily@111', 1, CAST(N'2021-02-25T18:32:29.237' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[Users] ([ID], [RoleID], [FirstName], [LastName], [EmailID], [Password], [IsEmailVerified], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (2023, 6, N'Rita', N'Bhavsar', N'170320132005.ict.shaily@gmail.com', N'Abcdf@12345', 1, CAST(N'2021-03-06T11:19:26.570' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[Users] ([ID], [RoleID], [FirstName], [LastName], [EmailID], [Password], [IsEmailVerified], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (2024, 6, N'Nikhil', N'Shah', N'nikhivshah12274@gmail.com', N'Nik#123', 1, CAST(N'2021-03-06T13:28:17.763' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[Users] ([ID], [RoleID], [FirstName], [LastName], [EmailID], [Password], [IsEmailVerified], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (2026, 6, N'Krupa', N'Patel', N'nikhilvshah@gmail.com', N'Nik#23', 1, CAST(N'2021-03-08T00:26:07.160' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[Users] ([ID], [RoleID], [FirstName], [LastName], [EmailID], [Password], [IsEmailVerified], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (2027, 6, N'Nikki', N'Patel', N'nikhilshah4120@gmail.com', N'Shaily&7878', 1, CAST(N'2021-03-08T00:29:04.537' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[Users] ([ID], [RoleID], [FirstName], [LastName], [EmailID], [Password], [IsEmailVerified], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (2028, 6, N'Nikhil', N'Shah', N'todoapp4120@gmail.com', N'Nik@213', 1, CAST(N'2021-03-08T01:30:12.217' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[Users] ([ID], [RoleID], [FirstName], [LastName], [EmailID], [Password], [IsEmailVerified], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (2029, 6, N'Bhavna', N'Bhavsar', N'shailybhavsar@gmail.com', N'Sjb@3103', 1, CAST(N'2021-03-08T01:38:09.173' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[Users] ([ID], [RoleID], [FirstName], [LastName], [EmailID], [Password], [IsEmailVerified], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (2030, 6, N'Nik', N'Shah', N'todoapp4120123@gmail.com', N'Nik@123', 1, CAST(N'2021-03-08T01:42:06.343' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[Users] ([ID], [RoleID], [FirstName], [LastName], [EmailID], [Password], [IsEmailVerified], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (3050, 6, N'Mihir', N'Trivedi', N'marit20840@macosnine.com', N'Xyz#123', 1, CAST(N'2021-03-10T12:09:19.767' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[Users] ([ID], [RoleID], [FirstName], [LastName], [EmailID], [Password], [IsEmailVerified], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (3051, 6, N'Ciroj', N'Shah', N'cirocej456@naymeo.com', N'Ciroj@113', 1, CAST(N'2021-03-14T16:52:03.523' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[Users] ([ID], [RoleID], [FirstName], [LastName], [EmailID], [Password], [IsEmailVerified], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (3052, 6, N'Vishwa', N'Patel', N'sonovi4500@ichkoch.com', N'Sonovi4500@', 1, CAST(N'2021-04-07T11:28:48.210' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[Users] ([ID], [RoleID], [FirstName], [LastName], [EmailID], [Password], [IsEmailVerified], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (3053, 7, N'Nirma', N'Patel', N'hayobe7643@aramidth.com', N'Shrinath#1234', 1, CAST(N'2021-03-06T13:28:17.763' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[Users] ([ID], [RoleID], [FirstName], [LastName], [EmailID], [Password], [IsEmailVerified], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (3055, 7, N'Saurin', N'Dave', N'gefav51502@684hh.com', N'abNLdJig', 0, CAST(N'2021-04-06T17:39:15.467' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[Users] ([ID], [RoleID], [FirstName], [LastName], [EmailID], [Password], [IsEmailVerified], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (3058, 7, N'Mukesh', N'Tanna', N'dasxcvav123@684hh.com', N'QqdnS6Rc', 0, CAST(N'2021-04-06T17:56:11.810' AS DateTime), NULL, CAST(N'2021-04-07T00:22:13.757' AS DateTime), NULL, 1)
INSERT [dbo].[Users] ([ID], [RoleID], [FirstName], [LastName], [EmailID], [Password], [IsEmailVerified], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (3059, 7, N'Nikita', N'Patel', N'xyzshrii@gmail.com', N'3Dx4D1tM', 0, CAST(N'2021-04-06T17:58:54.600' AS DateTime), NULL, NULL, NULL, 0)
INSERT [dbo].[Users] ([ID], [RoleID], [FirstName], [LastName], [EmailID], [Password], [IsEmailVerified], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (3060, 7, N'Krishika', N'Tanna', N'hetif13227@0pppp.com', N'91k6QXkJ', 0, CAST(N'2021-04-06T18:01:48.250' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[Users] ([ID], [RoleID], [FirstName], [LastName], [EmailID], [Password], [IsEmailVerified], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (3061, 6, N'Krishna ', N'Bhavsar', N'darefow278@shzsedu.com', N'Xyz@12345', 1, CAST(N'2021-04-08T15:33:15.253' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[Users] ([ID], [RoleID], [FirstName], [LastName], [EmailID], [Password], [IsEmailVerified], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (3062, 6, N'Dhara ', N'Dudhiya', N'wokiti6449@shzsedu.com', N'Dhara$345', 0, CAST(N'2021-04-08T16:20:47.587' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[Users] ([ID], [RoleID], [FirstName], [LastName], [EmailID], [Password], [IsEmailVerified], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (3063, 6, N'cdsjccdsf', N'fdsf', N'xasda@gmail.com', N'Shai@34', 0, CAST(N'2021-04-08T16:35:54.643' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[Users] ([ID], [RoleID], [FirstName], [LastName], [EmailID], [Password], [IsEmailVerified], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (3064, 6, N'sdkdsaddsa', N'dsd', N'xzcjxz@gmail.com', N'Seee@123', 0, CAST(N'2021-04-08T17:34:33.700' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[Users] ([ID], [RoleID], [FirstName], [LastName], [EmailID], [Password], [IsEmailVerified], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (3066, 8, N'Tatvasoft', N'Tatavasoft', N'laxoxes626@0pppp.com', N'XjMklos', 1, CAST(N'2021-02-23T16:30:39.067' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[Users] ([ID], [RoleID], [FirstName], [LastName], [EmailID], [Password], [IsEmailVerified], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (4065, 6, N'Xyz', N'Njds', N'fireli5238@whyflkj.com', N'SHa@123', 1, CAST(N'2021-04-10T20:27:48.347' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[Users] ([ID], [RoleID], [FirstName], [LastName], [EmailID], [Password], [IsEmailVerified], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (4066, 6, N'Nirali', N'Adeshra', N'gilefo8294@0pppp.com', N'Nirali9080@', 0, CAST(N'2021-04-11T14:42:46.087' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[Users] ([ID], [RoleID], [FirstName], [LastName], [EmailID], [Password], [IsEmailVerified], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (4067, 6, N'Ayushi ', N'Patel', N'poboyi7053@art2427.com', N'Ayuu#456', 1, CAST(N'2021-04-11T14:58:01.347' AS DateTime), NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Country]  WITH CHECK ADD  CONSTRAINT [FK_Country_Users] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Country] CHECK CONSTRAINT [FK_Country_Users]
GO
ALTER TABLE [dbo].[Country]  WITH CHECK ADD  CONSTRAINT [FK_Country_Users1] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Country] CHECK CONSTRAINT [FK_Country_Users1]
GO
ALTER TABLE [dbo].[Downloads]  WITH CHECK ADD  CONSTRAINT [FK_Downloads_SellerNotes] FOREIGN KEY([NoteID])
REFERENCES [dbo].[SellerNotes] ([ID])
GO
ALTER TABLE [dbo].[Downloads] CHECK CONSTRAINT [FK_Downloads_SellerNotes]
GO
ALTER TABLE [dbo].[Downloads]  WITH CHECK ADD  CONSTRAINT [FK_Downloads_Users] FOREIGN KEY([Seller])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Downloads] CHECK CONSTRAINT [FK_Downloads_Users]
GO
ALTER TABLE [dbo].[Downloads]  WITH CHECK ADD  CONSTRAINT [FK_Downloads_Users1] FOREIGN KEY([Downloader])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Downloads] CHECK CONSTRAINT [FK_Downloads_Users1]
GO
ALTER TABLE [dbo].[Downloads]  WITH CHECK ADD  CONSTRAINT [FK_Downloads_Users2] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Downloads] CHECK CONSTRAINT [FK_Downloads_Users2]
GO
ALTER TABLE [dbo].[Downloads]  WITH CHECK ADD  CONSTRAINT [FK_Downloads_Users3] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Downloads] CHECK CONSTRAINT [FK_Downloads_Users3]
GO
ALTER TABLE [dbo].[NoteCategories]  WITH CHECK ADD  CONSTRAINT [FK_NoteCategories_Users] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[NoteCategories] CHECK CONSTRAINT [FK_NoteCategories_Users]
GO
ALTER TABLE [dbo].[NoteCategories]  WITH CHECK ADD  CONSTRAINT [FK_NoteCategories_Users1] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[NoteCategories] CHECK CONSTRAINT [FK_NoteCategories_Users1]
GO
ALTER TABLE [dbo].[NoteTypes]  WITH CHECK ADD  CONSTRAINT [FK_NoteTypes_Users] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[NoteTypes] CHECK CONSTRAINT [FK_NoteTypes_Users]
GO
ALTER TABLE [dbo].[NoteTypes]  WITH CHECK ADD  CONSTRAINT [FK_NoteTypes_Users1] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[NoteTypes] CHECK CONSTRAINT [FK_NoteTypes_Users1]
GO
ALTER TABLE [dbo].[ReferenceData]  WITH CHECK ADD  CONSTRAINT [FK_ReferenceData_Users] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[ReferenceData] CHECK CONSTRAINT [FK_ReferenceData_Users]
GO
ALTER TABLE [dbo].[ReferenceData]  WITH CHECK ADD  CONSTRAINT [FK_ReferenceData_Users1] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[ReferenceData] CHECK CONSTRAINT [FK_ReferenceData_Users1]
GO
ALTER TABLE [dbo].[SellerNotes]  WITH NOCHECK ADD  CONSTRAINT [FK_SellerNotes_Country] FOREIGN KEY([Country])
REFERENCES [dbo].[Country] ([CountryID])
GO
ALTER TABLE [dbo].[SellerNotes] CHECK CONSTRAINT [FK_SellerNotes_Country]
GO
ALTER TABLE [dbo].[SellerNotes]  WITH CHECK ADD  CONSTRAINT [FK_SellerNotes_NoteCategories] FOREIGN KEY([Category])
REFERENCES [dbo].[NoteCategories] ([CategoryID])
GO
ALTER TABLE [dbo].[SellerNotes] CHECK CONSTRAINT [FK_SellerNotes_NoteCategories]
GO
ALTER TABLE [dbo].[SellerNotes]  WITH CHECK ADD  CONSTRAINT [FK_SellerNotes_NoteTypes] FOREIGN KEY([NoteType])
REFERENCES [dbo].[NoteTypes] ([TypeID])
GO
ALTER TABLE [dbo].[SellerNotes] CHECK CONSTRAINT [FK_SellerNotes_NoteTypes]
GO
ALTER TABLE [dbo].[SellerNotes]  WITH CHECK ADD  CONSTRAINT [FK_SellerNotes_ReferenceData] FOREIGN KEY([Status])
REFERENCES [dbo].[ReferenceData] ([ID])
GO
ALTER TABLE [dbo].[SellerNotes] CHECK CONSTRAINT [FK_SellerNotes_ReferenceData]
GO
ALTER TABLE [dbo].[SellerNotes]  WITH CHECK ADD  CONSTRAINT [FK_SellerNotes_Users] FOREIGN KEY([SellerID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[SellerNotes] CHECK CONSTRAINT [FK_SellerNotes_Users]
GO
ALTER TABLE [dbo].[SellerNotes]  WITH CHECK ADD  CONSTRAINT [FK_SellerNotes_Users1] FOREIGN KEY([ActionedBy])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[SellerNotes] CHECK CONSTRAINT [FK_SellerNotes_Users1]
GO
ALTER TABLE [dbo].[SellerNotes]  WITH CHECK ADD  CONSTRAINT [FK_SellerNotes_Users2] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[SellerNotes] CHECK CONSTRAINT [FK_SellerNotes_Users2]
GO
ALTER TABLE [dbo].[SellerNotes]  WITH CHECK ADD  CONSTRAINT [FK_SellerNotes_Users3] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[SellerNotes] CHECK CONSTRAINT [FK_SellerNotes_Users3]
GO
ALTER TABLE [dbo].[SellerNotesAttachments]  WITH CHECK ADD  CONSTRAINT [FK_SellerNotesAttachments_SellerNotes] FOREIGN KEY([NoteID])
REFERENCES [dbo].[SellerNotes] ([ID])
GO
ALTER TABLE [dbo].[SellerNotesAttachments] CHECK CONSTRAINT [FK_SellerNotesAttachments_SellerNotes]
GO
ALTER TABLE [dbo].[SellerNotesAttachments]  WITH CHECK ADD  CONSTRAINT [FK_SellerNotesAttachments_Users] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[SellerNotesAttachments] CHECK CONSTRAINT [FK_SellerNotesAttachments_Users]
GO
ALTER TABLE [dbo].[SellerNotesAttachments]  WITH CHECK ADD  CONSTRAINT [FK_SellerNotesAttachments_Users1] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[SellerNotesAttachments] CHECK CONSTRAINT [FK_SellerNotesAttachments_Users1]
GO
ALTER TABLE [dbo].[SellerNotesReportedIssues]  WITH CHECK ADD  CONSTRAINT [FK_SellerNotesReportedIssues_Downloads] FOREIGN KEY([AgainstDownloadID])
REFERENCES [dbo].[Downloads] ([ID])
GO
ALTER TABLE [dbo].[SellerNotesReportedIssues] CHECK CONSTRAINT [FK_SellerNotesReportedIssues_Downloads]
GO
ALTER TABLE [dbo].[SellerNotesReportedIssues]  WITH CHECK ADD  CONSTRAINT [FK_SellerNotesReportedIssues_SellerNotes] FOREIGN KEY([NoteID])
REFERENCES [dbo].[SellerNotes] ([ID])
GO
ALTER TABLE [dbo].[SellerNotesReportedIssues] CHECK CONSTRAINT [FK_SellerNotesReportedIssues_SellerNotes]
GO
ALTER TABLE [dbo].[SellerNotesReportedIssues]  WITH CHECK ADD  CONSTRAINT [FK_SellerNotesReportedIssues_Users] FOREIGN KEY([ReportedByID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[SellerNotesReportedIssues] CHECK CONSTRAINT [FK_SellerNotesReportedIssues_Users]
GO
ALTER TABLE [dbo].[SellerNotesReportedIssues]  WITH CHECK ADD  CONSTRAINT [FK_SellerNotesReportedIssues_Users1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[SellerNotesReportedIssues] CHECK CONSTRAINT [FK_SellerNotesReportedIssues_Users1]
GO
ALTER TABLE [dbo].[SellerNotesReportedIssues]  WITH CHECK ADD  CONSTRAINT [FK_SellerNotesReportedIssues_Users2] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[SellerNotesReportedIssues] CHECK CONSTRAINT [FK_SellerNotesReportedIssues_Users2]
GO
ALTER TABLE [dbo].[SellerNotesReviews]  WITH CHECK ADD  CONSTRAINT [FK_SellerNotesReviews_SellerNotes] FOREIGN KEY([NoteID])
REFERENCES [dbo].[SellerNotes] ([ID])
GO
ALTER TABLE [dbo].[SellerNotesReviews] CHECK CONSTRAINT [FK_SellerNotesReviews_SellerNotes]
GO
ALTER TABLE [dbo].[SellerNotesReviews]  WITH CHECK ADD  CONSTRAINT [FK_SellerNotesReviews_Users] FOREIGN KEY([ReviewedByID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[SellerNotesReviews] CHECK CONSTRAINT [FK_SellerNotesReviews_Users]
GO
ALTER TABLE [dbo].[SellerNotesReviews]  WITH CHECK ADD  CONSTRAINT [FK_SellerNotesReviews_Users1] FOREIGN KEY([ReviewedByID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[SellerNotesReviews] CHECK CONSTRAINT [FK_SellerNotesReviews_Users1]
GO
ALTER TABLE [dbo].[SellerNotesReviews]  WITH CHECK ADD  CONSTRAINT [FK_SellerNotesReviews_Users2] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[SellerNotesReviews] CHECK CONSTRAINT [FK_SellerNotesReviews_Users2]
GO
ALTER TABLE [dbo].[SellerNotesReviews]  WITH CHECK ADD  CONSTRAINT [FK_SellerNotesReviews_Users3] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[SellerNotesReviews] CHECK CONSTRAINT [FK_SellerNotesReviews_Users3]
GO
ALTER TABLE [dbo].[SystemConfiguration]  WITH CHECK ADD  CONSTRAINT [FK_SystemConfiguration_Users] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[SystemConfiguration] CHECK CONSTRAINT [FK_SystemConfiguration_Users]
GO
ALTER TABLE [dbo].[SystemConfiguration]  WITH CHECK ADD  CONSTRAINT [FK_SystemConfiguration_Users1] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[SystemConfiguration] CHECK CONSTRAINT [FK_SystemConfiguration_Users1]
GO
ALTER TABLE [dbo].[UserProfile]  WITH CHECK ADD  CONSTRAINT [FK_UserProfile_ReferenceData] FOREIGN KEY([Gender])
REFERENCES [dbo].[ReferenceData] ([ID])
GO
ALTER TABLE [dbo].[UserProfile] CHECK CONSTRAINT [FK_UserProfile_ReferenceData]
GO
ALTER TABLE [dbo].[UserProfile]  WITH CHECK ADD  CONSTRAINT [FK_UserProfile_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[UserProfile] CHECK CONSTRAINT [FK_UserProfile_Users]
GO
ALTER TABLE [dbo].[UserProfile]  WITH CHECK ADD  CONSTRAINT [FK_UserProfile_Users1] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[UserProfile] CHECK CONSTRAINT [FK_UserProfile_Users1]
GO
ALTER TABLE [dbo].[UserProfile]  WITH CHECK ADD  CONSTRAINT [FK_UserProfile_Users2] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[UserProfile] CHECK CONSTRAINT [FK_UserProfile_Users2]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_UserRoles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[UserRoles] ([ID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_UserRoles]
GO
/****** Object:  StoredProcedure [dbo].[NewGetSellerNotesDetails]    Script Date: 12-04-2021 20:12:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[NewGetSellerNotesDetails]
--declare
@FK_Type int = 0,
@FK_Category int = 0,
@FK_Country int = 0,
@FK_University nvarchar(200) = null,
@FK_Course nvarchar(200) = null,
@FK_Rating decimal=0,
@PageSize INT = 9,
@PageNumber INT = 1,
@Search nvarchar(200) = null
As 
Begin 
	SELECT S.ID,S.SellerID,S.DisplayPicture,S.Title,S.Category,S.Country,S.CreatedDate,S.UniversityName,S.NumberOfPages,S.PublishedDate,(SELECT C.CountryName FROM Country AS C WHERE C.CountryID = S.Country) AS CountyName,
	(SELECT COUNT(SN.ID) FROM SellerNotes AS SN 
		LEFT JOIN 
		(
		SELECT AVG(NVN.ratings) AS RatingNew,NVN.NoteID FROM [dbo].[SellerNotesReviews] AS NVN GROUP BY NVN.NoteID
		) AS DSN
		ON SN.ID = DSN.NoteID
		WHERE (SN.NoteType = @FK_Type OR @FK_Type = 0) AND (SN.Title like '%'+@Search+'%' OR  @Search is null ) AND (SN.Category = @FK_Category OR @FK_Category = 0)
			And (SN.Country = @FK_Country OR @FK_Country = 0) AND (SN.UniversityName = @FK_University OR @FK_University is null)
			And (SN.Course = @FK_Course OR @FK_Course is null) AND (DSN.RatingNew >= @FK_Rating OR @FK_Rating = 0) AND (Status = (select id from ReferenceData
			where Value = 'Published'))) AS TotalCount,DM.Report,DS.Rating,DS.TotalRating from SellerNotes AS S
	LEFT JOIN 
	(
	SELECT COUNT(NR.NoteID) AS Report,NR.NoteID FROM [dbo].[SellerNotesReportedIssues] AS NR GROUP BY NR.NoteID
	) AS DM
	ON S.ID = DM.NoteID
	LEFT JOIN 
	(
	SELECT AVG(NV.ratings) AS Rating, COUNT(NV.Ratings) As TotalRating,NV.NoteID FROM [dbo].[SellerNotesReviews] AS NV GROUP BY NV.NoteID
	) AS DS
	ON S.ID = DS.NoteID
	 WHERE (S.NoteType = @FK_Type OR @FK_Type = 0) AND (S.Category = @FK_Category OR @FK_Category = 0)
			and (S.Title like '%'+@Search+'%' OR  @Search is null )
			And (S.Country = @FK_Country OR @FK_Country = 0) AND (S.UniversityName = @FK_University OR @FK_University is null)
			And (S.Course = @FK_Course OR @FK_Course is null) AND(DS.Rating >= @FK_Rating OR @FK_Rating = 0) AND (Status = (select id from ReferenceData where Value = 'Published'))
	ORDER BY S.ID DESC
	OFFSET (@PageNumber - 1) * @PageSize ROWS
	FETCH NEXT @PageSize ROWS ONLY

End
GO
USE [master]
GO
ALTER DATABASE [NotesMarketPlaceTables] SET  READ_WRITE 
GO
