CREATE TABLE [common].[HCM_Machine_Brakes](
	[IdMachineBrake] [int] NOT NULL,
	[IdBrakeType] [int] NOT NULL,
	[IdMachine] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[Alias] [varchar](20) NOT NULL,
	[SelectionTagname] [varchar](70) NULL,
	[SelectionBit] [int] NULL,
	[SelectionPlcValue] [int] NULL,
	[Order] [smallint] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_HCM_Machine_Brakes] PRIMARY KEY CLUSTERED
(
	[IdMachineBrake] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_HCM_Machine_Brakes_Name] UNIQUE NONCLUSTERED 
(
	[IdMachine] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [common].[HCM_Machine_Brakes]  WITH CHECK ADD CONSTRAINT [FK_HCM_Machine_Brakes_HCM_Brake_Types] FOREIGN KEY([IdBrakeType]) REFERENCES [common].[HCM_Brake_Types] ([IdBrakeType])

GO

ALTER TABLE [common].[HCM_Machine_Brakes] CHECK CONSTRAINT [FK_HCM_Machine_Brakes_HCM_Brake_Types]

GO

ALTER TABLE [common].[HCM_Machine_Brakes]  WITH CHECK ADD CONSTRAINT [FK_HCM_Machine_Brakes_Rodeo_Machines] FOREIGN KEY([IdMachine]) REFERENCES [common].[Rodeo_Machines] ([IdMachine])

GO

ALTER TABLE [common].[HCM_Machine_Brakes] CHECK CONSTRAINT [FK_HCM_Machine_Brakes_Rodeo_Machines]

GO

ALTER TABLE [common].[HCM_Machine_Brakes] ADD  CONSTRAINT [DF_HCM_Machine_Brakes_Active]  DEFAULT ((1)) FOR [Active]
GO