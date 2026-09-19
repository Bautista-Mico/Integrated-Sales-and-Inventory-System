USE LabDB;
GO

CREATE OR ALTER PROCEDURE sp_AuthenticateUser
    @Username NVARCHAR(50),
    @Password NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT UserID, Username, Role, IsActive
    FROM Users
    WHERE Username = @Username 
      AND Password = @Password 
      AND IsActive = 1;
END;
GO