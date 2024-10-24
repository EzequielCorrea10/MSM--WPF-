CREATE TABLE [common].[Rodeo_Client_Types](
	[IdClientType] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[AppPath] [varchar](100) NULL,
	[ImagePath] [varchar](100) NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Rodeo_Client_Types] PRIMARY KEY CLUSTERED 
(
	[IdClientType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [common].[Rodeo_Client_Types] ADD  CONSTRAINT [DF_Rodeo_Client_Types_Active]  DEFAULT ((1)) FOR [Active]
GO


