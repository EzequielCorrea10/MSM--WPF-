CREATE TABLE [safety].[MSM_Request_Interlocks](
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
 CONSTRAINT [PK_MSM_Request_Interlocks] PRIMARY KEY CLUSTERED 
(
	[IdRequest] ASC,
	[IdRequestSignal] ASC,
	[RequestSignalTrueOrFalse] ASC,
	[Order] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY], 
    CONSTRAINT [CK_MSM_Request_Interlocks] CHECK ((([ByIdRequest] IS NOT NULL AND 
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

ALTER TABLE [safety].[MSM_Request_Interlocks]  WITH CHECK ADD  CONSTRAINT [FK_MSM_Request_Interlocks_MSM_Requests] FOREIGN KEY([IdRequest]) REFERENCES [safety].[MSM_Requests] ([IdRequest])

GO

ALTER TABLE [safety].[MSM_Request_Interlocks] CHECK CONSTRAINT [FK_MSM_Request_Interlocks_MSM_Requests]

GO

ALTER TABLE [safety].[MSM_Request_Interlocks]  WITH CHECK ADD  CONSTRAINT [FK_MSM_Request_Interlocks_MSM_Request_Signals] FOREIGN KEY([IdRequestSignal]) REFERENCES [safety].[MSM_Request_Signals] ([IdRequestSignal])

GO

ALTER TABLE [safety].[MSM_Request_Interlocks] CHECK CONSTRAINT [FK_MSM_Request_Interlocks_MSM_Request_Signals]

GO

ALTER TABLE [safety].[MSM_Request_Interlocks]  WITH CHECK ADD  CONSTRAINT [FK_MSM_Request_Interlocks_By_MSM_Zones] FOREIGN KEY([ByIdZone]) REFERENCES [safety].[MSM_Zones] ([IdZone])

GO

ALTER TABLE [safety].[MSM_Request_Interlocks] CHECK CONSTRAINT [FK_MSM_Request_Interlocks_By_MSM_Zones]

GO

ALTER TABLE [safety].[MSM_Request_Interlocks]  WITH CHECK ADD  CONSTRAINT [FK_MSM_Request_Interlocks_By_MSM_Requests] FOREIGN KEY([ByIdRequest]) REFERENCES [safety].[MSM_Requests] ([IdRequest])

GO

ALTER TABLE [safety].[MSM_Request_Interlocks] CHECK CONSTRAINT [FK_MSM_Request_Interlocks_By_MSM_Requests]

GO

ALTER TABLE [safety].[MSM_Request_Interlocks]  WITH CHECK ADD  CONSTRAINT [FK_MSM_Request_Interlocks_By_MSM_Request_Signals] FOREIGN KEY([ByIdRequestSignal]) REFERENCES [safety].[MSM_Request_Signals] ([IdRequestSignal])

GO

ALTER TABLE [safety].[MSM_Request_Interlocks] CHECK CONSTRAINT [FK_MSM_Request_Interlocks_By_MSM_Request_Signals]

GO

ALTER TABLE [safety].[MSM_Request_Interlocks] ADD  CONSTRAINT [DF_MSM_Request_Interlocks_Active]  DEFAULT ((1)) FOR [Active]
