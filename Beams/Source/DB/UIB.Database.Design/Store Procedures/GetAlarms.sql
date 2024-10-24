CREATE PROCEDURE [rodeo].[GetAlarms]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
 
	SELECT 
		HA.IdAlarmHistory,
		HA.IdAlarm,
		HA.TimeOn,
		HA.TimeOff,
		HA.TimeAccept,
		HA.TimeAcceptUserName,
		HA.TimeReset,
		HA.TimeResetUserName,
		HA.TimeQuarantine,
		HA.TimeQuarantineUserName,
		HA.[Event]   
	FROM [rodeo].[Rodeo_Alarms_History] HA
	WHERE HA.[TimeOff] IS NULL    
	ORDER BY HA.[TimeOn] DESC	
END