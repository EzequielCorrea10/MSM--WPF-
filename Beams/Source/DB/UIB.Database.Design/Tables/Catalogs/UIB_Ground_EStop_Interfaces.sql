CREATE TABLE [safety].[HCM_Ground_EStop_Interfaces](
	[IdGroundEStopInterface] [int] NOT NULL,
	[IdGroundEStopGroup] [int] NOT NULL,
	[Title] VARCHAR(250) NOT NULL,
	[Tagname] VARCHAR(70) NULL,
	[Bit] [int] NULL,
	[PlcValue] [int] NULL,
	[Alarmname] [varchar](70) NULL,
	[TextSizeDisplayed] [smallint] NOT NULL DEFAULT 1,
	[Order] [smallint] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_HCM_Ground_EStop_Interfaces] PRIMARY KEY CLUSTERED 
(
	[IdGroundEStopInterface] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_HCM_Ground_EStop_Interfaces] UNIQUE NONCLUSTERED 
(
	[IdGroundEStopGroup] ASC,
	[Order] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO 

ALTER TABLE [safety].[HCM_Ground_EStop_Interfaces]  WITH CHECK ADD  CONSTRAINT [FK_HCM_Ground_EStop_Interfaces_HCM_Ground_EStop_Groups] FOREIGN KEY([IdGroundEStopGroup]) REFERENCES [safety].[HCM_Ground_EStop_Groups] ([IdGroundEStopGroup])
GO

ALTER TABLE [safety].[HCM_Ground_EStop_Interfaces] CHECK CONSTRAINT [FK_HCM_Ground_EStop_Interfaces_HCM_Ground_EStop_Groups]
GO

ALTER TABLE [safety].[HCM_Ground_EStop_Interfaces] ADD  CONSTRAINT [DF_HCM_Ground_EStop_Interfaces_Active]  DEFAULT ((1)) FOR [Active]
