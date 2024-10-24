CREATE TABLE [to].[Rodeo_TO_Pieces](
	[IdTransportOrder] [bigint] NOT NULL,
	[MachinePosition] [smallint] NOT NULL,
	[PieceName] [varchar](50) NOT NULL,
	[IdJob] [bigint] NULL,
	[JobSequence] [smallint] NULL,
	[IsDigging] [bit] NULL,

	[PickupLocationName] [varchar](50) NULL,
	[PickupMachineName] [varchar](50) NULL,
	[PickupIdYard] [int] NULL,
	[PickupXPos] [int] NULL,
	[PickupYPos] [int] NULL,
	[PickupZPos] [int] NULL,
	[PickupHeading] [smallint] NULL,

	[DropLocationName] [varchar](50) NULL,
	[DropMachineName] [varchar](50) NULL,
	[DropIdYard] [int] NULL,
	[DropXPos] [int] NULL,
	[DropYPos] [int] NULL,
	[DropZPos] [int] NULL,
	[DropHeading] [smallint] NULL,

	[PickupTime] [datetimeoffset](7) NULL,
	[StorageTime] [datetimeoffset](7) NULL,
	[InsDateTime] [datetimeoffset](7) NOT NULL,
	[UpdDateTime] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Rodeo_TO_Pieces] PRIMARY KEY CLUSTERED 
(
	[IdTransportOrder] ASC,
	[MachinePosition] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PROCESS],
 CONSTRAINT [Rodeo_TO_Pieces_JobTO] UNIQUE NONCLUSTERED 
(
	[IdJob] ASC,
	[IdTransportOrder] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PROCESS]

GO

ALTER TABLE [to].[Rodeo_TO_Pieces]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_TO_Pieces_Rodeo_TransportOrders] FOREIGN KEY([IdTransportOrder]) REFERENCES [to].[Rodeo_TransportOrders] ([IdTransportOrder])

GO

ALTER TABLE [to].[Rodeo_TO_Pieces] CHECK CONSTRAINT [FK_Rodeo_TO_Pieces_Rodeo_TransportOrders]

GO

ALTER TABLE [to].[Rodeo_TO_Pieces]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_TO_Pieces_MSM_Jobs] FOREIGN KEY([IdJob]) REFERENCES [to].[MSM_Jobs] ([IdJob])

GO

ALTER TABLE [to].[Rodeo_TO_Pieces] CHECK CONSTRAINT [FK_Rodeo_TO_Pieces_MSM_Jobs]

GO

CREATE NONCLUSTERED INDEX [IX_Rodeo_TO_Pieces_IdJob] ON [to].[Rodeo_TO_Pieces]
(
	[IdJob] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PROCESS]

GO

ALTER TABLE [to].[Rodeo_TO_Pieces]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_TO_Pieces_Rodeo_Yards_Begin] FOREIGN KEY([PickupIdYard]) REFERENCES [common].[Rodeo_Yards] ([IdYard])

GO

ALTER TABLE [to].[Rodeo_TO_Pieces] CHECK CONSTRAINT [FK_Rodeo_TO_Pieces_Rodeo_Yards_Begin]

GO

ALTER TABLE [to].[Rodeo_TO_Pieces]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_TO_Pieces_Rodeo_Yards_End] FOREIGN KEY([DropIdYard]) REFERENCES [common].[Rodeo_Yards] ([IdYard])

GO

ALTER TABLE [to].[Rodeo_TO_Pieces] CHECK CONSTRAINT [FK_Rodeo_TO_Pieces_Rodeo_Yards_End]

GO

ALTER TABLE [to].[Rodeo_TO_Pieces] ADD  CONSTRAINT [DF_Rodeo_TO_Pieces_InsDateTime]  DEFAULT (sysdatetimeoffset()) FOR [InsDateTime]

GO

ALTER TABLE [to].[Rodeo_TO_Pieces] ADD  CONSTRAINT [DF_Rodeo_TO_Pieces_UpdDateTime]  DEFAULT (sysdatetimeoffset()) FOR [UpdDateTime]

GO