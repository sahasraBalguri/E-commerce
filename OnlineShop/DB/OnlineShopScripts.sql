USE [master]
GO
/****** Object:  Database [OnlineShop]    Script Date: 18-04-2023 11.10.36 PM ******/
CREATE DATABASE [OnlineShop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OnlineShop', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\OnlineShop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OnlineShop_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\OnlineShop_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [OnlineShop] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OnlineShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OnlineShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OnlineShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OnlineShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OnlineShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OnlineShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [OnlineShop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OnlineShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OnlineShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OnlineShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OnlineShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OnlineShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OnlineShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OnlineShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OnlineShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OnlineShop] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OnlineShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OnlineShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OnlineShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OnlineShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OnlineShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OnlineShop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OnlineShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OnlineShop] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [OnlineShop] SET  MULTI_USER 
GO
ALTER DATABASE [OnlineShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OnlineShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OnlineShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OnlineShop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OnlineShop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OnlineShop] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [OnlineShop] SET QUERY_STORE = ON
GO
ALTER DATABASE [OnlineShop] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [OnlineShop]
GO
/****** Object:  User [devuser]    Script Date: 18-04-2023 11.10.36 PM ******/
CREATE USER [devuser] FOR LOGIN [devuser] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  UserDefinedTableType [dbo].[OrderDetailsList]    Script Date: 18-04-2023 11.10.36 PM ******/
CREATE TYPE [dbo].[OrderDetailsList] AS TABLE(
	[OrderId] [int] NULL,
	[PorductId] [int] NULL
)
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[Discriminator] [nvarchar](max) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[PorductId] [int] NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderNo] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NOT NULL,
	[PhoneNo] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[OrderDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Image] [nvarchar](max) NULL,
	[ProductColor] [nvarchar](max) NULL,
	[IsAvailable] [bit] NOT NULL,
	[ProductTypeId] [int] NOT NULL,
	[SpecialTagId] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductTypes]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductType] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ProductTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SpecialTags]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SpecialTags](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SpecialTag] [nvarchar](max) NULL,
 CONSTRAINT [PK_SpecialTags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'1', N'Super user', N'Super user', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'2', N'User', N'User', NULL)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'700c89f7-6f99-4513-b193-09253a28cea9', N'1')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8151cd9b-6c13-409e-bc57-f3d9bab3d133', N'1')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c24b3055-18e4-42d1-a95e-b2e3c21989cc', N'1')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'093e9bbd-7be6-4e42-89bf-bfab6dbba564', N'2')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3fa2d972-c182-4518-a34b-d1f27628a0f5', N'2')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'42baf962-3280-457f-82c4-13bb289edc5f', N'2')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'97bd8f35-72f2-4af8-bc9a-56e8958cc40f', N'2')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a4cb9043-6592-4c4a-b738-9e23088e4130', N'2')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f02886db-5051-4898-86a5-ea57a77c4e84', N'2')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Discriminator], [FirstName], [LastName]) VALUES (N'093e9bbd-7be6-4e42-89bf-bfab6dbba564', N'sarvesh@gmail.com', N'SARVESH@GMAIL.COM', N'sarvesh@gmail.com', N'SARVESH@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEJV3S1tyEsuHYZjzDQSflYWB1erucjnvDTA35l521WMkeoUnQAYIDBv4Sj1QktfY/A==', N'7XQIZUD6TUFCHILEBRO4L373RBM5LU2N', N'b5330a9c-aa78-4b72-af1a-1be1682dca60', NULL, 0, 0, NULL, 1, 0, N'', NULL, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Discriminator], [FirstName], [LastName]) VALUES (N'3fa2d972-c182-4518-a34b-d1f27628a0f5', N'jayesh4@gmail.com', N'JAYESH4@GMAIL.COM', N'jayesh4@gmail.com', N'JAYESH4@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEEoxOqmSBnZ6ZZ6fpSaDVHxjzuF4438xISHPtPPJ0kGCxS0NaGDqfPCx5EB1FQ2JBg==', N'5XK5SJLHZWTVQQN4MWTJGYM5MDJBPHLL', N'dcc17463-dc4a-4765-b885-fc89a235261d', NULL, 0, 0, NULL, 1, 0, N'', NULL, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Discriminator], [FirstName], [LastName]) VALUES (N'42baf962-3280-457f-82c4-13bb289edc5f', N'jayesh@gmail.com', N'JAYESH@GMAIL.COM', N'', N'', 0, N'Jayesh@123', N'1d15a7f2-aac0-47fe-83c3-215275af784f', N'1cf2e4a3-c1da-4ff1-834d-df7fdd447524', N'', 0, 0, CAST(N'2023-04-14T17:13:53.3566667+00:00' AS DateTimeOffset), 1, 0, N'', N'Jayesh', N'Mahadik')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Discriminator], [FirstName], [LastName]) VALUES (N'700c89f7-6f99-4513-b193-09253a28cea9', N'sai@gmail.com', N'SAI@GMAIL.COM', N'sai@gmail.com', N'SAI@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEEcOBD0dvEHIPfBN7Ny7YfJEScHhhIjEJUb/7VAhITZNqihaourfApFQkogR+0ekJw==', N'ZBKOVUEVMCCUS2YWV3WBY4M4OMMCB3AZ', N'ef222588-16fd-463b-9abe-640bf2a339c3', NULL, 0, 0, NULL, 1, 0, N'', NULL, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Discriminator], [FirstName], [LastName]) VALUES (N'8151cd9b-6c13-409e-bc57-f3d9bab3d133', N'admin@gmail.com', N'ADMIN@GMAIL.COM', NULL, NULL, 0, N'AQAAAAEAACcQAAAAEIZfV1ljsNz8Yqy1bWtPZ6IzQhbxo1KUdj31iQX0lUZPr1orM1d6p+oSU4qdrDbTrA==', N'3TPBN4CBI3OSFJ6AMLUOMAJLEDBXWHCV', N'd65a3d98-8f7c-4114-b516-2ba97b6fc3c9', NULL, 0, 0, NULL, 1, 0, N'ApplicationUser', N'Jayesh', N'Mahadik')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Discriminator], [FirstName], [LastName]) VALUES (N'97bd8f35-72f2-4af8-bc9a-56e8958cc40f', N'jayesh2@gmail.com', N'JAYESH2@GMAIL.COM', NULL, NULL, 0, N'AQAAAAEAACcQAAAAEFm60w+obuvURgBHj8nxGEsaLEuzEFSlJmjQ1ztHGFfs816QrIbzZHWYXkYjCsBztQ==', N'VQO6CJXZKD3LABVWSTRCGFROV5LQKKTS', N'ee37c658-3280-4650-9275-f6976092f2e2', NULL, 0, 0, NULL, 1, 0, N'', NULL, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Discriminator], [FirstName], [LastName]) VALUES (N'a4cb9043-6592-4c4a-b738-9e23088e4130', N'sarvesh1@gmail.com', N'SARVESH1@GMAIL.COM', N'sarvesh1@gmail.com', N'SARVESH1@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEKZOfkzOT5dXraMtJoTWDToOrE1fGWgLihbHzWWaiTC6owcJQU+2zqZq9BUzPGzisg==', N'XXBYWGY6SCZGAA2URW4CCXJNVOTG4ZLD', N'ea4a899f-fcf5-403d-9527-733c07546161', NULL, 0, 0, NULL, 1, 0, N'', NULL, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Discriminator], [FirstName], [LastName]) VALUES (N'c24b3055-18e4-42d1-a95e-b2e3c21989cc', N'jayesh3@gmail.com', N'JAYESH3@GMAIL.COM', NULL, NULL, 1, N'AQAAAAEAACcQAAAAEOCryUvVoEk77UIePWeU4moO5moCevhUcLoDn0+Y26/p+sXnQvk7EsxPdnkUOvNjiw==', N'6PFF7LB7GWAY3D5QH3UT5G4WI6RSBJAU', N'1e8a97d2-9b38-4b34-8515-64258d256cab', NULL, 0, 0, NULL, 1, 0, N'', N'Jayesh', N'Mahadik')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Discriminator], [FirstName], [LastName]) VALUES (N'f02886db-5051-4898-86a5-ea57a77c4e84', N'jayesh1@gmail.com', N'JAYESH1@GMAIL.COM', NULL, NULL, 0, N'AQAAAAEAACcQAAAAEKkiOIcP72KvTSCsTTRkW/ix+6n7ZmESqaZrvfMV1qIrgnIKKH9kJQHW5AmYUHhRRg==', N'OU7T66DYM7RNLVGC4W2TVV3WZ2KOJITO', N'8c1fb725-664d-4250-a8e9-ec04d47d7d5f', NULL, 0, 0, NULL, 1, 0, N'', N'Jayesh', N'Mahadik')
GO
SET IDENTITY_INSERT [dbo].[OrderDetails] ON 

INSERT [dbo].[OrderDetails] ([Id], [OrderId], [PorductId]) VALUES (1, 4, 2)
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [PorductId]) VALUES (2, 4, 10)
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [PorductId]) VALUES (3, 5, 2)
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [PorductId]) VALUES (4, 5, 10)
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [PorductId]) VALUES (5, 6, 1)
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [PorductId]) VALUES (6, 6, 2)
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [PorductId]) VALUES (7, 7, 1)
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [PorductId]) VALUES (8, 7, 7)
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [PorductId]) VALUES (9, 9, 1)
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [PorductId]) VALUES (10, 9, 7)
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [PorductId]) VALUES (11, 10, 2)
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [PorductId]) VALUES (12, 10, 9)
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [PorductId]) VALUES (13, 11, 3)
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [PorductId]) VALUES (14, 11, 9)
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [PorductId]) VALUES (15, 12, 5)
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [PorductId]) VALUES (16, 13, 8)
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [PorductId]) VALUES (17, 14, 5)
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [PorductId]) VALUES (18, 14, 6)
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Id], [OrderNo], [Name], [PhoneNo], [Email], [Address], [OrderDate]) VALUES (1, N'Test Test Test', N'Test Test Test', N'999999999', N'test@test.com', N'Test Apartment, Sector 19, Test', CAST(N'2023-04-13T22:56:01.4966667' AS DateTime2))
INSERT [dbo].[Orders] ([Id], [OrderNo], [Name], [PhoneNo], [Email], [Address], [OrderDate]) VALUES (2, N'002', N'Test Test Test', N'999999999', N'test@test.com', N'Test Apartment, Sector 19, Test', CAST(N'2023-04-14T00:00:34.7600000' AS DateTime2))
INSERT [dbo].[Orders] ([Id], [OrderNo], [Name], [PhoneNo], [Email], [Address], [OrderDate]) VALUES (3, N'003', N'Test Test Test', N'999999999', N'test@test.com', N'Test Apartment, Sector 19, Test', CAST(N'2023-04-14T00:15:13.9000000' AS DateTime2))
INSERT [dbo].[Orders] ([Id], [OrderNo], [Name], [PhoneNo], [Email], [Address], [OrderDate]) VALUES (4, N'004', N'Test Test Test', N'999999999', N'test@test.com', N'Test Apartment, Sector 19, Test', CAST(N'2023-04-14T00:16:56.6100000' AS DateTime2))
INSERT [dbo].[Orders] ([Id], [OrderNo], [Name], [PhoneNo], [Email], [Address], [OrderDate]) VALUES (5, N'005', N'Test Test Test', N'999999999', N'test@test.com', N'Test Apartment, Sector 19, Test', CAST(N'2023-04-14T00:17:07.5266667' AS DateTime2))
INSERT [dbo].[Orders] ([Id], [OrderNo], [Name], [PhoneNo], [Email], [Address], [OrderDate]) VALUES (6, N'006', N'Test Test Test', N'999999999', N'test@test.com', N'Test Apartment, Sector 19, Test', CAST(N'2023-04-14T00:18:36.8533333' AS DateTime2))
INSERT [dbo].[Orders] ([Id], [OrderNo], [Name], [PhoneNo], [Email], [Address], [OrderDate]) VALUES (7, N'007', N'Test Test Test', N'999999999', N'test@test.com', N'Test Apartment, Sector 19, Test', CAST(N'2023-04-15T22:49:06.0766667' AS DateTime2))
INSERT [dbo].[Orders] ([Id], [OrderNo], [Name], [PhoneNo], [Email], [Address], [OrderDate]) VALUES (8, N'008', N'Test Test Test', N'999999999', N'test@test.com', N'Test Apartment, Sector 19, Test', CAST(N'2023-04-15T22:49:35.7500000' AS DateTime2))
INSERT [dbo].[Orders] ([Id], [OrderNo], [Name], [PhoneNo], [Email], [Address], [OrderDate]) VALUES (9, N'009', N'Test Test Test', N'999999999', N'test@test.com', N'Test Apartment, Sector 19, Test', CAST(N'2023-04-15T22:50:41.3533333' AS DateTime2))
INSERT [dbo].[Orders] ([Id], [OrderNo], [Name], [PhoneNo], [Email], [Address], [OrderDate]) VALUES (10, N'010', N'Sarvesh', N'999999999', N'test@test.com', N'Test Apartment, Sector 19, Test', CAST(N'2023-04-16T19:48:33.2000000' AS DateTime2))
INSERT [dbo].[Orders] ([Id], [OrderNo], [Name], [PhoneNo], [Email], [Address], [OrderDate]) VALUES (11, N'011', N'Sarvesh', N'999999999', N'test@test.com', N'Test Apartment, Sector 19, Test', CAST(N'2023-04-16T19:55:08.4300000' AS DateTime2))
INSERT [dbo].[Orders] ([Id], [OrderNo], [Name], [PhoneNo], [Email], [Address], [OrderDate]) VALUES (12, N'012', N'Sarvesh', N'999999999', N'test@test.com', N'Test Apartment, Sector 19, Test', CAST(N'2023-04-16T21:57:21.9333333' AS DateTime2))
INSERT [dbo].[Orders] ([Id], [OrderNo], [Name], [PhoneNo], [Email], [Address], [OrderDate]) VALUES (13, N'013', N'tes', N'999999999', N'test@test.com', N'Test Apartment, Sector 19, Test', CAST(N'2023-04-17T16:33:13.9633333' AS DateTime2))
INSERT [dbo].[Orders] ([Id], [OrderNo], [Name], [PhoneNo], [Email], [Address], [OrderDate]) VALUES (14, N'014', N'Test Test Test', N'999999999', N'test@test.com', N'Test Apartment, Sector 19, Test', CAST(N'2023-04-18T21:48:31.0666667' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Name], [Price], [Image], [ProductColor], [IsAvailable], [ProductTypeId], [SpecialTagId]) VALUES (1, N'Kurta', CAST(1000.00 AS Decimal(18, 2)), N'Images/Kurta.jfif', N'Red', 1, 1, 1)
INSERT [dbo].[Products] ([Id], [Name], [Price], [Image], [ProductColor], [IsAvailable], [ProductTypeId], [SpecialTagId]) VALUES (2, N'Dell Pression 5510', CAST(220000.00 AS Decimal(18, 2)), N'Images/Apple.jfif', N'Gray', 1, 1, 1)
INSERT [dbo].[Products] ([Id], [Name], [Price], [Image], [ProductColor], [IsAvailable], [ProductTypeId], [SpecialTagId]) VALUES (3, N'Dell Pression 5510', CAST(220000.00 AS Decimal(18, 2)), N'Images/Apple_MacBook-Pro_14-16-inch_10182021_big.jpg.slideshow-large.jpg', N'Gray', 1, 1, 1)
INSERT [dbo].[Products] ([Id], [Name], [Price], [Image], [ProductColor], [IsAvailable], [ProductTypeId], [SpecialTagId]) VALUES (5, N'Apple Macbook', CAST(200000.00 AS Decimal(18, 2)), N'Images/Apple_MacBook-Pro_14-16-inch_10182021_big.jpg.slideshow-large.jpg', N'Grey', 1, 1, 1)
INSERT [dbo].[Products] ([Id], [Name], [Price], [Image], [ProductColor], [IsAvailable], [ProductTypeId], [SpecialTagId]) VALUES (6, N'I Phone 10', CAST(111111.00 AS Decimal(18, 2)), N'Images/iphone.jfif', N'Grey', 1, 3, 2)
INSERT [dbo].[Products] ([Id], [Name], [Price], [Image], [ProductColor], [IsAvailable], [ProductTypeId], [SpecialTagId]) VALUES (7, N'I Phone 11', CAST(10000.00 AS Decimal(18, 2)), N'Images/iphone - Copy.jfif', N'Grey', 1, 2, 3)
INSERT [dbo].[Products] ([Id], [Name], [Price], [Image], [ProductColor], [IsAvailable], [ProductTypeId], [SpecialTagId]) VALUES (8, N'I Phone 12', CAST(200000.00 AS Decimal(18, 2)), N'Images/iphone - Copy - Copy.jfif', N'Grey', 1, 3, 2)
INSERT [dbo].[Products] ([Id], [Name], [Price], [Image], [ProductColor], [IsAvailable], [ProductTypeId], [SpecialTagId]) VALUES (9, N'I Phone 13', CAST(200000.00 AS Decimal(18, 2)), N'Images/iphone13.jfif', N'Grey', 1, 2, 2)
INSERT [dbo].[Products] ([Id], [Name], [Price], [Image], [ProductColor], [IsAvailable], [ProductTypeId], [SpecialTagId]) VALUES (10, N'I Phone 14', CAST(200000.00 AS Decimal(18, 2)), N'Images/iphone13 - Copy.jfif', N'Grey', 1, 3, 2)
INSERT [dbo].[Products] ([Id], [Name], [Price], [Image], [ProductColor], [IsAvailable], [ProductTypeId], [SpecialTagId]) VALUES (11, N'I Phone 15', CAST(10000.00 AS Decimal(18, 2)), N'Images/iphone15.jfif', N'Grey', 1, 3, 2)
INSERT [dbo].[Products] ([Id], [Name], [Price], [Image], [ProductColor], [IsAvailable], [ProductTypeId], [SpecialTagId]) VALUES (12, N'Apple Macbook 2', CAST(200000.00 AS Decimal(18, 2)), N'Images/dell-long-term-test-5510.jpg', N'Grey', 1, 1, 1)
INSERT [dbo].[Products] ([Id], [Name], [Price], [Image], [ProductColor], [IsAvailable], [ProductTypeId], [SpecialTagId]) VALUES (13, N'Nike AJ', CAST(10000.00 AS Decimal(18, 2)), N'Images/iphone13.jfif', N'White', 1, 14, 5)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductTypes] ON 

INSERT [dbo].[ProductTypes] ([Id], [ProductType]) VALUES (1, N'Traditional Wear')
INSERT [dbo].[ProductTypes] ([Id], [ProductType]) VALUES (2, N'Phone')
INSERT [dbo].[ProductTypes] ([Id], [ProductType]) VALUES (3, N'Mobile')
INSERT [dbo].[ProductTypes] ([Id], [ProductType]) VALUES (14, N'Shoes')
SET IDENTITY_INSERT [dbo].[ProductTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[SpecialTags] ON 

INSERT [dbo].[SpecialTags] ([Id], [SpecialTag]) VALUES (1, N'Laptop')
INSERT [dbo].[SpecialTags] ([Id], [SpecialTag]) VALUES (2, N'Mobile')
INSERT [dbo].[SpecialTags] ([Id], [SpecialTag]) VALUES (3, N'Phone')
INSERT [dbo].[SpecialTags] ([Id], [SpecialTag]) VALUES (5, N'Sneakers')
SET IDENTITY_INSERT [dbo].[SpecialTags] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 18-04-2023 11.10.36 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 18-04-2023 11.10.36 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 18-04-2023 11.10.36 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 18-04-2023 11.10.36 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 18-04-2023 11.10.36 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 18-04-2023 11.10.36 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 18-04-2023 11.10.36 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderDetails_OrderId]    Script Date: 18-04-2023 11.10.36 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderDetails_OrderId] ON [dbo].[OrderDetails]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderDetails_PorductId]    Script Date: 18-04-2023 11.10.36 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderDetails_PorductId] ON [dbo].[OrderDetails]
(
	[PorductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_ProductTypeId]    Script Date: 18-04-2023 11.10.36 PM ******/
CREATE NONCLUSTERED INDEX [IX_Products_ProductTypeId] ON [dbo].[Products]
(
	[ProductTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_SpecialTagId]    Script Date: 18-04-2023 11.10.36 PM ******/
CREATE NONCLUSTERED INDEX [IX_Products_SpecialTagId] ON [dbo].[Products]
(
	[SpecialTagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  CONSTRAINT [DF__AspNetUse__Discr__5EBF139D]  DEFAULT (N'') FOR [Discriminator]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders_OrderId]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Products_PorductId] FOREIGN KEY([PorductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Products_PorductId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_ProductTypes_ProductTypeId] FOREIGN KEY([ProductTypeId])
REFERENCES [dbo].[ProductTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_ProductTypes_ProductTypeId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_SpecialTags_SpecialTagId] FOREIGN KEY([SpecialTagId])
REFERENCES [dbo].[SpecialTags] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_SpecialTags_SpecialTagId]
GO
/****** Object:  StoredProcedure [dbo].[USP_Activate_User]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[USP_Activate_User]
@Id Nvarchar(max),
@ApplicationIDout NVARCHAR(200) output
As
Begin
	Declare @ActualRowsAffected int
	If Exists(Select * from AspNetUsers where Id=@Id)
		Begin
			Update AspNetUsers set LockoutEnd = GETDATE() - 1 where Id=@Id			
		End
	set @ActualRowsAffected =@@ROWCOUNT	
	SET  @ApplicationIDout =(CONVERT(varchar,@ActualRowsAffected))
	select @ApplicationIDout;
End
GO
/****** Object:  StoredProcedure [dbo].[USP_DELETE_Product]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[USP_DELETE_Product]
@Id int,
@ApplicationIDout NVARCHAR(200) output
As
Begin
	Declare @ActualRowsAffected int
	If Exists(Select * from Products where Id=@Id)
		Begin
			Delete From Products where Id=@Id
		End
	set @ActualRowsAffected =@@ROWCOUNT	
	SET  @ApplicationIDout =(CONVERT(varchar,@ActualRowsAffected))
	select @ApplicationIDout;
End
GO
/****** Object:  StoredProcedure [dbo].[USP_DELETE_ProductTypes]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[USP_DELETE_ProductTypes]
@Id int,
@ApplicationIDout NVARCHAR(200) output
As
Begin
	Declare @ActualRowsAffected int
	If Exists(Select * from ProductTypes where Id=@Id)
		Begin
			Delete From ProductTypes where Id=@Id
		End
	set @ActualRowsAffected =@@ROWCOUNT	
	SET  @ApplicationIDout =(CONVERT(varchar,@ActualRowsAffected))
	select @ApplicationIDout;
End
GO
/****** Object:  StoredProcedure [dbo].[USP_DELETE_SpecialTags]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[USP_DELETE_SpecialTags]
@Id int,
@ApplicationIDout NVARCHAR(200) output
As
Begin
	Declare @ActualRowsAffected int
	If Exists(Select * from SpecialTags where Id=@Id)
		Begin
			Delete From SpecialTags where Id=@Id
		End
	set @ActualRowsAffected =@@ROWCOUNT	
	SET  @ApplicationIDout =(CONVERT(varchar,@ActualRowsAffected))
	select @ApplicationIDout;
End
GO
/****** Object:  StoredProcedure [dbo].[USP_DELETE_User]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[USP_DELETE_User]
@Id Nvarchar(max),
@ApplicationIDout NVARCHAR(200) output
As
Begin
	Declare @ActualRowsAffected int
	If Exists(Select * from AspNetUsers where Id=@Id)
		Begin
			Delete From AspNetUsers where Id=@Id
			Delete From AspNetUserRoles where UserId=@Id
		End
	set @ActualRowsAffected =@@ROWCOUNT	
	SET  @ApplicationIDout =(CONVERT(varchar,@ActualRowsAffected))
	select @ApplicationIDout;
End
GO
/****** Object:  StoredProcedure [dbo].[USP_GET_AllUSER]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[USP_GET_AllUSER]
As
Begin
	Select UR.UserId,UR.RoleId,A.UserName,R.Name as RoleName from AspNetUserRoles UR
	Inner Join AspNetRoles R on UR.RoleId = R.ID
	Inner Join AspNetUsers A on UR.UserId = A.Id
End
GO
/****** Object:  StoredProcedure [dbo].[USP_GET_ApplicationUser]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[USP_GET_ApplicationUser]
As
Begin
	Select Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,
	TwoFactorEnabled,ISNULL(LockoutEnd,GETDATE() - 1)as LockoutEnd,LockoutEnabled,AccessFailedCount,Discriminator,FirstName,LastName
	from AspNetUsers
End
GO
/****** Object:  StoredProcedure [dbo].[USP_GET_OrderCount]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[USP_GET_OrderCount]
As
Begin
	Select Count(1) as 'rowCount' from Orders
End
GO
/****** Object:  StoredProcedure [dbo].[USP_GET_Product]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[USP_GET_Product]
@ProductType Nvarchar(max) = null
As
Begin
	Select Products.Id,Name,Price,Image,ProductColor,IsAvailable,ProductTypeId,SpecialTagId,ProductTypes.ProductType
	from Products
	Inner Join ProductTypes on ProductTypes.Id = Products.ProductTypeId
	Inner Join SpecialTags on SpecialTags.Id = Products.SpecialTagId
	Where @ProductType is null or ProductTypes.ProductType = @ProductType
End
GO
/****** Object:  StoredProcedure [dbo].[USP_GET_ProductIdWise]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[USP_GET_ProductIdWise]
@Id int
As
Begin
	Select Products.Id,Name,Price,Image,ProductColor,IsAvailable,ProductTypeId,SpecialTagId,ProductTypes.ProductType
	from Products
	Inner Join ProductTypes on ProductTypes.Id = Products.ProductTypeId
	Inner Join SpecialTags on SpecialTags.Id = Products.SpecialTagId 
	where Products.Id = @Id
End
GO
/****** Object:  StoredProcedure [dbo].[USP_GET_ProductTypes]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[USP_GET_ProductTypes]
As
Begin
	Select Id, ProductType from ProductTypes
End
GO
/****** Object:  StoredProcedure [dbo].[USP_GET_ProductTypesIdWise]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[USP_GET_ProductTypesIdWise]
@Id int
As
Begin
	Select Id,ProductType from ProductTypes where Id = @Id
End
GO
/****** Object:  StoredProcedure [dbo].[USP_GET_Role]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[USP_GET_Role]
As
Begin
	Select Id,UserName from AspNetUsers
	Where LockoutEnd < GETDATE() OR LockoutEnd IS NULL
End
GO
/****** Object:  StoredProcedure [dbo].[USP_GET_SpecialTags]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[USP_GET_SpecialTags]
As
Begin
	Select Id, SpecialTag from SpecialTags
End
GO
/****** Object:  StoredProcedure [dbo].[USP_GET_SpecialTagsIdWise]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[USP_GET_SpecialTagsIdWise]
@Id int
As
Begin
	Select Id,SpecialTag from SpecialTags where Id = @Id
End
GO
/****** Object:  StoredProcedure [dbo].[USP_GET_UserIdRole]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[USP_GET_UserIdRole]
@Id Nvarchar(max)
As
Begin
	Select UserId,RoleId,UserName,U.Id
	from AspNetUsers U
	inner Join AspNetUserRoles UR on U.Id = UR.UserId
	where U.Id = @Id
End
GO
/****** Object:  StoredProcedure [dbo].[USP_GET_UserIdWise]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[USP_GET_UserIdWise]
@Id nvarchar(max)
As
Begin
	Select Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount,Discriminator,FirstName,LastName
	from AspNetUsers
	where AspNetUsers.Id = @Id
End
GO
/****** Object:  StoredProcedure [dbo].[USP_GET_UserRoleInfo]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[USP_GET_UserRoleInfo]
@EmailId Nvarchar(max)
As
Begin
	Select UR.UserId,UR.RoleId,A.UserName,R.Name as RoleName from AspNetUserRoles UR
	Inner Join AspNetRoles R on UR.RoleId = R.ID
	Inner Join AspNetUsers A on UR.UserId = A.Id
	where A.UserName = @EmailId
End
GO
/****** Object:  StoredProcedure [dbo].[USP_INSERT_Order]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[USP_INSERT_Order]
@OrderNo nvarchar(max),
@Name nvarchar(max),
@PhoneNo nvarchar(max),
@Email nvarchar(max),
@Address nvarchar(max),
--@OrderDate datetime2,
@ApplicationIDout NVARCHAR(200) output
As
Begin
	Declare @ActualRowsAffected int

	INSERT INTO Orders
                  (OrderNo,Name,PhoneNo,Email,Address,OrderDate)
	VALUES (@OrderNo,@Name,@PhoneNo,@Email,@Address,GETDATE())	
	
	set @ActualRowsAffected =@@ROWCOUNT	
	SET  @ApplicationIDout =(CONVERT(varchar,@ActualRowsAffected))
	select @ApplicationIDout;
End
GO
/****** Object:  StoredProcedure [dbo].[USP_INSERT_OrderDetails]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_INSERT_OrderDetails]
(@TempTable AS dbo.OrderDetailsList READONLY)
AS
BEGIN
	INSERT INTO OrderDetails
                  (OrderId, PorductId)
	SELECT OrderId, PorductId FROM @TempTable
END
GO
/****** Object:  StoredProcedure [dbo].[USP_INSERT_Product]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[USP_INSERT_Product]
@Name nvarchar(max),
@Price decimal,
@Image nvarchar(max),
@ProductColor nvarchar(max),
@IsAvailable bit,
@ProductTypeId int,
@SpecialTagId int,
@ApplicationIDout NVARCHAR(200) output
As
Begin
	Declare @ActualRowsAffected int

	INSERT INTO Products
                  (Name,Price,Image,ProductColor,IsAvailable,ProductTypeId,SpecialTagId)
	VALUES (@Name,@Price,@Image,@ProductColor,@IsAvailable,@ProductTypeId,@SpecialTagId)
	
	set @ActualRowsAffected =@@ROWCOUNT	
	SET  @ApplicationIDout =(CONVERT(varchar,@ActualRowsAffected))
	select @ApplicationIDout;
End
GO
/****** Object:  StoredProcedure [dbo].[USP_INSERT_ProductTypes]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[USP_INSERT_ProductTypes]
@ProductType nvarchar(max),
@ApplicationIDout NVARCHAR(200) output
As
Begin
	Declare @ActualRowsAffected int

	INSERT INTO ProductTypes
                  (ProductType)
	VALUES (@ProductType)

	
	set @ActualRowsAffected =@@ROWCOUNT	
	SET  @ApplicationIDout =(CONVERT(varchar,@ActualRowsAffected))
	select @ApplicationIDout;
End
GO
/****** Object:  StoredProcedure [dbo].[USP_INSERT_SpecialTags]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[USP_INSERT_SpecialTags]
@SpecialTag nvarchar(max),
@ApplicationIDout NVARCHAR(200) output
As
Begin
	Declare @ActualRowsAffected int

	INSERT INTO SpecialTags
                  (SpecialTag)
	VALUES (@SpecialTag)

	
	set @ActualRowsAffected =@@ROWCOUNT	
	SET  @ApplicationIDout =(CONVERT(varchar,@ActualRowsAffected))
	select @ApplicationIDout;
End
GO
/****** Object:  StoredProcedure [dbo].[USP_INSERT_User]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[USP_INSERT_User]
@Id nvarchar(max),
@UserName nvarchar(max),
@NormalizedUserName nvarchar(max),
@Email nvarchar(max),
@NormalizedEmail nvarchar(max),
@EmailConfirmed bit,
@PasswordHash nvarchar(MAX),
@SecurityStamp nvarchar(MAX),
@ConcurrencyStamp nvarchar(MAX),
@PhoneNumber nvarchar(MAX),
@PhoneNumberConfirmed bit,
@TwoFactorEnabled bit,
@LockoutEnd datetimeoffset(7),
@LockoutEnabled bit,
@AccessFailedCount int,
@FirstName nvarchar(MAX),
@LastName nvarchar(MAX),
@ApplicationIDout NVARCHAR(200) output
As
Begin
	Declare @ActualRowsAffected int

	INSERT INTO AspNetUsers
                  (Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, 
				  PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount, FirstName, LastName)
	VALUES (@Id,@UserName,@NormalizedUserName,@Email,@NormalizedEmail,@EmailConfirmed,@PasswordHash,@SecurityStamp,@ConcurrencyStamp,@PhoneNumber,
				@PhoneNumberConfirmed,@TwoFactorEnabled,@LockoutEnd,@LockoutEnabled,@AccessFailedCount,@FirstName,@LastName)
	
	set @ActualRowsAffected =@@ROWCOUNT	
	SET  @ApplicationIDout =(CONVERT(varchar,@ActualRowsAffected))
	select @ApplicationIDout;
End
GO
/****** Object:  StoredProcedure [dbo].[USP_INSERT_UserRole]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[USP_INSERT_UserRole]
@UserId nvarchar(max),
@Role nvarchar(max),
@FirstName nvarchar(max) = null,
@LastName nvarchar(max)=null,
@ApplicationIDout NVARCHAR(200) output
As
Begin
	Declare @ActualRowsAffected int

	INSERT INTO AspNetUserRoles
                  (UserId, RoleId)
	VALUES (@UserId,(Select Id from AspNetRoles where Name=@Role))

	Update AspNetUsers Set FirstName=@FirstName, LastName = @LastName where Id = @UserId
	
	set @ActualRowsAffected =@@ROWCOUNT	
	SET  @ApplicationIDout =(CONVERT(varchar,@ActualRowsAffected))
	select @ApplicationIDout;
End
GO
/****** Object:  StoredProcedure [dbo].[USP_IsExists_Product]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[USP_IsExists_Product]
@Name Nvarchar(max),
@ApplicationIDout NVARCHAR(200) output
As
Begin
	If Exists(Select * from Products where Name=@Name)
		Begin
			SET  @ApplicationIDout = 'Exists'
		End
	Else
		Begin
			Set @ApplicationIDout = 'NotExists'
		End
		
	select @ApplicationIDout;
End
GO
/****** Object:  StoredProcedure [dbo].[USP_LockOut_User]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[USP_LockOut_User]
@Id Nvarchar(max),
@ApplicationIDout NVARCHAR(200) output
As
Begin
	Declare @ActualRowsAffected int
	If Exists(Select * from AspNetUsers where Id=@Id)
		Begin
			Update AspNetUsers set LockoutEnd = DATEADD(YEAR,100,GETDATE()) where Id=@Id			
		End
	set @ActualRowsAffected =@@ROWCOUNT	
	SET  @ApplicationIDout =(CONVERT(varchar,@ActualRowsAffected))
	select @ApplicationIDout;
End
GO
/****** Object:  StoredProcedure [dbo].[USP_SEARCH_Product]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[USP_SEARCH_Product]
@lowAmount decimal,
@largeAmount decimal
As
Begin
	Select Products.Id,Name,Price,Image,ProductColor,IsAvailable,ProductTypeId,SpecialTagId,ProductTypes.ProductType
	from Products
	Inner Join ProductTypes on ProductTypes.Id = Products.ProductTypeId
	Inner Join SpecialTags on SpecialTags.Id = Products.SpecialTagId
	where Products.Price >= @lowAmount and Products.Price <= @largeAmount
End
GO
/****** Object:  StoredProcedure [dbo].[USP_UPDATE_Product]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[USP_UPDATE_Product]
@Id int,
@Name Nvarchar(Max),
@Price decimal,
@Image nvarchar(max),
@ProductColor nvarchar(max),
@IsAvailable bit,
@ProductTypeId int,
@SpecialTagId int,
@ApplicationIDout NVARCHAR(200) output
As
Begin
	Declare @ActualRowsAffected int
	If Exists(Select * from Products where Id=@Id)
		Begin
			Update Products set Name = @Name, Price = @Price, Image=@Image, ProductColor = @ProductColor, IsAvailable = @IsAvailable, 
			ProductTypeId = @ProductTypeId, SpecialTagId = @SpecialTagId where Id=@Id
		End
	set @ActualRowsAffected =@@ROWCOUNT	
	SET  @ApplicationIDout =(CONVERT(varchar,@ActualRowsAffected))
	select @ApplicationIDout;
End
GO
/****** Object:  StoredProcedure [dbo].[USP_UPDATE_ProductTypes]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[USP_UPDATE_ProductTypes]
@Id int,
@ProductTypes Nvarchar(Max),
@ApplicationIDout NVARCHAR(200) output
As
Begin
	Declare @ActualRowsAffected int
	If Exists(Select * from ProductTypes where Id=@Id)
		Begin
			Update ProductTypes set ProductType = @ProductTypes where Id=@Id
		End
	set @ActualRowsAffected =@@ROWCOUNT	
	SET  @ApplicationIDout =(CONVERT(varchar,@ActualRowsAffected))
	select @ApplicationIDout;
End
GO
/****** Object:  StoredProcedure [dbo].[USP_UPDATE_SpecialTags]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[USP_UPDATE_SpecialTags]
@Id int,
@SpecialTag Nvarchar(Max),
@ApplicationIDout NVARCHAR(200) output
As
Begin
	Declare @ActualRowsAffected int
	If Exists(Select * from SpecialTags where Id=@Id)
		Begin
			Update SpecialTags set SpecialTag = @SpecialTag where Id=@Id
		End
	set @ActualRowsAffected =@@ROWCOUNT	
	SET  @ApplicationIDout =(CONVERT(varchar,@ActualRowsAffected))
	select @ApplicationIDout;
End
GO
/****** Object:  StoredProcedure [dbo].[USP_UPDATE_User]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[USP_UPDATE_User]
@Id Nvarchar(max),
@UserName Nvarchar(Max),
@FirstName Nvarchar(Max),
@LastName nvarchar(max),
@ApplicationIDout NVARCHAR(200) output
As
Begin
	Declare @ActualRowsAffected int
	If Exists(Select * from AspNetUsers where Id=@Id)
		Begin
			Update AspNetUsers Set UserName=@UserName, FirstName=@FirstName, LastName = @LastName where Id = @Id
		End
	set @ActualRowsAffected =@@ROWCOUNT	
	SET  @ApplicationIDout =(CONVERT(varchar,@ActualRowsAffected))
	select @ApplicationIDout;
End
GO
/****** Object:  StoredProcedure [dbo].[USP_UPDATE_UserRole]    Script Date: 18-04-2023 11.10.36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[USP_UPDATE_UserRole]
@UserId Nvarchar(max),
@RoleId Nvarchar(max),
@ApplicationIDout NVARCHAR(200) output
As
Begin
	Declare @ActualRowsAffected int
	If Exists(Select * from AspNetUserRoles where UserId=@UserId)
		Begin
			Update AspNetUserRoles set RoleId = (Select Id from AspNetRoles Where Name = @RoleId) where UserId=@UserId
		End
	set @ActualRowsAffected =@@ROWCOUNT	
	SET  @ApplicationIDout =(CONVERT(varchar,@ActualRowsAffected))
	select @ApplicationIDout;
End
GO
USE [master]
GO
ALTER DATABASE [OnlineShop] SET  READ_WRITE 
GO
