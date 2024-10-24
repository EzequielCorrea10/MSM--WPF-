CREATE TABLE [system].[Rodeo_Setting_Group_Machine_Types](
	[IdSettingGroup] [int] NOT NULL,
	[IdMachineType] [int] NOT NULL,
	[Order] [smallint] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Rodeo_Setting_Group_Machine_Types] PRIMARY KEY CLUSTERED 
(
	[IdSettingGroup] ASC,
	[IdMachineType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Rodeo_Setting_Group_Machine_Types] UNIQUE NONCLUSTERED 
(
	[IdSettingGroup] ASC,
	[Order] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [system].[Rodeo_Setting_Group_Machine_Types]  WITH CHECK ADD CONSTRAINT [FK_Rodeo_Setting_Group_Machine_Types_Rodeo_Setting_Groups] FOREIGN KEY([IdSettingGroup]) REFERENCES [system].[Rodeo_Setting_Groups] ([IdSettingGroup])

GO

ALTER TABLE [system].[Rodeo_Setting_Group_Machine_Types] CHECK CONSTRAINT [FK_Rodeo_Setting_Group_Machine_Types_Rodeo_Setting_Groups]

GO

ALTER TABLE [system].[Rodeo_Setting_Group_Machine_Types]  WITH CHECK ADD CONSTRAINT [FK_Rodeo_Setting_Group_Machine_Types_Rodeo_Machine_Types] FOREIGN KEY([IdMachineType]) REFERENCES [common].[Rodeo_Machine_Types] ([IdMachineType])

GO

ALTER TABLE [system].[Rodeo_Setting_Group_Machine_Types] CHECK CONSTRAINT [FK_Rodeo_Setting_Group_Machine_Types_Rodeo_Machine_Types]

GO

ALTER TABLE [system].[Rodeo_Setting_Group_Machine_Types] ADD  CONSTRAINT [DF_Rodeo_Setting_Group_Machine_Types_Active]  DEFAULT ((1)) FOR [Active]
