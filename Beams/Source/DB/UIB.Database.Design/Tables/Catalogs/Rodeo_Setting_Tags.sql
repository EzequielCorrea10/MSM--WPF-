CREATE TABLE [system].[Rodeo_Setting_Tags](
	[IdSettingTag] [int] NOT NULL,
	[IdSettingGroup] [int] NOT NULL,
	[IdMachineType] [int] NULL,
	[IdMachine] [int] NULL,
	[Tagname] [varchar](70) NOT NULL,
	[OnlyWriteAll] [bit] NOT NULL,
	[WriteAllTagname] [varchar](70) NULL,
	[Order] [smallint] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Rodeo_Setting_Tags] PRIMARY KEY CLUSTERED 
(
	[IdSettingTag] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Rodeo_Setting_Tags] UNIQUE NONCLUSTERED 
(
	[IdSettingGroup] ASC,
	[IdMachineType] ASC,
	[Order] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_Rodeo_Setting_Tags_Tagname] ON [system].[Rodeo_Setting_Tags]
(
	[Tagname] ASC,
	[IdMachineType] ASC,
	[IdMachine] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO 

ALTER TABLE [system].[Rodeo_Setting_Tags]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_Setting_Tags_Rodeo_Setting_Groups] FOREIGN KEY([IdSettingGroup]) REFERENCES [system].[Rodeo_Setting_Groups] ([IdSettingGroup])

GO

ALTER TABLE [system].[Rodeo_Setting_Tags] CHECK CONSTRAINT [FK_Rodeo_Setting_Tags_Rodeo_Setting_Groups]

GO

ALTER TABLE [system].[Rodeo_Setting_Tags] WITH CHECK ADD  CONSTRAINT [FK_Rodeo_Setting_Tags_Rodeo_Machine_Types] FOREIGN KEY([IdMachineType]) REFERENCES [common].[Rodeo_Machine_Types] ([IdMachineType])
GO

ALTER TABLE [system].[Rodeo_Setting_Tags] CHECK CONSTRAINT [FK_Rodeo_Setting_Tags_Rodeo_Machine_Types]
GO

ALTER TABLE [system].[Rodeo_Setting_Tags] WITH CHECK ADD  CONSTRAINT [FK_Rodeo_Setting_Tags_Rodeo_Machines] FOREIGN KEY([IdMachine]) REFERENCES [common].[Rodeo_Machines] ([IdMachine])
GO

ALTER TABLE [system].[Rodeo_Setting_Tags] CHECK CONSTRAINT [FK_Rodeo_Setting_Tags_Rodeo_Machines]
GO

ALTER TABLE [system].[Rodeo_Setting_Tags] ADD  CONSTRAINT [DF_Rodeo_Setting_Tags_Active]  DEFAULT ((1)) FOR [Active]
