CREATE TABLE [safety].[MSM_Zone_Sections](
	[IdZone] [int] NOT NULL,
	[Section] [smallint] NOT NULL,
	[IdYard] [int] NULL,
	[X1Pos] [int] NULL,
	[Y1Pos] [int] NULL,
	[X2Pos] [int] NULL,
	[Y2Pos] [int] NULL,
	[SafeRunwayInsideX1Pos] [int] NULL,
	[SafeRunwayInsideX2Pos] [int] NULL,
	[SafeRunwayInsideY1Pos] [int] NULL,
	[SafeRunwayInsideY2Pos] [int] NULL,
	[SafeRunwayOutsideX1Pos] [int] NULL,
	[SafeRunwayOutsideX2Pos] [int] NULL,
	[SafeRunwayOutsideY1Pos] [int] NULL,
	[SafeRunwayOutsideY2Pos] [int] NULL,
	[IsAxisX] [bit] NULL,
	[TextDisplayed] [varchar](20) NULL,
	[IsTransportArea] [bit] NULL,
	[ColorShown] [varchar](20) NULL,
	[Active] [bit] NOT NULL,
	[UpdDateTime] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_MSM_Zone_Sections] PRIMARY KEY CLUSTERED 
(
	[IdZone] ASC,
	[Section] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO 

ALTER TABLE [safety].[MSM_Zone_Sections]  WITH CHECK ADD  CONSTRAINT [FK_MSM_Zone_Sections_Rodeo_Yards] FOREIGN KEY([IdYard]) REFERENCES [common].[Rodeo_Yards] ([IdYard])
GO

ALTER TABLE [safety].[MSM_Zone_Sections] CHECK CONSTRAINT [FK_MSM_Zone_Sections_Rodeo_Yards]
GO

ALTER TABLE [safety].[MSM_Zone_Sections]  WITH CHECK ADD  CONSTRAINT [FK_MSM_Zone_Sections_MSM_Zones] FOREIGN KEY([IdZone]) REFERENCES [safety].[MSM_Zones] ([IdZone])

GO

ALTER TABLE [safety].[MSM_Zone_Sections] CHECK CONSTRAINT [FK_MSM_Zone_Sections_MSM_Zones]

GO

ALTER TABLE [safety].[MSM_Zone_Sections] ADD  CONSTRAINT [DF_MSM_Zone_Sections_Active]  DEFAULT ((1)) FOR [Active]

GO 

ALTER TABLE [safety].[MSM_Zone_Sections] ADD  CONSTRAINT [DF_MSM_Zone_Sections_UpdDateTime]  DEFAULT (sysdatetimeoffset()) FOR [UpdDateTime]
