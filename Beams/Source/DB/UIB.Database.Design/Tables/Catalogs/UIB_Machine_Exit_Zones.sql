CREATE TABLE [safety].[HCM_Machine_Exit_Zones](
	[IdMachine] [int] NOT NULL,
	[IdZone] [int] NOT NULL,
	[Move_IdYard] [int] NULL,
	[Move_XPos] [int] NULL,
	[Move_YPos] [int] NULL,
	[Move_IdLocation] [int] NULL,
	[Priority] [smallint] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_HCM_Machine_Exit_Zones] PRIMARY KEY CLUSTERED 
(
	[IdZone] ASC,
	[IdMachine] ASC,
	[Priority] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO 

ALTER TABLE [safety].[HCM_Machine_Exit_Zones]  WITH CHECK ADD  CONSTRAINT [FK_HCM_Machine_Exit_Zones_HCM_Machines] FOREIGN KEY([IdMachine]) REFERENCES [common].[Rodeo_Machines] ([IdMachine])

GO

ALTER TABLE [safety].[HCM_Machine_Exit_Zones] CHECK CONSTRAINT [FK_HCM_Machine_Exit_Zones_HCM_Machines]

GO

ALTER TABLE [safety].[HCM_Machine_Exit_Zones]  WITH CHECK ADD  CONSTRAINT [FK_HCM_Machine_Exit_Zones_HCM_Zones] FOREIGN KEY([IdZone]) REFERENCES [safety].[HCM_Zones] ([IdZone])

GO

ALTER TABLE [safety].[HCM_Machine_Exit_Zones] CHECK CONSTRAINT [FK_HCM_Machine_Exit_Zones_HCM_Zones]

GO

ALTER TABLE [safety].[HCM_Machine_Exit_Zones]  WITH CHECK ADD  CONSTRAINT [FK_HCM_Machine_Exit_Zones_Rodeo_Yards] FOREIGN KEY([Move_IdYard]) REFERENCES [common].[Rodeo_Yards] ([IdYard])
GO

ALTER TABLE [safety].[HCM_Machine_Exit_Zones] CHECK CONSTRAINT [FK_HCM_Machine_Exit_Zones_Rodeo_Yards]
GO

ALTER TABLE [safety].[HCM_Machine_Exit_Zones]  WITH CHECK ADD  CONSTRAINT [FK_HCM_Machine_Exit_Zones_Rodeo_Locations] FOREIGN KEY([Move_IdLocation]) REFERENCES [common].[Rodeo_Locations] ([IdLocation])

GO

ALTER TABLE [safety].[HCM_Machine_Exit_Zones] CHECK CONSTRAINT [FK_HCM_Machine_Exit_Zones_Rodeo_Locations]

GO

ALTER TABLE [safety].[HCM_Machine_Exit_Zones]  WITH CHECK ADD  CONSTRAINT [CK_HCM_Machine_Exit_Zones] CHECK  (([Move_XPos] IS NOT NULL AND [Move_YPos] IS NOT NULL) OR [Move_IdLocation] IS NOT NULL)
GO

ALTER TABLE [safety].[HCM_Machine_Exit_Zones] CHECK CONSTRAINT [CK_HCM_Machine_Exit_Zones]
GO

ALTER TABLE [safety].[HCM_Machine_Exit_Zones] ADD  CONSTRAINT [DF_Machine_Exit_Zones_Active]  DEFAULT ((1)) FOR [Active]
