CREATE TABLE [safety].[MSM_Zone_Fences](
	[IdFence] [int] NOT NULL,
	[X1Pos] [int] NOT NULL,
	[Y1Pos] [int] NOT NULL,
	[X2Pos] [int] NOT NULL,
	[Y2Pos] [int] NOT NULL,
	[ThicknessDrawn] [int] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_MSM_Zone_Fences] PRIMARY KEY CLUSTERED 
(
	[IdFence] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO 

ALTER TABLE [safety].[MSM_Zone_Fences] ADD  CONSTRAINT [DF_MSM_Zone_Fences_Active]  DEFAULT ((1)) FOR [Active]