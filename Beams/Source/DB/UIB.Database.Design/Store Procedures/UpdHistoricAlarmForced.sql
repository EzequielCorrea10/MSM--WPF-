CREATE PROCEDURE [rodeo].[UpdHistoricAlarmForced]
	-- Add the parameters for the stored procedure here
	@IsForced bit,
	@IdAlarm  int,
	@TimeOn datetimeoffset(7) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [rodeo].[Rodeo_Alarms_History]
	SET IsCloseForced = @IsForced,
		TimeOff = SYSDATETIMEOFFSET(),
		UpdDateTime = SYSDATETIMEOFFSET()
	WHERE IdAlarm = @IdAlarm
	AND (@TimeOn IS NULL OR TimeOn = @TimeOn) 
	AND TimeOff IS NULL
END