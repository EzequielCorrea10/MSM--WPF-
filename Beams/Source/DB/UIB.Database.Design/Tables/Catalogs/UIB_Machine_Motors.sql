CREATE TABLE [common].[MSM_Machine_Motors](
	[IdMachineMotor] [int] NOT NULL,
	[IdMotorType] [int] NOT NULL,
	[IdMachine] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[Alias] [varchar](20) NOT NULL,
	[SelectionTagname] [varchar](70) NULL,
	[SelectionBit] [int] NULL,
	[SelectionPlcValue] [int] NULL,
	[Order] [smallint] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_MSM_Machine_Motors] PRIMARY KEY CLUSTERED
(
	[IdMachineMotor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_MSM_Machine_Motors_Name] UNIQUE NONCLUSTERED 
(
	[IdMachine] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [common].[MSM_Machine_Motors]  WITH CHECK ADD CONSTRAINT [FK_MSM_Machine_Motors_MSM_Motor_Types] FOREIGN KEY([IdMotorType]) REFERENCES [common].[MSM_Motor_Types] ([IdMotorType])

GO

ALTER TABLE [common].[MSM_Machine_Motors] CHECK CONSTRAINT [FK_MSM_Machine_Motors_MSM_Motor_Types]

GO

ALTER TABLE [common].[MSM_Machine_Motors]  WITH CHECK ADD CONSTRAINT [FK_MSM_Machine_Motors_Rodeo_Machines] FOREIGN KEY([IdMachine]) REFERENCES [common].[Rodeo_Machines] ([IdMachine])

GO

ALTER TABLE [common].[MSM_Machine_Motors] CHECK CONSTRAINT [FK_MSM_Machine_Motors_Rodeo_Machines]

GO

ALTER TABLE [common].[MSM_Machine_Motors] ADD  CONSTRAINT [DF_MSM_Machine_Motors_Active]  DEFAULT ((1)) FOR [Active]
GO