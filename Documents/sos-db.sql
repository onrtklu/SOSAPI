USE [master]
GO
/****** Object:  Database [SOS_DB]    Script Date: 4.06.2019 00:11:07 ******/
CREATE DATABASE [SOS_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SOS_DB', FILENAME = N'D:\SQL\SQL 2012\MSSQL11.MSSQLSERVER\MSSQL\DATA\SOS_DB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SOS_DB_log', FILENAME = N'D:\SQL\SQL 2012\MSSQL11.MSSQLSERVER\MSSQL\DATA\SOS_DB_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SOS_DB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SOS_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SOS_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SOS_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SOS_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SOS_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SOS_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [SOS_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SOS_DB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [SOS_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SOS_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SOS_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SOS_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SOS_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SOS_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SOS_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SOS_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SOS_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SOS_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SOS_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SOS_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SOS_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SOS_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SOS_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SOS_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SOS_DB] SET RECOVERY FULL 
GO
ALTER DATABASE [SOS_DB] SET  MULTI_USER 
GO
ALTER DATABASE [SOS_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SOS_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SOS_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SOS_DB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SOS_DB', N'ON'
GO
USE [SOS_DB]
GO
/****** Object:  Schema [Constant]    Script Date: 4.06.2019 00:11:07 ******/
CREATE SCHEMA [Constant]
GO
/****** Object:  Schema [Credit]    Script Date: 4.06.2019 00:11:07 ******/
CREATE SCHEMA [Credit]
GO
/****** Object:  Schema [Customer]    Script Date: 4.06.2019 00:11:07 ******/
CREATE SCHEMA [Customer]
GO
/****** Object:  Schema [Offer]    Script Date: 4.06.2019 00:11:07 ******/
CREATE SCHEMA [Offer]
GO
/****** Object:  Schema [Orders]    Script Date: 4.06.2019 00:11:07 ******/
CREATE SCHEMA [Orders]
GO
/****** Object:  Schema [Restaurant]    Script Date: 4.06.2019 00:11:07 ******/
CREATE SCHEMA [Restaurant]
GO
/****** Object:  Schema [Users]    Script Date: 4.06.2019 00:11:07 ******/
CREATE SCHEMA [Users]
GO
/****** Object:  Table [Constant].[City]    Script Date: 4.06.2019 00:11:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Constant].[City](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [nvarchar](1000) NOT NULL,
	[ZipCode] [nvarchar](1000) NULL,
 CONSTRAINT [PK__City__3214EC0704ADF401] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Credit].[Credit]    Script Date: 4.06.2019 00:11:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Credit].[Credit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreditName] [nvarchar](1000) NOT NULL,
	[CreditRate] [int] NULL,
 CONSTRAINT [PK_Credit_Credit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Credit].[CustomerCredit]    Script Date: 4.06.2019 00:11:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Credit].[CustomerCredit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Customer_Id] [int] NOT NULL,
	[Credit_Id] [int] NOT NULL,
 CONSTRAINT [PK_Credit_CustomerCredit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Credit].[OrderCredit]    Script Date: 4.06.2019 00:11:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Credit].[OrderCredit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Restaurant_Id] [int] NULL,
	[Credit_Id] [int] NULL,
	[Order_Id] [int] NULL,
	[Customer_Id] [int] NULL,
 CONSTRAINT [PK_Credit_OrderCredit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Customer].[Customers]    Script Date: 4.06.2019 00:11:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Customer].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](1000) NOT NULL,
	[City_Id] [int] NULL,
	[Address] [nvarchar](max) NULL,
	[Phone] [nvarchar](1000) NULL,
	[Email] [nvarchar](1000) NULL,
	[ConfirmationKey] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[BirthDate] [date] NULL,
	[ActiveDate] [datetime] NULL,
	[Datetime] [datetime] NULL,
 CONSTRAINT [PK_Customer_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [Customer].[SocialMedia]    Script Date: 4.06.2019 00:11:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Customer].[SocialMedia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Customer_Id] [int] NOT NULL,
	[FacebookKey] [nvarchar](max) NULL,
	[TwitterKey] [nvarchar](max) NULL,
	[InstagramKey] [nvarchar](max) NULL,
	[GoogleKey] [nvarchar](max) NULL,
	[LinkedinKey] [nvarchar](max) NULL,
 CONSTRAINT [PK_Customer_SocialMedia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Event]    Script Date: 4.06.2019 00:11:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HallID] [int] NULL,
	[PlayID] [int] NULL,
	[EventDate] [datetime] NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Hall]    Script Date: 4.06.2019 00:11:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hall](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HallName] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Play]    Script Date: 4.06.2019 00:11:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Play](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PlayName] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ticket]    Script Date: 4.06.2019 00:11:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ticket](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EventID] [int] NULL,
	[NameSurname] [nvarchar](100) NULL,
	[ReservationTypeID] [int] NULL,
	[PaymentTypeID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 4.06.2019 00:11:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nchar](100) NULL,
	[Email] [nchar](100) NULL,
	[Password] [nchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Offer].[Offer]    Script Date: 4.06.2019 00:11:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Offer].[Offer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StartOfferDatetime] [datetime] NULL,
	[FinishOfferDatetime] [datetime] NULL,
	[OfferPaymentType_Id] [int] NULL,
	[Customer_Id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Offer].[OfferDetail]    Script Date: 4.06.2019 00:11:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Offer].[OfferDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Offer_Id] [int] NULL,
	[MenuItem_Id] [int] NULL,
	[Quantity] [int] NULL,
	[Datetime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Orders].[OnlinePaymentOrders]    Script Date: 4.06.2019 00:11:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Orders].[OnlinePaymentOrders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PaymentKey] [nvarchar](max) NULL,
	[PaymentStatus_Id] [int] NULL,
	[Order_Id] [int] NULL,
	[PrevisionKey] [nvarchar](max) NULL,
	[PaymentToken] [nvarchar](max) NULL,
	[PrevisionBeginDatetime] [datetime] NULL,
	[PrevisionEndDatetime] [datetime] NULL,
	[PaymentSuccessfulDatetime] [datetime] NULL,
	[PaymentValidate] [bit] NULL,
 CONSTRAINT [PK_Orders_OnlinePaymentOrders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [Orders].[OrderDetail]    Script Date: 4.06.2019 00:11:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Orders].[OrderDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Order_Id] [int] NULL,
	[MenuItem_Id] [int] NULL,
	[Quantity] [int] NULL,
	[ItemPrice] [decimal](18, 2) NULL,
	[TotalPrice] [decimal](18, 2) NULL,
	[PaymentType_Id] [int] NULL,
 CONSTRAINT [PK_Orders_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Orders].[Orders]    Script Date: 4.06.2019 00:11:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Orders].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Restaurant_Id] [int] NULL,
	[OrderTime] [datetime] NULL,
	[EstimatedDeliveryTime] [datetime] NULL,
	[ActualDeliveryTime] [datetime] NULL,
	[Customer_Id] [int] NULL,
	[TotalPrice] [decimal](18, 2) NULL,
	[Discount] [decimal](18, 2) NULL,
	[FinalPrice] [decimal](18, 2) NULL,
	[Comments] [nvarchar](max) NULL,
	[IsSuccess] [bit] NULL,
	[OrderStatus_Id] [int] NULL,
	[Datetime] [datetime] NULL,
 CONSTRAINT [PK__Orders__3214EC07B82B05EF] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [Orders].[OrderStatus]    Script Date: 4.06.2019 00:11:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Orders].[OrderStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderStatusName] [nvarchar](100) NULL,
 CONSTRAINT [PK_Orders_OrderStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Orders].[PaymentStatus]    Script Date: 4.06.2019 00:11:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Orders].[PaymentStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PaymentStatusName] [nvarchar](1000) NULL,
 CONSTRAINT [PK_Orders_PaymentStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Orders].[PaymentType]    Script Date: 4.06.2019 00:11:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Orders].[PaymentType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PaymentTypeName] [nvarchar](1000) NULL,
 CONSTRAINT [PK_Orders_PaymentType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Restaurant].[MenuCategory]    Script Date: 4.06.2019 00:11:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Restaurant].[MenuCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Parent_Id] [int] NULL,
	[CategoryName] [nvarchar](1000) NULL,
	[Restaurant_Id] [int] NULL,
	[ImageUrl] [nvarchar](max) NULL,
 CONSTRAINT [PK__MenuCate__3214EC07980532D8] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [Restaurant].[MenuItem]    Script Date: 4.06.2019 00:11:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Restaurant].[MenuItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [nvarchar](1000) NULL,
	[Category_Id] [int] NULL,
	[Description] [nvarchar](max) NULL,
	[Ingredients] [nvarchar](max) NULL,
	[Receipe] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NULL,
	[IsActive] [bit] NULL,
	[Restaurant_Id] [int] NULL,
 CONSTRAINT [PK__MenuItem__3214EC071FB01BEC] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [Restaurant].[Rate]    Script Date: 4.06.2019 00:11:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Restaurant].[Rate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Restaurant_Comment_Id] [int] NULL,
	[OrderRate] [int] NULL,
	[RestaurantRate] [int] NULL,
	[FoodRate] [int] NULL,
	[ServiceRate] [int] NULL,
	[WaiterRate] [int] NULL,
 CONSTRAINT [PK_Restaurant_Rate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Restaurant].[Restaurant]    Script Date: 4.06.2019 00:11:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Restaurant].[Restaurant](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RestaurantName] [nvarchar](1000) NULL,
	[City_Id] [int] NULL,
	[Address] [nvarchar](max) NULL,
	[Phone] [nvarchar](1000) NULL,
	[Email] [nvarchar](1000) NULL,
	[ConfirmationKey] [nvarchar](max) NULL,
	[RestaurantType_Id] [int] NULL,
	[Datetime] [datetime] NULL,
 CONSTRAINT [PK__Restaura__3214EC07F7BEC576] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [Restaurant].[RestaurantComments]    Script Date: 4.06.2019 00:11:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Restaurant].[RestaurantComments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Order_Id] [int] NULL,
	[Customer_Id] [int] NULL,
	[CommentText] [nvarchar](max) NULL,
	[OrderDate] [datetime] NULL,
	[Complaint] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [Restaurant].[RestaurantDetail]    Script Date: 4.06.2019 00:11:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Restaurant].[RestaurantDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Restaurant_Id] [int] NULL,
	[Description] [nvarchar](max) NULL,
	[OpeningHours] [nvarchar](1000) NULL,
	[Smoking] [bit] NULL,
	[Alcohol] [bit] NULL,
	[Datetime] [datetime] NULL,
 CONSTRAINT [PK__Restaura__3214EC07557D71D8] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [Restaurant].[RestaurantPicture]    Script Date: 4.06.2019 00:11:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Restaurant].[RestaurantPicture](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PictureName] [nvarchar](1000) NULL,
	[PictureUrl] [nvarchar](max) NULL,
	[Cover] [bit] NULL,
	[IsActive] [bit] NULL,
	[Restaurant_Id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [Restaurant].[RestaurantType]    Script Date: 4.06.2019 00:11:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Restaurant].[RestaurantType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RestaurantTypeName] [nvarchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Users].[Authority]    Script Date: 4.06.2019 00:11:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Users].[Authority](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AuthorityName] [nvarchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Users].[RestaurantUser]    Script Date: 4.06.2019 00:11:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Users].[RestaurantUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Restaurant_Id] [int] NULL,
	[User_Id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Users].[Users]    Script Date: 4.06.2019 00:11:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Users].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](1000) NULL,
	[UserPassword] [nvarchar](max) NULL,
	[UserAuth_Id] [int] NULL,
	[ConfirmationKey] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [Credit].[CustomerCredit]  WITH CHECK ADD  CONSTRAINT [FK_Credit_CustomerCredit_Credit] FOREIGN KEY([Credit_Id])
REFERENCES [Credit].[Credit] ([Id])
GO
ALTER TABLE [Credit].[CustomerCredit] CHECK CONSTRAINT [FK_Credit_CustomerCredit_Credit]
GO
ALTER TABLE [Credit].[CustomerCredit]  WITH CHECK ADD  CONSTRAINT [FK_Credit_CustomerCredit_Customers] FOREIGN KEY([Customer_Id])
REFERENCES [Customer].[Customers] ([Id])
GO
ALTER TABLE [Credit].[CustomerCredit] CHECK CONSTRAINT [FK_Credit_CustomerCredit_Customers]
GO
ALTER TABLE [Credit].[OrderCredit]  WITH CHECK ADD  CONSTRAINT [FK_Credit_OrderCredit_Credit] FOREIGN KEY([Credit_Id])
REFERENCES [Credit].[Credit] ([Id])
GO
ALTER TABLE [Credit].[OrderCredit] CHECK CONSTRAINT [FK_Credit_OrderCredit_Credit]
GO
ALTER TABLE [Credit].[OrderCredit]  WITH CHECK ADD  CONSTRAINT [FK_Credit_OrderCredit_Customers] FOREIGN KEY([Customer_Id])
REFERENCES [Customer].[Customers] ([Id])
GO
ALTER TABLE [Credit].[OrderCredit] CHECK CONSTRAINT [FK_Credit_OrderCredit_Customers]
GO
ALTER TABLE [Credit].[OrderCredit]  WITH CHECK ADD  CONSTRAINT [FK_Credit_OrderCredit_Orders] FOREIGN KEY([Order_Id])
REFERENCES [Orders].[Orders] ([Id])
GO
ALTER TABLE [Credit].[OrderCredit] CHECK CONSTRAINT [FK_Credit_OrderCredit_Orders]
GO
ALTER TABLE [Credit].[OrderCredit]  WITH CHECK ADD  CONSTRAINT [FK_Credit_OrderCredit_Restaurant] FOREIGN KEY([Restaurant_Id])
REFERENCES [Restaurant].[Restaurant] ([Id])
GO
ALTER TABLE [Credit].[OrderCredit] CHECK CONSTRAINT [FK_Credit_OrderCredit_Restaurant]
GO
ALTER TABLE [Customer].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Customers_City] FOREIGN KEY([City_Id])
REFERENCES [Constant].[City] ([Id])
GO
ALTER TABLE [Customer].[Customers] CHECK CONSTRAINT [FK_Customer_Customers_City]
GO
ALTER TABLE [Customer].[SocialMedia]  WITH CHECK ADD  CONSTRAINT [FK_Customer_SocialMedia_Customers] FOREIGN KEY([Customer_Id])
REFERENCES [Customer].[Customers] ([Id])
GO
ALTER TABLE [Customer].[SocialMedia] CHECK CONSTRAINT [FK_Customer_SocialMedia_Customers]
GO
ALTER TABLE [Offer].[Offer]  WITH CHECK ADD  CONSTRAINT [FK_Offer_Offer_Customers] FOREIGN KEY([Customer_Id])
REFERENCES [Customer].[Customers] ([Id])
GO
ALTER TABLE [Offer].[Offer] CHECK CONSTRAINT [FK_Offer_Offer_Customers]
GO
ALTER TABLE [Offer].[Offer]  WITH CHECK ADD  CONSTRAINT [FK_Offer_Offer_PaymentType] FOREIGN KEY([OfferPaymentType_Id])
REFERENCES [Orders].[PaymentType] ([Id])
GO
ALTER TABLE [Offer].[Offer] CHECK CONSTRAINT [FK_Offer_Offer_PaymentType]
GO
ALTER TABLE [Offer].[OfferDetail]  WITH CHECK ADD  CONSTRAINT [FK_Offer_OfferDetail_MenuItem] FOREIGN KEY([MenuItem_Id])
REFERENCES [Restaurant].[MenuItem] ([Id])
GO
ALTER TABLE [Offer].[OfferDetail] CHECK CONSTRAINT [FK_Offer_OfferDetail_MenuItem]
GO
ALTER TABLE [Offer].[OfferDetail]  WITH CHECK ADD  CONSTRAINT [FK_Offer_OfferDetail_Offer] FOREIGN KEY([Offer_Id])
REFERENCES [Offer].[Offer] ([Id])
GO
ALTER TABLE [Offer].[OfferDetail] CHECK CONSTRAINT [FK_Offer_OfferDetail_Offer]
GO
ALTER TABLE [Orders].[OnlinePaymentOrders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_OnlinePaymentOrders_Orders] FOREIGN KEY([Order_Id])
REFERENCES [Orders].[Orders] ([Id])
GO
ALTER TABLE [Orders].[OnlinePaymentOrders] CHECK CONSTRAINT [FK_Orders_OnlinePaymentOrders_Orders]
GO
ALTER TABLE [Orders].[OnlinePaymentOrders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_OnlinePaymentOrders_PaymentStatus] FOREIGN KEY([PaymentStatus_Id])
REFERENCES [Orders].[PaymentStatus] ([Id])
GO
ALTER TABLE [Orders].[OnlinePaymentOrders] CHECK CONSTRAINT [FK_Orders_OnlinePaymentOrders_PaymentStatus]
GO
ALTER TABLE [Orders].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_Orders_OrderDetails_MenuItem] FOREIGN KEY([MenuItem_Id])
REFERENCES [Restaurant].[MenuItem] ([Id])
GO
ALTER TABLE [Orders].[OrderDetail] CHECK CONSTRAINT [FK_Orders_OrderDetails_MenuItem]
GO
ALTER TABLE [Orders].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_Orders_OrderDetails_Orders] FOREIGN KEY([Order_Id])
REFERENCES [Orders].[Orders] ([Id])
GO
ALTER TABLE [Orders].[OrderDetail] CHECK CONSTRAINT [FK_Orders_OrderDetails_Orders]
GO
ALTER TABLE [Orders].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_Orders_OrderDetails_PaymentType] FOREIGN KEY([PaymentType_Id])
REFERENCES [Orders].[PaymentType] ([Id])
GO
ALTER TABLE [Orders].[OrderDetail] CHECK CONSTRAINT [FK_Orders_OrderDetails_PaymentType]
GO
ALTER TABLE [Orders].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Orders_Customers] FOREIGN KEY([Customer_Id])
REFERENCES [Customer].[Customers] ([Id])
GO
ALTER TABLE [Orders].[Orders] CHECK CONSTRAINT [FK_Orders_Orders_Customers]
GO
ALTER TABLE [Orders].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Orders_OrderStatus] FOREIGN KEY([OrderStatus_Id])
REFERENCES [Orders].[OrderStatus] ([Id])
GO
ALTER TABLE [Orders].[Orders] CHECK CONSTRAINT [FK_Orders_Orders_OrderStatus]
GO
ALTER TABLE [Orders].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Orders_Restaurant] FOREIGN KEY([Restaurant_Id])
REFERENCES [Restaurant].[Restaurant] ([Id])
GO
ALTER TABLE [Orders].[Orders] CHECK CONSTRAINT [FK_Orders_Orders_Restaurant]
GO
ALTER TABLE [Restaurant].[MenuCategory]  WITH CHECK ADD  CONSTRAINT [FK_Restaurant_MenuCategory_MenuCategory] FOREIGN KEY([Parent_Id])
REFERENCES [Restaurant].[MenuCategory] ([Id])
GO
ALTER TABLE [Restaurant].[MenuCategory] CHECK CONSTRAINT [FK_Restaurant_MenuCategory_MenuCategory]
GO
ALTER TABLE [Restaurant].[MenuCategory]  WITH CHECK ADD  CONSTRAINT [FK_Restaurant_MenuCategory_Restaurant] FOREIGN KEY([Restaurant_Id])
REFERENCES [Restaurant].[Restaurant] ([Id])
GO
ALTER TABLE [Restaurant].[MenuCategory] CHECK CONSTRAINT [FK_Restaurant_MenuCategory_Restaurant]
GO
ALTER TABLE [Restaurant].[MenuItem]  WITH CHECK ADD  CONSTRAINT [FK_Restaurant_MenuItem_MenuCategory] FOREIGN KEY([Category_Id])
REFERENCES [Restaurant].[MenuCategory] ([Id])
GO
ALTER TABLE [Restaurant].[MenuItem] CHECK CONSTRAINT [FK_Restaurant_MenuItem_MenuCategory]
GO
ALTER TABLE [Restaurant].[MenuItem]  WITH CHECK ADD  CONSTRAINT [FK_Restaurant_MenuItem_Restaurant] FOREIGN KEY([Restaurant_Id])
REFERENCES [Restaurant].[Restaurant] ([Id])
GO
ALTER TABLE [Restaurant].[MenuItem] CHECK CONSTRAINT [FK_Restaurant_MenuItem_Restaurant]
GO
ALTER TABLE [Restaurant].[Rate]  WITH CHECK ADD  CONSTRAINT [FK_Restaurant_Rate_RestaurantComments] FOREIGN KEY([Restaurant_Comment_Id])
REFERENCES [Restaurant].[RestaurantComments] ([Id])
GO
ALTER TABLE [Restaurant].[Rate] CHECK CONSTRAINT [FK_Restaurant_Rate_RestaurantComments]
GO
ALTER TABLE [Restaurant].[Restaurant]  WITH CHECK ADD  CONSTRAINT [FK_Restaurant_Restaurant_City] FOREIGN KEY([City_Id])
REFERENCES [Constant].[City] ([Id])
GO
ALTER TABLE [Restaurant].[Restaurant] CHECK CONSTRAINT [FK_Restaurant_Restaurant_City]
GO
ALTER TABLE [Restaurant].[Restaurant]  WITH CHECK ADD  CONSTRAINT [FK_Restaurant_Restaurant_RestaurantType] FOREIGN KEY([RestaurantType_Id])
REFERENCES [Restaurant].[RestaurantType] ([Id])
GO
ALTER TABLE [Restaurant].[Restaurant] CHECK CONSTRAINT [FK_Restaurant_Restaurant_RestaurantType]
GO
ALTER TABLE [Restaurant].[RestaurantComments]  WITH CHECK ADD  CONSTRAINT [FK_Restaurant_RestaurantComments_Customers] FOREIGN KEY([Customer_Id])
REFERENCES [Customer].[Customers] ([Id])
GO
ALTER TABLE [Restaurant].[RestaurantComments] CHECK CONSTRAINT [FK_Restaurant_RestaurantComments_Customers]
GO
ALTER TABLE [Restaurant].[RestaurantComments]  WITH CHECK ADD  CONSTRAINT [FK_Restaurant_RestaurantComments_Orders] FOREIGN KEY([Order_Id])
REFERENCES [Orders].[Orders] ([Id])
GO
ALTER TABLE [Restaurant].[RestaurantComments] CHECK CONSTRAINT [FK_Restaurant_RestaurantComments_Orders]
GO
ALTER TABLE [Restaurant].[RestaurantDetail]  WITH CHECK ADD  CONSTRAINT [FK_Restaurant_RestaurantDetail_Restaurant] FOREIGN KEY([Restaurant_Id])
REFERENCES [Restaurant].[Restaurant] ([Id])
GO
ALTER TABLE [Restaurant].[RestaurantDetail] CHECK CONSTRAINT [FK_Restaurant_RestaurantDetail_Restaurant]
GO
ALTER TABLE [Restaurant].[RestaurantPicture]  WITH CHECK ADD  CONSTRAINT [FK_Restaurant_RestaurantPicture_Restaurant] FOREIGN KEY([Restaurant_Id])
REFERENCES [Restaurant].[Restaurant] ([Id])
GO
ALTER TABLE [Restaurant].[RestaurantPicture] CHECK CONSTRAINT [FK_Restaurant_RestaurantPicture_Restaurant]
GO
ALTER TABLE [Users].[RestaurantUser]  WITH CHECK ADD  CONSTRAINT [FK_Users_RestaurantUser_Restaurant] FOREIGN KEY([Restaurant_Id])
REFERENCES [Restaurant].[Restaurant] ([Id])
GO
ALTER TABLE [Users].[RestaurantUser] CHECK CONSTRAINT [FK_Users_RestaurantUser_Restaurant]
GO
ALTER TABLE [Users].[RestaurantUser]  WITH CHECK ADD  CONSTRAINT [FK_Users_RestaurantUser_Users] FOREIGN KEY([User_Id])
REFERENCES [Users].[Users] ([Id])
GO
ALTER TABLE [Users].[RestaurantUser] CHECK CONSTRAINT [FK_Users_RestaurantUser_Users]
GO
ALTER TABLE [Users].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Users_Authority] FOREIGN KEY([UserAuth_Id])
REFERENCES [Users].[Authority] ([Id])
GO
ALTER TABLE [Users].[Users] CHECK CONSTRAINT [FK_Users_Users_Authority]
GO
USE [master]
GO
ALTER DATABASE [SOS_DB] SET  READ_WRITE 
GO
