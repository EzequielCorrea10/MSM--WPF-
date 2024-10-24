CREATE TABLE [system].[MSM_Troubleshooting_Files](
	[Reference] [varchar](100) NOT NULL,
	[LinkTitle] [varchar](250) NOT NULL,
	[LinkPDFFile] [varchar](100) NOT NULL,
	[PDFPage] int NULL,
	[Order] [smallint] NOT NULL
 CONSTRAINT [PK_MSM_Troubleshooting_Files] PRIMARY KEY CLUSTERED 
(
	[Reference] ASC,
	[Order] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [system].[MSM_Troubleshooting_Files]  WITH CHECK ADD CONSTRAINT [FK_MSM_Troubleshooting_Files_MSM_Troubleshooting_References] FOREIGN KEY([Reference]) REFERENCES [system].[MSM_Troubleshooting_References] ([Reference])

GO

ALTER TABLE [system].[MSM_Troubleshooting_Files] CHECK CONSTRAINT [FK_MSM_Troubleshooting_Files_MSM_Troubleshooting_References]
