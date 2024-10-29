CREATE TABLE [to].[HCM_Machine_Exit_Locations](
	[IdMachine] [int] NOT NULL,
	[IdLocation] [int] NOT NULL,
	[TimeoutMachineIdleInside] [int] NOT NULL,
	[Move_IdLocation] [int] NOT NULL,
	[Priority] [smallint] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_HCM_Machine_Exit_Locations] PRIMARY KEY CLUSTERED 
(
	[IdMachine] ASC,
	[IdLocation] ASC,
	[Priority] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO 

ALTER TABLE [to].[HCM_Machine_Exit_Locations]  WITH CHECK ADD  CONSTRAINT [FK_HCM_Machine_Exit_Locations_HCM_Machines] FOREIGN KEY([IdMachine]) REFERENCES [common].[Rodeo_Machines] ([IdMachine])

GO

ALTER TABLE [to].[HCM_Machine_Exit_Locations] CHECK CONSTRAINT [FK_HCM_Machine_Exit_Locations_HCM_Machines]

GO

ALTER TABLE [to].[HCM_Machine_Exit_Locations]  WITH CHECK ADD  CONSTRAINT [FK_HCM_Machine_Exit_Locations_Rodeo_Locations_Origin] FOREIGN KEY([IdLocation]) REFERENCES [common].[Rodeo_Locations] ([IdLocation])

GO

ALTER TABLE [to].[HCM_Machine_Exit_Locations] CHECK CONSTRAINT [FK_HCM_Machine_Exit_Locations_Rodeo_Locations_Origin]

GO

ALTER TABLE [to].[HCM_Machine_Exit_Locations]  WITH CHECK ADD  CONSTRAINT [FK_HCM_Machine_Exit_Locations_Rodeo_Locations_Destination] FOREIGN KEY([Move_IdLocation]) REFERENCES [common].[Rodeo_Locations] ([IdLocation])

GO

ALTER TABLE [to].[HCM_Machine_Exit_Locations] CHECK CONSTRAINT [FK_HCM_Machine_Exit_Locations_Rodeo_Locations_Destination]

GO

ALTER TABLE [to].[HCM_Machine_Exit_Locations] ADD  CONSTRAINT [DF_Machine_Exit_Locations_Active]  DEFAULT ((1)) FOR [Active]
