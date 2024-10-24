/*
Do not change the database path or name variables.
Any sqlcmd variables will be properly substituted during 
build and deployment.
*/
ALTER DATABASE [$(DatabaseName)]
	ADD FILEGROUP [EVENTS]

GO

ALTER DATABASE [$(DatabaseName)]
	ADD FILE
	(
		NAME = N'Events',
		FILENAME = '$(DefaultDataPath)$(DefaultFilePrefix)_evt.ndf',
		SIZE = 73728KB,
		MAXSIZE = UNLIMITED, 
		FILEGROWTH = 65536KB
	)
TO FILEGROUP [EVENTS];