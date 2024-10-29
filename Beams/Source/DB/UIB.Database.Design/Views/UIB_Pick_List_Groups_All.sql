CREATE VIEW [tracking].[HSM_Pick_List_Groups_All]
AS 
	SELECT * FROM [tracking].[HSM_Pick_List_Groups]
	UNION
	SELECT * FROM [tracking].[HSM_Pick_List_Groups_Filters]
GO