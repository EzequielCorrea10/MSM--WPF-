CREATE TABLE [common].[HB_Layout_Machines](
	[IdMachineLayout] [int] NOT NULL,
	[IdMachine] [int] NOT NULL,
	[IdLayoutSection] [int] NOT NULL,
	[Active] [bit] NOT NULL,
	[Order] [int] NULL,
 CONSTRAINT [PK_HB_Layout_Machines] PRIMARY KEY CLUSTERED 
(
	[IdMachineLayout] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [common].[HB_Layout_Machines] ADD  CONSTRAINT [DF_HB_Layout_Machine_Active]  DEFAULT ((1)) FOR [Active]
GO

ALTER TABLE [common].[HB_Layout_Machines]  WITH CHECK ADD  CONSTRAINT [FK_HB_Layout_Machines_HB_Layout_Sections] FOREIGN KEY([IdLayoutSection])
REFERENCES [common].[HB_Layout_Sections] ([IdLayoutSection])
GO

ALTER TABLE [common].[HB_Layout_Machines] CHECK CONSTRAINT [FK_HB_Layout_Machines_HB_Layout_Sections]
GO

ALTER TABLE [common].[HB_Layout_Machines]  WITH CHECK ADD  CONSTRAINT [FK_HB_Layout_Machines_Rodeo_Machines] FOREIGN KEY([IdMachine])
REFERENCES [common].[Rodeo_Machines] ([IdMachine])
GO

ALTER TABLE [common].[HB_Layout_Machines] CHECK CONSTRAINT [FK_HB_Layout_Machines_Rodeo_Machines]
GO
