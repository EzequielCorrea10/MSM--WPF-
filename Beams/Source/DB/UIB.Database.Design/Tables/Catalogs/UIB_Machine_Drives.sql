CREATE TABLE [common].[MSM_Machine_Drives](
	[IdMachineDrive] [int] NOT NULL,
	[IdDriveType] [int] NOT NULL,
	[IdMachine] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[Alias] [varchar](20) NOT NULL,
	[SelectionTagname] [varchar](70) NULL,
	[SelectionBit] [int] NULL,
	[SelectionPlcValue] [int] NULL,
	[Order] [smallint] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_MSM_Machine_Drives] PRIMARY KEY CLUSTERED
(
	[IdMachineDrive] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_MSM_Machine_Drives_Name] UNIQUE NONCLUSTERED 
(
	[IdMachine] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [common].[MSM_Machine_Drives]  WITH CHECK ADD CONSTRAINT [FK_MSM_Machine_Drives_MSM_Drive_Types] FOREIGN KEY([IdDriveType]) REFERENCES [common].[MSM_Drive_Types] ([IdDriveType])

GO

ALTER TABLE [common].[MSM_Machine_Drives] CHECK CONSTRAINT [FK_MSM_Machine_Drives_MSM_Drive_Types]

GO

ALTER TABLE [common].[MSM_Machine_Drives]  WITH CHECK ADD CONSTRAINT [FK_MSM_Machine_Drives_Rodeo_Machines] FOREIGN KEY([IdMachine]) REFERENCES [common].[Rodeo_Machines] ([IdMachine])

GO

ALTER TABLE [common].[MSM_Machine_Drives] CHECK CONSTRAINT [FK_MSM_Machine_Drives_Rodeo_Machines]

GO

ALTER TABLE [common].[MSM_Machine_Drives] ADD  CONSTRAINT [DF_MSM_Machine_Drives_Active]  DEFAULT ((1)) FOR [Active]
GO