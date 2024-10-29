CREATE TABLE [common].[HSM_Encoder_Process](
	[IdEncoderProcess] [int] NOT NULL,
	[IdEncoderType] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[Tagname] [varchar](70) NOT NULL,
	[Unit] VARCHAR(20) NULL,
	[Order] [smallint] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_HSM_Encoder_Process] PRIMARY KEY CLUSTERED
(
	[IdEncoderProcess] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_HSM_Encoder_Process_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC,
	[IdEncoderType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [common].[HSM_Encoder_Process]  WITH CHECK ADD CONSTRAINT [FK_HSM_Encoder_Process_HSM_Encoder_Types] FOREIGN KEY([IdEncoderType]) REFERENCES [common].[HSM_Encoder_Types] ([IdEncoderType])

GO

ALTER TABLE [common].[HSM_Encoder_Process] CHECK CONSTRAINT [FK_HSM_Encoder_Process_HSM_Encoder_Types]

GO

ALTER TABLE [common].[HSM_Encoder_Process] ADD  CONSTRAINT [DF_HSM_Encoder_Process_Active]  DEFAULT ((1)) FOR [Active]
GO