CREATE TABLE [common].[Rodeo_Machine_Statuses](
	[IdMachineStatus] [int] NOT NULL,
	[IdMachineType] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[PlcValue] [int] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Rodeo_Machine_Statuses] PRIMARY KEY CLUSTERED 
(
	[IdMachineStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Rodeo_Machine_Statuses_PlcValue] UNIQUE NONCLUSTERED 
(
	[IdMachineType] ASC,
	[PlcValue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [common].[Rodeo_Machine_Statuses] ADD  CONSTRAINT [DF_Rodeo_Machine_Statuses_Active]  DEFAULT ((1)) FOR [Active]
GO

ALTER TABLE [common].[Rodeo_Machine_Statuses]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_Machine_Statuses_Rodeo_Machine_Types] FOREIGN KEY([IdMachineType])
REFERENCES [common].[Rodeo_Machine_Types] ([IdMachineType])
GO

ALTER TABLE [common].[Rodeo_Machine_Statuses] CHECK CONSTRAINT [FK_Rodeo_Machine_Statuses_Rodeo_Machine_Types]
GO