CREATE TABLE [to].[Rodeo_TO_ErrorCodes](
	[IdTOErrorCode] [int] NOT NULL,
	[IdMachineType] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[PlcValue] [int] NOT NULL,
	[IsError] [bit] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Rodeo_TO_ErrorCodes] PRIMARY KEY CLUSTERED 
(
	[IdTOErrorCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Rodeo_TO_ErrorCodes_PlcValue] UNIQUE NONCLUSTERED 
(
	[IdMachineType] ASC,
	[PlcValue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO 

CREATE UNIQUE NONCLUSTERED INDEX [IX_Rodeo_TO_ErrorCodes_Name] ON [to].[Rodeo_TO_ErrorCodes]
(
	[IdMachineType] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

ALTER TABLE [to].[Rodeo_TO_ErrorCodes]  WITH CHECK ADD CONSTRAINT [FK_Rodeo_TO_ErrorCodes_Rodeo_Machine_Types] FOREIGN KEY([IdMachineType]) REFERENCES [common].[Rodeo_Machine_Types] ([IdMachineType])

GO

ALTER TABLE [to].[Rodeo_TO_ErrorCodes] CHECK CONSTRAINT [FK_Rodeo_TO_ErrorCodes_Rodeo_Machine_Types]

GO

ALTER TABLE [to].[Rodeo_TO_ErrorCodes] ADD  CONSTRAINT [DF_Rodeo_TO_ErrorCodes_Active]  DEFAULT ((1)) FOR [Active]
