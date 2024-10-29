CREATE TABLE [common].[HSM_Motor_Motors](
	[IdMotorMotors] [int] NOT NULL,
	[IdMotorType] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[Tagname] [varchar](70) NOT NULL,
	[Unit] VARCHAR(20) NULL,
	[Order] [smallint] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_HSM_Motor_Motors] PRIMARY KEY CLUSTERED
(
	[IdMotorMotors] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_HSM_Motor_Motors_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC,
	[IdMotorType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [common].[HSM_Motor_Motors]  WITH CHECK ADD CONSTRAINT [FK_HSM_Motor_Motors_HSM_Motor_Types] FOREIGN KEY([IdMotorType]) REFERENCES [common].[HSM_Motor_Types] ([IdMotorType])

GO

ALTER TABLE [common].[HSM_Motor_Motors] CHECK CONSTRAINT [FK_HSM_Motor_Motors_HSM_Motor_Types]

GO

ALTER TABLE [common].[HSM_Motor_Motors] ADD  CONSTRAINT [DF_HSM_Motor_Motors_Active]  DEFAULT ((1)) FOR [Active]
GO