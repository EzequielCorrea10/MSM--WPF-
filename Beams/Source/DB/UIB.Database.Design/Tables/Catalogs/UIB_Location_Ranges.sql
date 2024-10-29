CREATE TABLE [common].[HCM_Location_Ranges](
	[IdLocationRange] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[LengthRange] [varchar](1) NOT NULL,
	[WidthSubRange] [varchar](1) NOT NULL,
	[Piece_Length_Min] [int] NOT NULL,
	[Piece_Length_Max] [int] NOT NULL,
	[Piece_Width_Min] [int] NULL,
	[Piece_Width_Max] [int] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_HCM_Location_Ranges] PRIMARY KEY CLUSTERED 
(
	[IdLocationRange] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [common].[HCM_Location_Ranges] ADD  CONSTRAINT [DF_HCM_Location_Ranges_Active]  DEFAULT ((1)) FOR [Active]
GO