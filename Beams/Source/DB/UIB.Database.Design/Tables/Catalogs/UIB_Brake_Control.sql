CREATE TABLE [common].[HSM_Brake_Control](
	[IdBrakeControl] [int] NOT NULL,
	[IdBrakeType] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[Tagname] [varchar](70) NOT NULL,
	[Bit] [int] NULL,
	[PlcValue] [int] NOT NULL,
	[AlertLevel] [tinyint] NOT NULL DEFAULT 0, -- 0 = Green, 1 = Yellow, 2 = Red
	[Order] [smallint] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_HSM_Brake_Control] PRIMARY KEY CLUSTERED
(
	[IdBrakeControl] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_HSM_Brake_Control_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC,
	[IdBrakeType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [common].[HSM_Brake_Control]  WITH CHECK ADD CONSTRAINT [FK_HSM_Brake_Control_HSM_Brake_Types] FOREIGN KEY([IdBrakeType]) REFERENCES [common].[HSM_Brake_Types] ([IdBrakeType])

GO

ALTER TABLE [common].[HSM_Brake_Control] CHECK CONSTRAINT [FK_HSM_Brake_Control_HSM_Brake_Types]

GO

ALTER TABLE [common].[HSM_Brake_Control] ADD  CONSTRAINT [DF_HSM_Brake_Control_Active]  DEFAULT ((1)) FOR [Active]
GO