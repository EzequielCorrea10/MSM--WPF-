CREATE TABLE [report].[HB_Machine_Events](
	[IdMachineEvent] [bigint] IDENTITY(1,1) NOT NULL,
	[IdMachineEventType] [int] NOT NULL,
	[IdMachine] [int] NOT NULL,
	[PieceName] [varchar](50) NULL,
	[Data] [varchar](500) NOT NULL,
	[EventTime] [datetimeoffset](7) NOT NULL,
	[InsDateTime] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_HB_Machine_Events] PRIMARY KEY CLUSTERED 
(
	[IdMachineEvent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [EVENTS]
) ON [EVENTS]

GO

CREATE NONCLUSTERED INDEX [IX_Machine_Events_PieceName] ON [report].[HB_Machine_Events]
(
	[PieceName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [EVENTS]

GO

ALTER TABLE [report].[HB_Machine_Events]  WITH CHECK ADD  CONSTRAINT [FK_HB_Machine_Events_Rodeo_Machine_Event_Types] FOREIGN KEY([IdMachineEventType]) REFERENCES [report].[HB_Machine_Event_Types] ([IdMachineEventType])

GO

ALTER TABLE [report].[HB_Machine_Events] CHECK CONSTRAINT [FK_HB_Machine_Events_Rodeo_Machine_Event_Types]

GO

CREATE NONCLUSTERED INDEX [IX_Machine_Events_IdMachineEventType] ON [report].[HB_Machine_Events]
(
	[IdMachineEventType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [EVENTS]

GO

ALTER TABLE [report].[HB_Machine_Events]  WITH CHECK ADD  CONSTRAINT [FK_HB_Machine_Events_Rodeo_Machines] FOREIGN KEY([IdMachine]) REFERENCES [common].[Rodeo_Machines] ([IdMachine])

GO

ALTER TABLE [report].[HB_Machine_Events] CHECK CONSTRAINT [FK_HB_Machine_Events_Rodeo_Machines]

GO

CREATE NONCLUSTERED INDEX [IX_HB_Machine_Events_IdMachine] ON [report].[HB_Machine_Events]
(
	[IdMachine] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [EVENTS]

GO

CREATE NONCLUSTERED INDEX [IX_HB_Machine_Events_Execution] ON [report].[HB_Machine_Events]
(
	[EventTime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [EVENTS]

GO 

ALTER TABLE [report].[HB_Machine_Events] ADD  CONSTRAINT [DF_HB_Machine_Events_InsDateTime]  DEFAULT (sysdatetimeoffset()) FOR [InsDateTime]
