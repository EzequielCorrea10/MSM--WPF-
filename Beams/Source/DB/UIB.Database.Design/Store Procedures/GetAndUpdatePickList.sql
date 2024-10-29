
/*
declare @pl as int
exec [tracking].[GetAndUpdatePickList] @piece_name = 'GHP000092', @picklist = @pl output
print '@pl: ' + cast(@pl as varchar(max))
*/

CREATE PROCEDURE [tracking].[GetAndUpdatePickList]
	-- Add the parameters for the stored procedure here
    @piece_name varchar(50),
	@picklist int = NULL OUTPUT
AS
BEGIN
	DECLARE @PieceStatusName VARCHAR(50);
	DECLARE @PickListName VARCHAR(50);
	DECLARE @L2Destination VARCHAR(50);
	DECLARE @HasLoadNumber BIT;
	DECLARE @IsGhost BIT;
	DECLARE @IsHold BIT;
	
	DECLARE @NewPickListName VARCHAR(50);
	DECLARE @IdPickList INT;

	SELECT	@PieceStatusName = C.[Name],
			@PickListName = D.[Name],
			@picklist = D.PlcValue,
			@IsGhost = CASE WHEN A.IdPieceType = 2 THEN 1 ELSE 0 END,
			@IsHold = CASE WHEN A.HoldOnReasonStatus > 0 THEN 1 ELSE 0 END
	FROM [tracking].[Rodeo_Pieces] A
	INNER JOIN [tracking].[Rodeo_Piece_Statuses] C ON A.IdPieceStatus = C.IdPieceStatus
	LEFT JOIN [tracking].[HCM_Pick_Lists] D ON A.IdPickList = D.IdPickList
	WHERE A.[PieceName] = @piece_name

	IF @@ROWCOUNT = 1
	BEGIN
		SET @NewPickListName = NULL

		IF @PieceStatusName <> 'Obsolete' AND @IsGhost = 0
		BEGIN
			SELECT TOP 1 @L2Destination = L2Destination
			FROM [to].[HCM_Destination_Next_Pieces]
			WHERE [PieceName] = @piece_name

			IF @L2Destination IS NOT NULL
			BEGIN
				SET  @NewPickListName = CASE
											WHEN @L2Destination = 'Scalped' THEN 'To be Scalped'
											ELSE NULL
										END;
			END
		END

		IF @NewPickListName IS NULL
		BEGIN
			--IF @PickListName IS NOT NULL
			--BEGIN
				IF @PieceStatusName <> 'Obsolete' AND @IsGhost = 0
					SET @picklist = 2;	--To not be Scalped
				ELSE
					SET @picklist = NULL;

				UPDATE [tracking].[Rodeo_Pieces]
				SET IdPickList = @picklist,
					UpdDateTime = SYSDATETIMEOFFSET()
				WHERE [PieceName] = @piece_name
			--END
		END
		ELSE
		BEGIN
			IF @NewPickListName <> @PickListName OR @PickListName IS NULL
			BEGIN
				SELECT	@IdPickList = [IdPickList],
						@picklist = [PlcValue]
				FROM [tracking].[HCM_Pick_Lists] 
				WHERE [Name] = @NewPickListName

				UPDATE [tracking].[Rodeo_Pieces]
				SET IdPickList = @IdPickList,
					UpdDateTime = SYSDATETIMEOFFSET()
				WHERE [PieceName] = @piece_name
			END
		END
	END

	--TO DO
	RETURN @picklist;

END