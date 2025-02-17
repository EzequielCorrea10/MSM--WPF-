﻿CREATE TABLE [tracking].[Rodeo_Piece_Types](
	[IdPieceType] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Rodeo_Piece_Types] PRIMARY KEY CLUSTERED 
(
	[IdPieceType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [tracking].[Rodeo_Piece_Types] ADD  CONSTRAINT [DF_Rodeo_Piece_Types_Active]  DEFAULT ((1)) FOR [Active]
GO

