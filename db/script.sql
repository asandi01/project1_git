USE [master]
GO
/****** Object:  Database [personalPayments]    Script Date: 13/3/2018 08:10:12 ******/
CREATE DATABASE [personalPayments]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'personalPayments', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\personalPayments.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'personalPayments_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\personalPayments_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [personalPayments] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [personalPayments].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [personalPayments] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [personalPayments] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [personalPayments] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [personalPayments] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [personalPayments] SET ARITHABORT OFF 
GO
ALTER DATABASE [personalPayments] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [personalPayments] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [personalPayments] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [personalPayments] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [personalPayments] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [personalPayments] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [personalPayments] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [personalPayments] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [personalPayments] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [personalPayments] SET  DISABLE_BROKER 
GO
ALTER DATABASE [personalPayments] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [personalPayments] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [personalPayments] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [personalPayments] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [personalPayments] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [personalPayments] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [personalPayments] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [personalPayments] SET RECOVERY FULL 
GO
ALTER DATABASE [personalPayments] SET  MULTI_USER 
GO
ALTER DATABASE [personalPayments] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [personalPayments] SET DB_CHAINING OFF 
GO
ALTER DATABASE [personalPayments] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [personalPayments] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [personalPayments] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'personalPayments', N'ON'
GO
ALTER DATABASE [personalPayments] SET QUERY_STORE = OFF
GO
USE [personalPayments]
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
USE [personalPayments]
GO
/****** Object:  Table [dbo].[expenseCategory]    Script Date: 13/3/2018 08:10:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[expenseCategory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[detail] [varchar](500) NULL,
	[priority] [int] NULL,
 CONSTRAINT [PK_expenseCategory] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[incomeRecord]    Script Date: 13/3/2018 08:10:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[incomeRecord](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idUser] [int] NULL,
	[detail] [varchar](500) NULL,
	[amount] [float] NULL,
	[paymentDate] [date] NULL,
 CONSTRAINT [PK_incomeRecord] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[paymentRecord]    Script Date: 13/3/2018 08:10:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[paymentRecord](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[iduser] [int] NULL,
	[detail] [varchar](500) NULL,
	[amount] [float] NULL,
	[recurrence] [bit] NULL,
	[recurrenciaTypeId] [int] NULL,
	[paymentDate] [date] NULL,
	[providerId] [int] NULL,
	[expenseCategoryId] [int] NULL,
 CONSTRAINT [PK_paymentRecord] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[provider]    Script Date: 13/3/2018 08:10:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[provider](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[detail] [varchar](500) NULL,
 CONSTRAINT [PK_provider] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[recurenceType]    Script Date: 13/3/2018 08:10:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[recurenceType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[detail] [varchar](500) NULL,
	[days] [int] NULL,
 CONSTRAINT [PK_recurenceType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 13/3/2018 08:10:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[idUsers] [int] NOT NULL,
	[login] [varchar](50) NULL,
	[password] [varchar](50) NULL,
	[name] [varchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[idUsers] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[incomeRecord]  WITH CHECK ADD  CONSTRAINT [FK_incomeRecord_user] FOREIGN KEY([idUser])
REFERENCES [dbo].[users] ([idUsers])
GO
ALTER TABLE [dbo].[incomeRecord] CHECK CONSTRAINT [FK_incomeRecord_user]
GO
/****** Object:  StoredProcedure [dbo].[AddExpenseCategoryType]    Script Date: 13/3/2018 08:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[AddExpenseCategoryType](
	@detail varchar(500),
	@priority int
)  
as
begin
	Insert into expenseCategory values(
		@detail,
		@priority
	)
End
GO
/****** Object:  StoredProcedure [dbo].[AddIncomeRecord]    Script Date: 13/3/2018 08:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[AddIncomeRecord](
	@idUser int,
	@detail varchar(500),
	@amount float,
	@paymentDate date
)  
as
begin
	Insert into incomeRecord values(
		@idUser,
		@detail,
		@amount,
		@paymentDate
	)
End;
GO
/****** Object:  StoredProcedure [dbo].[AddNewPayment]    Script Date: 13/3/2018 08:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[AddNewPayment](
	@idPaymentRecord int,
	@idUser int,
    @anount float,
    @recurrence int,
    @recurrenceType int,
    @paymentDate date,
    @serviceType int,
	@detail varchar(500),
    @provider varchar(500)
)  
as
begin
	Insert into paymentRecord values(
		@idPaymentRecord,
		@idUser,
		@anount,
		@recurrence,
		@recurrenceType,
		@paymentDate,
		@serviceType,
		@detail,
		@provider
	)
End
GO
/****** Object:  StoredProcedure [dbo].[AddNewProvider]    Script Date: 13/3/2018 08:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create    procedure [dbo].[AddNewProvider](
	@detail varchar(500)
)  
as
begin
	Insert into provider values(
		@detail
	)
End
GO
/****** Object:  StoredProcedure [dbo].[AddNewRecurenceType]    Script Date: 13/3/2018 08:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create   procedure [dbo].[AddNewRecurenceType](
	@detail varchar(500),
	@days int
)  
as
begin
	Insert into recurenceType values(
		@detail,
		@days
	)
End
GO
/****** Object:  StoredProcedure [dbo].[AddPaymentRecord]    Script Date: 13/3/2018 08:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[AddPaymentRecord](
	@idUser int,
	@detail varchar(500),
	@amount float,
	@recurrence int,
	@recurrenciaTypeId int,
	@paymentDate date,
	@providerId int,
	@expenseCategoryId int
)  
as
begin
	Insert into paymentRecord values(
		@idUser,
		@detail,
		@amount,
		@recurrence,
		@recurrenciaTypeId,
		@paymentDate,
		@providerId,
		@expenseCategoryId
	)
End;
GO
/****** Object:  StoredProcedure [dbo].[DeleteexpenseCategory]    Script Date: 13/3/2018 08:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[DeleteexpenseCategory](  
   @id int  
)  
as   
begin  
   DELETE FROM expenseCategory where id=@id 
End
GO
/****** Object:  StoredProcedure [dbo].[DeleteIncomeRecord]    Script Date: 13/3/2018 08:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[DeleteIncomeRecord](  
   @id int
)  
as   
begin  
   DELETE FROM incomeRecord where id=@id 
End;
GO
/****** Object:  StoredProcedure [dbo].[DeletePayment]    Script Date: 13/3/2018 08:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[DeletePayment]  
(  
   @idPaymentRecord int  
)  
as   
begin  
   DELETE FROM paymentRecord where idPaymentRecord=@idPaymentRecord 
End
GO
/****** Object:  StoredProcedure [dbo].[DeletePaymentRecord]    Script Date: 13/3/2018 08:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[DeletePaymentRecord](  
   @id int
)  
as   
begin  
   DELETE FROM paymentRecord where id=@id 
End;
GO
/****** Object:  StoredProcedure [dbo].[DeleteProvider]    Script Date: 13/3/2018 08:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[DeleteProvider](  
   @id int  
)  
as   
begin  
   DELETE FROM provider where id=@id 
End
GO
/****** Object:  StoredProcedure [dbo].[DeleteRecurenceType]    Script Date: 13/3/2018 08:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[DeleteRecurenceType](  
   @id int  
)  
as   
begin  
   DELETE FROM recurenceType where id=@id 
End
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 13/3/2018 08:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[DeleteUser]  
(  
   @idUsers int  
)  
as   
begin  
   Delete from users where idUsers=@idUsers 
End
GO
/****** Object:  StoredProcedure [dbo].[GetAlerts]    Script Date: 13/3/2018 08:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   Procedure [dbo].[GetAlerts]  

AS  
BEGIN  
	SELECT p.paymentDate
		,p.id
		,p.detail
		,p.amount
		, rt.days
		,DATEADD(day, rt.days, p.paymentDate) AS sumDate
	FROM [dbo].[paymentRecord] p
		INNER JOIN [dbo].[recurenceType] rt 
		ON p.recurrenciaTypeId = rt.id
		WHERE p.recurrence = 1;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetexpenseCategorys]    Script Date: 13/3/2018 08:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[GetexpenseCategorys]  
as  
begin  
   select * from expenseCategory
End
GO
/****** Object:  StoredProcedure [dbo].[GetFutureProjectionsIncoment]    Script Date: 13/3/2018 08:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   Procedure [dbo].[GetFutureProjectionsIncoment]
AS  
BEGIN  
	SELECT 
		SUM(i.amount) AS incomentMonth
	FROM [dbo].[incomeRecord] i
	WHERE DATEPART(month, i.paymentDate) = MONTH(getdate())
END;
GO
/****** Object:  StoredProcedure [dbo].[GetFutureProjectionsPay]    Script Date: 13/3/2018 08:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   Procedure [dbo].[GetFutureProjectionsPay]
AS  
BEGIN  
	SELECT 
		SUM(CAST(p.amount/rt.days AS float)*30) AS payMonth
	FROM [dbo].[paymentRecord] p
	INNER JOIN [dbo].[recurenceType] rt
		ON p.recurrenciaTypeId = rt.id
	WHERE DATEPART(month, p.paymentDate) = MONTH(getdate())
	AND p.recurrence = 1
END;
GO
/****** Object:  StoredProcedure [dbo].[GetFutureProjectionsSaving]    Script Date: 13/3/2018 08:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   Procedure [dbo].[GetFutureProjectionsSaving]
AS  
BEGIN  
	SELECT 
		SUM(CAST(p.amount/rt.days AS float)*30) AS payMonth
	FROM [dbo].[paymentRecord] p
	INNER JOIN [dbo].[recurenceType] rt
		ON p.recurrenciaTypeId = rt.id
	INNER JOIN [dbo].[expenseCategory] ec
		ON p.expenseCategoryId = ec.id

	WHERE DATEPART(month, p.paymentDate) = MONTH(getdate())
	AND p.recurrence = 1
	AND ec.priority = 1
END;
GO
/****** Object:  StoredProcedure [dbo].[GetIncomentByMonth]    Script Date: 13/3/2018 08:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   Procedure [dbo].[GetIncomentByMonth]  
	@montLess int
AS  
BEGIN 
	SELECT  SUM(i.amount) AS sumamount
	FROM [dbo].[incomeRecord] i
	WHERE DATEPART(month, i.paymentDate) = MONTH(getdate()) - @montLess
END;
GO
/****** Object:  StoredProcedure [dbo].[GetIncomeRecords]    Script Date: 13/3/2018 08:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[GetIncomeRecords](
	@idUser int
)
as  
begin  
   select * from incomeRecord WHERE idUser = @idUser
End;
GO
/****** Object:  StoredProcedure [dbo].[GetPayment]    Script Date: 13/3/2018 08:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[GetPayment]  
as  
begin  
   select * from paymentRecord
End
GO
/****** Object:  StoredProcedure [dbo].[GetPaymentByExpenseCategoryCurrentMonth]    Script Date: 13/3/2018 08:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   Procedure [dbo].[GetPaymentByExpenseCategoryCurrentMonth]
AS  
BEGIN  
	SELECT 
		ec.detail
		,SUM(p.amount) AS sumamount
		
	FROM [dbo].[paymentRecord] p
	INNER JOIN expenseCategory ec
		ON p.expenseCategoryId = ec.id
	WHERE DATEPART(month, p.paymentDate) = MONTH(getdate())
	GROUP BY ec.detail
END;
GO
/****** Object:  StoredProcedure [dbo].[GetPaymentCurrentMonth]    Script Date: 13/3/2018 08:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   Procedure [dbo].[GetPaymentCurrentMonth]  
	@montLess int
AS  
BEGIN  
	SELECT  SUM(p.amount) AS sumamount
	FROM [dbo].[paymentRecord] p
	WHERE DATEPART(month, p.paymentDate) = MONTH(getdate()) - @montLess
END;
GO
/****** Object:  StoredProcedure [dbo].[GetPaymentRecords]    Script Date: 13/3/2018 08:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create Procedure [dbo].[GetPaymentRecords](
	@idUser int
)
as  
begin  
   select * from paymentRecord WHERE idUser = @idUser
End;
GO
/****** Object:  StoredProcedure [dbo].[GetProviders]    Script Date: 13/3/2018 08:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[GetProviders]  
as  
begin  
   select * from provider
End
GO
/****** Object:  StoredProcedure [dbo].[GetRecurenceTypes]    Script Date: 13/3/2018 08:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[GetRecurenceTypes]  
as  
begin  
   select * from recurenceType
End
GO
/****** Object:  StoredProcedure [dbo].[GetStudentDetails]    Script Date: 13/3/2018 08:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[GetStudentDetails]  
as  
begin  
   select * from StudentReg
End
GO
/****** Object:  StoredProcedure [dbo].[GetuserDetails]    Script Date: 13/3/2018 08:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[GetuserDetails]  
as  
begin  
   select * from users
End
GO
/****** Object:  StoredProcedure [dbo].[UpdateexpenseCategory]    Script Date: 13/3/2018 08:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[UpdateexpenseCategory](  
	@id int,
	@detail varchar(500),
	@priority int
) 
as  
begin  
	UPDATE [expenseCategory]   
		SET
		[detail] = @detail,
		[priority] = @priority
			WHERE [id] = @id
End
GO
/****** Object:  StoredProcedure [dbo].[UpdateIncomeRecord]    Script Date: 13/3/2018 08:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[UpdateIncomeRecord](  
	@id int,
	@detail varchar(500),
	@amount float,
	@paymentDate date
) 
as  
begin  
	UPDATE [incomeRecord]   
		SET
		[detail] = @detail,
		[amount] = @amount,
		[paymentDate] = @paymentDate
			WHERE [id] = @id
End;
GO
/****** Object:  StoredProcedure [dbo].[UpdatePayment]    Script Date: 13/3/2018 08:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[UpdatePayment](  
	@idPaymentRecord int,
	@idUser int,
	@amount float,
	@recurrence int,
	@recurrenceType int,
	@paymentDate date,
	@serviceType int,
	@detail varchar(500),
	@provider varchar(500)
) 
as  
begin  
	UPDATE [paymentRecord]   
		SET
		[idUser] = @idUser,
		[amount] = @amount,
		[recurrence] = @recurrence,
		[recurrenceType] = @recurrenceType,
		[paymentDate] = @paymentDate,
		[serviceType] = @serviceType,
		[detail] = @detail,
		[provider] = @provider
			WHERE [idPaymentRecord] = @idPaymentRecord
End
GO
/****** Object:  StoredProcedure [dbo].[UpdatePaymentRecord]    Script Date: 13/3/2018 08:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[UpdatePaymentRecord](  
	@id int,
	@detail varchar(500),
	@amount float,
	@recurrence int,
	@recurrenciaTypeId int,
	@paymentDate date,
	@providerId int,
	@expenseCategoryId int
) 
as  
begin  
	UPDATE [paymentRecord]   
		SET
		[detail] = @detail,
		[amount] = @amount,
		[recurrence] = @recurrence,
		[recurrenciaTypeId] = @recurrenciaTypeId,
		[paymentDate] = @paymentDate,
		[providerId] = @providerId,
		[expenseCategoryId] = @expenseCategoryId
			WHERE [id] = @id
End;
GO
/****** Object:  StoredProcedure [dbo].[UpdateProvider]    Script Date: 13/3/2018 08:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create    procedure [dbo].[UpdateProvider](  
	@id int,
	@detail varchar(500)
) 
as  
begin  
	UPDATE [provider]   
		SET
		[detail] = @detail
			WHERE [id] = @id
End
GO
/****** Object:  StoredProcedure [dbo].[UpdateRecurenceType]    Script Date: 13/3/2018 08:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create   procedure [dbo].[UpdateRecurenceType](  
	@id int,
	@detail varchar(500),
	@days int
) 
as  
begin  
	UPDATE [recurenceType]   
		SET
		[detail] = @detail,
		[days] = @days
			WHERE [id] = @id
End
GO
/****** Object:  StoredProcedure [dbo].[UpdateUserDetails]    Script Date: 13/3/2018 08:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UpdateUserDetails]  
(  
   @idUsers int,  
   @login varchar(50),  
   @password varchar(50),  
   @name varchar(50)  
)  
as  
begin  
   Update users   
   set 
   login=@login,  
   password=@password,  
   name=@name
   where idUsers=@idUsers  
End
GO
USE [master]
GO
ALTER DATABASE [personalPayments] SET  READ_WRITE 
GO
