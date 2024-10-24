CREATE VIEW [tracking].[MSM_Pick_List_Groups_All]
AS 
	SELECT * FROM [tracking].[MSM_Pick_List_Groups]
	UNION
	SELECT * FROM [tracking].[MSM_Pick_List_Groups_Filters]
GO