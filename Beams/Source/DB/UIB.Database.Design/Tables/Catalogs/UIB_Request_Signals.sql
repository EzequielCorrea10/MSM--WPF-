CREATE TABLE [safety].[HCM_Request_Signals](
	[IdRequestSignal] [int] NOT NULL,
	[IdZoneEventType] [int] NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[TextDisplayed] [varchar](20) NOT NULL,
	[TextOtherwise] [varchar](20) NOT NULL,
	[ReadTagname] [varchar](70) NULL,
	[Bit] [int] NULL,
	[PlcValue] [int] NULL,
	[WriteTagname] [varchar](70) NULL,
	[SetpointValue] [int] NULL,
	[Alarmname] [varchar](70) NULL,
	[SignalInterlock_ReadTagname] [varchar](70) NULL,
	[SignalInterlock_Bit] [int] NULL,
	[SignalInterlock_PlcValue] [int] NULL,
	[OtherwiseInterlock_ReadTagname] [varchar](70) NULL,
	[OtherwiseInterlock_Bit] [int] NULL,
	[OtherwiseInterlock_PlcValue] [int] NULL,
	[IsAlert] [bit] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_HCM_Request_Signals] PRIMARY KEY CLUSTERED 
(
	[IdRequestSignal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO 

CREATE UNIQUE NONCLUSTERED INDEX [IX_HCM_Request_Signals_Name] ON [safety].[HCM_Request_Signals]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

ALTER TABLE [safety].[HCM_Request_Signals]  WITH CHECK ADD  CONSTRAINT [FK_HCM_Request_Signals_HCM_Zone_Event_Types] FOREIGN KEY([IdZoneEventType]) REFERENCES [report].[HCM_Zone_Event_Types] ([IdZoneEventType])

GO

ALTER TABLE [safety].[HCM_Request_Signals] CHECK CONSTRAINT [FK_HCM_Request_Signals_HCM_Zone_Event_Types]

GO

ALTER TABLE [safety].[HCM_Request_Signals]  WITH CHECK ADD  CONSTRAINT [CK_HCM_Request_Signals] CHECK  (([ReadTagname] IS NOT NULL AND [PlcValue] IS NOT NULL) OR [Alarmname] IS NOT NULL)
GO

ALTER TABLE [safety].[HCM_Request_Signals] ADD  CONSTRAINT [DF_HCM_Request_Signals_Active]  DEFAULT ((1)) FOR [Active]
GO
