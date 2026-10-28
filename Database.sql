Create Database DuLieu;
Go
Use DuLieu;
Go
Create Table MonHoc(
	MaMonHoc nvarchar(10) primary key,
	TenMonHoc nText not null,
	SoTinChi nvarchar(5) not null
);
