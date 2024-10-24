CREATE TABLE [to].[Rodeo_TO_Step_History](
	[IdTransportOrder] [bigint] NOT NULL,
	[Step] [smallint] NOT NULL,
	[IdTOStatus] [int] NOT NULL,
	[BeginTime] [datetimeoffset](7) NOT NULL,
	[EndTime] [datetimeoffset](7) NOT NULL,
	[InsDateTime] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Rodeo_TO_Step_History] PRIMARY KEY CLUSTERED 
(
	[IdTransportOrder] ASC,
	[Step] ASC,
	[BeginTime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PROCESS]
) ON [PROCESS]

GO

ALTER TABLE [to].[Rodeo_TO_Step_History] ADD  CONSTRAINT [DF_Rodeo_TO_Step_History_InsDateTime]  DEFAULT (sysdatetimeoffset()) FOR [InsDateTime]

GO

ALTER TABLE [to].[Rodeo_TO_Step_History]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_TO_Step_History_Rodeo_TO_Statuses] FOREIGN KEY([IdTOStatus]) REFERENCES [to].[Rodeo_TO_Statuses] ([IdTOStatus])

GO

ALTER TABLE [to].[Rodeo_TO_Step_History] CHECK CONSTRAINT [FK_Rodeo_TO_Step_History_Rodeo_TO_Statuses]

GO

ALTER TABLE [to].[Rodeo_TO_Step_History]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_TO_Step_History_Rodeo_TransportOrders] FOREIGN KEY([IdTransportOrder]) REFERENCES [to].[Rodeo_TransportOrders] ([IdTransportOrder])

GO

ALTER TABLE [to].[Rodeo_TO_Step_History] CHECK CONSTRAINT [FK_Rodeo_TO_Step_History_Rodeo_TransportOrders]

