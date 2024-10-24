CREATE TABLE [tracking].[MSM_Display_Piece_Groups](
	[IdDisplayPieceGroup] [int] NOT NULL,
	[IdDisplayPieceGroupParent] [int] NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[Position] [int] NOT NULL,
	[BackgroundColor] [varchar](10) NOT NULL,
	[ForegroundColor] [varchar](10) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_MSM_Display_Piece_Groups] PRIMARY KEY CLUSTERED 
(
	[IdDisplayPieceGroup] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [tracking].[MSM_Display_Piece_Groups]  WITH CHECK ADD  CONSTRAINT [FK_MSM_Display_Piece_Groups_MSM_Display_Piece_Groups] FOREIGN KEY([IdDisplayPieceGroupParent])
REFERENCES [tracking].[MSM_Display_Piece_Groups] ([IdDisplayPieceGroup])
GO

ALTER TABLE [tracking].[MSM_Display_Piece_Groups] CHECK CONSTRAINT [FK_MSM_Display_Piece_Groups_MSM_Display_Piece_Groups]
GO

ALTER TABLE [tracking].[MSM_Display_Piece_Groups] ADD  CONSTRAINT [DF_MSM_Display_Piece_Groups_Active]  DEFAULT ((1)) FOR [Active]
GO

