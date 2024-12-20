﻿CREATE TABLE [tracking].[HSM_HoldOn_Reasons](
	[IdHoldOnReason] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[Bit] [int] NULL,
	[PlcValue] [int] NULL,
	[L3Value] [int] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_HSM_HoldOn_Reasons] PRIMARY KEY CLUSTERED 
(
	[IdHoldOnReason] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_HSM_HoldOn_Reasons_PlcValue] UNIQUE NONCLUSTERED 
(
	[Bit] ASC,
	[PlcValue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_HSM_HoldOn_Reasons_L3Value] UNIQUE NONCLUSTERED 
(
	[L3Value] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO 

CREATE UNIQUE NONCLUSTERED INDEX [IX_HSM_HoldOn_Reasons_Name] ON [tracking].[HSM_HoldOn_Reasons]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

ALTER TABLE [tracking].[HSM_HoldOn_Reasons] ADD  CONSTRAINT [DF_HSM_HoldOn_Reasons_Active]  DEFAULT ((1)) FOR [Active]
