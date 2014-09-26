USE RENTAWHEELS
GO
EXEC sp_rename 'Branch.[Name]', 'BranchName', 'COLUMN'
GO
EXEC sp_rename 'Model.[Name]', 'ModelName', 'COLUMN'
GO
EXEC sp_rename 'Category.[Name]', 'CategoryName', 'COLUMN'
GO