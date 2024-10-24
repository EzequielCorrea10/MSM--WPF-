CREATE PROCEDURE [rodeo].[GetHistoricAlarms]
	-- Add the parameters for the stored procedure here
	@Description varchar(200) = null,
	@PlcId int = null,
	@Address varchar(50) = null,
	@Alarm varchar(200) = null,
	@BeginDate datetimeoffset(7),
	@EndDate datetimeoffset(7),
	@IsShowingRecognized bit = null,
	@isShowOff bit = null,
	@IsShowQuarantine bit = null,
	@IsShowCancelation bit = null,
	@Group varchar(100) = null,
	@Island varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT 
		 IdAlarm
		,TimeOn
		,TimeOff
		,TimeAccept
		,TimeAcceptUserName
		,TimeReset
		,TimeResetUserName
		,TimeQuarantine
		,TimeQuarantineUserName
		,[Event]
	FROM [rodeo].[Rodeo_Alarms_History] HA
	WHERE HA.[TimeOn] BETWEEN @BeginDate AND @EndDate
	AND ((@IsShowingRecognized IS NULL) OR (@IsShowingRecognized = 1 AND HA.[TimeAccept] IS NOT NULL) OR (@IsShowingRecognized = 0 AND HA.[TimeAccept] IS NULL))
	AND ((@isShowOff IS NULL) OR (@isShowOff = 1 AND HA.[TimeOff] IS NOT NULL) OR (@isShowOff = 0 AND HA.[TimeOff] IS NULL))
	AND ((@IsShowQuarantine IS NULL) OR (@IsShowQuarantine = 1 AND HA.[Event] IN (7, 8, 9)) OR (@IsShowQuarantine = 0 AND HA.[Event] NOT IN (7, 8, 9)))
	AND ((@IsShowCancelation IS NULL) OR (@IsShowCancelation = 1 AND HA.[Event] IN (2, 4)) OR (@IsShowCancelation = 0 AND HA.[Event] NOT IN (2, 4)))
	ORDER BY HA.[TimeOn] DESC
END