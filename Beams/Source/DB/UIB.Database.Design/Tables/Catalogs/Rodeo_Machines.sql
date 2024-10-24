CREATE TABLE [common].[Rodeo_Machines](
	[IdMachine] [int] NOT NULL,
	[IdMachineType] [int] NOT NULL,
	[IdMachineGroup] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[PrefixID] [smallint] NOT NULL,
	[IdParkingLocation] [int] NULL,
	[IdWorkingLocation] [int] NULL,
	[IdYard] [int] NULL,
	[XAbsoluteOffset] [int] NULL,
	[YAbsoluteOffset] [int] NULL,
	[ZOffset] [int] NOT NULL,
	[X1AbsoluteLimitPos] [int] NULL,
	[X2AbsoluteLimitPos] [int] NULL,
	[Y1AbsoluteLimitPos] [int] NULL,
	[Y2AbsoluteLimitPos] [int] NULL,
	[Z1LimitPos] [int] NULL,
	[Z2LimitPos] [int] NULL,
	[MinHeadingLimit] [int] NULL,
	[MaxHeadingLimit] [int] NULL,
	[IsAutomatic] [bit] NOT NULL,
	[IsManaged] [bit] NOT NULL,
	[MinTravelZPos] [int] NULL,
	[Lenght] [smallint] NULL,
	[YardOrder] [smallint] NULL,
	[AllowDisableZoneOnAuto] [bit] NOT NULL,
	[MechanicalDrawningsPath] [varchar] (MAX) NULL,
	[ElectricalDrawningsPath] [varchar] (MAX) NULL,
	[ColorShown] [varchar](20) NULL,
	[PlcValue] [int] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Rodeo_Machines] PRIMARY KEY CLUSTERED 
(
	[IdMachine] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Rodeo_Machines_Name] UNIQUE NONCLUSTERED 
(
	[IdMachineType] ASC,
	[PrefixID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Rodeo_Machines_PlcValue] UNIQUE NONCLUSTERED 
(
	[PlcValue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_Rodeo_Machines_Name] ON [common].[Rodeo_Machines]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

ALTER TABLE [common].[Rodeo_Machines] ADD  CONSTRAINT [DF_Rodeo_Machines_Active]  DEFAULT ((1)) FOR [Active]
GO

ALTER TABLE [common].[Rodeo_Machines]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_Machines_Rodeo_Locations_Parking] FOREIGN KEY([IdParkingLocation]) REFERENCES [common].[Rodeo_Locations] ([IdLocation])
GO

ALTER TABLE [common].[Rodeo_Machines] CHECK CONSTRAINT [FK_Rodeo_Machines_Rodeo_Locations_Parking]
GO

ALTER TABLE [common].[Rodeo_Machines]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_Machines_Rodeo_Locations_Working] FOREIGN KEY([IdWorkingLocation]) REFERENCES [common].[Rodeo_Locations] ([IdLocation])
GO

ALTER TABLE [common].[Rodeo_Machines] CHECK CONSTRAINT [FK_Rodeo_Machines_Rodeo_Locations_Working]
GO

ALTER TABLE [common].[Rodeo_Machines]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_Machines_Rodeo_Machine_Groups] FOREIGN KEY([IdMachineGroup])
REFERENCES [common].[Rodeo_Machine_Groups] ([IdMachineGroup])
GO

ALTER TABLE [common].[Rodeo_Machines] CHECK CONSTRAINT [FK_Rodeo_Machines_Rodeo_Machine_Groups]
GO

ALTER TABLE [common].[Rodeo_Machines]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_Machines_Rodeo_Machine_Types] FOREIGN KEY([IdMachineType])
REFERENCES [common].[Rodeo_Machine_Types] ([IdMachineType])
GO

ALTER TABLE [common].[Rodeo_Machines] CHECK CONSTRAINT [FK_Rodeo_Machines_Rodeo_Machine_Types]
GO

ALTER TABLE [common].[Rodeo_Machines]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_Machines_Rodeo_Yards] FOREIGN KEY([IdYard])
REFERENCES [common].[Rodeo_Yards] ([IdYard])
GO

ALTER TABLE [common].[Rodeo_Machines] CHECK CONSTRAINT [FK_Rodeo_Machines_Rodeo_Yards]
GO

ALTER TABLE [common].[Rodeo_Machines]  WITH CHECK ADD  CONSTRAINT [CK_Rodeo_Machines] CHECK  (([IdYard] IS NULL AND [YardOrder] IS NULL OR [IdYard] IS NOT NULL AND [YardOrder] IS NOT NULL))
GO

ALTER TABLE [common].[Rodeo_Machines] CHECK CONSTRAINT [CK_Rodeo_Machines]
GO
