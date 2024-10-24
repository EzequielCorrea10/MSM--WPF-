CREATE TABLE [safety].[MSM_Machine_Interfaces](
	[IdMachineInterface] [int] NOT NULL,
	[ParentIdMachineInterface] [int] NULL,
	[IdMachineType] [int] NOT NULL,
	[IdMachine] [int] NULL,
	[GroupName] VARCHAR(250) NOT NULL,
	[Title] VARCHAR(250) NOT NULL,
	[Tagname] VARCHAR(70) NULL,
	[Bit] [int] NULL,
	[PlcValue] [int] NULL,
	[Alarmname] [varchar](70) NULL,
	[IsString] [bit] NOT NULL, -- Tag should be read with GetText
	[Unit] VARCHAR(20) NULL,
	[TextSizeDisplayed] [smallint] NOT NULL DEFAULT 1,
	[TroubleshootingReference] [varchar](100) NULL,
	[Order] [smallint] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_MSM_Machine_Interfaces] PRIMARY KEY CLUSTERED
(
	[IdMachineInterface] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_MSM_Machine_Interfaces] UNIQUE NONCLUSTERED 
(
	[ParentIdMachineInterface] ASC,
	[IdMachineType] ASC,
	[IdMachine] ASC,
	[Order] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [safety].[MSM_Machine_Interfaces]  WITH CHECK ADD  CONSTRAINT [FK_MSM_Machine_Interfaces_MSM_Machine_Interfaces] FOREIGN KEY([ParentIdMachineInterface]) REFERENCES [safety].[MSM_Machine_Interfaces] ([IdMachineInterface])
GO

ALTER TABLE [safety].[MSM_Machine_Interfaces] CHECK CONSTRAINT [FK_MSM_Machine_Interfaces_MSM_Machine_Interfaces]
GO

ALTER TABLE [safety].[MSM_Machine_Interfaces] ADD  CONSTRAINT [DF_MSM_Machine_Interfaces_Active]  DEFAULT ((1)) FOR [Active]
GO

ALTER TABLE [safety].[MSM_Machine_Interfaces] WITH CHECK ADD  CONSTRAINT [FK_MSM_Machine_Interfaces_Rodeo_Machine_Types] FOREIGN KEY([IdMachineType]) REFERENCES [common].[Rodeo_Machine_Types] ([IdMachineType])
GO

ALTER TABLE [safety].[MSM_Machine_Interfaces] CHECK CONSTRAINT [FK_MSM_Machine_Interfaces_Rodeo_Machine_Types]
GO

ALTER TABLE [safety].[MSM_Machine_Interfaces]  WITH CHECK ADD  CONSTRAINT [FK_MSM_Machine_Interfaces_Rodeo_Machines] FOREIGN KEY([IdMachine]) REFERENCES [common].[Rodeo_Machines] ([IdMachine])
GO

ALTER TABLE [safety].[MSM_Machine_Interfaces] CHECK CONSTRAINT [FK_MSM_Machine_Interfaces_Rodeo_Machines]
GO