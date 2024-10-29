CREATE TABLE [report].[HSM_Outgoing_Messages](
	[IdOutgoingMessage] [bigint] IDENTITY(1,1) NOT NULL,
	[IdJob] [bigint] NULL,
	[IdMessageType] [int] NOT NULL,
	[Destination] [varchar](50) NOT NULL,
	[MsgReference] [bigint] NULL,
	[RawMessage] [sql_variant] NOT NULL,
	[RawResponse] [sql_variant] NULL,
	[DataMessage] [varchar](500) NOT NULL,
	[DataResponse] [varchar](200) NULL,
	[MessageTime] [datetimeoffset](7) NOT NULL,
	[ResponseTime] [datetimeoffset](7) NULL,
	[InsDateTime] [datetimeoffset](7) NOT NULL,
	[UpdDateTime] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_HSM_Outgoing_Messages] PRIMARY KEY CLUSTERED 
(
	[IdOutgoingMessage] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [EVENTS]
) ON [EVENTS]

GO

CREATE NONCLUSTERED INDEX [IX_HSM_Outgoing_Messages] ON [report].[HSM_Outgoing_Messages]
(
	[MsgReference] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [EVENTS]

GO 

CREATE NONCLUSTERED INDEX [IX_HSM_Outgoing_Messages_Execution] ON [report].[HSM_Outgoing_Messages]
(
	[MessageTime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [EVENTS]

GO

ALTER TABLE [report].[HSM_Outgoing_Messages] ADD  CONSTRAINT [DF_HSM_Outgoing_Messages_InsDateTime]  DEFAULT (sysdatetimeoffset()) FOR [InsDateTime]

GO

ALTER TABLE [report].[HSM_Outgoing_Messages] ADD  CONSTRAINT [DF_HSM_Outgoing_Messages_UpdDateTime]  DEFAULT (sysdatetimeoffset()) FOR [UpdDateTime]

GO

ALTER TABLE [report].[HSM_Outgoing_Messages]  WITH CHECK ADD  CONSTRAINT [FK_HSM_Outgoing_Messages_HSM_Jobs] FOREIGN KEY([IdJob]) REFERENCES [to].[HSM_Jobs] ([IdJob])

GO

ALTER TABLE [report].[HSM_Outgoing_Messages] CHECK CONSTRAINT [FK_HSM_Outgoing_Messages_HSM_Jobs]

GO

CREATE NONCLUSTERED INDEX [IX_HSM_Outgoing_Messages_IdJob] ON [report].[HSM_Outgoing_Messages]
(
	[IdJob] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [EVENTS]

GO

ALTER TABLE [report].[HSM_Outgoing_Messages]  WITH CHECK ADD  CONSTRAINT [FK_HSM_Outgoing_Messages_HSM_Message_Types] FOREIGN KEY([IdMessageType]) REFERENCES [report].[HSM_Message_Types] ([IdMessageType])

GO

ALTER TABLE [report].[HSM_Outgoing_Messages] CHECK CONSTRAINT [FK_HSM_Outgoing_Messages_HSM_Message_Types]
