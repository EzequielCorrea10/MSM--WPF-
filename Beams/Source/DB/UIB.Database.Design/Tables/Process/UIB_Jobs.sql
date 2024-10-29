CREATE TABLE [to].[HCM_Jobs] (
    [IdJob]                 BIGINT             IDENTITY (1, 1) NOT NULL,
    [IdJobType]             INT                NOT NULL,
    [IdTOStatus]            INT                NOT NULL,
    [LocationNameBeginReq]  VARCHAR (50)       NULL,
    [IdYardBeginReq]        INT                NULL,
    [XPosBeginReq]          INT                NULL,
    [YPosBeginReq]          INT                NULL,
    [ZPosBeginReq]          INT                NULL,
    [HeadingBeginReq]       SMALLINT           NULL,
    [LocationNameBegin]     VARCHAR (50)       NULL,
    [IdYardBegin]           INT                NULL,
    [XPosBegin]             INT                NULL,
    [YPosBegin]             INT                NULL,
    [ZPosBegin]             INT                NULL,
    [HeadingBegin]          SMALLINT           NULL,
    [LocationNameEndReq]    VARCHAR (50)       NULL,
    [IdYardEndReq]          INT                NULL,
    [XPosEndReq]            INT                NULL,
    [YPosEndReq]            INT                NULL,
    [ZPosEndReq]            INT                NULL,
    [HeadingEndReq]         SMALLINT           NULL,
    [LocationNameEnd]       VARCHAR (50)       NULL,
    [IdYardEnd]             INT                NULL,
    [XPosEnd]               INT                NULL,
    [YPosEnd]               INT                NULL,
    [ZPosEnd]               INT                NULL,
    [HeadingEnd]            SMALLINT           NULL,
    [LocationNameRedirect]  VARCHAR (50)       NULL,
    [IdYardRedirect]        INT                NULL,
    [XPosRedirect]          INT                NULL,
    [YPosRedirect]          INT                NULL,
    [ZPosRedirect]          INT                NULL,
    [HeadingRedirect]       SMALLINT           NULL,
    [FormattedInstructions] VARCHAR (MAX)      NULL,
    [PieceName]             VARCHAR (50)       NULL,
    [HighPriority]          BIT                NULL,
    [Bypasses]              INT                NULL,
    [RequestTime]           DATETIMEOFFSET (7) NULL,
    [BeginTime]             DATETIMEOFFSET (7) NULL,
    [PickupTime]            DATETIMEOFFSET (7) NULL,
    [StorageTime]           DATETIMEOFFSET (7) NULL,
    [EndTime]               DATETIMEOFFSET (7) NULL,
    [CancelTime]            DATETIMEOFFSET (7) NULL,
    [UsernameRequest]       VARCHAR (40)       NULL,
    [UsernameCancel]        VARCHAR (40)       NULL,
    [Notes]                 VARCHAR (MAX)      NULL,
    [InsDateTime]           DATETIMEOFFSET (7) CONSTRAINT [DF_HCM_Jobs_InsDateTime] DEFAULT (sysdatetimeoffset()) NULL,
    [UpdDateTime]           DATETIMEOFFSET (7) CONSTRAINT [DF_HCM_Jobs_UpdDateTime] DEFAULT (sysdatetimeoffset()) NULL,
    CONSTRAINT [PK_HCM_Jobs] PRIMARY KEY CLUSTERED ([IdJob] ASC) ON [PROCESS],
    CONSTRAINT [FK_Rodeo_Yards_Begin_Req_HCM_Jobs] FOREIGN KEY ([IdYardBeginReq]) REFERENCES [common].[Rodeo_Yards] ([IdYard]),
    CONSTRAINT [FK_Rodeo_Yards_Begin_HCM_Jobs] FOREIGN KEY ([IdYardBegin]) REFERENCES [common].[Rodeo_Yards] ([IdYard]),
    CONSTRAINT [FK_Rodeo_Yards_End_Req_HCM_Jobs] FOREIGN KEY ([IdYardEndReq]) REFERENCES [common].[Rodeo_Yards] ([IdYard]),
    CONSTRAINT [FK_Rodeo_Yards_End_HCM_Jobs] FOREIGN KEY ([IdYardEnd]) REFERENCES [common].[Rodeo_Yards] ([IdYard]),
    CONSTRAINT [FK_Rodeo_Yards_Redirect_HCM_Jobs] FOREIGN KEY ([IdYardRedirect]) REFERENCES [common].[Rodeo_Yards] ([IdYard]),
    CONSTRAINT [FK_HCM_Jobs_Rodeo_TO_Statuses] FOREIGN KEY ([IdTOStatus]) REFERENCES [to].[Rodeo_TO_Statuses] ([IdTOStatus]),
    CONSTRAINT [FK_HCM_Jobs_HCM_Job_Types] FOREIGN KEY ([IdJobType]) REFERENCES [to].[HCM_Job_Types] ([IdJobType])
) ON [PROCESS] TEXTIMAGE_ON [PROCESS];
GO

CREATE NONCLUSTERED INDEX [IX_HCM_Jobs_IdJobType]
    ON [to].[HCM_Jobs]([IdJobType] ASC)
    ON [PROCESS];
GO

CREATE NONCLUSTERED INDEX [IX_HCM_Jobs_IdTOStatus]
    ON [to].[HCM_Jobs]([IdTOStatus] ASC)
    ON [PROCESS];
GO

