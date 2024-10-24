CREATE TABLE [safety].[MSM_Requests](
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
 CONSTRAINT [PK_MSM_Requests] PRIMARY KEY CLUSTERED 
(
	[IdRequest] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_MSM_Requests_PlcValue] UNIQUE NONCLUSTERED 
(
	[PlcValue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO 

CREATE UNIQUE NONCLUSTERED INDEX [IX_MSM_Requests_Name] ON [safety].[MSM_Requests]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

ALTER TABLE [safety].[MSM_Requests]  WITH CHECK ADD  CONSTRAINT [FK_MSM_Requests_MSM_Request_Types] FOREIGN KEY([IdRequestType]) REFERENCES [safety].[MSM_Request_Types] ([IdRequestType])

GO

ALTER TABLE [safety].[MSM_Requests] CHECK CONSTRAINT [FK_MSM_Requests_MSM_Request_Types]

GO

ALTER TABLE [safety].[MSM_Requests]  WITH CHECK ADD  CONSTRAINT [FK_MSM_Requests_MSM_Zones] FOREIGN KEY([IdZone]) REFERENCES [safety].[MSM_Zones] ([IdZone])

GO

ALTER TABLE [safety].[MSM_Requests] CHECK CONSTRAINT [FK_MSM_Requests_MSM_Zones]

GO

ALTER TABLE [safety].[MSM_Requests]  WITH CHECK ADD  CONSTRAINT [FK_MSM_Requests_Rodeo_Yards] FOREIGN KEY([IdYard]) REFERENCES [common].[Rodeo_Yards] ([IdYard])
GO

ALTER TABLE [safety].[MSM_Requests] CHECK CONSTRAINT [FK_MSM_Requests_Rodeo_Yards]
GO

ALTER TABLE [safety].[MSM_Requests] ADD  CONSTRAINT [DF_MSM_Requests_Active]  DEFAULT ((1)) FOR [Active]
