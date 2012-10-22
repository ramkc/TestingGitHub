USE [master]
GO

/****** SQL query for database creation ******/
/****** Object:  Database [Shopping]    Script Date: 05/15/2012 15:31:56 ******/
CREATE DATABASE [Shopping]
GO

ALTER DATABASE [Shopping] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Shopping].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Shopping] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Shopping] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Shopping] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Shopping] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Shopping] SET ARITHABORT OFF 
GO

ALTER DATABASE [Shopping] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Shopping] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [Shopping] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Shopping] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Shopping] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Shopping] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Shopping] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Shopping] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Shopping] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Shopping] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Shopping] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Shopping] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Shopping] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Shopping] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Shopping] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Shopping] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Shopping] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Shopping] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Shopping] SET  READ_WRITE 
GO

ALTER DATABASE [Shopping] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [Shopping] SET  MULTI_USER 
GO

ALTER DATABASE [Shopping] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Shopping] SET DB_CHAINING OFF 
GO


USE [Shopping]
GO

/****** SQL query for creation of table where the list of items available for purchase are stored ******/
/****** Object:  Table [dbo].[ShoppingItems]    Script Date: 05/15/2012 15:34:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ShoppingItems](
	[ItemId] [int] NOT NULL,
	[ItemName] [varchar](max) NOT NULL,
	[Price] [int] NOT NULL,
 CONSTRAINT [PK_ShoppingItems] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


USE [Shopping]
GO

/****** SQL query for creation of table where the final invoice amount is stored for every invoice ******/
/****** Object:  Table [dbo].[InvoiceData]    Script Date: 05/15/2012 15:37:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[InvoiceData](
	[InvoiceValue] [int] NOT NULL
) ON [PRIMARY]

GO

/****** SQL query for insertion of initial data for the DB of list of items available ******/

INSERT INTO [Shopping].[dbo].[ShoppingItems]
           ([ItemId]
           ,[ItemName]
           ,[Price])
     VALUES
           (1
           ,'USB Pen Drive'
           ,2500)
GO

INSERT INTO [Shopping].[dbo].[ShoppingItems]
           ([ItemId]
           ,[ItemName]
           ,[Price])
     VALUES
           (2
           ,'HP Laptop'
           ,45000)
GO


INSERT INTO [Shopping].[dbo].[ShoppingItems]
           ([ItemId]
           ,[ItemName]
           ,[Price])
     VALUES
           (3
           ,'Beats Headphone'
           ,5000)
GO


INSERT INTO [Shopping].[dbo].[ShoppingItems]
           ([ItemId]
           ,[ItemName]
           ,[Price])
     VALUES
           (4
           ,'DVD Player'
           ,10000)
GO


INSERT INTO [Shopping].[dbo].[ShoppingItems]
           ([ItemId]
           ,[ItemName]
           ,[Price])
     VALUES
           (5
           ,'Targus Travel Adapter'
           ,2000)
GO


INSERT INTO [Shopping].[dbo].[ShoppingItems]
           ([ItemId]
           ,[ItemName]
           ,[Price])
     VALUES
           (6
           ,'iPhone 4S 8GB'
           ,44500)
GO


INSERT INTO [Shopping].[dbo].[ShoppingItems]
           ([ItemId]
           ,[ItemName]
           ,[Price])
     VALUES
           (7
           ,'HTC One X'
           ,37000)
GO


INSERT INTO [Shopping].[dbo].[ShoppingItems]
           ([ItemId]
           ,[ItemName]
           ,[Price])
     VALUES
           (8
           ,'Alienware laptop'
           ,115000)
GO


INSERT INTO [Shopping].[dbo].[ShoppingItems]
           ([ItemId]
           ,[ItemName]
           ,[Price])
     VALUES
           (9
           ,'Logitech Laser mouse'
           ,1500)
GO


INSERT INTO [Shopping].[dbo].[ShoppingItems]
           ([ItemId]
           ,[ItemName]
           ,[Price])
     VALUES
           (10
           ,'Benq Projector'
           ,50000)
GO

