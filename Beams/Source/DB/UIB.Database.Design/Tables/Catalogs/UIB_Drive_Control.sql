CREATE TABLE [common].[MSM_Drive_Control](
	[IdDriveControl] [int] NOT NULL,
	[IdDriveType] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[Tagname] [varchar](70) NOT NULL,
	[Bit] [int] NULL,
	[PlcValue] [int] NOT NULL,
	[AlertLevel] [tinyint] NOT NULL DEFAULT 0, -- 0 = Green, 1 = Yellow, 2 = Red
	[Order] [smallint] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_MSM_Drive_Control] PRIMARY KEY CLUSTERED
(
	[IdDriveControl] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_MSM_Drive_Control_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC,
	[IdDriveType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [common].[MSM_Drive_Control]  WITH CHECK ADD CONSTRAINT [FK_MSM_Drive_Control_MSM_Drive_Types] FOREIGN KEY([IdDriveType]) REFERENCES [common].[MSM_Drive_Types] ([IdDriveType])

GO

ALTER TABLE [common].[MSM_Drive_Control] CHECK CONSTRAINT [FK_MSM_Drive_Control_MSM_Drive_Types]

GO

ALTER TABLE [common].[MSM_Drive_Control] ADD  CONSTRAINT [DF_MSM_Drive_Control_Active]  DEFAULT ((1)) FOR [Active]
GO