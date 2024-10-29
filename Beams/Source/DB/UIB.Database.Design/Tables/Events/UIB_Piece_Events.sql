CREATE TABLE [report].[HCM_Piece_Events](
	[IdPieceEvent] [bigint] IDENTITY(1,1) NOT NULL,
	[IdPieceEventType] [int] NOT NULL,
	[PieceName] [varchar](50) NOT NULL,
	[IdMachine] [int] NULL,
	[Data] [varchar](500) NOT NULL,
	[EventTime] [datetimeoffset](7) NOT NULL,
	[InsDateTime] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_HCM_Piece_Events] PRIMARY KEY CLUSTERED 
(
	[IdPieceEvent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [EVENTS]
) ON [EVENTS]

GO

CREATE NONCLUSTERED INDEX [IX_Piece_Events_PieceName] ON [report].[HCM_Piece_Events]
(
	[PieceName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [EVENTS]

GO

ALTER TABLE [report].[HCM_Piece_Events]  WITH CHECK ADD  CONSTRAINT [FK_HCM_Piece_Events_HCM_Piece_Event_Types] FOREIGN KEY([IdPieceEventType]) REFERENCES [report].[HCM_Piece_Event_Types] ([IdPieceEventType])

GO

ALTER TABLE [report].[HCM_Piece_Events] CHECK CONSTRAINT [FK_HCM_Piece_Events_HCM_Piece_Event_Types]

GO

CREATE NONCLUSTERED INDEX [IX_HCM_Piece_Events_IdPieceEventType] ON [report].[HCM_Piece_Events]
(
	[IdPieceEventType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [EVENTS]

GO

ALTER TABLE [report].[HCM_Piece_Events]  WITH CHECK ADD  CONSTRAINT [FK_HCM_Piece_Events_Rodeo_Machines] FOREIGN KEY([IdMachine]) REFERENCES [common].[Rodeo_Machines] ([IdMachine])

GO

ALTER TABLE [report].[HCM_Piece_Events] CHECK CONSTRAINT [FK_HCM_Piece_Events_Rodeo_Machines]

GO

CREATE NONCLUSTERED INDEX [IX_HCM_Piece_Events_IdMachine] ON [report].[HCM_Piece_Events]
(
	[IdMachine] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [EVENTS]

GO

CREATE NONCLUSTERED INDEX [IX_HCM_Piece_Events_Execution] ON [report].[HCM_Piece_Events]
(
	[EventTime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [EVENTS]

GO

ALTER TABLE [report].[HCM_Piece_Events] ADD  CONSTRAINT [DF_HCM_Piece_Events_InsDateTime]  DEFAULT (sysdatetimeoffset()) FOR [InsDateTime]

GO