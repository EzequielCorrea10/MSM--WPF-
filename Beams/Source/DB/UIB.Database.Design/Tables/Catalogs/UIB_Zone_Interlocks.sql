CREATE TABLE [safety].[HSM_Zone_Interlocks](
	[IdZone] [int] NOT NULL,
	[EnableOrDisable] [bit] NOT NULL,
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
 CONSTRAINT [PK_HSM_Zone_Interlocks] PRIMARY KEY CLUSTERED 
(
	[IdZone] ASC,
	[EnableOrDisable] ASC,
	[Order] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY], 
    CONSTRAINT [CK_HSM_Zone_Interlocks] CHECK ((([ByIdRequest] IS NOT NULL AND 
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

ALTER TABLE [safety].[HSM_Zone_Interlocks]  WITH CHECK ADD  CONSTRAINT [FK_HSM_Zone_Interlocks_HSM_Zones] FOREIGN KEY([IdZone]) REFERENCES [safety].[HSM_Zones] ([IdZone])

GO

ALTER TABLE [safety].[HSM_Zone_Interlocks] CHECK CONSTRAINT [FK_HSM_Zone_Interlocks_HSM_Zones]

GO

ALTER TABLE [safety].[HSM_Zone_Interlocks]  WITH CHECK ADD  CONSTRAINT [FK_HSM_Zone_Interlocks_By_HSM_Zones] FOREIGN KEY([ByIdZone]) REFERENCES [safety].[HSM_Zones] ([IdZone])

GO

ALTER TABLE [safety].[HSM_Zone_Interlocks] CHECK CONSTRAINT [FK_HSM_Zone_Interlocks_By_HSM_Zones]

GO

ALTER TABLE [safety].[HSM_Zone_Interlocks]  WITH CHECK ADD  CONSTRAINT [FK_HSM_Zone_Interlocks_By_HSM_Requests] FOREIGN KEY([ByIdRequest]) REFERENCES [safety].[HSM_Requests] ([IdRequest])

GO

ALTER TABLE [safety].[HSM_Zone_Interlocks] CHECK CONSTRAINT [FK_HSM_Zone_Interlocks_By_HSM_Requests]

GO

ALTER TABLE [safety].[HSM_Zone_Interlocks]  WITH CHECK ADD  CONSTRAINT [FK_HSM_Zone_Interlocks_By_HSM_Request_Signals] FOREIGN KEY([ByIdRequestSignal]) REFERENCES [safety].[HSM_Request_Signals] ([IdRequestSignal])

GO

ALTER TABLE [safety].[HSM_Zone_Interlocks] CHECK CONSTRAINT [FK_HSM_Zone_Interlocks_By_HSM_Request_Signals]

GO

ALTER TABLE [safety].[HSM_Zone_Interlocks] ADD  CONSTRAINT [DF_HSM_Zone_Interlocks_Active]  DEFAULT ((1)) FOR [Active]
