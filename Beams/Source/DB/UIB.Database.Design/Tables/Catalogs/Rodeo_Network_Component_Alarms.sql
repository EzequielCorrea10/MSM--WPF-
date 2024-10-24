CREATE TABLE [system].[Rodeo_Network_Component_Alarms](
	[IdNetworkComponent] [int] NOT NULL,
	[Sequence] [int] NOT NULL,
	[IdMachine] [int] NULL,
	[Description] [varchar](200) NOT NULL,
	[Alarmname] [varchar](70) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Rodeo_Network_Component_Alarms] PRIMARY KEY CLUSTERED 
(
	[IdNetworkComponent] ASC,
	[Sequence] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
) ON [PRIMARY]
GO 

ALTER TABLE [system].[Rodeo_Network_Component_Alarms]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_Network_Component_Alarms_Rodeo_Networks] FOREIGN KEY([IdNetworkComponent]) REFERENCES [system].[Rodeo_Network_Components] ([IdNetworkComponent])
GO

ALTER TABLE [system].[Rodeo_Network_Component_Alarms] CHECK CONSTRAINT [FK_Rodeo_Network_Component_Alarms_Rodeo_Networks]
GO

ALTER TABLE [system].[Rodeo_Network_Component_Alarms]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_Network_Component_Alarms_Rodeo_Machines] FOREIGN KEY([IdMachine]) REFERENCES [common].[Rodeo_Machines] ([IdMachine])
GO

ALTER TABLE [system].[Rodeo_Network_Component_Alarms] CHECK CONSTRAINT [FK_Rodeo_Network_Component_Alarms_Rodeo_Machines]
GO

ALTER TABLE [system].[Rodeo_Network_Component_Alarms] ADD  CONSTRAINT [DF_Rodeo_Network_Component_Alarms_Active]  DEFAULT ((1)) FOR [Active]
