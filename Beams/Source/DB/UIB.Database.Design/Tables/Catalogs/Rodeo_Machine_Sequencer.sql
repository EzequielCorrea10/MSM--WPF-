CREATE TABLE [common].[Rodeo_Machine_Sequencer](
	[IdMachineSequencer] [int] NOT NULL,
	[IdMachineType] [int] NOT NULL,
	[Type] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Title] [varchar](250) NOT NULL,
	[PlcValue] [int] NOT NULL,
	[TextSizeDisplayed] [smallint] NOT NULL DEFAULT 1,
	[Order] [smallint] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Rodeo_Machine_Sequencer] PRIMARY KEY CLUSTERED
(
	[IdMachineSequencer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Rodeo_Machine_Sequencer_PlcValue] UNIQUE NONCLUSTERED 
(
	[Type] ASC,
	[IdMachineType] ASC,
	[PlcValue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [common].[Rodeo_Machine_Sequencer]  WITH CHECK ADD CONSTRAINT [FK_Rodeo_Machine_Sequencer_Rodeo_Machine_Types] FOREIGN KEY([IdMachineType]) REFERENCES [common].[Rodeo_Machine_Types] ([IdMachineType])

GO

ALTER TABLE [common].[Rodeo_Machine_Sequencer] CHECK CONSTRAINT [FK_Rodeo_Machine_Sequencer_Rodeo_Machine_Types]

GO

ALTER TABLE [common].[Rodeo_Machine_Sequencer] ADD  CONSTRAINT [DF_Rodeo_Machine_Sequencer_Active]  DEFAULT ((1)) FOR [Active]
