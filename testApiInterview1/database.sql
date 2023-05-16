USE [demoTest]
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 5/15/2023 6:56:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[Name] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[PhoneNumber] [varchar](12) NOT NULL,
 CONSTRAINT [PK_Contacts_1] PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Contacts] ([Name], [Email], [PhoneNumber]) VALUES (N'jose', N'jose@jose.com', N'123123')
GO
INSERT [dbo].[Contacts] ([Name], [Email], [PhoneNumber]) VALUES (N'jose 3', N'jose3@jose3.com', N'11111')
GO

