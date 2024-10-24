CREATE PROCEDURE [rodeo].[UpdHistoricUserLogForced]
	-- Add the parameters for the stored procedure here
	@IsForced bit,
	@IdClient int,
	@IdSession int,
	@TimeIN datetimeoffset(7) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE [rodeo].[Rodeo_UserLogs_History]
	SET	IsCloseForced = @IsForced,
		[TimeOUT] =SYSDATETIMEOFFSET(),
		UpdDateTime = SYSDATETIMEOFFSET()
	WHERE IdClient = @IdClient 
	AND IdSession = @IdSession
	AND (@TimeIN IS NULL OR TimeIN = @TimeIN)
	AND [TimeOUT] IS NULL
END