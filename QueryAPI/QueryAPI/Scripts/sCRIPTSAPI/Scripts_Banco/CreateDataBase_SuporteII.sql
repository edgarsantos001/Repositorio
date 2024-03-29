USE [master]
GO

/****** Object:  Database [SUPORTE_II]    Script Date: 02/04/2019 09:01:10 ******/
CREATE DATABASE [SUPORTE_II]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SUPORTE_II', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\SUPORTE_II.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SUPORTE_II_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\SUPORTE_II_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [SUPORTE_II] SET COMPATIBILITY_LEVEL = 120
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SUPORTE_II].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [SUPORTE_II] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [SUPORTE_II] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [SUPORTE_II] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [SUPORTE_II] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [SUPORTE_II] SET ARITHABORT OFF 
GO

ALTER DATABASE [SUPORTE_II] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [SUPORTE_II] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [SUPORTE_II] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [SUPORTE_II] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [SUPORTE_II] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [SUPORTE_II] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [SUPORTE_II] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [SUPORTE_II] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [SUPORTE_II] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [SUPORTE_II] SET  DISABLE_BROKER 
GO

ALTER DATABASE [SUPORTE_II] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [SUPORTE_II] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [SUPORTE_II] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [SUPORTE_II] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [SUPORTE_II] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [SUPORTE_II] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [SUPORTE_II] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [SUPORTE_II] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [SUPORTE_II] SET  MULTI_USER 
GO

ALTER DATABASE [SUPORTE_II] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [SUPORTE_II] SET DB_CHAINING OFF 
GO

ALTER DATABASE [SUPORTE_II] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [SUPORTE_II] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [SUPORTE_II] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [SUPORTE_II] SET  READ_WRITE 
GO


