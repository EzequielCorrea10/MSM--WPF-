CREATE TABLE [safety].[HCM_Machine_Interlocks](
	[IdMachineInterlock] [int] NOT NULL,
	[ParentIdMachineInterlock] [int] NULL,
	[IdMachineType] [int] NOT NULL,
	[IdMachine] [int] NULL,
	[Title] VARCHAR(250) NOT NULL,
	[Tagname] VARCHAR(70) NULL,
	[Bit] [int] NULL,
	[PlcValue] [int] NULL,
	[BridgeWorkModeAllowed] [int] NULL,
	[TrolleyWorkModeAllowed] [int] NULL,
	[HoistWorkModeAllowed] [int] NULL,
	[GrabWorkModeAllowed] [int] NULL,
	[TextSizeDisplayed] [smallint] NOT NULL DEFAULT 1,
	[TroubleshootingReference] [varchar](100) NULL,
	[Order] [smallint] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_HCM_Machine_Interlocks] PRIMARY KEY CLUSTERED
(
	[IdMachineInterlock] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_HCM_Machine_Interlocks] UNIQUE NONCLUSTERED 
(
	[ParentIdMachineInterlock] ASC,
	[IdMachineType] ASC,
	[Order] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [safety].[HCM_Machine_Interlocks]  WITH CHECK ADD  CONSTRAINT [FK_HCM_Machine_Interlocks_HCM_Machine_Interlocks] FOREIGN KEY([ParentIdMachineInterlock]) REFERENCES [safety].[HCM_Machine_Interlocks] ([IdMachineInterlock])
GO

ALTER TABLE [safety].[HCM_Machine_Interlocks] CHECK CONSTRAINT [FK_HCM_Machine_Interlocks_HCM_Machine_Interlocks]
GO

ALTER TABLE [safety].[HCM_Machine_Interlocks] ADD  CONSTRAINT [DF_HCM_Machine_Interlocks_Active]  DEFAULT ((1)) FOR [Active]

GO

ALTER TABLE [safety].[HCM_Machine_Interlocks] WITH CHECK ADD  CONSTRAINT [FK_HCM_Machine_Interlocks_Rodeo_Machine_Types] FOREIGN KEY([IdMachineType]) REFERENCES [common].[Rodeo_Machine_Types] ([IdMachineType])
GO

ALTER TABLE [safety].[HCM_Machine_Interlocks] CHECK CONSTRAINT [FK_HCM_Machine_Interlocks_Rodeo_Machine_Types]
GO

ALTER TABLE [safety].[HCM_Machine_Interlocks]  WITH CHECK ADD  CONSTRAINT [FK_HCM_Machine_Interlocks_Rodeo_Machines] FOREIGN KEY([IdMachine]) REFERENCES [common].[Rodeo_Machines] ([IdMachine])
GO

ALTER TABLE [safety].[HCM_Machine_Interlocks] CHECK CONSTRAINT [FK_HCM_Machine_Interlocks_Rodeo_Machines]
GO