CREATE TABLE [system].[Rodeo_Network_Component_Types](
	[IdNetworkComponentType] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[ImagePath] [varchar](100) NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Rodeo_Network_Component_Types] PRIMARY KEY CLUSTERED 
(
	[IdNetworkComponentType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO 

CREATE UNIQUE NONCLUSTERED INDEX [IX_Rodeo_Network_Component_Types_Name] ON [system].[Rodeo_Network_Component_Types]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

ALTER TABLE [system].[Rodeo_Network_Component_Types] ADD  CONSTRAINT [DF_Rodeo_Network_Components_Active]  DEFAULT ((1)) FOR [Active]
