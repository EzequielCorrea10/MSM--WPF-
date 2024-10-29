CREATE TABLE [to].[HSM_Job_Yard_Transfer_Steps](
	[IdJobYardTransferStep] [int] NOT NULL,
	[IsYardBeginOnFinalDestination] [bit] NOT NULL,
	[IsYardEndOnFinalDestination] [bit] NOT NULL,
	[IdLocationGroupBegin] [int] NOT NULL,
	[IdLocationGroupEnd] [int] NOT NULL,
	[IdMachineType] [int] NOT NULL,
	[IdYardBeginOnlyApplicable] [int] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_HSM_Job_Yard_Transfer_Steps] PRIMARY KEY CLUSTERED 
(
	[IdJobYardTransferStep] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
 
CREATE UNIQUE NONCLUSTERED INDEX [IX_HSM_Job_Yard_Transfer_Steps] ON [to].[HSM_Job_Yard_Transfer_Steps]
(
	[IsYardBeginOnFinalDestination] ASC,
	[IdLocationGroupBegin] ASC,
	[IdYardBeginOnlyApplicable] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

ALTER TABLE [to].[HSM_Job_Yard_Transfer_Steps]  WITH CHECK ADD CONSTRAINT [FK_HSM_Job_Yard_Transfer_Steps_HSM_Location_Groups_Begin] FOREIGN KEY([IdLocationGroupBegin]) REFERENCES [common].[HSM_Location_Groups] ([IdLocationGroup])

GO

ALTER TABLE [to].[HSM_Job_Yard_Transfer_Steps] CHECK CONSTRAINT [FK_HSM_Job_Yard_Transfer_Steps_HSM_Location_Groups_Begin]

GO

ALTER TABLE [to].[HSM_Job_Yard_Transfer_Steps]  WITH CHECK ADD CONSTRAINT [FK_HSM_Job_Yard_Transfer_Steps_HSM_Location_Groups_End] FOREIGN KEY([IdLocationGroupEnd]) REFERENCES [common].[HSM_Location_Groups] ([IdLocationGroup])

GO

ALTER TABLE [to].[HSM_Job_Yard_Transfer_Steps] CHECK CONSTRAINT [FK_HSM_Job_Yard_Transfer_Steps_HSM_Location_Groups_End]

GO

ALTER TABLE [to].[HSM_Job_Yard_Transfer_Steps]  WITH CHECK ADD  CONSTRAINT [FK_HSM_Job_Yard_Transfer_Steps_Rodeo_Machine_Types] FOREIGN KEY([IdMachineType]) REFERENCES [common].[Rodeo_Machine_Types] ([IdMachineType])

GO

ALTER TABLE [to].[HSM_Job_Yard_Transfer_Steps] CHECK CONSTRAINT [FK_HSM_Job_Yard_Transfer_Steps_Rodeo_Machine_Types]

GO

ALTER TABLE [to].[HSM_Job_Yard_Transfer_Steps] WITH CHECK ADD  CONSTRAINT [FK_HSM_Job_Yard_Transfer_Steps_Rodeo_Yards] FOREIGN KEY([IdYardBeginOnlyApplicable]) REFERENCES [common].[Rodeo_Yards] ([IdYard])

GO

ALTER TABLE [to].[HSM_Job_Yard_Transfer_Steps] CHECK CONSTRAINT [FK_HSM_Job_Yard_Transfer_Steps_Rodeo_Yards]

GO

ALTER TABLE [to].[HSM_Job_Yard_Transfer_Steps] ADD  CONSTRAINT [DF_HSM_Job_Yard_Transfer_Steps_Active]  DEFAULT ((1)) FOR [Active]

GO
