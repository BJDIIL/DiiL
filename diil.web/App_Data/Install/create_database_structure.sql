USE [master]
GO
/****** Object:  Database [DiiL]    Script Date: 2018/4/24 22:37:40 ******/
CREATE DATABASE [DiiL]
 go
 
USE [DiiL]
GO
/****** Object:  Table [dbo].[Article]    Script Date: 2018/4/24 22:37:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Article](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ArticleId] [uniqueidentifier] NOT NULL,
	[Content] [text] NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Article] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Log]    Script Date: 2018/4/24 22:37:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Thread] [varchar](255) NOT NULL,
	[Level] [varchar](50) NOT NULL,
	[Logger] [varchar](255) NOT NULL,
	[Message] [varchar](4000) NOT NULL,
	[Exception] [varchar](2000) NULL
) ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [DiiL] SET  READ_WRITE 
GO
