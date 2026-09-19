USE LabDB;
GO

IF NOT EXISTS (SELECT 1 FROM Users)
BEGIN
    INSERT INTO Users (Username, Password, Role, IsActive)
    VALUES 
    ('admin', 'admin123', 'Admin', 1),
    ('cashier', 'cashier123', 'Cashier', 1);
END
GO