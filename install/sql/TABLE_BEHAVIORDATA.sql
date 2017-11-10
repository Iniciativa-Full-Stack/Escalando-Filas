
/****** Object:  Table [dbo].[BEHAVIORDATA]    Script Date: 11/10/2017 9:25:38 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BEHAVIORDATA](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[IP] [varchar](16) NULL,
	[Url] [varchar](1000) NULL,
	[Referrer] [varchar](1000) NULL,
	[UserAgent] [varchar](1000) NULL,
	[Created] [datetime] NULL,
	[DataBag] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


