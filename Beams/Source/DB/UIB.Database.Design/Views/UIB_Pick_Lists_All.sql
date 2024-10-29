CREATE VIEW [tracking].[HSM_Pick_Lists_All]
AS 
	SELECT * FROM [tracking].[HSM_Pick_Lists]
	UNION
	SELECT * FROM [tracking].[HSM_Pick_Lists_Filters]
GO