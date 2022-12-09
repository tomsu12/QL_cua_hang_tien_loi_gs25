IF NOT EXISTS (SELECT * FROM sys.sysdatabases WHERE name='QuanLyCuaHangGS25')
	BEGIN
	   CREATE DATABASE [QuanLyCuaHangGS25]
	END
GO
USE [QuanLyCuaHangGS25]
GO

--Bang BoPhan
CREATE TABLE [BoPhan](
	[MaBoPhan] nchar(10) NOT NULL,
	[TenBoPhan] nvarchar(50) NULL,
	CONSTRAINT pk_BoPhan PRIMARY KEY ([MaBoPhan])
);

--Bang ChucVu
CREATE TABLE [ChucVu](
	[MaCV] nchar(10) NOT NULL,
	[TenCV] nvarchar(50) NULL,
	[MaBoPhan] nchar(10) NULL,
	CONSTRAINT pk_ChucVu PRIMARY KEY ([MaCV])
)
GO

ALTER TABLE [ChucVu]
ADD CONSTRAINT fk_ChucVu_BoPhan FOREIGN KEY ([MaBoPhan]) REFERENCES [BoPhan] ([MaBoPhan]);

--Bang NhanVien
CREATE TABLE [NhanVien](
	[MaNV] nchar(10) NOT NULL,
	[MaCV] nchar(10) NOT NULL,
	[TenNV] nvarchar(50) NOT NULL,
	[DiaChi] nvarchar(100) NOT NULL,
	[Img] varchar(255) NULL,
	[SDT] nchar(13) NULL,
	[SoCMND] nchar(13) NOT NULL,
	[SoTaiKhoan] nchar(13) NULL,
	[NgaySinh] datetime NOT NULL,
	[GioiTinh] nvarchar(4) NOT NULL,
	[TrangThai] nvarchar(200) NULL,
	CONSTRAINT pk_NhanVien PRIMARY KEY ([MaNV])
)

GO

ALTER TABLE [NhanVien]
ADD CONSTRAINT fk_NhanVien_ChucVu FOREIGN KEY ([MaCV]) REFERENCES [ChucVu] ([MaCV]);

--Bang KhachHang
CREATE TABLE [KhachHang](
	[MaKhach] nchar(10) NOT NULL,
	[TenKhach] nvarchar(50) NULL,
	[GioiTinh] nvarchar(4) NULL,
	[DiaChi] nvarchar(200) NULL,
	[SDT] nchar(13) NULL,
	[SoCMND] nchar(13) NULL,
	[SoTaiKhoan] nchar(13) NULL,
	[SoDiemThuong] int NULL,
	CONSTRAINT pk_KhachHang PRIMARY KEY ([MaKhach])
);

--Bang NhaCC
CREATE TABLE [NhaCC](
	[MaNCC] nchar(10) NOT NULL,
	[TenNCC] nvarchar(100) NULL,
	[DiaChi] nvarchar(200) NULL,
	[SDT] nchar(15) NULL,
	[SoFax] nchar(15) NULL,
	[SoTaiKhoan] nchar(15) NULL,
	[MaSoThue] nchar(15) NULL,
	[No] float NULL,
	[Co] float NULL,
	CONSTRAINT pk_NhaCC PRIMARY KEY ([MaNCC])
);
--Bang CongNoNCC
CREATE TABLE [CongNoNCC](
	[STT] int IDENTITY(1,1) NOT NULL,
	[Ngay] datetime NULL,
	[SoHoaDon] nchar(10) NOT NULL,
	[MaNCC] nchar(10) NULL,
	[DauKy] int NULL,
	[PhatSinhTang] int NULL,
	[PhatSinhGiam] int NULL,
	[CuoiKy] int NULL,
	[DienGiai] nvarchar(200) NULL,
	CONSTRAINT pk_CongNoNCC PRIMARY KEY ([SoHoaDon])
)
GO
ALTER TABLE [CongNoNCC]
ADD CONSTRAINT fk_CongNoNCC_NhaCC FOREIGN KEY ([MaNCC]) REFERENCES [NhaCC] ([MaNCC]);
--Bang HangSX
CREATE TABLE [HangSX](
	[MaHangSX] nchar(10) NOT NULL,
	[TenHangSX] nvarchar(100) NULL
	CONSTRAINT pk_HangSX PRIMARY KEY ([MaHangSX])
);
--Bang LoaiSanPham
CREATE TABLE [LoaiSanPham](
	[MaLoaiSanPham] nchar(10) NOT NULL,
	[TenLoaiSanPham] nvarchar(100) NULL,
	CONSTRAINT pk_LoaiSanPham PRIMARY KEY ([MaLoaiSanPham])
);
--Bang NhomHang
CREATE TABLE [NhomHang](
	[MaNhomHang] nchar(10) NOT NULL,
	[TenNhomHang] nvarchar(100) NULL,
	[MaLoaiSanPham] nchar(10) NULL,
	CONSTRAINT pk_NhomHang PRIMARY KEY ([MaNhomHang])
)
GO
ALTER TABLE [NhomHang]
ADD CONSTRAINT fk_NhomHang_LoaiSanPham FOREIGN KEY ([MaLoaiSanPham]) REFERENCES [LoaiSanPham] ([MaLoaiSanPham]);
--Bang MatHang
CREATE TABLE [MatHang](
	[MaHang] nchar(20) NOT NULL,
	[MaNhomHang] nchar(10) NULL,
	[MaHangSX] nchar(10) NULL,
	[TenHang] nvarchar(100) NULL,
	[DonViTinh] nvarchar(50) NULL,
	[GiaBan] int NULL,
	[VAT] int NULL,
	[TonQuay] int NULL,
	[TonKho] int NULL,
	[TonQuayToiThieu] int NULL,
	[TonKhoToiThieu] int NULL
	CONSTRAINT pk_MatHang PRIMARY KEY ([MaHang])
)
GO
ALTER TABLE [MatHang]
ADD CONSTRAINT fk_MatHang_NhomHang FOREIGN KEY ([MaNhomHang]) REFERENCES [NhomHang] ([MaNhomHang])
GO
ALTER TABLE [MatHang]
ADD CONSTRAINT fk_MatHang_HangSX FOREIGN KEY ([MaHangSX]) REFERENCES [HangSX] ([MaHangSX]);
--Bang PhieuQuaTang
CREATE TABLE [PhieuQuaTang](
	[MaPhieuQuaTang] nchar(13) NOT NULL,
	[TriGiaPhieu] float NULL,
	[HanSuDung] datetime NULL,
	[TrangThai] bit NULL,
	[NgayCapNhat] datetime NULL,
	CONSTRAINT pk_PhieuQuaTang PRIMARY KEY ([MaPhieuQuaTang])
);
--Bang LoaiHoaDon
CREATE TABLE [LoaiHoaDon](
	[MaLoaiHoaDon] nchar(10) NOT NULL,
	[TenLoaiHoaDon] nvarchar(100) NULL,
	CONSTRAINT pk_LoaiHoaDon PRIMARY KEY ([MaLoaiHoaDon])
);

--Bang HoaDonBanHang
CREATE TABLE [HoaDonBanHang](
	[SoHoaDon] nchar(13) NOT NULL,
	[MaLoaiHoaDon] nchar(10) NULL,
	[MaNV] nchar(10) NULL,
	[MaKhach] nchar(10) NULL,
	[TenKhachHang] nvarchar(50) NULL,
	[DiaChi] nvarchar(200) NULL,
	[SDT] nchar(13) NULL,
	[NgayThang] datetime NULL,
	[TongTien] float NULL,
	[ChietKhauHoaDon] float NULL,
	[DaThanhToan] float NULL,
	[KetQua] nvarchar(50) NULL,
	[MaPhieuQuaTang] nchar(13) NULL,
	[TriGiaPQT] float NULL,
	[DuocNhanPQT] bit NULL,
	CONSTRAINT pk_HoaDonBanHang PRIMARY KEY ([SoHoaDon])
)

GO
ALTER TABLE [HoaDonBanHang]
ADD CONSTRAINT fk_HoaDonBanHang_KhachHang FOREIGN KEY ([MaKhach]) REFERENCES [KhachHang] ([MaKhach])
GO
ALTER TABLE [HoaDonBanHang]
ADD CONSTRAINT fk_HoaDonBanHang_LoaiHoaDon FOREIGN KEY ([MaLoaiHoaDon]) REFERENCES [LoaiHoaDon] ([MaLoaiHoaDon])
GO
ALTER TABLE [HoaDonBanHang]
ADD CONSTRAINT fk_HoaDonBanHang_NhanVien FOREIGN KEY ([MaNV]) REFERENCES [NhanVien] ([MaNV])
GO
ALTER TABLE [HoaDonBanHang]
ADD CONSTRAINT fk_HoaDonBanHang_PhieuQuaTang FOREIGN KEY ([MaPhieuQuaTang]) REFERENCES [PhieuQuaTang] ([MaPhieuQuaTang]);
--Bang ChiTietHoaDonBH
CREATE TABLE [ChiTietHoaDonBH](
	[SoHoaDon] nchar(13) NOT NULL,
	[MaHang] nchar(20) NOT NULL,
	[SoLo] int NOT NULL,
	[SoLuong] int NULL,
	[GiaBan] int NULL,
	[ChietKhauMatHang] int NULL,
	[ThanhTien] int NULL,
	CONSTRAINT pk_ChiTietHoaDonBH PRIMARY KEY ([SoHoaDon],[MaHang],[SoLo])
)
GO
ALTER TABLE [ChiTietHoaDonBH]
ADD CONSTRAINT fk_ChiTietHoaDonBH_HoaDonBanHang FOREIGN KEY ([SoHoaDon]) REFERENCES [HoaDonBanHang] ([SoHoaDon])
GO
ALTER TABLE [ChiTietHoaDonBH]
ADD CONSTRAINT fk_ChiTietHoaDonBH_MatHang FOREIGN KEY ([MaHang]) REFERENCES [MatHang] ([MaHang]);

--Bang HoaDonNH
CREATE TABLE [HoaDonNhapHang](
	[SoHoaDon] nchar(13) NOT NULL,
	[MaLoaiHoaDon] nchar(10) NULL,
	[MaNV] nchar(10) NULL,
	[MaNCC] nchar(10) NULL,
	[NgayThang] datetime NULL,
	[SoHoaDonLienQuan] nchar(13) NULL,
	[TongTien] float NULL,
	[ChietKhauHoaDon] float NULL,
	[DaThanhToan] float NULL,
	CONSTRAINT pk_HoaDonNhapHang PRIMARY KEY ([SoHoaDon])
)
GO
ALTER TABLE [HoaDonNhapHang]
ADD CONSTRAINT fk_HoaDonMuaHang_NhaCC FOREIGN KEY ([MaNCC]) REFERENCES [NhaCC] ([MaNCC])
GO
ALTER TABLE [HoaDonNhapHang]
ADD CONSTRAINT fk_HoaDonNhapHang_NhanVien FOREIGN KEY ([MaNV]) REFERENCES [NhanVien] ([MaNV]);
GO
ALTER TABLE [HoaDonNhapHang]
ADD CONSTRAINT fk_HoaDonNhapHang_LoaiHoaDon FOREIGN KEY ([MaLoaiHoaDon]) REFERENCES [LoaiHoaDon] ([MaLoaiHoaDon]);
--Bang ChiTietHoaDonNH
CREATE TABLE [ChiTietHoaDonNH](
	[SoHoaDon] nchar(13) NOT NULL,
	[MaHang] nchar(20) NOT NULL,
	[SoLo] int NOT NULL,
	[SoLuong] int NULL,
	[GiaNhap] float NULL,
	[ChietKhauMatHang] int NULL,
	[ThanhTien] float NULL,
	CONSTRAINT pk_ChiTietHoaDonNH PRIMARY KEY ([SoHoaDon],[MaHang],[SoLo])
)
GO
ALTER TABLE [ChiTietHoaDonNH]
ADD  CONSTRAINT fk_ChiTietHoaDonMH_HoaDonMuaHang FOREIGN KEY ([SoHoaDon]) REFERENCES [HoaDonNhapHang] ([SoHoaDon])
GO
ALTER TABLE [ChiTietHoaDonNH]
ADD  CONSTRAINT fk_ChiTietHoaDonMH_MatHang FOREIGN KEY ([MaHang]) REFERENCES [MatHang] ([MaHang]);

--Bang User
CREATE TABLE [tblUser](
	[TenDangNhap] nvarchar(50) NOT NULL,
	[MatKhau] nvarchar(50) NULL,
	[MaNV] nchar(10) NULL,
	[Role] int NULL,
	CONSTRAINT pk_tblUser PRIMARY KEY ([TenDangNhap])
)
GO

ALTER TABLE [tblUser]
ADD CONSTRAINT fk_tblUser_NhanVien FOREIGN KEY ([MaNV]) REFERENCES [NhanVien] ([MaNV]);
