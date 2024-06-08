/*    ==Параметры сценариев==

    Версия исходного сервера : SQL Server 2017 (14.0.1000)
    Выпуск исходного ядра СУБД : Выпуск Microsoft SQL Server Express Edition
    Тип исходного ядра СУБД : Изолированный SQL Server

    Версия целевого сервера : SQL Server 2017
    Выпуск целевого ядра СУБД : Выпуск Microsoft SQL Server Standard Edition
    Тип целевого ядра СУБД : Изолированный SQL Server
*/
USE [master]
GO
/****** Object:  Database [AutoTuningBD]    Script Date: 08.06.2024 11:59:02 ******/
CREATE DATABASE [AutoTuningBD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AutoTuningBD', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\AutoTuningBD.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AutoTuningBD_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\AutoTuningBD_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [AutoTuningBD] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AutoTuningBD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AutoTuningBD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AutoTuningBD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AutoTuningBD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AutoTuningBD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AutoTuningBD] SET ARITHABORT OFF 
GO
ALTER DATABASE [AutoTuningBD] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [AutoTuningBD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AutoTuningBD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AutoTuningBD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AutoTuningBD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AutoTuningBD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AutoTuningBD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AutoTuningBD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AutoTuningBD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AutoTuningBD] SET  ENABLE_BROKER 
GO
ALTER DATABASE [AutoTuningBD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AutoTuningBD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AutoTuningBD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AutoTuningBD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AutoTuningBD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AutoTuningBD] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AutoTuningBD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AutoTuningBD] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AutoTuningBD] SET  MULTI_USER 
GO
ALTER DATABASE [AutoTuningBD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AutoTuningBD] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AutoTuningBD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AutoTuningBD] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AutoTuningBD] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AutoTuningBD] SET QUERY_STORE = OFF
GO
USE [AutoTuningBD]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [AutoTuningBD]
GO
/****** Object:  Table [dbo].[Brand]    Script Date: 08.06.2024 11:59:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brand](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Brand] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 08.06.2024 11:59:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 08.06.2024 11:59:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BrandId] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[DateStart] [date] NOT NULL,
	[DateEnd] [date] NOT NULL,
	[CarNumber] [nvarchar](20) NOT NULL,
	[Info] [nvarchar](1000) NULL,
	[Username] [nvarchar](50) NOT NULL,
	[TotalPrice] [float] NOT NULL,
 CONSTRAINT [PK_Rent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 08.06.2024 11:59:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Price] [float] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Photo] [nvarchar](100) NULL,
 CONSTRAINT [PK_Prokat] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceOrder]    Script Date: 08.06.2024 11:59:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceOrder](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ServiceId] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
	[Count] [int] NOT NULL,
 CONSTRAINT [PK_ServiceOrder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 08.06.2024 11:59:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Color] [nvarchar](10) NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 08.06.2024 11:59:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](100) NULL,
	[LastName] [nvarchar](50) NULL,
	[FirstName] [nvarchar](50) NULL,
	[MiddleName] [nvarchar](50) NULL,
	[Phone] [nvarchar](30) NULL,
	[Email] [nvarchar](50) NULL,
	[PassportSeries] [nvarchar](50) NULL,
	[PassportNum] [nvarchar](50) NULL,
	[Role] [bit] NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Brand] ON 

INSERT [dbo].[Brand] ([Id], [Name]) VALUES (1, N'BMW')
INSERT [dbo].[Brand] ([Id], [Name]) VALUES (2, N'Chery')
INSERT [dbo].[Brand] ([Id], [Name]) VALUES (3, N'Citroen')
INSERT [dbo].[Brand] ([Id], [Name]) VALUES (4, N'Daewoo')
INSERT [dbo].[Brand] ([Id], [Name]) VALUES (5, N'Datsun')
INSERT [dbo].[Brand] ([Id], [Name]) VALUES (6, N'FAW')
INSERT [dbo].[Brand] ([Id], [Name]) VALUES (7, N'Fiat')
INSERT [dbo].[Brand] ([Id], [Name]) VALUES (8, N'Ford')
INSERT [dbo].[Brand] ([Id], [Name]) VALUES (9, N'Great Wall')
INSERT [dbo].[Brand] ([Id], [Name]) VALUES (10, N'Haval')
INSERT [dbo].[Brand] ([Id], [Name]) VALUES (11, N'LADA(ВАЗ)')
INSERT [dbo].[Brand] ([Id], [Name]) VALUES (12, N'KIA')
INSERT [dbo].[Brand] ([Id], [Name]) VALUES (13, N'Lifan')
INSERT [dbo].[Brand] ([Id], [Name]) VALUES (14, N'Renault')
INSERT [dbo].[Brand] ([Id], [Name]) VALUES (15, N'Skoda')
INSERT [dbo].[Brand] ([Id], [Name]) VALUES (16, N'Volkswagen')
INSERT [dbo].[Brand] ([Id], [Name]) VALUES (17, N'Hyundai')
INSERT [dbo].[Brand] ([Id], [Name]) VALUES (18, N'ГАз')
INSERT [dbo].[Brand] ([Id], [Name]) VALUES (19, N'УАЗ')
INSERT [dbo].[Brand] ([Id], [Name]) VALUES (20, N'ЗАЗ')
SET IDENTITY_INSERT [dbo].[Brand] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name]) VALUES (1, N'Головные устройства')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (2, N'Сабвуферы')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (3, N'Усилители')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (4, N'Морская акустика')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (5, N'Стайлинг')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (6, N'Короба')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (7, N'Акустика')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (8, N'Аксессуары')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (9, N'Кабельная продукция')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (10, N'Шумоизоляция')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (11, N'Автосвет')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Id], [BrandId], [StatusId], [DateStart], [DateEnd], [CarNumber], [Info], [Username], [TotalPrice]) VALUES (3, 2, 2, CAST(N'2024-06-09' AS Date), CAST(N'0004-01-01' AS Date), N'12131', N'321321', N'andrei', 10100)
INSERT [dbo].[Order] ([Id], [BrandId], [StatusId], [DateStart], [DateEnd], [CarNumber], [Info], [Username], [TotalPrice]) VALUES (4, 6, 2, CAST(N'2024-06-09' AS Date), CAST(N'0004-01-01' AS Date), N'243', N'4234', N'dunkan', 4000)
INSERT [dbo].[Order] ([Id], [BrandId], [StatusId], [DateStart], [DateEnd], [CarNumber], [Info], [Username], [TotalPrice]) VALUES (5, 2, 1, CAST(N'2024-06-09' AS Date), CAST(N'2024-06-14' AS Date), N'111', N'111', N'andrei', 3200)
INSERT [dbo].[Order] ([Id], [BrandId], [StatusId], [DateStart], [DateEnd], [CarNumber], [Info], [Username], [TotalPrice]) VALUES (8, 3, 1, CAST(N'2024-05-21' AS Date), CAST(N'2024-05-23' AS Date), N'111', N'1111', N'dimon', 8005)
INSERT [dbo].[Order] ([Id], [BrandId], [StatusId], [DateStart], [DateEnd], [CarNumber], [Info], [Username], [TotalPrice]) VALUES (9, 2, 1, CAST(N'2024-06-07' AS Date), CAST(N'2024-06-07' AS Date), N'н123нн', N'белый', N'Marat', 800)
INSERT [dbo].[Order] ([Id], [BrandId], [StatusId], [DateStart], [DateEnd], [CarNumber], [Info], [Username], [TotalPrice]) VALUES (10, 3, 1, CAST(N'2024-06-07' AS Date), CAST(N'2024-06-07' AS Date), N'1323', N'1', N'liza', 14790)
SET IDENTITY_INSERT [dbo].[Order] OFF
SET IDENTITY_INSERT [dbo].[Service] ON 

INSERT [dbo].[Service] ([Id], [Name], [Price], [CategoryId], [Photo]) VALUES (44, N'Alphard Machete MF-12R D2', 10790, 2, N'OB1c8DBlO.jpg')
INSERT [dbo].[Service] ([Id], [Name], [Price], [CategoryId], [Photo]) VALUES (45, N'DL Audio Gryphon Pro 12', 9400, 2, N'Gryphon-Pro-12-V2_1-.jpg')
INSERT [dbo].[Service] ([Id], [Name], [Price], [CategoryId], [Photo]) VALUES (46, N'Короб 15" на трубе (рисунок Боевая Русь) 96л.', 6000, 6, N'73377835.jpg')
INSERT [dbo].[Service] ([Id], [Name], [Price], [CategoryId], [Photo]) VALUES (47, N'Короб 12" AURA INDIGO', 6800, 6, N'46832122.jpg')
INSERT [dbo].[Service] ([Id], [Name], [Price], [CategoryId], [Photo]) VALUES (48, N'ACV AVS-914BR', 2750, 1, N'1.jpg')
INSERT [dbo].[Service] ([Id], [Name], [Price], [CategoryId], [Photo]) VALUES (49, N'Короб 12" на трубе (JOKER) 65л.', 5500, 6, N'89845098.jpg')
INSERT [dbo].[Service] ([Id], [Name], [Price], [CategoryId], [Photo]) VALUES (50, N'Aura AMH-520BT', 3990, 1, N'AMH-520BT.jpg')
INSERT [dbo].[Service] ([Id], [Name], [Price], [CategoryId], [Photo]) VALUES (51, N'Pioneer MVH S120UBW', 7100, 1, N'66466343.jpg')
INSERT [dbo].[Service] ([Id], [Name], [Price], [CategoryId], [Photo]) VALUES (52, N'Шумоизоляция дверей передних за пару', 4000, 10, N'11ыФЫф.jpg')
INSERT [dbo].[Service] ([Id], [Name], [Price], [CategoryId], [Photo]) VALUES (53, N'Шумоизоляция полная (легковой авто)        ', 30000, 10, N'11ыфФЫ.jpg')
INSERT [dbo].[Service] ([Id], [Name], [Price], [CategoryId], [Photo]) VALUES (54, N'Комплект светодиодных ламп головного света F10-H3', 1800, 11, N'151579271.jpg')
INSERT [dbo].[Service] ([Id], [Name], [Price], [CategoryId], [Photo]) VALUES (55, N'Комплект светодиодных ламп головного света RuZoom A80-H4', 4200, 11, N'157279796.jpg')
SET IDENTITY_INSERT [dbo].[Service] OFF
SET IDENTITY_INSERT [dbo].[ServiceOrder] ON 

INSERT [dbo].[ServiceOrder] ([Id], [ServiceId], [OrderId], [Count]) VALUES (14, 52, 4, 1)
INSERT [dbo].[ServiceOrder] ([Id], [ServiceId], [OrderId], [Count]) VALUES (17, 51, 3, 1)
INSERT [dbo].[ServiceOrder] ([Id], [ServiceId], [OrderId], [Count]) VALUES (18, 44, 3, 1)
INSERT [dbo].[ServiceOrder] ([Id], [ServiceId], [OrderId], [Count]) VALUES (24, 52, 8, 2)
INSERT [dbo].[ServiceOrder] ([Id], [ServiceId], [OrderId], [Count]) VALUES (25, 48, 8, 2)
INSERT [dbo].[ServiceOrder] ([Id], [ServiceId], [OrderId], [Count]) VALUES (26, 44, 9, 1)
INSERT [dbo].[ServiceOrder] ([Id], [ServiceId], [OrderId], [Count]) VALUES (27, 44, 5, 4)
INSERT [dbo].[ServiceOrder] ([Id], [ServiceId], [OrderId], [Count]) VALUES (28, 44, 10, 1)
INSERT [dbo].[ServiceOrder] ([Id], [ServiceId], [OrderId], [Count]) VALUES (29, 52, 10, 1)
SET IDENTITY_INSERT [dbo].[ServiceOrder] OFF
INSERT [dbo].[Status] ([Id], [Name], [Color]) VALUES (1, N'создана', N'#FFF46859')
INSERT [dbo].[Status] ([Id], [Name], [Color]) VALUES (2, N'в работе', N'#FFFFDAB9')
INSERT [dbo].[Status] ([Id], [Name], [Color]) VALUES (3, N'готов', N'#FF41FF41')
INSERT [dbo].[User] ([UserName], [Password], [LastName], [FirstName], [MiddleName], [Phone], [Email], [PassportSeries], [PassportNum], [Role]) VALUES (N'admin', N'1', N'Мусинов', N'Алишер', N'Усманович', N'+7 (900) 745-32-34', N'alishtop@mail.ru', NULL, NULL, 1)
INSERT [dbo].[User] ([UserName], [Password], [LastName], [FirstName], [MiddleName], [Phone], [Email], [PassportSeries], [PassportNum], [Role]) VALUES (N'andrei', N'1', N'Гудихин', N'Андрей', N'Евгеньевич', N'89674547454', N'andrei@mail.ru', N'1111', N'1111111', 0)
INSERT [dbo].[User] ([UserName], [Password], [LastName], [FirstName], [MiddleName], [Phone], [Email], [PassportSeries], [PassportNum], [Role]) VALUES (N'dimon', N'1', N'Ефремов', N'Дмитрий', N'Антонович', N'+7 (917) 459-24-33', N'dimon2228@gmail.ru', NULL, NULL, 0)
INSERT [dbo].[User] ([UserName], [Password], [LastName], [FirstName], [MiddleName], [Phone], [Email], [PassportSeries], [PassportNum], [Role]) VALUES (N'dunkan', N'1', N'Астахов ', N'Дункан', N' Николаевич', N'+7 (939) 848-86-83', N'AstahovDunkan459@mail.ru', NULL, NULL, 0)
INSERT [dbo].[User] ([UserName], [Password], [LastName], [FirstName], [MiddleName], [Phone], [Email], [PassportSeries], [PassportNum], [Role]) VALUES (N'fedor', N'1', N'Федорова', N'Анна', N'Александровна', N'+7 (969) 325-95-89', N'anya188@mail.ru', NULL, NULL, 0)
INSERT [dbo].[User] ([UserName], [Password], [LastName], [FirstName], [MiddleName], [Phone], [Email], [PassportSeries], [PassportNum], [Role]) VALUES (N'igor', N'1', N'Иванов', N'ИВан', N'Иванович', N'8964564654', N'456456', N'121', N'121221', 0)
INSERT [dbo].[User] ([UserName], [Password], [LastName], [FirstName], [MiddleName], [Phone], [Email], [PassportSeries], [PassportNum], [Role]) VALUES (N'liza', N'1', N'Герасимова1', N'Елизавета', N'Сергеевна', N'+7 (991) 240-73-10', N'lisabetta@yandex.ru', N'1', N'2', 0)
INSERT [dbo].[User] ([UserName], [Password], [LastName], [FirstName], [MiddleName], [Phone], [Email], [PassportSeries], [PassportNum], [Role]) VALUES (N'Marat', N'1234', N'Исмагилов', N'Марат', N'Саяфович', N'89009876778', N'Maratism@mail.ru', N'', N'', 0)
INSERT [dbo].[User] ([UserName], [Password], [LastName], [FirstName], [MiddleName], [Phone], [Email], [PassportSeries], [PassportNum], [Role]) VALUES (N'partina', N'1', N'Москаленко ', N'Партина', N' Геннадиевна', N'+7 (954) 343-27-62', N'MoskalenkoPartina240@mail.ru', NULL, NULL, 0)
INSERT [dbo].[User] ([UserName], [Password], [LastName], [FirstName], [MiddleName], [Phone], [Email], [PassportSeries], [PassportNum], [Role]) VALUES (N'ruzilya', N'1', N'Миндубаева', N'Рузиля', N'Рафисовна', N'+7 (942) 988-43-60', N'rusilya@mail.ru', NULL, NULL, 0)
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Brand] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brand] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Brand]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Rent_Client1] FOREIGN KEY([Username])
REFERENCES [dbo].[User] ([UserName])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Rent_Client1]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Rent_Status] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Status] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Rent_Status]
GO
ALTER TABLE [dbo].[Service]  WITH CHECK ADD  CONSTRAINT [FK_PriceList_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Service] CHECK CONSTRAINT [FK_PriceList_Category]
GO
ALTER TABLE [dbo].[ServiceOrder]  WITH CHECK ADD  CONSTRAINT [FK_ServiceOrder_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[ServiceOrder] CHECK CONSTRAINT [FK_ServiceOrder_Order]
GO
ALTER TABLE [dbo].[ServiceOrder]  WITH CHECK ADD  CONSTRAINT [FK_ServiceOrder_Service] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Service] ([Id])
GO
ALTER TABLE [dbo].[ServiceOrder] CHECK CONSTRAINT [FK_ServiceOrder_Service]
GO
USE [master]
GO
ALTER DATABASE [AutoTuningBD] SET  READ_WRITE 
GO
