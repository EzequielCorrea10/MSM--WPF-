﻿CREATE TABLE [report].[HSM_Message_Types](
	[IdMessageType] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[Source] [varchar](50) NOT NULL,
	[L3OrL2Value] [varchar](30) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_HSM_Message_Types] PRIMARY KEY CLUSTERED 
(
	[IdMessageType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_HSM_Message_Types_L3Value] UNIQUE NONCLUSTERED 
(
	[L3OrL2Value] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO 

CREATE UNIQUE NONCLUSTERED INDEX [IX_HSM_Message_Types_Name] ON [report].[HSM_Message_Types]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

ALTER TABLE [report].[HSM_Message_Types] ADD  CONSTRAINT [DF_HSM_Message_Types_Active]  DEFAULT ((1)) FOR [Active]
