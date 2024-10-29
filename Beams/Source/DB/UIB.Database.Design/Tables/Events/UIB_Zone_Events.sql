CREATE TABLE [report].[HSM_Zone_Events](
	[IdZoneEvent] [bigint] IDENTITY(1,1) NOT NULL,
	[IdZoneEventType] [int] NOT NULL,
	[IdZone] [int] NOT NULL,
	[IdRequest] [int] NULL,
	[IdClient] [int] NULL,
	[UsernameExecute] [varchar](20) NULL,
	[Data] [varchar](500) NOT NULL,
	[EventTime] [datetimeoffset](7) NOT NULL,
	[InsDateTime] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_HSM_Zone_Events] PRIMARY KEY CLUSTERED 
(
	[IdZoneEvent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [EVENTS]
) ON [EVENTS]

GO

ALTER TABLE [report].[HSM_Zone_Events]  WITH CHECK ADD  CONSTRAINT [FK_HSM_Zone_Events_HSM_Zone_Event_Types] FOREIGN KEY([IdZoneEventType]) REFERENCES [report].[HSM_Zone_Event_Types] ([IdZoneEventType])

GO

ALTER TABLE [report].[HSM_Zone_Events] CHECK CONSTRAINT [FK_HSM_Zone_Events_HSM_Zone_Event_Types]

GO

CREATE NONCLUSTERED INDEX [IX_HSM_Zone_Events_IdZoneEventType] ON [report].[HSM_Zone_Events]
(
	[IdZoneEventType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [EVENTS]

GO

ALTER TABLE [report].[HSM_Zone_Events]  WITH CHECK ADD  CONSTRAINT [FK_HSM_Zone_Events_HSM_Zones] FOREIGN KEY([IdZone]) REFERENCES [safety].[HSM_Zones] ([IdZone])

GO

ALTER TABLE [report].[HSM_Zone_Events] CHECK CONSTRAINT [FK_HSM_Zone_Events_HSM_Zones]

GO

CREATE NONCLUSTERED INDEX [IX_HSM_Zone_Events_IdZone] ON [report].[HSM_Zone_Events]
(
	[IdZone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [EVENTS]

GO

ALTER TABLE [report].[HSM_Zone_Events]  WITH CHECK ADD  CONSTRAINT [FK_HSM_Zone_Events_HSM_Requests] FOREIGN KEY([IdRequest]) REFERENCES [safety].[HSM_Requests] ([IdRequest])

GO

ALTER TABLE [report].[HSM_Zone_Events] CHECK CONSTRAINT [FK_HSM_Zone_Events_HSM_Requests]

GO

CREATE NONCLUSTERED INDEX [IX_HSM_Zone_Events_IdRequest] ON [report].[HSM_Zone_Events]
(
	[IdRequest] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [EVENTS]

GO 

ALTER TABLE [report].[HSM_Zone_Events]  WITH CHECK ADD  CONSTRAINT [FK_HSM_Zone_Events_Rodeo_Clients] FOREIGN KEY([IdClient]) REFERENCES [common].[Rodeo_Clients] ([IdClient])

GO

ALTER TABLE [report].[HSM_Zone_Events] CHECK CONSTRAINT [FK_HSM_Zone_Events_Rodeo_Clients]

GO

CREATE NONCLUSTERED INDEX [IX_HSM_Zone_Events_IdClient] ON [report].[HSM_Zone_Events]
(
	[IdClient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [EVENTS]

GO

CREATE NONCLUSTERED INDEX [IX_HSM_Zone_Events_Execution] ON [report].[HSM_Zone_Events]
(
	[EventTime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [EVENTS]

GO

ALTER TABLE [report].[HSM_Zone_Events] ADD  CONSTRAINT [DF_HSM_Zone_Events_InsDateTime]  DEFAULT (sysdatetimeoffset()) FOR [InsDateTime]
