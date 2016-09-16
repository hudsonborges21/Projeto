USE [master]
GO
/****** Object:  Database [DBCatequese]    Script Date: 16/09/2016 19:42:59 ******/
CREATE DATABASE [DBCatequese]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBCatequese', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\DBCatequese.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DBCatequese_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\DBCatequese_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DBCatequese] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBCatequese].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBCatequese] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBCatequese] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBCatequese] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBCatequese] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBCatequese] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBCatequese] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DBCatequese] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [DBCatequese] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBCatequese] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBCatequese] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBCatequese] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBCatequese] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBCatequese] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBCatequese] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBCatequese] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBCatequese] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DBCatequese] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBCatequese] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBCatequese] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBCatequese] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBCatequese] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBCatequese] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBCatequese] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBCatequese] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DBCatequese] SET  MULTI_USER 
GO
ALTER DATABASE [DBCatequese] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBCatequese] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBCatequese] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBCatequese] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [DBCatequese]
GO
/****** Object:  Table [dbo].[Aluno]    Script Date: 16/09/2016 19:42:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Aluno](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](60) NOT NULL,
	[Endereco] [varchar](60) NULL,
	[Bairro] [varchar](50) NULL,
	[Numero] [varchar](5) NULL,
	[Cidade] [varchar](60) NULL,
	[CEP] [varchar](9) NULL,
	[UF] [varchar](2) NULL,
	[Naturalidade] [varchar](60) NULL,
	[Pai] [varchar](60) NULL,
	[Mae] [varchar](60) NULL,
	[Batizado] [bit] NULL,
	[DataCadastro] [date] NULL,
	[DataNascimento] [date] NULL,
	[telefone] [varchar](20) NULL,
 CONSTRAINT [PK_Catequista] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Instituicao]    Script Date: 16/09/2016 19:42:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Instituicao](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NULL,
 CONSTRAINT [PK_Instituicao] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Matricula]    Script Date: 16/09/2016 19:42:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Matricula](
	[codigoTurma] [int] NOT NULL,
	[codigoAluno] [int] NOT NULL,
	[data] [date] NULL,
	[status] [varchar](50) NULL,
 CONSTRAINT [PK_Matricula] PRIMARY KEY CLUSTERED 
(
	[codigoTurma] ASC,
	[codigoAluno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Professor]    Script Date: 16/09/2016 19:42:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Professor](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](60) NULL,
	[Endereco] [varchar](60) NULL,
	[Bairro] [varchar](50) NULL,
	[Numero] [varchar](5) NULL,
	[Cidade] [varchar](60) NULL,
	[CEP] [varchar](9) NULL,
	[UF] [varchar](2) NULL,
	[Naturalidade] [varchar](60) NULL,
	[Pai] [varchar](60) NULL,
	[Mae] [varchar](60) NULL,
	[Batizado] [bit] NULL,
	[DataCadastro] [date] NULL,
	[DataNascimento] [date] NULL,
	[telefone] [varchar](20) NULL,
 CONSTRAINT [PK_Catequisando] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Turma]    Script Date: 16/09/2016 19:42:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Turma](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NULL,
	[InstituicaoCodigo] [int] NULL,
	[Curso] [varchar](50) NULL,
	[AnoINI] [varchar](4) NULL,
	[AnoFIM] [varchar](4) NULL,
	[CatequistaCodigo] [int] NULL,
	[DataCadastro] [date] NULL,
 CONSTRAINT [PK_Turma] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [DBCatequese] SET  READ_WRITE 
GO
