CREATE TABLE [common].[Rodeo_Machine_Types](
	[IdMachineType] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[PrefixName] [varchar](10) NOT NULL,
	[DefaultMechanicalDrawningsPath] [varchar] (MAX) NULL,
	[DefaultElectricalDrawningsPath] [varchar] (MAX) NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Rodeo_Machine_Types] PRIMARY KEY CLUSTERED 
(
	[IdMachineType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Rodeo_Machine_Type_Name] UNIQUE NONCLUSTERED 
(
	[PrefixName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
 
CREATE UNIQUE NONCLUSTERED INDEX [IX_Rodeo_Machine_Types_Name] ON [common].[Rodeo_Machine_Types]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

ALTER TABLE [common].[Rodeo_Machine_Types] ADD  CONSTRAINT [DF_Rodeo_Machine_Types_Active]  DEFAULT ((1)) FOR [Active]
GO




