USE [master]
GO
/****** Object:  Database [Interbet]    Script Date: 2020/01/29 21:57:16 ******/
CREATE DATABASE [Interbet]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Interbet', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Interbet.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Interbet_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Interbet_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Interbet] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Interbet].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Interbet] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Interbet] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Interbet] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Interbet] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Interbet] SET ARITHABORT OFF 
GO
ALTER DATABASE [Interbet] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Interbet] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Interbet] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Interbet] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Interbet] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Interbet] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Interbet] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Interbet] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Interbet] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Interbet] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Interbet] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Interbet] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Interbet] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Interbet] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Interbet] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Interbet] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Interbet] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Interbet] SET RECOVERY FULL 
GO
ALTER DATABASE [Interbet] SET  MULTI_USER 
GO
ALTER DATABASE [Interbet] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Interbet] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Interbet] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Interbet] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Interbet] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Interbet', N'ON'
GO
ALTER DATABASE [Interbet] SET QUERY_STORE = OFF
GO
USE [Interbet]
GO
/****** Object:  Table [dbo].[tblTransactions]    Script Date: 2020/01/29 21:57:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTransactions](
	[UniqueInstanceID] [nvarchar](50) NOT NULL,
	[EffectiveDate] [date] NOT NULL,
	[TransactionCode] [int] NOT NULL,
	[TransactionAmount] [money] NOT NULL,
	[TransactionDate] [date] NOT NULL,
	[TransactionTime] [nvarchar](7) NOT NULL,
	[ChequeNumber] [nvarchar](50) NULL,
	[DrCrIndicator] [nvarchar](50) NOT NULL,
	[BankName] [nvarchar](50) NOT NULL,
	[BranchCode] [int] NOT NULL,
	[ReferenceNumber] [nvarchar](50) NOT NULL,
	[AccountNumber] [nvarchar](50) NOT NULL,
	[Identifier] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[spGetTransactionsByDateRange]    Script Date: 2020/01/29 21:57:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spGetTransactionsByDateRange] 
@FromDate date,
@ToDate date
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT UniqueInstanceID,EffectiveDate,TransactionCode,TransactionAmount,TransactionDate,TransactionTime,ChequeNumber,DrCrIndicator,BankName,BranchCode,ReferenceNumber,AccountNumber,Identifier 
	FROM tblTransactions
	WHERE TransactionDate BETWEEN @FromDate and @ToDate
END

GO
/****** Object:  StoredProcedure [dbo].[spInsertTransactions]    Script Date: 2020/01/29 21:57:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spInsertTransactions]
@UniqueInstanceID nvarchar(50),
@EffectiveDate date,
@TransactionCode int,
@TransactionAmount money,
@TransactionDate date,
@TransactionTime nvarchar(7),
@ChequeNumber nvarchar(50) null,
@DrCrIndicator nvarchar(50),
@BankName nvarchar(50),
@BranchCode int,
@ReferenceNumber nvarchar(50),
@AccountNumber nvarchar(50),
@Identifier nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO tblTransactions(UniqueInstanceID,EffectiveDate,TransactionCode,TransactionAmount,TransactionDate,TransactionTime,ChequeNumber,DrCrIndicator,BankName,BranchCode,ReferenceNumber,AccountNumber,Identifier) VALUES(@UniqueInstanceID,@EffectiveDate,@TransactionCode,@TransactionAmount,@TransactionDate,@TransactionTime,@ChequeNumber,@DrCrIndicator,@BankName,@BranchCode,@ReferenceNumber,@AccountNumber,@Identifier)
END

GO
USE [master]
GO
ALTER DATABASE [Interbet] SET  READ_WRITE 
GO
