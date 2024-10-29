CREATE TABLE [to].[HCM_Job_Types](
	[IdJobType] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[Priority] [smallint] NOT NULL,
	[IdLocationGroupBeginDefault] [int] NOT NULL,
	[IdLocationGroupEndDefault] [int] NOT NULL,
	[PlcValue] [int] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_HCM_Job_Types] PRIMARY KEY CLUSTERED 
(
	[IdJobType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_HCM_Job_Types_PlcValue] UNIQUE NONCLUSTERED 
(
	[PlcValue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO 

CREATE UNIQUE NONCLUSTERED INDEX [IX_HCM_Job_Types_Name] ON [to].[HCM_Job_Types]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

ALTER TABLE [to].[HCM_Job_Types]  WITH CHECK ADD CONSTRAINT [FK_HCM_Job_Types_HCM_Location_Groups_Begin] FOREIGN KEY([IdLocationGroupBeginDefault]) REFERENCES [common].[HCM_Location_Groups] ([IdLocationGroup])

GO

ALTER TABLE [to].[HCM_Job_Types] CHECK CONSTRAINT [FK_HCM_Job_Types_HCM_Location_Groups_Begin]

GO

ALTER TABLE [to].[HCM_Job_Types]  WITH CHECK ADD CONSTRAINT [FK_HCM_Job_Types_HCM_Location_Groups_End] FOREIGN KEY([IdLocationGroupEndDefault]) REFERENCES [common].[HCM_Location_Groups] ([IdLocationGroup])

GO

ALTER TABLE [to].[HCM_Job_Types] CHECK CONSTRAINT [FK_HCM_Job_Types_HCM_Location_Groups_End]

GO

ALTER TABLE [to].[HCM_Job_Types] ADD  CONSTRAINT [DF_HCM_Job_Types_Active]  DEFAULT ((1)) FOR [Active]
