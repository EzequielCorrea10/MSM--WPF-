CREATE TABLE [report].[HSM_Incoming_Messages](
	[IdIncomingMessage] [bigint] IDENTITY(1,1) NOT NULL,
	[IdJob] [bigint] NULL,
	[IdMessageType] [int] NOT NULL,
	[Origin] [varchar](50) NOT NULL,
	[MsgReference] [bigint] NULL,
	[RawMessage] [sql_variant] NOT NULL,
	[RawResponse] [sql_variant] NULL,
	[DataMessage] [varchar](500) NOT NULL,
	[DataResponse] [varchar](200) NULL,
	[MessageTime] [datetimeoffset](7) NOT NULL,
	[ResponseTime] [datetimeoffset](7) NULL,
	[InsDateTime] [datetimeoffset](7) NOT NULL,
	[UpdDateTime] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_HSM_Incoming_Messages] PRIMARY KEY CLUSTERED 
(
	[IdIncomingMessage] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [EVENTS]
) ON [EVENTS]

GO

CREATE NONCLUSTERED INDEX [IX_HSM_Incoming_Messages_Execution] ON [report].[HSM_Incoming_Messages]
(
	[MessageTime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [EVENTS]

GO 

CREATE NONCLUSTERED INDEX [IX_HSM_Incoming_Messages_Ref] ON [report].[HSM_Incoming_Messages]
(
	[MsgReference] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [EVENTS]

GO

ALTER TABLE [report].[HSM_Incoming_Messages] ADD  CONSTRAINT [DF_HSM_Incoming_Messages_InsDateTime]  DEFAULT (sysdatetimeoffset()) FOR [InsDateTime]

GO

ALTER TABLE [report].[HSM_Incoming_Messages] ADD  CONSTRAINT [DF_HSM_Incoming_Messages_UpdDateTime]  DEFAULT (sysdatetimeoffset()) FOR [UpdDateTime]

GO

ALTER TABLE [report].[HSM_Incoming_Messages]  WITH CHECK ADD  CONSTRAINT [FK_HSM_Incoming_Messages_HSM_Jobs] FOREIGN KEY([IdJob]) REFERENCES [to].[HSM_Jobs] ([IdJob])

GO

ALTER TABLE [report].[HSM_Incoming_Messages] CHECK CONSTRAINT [FK_HSM_Incoming_Messages_HSM_Jobs]

GO

CREATE NONCLUSTERED INDEX [IX_HSM_Incoming_Messages_IdPS] ON [report].[HSM_Incoming_Messages]
(
	[IdJob] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [EVENTS]

GO

ALTER TABLE [report].[HSM_Incoming_Messages]  WITH CHECK ADD  CONSTRAINT [FK_HSM_Incoming_Messages_HSM_Message_Types] FOREIGN KEY([IdMessageType]) REFERENCES [report].[HSM_Message_Types] ([IdMessageType])

GO

ALTER TABLE [report].[HSM_Incoming_Messages] CHECK CONSTRAINT [FK_HSM_Incoming_Messages_HSM_Message_Types]
