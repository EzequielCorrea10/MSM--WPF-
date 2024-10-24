CREATE TABLE [to].[Rodeo_TO_Steps](
	[IdTransportOrder] [bigint] NOT NULL,
	[Step] [smallint] NOT NULL,
	[IdTOAction] [int] NOT NULL,
	[IdTOStatus] [int] NOT NULL,

	[LocationNameBegin] [varchar](50) NULL,
	[IdYardBegin] [int] NOT NULL,
	[XPosBegin] [int] NOT NULL,
	[YPosBegin] [int] NOT NULL,
	[ZPosBegin] [int] NULL,
	[HeadingBegin] SMALLINT NOT NULL,

	[LocationNameEnd] [varchar](50) NULL,
	[IdYardEnd] [int] NULL,
	[XPosEnd] [int] NULL,
	[YPosEnd] [int] NULL,
	[ZPosEnd] [int] NULL,
	[HeadingEnd] SMALLINT NULL,

	[GrabberOpening] [smallint] NULL,
	[WaitTime] [smallint] NULL,
	[Speed] [float] NULL,

	[ConnectLocationName] [varchar](50) NULL,
	[IdPathBegin] [int] NULL,
	[PathOffsetBegin] [int] NULL,
	[IdPathEnd] [int] NULL,
	[PathOffsetEnd] [int] NULL,
	[MachineHeading] [int] NULL,
	[MachineName] [varchar](50) NULL,

	[BeginTime] [datetimeoffset](7) NULL,
	[EndTime] [datetimeoffset](7) NULL,
	[InsDateTime] [datetimeoffset](7) NOT NULL,
	[UpdDateTime] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Rodeo_TO_Steps] PRIMARY KEY CLUSTERED 
(
	[IdTransportOrder] ASC,
	[Step] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PROCESS]
) ON [PROCESS]

GO

ALTER TABLE [to].[Rodeo_TO_Steps] ADD  CONSTRAINT [DF_Rodeo_TO_Steps_InsDateTime]  DEFAULT (sysdatetimeoffset()) FOR [InsDateTime]

GO

ALTER TABLE [to].[Rodeo_TO_Steps] ADD  CONSTRAINT [DF_Rodeo_TO_Steps_UpdDateTime]  DEFAULT (sysdatetimeoffset()) FOR [UpdDateTime]

GO

ALTER TABLE [to].[Rodeo_TO_Steps]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_TO_Steps_Rodeo_TO_Actions] FOREIGN KEY([IdTOAction]) REFERENCES [to].[Rodeo_TO_Actions] ([IdTOAction])

GO

ALTER TABLE [to].[Rodeo_TO_Steps] CHECK CONSTRAINT [FK_Rodeo_TO_Steps_Rodeo_TO_Actions]

GO

ALTER TABLE [to].[Rodeo_TO_Steps]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_TO_Steps_Rodeo_TO_Statuses] FOREIGN KEY([IdTOStatus]) REFERENCES [to].[Rodeo_TO_Statuses] ([IdTOStatus])

GO

ALTER TABLE [to].[Rodeo_TO_Steps] CHECK CONSTRAINT [FK_Rodeo_TO_Steps_Rodeo_TO_Statuses]

GO

ALTER TABLE [to].[Rodeo_TO_Steps]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_TO_Steps_Rodeo_Yards_Begin] FOREIGN KEY([IdYardBegin]) REFERENCES [common].[Rodeo_Yards] ([IdYard])

GO

ALTER TABLE [to].[Rodeo_TO_Steps] CHECK CONSTRAINT [FK_Rodeo_TO_Steps_Rodeo_Yards_Begin]

GO

ALTER TABLE [to].[Rodeo_TO_Steps]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_TO_Steps_Rodeo_Yards_End] FOREIGN KEY([IdYardEnd]) REFERENCES [common].[Rodeo_Yards] ([IdYard])

GO

ALTER TABLE [to].[Rodeo_TO_Steps] CHECK CONSTRAINT [FK_Rodeo_TO_Steps_Rodeo_Yards_End]

GO

--ALTER TABLE [to].[Rodeo_TO_Steps]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_TO_Steps_Rodeo_Paths_Begin] FOREIGN KEY([IdPathBegin]) REFERENCES [tracking].[MSM_Paths] ([IdPath])

--GO

--ALTER TABLE [to].[Rodeo_TO_Steps] CHECK CONSTRAINT [FK_Rodeo_TO_Steps_Rodeo_Paths_Begin]

--GO

--ALTER TABLE [to].[Rodeo_TO_Steps]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_TO_Steps_Rodeo_Paths_End] FOREIGN KEY([IdPathEnd]) REFERENCES [tracking].[MSM_Paths] ([IdPath])

--GO

ALTER TABLE [to].[Rodeo_TO_Steps] CHECK CONSTRAINT [FK_Rodeo_TO_Steps_Rodeo_Yards_End]

GO

ALTER TABLE [to].[Rodeo_TO_Steps]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_TO_Steps_Rodeo_TransportOrders] FOREIGN KEY([IdTransportOrder]) REFERENCES [to].[Rodeo_TransportOrders] ([IdTransportOrder])

GO

ALTER TABLE [to].[Rodeo_TO_Steps] CHECK CONSTRAINT [FK_Rodeo_TO_Steps_Rodeo_TransportOrders]

