CREATE TABLE [rodeo].[HSM_Failures_History](
	[IdMachineFailureHistory] [bigint] IDENTITY(1,1) NOT NULL,
	[IdMachineFailure] [int] NOT NULL,
	[TimeOn] [datetimeoffset](7) NOT NULL,
	[TimeOff] [datetimeoffset](7) NULL,
	[IsCloseForced] [bit] NULL,
	[InsDateTime] [datetimeoffset](7) NOT NULL,
	[UpdDateTime] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_HSM_Failures_History] PRIMARY KEY CLUSTERED 
(
	[IdMachineFailureHistory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [HISTORY]
) ON [HISTORY]

GO

ALTER TABLE [rodeo].[HSM_Failures_History]  WITH CHECK ADD  CONSTRAINT [FK_HSM_Failures_History_Rodeo_Machines] FOREIGN KEY([IdMachineFailure]) REFERENCES [safety].[HSM_Machine_Failures] ([IdMachineFailure])

GO

ALTER TABLE [rodeo].[HSM_Failures_History] CHECK CONSTRAINT [FK_HSM_Failures_History_Rodeo_Machines]

GO

ALTER TABLE [rodeo].[HSM_Failures_History] ADD  CONSTRAINT [DF_HSM_Failures_History_InsDateTime]  DEFAULT (sysdatetimeoffset()) FOR [InsDateTime]
GO

ALTER TABLE [rodeo].[HSM_Failures_History] ADD  CONSTRAINT [DF_HSM_Failures_History_UpdDateTime]  DEFAULT (sysdatetimeoffset()) FOR [UpdDateTime]
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_HSM_Failures_History_Alarm] ON [rodeo].[HSM_Failures_History]
(
	[IdMachineFailure] ASC,
	[TimeOn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [HISTORY]
GO

CREATE NONCLUSTERED INDEX [IX_HSM_Failures_History_Date] ON [rodeo].[HSM_Failures_History]
(
	[TimeOn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [HISTORY]
GO
