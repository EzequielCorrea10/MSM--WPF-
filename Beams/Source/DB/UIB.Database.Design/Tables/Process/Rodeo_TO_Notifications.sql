CREATE TABLE [to].[Rodeo_TO_Notifications](
	[IdTransportOrder] [bigint] NOT NULL,
	[PickupConditional] [bit] NULL,
	[ResetRequested] [bit] NULL,
	[CancelRequested] [bit] NULL,
	[RedirectRequested] [bit] NULL,
	[RecalculateRequested] [bit] NULL,
	[RCPFlagCode] [smallint] NULL,
	[InsDateTime] [datetimeoffset](7) NOT NULL,
	[UpdDateTime] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Rodeo_TO_Notifications] PRIMARY KEY CLUSTERED 
(
	[IdTransportOrder] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PROCESS]
) ON [PROCESS]

GO

ALTER TABLE [to].[Rodeo_TO_Notifications] ADD  CONSTRAINT [DF_Rodeo_TO_Notifications_InsDateTime]  DEFAULT (sysdatetimeoffset()) FOR [InsDateTime]

GO

ALTER TABLE [to].[Rodeo_TO_Notifications] ADD  CONSTRAINT [DF_Rodeo_TO_Notifications_UpdDateTime]  DEFAULT (sysdatetimeoffset()) FOR [UpdDateTime]

GO

ALTER TABLE [to].[Rodeo_TO_Notifications]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_TO_Notifications_Rodeo_TransportOrders] FOREIGN KEY([IdTransportOrder]) REFERENCES [to].[Rodeo_TransportOrders] ([IdTransportOrder])

GO

ALTER TABLE [to].[Rodeo_TO_Notifications] CHECK CONSTRAINT [FK_Rodeo_TO_Notifications_Rodeo_TransportOrders]

GO
