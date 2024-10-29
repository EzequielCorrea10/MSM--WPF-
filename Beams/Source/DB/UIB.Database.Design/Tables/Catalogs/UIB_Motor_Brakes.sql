CREATE TABLE [common].[HCM_Motor_Brakes](
	[IdMotorBrakes] [int] NOT NULL,
	[IdMotorType] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[Tagname] [varchar](70) NOT NULL,
	[Unit] VARCHAR(20) NULL,
	[Order] [smallint] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_HCM_Motor_Brakes] PRIMARY KEY CLUSTERED
(
	[IdMotorBrakes] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_HCM_Motor_Brakes_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC,
	[IdMotorType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [common].[HCM_Motor_Brakes]  WITH CHECK ADD CONSTRAINT [FK_HCM_Motor_Brakes_HCM_Motor_Types] FOREIGN KEY([IdMotorType]) REFERENCES [common].[HCM_Motor_Types] ([IdMotorType])

GO

ALTER TABLE [common].[HCM_Motor_Brakes] CHECK CONSTRAINT [FK_HCM_Motor_Brakes_HCM_Motor_Types]

GO

ALTER TABLE [common].[HCM_Motor_Brakes] ADD  CONSTRAINT [DF_HCM_Motor_Brakes_Active]  DEFAULT ((1)) FOR [Active]
GO