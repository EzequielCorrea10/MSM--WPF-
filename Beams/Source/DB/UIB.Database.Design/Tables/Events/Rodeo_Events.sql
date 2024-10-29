CREATE TABLE [report].[Rodeo_Events](
	[IdEvent] [bigint] IDENTITY(1,1) NOT NULL,
	[IdEventType] [int] NOT NULL,
	[IdClient] [int] NULL,
	[UsernameExecute] [varchar](40) NULL,
	[Data] [varchar](500) NOT NULL,
	[IdJob] [bigint] NULL,
	[IdTransportOrder] [bigint] NULL,
	[Step] [smallint] NULL,
	[PieceName] [varchar](50) NULL,
	[LocationName] [varchar](50) NULL,
	[MachineName] [varchar](50) NULL,
	[EventTime] [datetimeoffset](7) NOT NULL,
	[InsDateTime] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Rodeo_Events] PRIMARY KEY CLUSTERED 
(
	[IdEvent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [EVENTS]
) ON [EVENTS]

GO

ALTER TABLE [report].[Rodeo_Events]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_Events_Rodeo_Event_Types] FOREIGN KEY([IdEventType]) REFERENCES [report].[Rodeo_Event_Types] ([IdEventType])

GO

ALTER TABLE [report].[Rodeo_Events] CHECK CONSTRAINT [FK_Rodeo_Events_Rodeo_Event_Types]

GO

CREATE NONCLUSTERED INDEX [IX_Rodeo_Events_IdEventType] ON [report].[Rodeo_Events]
(
	[IdEventType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [EVENTS]

GO 

ALTER TABLE [report].[Rodeo_Events]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_Events_Rodeo_Clients] FOREIGN KEY([IdClient]) REFERENCES [common].[Rodeo_Clients] ([IdClient])

GO

ALTER TABLE [report].[Rodeo_Events] CHECK CONSTRAINT [FK_Rodeo_Events_Rodeo_Clients]

GO

CREATE NONCLUSTERED INDEX [IX_Rodeo_Events_IdClient] ON [report].[Rodeo_Events]
(
	[IdClient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [EVENTS]

GO

ALTER TABLE [report].[Rodeo_Events]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_Events_HCM_Jobs] FOREIGN KEY([IdJob]) REFERENCES [to].[HCM_Jobs] ([IdJob])

GO

ALTER TABLE [report].[Rodeo_Events] CHECK CONSTRAINT [FK_Rodeo_Events_HCM_Jobs]

GO
 
CREATE NONCLUSTERED INDEX [IX_Rodeo_Events_IdJob] ON [report].[Rodeo_Events]
(
	[IdJob] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [EVENTS]

GO

ALTER TABLE [report].[Rodeo_Events]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_Events_Rodeo_TransportOrders] FOREIGN KEY([IdTransportOrder]) REFERENCES [to].[Rodeo_TransportOrders] ([IdTransportOrder])

GO

ALTER TABLE [report].[Rodeo_Events] CHECK CONSTRAINT [FK_Rodeo_Events_Rodeo_TransportOrders]

GO

CREATE NONCLUSTERED INDEX [IX_Rodeo_Events_IdTransportOrder] ON [report].[Rodeo_Events]
(
	[IdTransportOrder] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [EVENTS]

GO

CREATE NONCLUSTERED INDEX [IX_Rodeo_Events_Execution] ON [report].[Rodeo_Events]
(
	[EventTime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [EVENTS]

GO

ALTER TABLE [report].[Rodeo_Events] ADD  CONSTRAINT [DF_Rodeo_Events_InsDateTime]  DEFAULT (sysdatetimeoffset()) FOR [InsDateTime]
