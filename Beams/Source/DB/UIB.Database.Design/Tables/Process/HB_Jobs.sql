CREATE TABLE [to].[HB_Jobs](
	[IdJob] [bigint] IDENTITY(1,1) NOT NULL,
	[IdMasterJob] [bigint] NULL,
	[IdJobType] [int] NOT NULL,
	[IdTOStatus] [int] NOT NULL,
	
	[PickupReqLocationName] [varchar](50) NULL,
	[PickupReqMachineName] [varchar](50) NULL,
	[PickupReqIdYard] [int] NULL,
	[PickupReqXPos] [int] NULL,
	[PickupReqYPos] [int] NULL,
	[PickupReqZPos] [int] NULL,
	[PickupReqHeading] [smallint] NULL,

	[PickupFinalLocationName] [varchar](50) NULL,
	[PickupFinalMachineName] [varchar](50) NULL,
	[PickupFinalIdYard] [int] NULL,
	[PickupFinalXPos] [int] NULL,
	[PickupFinalYPos] [int] NULL,
	[PickupFinalZPos] [int] NULL,
	[PickupFinalHeading] [smallint] NULL,
	
	[DropReqLocationName] [varchar](50) NULL,
	[DropReqMachineName] [varchar](50) NULL,
	[DropReqIdYard] [int] NULL,
	[DropReqXPos] [int] NULL,
	[DropReqYPos] [int] NULL,
	[DropReqZPos] [int] NULL,
	[DropReqHeading] [smallint] NULL,

	[DropAssignLocationName] [varchar](50) NULL,
	[DropAssignMachineName] [varchar](50) NULL,
	[DropAssignIdYard] [int] NULL,
	[DropAssignXPos] [int] NULL,
	[DropAssignYPos] [int] NULL,
	[DropAssignZPos] [int] NULL,
	[DropAssignHeading] [smallint] NULL,

	[DropInitialLocationName] [varchar](50) NULL,
	[DropInitialMachineName] [varchar](50) NULL,
	[DropInitialIdYard] [int] NULL,
	[DropInitialXPos] [int] NULL,
	[DropInitialYPos] [int] NULL,
	[DropInitialZPos] [int] NULL,
	[DropInitialHeading] [smallint] NULL,
	
	[DropRedirectLocationName] [varchar](50) NULL,
	[DropRedirectMachineName] [varchar](50) NULL,
	[DropRedirectIdYard] [int] NULL,
	[DropRedirectXPos] [int] NULL,
	[DropRedirectYPos] [int] NULL,
	[DropRedirectZPos] [int] NULL,
	[DropRedirectHeading] [smallint] NULL,
	
	[FormattedInstructions] [varchar](MAX) NULL,
	[PieceName] [varchar](50) NOT NULL,
	[HighPriority] [bit] NULL,
	[Bypasses] [int] NOT NULL,
	[RequestTime] [datetimeoffset](7) NOT NULL,
	[BeginTime] [datetimeoffset](7) NULL,
	[PickupTime] [datetimeoffset](7) NULL,
	[StorageTime] [datetimeoffset](7) NULL,
	[EndTime] [datetimeoffset](7) NULL,
	[CancelTime] [datetimeoffset](7) NULL,
	[UsernameRequest] [varchar](40) NULL,
	[UsernameCancel] [varchar](40) NULL,
	[Notes] [varchar](MAX) NULL,
	[InsDateTime] [datetimeoffset](7) NOT NULL,
	[UpdDateTime] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_HB_Jobs] PRIMARY KEY CLUSTERED 
(
	[IdJob] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PROCESS]
) ON [PROCESS]

GO
 
ALTER TABLE [to].[HB_Jobs]  WITH CHECK ADD  CONSTRAINT [FK_HB_Jobs_HB_Job_Types] FOREIGN KEY([IdJobType]) REFERENCES [to].[HB_Job_Types] ([IdJobType])

GO

ALTER TABLE [to].[HB_Jobs] CHECK CONSTRAINT [FK_HB_Jobs_HB_Job_Types]

GO

CREATE NONCLUSTERED INDEX [IX_HB_Jobs_Global] ON [to].[HB_Jobs]
(
	[IdMasterJob] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PROCESS]

GO 

CREATE NONCLUSTERED INDEX [IX_HB_Jobs_IdJobType] ON [to].[HB_Jobs]
(
	[IdJobType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PROCESS]

GO 

ALTER TABLE [to].[HB_Jobs]  WITH CHECK ADD  CONSTRAINT [FK_HB_Jobs_Rodeo_TO_Statuses] FOREIGN KEY([IdTOStatus]) REFERENCES [to].[Rodeo_TO_Statuses] ([IdTOStatus])

GO

ALTER TABLE [to].[HB_Jobs] CHECK CONSTRAINT [FK_HB_Jobs_Rodeo_TO_Statuses]

GO

CREATE NONCLUSTERED INDEX [IX_HB_Jobs_IdTOStatus] ON [to].[HB_Jobs]
(
	[IdTOStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PROCESS]

GO

CREATE NONCLUSTERED INDEX [IX_HB_Jobs_RequestTime] ON [to].[HB_Jobs]
(
	[RequestTime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PROCESS]

GO

ALTER TABLE [to].[HB_Jobs]  WITH CHECK ADD  CONSTRAINT [FK_HB_Jobs_Rodeo_Yards_Begin] FOREIGN KEY([PickupFinalIdYard]) REFERENCES [common].[Rodeo_Yards] ([IdYard])

GO

ALTER TABLE [to].[HB_Jobs] CHECK CONSTRAINT [FK_HB_Jobs_Rodeo_Yards_Begin]

GO

ALTER TABLE [to].[HB_Jobs]  WITH CHECK ADD  CONSTRAINT [FK_HB_Jobs_Rodeo_Yards_End] FOREIGN KEY([DropInitialIdYard]) REFERENCES [common].[Rodeo_Yards] ([IdYard])

GO

ALTER TABLE [to].[HB_Jobs] CHECK CONSTRAINT [FK_HB_Jobs_Rodeo_Yards_End]

GO

ALTER TABLE [to].[HB_Jobs]  WITH CHECK ADD  CONSTRAINT [FK_HB_Jobs_Rodeo_Yards_Redirect] FOREIGN KEY([DropRedirectIdYard]) REFERENCES [common].[Rodeo_Yards] ([IdYard])

GO

ALTER TABLE [to].[HB_Jobs] CHECK CONSTRAINT [FK_HB_Jobs_Rodeo_Yards_Redirect]

GO

ALTER TABLE [to].[HB_Jobs]  WITH CHECK ADD  CONSTRAINT [FK_HB_Jobs_Rodeo_Yards_Begin_Req] FOREIGN KEY([PickupReqIdYard]) REFERENCES [common].[Rodeo_Yards] ([IdYard])

GO

ALTER TABLE [to].[HB_Jobs] CHECK CONSTRAINT [FK_HB_Jobs_Rodeo_Yards_Begin_Req]

GO

ALTER TABLE [to].[HB_Jobs]  WITH CHECK ADD  CONSTRAINT [FK_HB_Jobs_Rodeo_Yards_End_Req] FOREIGN KEY([DropReqIdYard]) REFERENCES [common].[Rodeo_Yards] ([IdYard])

GO

ALTER TABLE [to].[HB_Jobs] CHECK CONSTRAINT [FK_HB_Jobs_Rodeo_Yards_End_Req]

GO

ALTER TABLE [to].[HB_Jobs]  WITH CHECK ADD  CONSTRAINT [FK_HB_Jobs_Rodeo_Yards_End_Assign] FOREIGN KEY([DropAssignIdYard]) REFERENCES [common].[Rodeo_Yards] ([IdYard])

GO

ALTER TABLE [to].[HB_Jobs] CHECK CONSTRAINT [FK_HB_Jobs_Rodeo_Yards_End_Assign]

GO

ALTER TABLE [to].[HB_Jobs] ADD  CONSTRAINT [DF_HB_Jobs_InsDateTime]  DEFAULT (sysdatetimeoffset()) FOR [InsDateTime]

GO

ALTER TABLE [to].[HB_Jobs] ADD  CONSTRAINT [DF_HB_Jobs_UpdDateTime]  DEFAULT (sysdatetimeoffset()) FOR [UpdDateTime]
