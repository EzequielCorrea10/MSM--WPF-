CREATE TABLE [safety].[HSM_Ground_EStop_Requests](
	[IdGroundEStopRequest] [int] NOT NULL,
	[IdGroundEStopGroup] [int] NOT NULL,
	[IdRequest] [int] NOT NULL,
	[Order] [smallint] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_HSM_Ground_EStop_Requests] PRIMARY KEY CLUSTERED 
(
	[IdGroundEStopRequest] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_HSM_Ground_EStop_Requests_Order] UNIQUE NONCLUSTERED 
(
	[IdGroundEStopGroup] ASC,
	[IdRequest] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO 

ALTER TABLE [safety].[HSM_Ground_EStop_Requests]  WITH CHECK ADD  CONSTRAINT [FK_HSM_Ground_EStop_Requests_HSM_Ground_EStop_Groups] FOREIGN KEY([IdGroundEStopGroup]) REFERENCES [safety].[HSM_Ground_EStop_Groups] ([IdGroundEStopGroup])
GO

ALTER TABLE [safety].[HSM_Ground_EStop_Requests] CHECK CONSTRAINT [FK_HSM_Ground_EStop_Requests_HSM_Ground_EStop_Groups]
GO

ALTER TABLE [safety].[HSM_Ground_EStop_Requests]  WITH CHECK ADD  CONSTRAINT [FK_HSM_Ground_EStop_Requests_HSM_Requests] FOREIGN KEY([IdRequest]) REFERENCES [safety].[HSM_Requests] ([IdRequest])
GO

ALTER TABLE [safety].[HSM_Ground_EStop_Requests] CHECK CONSTRAINT [FK_HSM_Ground_EStop_Requests_HSM_Requests]
GO

ALTER TABLE [safety].[HSM_Ground_EStop_Requests] ADD  CONSTRAINT [DF_HSM_Ground_EStop_Requests_Active]  DEFAULT ((1)) FOR [Active]
