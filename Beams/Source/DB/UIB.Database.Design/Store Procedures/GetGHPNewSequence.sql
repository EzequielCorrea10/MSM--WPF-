CREATE PROCEDURE [tracking].[GetGHPNewSequence]
	@sequence int = NULL OUTPUT
AS
BEGIN

	SELECT @sequence = NEXT VALUE FOR [tracking].[MSM_GHP_Reference]
	RETURN @sequence

END