CREATE TABLE [tracking].[Rodeo_Piece_Alloys](
	[IdPieceAlloy] [int] NOT NULL,
	[IdPieceAlloyFamily] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[PlcValue] [int] NOT NULL,
	[L3Value] [varchar] (20) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Rodeo_Piece_Alloys] PRIMARY KEY CLUSTERED 
(
	[IdPieceAlloy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Rodeo_Piece_Alloys_PlcValue] UNIQUE NONCLUSTERED 
(
	[PlcValue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [tracking].[Rodeo_Piece_Alloys]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_Piece_Alloys_Rodeo_Piece_Alloy_Families] FOREIGN KEY([IdPieceAlloyFamily]) REFERENCES [tracking].[Rodeo_Piece_Alloy_Families] ([IdPieceAlloyFamily])
GO

ALTER TABLE [tracking].[Rodeo_Piece_Alloys] CHECK CONSTRAINT [FK_Rodeo_Piece_Alloys_Rodeo_Piece_Alloy_Families]
GO
