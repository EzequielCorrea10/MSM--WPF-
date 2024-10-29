CREATE TABLE [safety].[HCM_Zones](
	[IdZone] [int] NOT NULL,
	[IdZoneType] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[PlcValue] [int] NOT NULL,
	[IsFirstLine] [bit] NOT NULL,
	[TimeoutMachineIdleInside] [int] NULL,
	[AllowFieldOperation] [bit] NOT NULL,
	[AllowManualOperation] [bit] NOT NULL,
	[AllowManualAuthorization] [bit] NOT NULL,
	[AllowTOAssignOnDisable] [bit] NOT NULL,
	[AllowTravelAssistedOnDisable] [bit] NOT NULL,
	[IsTODestination] [bit] NOT NULL,
	[IdMachineRequiredOnDisable] [int] NULL,
	[Exist_ReadTagname] [varchar](70) NULL,
	[Exist_Bit] [int] NULL,
	[Exist_PlcValue] [int] NULL,
	[Exist_WriteTagname] [varchar](70) NULL,
	[Exist_SetpointValue] [int] NULL,
	[Enable_ReadTagname] [varchar](70) NULL,
	[Enable_Bit] [int] NULL,
	[Enable_PlcValue] [int] NULL,
	[Enable_WriteTagname] [varchar](70) NULL,
	[Enable_SetpointValue] [int] NULL,
	[L2DisableReq_ReadTagname] [varchar](70) NULL,
	[L2DisableReq_Bit] [int] NULL,
	[L2DisableReq_PlcValue] [int] NULL,
	[L2DisableReq_WriteTagname] [varchar](70) NULL,
	[L2DisableReq_SetpointValue] [int] NULL,
	[L2EnableReq_ReadTagname] [varchar](70) NULL,
	[L2EnableReq_Bit] [int] NULL,
	[L2EnableReq_PlcValue] [int] NULL,
	[L2EnableReq_WriteTagname] [varchar](70) NULL,
	[L2EnableReq_SetpointValue] [int] NULL,
	[EnableInterlock_ReadTagname] [varchar](70) NULL,
	[EnableInterlock_Bit] [int] NULL,
	[EnableInterlock_PlcValue] [int] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_HCM_Zones] PRIMARY KEY CLUSTERED 
(
	[IdZone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_HCM_Zones_PlcValue] UNIQUE NONCLUSTERED 
(
	[PlcValue] ASC,
	[IdZoneType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_HCM_Zones_Name] ON [safety].[HCM_Zones]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

ALTER TABLE [safety].[HCM_Zones] ADD  CONSTRAINT [DF_HCM_Zones_IsFirstLine]  DEFAULT ((0)) FOR [IsFirstLine]
GO

ALTER TABLE [safety].[HCM_Zones] ADD  CONSTRAINT [DF_HCM_Zones_AllowFieldOperation]  DEFAULT ((1)) FOR [AllowFieldOperation]
GO

ALTER TABLE [safety].[HCM_Zones] ADD  CONSTRAINT [DF_HCM_Zones_AllowManualOperation]  DEFAULT ((1)) FOR [AllowManualOperation]
GO

ALTER TABLE [safety].[HCM_Zones] ADD  CONSTRAINT [DF_HCM_Zones_AllowManualAuthorization]  DEFAULT ((0)) FOR [AllowManualAuthorization]
GO

ALTER TABLE [safety].[HCM_Zones] ADD  CONSTRAINT [DF_HCM_Zones_Active]  DEFAULT ((1)) FOR [Active]
GO

ALTER TABLE [safety].[HCM_Zones]  WITH CHECK ADD  CONSTRAINT [FK_HCM_Zones_HCM_Zone_Types] FOREIGN KEY([IdZoneType])
REFERENCES [safety].[HCM_Zone_Types] ([IdZoneType])
GO

ALTER TABLE [safety].[HCM_Zones] CHECK CONSTRAINT [FK_HCM_Zones_HCM_Zone_Types]
GO

ALTER TABLE [safety].[HCM_Zones]  WITH CHECK ADD  CONSTRAINT [FK_HCM_Zone_Machines_Rodeo_Machines] FOREIGN KEY([IdMachineRequiredOnDisable]) REFERENCES [common].[Rodeo_Machines] ([IdMachine])

GO

ALTER TABLE [safety].[HCM_Zones] CHECK CONSTRAINT [FK_HCM_Zone_Machines_Rodeo_Machines]

GO