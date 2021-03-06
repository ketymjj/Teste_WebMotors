USE [teste_webmotors]
GO
/****** Object:  Table [dbo].[tb_AnuncioWebmotors]    Script Date: 05/04/2020 13:54:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_AnuncioWebmotors](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[marca] [varchar](45) NOT NULL,
	[modelo] [varchar](45) NOT NULL,
	[versao] [varchar](45) NOT NULL,
	[ano] [int] NOT NULL,
	[quilometragem] [int] NOT NULL,
	[observacao] [text] NOT NULL,
 CONSTRAINT [PK_tb_AnuncioWebmotors] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
