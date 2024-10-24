CREATE TABLE [common].[MSM_Brake_Process](
	[IdBrakeProcess] [int] NOT NULL,
	[IdBrakeType] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[Tagname] [varchar](70) NOT NULL,
	[Unit] VARCHAR(20) NULL,
	[Order] [smallint] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_MSM_Brake_Process] PRIMARY KEY CLUSTERED
(
	[IdBrakeProcess] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_MSM_Brake_Process_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC,
	[IdBrakeType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [common].[MSM_Brake_Process]  WITH CHECK ADD CONSTRAINT [FK_MSM_Brake_Process_MSM_Brake_Types] FOREIGN KEY([IdBrakeType]) REFERENCES [common].[MSM_Brake_Types] ([IdBrakeType])

GO

ALTER TABLE [common].[MSM_Brake_Process] CHECK CONSTRAINT [FK_MSM_Brake_Process_MSM_Brake_Types]

GO

ALTER TABLE [common].[MSM_Brake_Process] ADD  CONSTRAINT [DF_MSM_Brake_Process_Active]  DEFAULT ((1)) FOR [Active]
GO