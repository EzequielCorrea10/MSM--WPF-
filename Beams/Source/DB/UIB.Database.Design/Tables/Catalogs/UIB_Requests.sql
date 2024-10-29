CREATE TABLE [safety].[HSM_Requests](
	[IdRequest] [int] NOT NULL,
	[IdRequestType] [int] NOT NULL,
	[IdZone] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[IdYard] [int] NULL,
	[XPos] [int] NULL,
	[YPos] [int] NULL,
	[ZPos] [int] NULL,
	[IsAxisX] [bit] NULL,
	[TextPosition] [nchar](1) NULL,
	[TextDisplayed] [varchar](20) NULL,
	[PlcValue] [int] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_HSM_Requests] PRIMARY KEY CLUSTERED 
(
	[IdRequest] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_HSM_Requests_PlcValue] UNIQUE NONCLUSTERED 
(
	[PlcValue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO 

CREATE UNIQUE NONCLUSTERED INDEX [IX_HSM_Requests_Name] ON [safety].[HSM_Requests]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

ALTER TABLE [safety].[HSM_Requests]  WITH CHECK ADD  CONSTRAINT [FK_HSM_Requests_HSM_Request_Types] FOREIGN KEY([IdRequestType]) REFERENCES [safety].[HSM_Request_Types] ([IdRequestType])

GO

ALTER TABLE [safety].[HSM_Requests] CHECK CONSTRAINT [FK_HSM_Requests_HSM_Request_Types]

GO

ALTER TABLE [safety].[HSM_Requests]  WITH CHECK ADD  CONSTRAINT [FK_HSM_Requests_HSM_Zones] FOREIGN KEY([IdZone]) REFERENCES [safety].[HSM_Zones] ([IdZone])

GO

ALTER TABLE [safety].[HSM_Requests] CHECK CONSTRAINT [FK_HSM_Requests_HSM_Zones]

GO

ALTER TABLE [safety].[HSM_Requests]  WITH CHECK ADD  CONSTRAINT [FK_HSM_Requests_Rodeo_Yards] FOREIGN KEY([IdYard]) REFERENCES [common].[Rodeo_Yards] ([IdYard])
GO

ALTER TABLE [safety].[HSM_Requests] CHECK CONSTRAINT [FK_HSM_Requests_Rodeo_Yards]
GO

ALTER TABLE [safety].[HSM_Requests] ADD  CONSTRAINT [DF_HSM_Requests_Active]  DEFAULT ((1)) FOR [Active]
