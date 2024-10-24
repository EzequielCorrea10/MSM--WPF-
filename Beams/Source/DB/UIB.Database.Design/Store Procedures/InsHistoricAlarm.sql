CREATE PROCEDURE [rodeo].[InsHistoricAlarm]
	-- Add the parameters for the stored procedure here
	@IdAlarm int,		
	@TimeOn datetimeoffset(7),
	@TimeOff datetimeoffset(7) = NULL,
	@TimeAccept datetimeoffset(7) = NULL,
    @TimeAcceptUserName varchar(20) = NULL,
	@TimeReset datetimeoffset(7) = NULL,
    @TimeResetUserName varchar(20) = NULL,
	@TimeQuarantine datetimeoffset(7) = NULL,
    @TimeQuarantineUserName varchar(20) = NULL,
	@IsForced bit,
	@Event int,
	@IdAlarmHistory bigint = NULL OUTPUT
AS
BEGIN

	BEGIN TRY
		BEGIN TRANSACTION;

		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
		SET NOCOUNT ON;

		INSERT INTO [rodeo].[Rodeo_Alarms_History]
			(IdAlarm,
			 TimeOn,
			 TimeOff,
			 TimeAccept,
			 TimeAcceptUserName,
			 TimeReset,
			 TimeResetUserName,
			 TimeQuarantine,
			 TimeQuarantineUserName,
			 [IsCloseForced],
			 [Event])
		VALUES
			(@IdAlarm,
			 @TimeOn,
			 @TimeOff,
			 @TimeAccept,
			 @TimeAcceptUserName,
			 @TimeReset,
			 @TimeResetUserName,
			 @TimeQuarantine,
			 @TimeQuarantineUserName,
			 @IsForced,
			 @Event)

		COMMIT TRANSACTION;

		SELECT @IdAlarmHistory = SCOPE_IDENTITY();

	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION;
		DECLARE @ErrorMessage NVARCHAR(4000);  
		DECLARE @ErrorSeverity INT;  
		DECLARE @ErrorState INT;  
		DECLARE @ErrorNumber INT;
  
		SELECT   
			@ErrorMessage = ERROR_MESSAGE(),  
			@ErrorSeverity = ERROR_SEVERITY(),  
			@ErrorState = ERROR_STATE(),
			@ErrorNumber = ERROR_NUMBER();  
  
		IF @ErrorNumber = 2627 OR @ErrorNumber = 2601 
		BEGIN
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
				UpdDateTime = SYSDATETIMEOFFSET(),
				@IdAlarmHistory = IdAlarmHistory
			WHERE IdAlarm = @IdAlarm 
			AND TimeOn = @TimeOn
		END
		ELSE
		BEGIN
			-- Use RAISERROR inside the CATCH block to return error  
			-- information about the original error that caused  
			-- execution to jump to the CATCH block.  
			RAISERROR (@ErrorMessage, -- Message text.  
					   @ErrorSeverity, -- Severity.  
					   @ErrorState -- State.  
					   );  
		END;
	END CATCH

	RETURN @IdAlarmHistory;

END