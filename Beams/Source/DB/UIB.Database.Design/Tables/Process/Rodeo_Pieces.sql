CREATE TABLE [tracking].[Rodeo_Pieces](
	[PieceName] [varchar](50) NOT NULL,
	[IdPieceType] [int] NOT NULL,
	[IdPieceStatus] [int] NOT NULL,
	[IdPieceAlloy] [int] NOT NULL,
	[IdPickList] [int] NULL,
	[IdYard] [int] NULL,
	[XPos] [int] NULL,
	[YPos] [int] NULL,
	[ZPos] [int] NULL,
	[ZOrder] [smallint] NULL,
	[Heading] [smallint] NULL,
	[IdLocation] [int] NULL,
	[LocationOrder] [smallint] NULL,
	[IdMachine] [int] NULL,
	[MachinePosition] [smallint] NULL,
	[MachinePositionOrder] [smallint] NULL,
	[HoldOnReasonStatus] [int] NULL,
	[NextStep] [varchar](50) NULL,
	[Thickness] [int] NOT NULL,
	[Width] [int] NOT NULL,
	[Length] [int] NOT NULL,
	[Weight] [int] NOT NULL,
	[WeightCalc] [int] NOT NULL,
	[NonStackable] [bit] NOT NULL,
	[Owner] [varchar](20) NULL,
	[ArrivalTime] [datetimeoffset](7) NULL,
	[DepartureTime] [datetimeoffset](7) NULL,
	[InsDateTime] [datetimeoffset](7) NOT NULL,
	[UpdDateTime] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Rodeo_Pieces] PRIMARY KEY CLUSTERED 
(
	[PieceName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PROCESS]
) ON [PROCESS]
GO

ALTER TABLE [tracking].[Rodeo_Pieces] ADD  CONSTRAINT [DF_Rodeo_Pieces_InsDateTime]  DEFAULT (sysdatetimeoffset()) FOR [InsDateTime]
GO

ALTER TABLE [tracking].[Rodeo_Pieces] ADD  CONSTRAINT [DF_Rodeo_Pieces_UpdDateTime]  DEFAULT (sysdatetimeoffset()) FOR [UpdDateTime]
GO

ALTER TABLE [tracking].[Rodeo_Pieces]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_Pieces_HSM_Pick_Lists] FOREIGN KEY([IdPickList]) REFERENCES [tracking].[HSM_Pick_Lists] ([IdPickList])
GO

ALTER TABLE [tracking].[Rodeo_Pieces] CHECK CONSTRAINT [FK_Rodeo_Pieces_HSM_Pick_Lists]
GO

ALTER TABLE [tracking].[Rodeo_Pieces]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_Pieces_Rodeo_Yards] FOREIGN KEY([IdYard]) REFERENCES [common].[Rodeo_Yards] ([IdYard])

GO

ALTER TABLE [tracking].[Rodeo_Pieces] CHECK CONSTRAINT [FK_Rodeo_Pieces_Rodeo_Yards]

GO

ALTER TABLE [tracking].[Rodeo_Pieces]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_Pieces_Rodeo_Locations] FOREIGN KEY([IdLocation]) REFERENCES [common].[Rodeo_Locations] ([IdLocation])
GO

ALTER TABLE [tracking].[Rodeo_Pieces] CHECK CONSTRAINT [FK_Rodeo_Pieces_Rodeo_Locations]
GO

ALTER TABLE [tracking].[Rodeo_Pieces]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_Pieces_Rodeo_Machines] FOREIGN KEY([IdMachine]) REFERENCES [common].[Rodeo_Machines] ([IdMachine])
GO

ALTER TABLE [tracking].[Rodeo_Pieces] CHECK CONSTRAINT [FK_Rodeo_Pieces_Rodeo_Machines]
GO

ALTER TABLE [tracking].[Rodeo_Pieces]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_Pieces_Rodeo_Piece_Statuses] FOREIGN KEY([IdPieceStatus]) REFERENCES [tracking].[Rodeo_Piece_Statuses] ([IdPieceStatus])
GO

ALTER TABLE [tracking].[Rodeo_Pieces] CHECK CONSTRAINT [FK_Rodeo_Pieces_Rodeo_Piece_Statuses]
GO

ALTER TABLE [tracking].[Rodeo_Pieces]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_Pieces_Rodeo_Piece_Types] FOREIGN KEY([IdPieceType]) REFERENCES [tracking].[Rodeo_Piece_Types] ([IdPieceType])
GO

ALTER TABLE [tracking].[Rodeo_Pieces] CHECK CONSTRAINT [FK_Rodeo_Pieces_Rodeo_Piece_Types]
GO

ALTER TABLE [tracking].[Rodeo_Pieces]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_Pieces_Rodeo_Piece_Alloys] FOREIGN KEY([IdPieceAlloy]) REFERENCES [tracking].[Rodeo_Piece_Alloys] ([IdPieceAlloy])
GO

ALTER TABLE [tracking].[Rodeo_Pieces] CHECK CONSTRAINT [FK_Rodeo_Pieces_Rodeo_Piece_Alloys]
GO
