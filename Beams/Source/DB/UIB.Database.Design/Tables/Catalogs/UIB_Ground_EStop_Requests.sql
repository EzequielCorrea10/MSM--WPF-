CREATE TABLE [safety].[HCM_Ground_EStop_Requests](
	[IdGroundEStopRequest] [int] NOT NULL,
	[IdGroundEStopGroup] [int] NOT NULL,
	[IdRequest] [int] NOT NULL,
	[Order] [smallint] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_HCM_Ground_EStop_Requests] PRIMARY KEY CLUSTERED 
(
	[IdGroundEStopRequest] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_HCM_Ground_EStop_Requests_Order] UNIQUE NONCLUSTERED 
(
	[IdGroundEStopGroup] ASC,
	[IdRequest] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO 

ALTER TABLE [safety].[HCM_Ground_EStop_Requests]  WITH CHECK ADD  CONSTRAINT [FK_HCM_Ground_EStop_Requests_HCM_Ground_EStop_Groups] FOREIGN KEY([IdGroundEStopGroup]) REFERENCES [safety].[HCM_Ground_EStop_Groups] ([IdGroundEStopGroup])
GO

ALTER TABLE [safety].[HCM_Ground_EStop_Requests] CHECK CONSTRAINT [FK_HCM_Ground_EStop_Requests_HCM_Ground_EStop_Groups]
GO

ALTER TABLE [safety].[HCM_Ground_EStop_Requests]  WITH CHECK ADD  CONSTRAINT [FK_HCM_Ground_EStop_Requests_HCM_Requests] FOREIGN KEY([IdRequest]) REFERENCES [safety].[HCM_Requests] ([IdRequest])
GO

ALTER TABLE [safety].[HCM_Ground_EStop_Requests] CHECK CONSTRAINT [FK_HCM_Ground_EStop_Requests_HCM_Requests]
GO

ALTER TABLE [safety].[HCM_Ground_EStop_Requests] ADD  CONSTRAINT [DF_HCM_Ground_EStop_Requests_Active]  DEFAULT ((1)) FOR [Active]
