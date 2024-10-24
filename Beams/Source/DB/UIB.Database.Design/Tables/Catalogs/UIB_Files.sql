CREATE TABLE [common].[MSM_Files] (
    [IdFile]          INT           NOT NULL,
    [IdFileType]      INT           NOT NULL,
    [IdMachineType]   INT           NOT NULL,
    [IdMachine]       INT           NULL,
    [FileName]        VARCHAR (100) NOT NULL,
    [FullDescription] VARCHAR (100) NULL,
    [Order]           SMALLINT      NOT NULL,
    [Active]          BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([IdFile] ASC),
    FOREIGN KEY ([IdFileType]) REFERENCES [common].[MSM_File_Types] ([IdFileType])
);
GO

ALTER TABLE [common].[MSM_Files]  WITH CHECK ADD CONSTRAINT [FK_MSM_Files_Rodeo_Machine_Types] FOREIGN KEY([IdMachineType]) REFERENCES [common].[Rodeo_Machine_Types] ([IdMachineType])

GO

ALTER TABLE [common].[MSM_Files] CHECK CONSTRAINT [FK_MSM_Files_Rodeo_Machine_Types]

GO

ALTER TABLE [common].[MSM_Files]  WITH CHECK ADD CONSTRAINT [FK_MSM_Files_Rodeo_Machines] FOREIGN KEY([IdMachine]) REFERENCES [common].[Rodeo_Machines] ([IdMachine])

GO

ALTER TABLE [common].[MSM_Files] CHECK CONSTRAINT [FK_MSM_Files_Rodeo_Machines]

GO
