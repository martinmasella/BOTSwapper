USE [master]
GO
/****** Object:  Database [ArbitradorGDAL]    Script Date: 19/09/2023 18:25:14 ******/
CREATE DATABASE [ArbitradorGDAL]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ArbitradorGDAL', FILENAME = N'D:\rdsdbdata\DATA\ArbitradorGDAL.mdf' , SIZE = 258432KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'ArbitradorGDAL_log', FILENAME = N'D:\rdsdbdata\DATA\ArbitradorGDAL_log.ldf' , SIZE = 265344KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ArbitradorGDAL] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ArbitradorGDAL].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ArbitradorGDAL] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ArbitradorGDAL] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ArbitradorGDAL] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ArbitradorGDAL] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ArbitradorGDAL] SET ARITHABORT OFF 
GO
ALTER DATABASE [ArbitradorGDAL] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ArbitradorGDAL] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ArbitradorGDAL] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ArbitradorGDAL] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ArbitradorGDAL] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ArbitradorGDAL] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ArbitradorGDAL] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ArbitradorGDAL] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ArbitradorGDAL] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ArbitradorGDAL] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ArbitradorGDAL] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ArbitradorGDAL] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ArbitradorGDAL] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ArbitradorGDAL] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ArbitradorGDAL] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ArbitradorGDAL] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ArbitradorGDAL] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ArbitradorGDAL] SET RECOVERY FULL 
GO
ALTER DATABASE [ArbitradorGDAL] SET  MULTI_USER 
GO
ALTER DATABASE [ArbitradorGDAL] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ArbitradorGDAL] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ArbitradorGDAL] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ArbitradorGDAL] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ArbitradorGDAL] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ArbitradorGDAL] SET QUERY_STORE = OFF
GO
USE [ArbitradorGDAL]
GO
/****** Object:  User [martinmasella]    Script Date: 19/09/2023 18:25:16 ******/
CREATE USER [martinmasella] FOR LOGIN [martinmasella] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [martinmasella]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_Desvio]    Script Date: 19/09/2023 18:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_Desvio]
	(@DT datetime)
	RETURNS DECIMAL(5,2)
AS
/* Probador
select [dbo].[fn_Desvio](getdate())
*/
BEGIN
	declare @Desvio DECIMAL(5,2)

	select @Desvio=STDEV(ratio)*1.5
	from
		(
			SELECT top 180 Ratio
			from MD
			where DT<=@DT
					and
				dt>=Convert(date,getdate())
			order by dt desc
		) tabla
	if @Desvio is null
		begin
			set @desvio=0
		end
	return @Desvio

END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_Max]    Script Date: 19/09/2023 18:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_Max]
	(@DT datetime)
	RETURNS DECIMAL(4,2)
AS
BEGIN
	declare @Max DECIMAL(4,2)

	select
		@Max=Max(Ratio)
	from
		(
			SELECT top 60 Ratio
			from MD
			where DT<=@DT and DT>=convert(date,getdate())
		) tabla
	RETURN @Max
END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_Min]    Script Date: 19/09/2023 18:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_Min]
	(@DT datetime)
	RETURNS DECIMAL(4,2)
AS
BEGIN
	declare @Min DECIMAL(4,2)

	select
		@Min=Min(Ratio)
	from
		(
			SELECT top 60 Ratio
			from MD
			where DT<=@DT and DT>=convert(date,getdate())
		) tabla
	RETURN @Min
END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_MM]    Script Date: 19/09/2023 18:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_MM]
	(@DT datetime)
	RETURNS DECIMAL(4,2)
AS
BEGIN
	declare @MM DECIMAL(4,2)

	select
		@MM=avg(Ratio)
	from
		(
			SELECT top 180 Ratio
			from MD
			where DT<=@DT
					and
				dt>=Convert(date,getdate())
		) tabla
	RETURN @MM
END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_Volatility]    Script Date: 19/09/2023 18:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_Volatility]
	(@DT datetime)
	RETURNS DECIMAL(5,2)
AS
/* Probador
select [dbo].[fn_Volatility](getdate())
*/
BEGIN
	declare @Volatilidad DECIMAL(5,2)
	SET @Volatilidad=0

	declare @tabla1 table (num int, DT datetime, Ratio decimal (5,2))
	declare @tabla2 table (num int, DT datetime, Ratio decimal (5,2))

	insert into @tabla1
	select top 180 ROW_NUMBER() over (order by DT desc), DT, Ratio
	from MD
	where DT<=@DT and dt>=Convert(date,getdate())
	order by dt desc
	
	insert into @tabla2
	select top 180 ROW_NUMBER() over (order by DT desc), DT, Ratio
	from MD
	where DT < (select MAX(DT) from MD) and DT<=@DT and dt>=Convert(date,getdate())
	order by dt desc

	select @Volatilidad=isnull(STDEV(logTabla.logChange)*100,0) from
	(
		select top 180 log(t1.ratio/(select ratio from @tabla2 t2 where t1.num=t2.num)) as logChange
		from @tabla1 t1
	) as logTabla
	
	return @Volatilidad

END
GO
/****** Object:  Table [dbo].[MarketData]    Script Date: 19/09/2023 18:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MarketData](
	[Ticker] [varchar](50) NOT NULL,
	[DT] [datetime] NOT NULL,
	[BidSize] [int] NOT NULL,
	[Bid] [smallmoney] NOT NULL,
	[Last] [smallmoney] NOT NULL,
	[Ask] [smallmoney] NOT NULL,
	[AskSize] [int] NOT NULL,
	[Stamp] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MD]    Script Date: 19/09/2023 18:25:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MD](
	[DT] [datetime] NOT NULL,
	[GD30Bid] [money] NOT NULL,
	[GD30Last] [money] NOT NULL,
	[GD30Ask] [money] NOT NULL,
	[AL30Bid] [money] NOT NULL,
	[AL30Last] [money] NOT NULL,
	[AL30Ask] [money] NOT NULL,
	[Ratio]  AS (([GD30Last]/[AL30Last]-(1))*(100)) PERSISTED,
	[GDAL]  AS (([GD30Bid]/[AL30Ask]-(1))*(100)) PERSISTED,
	[ALGD]  AS (([GD30Ask]/[AL30Bid]-(1))*(100)) PERSISTED,
	[GDAL_Last]  AS (([GD30Last]/[AL30Ask]-(1))*(100)) PERSISTED,
	[ALGD_Last]  AS (([AL30Last]/[GD30Ask]-(1))*(100)) PERSISTED,
 CONSTRAINT [PK_MD] PRIMARY KEY CLUSTERED 
(
	[DT] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sintetica]    Script Date: 19/09/2023 18:25:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sintetica](
	[DT] [datetime] NOT NULL,
	[CALLQBid] [int] NULL,
	[CALLBid] [money] NULL,
	[CALLLast] [money] NULL,
	[CALLAsk] [money] NULL,
	[CALLQAsk] [int] NULL,
	[GGALBid] [money] NULL,
	[GGALLast] [money] NULL,
	[GGALAsk] [money] NULL,
	[PUTQBid] [int] NULL,
	[PUTBid] [money] NULL,
	[PUTLast] [money] NULL,
	[PUTAsk] [money] NULL,
	[PUTQAsk] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetData]    Script Date: 19/09/2023 18:25:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_GetData]
	@dt datetime=null
as
/*
probador
sp_getdata '20220929'
*/
if @dt is null
	SET @dt=getdate()

select top 1
	Cast(Cast(DT as Time(0)) as varchar) DT,
	cast(Ratio as Decimal(4,2)) Ratio,
	[dbo].[fn_MM](DT) MM180,
	cast(GDAL as Decimal (4,2)) GDAL,
	Cast(ALGD as Decimal (4,2)) ALGD,
	cast(GDAL_Last as Decimal (4,2)) GDAL_Last,
	Cast(ALGD_Last as Decimal (4,2)) ALGD_Last,
	[dbo].[fn_Max](DT) Techo,
	[dbo].[fn_Min](DT) Piso,
	[dbo].[fn_Volatility](DT) Volatilidad,
	[dbo].[fn_Desvio](DT) Desvio
from
	MD
where
	dt>=Convert(date,@dt)
order by
	DT desc
GO
/****** Object:  StoredProcedure [dbo].[sp_GetDataSet]    Script Date: 19/09/2023 18:25:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO









CREATE proc [dbo].[sp_GetDataSet]
	@dt datetime=null
as

if @dt is null
	SET @dt=getdate()

select top 60
	Cast(Cast(DT as Time(0)) as varchar) DT,
	Ratio,
	[dbo].[fn_MM](DT) MM180,
	cast(GDAL as Decimal (4,2)) GDAL,
	Cast(ALGD as Decimal (4,2)) ALGD,
	cast(GDAL_Last as Decimal (4,2)) GDAL_Last,
	Cast(ALGD_Last as Decimal (4,2)) ALGD_Last
from
	MD

where
	dt>=Convert(date,@dt)

order by
	DT desc
GO
/****** Object:  StoredProcedure [dbo].[sp_MarketData_INS]    Script Date: 19/09/2023 18:25:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_MarketData_INS]
(
	@DT DateTime,
	@Ticker VARCHAR(50),
	@BidSize int,
	@Bid money,
	@Last money,
	@Ask money,
	@AskSize money,
	@Stamp DateTime
)
AS
BEGIN
	INSERT INTO MarketData
		(DT,
		Ticker,
		BidSize,
		Bid,
		[Last],
		Ask,
		AskSize,
		Stamp)
	VALUES
		(@DT,
		@Ticker,
		@BidSize,
		@Bid,
		@Last,
		@Ask,
		@AskSize,
		@Stamp)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_MD_INS]    Script Date: 19/09/2023 18:25:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_MD_INS]
	@dt datetime,
	@GD30Bid smallmoney = 0,
	@GD30Last smallmoney =0,
	@GD30Ask smallmoney=0,
	@AL30Bid smallmoney = 0,
	@AL30Last smallmoney =0,
	@AL30Ask smallmoney=0
AS
	insert into MD (DT, GD30Bid, GD30Last, GD30Ask, AL30Bid, AL30Last, AL30Ask)
	values (@dt,@GD30Bid, @GD30Last, @GD30Ask, @AL30Bid, @AL30Last, @AL30Ask)
GO
/****** Object:  StoredProcedure [dbo].[sp_Sintetica_INS]    Script Date: 19/09/2023 18:25:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_Sintetica_INS]
	@DT datetime,
	@CALLQBid int null,
	@CALLBid money null,
	@CALLLast money null,
	@CALLAsk money null,
	@CALLQAsk int null,
	@GGALBid money null,
	@GGALLast money null,
	@GGALAsk money null,
	@PUTQBid int null,
	@PUTBid money null,
	@PUTLast money null,
	@PUTAsk money null,
	@PUTQAsk int null
as
	insert into Sintetica
		(dt,
		CALLQBid,
		CALLBid,
		CALLLast,
		CALLAsk,
		CALLQAsk,
		GGALBid,
		GGALLast,
		GGALAsk,
		PUTQBid,
		PUTBid,
		PUTLast,
		PUTAsk,
		PUTQAsk)
	values
		(@DT,
		@CALLQBid,
		@CALLBid,
		@CALLLast,
		@CALLAsk,
		@CALLQAsk,
		@GGALBid,
		@GGALLast,
		@GGALAsk,
		@PUTQBid,
		@PUTBid,
		@PUTLast,
		@PUTAsk,
		@PUTQAsk)
GO
USE [master]
GO
ALTER DATABASE [ArbitradorGDAL] SET  READ_WRITE 
GO
