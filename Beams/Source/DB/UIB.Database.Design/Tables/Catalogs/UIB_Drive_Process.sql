CREATE TABLE [common].[HCM_Drive_Process](
	[IdDriveProcess] [int] NOT NULL,
	[IdDriveType] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[Tagname] [varchar](70) NOT NULL,
	[Unit] VARCHAR(20) NULL,
	[Order] [smallint] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_HCM_Drive_Process] PRIMARY KEY CLUSTERED
(
	[IdDriveProcess] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_HCM_Drive_Process_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC,
	[IdDriveType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [common].[HCM_Drive_Process]  WITH CHECK ADD CONSTRAINT [FK_HCM_Drive_Process_HCM_Drive_Types] FOREIGN KEY([IdDriveType]) REFERENCES [common].[HCM_Drive_Types] ([IdDriveType])

GO

ALTER TABLE [common].[HCM_Drive_Process] CHECK CONSTRAINT [FK_HCM_Drive_Process_HCM_Drive_Types]

GO

ALTER TABLE [common].[HCM_Drive_Process] ADD  CONSTRAINT [DF_HCM_Drive_Process_Active]  DEFAULT ((1)) FOR [Active]
GO