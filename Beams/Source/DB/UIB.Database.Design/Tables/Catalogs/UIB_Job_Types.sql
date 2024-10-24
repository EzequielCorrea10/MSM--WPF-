CREATE TABLE [to].[MSM_Job_Types](
	[IdJobType] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[Priority] [smallint] NOT NULL,
	[IdLocationGroupBeginDefault] [int] NOT NULL,
	[IdLocationGroupEndDefault] [int] NOT NULL,
	[PlcValue] [int] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_MSM_Job_Types] PRIMARY KEY CLUSTERED 
(
	[IdJobType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_MSM_Job_Types_PlcValue] UNIQUE NONCLUSTERED 
(
	[PlcValue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO 

CREATE UNIQUE NONCLUSTERED INDEX [IX_MSM_Job_Types_Name] ON [to].[MSM_Job_Types]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

ALTER TABLE [to].[MSM_Job_Types]  WITH CHECK ADD CONSTRAINT [FK_MSM_Job_Types_MSM_Location_Groups_Begin] FOREIGN KEY([IdLocationGroupBeginDefault]) REFERENCES [common].[MSM_Location_Groups] ([IdLocationGroup])

GO

ALTER TABLE [to].[MSM_Job_Types] CHECK CONSTRAINT [FK_MSM_Job_Types_MSM_Location_Groups_Begin]

GO

ALTER TABLE [to].[MSM_Job_Types]  WITH CHECK ADD CONSTRAINT [FK_MSM_Job_Types_MSM_Location_Groups_End] FOREIGN KEY([IdLocationGroupEndDefault]) REFERENCES [common].[MSM_Location_Groups] ([IdLocationGroup])

GO

ALTER TABLE [to].[MSM_Job_Types] CHECK CONSTRAINT [FK_MSM_Job_Types_MSM_Location_Groups_End]

GO

ALTER TABLE [to].[MSM_Job_Types] ADD  CONSTRAINT [DF_MSM_Job_Types_Active]  DEFAULT ((1)) FOR [Active]
