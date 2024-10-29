CREATE TABLE [safety].[HCM_Request_Signal_Requests](
	[IdRequest] [int] NOT NULL,
	[IdRequestSignal] [int] NOT NULL,
	[ReadTagname] [varchar](70) NULL,
	[Bit] [int] NULL,
	[PlcValue] [int] NULL,
	[WriteTagname] [varchar](70) NULL,
	[SetpointValue] [int] NULL,
	[Alarmname] [varchar](70) NULL,
	[SignalInterlock_ReadTagname] [varchar](70) NULL,
	[SignalInterlock_Bit] [int] NULL,
	[SignalInterlock_PlcValue] [int] NULL,
	[OtherwiseInterlock_ReadTagname] [varchar](70) NULL,
	[OtherwiseInterlock_Bit] [int] NULL,
	[OtherwiseInterlock_PlcValue] [int] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_HCM_Request_Signal_Requests] PRIMARY KEY CLUSTERED 
(
	[IdRequest] ASC,
	[IdRequestSignal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO 

ALTER TABLE [safety].[HCM_Request_Signal_Requests]  WITH CHECK ADD  CONSTRAINT [FK_HCM_Request_Signal_Requests_HCM_Requests] FOREIGN KEY([IdRequest]) REFERENCES [safety].[HCM_Requests] ([IdRequest])

GO

ALTER TABLE [safety].[HCM_Request_Signal_Requests] CHECK CONSTRAINT [FK_HCM_Request_Signal_Requests_HCM_Requests]

GO

ALTER TABLE [safety].[HCM_Request_Signal_Requests]  WITH CHECK ADD  CONSTRAINT [FK_HCM_Request_Signal_Requests_HCM_Request_Signals] FOREIGN KEY([IdRequestSignal]) REFERENCES [safety].[HCM_Request_Signals] ([IdRequestSignal])

GO

ALTER TABLE [safety].[HCM_Request_Signal_Requests] CHECK CONSTRAINT [FK_HCM_Request_Signal_Requests_HCM_Request_Signals]

GO

ALTER TABLE [safety].[HCM_Request_Signal_Requests]  WITH CHECK ADD  CONSTRAINT [CK_HCM_Request_Signal_Requests] CHECK  (([ReadTagname] IS NOT NULL AND [PlcValue] IS NOT NULL) OR [Alarmname] IS NOT NULL)

GO

ALTER TABLE [safety].[HCM_Request_Signal_Requests] ADD  CONSTRAINT [DF_HCM_Request_Signal_Requests_Active]  DEFAULT ((1)) FOR [Active]

GO
