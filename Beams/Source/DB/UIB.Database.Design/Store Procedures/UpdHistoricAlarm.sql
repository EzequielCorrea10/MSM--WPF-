CREATE PROCEDURE [rodeo].[UpdHistoricAlarm]
	-- Add the parameters for the stored procedure here
	@IdAlarm int,		
	@TimeOn datetimeoffset(7) = NULL,
	@TimeOff datetimeoffset(7) = NULL,
	@TimeAccept datetimeoffset(7) = NULL,
    @TimeAcceptUserName varchar(20) = NULL,
	@TimeReset datetimeoffset(7) = NULL,
    @TimeResetUserName varchar(20) = NULL,
	@TimeQuarantine datetimeoffset(7) = NULL,
    @TimeQuarantineUserName varchar(20) = NULL,
	@IsForced bit,
	@Event int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE [rodeo].[Rodeo_Alarms_History]
	SET	TimeOff = @TimeOff,
		TimeAccept = @TimeAccept,
		TimeAcceptUserName = @TimeAcceptUserName,
		TimeReset = @TimeReset,
		TimeResetUserName = @TimeResetUserName,
		TimeQuarantine = @TimeQuarantine,
		TimeQuarantineUserName = @TimeQuarantineUserName,
		[IsCloseForced]= @IsForced,
		[Event]= @Event,
		UpdDateTime = SYSDATETIMEOFFSET()
	WHERE IdAlarm = @IdAlarm 
	AND TimeOn = @TimeOn
END