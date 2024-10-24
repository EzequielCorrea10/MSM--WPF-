CREATE TABLE [system].[MSM_Setting_Values](
	[Tagname] [varchar](100) NOT NULL,
	[Value] [float] NOT NULL,
	[InsDateTime] [datetimeoffset](7) NOT NULL,
	[UpdDateTime] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_MSM_Setting_Values] PRIMARY KEY CLUSTERED 
(
	[Tagname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PROCESS]
) ON [PROCESS]

GO

ALTER TABLE [system].[MSM_Setting_Values] ADD  CONSTRAINT [DF_MSM_Setting_Values_InsDateTime]  DEFAULT (sysdatetimeoffset()) FOR [InsDateTime]

GO

ALTER TABLE [system].[MSM_Setting_Values] ADD  CONSTRAINT [DF_MSM_Setting_Values_UpdDateTime]  DEFAULT (sysdatetimeoffset()) FOR [UpdDateTime]

