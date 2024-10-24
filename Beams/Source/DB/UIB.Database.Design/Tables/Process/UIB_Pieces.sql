
CREATE TABLE [tracking].[UIB_Pieces](
	[PieceName] [varchar](50) NOT NULL,
	[IdPieceType] [int] NOT NULL,
	[IdPieceStatus] [int] NOT NULL,
	[IdPickList] [int] NULL,
	[IdYard] [int] NULL,
	[XPos] [int] NULL,
	[YPos] [int] NULL,
	[ZPos] [int] NULL,
	[ZOrder] [tinyint] NULL,
	[Heading] [smallint] NULL,
	[IdLocation] [int] NULL,
	[LocationOrder] [smallint] NULL,
	[IdMachine] [int] NULL,
	[MachinePosition] [smallint] NULL,
	[MachinePositionOrder] [smallint] NULL,
	[HoldOnReasonStatus] [int] NULL,
	[AnnouncedThickness] INT NULL,
	[AnnouncedWidth] [int] NULL,
	[AnnouncedLength] [int] NULL,
	[AnnouncedWeight] [float] NULL,
	[AnnouncedTemperature] [float] NULL,
	[MeasuredWeight] [float] NULL,
	[MeasuredTemperature] [float] NULL,
	[LastTimeMeasuredTemperature] [datetimeoffset](7) NULL,
	[AnnouncementTime] [datetimeoffset](7) NULL,
	[ArrivalTime] [datetimeoffset](7) NULL,
	[DepartureTime] [datetimeoffset](7) NULL,
	[InsDateTime] [datetimeoffset](7) NOT NULL,
	[UpdDateTime] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_UIB_Pieces] PRIMARY KEY CLUSTERED 
(
	[PieceName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PROCESS]
) ON [PROCESS]
GO

ALTER TABLE [tracking].[UIB_Pieces] ADD  CONSTRAINT [DF_UIB_Pieces_InsDateTime]  DEFAULT (sysdatetimeoffset()) FOR [InsDateTime]
GO

ALTER TABLE [tracking].[UIB_Pieces] ADD  CONSTRAINT [DF_UIB_Pieces_UpdDateTime]  DEFAULT (sysdatetimeoffset()) FOR [UpdDateTime]
GO

ALTER TABLE [tracking].[UIB_Pieces]  WITH CHECK ADD  CONSTRAINT [FK_UIB_Pieces_UIB_Pick_Lists] FOREIGN KEY([IdPickList])
REFERENCES [tracking].[UIB_Pick_Lists] ([IdPickList])
GO

ALTER TABLE [tracking].[UIB_Pieces] CHECK CONSTRAINT [FK_UIB_Pieces_UIB_Pick_Lists]
GO

ALTER TABLE [tracking].[UIB_Pieces]  WITH CHECK ADD  CONSTRAINT [FK_UIB_Pieces_Rodeo_Locations] FOREIGN KEY([IdLocation])
REFERENCES [common].[Rodeo_Locations] ([IdLocation])
GO

ALTER TABLE [tracking].[UIB_Pieces] CHECK CONSTRAINT [FK_UIB_Pieces_Rodeo_Locations]
GO

ALTER TABLE [tracking].[UIB_Pieces]  WITH CHECK ADD  CONSTRAINT [FK_UIB_Pieces_Rodeo_Machines] FOREIGN KEY([IdMachine])
REFERENCES [common].[Rodeo_Machines] ([IdMachine])
GO

ALTER TABLE [tracking].[UIB_Pieces] CHECK CONSTRAINT [FK_UIB_Pieces_Rodeo_Machines]
GO

ALTER TABLE [tracking].[UIB_Pieces]  WITH CHECK ADD  CONSTRAINT [FK_UIB_Pieces_Rodeo_Piece_Statuses] FOREIGN KEY([IdPieceStatus])
REFERENCES [tracking].[Rodeo_Piece_Statuses] ([IdPieceStatus])
GO

ALTER TABLE [tracking].[UIB_Pieces] CHECK CONSTRAINT [FK_UIB_Pieces_Rodeo_Piece_Statuses]
GO

ALTER TABLE [tracking].[UIB_Pieces]  WITH CHECK ADD  CONSTRAINT [FK_UIB_Pieces_Rodeo_Piece_Types] FOREIGN KEY([IdPieceType]) REFERENCES [tracking].[Rodeo_Piece_Types] ([IdPieceType])
GO

ALTER TABLE [tracking].[UIB_Pieces] CHECK CONSTRAINT [FK_UIB_Pieces_Rodeo_Piece_Types]
GO

ALTER TABLE [tracking].[UIB_Pieces]  WITH CHECK ADD  CONSTRAINT [FK_UIB_Pieces_Rodeo_Yards] FOREIGN KEY([IdYard]) REFERENCES [common].[Rodeo_Yards] ([IdYard])
GO

ALTER TABLE [tracking].[UIB_Pieces] CHECK CONSTRAINT [FK_UIB_Pieces_Rodeo_Yards]
GO


