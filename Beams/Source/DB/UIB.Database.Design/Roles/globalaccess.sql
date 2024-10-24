--USE [$(DatabaseName)]

--GO

CREATE ROLE [globalaccess]

GO

GRANT DELETE, EXECUTE, INSERT, UPDATE, SELECT ON SCHEMA::[global] TO [globalaccess]

GO