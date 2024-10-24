CREATE TABLE [rodeo].[Rodeo_Commands_History](
	[IdCommandHistory] [bigint] IDENTITY(1,1) NOT NULL,
	[TagName] [varchar](60) NOT NULL,
	[SetPoint] [smallint] NOT NULL,
	[SentValue] [nvarchar](max) NOT NULL,
	[PreviousValue] [nvarchar](max) NOT NULL,
	[SentTime] [datetimeoffset](7) NOT NULL,
	[AnswerTime] [datetimeoffset](7) NOT NULL,
	[AnswerCode] [int] NOT NULL,
	[UserName] [varchar](40) NOT NULL,
	[AppName] [varchar](60) NOT NULL,
	[LocName] [varchar](60) NOT NULL,
	[InsDateTime] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Rodeo_Commands_History] PRIMARY KEY CLUSTERED 
(
	[IdCommandHistory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [HISTORY]
) ON [HISTORY] TEXTIMAGE_ON [HISTORY]

GO

ALTER TABLE [rodeo].[Rodeo_Commands_History] ADD  CONSTRAINT [DF_Rodeo_Commands_History_InsDateTime]  DEFAULT (sysdatetimeoffset()) FOR [InsDateTime]
GO

/****** Object:  Index [IX_Rodeo_Commands_History_Date]    Script Date: 11/4/2015 10:26:02 AM ******/
CREATE NONCLUSTERED INDEX [IX_Rodeo_Commands_History_Date] ON [rodeo].[Rodeo_Commands_History]
(
	[SentTime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [HISTORY]
GO