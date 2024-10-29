CREATE TABLE [common].[Rodeo_Locations](
	[IdLocation] [int] NOT NULL,
	[IdLocationType] [int] NOT NULL,
	[IdLocationGroup] [int] NOT NULL,
	[IdLocationRange] [int] NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[IdYard] [int] NOT NULL,
	[XPos] [int] NOT NULL,
	[YPos] [int] NOT NULL,
	[ZPos] [int] NULL,
	[TheoricalXMin] [int] NULL,
	[TheoricalYMin] [int] NULL,
	[TheoricalZMin] [int] NULL,
	[TheoricalXMax] [int] NULL,
	[TheoricalYMax] [int] NULL,
	[TheoricalZMax] [int] NULL,
	[ZOrder] SMALLINT NOT NULL,
	[DefaultHeading] [smallint] NOT NULL,
	[Row] [smallint] NULL,
	[Col] [smallint] NULL,
	[IsVertical] [bit] NULL DEFAULT 0,
	[PlcValue] [int] NOT NULL,
	[L3Value] [varchar](20) NOT NULL,
	[RCSValue] [int] NOT NULL,
	[TOLT] [int] NULL,
	[PickupPriority] [int] NULL,
	[StoragePriority] [int] NULL,
	[CarPresent_ReadTagname] [varchar](70) NULL,
	[CarPresent_Bit] [int] NULL,
	[CarPresent_PlcValue] [int] NULL,
	[PiecePresent_ReadTagname] [varchar](70) NULL,
	[PiecePresent_Bit] [int] NULL,
	[PiecePresent_PlcValue] [int] NULL,
	[PieceID_ReadTagname] [varchar](70) NULL,
	[PieceID_WriteTagname] [varchar](70) NULL,
	[PieceID_TriggerTagname] [varchar](70) NULL,
	[PieceID_SetpointValue] [int] NULL,
	[ReadyForPickup_ReadTagname] [varchar](70) NULL,
	[ReadyForPickup_Bit] [int] NULL,
	[ReadyForPickup_PlcValue] [int] NULL,
	[ReadyForStorage_ReadTagname] [varchar](70) NULL,
	[ReadyForStorage_Bit] [int] NULL,
	[ReadyForStorage_PlcValue] [int] NULL,
	[AccessRequest_ReadTagname] [varchar](70) NULL,
	[AccessRequest_Bit] [int] NULL,
	[AccessRequest_PlcValue] [int] NULL,
	[AccessGranted_ReadTagname] [varchar](70) NULL,
	[AccessGranted_Bit] [int] NULL,
	[AccessGranted_PlcValue] [int] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Rodeo_Locations] PRIMARY KEY CLUSTERED 
(
	[IdLocation] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Rodeo_Locations_PlcValue] UNIQUE NONCLUSTERED 
(
	[PlcValue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_Rodeo_Locations_Name] ON [common].[Rodeo_Locations]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

ALTER TABLE [common].[Rodeo_Locations]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_Locations_Rodeo_Location_Types] FOREIGN KEY([IdLocationType]) REFERENCES [common].[Rodeo_Location_Types] ([IdLocationType])
GO

ALTER TABLE [common].[Rodeo_Locations] CHECK CONSTRAINT [FK_Rodeo_Locations_Rodeo_Location_Types]
GO

ALTER TABLE [common].[Rodeo_Locations]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_Locations_HCM_Location_Groups] FOREIGN KEY([IdLocationGroup]) REFERENCES [common].[HCM_Location_Groups] ([IdLocationGroup])
GO

ALTER TABLE [common].[Rodeo_Locations] CHECK CONSTRAINT [FK_Rodeo_Locations_HCM_Location_Groups]
GO

ALTER TABLE [common].[Rodeo_Locations]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_Locations_HCM_Location_Ranges] FOREIGN KEY([IdLocationRange]) REFERENCES [common].[HCM_Location_Ranges] ([IdLocationRange])
GO

ALTER TABLE [common].[Rodeo_Locations]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_Locations_Rodeo_Yards] FOREIGN KEY([IdYard]) REFERENCES [common].[Rodeo_Yards] ([IdYard])
GO

ALTER TABLE [common].[Rodeo_Locations] CHECK CONSTRAINT [FK_Rodeo_Locations_Rodeo_Yards]
GO

ALTER TABLE [common].[Rodeo_Locations]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_Locations_Rodeo_Locations] FOREIGN KEY([TOLT]) REFERENCES [common].[Rodeo_Locations] ([IdLocation])
GO

ALTER TABLE [common].[Rodeo_Locations] CHECK CONSTRAINT [FK_Rodeo_Locations_Rodeo_Locations]
GO

ALTER TABLE [common].[Rodeo_Locations] ADD  CONSTRAINT [DF_Rodeo_Locations_Active]  DEFAULT ((1)) FOR [Active]
GO
