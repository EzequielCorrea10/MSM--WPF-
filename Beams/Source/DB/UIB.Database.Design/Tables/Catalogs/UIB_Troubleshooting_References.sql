CREATE TABLE [system].[MSM_Troubleshooting_References](
	[Reference] [varchar](100) NOT NULL,
	[Title] [varchar](250) NOT NULL,
	[Description] [varchar](MAX) NULL
 CONSTRAINT [PK_MSM_Troubleshooting_References] PRIMARY KEY CLUSTERED 
(
	[Reference] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
