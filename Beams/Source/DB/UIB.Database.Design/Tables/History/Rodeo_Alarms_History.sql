CREATE TABLE [rodeo].[Rodeo_Alarms_History](
	[IdAlarmHistory] [bigint] IDENTITY(1,1) NOT NULL,
	[IdAlarm] [int] NOT NULL,
	[TimeOn] [datetimeoffset](7) NOT NULL,
	[TimeOff] [datetimeoffset](7) NULL,
	[TimeAccept] [datetimeoffset](7) NULL,
	[TimeAcceptUserName] [varchar](40) NULL,
	[TimeReset] [datetimeoffset](7) NULL,
	[TimeResetUserName] [varchar](40) NULL,
	[TimeQuarantine] [datetimeoffset](7) NULL,
	[TimeQuarantineUserName] [varchar](40) NULL,
	[Event] [int] NOT NULL,
	[IsCloseForced] [bit] NULL,
	[InsDateTime] [datetimeoffset](7) NOT NULL,
	[UpdDateTime] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Rodeo_Alarms_History] PRIMARY KEY CLUSTERED 
(
	[IdAlarmHistory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [HISTORY]
) ON [HISTORY]

GO

ALTER TABLE [rodeo].[Rodeo_Alarms_History] ADD  CONSTRAINT [DF_Rodeo_Alarms_History_InsDateTime]  DEFAULT (sysdatetimeoffset()) FOR [InsDateTime]
GO

ALTER TABLE [rodeo].[Rodeo_Alarms_History] ADD  CONSTRAINT [DF_Rodeo_Alarms_History_UpdDateTime]  DEFAULT (sysdatetimeoffset()) FOR [UpdDateTime]
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_Rodeo_Alarms_History_Alarm] ON [rodeo].[Rodeo_Alarms_History]
(
	[IdAlarm] ASC,
	[TimeOn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [HISTORY]
GO

CREATE NONCLUSTERED INDEX [IX_Rodeo_Alarms_History_Date] ON [rodeo].[Rodeo_Alarms_History]
(
	[TimeOn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [HISTORY]
GO
