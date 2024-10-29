--USE [$(DatabaseName)]

--GO

CREATE ROLE [clientaccess]

GO

GRANT SELECT ON SCHEMA::[common] TO [clientaccess]

GO

GRANT SELECT ON SCHEMA::[report] TO [clientaccess]

GO

GRANT SELECT ON SCHEMA::[rodeo] TO [clientaccess]

GO

GRANT SELECT ON SCHEMA::[safety] TO [clientaccess]

GO

GRANT SELECT ON SCHEMA::[system] TO [clientaccess]

GO

GRANT SELECT ON SCHEMA::[to] TO [clientaccess]

GO

GRANT SELECT ON SCHEMA::[tracking] TO [clientaccess]

GO

GRANT INSERT, UPDATE, DELETE ON OBJECT::[system].[HCM_Setting_Values] TO [clientaccess] --AFTER THE TABLES ARE CREATED
