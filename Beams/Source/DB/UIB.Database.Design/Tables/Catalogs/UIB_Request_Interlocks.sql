CREATE TABLE [safety].[HCM_Request_Interlocks](
	[IdRequest] [int] NOT NULL,
	[IdRequestSignal] [int] NOT NULL,
	[RequestSignalTrueOrFalse] [bit] NOT NULL,
	[ByIdZone] [int] NULL,
	[ByZoneEnableOrDisable] [bit] NULL,
	[ByIdRequest] [int] NULL,
	[ByIdRequestSignal] [int] NULL,
	[ByRequestSignalTrueOrFalse] [bit] NULL,
	[ByOtherTitle] VARCHAR(250) NULL,
	[ByOtherTagname] VARCHAR(70) NULL,
	[ByOtherBit] [bit] NULL,
	[ByOtherPlcValue] [int] NULL,
	[TextSizeDisplayed] [smallint] NOT NULL DEFAULT 1,
	[Order] [smallint] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_HCM_Request_Interlocks] PRIMARY KEY CLUSTERED 
(
	[IdRequest] ASC,
	[IdRequestSignal] ASC,
	[RequestSignalTrueOrFalse] ASC,
	[Order] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY], 
    CONSTRAINT [CK_HCM_Request_Interlocks] CHECK ((([ByIdRequest] IS NOT NULL AND 
  [ByIdZone] IS NULL AND
  [ByOtherTagname] IS NULL) OR 
 ([ByIdRequest] IS NULL AND 
  [ByIdZone] IS NOT NULL AND 
  [ByOtherTagname] IS NULL) OR 
 ([ByIdRequest] IS NULL AND 
  [ByIdZone] IS NULL AND
  [ByOtherTagname] IS NOT NULL))),
) ON [PRIMARY]

GO 

ALTER TABLE [safety].[HCM_Request_Interlocks]  WITH CHECK ADD  CONSTRAINT [FK_HCM_Request_Interlocks_HCM_Requests] FOREIGN KEY([IdRequest]) REFERENCES [safety].[HCM_Requests] ([IdRequest])

GO

ALTER TABLE [safety].[HCM_Request_Interlocks] CHECK CONSTRAINT [FK_HCM_Request_Interlocks_HCM_Requests]

GO

ALTER TABLE [safety].[HCM_Request_Interlocks]  WITH CHECK ADD  CONSTRAINT [FK_HCM_Request_Interlocks_HCM_Request_Signals] FOREIGN KEY([IdRequestSignal]) REFERENCES [safety].[HCM_Request_Signals] ([IdRequestSignal])

GO

ALTER TABLE [safety].[HCM_Request_Interlocks] CHECK CONSTRAINT [FK_HCM_Request_Interlocks_HCM_Request_Signals]

GO

ALTER TABLE [safety].[HCM_Request_Interlocks]  WITH CHECK ADD  CONSTRAINT [FK_HCM_Request_Interlocks_By_HCM_Zones] FOREIGN KEY([ByIdZone]) REFERENCES [safety].[HCM_Zones] ([IdZone])

GO

ALTER TABLE [safety].[HCM_Request_Interlocks] CHECK CONSTRAINT [FK_HCM_Request_Interlocks_By_HCM_Zones]

GO

ALTER TABLE [safety].[HCM_Request_Interlocks]  WITH CHECK ADD  CONSTRAINT [FK_HCM_Request_Interlocks_By_HCM_Requests] FOREIGN KEY([ByIdRequest]) REFERENCES [safety].[HCM_Requests] ([IdRequest])

GO

ALTER TABLE [safety].[HCM_Request_Interlocks] CHECK CONSTRAINT [FK_HCM_Request_Interlocks_By_HCM_Requests]

GO

ALTER TABLE [safety].[HCM_Request_Interlocks]  WITH CHECK ADD  CONSTRAINT [FK_HCM_Request_Interlocks_By_HCM_Request_Signals] FOREIGN KEY([ByIdRequestSignal]) REFERENCES [safety].[HCM_Request_Signals] ([IdRequestSignal])

GO

ALTER TABLE [safety].[HCM_Request_Interlocks] CHECK CONSTRAINT [FK_HCM_Request_Interlocks_By_HCM_Request_Signals]

GO

ALTER TABLE [safety].[HCM_Request_Interlocks] ADD  CONSTRAINT [DF_HCM_Request_Interlocks_Active]  DEFAULT ((1)) FOR [Active]
