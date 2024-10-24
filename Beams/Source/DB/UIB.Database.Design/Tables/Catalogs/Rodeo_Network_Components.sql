CREATE TABLE [system].[Rodeo_Network_Components](
	[IdNetworkComponent] [int] NOT NULL,
	[IdNetworkComponentType] [int] NOT NULL,
	[IdNetwork] [int] NOT NULL,
	[IdMachine] [int] NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[IPAddress] [varchar](20) NULL,
	[NAT] [varchar](20) NULL,
	[LocalIPAddress1] [varchar](20) NULL,
	[LocalIPAddress2] [varchar](20) NULL,
	[ConnectivityAlarmname] [varchar](70) NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Rodeo_Network_Components] PRIMARY KEY CLUSTERED 
(
	[IdNetworkComponent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Rodeo_Network_Components_Network] UNIQUE NONCLUSTERED 
(
	[IdNetwork] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO 

ALTER TABLE [system].[Rodeo_Network_Components]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_Network_Components_Rodeo_Machines] FOREIGN KEY([IdMachine]) REFERENCES [common].[Rodeo_Machines] ([IdMachine])

GO

ALTER TABLE [system].[Rodeo_Network_Components] CHECK CONSTRAINT [FK_Rodeo_Network_Components_Rodeo_Machines]

GO

ALTER TABLE [system].[Rodeo_Network_Components]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_Network_Components_Rodeo_Network_Component_Types] FOREIGN KEY([IdNetworkComponentType]) REFERENCES [system].[Rodeo_Network_Component_Types] ([IdNetworkComponentType])

GO

ALTER TABLE [system].[Rodeo_Network_Components] CHECK CONSTRAINT [FK_Rodeo_Network_Components_Rodeo_Network_Component_Types]

GO

ALTER TABLE [system].[Rodeo_Network_Components]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_Network_Components_Rodeo_Networks] FOREIGN KEY([IdNetwork]) REFERENCES [system].[Rodeo_Networks] ([IdNetwork])

GO

ALTER TABLE [system].[Rodeo_Network_Components] CHECK CONSTRAINT [FK_Rodeo_Network_Components_Rodeo_Networks]

GO

ALTER TABLE [system].[Rodeo_Network_Components] ADD  CONSTRAINT [DF_Rodeo_Network_Components_Active_1]  DEFAULT ((1)) FOR [Active]
