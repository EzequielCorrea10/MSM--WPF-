/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
USE [master]
GO
ALTER DATABASE [$(DatabaseName)] SET READ_WRITE 
GO
sp_configure 'show advanced options', 1;  
GO  
RECONFIGURE;  
GO  
sp_configure 'min server memory', 512;  
GO  
sp_configure 'max server memory', 4096;  
GO  
RECONFIGURE;  
GO
sp_configure 'show advanced options', 0;  
GO  
  