--USE [$(DatabaseName)]

--GO

CREATE ROLE [rodeoaccess]

GO

GRANT EXECUTE ON SCHEMA::[rodeo] TO [rodeoaccess]