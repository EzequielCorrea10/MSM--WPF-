CREATE TABLE [common].[Rodeo_Yards](
	[IdYard] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[X1AbsolutePos] [int] NOT NULL,
	[X2AbsolutePos] [int] NOT NULL,
	[Y1AbsolutePos] [int] NOT NULL,
	[Y2AbsolutePos] [int] NOT NULL,
	[Z1Pos] [int] NOT NULL,
	[Z2Pos] [int] NOT NULL,
	[IsAxisX] [bit] NOT NULL,
	[PlcValue] [int] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Rodeo_Yards] PRIMARY KEY CLUSTERED 
(
	[IdYard] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Rodeo_Yards_PlcValue] UNIQUE NONCLUSTERED 
(
	[PlcValue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [common].[Rodeo_Yards] ADD  CONSTRAINT [DF_Rodeo_Yards_Active]  DEFAULT ((1)) FOR [Active]
GO
