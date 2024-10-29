CREATE TABLE [safety].[HSM_Machine_Failures](
	[IdMachineFailure] [int] NOT NULL,
	[ParentIdMachineFailure] [int] NULL,
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
	[Alarmname] [varchar](70) NULL,
	[TextSizeDisplayed] [smallint] NOT NULL DEFAULT 1,
	[TroubleshootingReference] [varchar](100) NULL,
	[Order] [smallint] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_HSM_Machine_Failures] PRIMARY KEY CLUSTERED
(
	[IdMachineFailure] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_HSM_Machine_Failures] UNIQUE NONCLUSTERED 
(
	[ParentIdMachineFailure] ASC,
	[IdMachineType] ASC,
	[Order] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [safety].[HSM_Machine_Failures] WITH CHECK ADD  CONSTRAINT [FK_HSM_Machine_Failures_HSM_Machine_Failures] FOREIGN KEY([ParentIdMachineFailure]) REFERENCES [safety].[HSM_Machine_Failures] ([IdMachineFailure])
GO

ALTER TABLE [safety].[HSM_Machine_Failures] CHECK CONSTRAINT [FK_HSM_Machine_Failures_HSM_Machine_Failures]
GO

ALTER TABLE [safety].[HSM_Machine_Failures] WITH CHECK ADD  CONSTRAINT [FK_HSM_Machine_Failures_Rodeo_Machine_Types] FOREIGN KEY([IdMachineType]) REFERENCES [common].[Rodeo_Machine_Types] ([IdMachineType])
GO

ALTER TABLE [safety].[HSM_Machine_Failures] CHECK CONSTRAINT [FK_HSM_Machine_Failures_Rodeo_Machine_Types]
GO

ALTER TABLE [safety].[HSM_Machine_Failures] WITH CHECK ADD  CONSTRAINT [FK_HSM_Machine_Failures_Rodeo_Machines] FOREIGN KEY([IdMachine]) REFERENCES [common].[Rodeo_Machines] ([IdMachine])
GO

ALTER TABLE [safety].[HSM_Machine_Failures] CHECK CONSTRAINT [FK_HSM_Machine_Failures_Rodeo_Machines]
GO

ALTER TABLE [safety].[HSM_Machine_Failures] ADD CONSTRAINT [DF_HSM_Machine_Failures_Active]  DEFAULT ((1)) FOR [Active]
GO
