CREATE TABLE [rodeo].[Rodeo_UserLogs_History]
(
	[IdUserLogHistory]	[bigint] IDENTITY(1,1) NOT NULL,
	[IdClient]			[int] NOT NULL,
	[IdSession]			[int] NOT NULL,
	[UserName]			[varchar](40) NOT NULL,
	[TimeIN]			[datetimeoffset](7) NOT NULL,
	[TimeOUT]			[datetimeoffset](7) NULL,
	[AuthorIN]			[varchar](40) NULL,
	[AuthorOUT]			[varchar](40) NULL,
	[IsCloseForced]		[bit] NULL,
	[InsDateTime]		[datetimeoffset](7) NOT NULL,
	[UpdDateTime]		[datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Rodeo_UserLogs_History] PRIMARY KEY CLUSTERED 
(
	[IdUserLogHistory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [HISTORY]
) ON [HISTORY]

GO

ALTER TABLE [rodeo].[Rodeo_UserLogs_History] ADD  CONSTRAINT [DF_Rodeo_UserLogs_History_InsDateTime]  DEFAULT (sysdatetimeoffset()) FOR [InsDateTime]
GO

ALTER TABLE [rodeo].[Rodeo_UserLogs_History] ADD  CONSTRAINT [DF_Rodeo_UserLogs_History_UpdDateTime]  DEFAULT (sysdatetimeoffset()) FOR [UpdDateTime]
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_Rodeo_UserLogs_History_Access] ON [rodeo].[Rodeo_UserLogs_History]
(
	[IdClient] ASC,
	[IdSession] ASC,
	[TimeIN] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [HISTORY]
GO

CREATE NONCLUSTERED INDEX [IX_Rodeo_UserLogs_History_Date] ON [rodeo].[Rodeo_UserLogs_History]
(
	[TimeIN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [HISTORY]
GO