CREATE TABLE [to].[MSM_RCP_Configs] (
    [IdMachine]         INT           NOT NULL,
    [MachineConfigName] NVARCHAR (5)  NOT NULL,
    [IP]                NVARCHAR (50) NOT NULL,
    [RequestPort]       INT           NOT NULL,
    [ServerPort]        INT           NOT NULL,
    [RCPPort]           INT           NOT NULL,
    [IsTripleIN]        BIT           NOT NULL,
    [ConnectWatchdog]   BIT           NOT NULL,
    CONSTRAINT [PK_PB_RCP_Configs] PRIMARY KEY CLUSTERED ([IdMachine] ASC)
);
GO