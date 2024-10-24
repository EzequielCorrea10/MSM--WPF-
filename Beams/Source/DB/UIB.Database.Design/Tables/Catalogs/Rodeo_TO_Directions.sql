CREATE TABLE [to].[Rodeo_TO_Directions]( --None, Forward, Reverse, Down, Up
	[IdTODirection] [int] NOT NULL,
	[IdMachineType] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[PlcValue] [int] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Rodeo_TO_Directions] PRIMARY KEY CLUSTERED 
(
	[IdTODirection] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Rodeo_TO_Directions_PlcValue] UNIQUE NONCLUSTERED 
(
	[IdMachineType] ASC,
	[PlcValue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO 

CREATE UNIQUE NONCLUSTERED INDEX [IX_Rodeo_TO_Directions_Name] ON [to].[Rodeo_TO_Directions]
(
	[IdMachineType] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

ALTER TABLE [to].[Rodeo_TO_Directions]  WITH CHECK ADD CONSTRAINT [FK_Rodeo_TO_Directions_Rodeo_Machine_Types] FOREIGN KEY([IdMachineType]) REFERENCES [common].[Rodeo_Machine_Types] ([IdMachineType])

GO

ALTER TABLE [to].[Rodeo_TO_Directions] CHECK CONSTRAINT [FK_Rodeo_TO_Directions_Rodeo_Machine_Types]

GO

ALTER TABLE [to].[Rodeo_TO_Directions] ADD  CONSTRAINT [DF_Rodeo_TO_Directions_Active]  DEFAULT ((1)) FOR [Active]
