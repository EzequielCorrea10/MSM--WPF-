CREATE TABLE [safety].[UIB_Machine_Failures_bk20240805] (
    [IdMachineFailure]         INT           NOT NULL,
    [ParentIdMachineFailure]   INT           NULL,
    [IdMachineType]            INT           NOT NULL,
    [IdMachine]                INT           NULL,
    [Title]                    VARCHAR (250) NOT NULL,
    [Tagname]                  VARCHAR (70)  NULL,
    [Bit]                      INT           NULL,
    [PlcValue]                 INT           NULL,
    [Alarmname]                VARCHAR (70)  NULL,
    [TextSizeDisplayed]        SMALLINT      NOT NULL,
    [TroubleshootingReference] VARCHAR (100) NULL,
    [Order]                    SMALLINT      NOT NULL,
    [Active]                   BIT           NOT NULL
);

