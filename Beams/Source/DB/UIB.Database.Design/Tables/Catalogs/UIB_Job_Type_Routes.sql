CREATE TABLE [to].[HCM_Job_Type_Routes](
	[IdJobTypeRoute] [int] NOT NULL,
	[IdJobType] [int] NOT NULL,
	[IdYardOnlyApplicable] [int] NULL,
	[IdLocationGroupBegin] [int] NOT NULL,
	[IdLocationGroupEnd] [int] NOT NULL,
	[IdMachineType] [int] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_HCM_Job_Type_Routes] PRIMARY KEY CLUSTERED 
(
	[IdJobTypeRoute] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
 
CREATE UNIQUE NONCLUSTERED INDEX [IX_HCM_Job_Type_Routes] ON [to].[HCM_Job_Type_Routes]
(
	[IdJobType] ASC,
	[IdYardOnlyApplicable] ASC,
	[IdLocationGroupBegin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

ALTER TABLE [to].[HCM_Job_Type_Routes]  WITH CHECK ADD CONSTRAINT [FK_HCM_Job_Type_Routes_HCM_Job_Types] FOREIGN KEY([IdJobType]) REFERENCES [to].[HCM_Job_Types] ([IdJobType])

GO

ALTER TABLE [to].[HCM_Job_Type_Routes] CHECK CONSTRAINT [FK_HCM_Job_Type_Routes_HCM_Job_Types]

GO

ALTER TABLE [to].[HCM_Job_Type_Routes] WITH CHECK ADD  CONSTRAINT [FK_HCM_Job_Type_Routes_Rodeo_Yards] FOREIGN KEY([IdYardOnlyApplicable]) REFERENCES [common].[Rodeo_Yards] ([IdYard])
GO

ALTER TABLE [to].[HCM_Job_Type_Routes] CHECK CONSTRAINT [FK_HCM_Job_Type_Routes_Rodeo_Yards]
GO

ALTER TABLE [to].[HCM_Job_Type_Routes]  WITH CHECK ADD CONSTRAINT [FK_HCM_Job_Type_Routes_HCM_Location_Groups_Begin] FOREIGN KEY([IdLocationGroupBegin]) REFERENCES [common].[HCM_Location_Groups] ([IdLocationGroup])

GO

ALTER TABLE [to].[HCM_Job_Type_Routes] CHECK CONSTRAINT [FK_HCM_Job_Type_Routes_HCM_Location_Groups_Begin]

GO

ALTER TABLE [to].[HCM_Job_Type_Routes]  WITH CHECK ADD CONSTRAINT [FK_HCM_Job_Type_Routes_HCM_Location_Groups_End] FOREIGN KEY([IdLocationGroupEnd]) REFERENCES [common].[HCM_Location_Groups] ([IdLocationGroup])

GO

ALTER TABLE [to].[HCM_Job_Type_Routes] CHECK CONSTRAINT [FK_HCM_Job_Type_Routes_HCM_Location_Groups_End]

GO

ALTER TABLE [to].[HCM_Job_Type_Routes]  WITH CHECK ADD  CONSTRAINT [FK_HCM_Job_Type_Routes_Rodeo_Machine_Types] FOREIGN KEY([IdMachineType]) REFERENCES [common].[Rodeo_Machine_Types] ([IdMachineType])

GO

ALTER TABLE [to].[HCM_Job_Type_Routes] CHECK CONSTRAINT [FK_HCM_Job_Type_Routes_Rodeo_Machine_Types]

GO

ALTER TABLE [to].[HCM_Job_Type_Routes] ADD  CONSTRAINT [DF_HCM_Job_Type_Routes_Active]  DEFAULT ((1)) FOR [Active]

GO
