CREATE TABLE [safety].[HCM_Request_Transport_Dependencies](
	[IdRequest] [int] NOT NULL,
	[IdTransportLocation] [int] NOT NULL,
	[IdRequestSignal] [int] NOT NULL,
	[RequestSignalTrueOrFalse] [bit] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_HCM_Request_Transport_Dependencies] PRIMARY KEY CLUSTERED 
(
	[IdRequest] ASC,
	[IdTransportLocation] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO 

ALTER TABLE [safety].[HCM_Request_Transport_Dependencies]  WITH CHECK ADD  CONSTRAINT [FK_HCM_Request_Transport_Dependencies_Rodeo_Locations_Transport] FOREIGN KEY([IdTransportLocation]) REFERENCES [common].[Rodeo_Locations] ([IdLocation])
GO

ALTER TABLE [safety].[HCM_Request_Transport_Dependencies] CHECK CONSTRAINT [FK_HCM_Request_Transport_Dependencies_Rodeo_Locations_Transport]
GO

ALTER TABLE [safety].[HCM_Request_Transport_Dependencies]  WITH CHECK ADD  CONSTRAINT [FK_HCM_Request_Transport_Dependencies_HCM_Request_Signals] FOREIGN KEY([IdRequestSignal]) REFERENCES [safety].[HCM_Request_Signals] ([IdRequestSignal])
GO

ALTER TABLE [safety].[HCM_Request_Transport_Dependencies] CHECK CONSTRAINT [FK_HCM_Request_Transport_Dependencies_HCM_Request_Signals]
GO

ALTER TABLE [safety].[HCM_Request_Transport_Dependencies] ADD  CONSTRAINT [DF_HCM_Request_Transport_Dependencies_Active]  DEFAULT ((1)) FOR [Active]
