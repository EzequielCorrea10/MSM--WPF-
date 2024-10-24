CREATE TABLE [common].[MSM_Motor_Gearboxs](
	[IdMotorGearboxs] [int] NOT NULL,
	[IdMotorType] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[Tagname] [varchar](70) NOT NULL,
	[Unit] VARCHAR(20) NULL,
	[Order] [smallint] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_MSM_Motor_Gearboxs] PRIMARY KEY CLUSTERED
(
	[IdMotorGearboxs] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_MSM_Motor_Gearboxs_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC,
	[IdMotorType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [common].[MSM_Motor_Gearboxs]  WITH CHECK ADD CONSTRAINT [FK_MSM_Motor_Gearboxs_MSM_Motor_Types] FOREIGN KEY([IdMotorType]) REFERENCES [common].[MSM_Motor_Types] ([IdMotorType])

GO

ALTER TABLE [common].[MSM_Motor_Gearboxs] CHECK CONSTRAINT [FK_MSM_Motor_Gearboxs_MSM_Motor_Types]

GO

ALTER TABLE [common].[MSM_Motor_Gearboxs] ADD  CONSTRAINT [DF_MSM_Motor_Gearboxs_Active]  DEFAULT ((1)) FOR [Active]
GO