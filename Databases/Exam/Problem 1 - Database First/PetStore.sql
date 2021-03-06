USE [master]
GO
/****** Object:  Database [PetStore]    Script Date: 23.10.2015 г. 10:16:02 ******/
CREATE DATABASE [PetStore]
GO
ALTER DATABASE [PetStore] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PetStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PetStore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PetStore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PetStore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PetStore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PetStore] SET ARITHABORT OFF 
GO
ALTER DATABASE [PetStore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PetStore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PetStore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PetStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PetStore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PetStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PetStore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PetStore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PetStore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PetStore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PetStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PetStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PetStore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PetStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PetStore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PetStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PetStore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PetStore] SET RECOVERY FULL 
GO
ALTER DATABASE [PetStore] SET  MULTI_USER 
GO
ALTER DATABASE [PetStore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PetStore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PetStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PetStore] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [PetStore] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PetStore', N'ON'
GO
USE [PetStore]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 23.10.2015 г. 10:16:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Colors]    Script Date: 23.10.2015 г. 10:16:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Colors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Color] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Colors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Countries]    Script Date: 23.10.2015 г. 10:16:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pets]    Script Date: 23.10.2015 г. 10:16:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pets](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SpeciesId] [int] NOT NULL,
	[BirthDateTime] [datetime] NOT NULL,
	[Price] [money] NOT NULL,
	[ColorId] [int] NOT NULL,
	[Breed] [nvarchar](30) NULL,
 CONSTRAINT [PK_Pets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 23.10.2015 г. 10:16:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](25) NOT NULL,
	[Price] [money] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductSpecies]    Script Date: 23.10.2015 г. 10:16:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSpecies](
	[ProductId] [int] NOT NULL,
	[SpeciesId] [int] NOT NULL,
 CONSTRAINT [PK_ProductSpecies] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[SpeciesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Species]    Script Date: 23.10.2015 г. 10:16:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Species](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CountryId] [int] NOT NULL,
 CONSTRAINT [PK_Species] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Category] ON 

GO
INSERT [dbo].[Category] ([Id], [Name]) VALUES (1, N'Toys')
GO
INSERT [dbo].[Category] ([Id], [Name]) VALUES (2, N'Food')
GO
INSERT [dbo].[Category] ([Id], [Name]) VALUES (3, N'Beds')
GO
INSERT [dbo].[Category] ([Id], [Name]) VALUES (4, N'Medicine')
GO
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Colors] ON 

GO
INSERT [dbo].[Colors] ([Id], [Color]) VALUES (1, N'black')
GO
INSERT [dbo].[Colors] ([Id], [Color]) VALUES (2, N'white')
GO
INSERT [dbo].[Colors] ([Id], [Color]) VALUES (3, N'red')
GO
INSERT [dbo].[Colors] ([Id], [Color]) VALUES (4, N'mixed')
GO
SET IDENTITY_INSERT [dbo].[Colors] OFF
GO
SET IDENTITY_INSERT [dbo].[Countries] ON 

GO
INSERT [dbo].[Countries] ([Id], [Name]) VALUES (7, N'Australia')
GO
INSERT [dbo].[Countries] ([Id], [Name]) VALUES (6, N'Brazil')
GO
INSERT [dbo].[Countries] ([Id], [Name]) VALUES (1, N'Bulgaria')
GO
INSERT [dbo].[Countries] ([Id], [Name]) VALUES (2, N'Germany')
GO
INSERT [dbo].[Countries] ([Id], [Name]) VALUES (3, N'Japan')
GO
INSERT [dbo].[Countries] ([Id], [Name]) VALUES (5, N'United Kingdom')
GO
INSERT [dbo].[Countries] ([Id], [Name]) VALUES (4, N'USA')
GO
SET IDENTITY_INSERT [dbo].[Countries] OFF
GO
SET IDENTITY_INSERT [dbo].[Pets] ON 

GO
INSERT [dbo].[Pets] ([Id], [SpeciesId], [BirthDateTime], [Price], [ColorId], [Breed]) VALUES (1, 1, CAST(N'2015-10-22 00:00:00.000' AS DateTime), 100.0000, 1, N'German Shepard')
GO
INSERT [dbo].[Pets] ([Id], [SpeciesId], [BirthDateTime], [Price], [ColorId], [Breed]) VALUES (2, 6, CAST(N'2014-10-21 00:00:00.000' AS DateTime), 50.0000, 2, N'Mantis')
GO
INSERT [dbo].[Pets] ([Id], [SpeciesId], [BirthDateTime], [Price], [ColorId], [Breed]) VALUES (3, 8, CAST(N'2013-02-20 00:00:00.000' AS DateTime), 600.0000, 3, N'East-Australian')
GO
INSERT [dbo].[Pets] ([Id], [SpeciesId], [BirthDateTime], [Price], [ColorId], [Breed]) VALUES (4, 2, CAST(N'2002-05-17 00:00:00.000' AS DateTime), 2000.0000, 1, N'Persian')
GO
INSERT [dbo].[Pets] ([Id], [SpeciesId], [BirthDateTime], [Price], [ColorId], [Breed]) VALUES (5, 3, CAST(N'2013-02-02 00:00:00.000' AS DateTime), 1000.0000, 3, NULL)
GO
INSERT [dbo].[Pets] ([Id], [SpeciesId], [BirthDateTime], [Price], [ColorId], [Breed]) VALUES (6, 4, CAST(N'2004-06-25 00:00:00.000' AS DateTime), 6000.0000, 4, N'Amazonian')
GO
INSERT [dbo].[Pets] ([Id], [SpeciesId], [BirthDateTime], [Price], [ColorId], [Breed]) VALUES (7, 5, CAST(N'2006-12-17 00:00:00.000' AS DateTime), 7000.0000, 1, NULL)
GO
SET IDENTITY_INSERT [dbo].[Pets] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

GO
INSERT [dbo].[Products] ([Id], [Name], [Price], [CategoryId]) VALUES (1, N'Ball', 10.0000, 1)
GO
INSERT [dbo].[Products] ([Id], [Name], [Price], [CategoryId]) VALUES (2, N'Food', 20.0000, 2)
GO
INSERT [dbo].[Products] ([Id], [Name], [Price], [CategoryId]) VALUES (3, N'Yummy Food', 500.0000, 2)
GO
INSERT [dbo].[Products] ([Id], [Name], [Price], [CategoryId]) VALUES (4, N'Bed', 100.0000, 3)
GO
INSERT [dbo].[Products] ([Id], [Name], [Price], [CategoryId]) VALUES (5, N'Temperature Medicine', 300.0000, 4)
GO
INSERT [dbo].[Products] ([Id], [Name], [Price], [CategoryId]) VALUES (6, N'Huge Bed', 600.0000, 3)
GO
INSERT [dbo].[Products] ([Id], [Name], [Price], [CategoryId]) VALUES (7, N'Eco Food', 40.0000, 2)
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
INSERT [dbo].[ProductSpecies] ([ProductId], [SpeciesId]) VALUES (1, 1)
GO
INSERT [dbo].[ProductSpecies] ([ProductId], [SpeciesId]) VALUES (2, 3)
GO
INSERT [dbo].[ProductSpecies] ([ProductId], [SpeciesId]) VALUES (2, 4)
GO
INSERT [dbo].[ProductSpecies] ([ProductId], [SpeciesId]) VALUES (2, 6)
GO
INSERT [dbo].[ProductSpecies] ([ProductId], [SpeciesId]) VALUES (3, 2)
GO
INSERT [dbo].[ProductSpecies] ([ProductId], [SpeciesId]) VALUES (4, 2)
GO
INSERT [dbo].[ProductSpecies] ([ProductId], [SpeciesId]) VALUES (5, 5)
GO
INSERT [dbo].[ProductSpecies] ([ProductId], [SpeciesId]) VALUES (6, 2)
GO
INSERT [dbo].[ProductSpecies] ([ProductId], [SpeciesId]) VALUES (7, 8)
GO
SET IDENTITY_INSERT [dbo].[Species] ON 

GO
INSERT [dbo].[Species] ([Id], [Name], [CountryId]) VALUES (1, N'Dog', 1)
GO
INSERT [dbo].[Species] ([Id], [Name], [CountryId]) VALUES (2, N'Cat', 2)
GO
INSERT [dbo].[Species] ([Id], [Name], [CountryId]) VALUES (3, N'Lizard', 3)
GO
INSERT [dbo].[Species] ([Id], [Name], [CountryId]) VALUES (4, N'Crocodile', 4)
GO
INSERT [dbo].[Species] ([Id], [Name], [CountryId]) VALUES (5, N'Monkey', 5)
GO
INSERT [dbo].[Species] ([Id], [Name], [CountryId]) VALUES (6, N'Shrimp', 6)
GO
INSERT [dbo].[Species] ([Id], [Name], [CountryId]) VALUES (8, N'Koala', 7)
GO
SET IDENTITY_INSERT [dbo].[Species] OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Countries_Name]    Script Date: 23.10.2015 г. 10:16:03 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Countries_Name] ON [dbo].[Countries]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_BirthDateTime]    Script Date: 23.10.2015 г. 10:16:03 ******/
CREATE NONCLUSTERED INDEX [IX_BirthDateTime] ON [dbo].[Pets]
(
	[BirthDateTime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Price]    Script Date: 23.10.2015 г. 10:16:03 ******/
CREATE NONCLUSTERED INDEX [IX_Price] ON [dbo].[Pets]
(
	[Price] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Name]    Script Date: 23.10.2015 г. 10:16:03 ******/
ALTER TABLE [dbo].[Species] ADD  CONSTRAINT [IX_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Pets]  WITH CHECK ADD  CONSTRAINT [FK_Pets_Colors] FOREIGN KEY([ColorId])
REFERENCES [dbo].[Colors] ([Id])
GO
ALTER TABLE [dbo].[Pets] CHECK CONSTRAINT [FK_Pets_Colors]
GO
ALTER TABLE [dbo].[Pets]  WITH CHECK ADD  CONSTRAINT [FK_Pets_Species] FOREIGN KEY([SpeciesId])
REFERENCES [dbo].[Species] ([Id])
GO
ALTER TABLE [dbo].[Pets] CHECK CONSTRAINT [FK_Pets_Species]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Category]
GO
ALTER TABLE [dbo].[ProductSpecies]  WITH CHECK ADD  CONSTRAINT [FK_ProductSpecies_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[ProductSpecies] CHECK CONSTRAINT [FK_ProductSpecies_Products]
GO
ALTER TABLE [dbo].[ProductSpecies]  WITH CHECK ADD  CONSTRAINT [FK_ProductSpecies_Species] FOREIGN KEY([SpeciesId])
REFERENCES [dbo].[Species] ([Id])
GO
ALTER TABLE [dbo].[ProductSpecies] CHECK CONSTRAINT [FK_ProductSpecies_Species]
GO
ALTER TABLE [dbo].[Species]  WITH CHECK ADD  CONSTRAINT [FK_Species_Countries] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([Id])
GO
ALTER TABLE [dbo].[Species] CHECK CONSTRAINT [FK_Species_Countries]
GO
USE [master]
GO
ALTER DATABASE [PetStore] SET  READ_WRITE 
GO
