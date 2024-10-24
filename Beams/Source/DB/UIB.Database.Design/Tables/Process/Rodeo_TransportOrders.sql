CREATE TABLE [to].[Rodeo_TransportOrders](
	[IdTransportOrder] [bigint] IDENTITY(1,1) NOT NULL,
	[IdMachine] [int] NOT NULL,
	[IdTOType] [int] NOT NULL,
	[IdTOStatus] [int] NOT NULL,
	[IdPreviousTO] [bigint] NULL,
	
	[LocationNameBegin] [varchar](50) NULL,
	[IdYardBegin] [int] NOT NULL,
	[XPosBegin] [int] NOT NULL,
	[YPosBegin] [int] NOT NULL,
	[ZPosBegin] [int] NULL,
	[HeadingBegin] [smallint] NOT NULL,

	[LocationNameEnd] [varchar](50) NULL,
	[IdYardEnd] [int] NOT NULL,
	[XPosEnd] [int] NOT NULL,
	[YPosEnd] [int] NOT NULL,
	[ZPosEnd] [int] NULL,
	[HeadingEnd] [smallint] NOT NULL,

	[RecordingID1] [varchar](100) NULL,
	[RecordingID2] [varchar](100) NULL,
	[RecordingID3] [varchar](100) NULL,
	[RecordingID4] [varchar](100) NULL,

	[Bypasses] [int] NOT NULL,
	[RequestTime] [datetimeoffset](7) NOT NULL,
	[BeginTime] [datetimeoffset](7) NULL,
	[EndTime] [datetimeoffset](7) NULL,
	[UsernameRequest] [varchar](40) NULL,
	[UsernameCancel] [varchar](40) NULL,
	[InsDateTime] [datetimeoffset](7) NOT NULL,
	[UpdDateTime] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Rodeo_TransportOrders] PRIMARY KEY CLUSTERED 
(
	[IdTransportOrder] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PROCESS]
) ON [PROCESS]

GO

CREATE NONCLUSTERED INDEX [IX_Rodeo_TransportOrders] ON [to].[Rodeo_TransportOrders]
(
	[BeginTime] ASC,
	[EndTime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PROCESS]

GO

CREATE NONCLUSTERED INDEX [IX_Rodeo_TransportOrders_Insert] ON [to].[Rodeo_TransportOrders]
(
	[InsDateTime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PROCESS]

GO

ALTER TABLE [to].[Rodeo_TransportOrders] ADD  CONSTRAINT [DF_Rodeo_TransportOrders_InsDateTime]  DEFAULT (sysdatetimeoffset()) FOR [InsDateTime]

GO

ALTER TABLE [to].[Rodeo_TransportOrders] ADD  CONSTRAINT [DF_Rodeo_TransportOrders_UpdDateTime]  DEFAULT (sysdatetimeoffset()) FOR [UpdDateTime]

GO

ALTER TABLE [to].[Rodeo_TransportOrders]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_TransportOrders_Rodeo_Machines] FOREIGN KEY([IdMachine]) REFERENCES [common].[Rodeo_Machines] ([IdMachine])

GO

ALTER TABLE [to].[Rodeo_TransportOrders] CHECK CONSTRAINT [FK_Rodeo_TransportOrders_Rodeo_Machines]

GO

ALTER TABLE [to].[Rodeo_TransportOrders]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_TransportOrders_Rodeo_TO_Statuses] FOREIGN KEY([IdTOStatus]) REFERENCES [to].[Rodeo_TO_Statuses] ([IdTOStatus])

GO

ALTER TABLE [to].[Rodeo_TransportOrders] CHECK CONSTRAINT [FK_Rodeo_TransportOrders_Rodeo_TO_Statuses]

GO

CREATE NONCLUSTERED INDEX [IX_Rodeo_TransportOrders_IdTOStatus] ON [to].[Rodeo_TransportOrders]
(
	[IdTOStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PROCESS]

GO

ALTER TABLE [to].[Rodeo_TransportOrders]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_TransportOrders_Rodeo_TO_Types] FOREIGN KEY([IdTOType]) REFERENCES [to].[Rodeo_TO_Types] ([IdTOType])

GO

ALTER TABLE [to].[Rodeo_TransportOrders] CHECK CONSTRAINT [FK_Rodeo_TransportOrders_Rodeo_TO_Types]

GO

CREATE NONCLUSTERED INDEX [IX_Rodeo_TransportOrders_IdTOType] ON [to].[Rodeo_TransportOrders]
(
	[IdTOType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PROCESS]

GO

ALTER TABLE [to].[Rodeo_TransportOrders]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_TransportOrders_Rodeo_Yards_Begin] FOREIGN KEY([IdYardBegin]) REFERENCES [common].[Rodeo_Yards] ([IdYard])

GO

ALTER TABLE [to].[Rodeo_TransportOrders] CHECK CONSTRAINT [FK_Rodeo_TransportOrders_Rodeo_Yards_Begin]

GO

ALTER TABLE [to].[Rodeo_TransportOrders]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_TransportOrders_Rodeo_Yards_End] FOREIGN KEY([IdYardEnd]) REFERENCES [common].[Rodeo_Yards] ([IdYard])

GO

ALTER TABLE [to].[Rodeo_TransportOrders] CHECK CONSTRAINT [FK_Rodeo_TransportOrders_Rodeo_Yards_End]

GO
