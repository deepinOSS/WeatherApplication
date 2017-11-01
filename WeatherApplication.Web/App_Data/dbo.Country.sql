CREATE TABLE [dbo].[Country]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [name] NVARCHAR(100) NOT NULL, 
    [alpha-2] NVARCHAR(50) NOT NULL, 
    [alpha-3] NVARCHAR(50) NOT NULL, 
    [country-code] NVARCHAR(50) NOT NULL, 
    [iso_3166-2] NVARCHAR(50) NOT NULL, 
    [region] NVARCHAR(50) NOT NULL, 
    [sub-region] NVARCHAR(50) NOT NULL, 
    [region-code] NVARCHAR(50) NOT NULL, 
    [sub-region-code] NVARCHAR(50) NOT NULL
)
