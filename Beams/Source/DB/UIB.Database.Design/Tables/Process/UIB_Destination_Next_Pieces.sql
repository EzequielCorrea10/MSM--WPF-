
CREATE TABLE [to].[MSM_Destination_Next_Pieces](
	[L2Destination] [varchar](50) NOT NULL,
	[Sequence] [int] NOT NULL,
	[PieceName] [varchar](50) NOT NULL,
	[InsDateTime] [datetimeoffset](7) NOT NULL,
	[UpdDateTime] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_MSM_Destination_Next_Pieces] PRIMARY KEY CLUSTERED 
(
	[L2Destination] ASC,
	[Sequence] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PROCESS]
) ON [PROCESS]
GO

ALTER TABLE [to].[MSM_Destination_Next_Pieces] ADD  CONSTRAINT [DF_MSM_Destination_Next_Pieces_InsDateTime]  DEFAULT (sysdatetimeoffset()) FOR [InsDateTime]
GO

ALTER TABLE [to].[MSM_Destination_Next_Pieces] ADD  CONSTRAINT [DF_MSM_Destination_Next_Pieces_UpdDateTime]  DEFAULT (sysdatetimeoffset()) FOR [UpdDateTime]
GO
