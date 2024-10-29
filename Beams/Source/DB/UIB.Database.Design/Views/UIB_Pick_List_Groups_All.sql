CREATE VIEW [tracking].[HCM_Pick_List_Groups_All]
AS 
	SELECT * FROM [tracking].[HCM_Pick_List_Groups]
	UNION
	SELECT * FROM [tracking].[HCM_Pick_List_Groups_Filters]
GO