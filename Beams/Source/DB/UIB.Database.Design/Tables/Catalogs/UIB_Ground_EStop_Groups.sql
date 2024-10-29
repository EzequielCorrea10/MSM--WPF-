CREATE TABLE [safety].[HCM_Ground_EStop_Groups](
	[IdGroundEStopGroup] [int] NOT NULL,
	[Title] VARCHAR(250) NOT NULL,
	[StatusTagname] [varchar](70) NULL,
	[StatusBit] [bit] NULL,
	[StatusPlcValue] [int] NULL,
	[StatusAlarmname] [varchar](70) NULL,
	[ResetTagname] [varchar](70) NOT NULL,
	[ResetSetpoint] [smallint] NOT NULL,
	[ResetPlcValue] [bit] NOT NULL,
	[Order] [smallint] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_HCM_Ground_EStop_Groups] PRIMARY KEY CLUSTERED 
(
	[IdGroundEStopGroup] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_HCM_Ground_EStop_Groups] UNIQUE NONCLUSTERED 
(
	[Order] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [safety].[HCM_Ground_EStop_Groups] ADD  CONSTRAINT [DF_HCM_Ground_EStop_Groups_Active]  DEFAULT ((1)) FOR [Active]
