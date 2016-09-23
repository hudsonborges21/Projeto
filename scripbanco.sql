USE [DBCatequese]
GO
/****** Object:  Table [dbo].[Aluno]    Script Date: 22/09/2016 21:41:30 ******/
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
/****** Object:  Table [dbo].[Aula]    Script Date: 22/09/2016 21:41:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Aula](
	[CodigoAula] [int] IDENTITY(1,1) NOT NULL,
	[CodigoTurma] [int] NOT NULL,
	[Data] [date] NULL,
	[Descricao] [varchar](50) NULL,
 CONSTRAINT [PK_Aula] PRIMARY KEY CLUSTERED 
(
	[CodigoAula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Instituicao]    Script Date: 22/09/2016 21:41:30 ******/
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
/****** Object:  Table [dbo].[Matricula]    Script Date: 22/09/2016 21:41:30 ******/
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
/****** Object:  Table [dbo].[Professor]    Script Date: 22/09/2016 21:41:30 ******/
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
/****** Object:  Table [dbo].[Turma]    Script Date: 22/09/2016 21:41:30 ******/
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
