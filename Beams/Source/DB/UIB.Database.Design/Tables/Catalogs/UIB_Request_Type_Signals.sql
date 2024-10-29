CREATE TABLE [safety].[HSM_Request_Type_Signals](
	[IdRequestType] [int] NOT NULL,
	[IdRequestSignal] [int] NOT NULL,
	[ShowOnBrief] [bit] NOT NULL,
	[ReadAllowed] [bit] NOT NULL,
	[WriteAllowed] [bit] NOT NULL,
	[ManActionReq] [bit] NOT NULL,
	[AutoActionReq] [bit] NOT NULL,
	[Order] [smallint] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_HSM_Request_Type_Signals] PRIMARY KEY CLUSTERED 
(
	[IdRequestType] ASC,
	[IdRequestSignal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO 

ALTER TABLE [safety].[HSM_Request_Type_Signals]  WITH CHECK ADD  CONSTRAINT [FK_HSM_Request_Type_Signals_HSM_Request_Types] FOREIGN KEY([IdRequestType]) REFERENCES [safety].[HSM_Request_Types] ([IdRequestType])

GO

ALTER TABLE [safety].[HSM_Request_Type_Signals] CHECK CONSTRAINT [FK_HSM_Request_Type_Signals_HSM_Request_Types]

GO

ALTER TABLE [safety].[HSM_Request_Type_Signals]  WITH CHECK ADD  CONSTRAINT [FK_HSM_Request_Type_Signals_HSM_Request_Signals] FOREIGN KEY([IdRequestSignal]) REFERENCES [safety].[HSM_Request_Signals] ([IdRequestSignal])

GO

ALTER TABLE [safety].[HSM_Request_Type_Signals] CHECK CONSTRAINT [FK_HSM_Request_Type_Signals_HSM_Request_Signals]

GO

ALTER TABLE [safety].[HSM_Request_Type_Signals] ADD  CONSTRAINT [DF_HSM_Request_Type_Signals_Active]  DEFAULT ((1)) FOR [Active]