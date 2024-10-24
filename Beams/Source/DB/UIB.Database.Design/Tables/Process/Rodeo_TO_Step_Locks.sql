CREATE TABLE [to].[Rodeo_TO_Step_Locks](
	[IdTransportOrder] [bigint] NOT NULL,
	[Step] [smallint] NOT NULL,
	[IdLockLocation] [int] NOT NULL
 CONSTRAINT [PK_Rodeo_TO_Step_Locks] PRIMARY KEY CLUSTERED 
(
	[IdTransportOrder] ASC,
	[Step] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PROCESS]
) ON [PROCESS]

GO

ALTER TABLE [to].[Rodeo_TO_Step_Locks]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_TO_Step_Locks_Rodeo_TO_Steps] FOREIGN KEY([IdTransportOrder], [Step]) REFERENCES [to].[Rodeo_TO_Steps] ([IdTransportOrder], [Step])

GO

ALTER TABLE [to].[Rodeo_TO_Step_Locks] CHECK CONSTRAINT [FK_Rodeo_TO_Step_Locks_Rodeo_TO_Steps]
GO 

ALTER TABLE [to].[Rodeo_TO_Step_Locks]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_TO_Step_Locks_Rodeo_Locations] FOREIGN KEY([IdLockLocation]) REFERENCES [common].[Rodeo_Locations] ([IdLocation])
GO

ALTER TABLE [to].[Rodeo_TO_Step_Locks] CHECK CONSTRAINT [FK_Rodeo_TO_Step_Locks_Rodeo_Locations]
GO

