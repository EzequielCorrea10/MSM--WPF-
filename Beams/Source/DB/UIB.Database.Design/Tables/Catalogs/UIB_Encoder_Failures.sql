CREATE TABLE [common].[HCM_Encoder_Failures](
	[IdEncoderFailure] [int] NOT NULL,
	[IdEncoderType] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[Tagname] [varchar](70) NULL,
	[Bit] [int] NULL,
	[PlcValue] [int] NULL,
	[Alarmname] [varchar](70) NULL,
	[TroubleshootingReference] [varchar](100) NULL,
	[Order] [smallint] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_HCM_Encoder_Failures] PRIMARY KEY CLUSTERED
(
	[IdEncoderFailure] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_HCM_Encoder_Failures_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC,
	[IdEncoderType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [common].[HCM_Encoder_Failures]  WITH CHECK ADD CONSTRAINT [FK_HCM_Encoder_Failures_HCM_Encoder_Types] FOREIGN KEY([IdEncoderType]) REFERENCES [common].[HCM_Encoder_Types] ([IdEncoderType])

GO

ALTER TABLE [common].[HCM_Encoder_Failures] CHECK CONSTRAINT [FK_HCM_Encoder_Failures_HCM_Encoder_Types]

GO

ALTER TABLE [common].[HCM_Encoder_Failures] ADD  CONSTRAINT [DF_HCM_Encoder_Failures_Active]  DEFAULT ((1)) FOR [Active]
GO