CREATE TABLE [to].[MSM_Job_Forecasts](
	[IdJob] [bigint] NOT NULL,
	[Sequence] [smallint] NOT NULL,
	[LocationNameBegin] [varchar](50) NULL,
	[MachineNameBegin] [varchar](50) NULL,
	[IdYardBegin] [int] NULL,
	[XPosBegin] [int] NULL,
	[YPosBegin] [int] NULL,
	[ZPosBegin] [int] NULL,
	[HeadingBegin] [smallint] NULL,
	[LocationNameEnd] [varchar](50) NULL,
	[MachineNameEnd] [varchar](50) NULL,
	[IdYardEnd] [int] NULL,
	[XPosEnd] [int] NULL,
	[YPosEnd] [int] NULL,
	[ZPosEnd] [int] NULL,
	[HeadingEnd] [smallint] NULL,
	[PieceName] [varchar](50) NOT NULL,
	[MachineName] [varchar](50) NULL,
	[Order] [int] NOT NULL,
	[Notes] [varchar](max) NULL,
	[InsDateTime] [datetimeoffset](7) NOT NULL,
	[UpdDateTime] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_MSM_Job_Forecasts] PRIMARY KEY CLUSTERED
(
	[IdJob] ASC,
	[Sequence] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PROCESS]
) ON [PROCESS] TEXTIMAGE_ON [PROCESS]
GO

ALTER TABLE [to].[MSM_Job_Forecasts] ADD  CONSTRAINT [DF_MSM_Job_Forecasts_InsDateTime]  DEFAULT (sysdatetimeoffset()) FOR [InsDateTime]
GO

ALTER TABLE [to].[MSM_Job_Forecasts] ADD  CONSTRAINT [DF_MSM_Job_Forecasts_UpdDateTime]  DEFAULT (sysdatetimeoffset()) FOR [UpdDateTime]
GO

CREATE NONCLUSTERED INDEX [IX_MSM_Job_Forecasts_IdJob] ON [to].[MSM_Job_Forecasts]
(
	[IdJob] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PROCESS]

GO

ALTER TABLE [to].[MSM_Job_Forecasts]  WITH CHECK ADD  CONSTRAINT [FK_MSM_Job_Forecasts_Rodeo_Yards_Begin] FOREIGN KEY([IdYardBegin]) REFERENCES [common].[Rodeo_Yards] ([IdYard])

GO

ALTER TABLE [to].[MSM_Job_Forecasts] CHECK CONSTRAINT [FK_MSM_Job_Forecasts_Rodeo_Yards_Begin]

GO

ALTER TABLE [to].[MSM_Job_Forecasts]  WITH CHECK ADD  CONSTRAINT [FK_MSM_Job_Forecasts_Rodeo_Yards_End] FOREIGN KEY([IdYardEnd]) REFERENCES [common].[Rodeo_Yards] ([IdYard])

GO

ALTER TABLE [to].[MSM_Job_Forecasts] CHECK CONSTRAINT [FK_MSM_Job_Forecasts_Rodeo_Yards_End]

GO

ALTER TABLE [to].[MSM_Job_Forecasts]  WITH CHECK ADD  CONSTRAINT [FK_MSM_Job_Forecasts_MSM_Jobs] FOREIGN KEY([IdJob]) REFERENCES [to].[MSM_Jobs] ([IdJob])

GO
