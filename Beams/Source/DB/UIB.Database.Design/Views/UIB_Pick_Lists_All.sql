CREATE VIEW [tracking].[MSM_Pick_Lists_All]
AS 
	SELECT * FROM [tracking].[MSM_Pick_Lists]
	UNION
	SELECT * FROM [tracking].[MSM_Pick_Lists_Filters]
GO