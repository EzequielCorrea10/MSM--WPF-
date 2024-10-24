CREATE TABLE [common].[Rodeo_Location_Types](
	[IdLocationType] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[PlcValue] [int] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Rodeo_Location_Types] PRIMARY KEY CLUSTERED 
(
	[IdLocationType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [common].[Rodeo_Location_Types] ADD  CONSTRAINT [DF_Rodeo_Location_Types_Active]  DEFAULT ((1)) FOR [Active]
GO