CREATE VIEW [tracking].[HCM_Pick_Lists_All]
AS 
	SELECT * FROM [tracking].[HCM_Pick_Lists]
	UNION
	SELECT * FROM [tracking].[HCM_Pick_Lists_Filters]
GO