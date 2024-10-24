--USE [$(DatabaseName)]

--GO

CREATE ROLE [l2_espaccess]

GO

GRANT DELETE, EXECUTE, INSERT, UPDATE, SELECT ON SCHEMA::[l2_esp] TO [l2_espaccess]

GO