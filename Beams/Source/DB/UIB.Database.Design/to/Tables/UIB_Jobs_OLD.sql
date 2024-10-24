CREATE TABLE [to].[UIB_Jobs_OLD] (
    [IdJob]                    BIGINT             IDENTITY (1, 1) NOT NULL,
    [IdMasterJob]              BIGINT             NULL,
    [IdJobType]                INT                NOT NULL,
    [IdTOStatus]               INT                NOT NULL,
    [PickupReqLocationName]    VARCHAR (50)       NULL,
    [PickupReqMachineName]     VARCHAR (50)       NULL,
    [PickupReqIdYard]          INT                NULL,
    [PickupReqXPos]            INT                NULL,
    [PickupReqYPos]            INT                NULL,
    [PickupReqZPos]            INT                NULL,
    [PickupReqHeading]         SMALLINT           NULL,
    [PickupFinalLocationName]  VARCHAR (50)       NULL,
    [PickupFinalMachineName]   VARCHAR (50)       NULL,
    [PickupFinalIdYard]        INT                NULL,
    [PickupFinalXPos]          INT                NULL,
    [PickupFinalYPos]          INT                NULL,
    [PickupFinalZPos]          INT                NULL,
    [PickupFinalHeading]       SMALLINT           NULL,
    [DropReqLocationName]      VARCHAR (50)       NULL,
    [DropReqMachineName]       VARCHAR (50)       NULL,
    [DropReqIdYard]            INT                NULL,
    [DropReqXPos]              INT                NULL,
    [DropReqYPos]              INT                NULL,
    [DropReqZPos]              INT                NULL,
    [DropReqHeading]           SMALLINT           NULL,
    [DropAssignLocationName]   VARCHAR (50)       NULL,
    [DropAssignMachineName]    VARCHAR (50)       NULL,
    [DropAssignIdYard]         INT                NULL,
    [DropAssignXPos]           INT                NULL,
    [DropAssignYPos]           INT                NULL,
    [DropAssignZPos]           INT                NULL,
    [DropAssignHeading]        SMALLINT           NULL,
    [DropInitialLocationName]  VARCHAR (50)       NULL,
    [DropInitialMachineName]   VARCHAR (50)       NULL,
    [DropInitialIdYard]        INT                NULL,
    [DropInitialXPos]          INT                NULL,
    [DropInitialYPos]          INT                NULL,
    [DropInitialZPos]          INT                NULL,
    [DropInitialHeading]       SMALLINT           NULL,
    [DropRedirectLocationName] VARCHAR (50)       NULL,
    [DropRedirectMachineName]  VARCHAR (50)       NULL,
    [DropRedirectIdYard]       INT                NULL,
    [DropRedirectXPos]         INT                NULL,
    [DropRedirectYPos]         INT                NULL,
    [DropRedirectZPos]         INT                NULL,
    [DropRedirectHeading]      SMALLINT           NULL,
    [FormattedInstructions]    VARCHAR (MAX)      NULL,
    [PieceName]                VARCHAR (50)       NOT NULL,
    [HighPriority]             BIT                NULL,
    [Bypasses]                 INT                NOT NULL,
    [RequestTime]              DATETIMEOFFSET (7) NOT NULL,
    [BeginTime]                DATETIMEOFFSET (7) NULL,
    [PickupTime]               DATETIMEOFFSET (7) NULL,
    [StorageTime]              DATETIMEOFFSET (7) NULL,
    [EndTime]                  DATETIMEOFFSET (7) NULL,
    [CancelTime]               DATETIMEOFFSET (7) NULL,
    [UsernameRequest]          VARCHAR (40)       NULL,
    [UsernameCancel]           VARCHAR (40)       NULL,
    [Notes]                    VARCHAR (MAX)      NULL,
    [InsDateTime]              DATETIMEOFFSET (7) CONSTRAINT [DF_UIB_Jobs_InsDateTime] DEFAULT (sysdatetimeoffset()) NOT NULL,
    [UpdDateTime]              DATETIMEOFFSET (7) CONSTRAINT [DF_UIB_Jobs_UpdDateTime] DEFAULT (sysdatetimeoffset()) NOT NULL,
    CONSTRAINT [PK_UIB_Jobs] PRIMARY KEY CLUSTERED ([IdJob] ASC) ON [PROCESS],
    CONSTRAINT [FK_UIB_Jobs_Rodeo_TO_Statuses] FOREIGN KEY ([IdTOStatus]) REFERENCES [to].[Rodeo_TO_Statuses] ([IdTOStatus]),
    CONSTRAINT [FK_UIB_Jobs_Rodeo_Yards_Begin] FOREIGN KEY ([PickupFinalIdYard]) REFERENCES [common].[Rodeo_Yards] ([IdYard]),
    CONSTRAINT [FK_UIB_Jobs_Rodeo_Yards_Begin_Req] FOREIGN KEY ([PickupReqIdYard]) REFERENCES [common].[Rodeo_Yards] ([IdYard]),
    CONSTRAINT [FK_UIB_Jobs_Rodeo_Yards_End] FOREIGN KEY ([DropInitialIdYard]) REFERENCES [common].[Rodeo_Yards] ([IdYard]),
    CONSTRAINT [FK_UIB_Jobs_Rodeo_Yards_End_Assign] FOREIGN KEY ([DropAssignIdYard]) REFERENCES [common].[Rodeo_Yards] ([IdYard]),
    CONSTRAINT [FK_UIB_Jobs_Rodeo_Yards_End_Req] FOREIGN KEY ([DropReqIdYard]) REFERENCES [common].[Rodeo_Yards] ([IdYard]),
    CONSTRAINT [FK_UIB_Jobs_Rodeo_Yards_Redirect] FOREIGN KEY ([DropRedirectIdYard]) REFERENCES [common].[Rodeo_Yards] ([IdYard]),
    CONSTRAINT [FK_UIB_Jobs_UIB_Job_Types] FOREIGN KEY ([IdJobType]) REFERENCES [to].[UIB_Job_Types] ([IdJobType])
) ON [PROCESS] TEXTIMAGE_ON [PROCESS];


GO
CREATE NONCLUSTERED INDEX [IX_UIB_Jobs_RequestTime]
    ON [to].[UIB_Jobs_OLD]([RequestTime] ASC)
    ON [PROCESS];


GO
CREATE NONCLUSTERED INDEX [IX_UIB_Jobs_IdTOStatus]
    ON [to].[UIB_Jobs_OLD]([IdTOStatus] ASC)
    ON [PROCESS];


GO
CREATE NONCLUSTERED INDEX [IX_UIB_Jobs_IdJobType]
    ON [to].[UIB_Jobs_OLD]([IdJobType] ASC)
    ON [PROCESS];


GO
CREATE NONCLUSTERED INDEX [IX_UIB_Jobs_Global]
    ON [to].[UIB_Jobs_OLD]([IdMasterJob] ASC)
    ON [PROCESS];

