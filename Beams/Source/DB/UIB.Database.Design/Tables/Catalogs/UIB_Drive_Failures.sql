CREATE TABLE [common].[HCM_Drive_Failures](
	[IdDriveFailure] [int] NOT NULL,
	[IdDriveType] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[Tagname] [varchar](70) NULL,
	[Bit] [int] NULL,
	[PlcValue] [int] NULL,
	[Alarmname] [varchar](70) NULL,
	[TroubleshootingReference] [varchar](100) NULL,
	[Order] [smallint] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_HCM_Drive_Failures] PRIMARY KEY CLUSTERED
(
	[IdDriveFailure] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_HCM_Drive_Failures_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC,
	[IdDriveType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [common].[HCM_Drive_Failures]  WITH CHECK ADD CONSTRAINT [FK_HCM_Drive_Failures_HCM_Drive_Types] FOREIGN KEY([IdDriveType]) REFERENCES [common].[HCM_Drive_Types] ([IdDriveType])

GO

ALTER TABLE [common].[HCM_Drive_Failures] CHECK CONSTRAINT [FK_HCM_Drive_Failures_HCM_Drive_Types]

GO

ALTER TABLE [common].[HCM_Drive_Failures] ADD  CONSTRAINT [DF_HCM_Drive_Failures_Active]  DEFAULT ((1)) FOR [Active]
GO