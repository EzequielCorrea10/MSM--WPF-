CREATE TABLE [tracking].[HCM_Display_Piece_Group_Items](
	[IdDisplayPieceGroupItem] [int] NOT NULL,
	[IdDisplayPieceGroup] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[Position] [int] NOT NULL,
	[BackgroundColor] [varchar](10) NOT NULL,
	[ForegroundColor] [varchar](10) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_HCM_Display_Piece_Group_Items] PRIMARY KEY CLUSTERED 
(
	[IdDisplayPieceGroupItem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [tracking].[HCM_Display_Piece_Group_Items] WITH CHECK ADD CONSTRAINT [FK_HCM_Display_Piece_Group_Items_HCM_Display_Piece_Groups] FOREIGN KEY([IdDisplayPieceGroup]) REFERENCES [tracking].[HCM_Display_Piece_Groups] ([IdDisplayPieceGroup])

GO

ALTER TABLE [tracking].[HCM_Display_Piece_Group_Items] CHECK CONSTRAINT [FK_HCM_Display_Piece_Group_Items_HCM_Display_Piece_Groups]

GO

ALTER TABLE [tracking].[HCM_Display_Piece_Group_Items] ADD  CONSTRAINT [DF_HCM_Display_Piece_Group_Items_Active]  DEFAULT ((1)) FOR [Active]
