CREATE TABLE [safety].[MSM_Ground_EStop_Panels](
	[IdGroundEStopPanel] [int] NOT NULL,
	[IdGroundEStopGroup] [int] NOT NULL,
	[Title] VARCHAR(250) NOT NULL,
	[Tagname] VARCHAR(70) NULL,
	[Bit] [int] NULL,
	[PlcValue] [int] NULL,
	[Alarmname] [varchar](70) NULL,
	[TextSizeDisplayed] [smallint] NOT NULL DEFAULT 1,
	[Order] [smallint] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_MSM_Ground_EStop_Panels] PRIMARY KEY CLUSTERED 
(
	[IdGroundEStopPanel] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_MSM_Ground_EStop_Panels] UNIQUE NONCLUSTERED 
(
	[IdGroundEStopGroup] ASC,
	[Order] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO 

ALTER TABLE [safety].[MSM_Ground_EStop_Panels] WITH CHECK ADD  CONSTRAINT [FK_MSM_Ground_EStop_Panels_MSM_Ground_EStop_Groups] FOREIGN KEY([IdGroundEStopGroup]) REFERENCES [safety].[MSM_Ground_EStop_Groups] ([IdGroundEStopGroup])
GO

ALTER TABLE [safety].[MSM_Ground_EStop_Panels] CHECK CONSTRAINT [FK_MSM_Ground_EStop_Panels_MSM_Ground_EStop_Groups]
GO

ALTER TABLE [safety].[MSM_Ground_EStop_Panels] ADD  CONSTRAINT [DF_MSM_Ground_EStop_Panels_Active]  DEFAULT ((1)) FOR [Active]
