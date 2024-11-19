CREATE TABLE [dbo].[Table]
(
	[MaSp] VARCHAR(50) NOT NULL PRIMARY KEY, 
    [TenSp] NVARCHAR(50) NULL, 
    [LoaiSp] NVARCHAR(50) NULL, 
    [SoLuong] VARCHAR(50) NULL, 
    [Gia] VARCHAR(50) NULL
)
go
CREATE TABLE [dbo].[dsSanPham]
(
	[MaSp] VARCHAR(50) NOT NULL PRIMARY KEY, 
    [TenSp] NVARCHAR(50) NULL, 
    [LoaiSp] NVARCHAR(50) NULL, 
    [SoLuong] VARCHAR(50) NULL, 
    [Gia] VARCHAR(50) NULL
)