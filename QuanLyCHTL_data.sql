USE [QuanLyCuaHangGS25]
GO

--Nocheck FK constraints
ALTER TABLE [dbo].[ChiTietHoaDonBH] NOCHECK CONSTRAINT fk_ChiTietHoaDonBH_HoaDonBanHang;
ALTER TABLE [dbo].[ChiTietHoaDonBH] NOCHECK CONSTRAINT fk_ChiTietHoaDonBH_MatHang;
ALTER TABLE [dbo].[ChiTietHoaDonNH] NOCHECK CONSTRAINT fk_ChiTietHoaDonMH_HoaDonMuaHang;
ALTER TABLE [dbo].[ChiTietHoaDonNH] NOCHECK CONSTRAINT fk_ChiTietHoaDonMH_MatHang;
ALTER TABLE [dbo].[ChucVu] NOCHECK CONSTRAINT fk_ChucVu_BoPhan;
ALTER TABLE [dbo].[HoaDonBanHang] NOCHECK CONSTRAINT fk_HoaDonBanHang_KhachHang;
ALTER TABLE [dbo].[HoaDonBanHang] NOCHECK CONSTRAINT fk_HoaDonBanHang_LoaiHoaDon;
ALTER TABLE [dbo].[HoaDonBanHang] NOCHECK CONSTRAINT fk_HoaDonBanHang_NhanVien;
ALTER TABLE [dbo].[HoaDonBanHang] NOCHECK CONSTRAINT fk_HoaDonBanHang_PhieuQuaTang;
ALTER TABLE [dbo].[HoaDonNhapHang] NOCHECK CONSTRAINT fk_HoaDonMuaHang_NhaCC;
ALTER TABLE [dbo].[HoaDonNhapHang] NOCHECK CONSTRAINT fk_HoaDonNhapHang_NhanVien;
ALTER TABLE [dbo].[CongNoNCC] NOCHECK CONSTRAINT fk_CongNoNCC_NhaCC;
ALTER TABLE [dbo].[MatHang] NOCHECK CONSTRAINT fk_MatHang_HangSX;
ALTER TABLE [dbo].[MatHang] NOCHECK CONSTRAINT fk_MatHang_NhomHang;
ALTER TABLE [dbo].[NhanVien] NOCHECK CONSTRAINT fk_NhanVien_ChucVu;
ALTER TABLE [dbo].[NhomHang] NOCHECK CONSTRAINT fk_NhomHang_LoaiSanPham;

--Du lieu bang BoPhan
INSERT INTO [dbo].[BoPhan] ([MaBoPhan],[TenBoPhan])
VALUES 
	('01', N'Bộ phận bán hàng'),														
	('02', N'Bộ phận kho'),
    ('03', N'Bộ phận quản lý'),															
	('04', N'Bộ phận kế toán')																
GO
--Du lieu bang ChucVu
INSERT INTO [dbo].[ChucVu] ([MaCV],[TenCV],[MaBoPhan])
VALUES
    ('01',N'Nhân viên bán hàng','01'),
	('02',N'Nhân viên Marketing','01'),
	('03',N'Trưởng bộ phận bán hàng','01'),
	('04',N'Thủ kho','02'),
	('05',N'Phụ kho','02'),
    ('06',N'Quản lý trưởng cửa hàng','03'),
    ('07',N'Nhân viên quản lý','03'),
	('08',N'Kế toán kho','04'),
	('09',N'Thủ quỹ','04'),
    ('10',N'Kế toán trưởng','04')
GO
--Du lieu bang NhanVien
INSERT INTO [dbo].[NhanVien] ([MaNV],[MaCV],[TenNV],[DiaChi],[Img],[SDT],[SoCMND]
			,[SoTaiKhoan],[NgaySinh],[GioiTinh],[TrangThai])
VALUES
	('00001','01',N'Nguyễn Thị Phương',N'Hà Nội','','0122344','2344566','234455','2012-04-02',N'Nữ',N'Sẵn sàng'),
	('00002','01',N'Nguyễn Lan Hương',N'Hà Nội','','2234','12344','3333','1988-03-02',N'Nữ',N'Sẵn sàng'),
	('00003','01',N'Hoàng Thu Ngân',N'Hà Nội','','335446574','465464645','45345453','1988-04-23',N'Nữ',N'Sẵn sàng'),
	('00005','01',N'Nguyễn Hoàng Nam',N'Hà Nội','','335354','3432535','45454','2012-04-02',N'Nữ',N'Sẵn sàng'),
	('00006','01',N'Nguyễn Thị Bích',N'Hà Nội','','3446554','4546557','53454577','2012-04-02',N'Nữ',N'Sẵn sàng'),
	('00007','01',N'Phạm Văn Tài',N'Hà Nội','','34354546','4465657','5654656','1986-04-11',N'Nam',N'Sẵn sàng'),
	('00008','01',N'Nguyễn Hoàng Hải',N'Hà Nội','','4546546','34535364','43453535','1985-04-03',N'Nam',N'Sẵn sàng'),
	('00009','01',N'Lê Văn Thịnh',N'Hà Nội','','433545','435454','454345435','2012-04-02',N'Nam',N'Sẵn sàng'),
	('00010','01',N'Nguyễn Quang Hà',N'Hà Nội','','3435454','434543543','43454543','2012-04-02',N'Nam',N'Sẵn sàng'),
	('00011','03',N'Phạm Thanh Tùng',N'Hà Nội','','4543535','4453454','4345345','2012-04-02',N'Nam',N'Sẵn sàng'),
	('00012','04',N'Nguyễn Tuấn Tài',N'Hà Nội','','4545543','5354364','4345354','1987-04-02',N'Nam',N'Sẵn sàng'),
	('00013','05',N'Nguyễn Bích Vân',N'Hà Nội','','3454546','56545656','545656','2012-04-02',N'Nữ',N'Sẵn sàng'),
	('00014','05',N'Nguyễn Phương Thảo',N'Hà nội','','44545555','5554323433','34343434','1987-04-02',N'Nữ',N'Sẵn sàng'),
	('00015','06',N'Trần Minh Thu',N'Hà nội','','44566767','66453454','45465555','1981-09-01',N'Nữ',N'Sẵn sàng'),
	('00016','07',N'Nguyễn Minh Tiến',N'Hà nội','','334567677','76767776777','767767677676','2012-04-02',N'Nam',N'Sẵn sàng'),
	('00017','01',N'Nguyễn Phương Dung',N'Hà nội','','4545454545','45345456','4446636','1982-04-02',N'Nữ',N'Sẵn sàng'),
	('00018','08',N'Lê Hoài Nam',N'Hà nội','','7498849','44499494','3823892','1987-04-02',N'Nam',N'Sẵn sàng'),
	('00019','09',N'Nguyễn Thanh Tùng',N'Hà nội','','34554323','4555534','44344','1988-04-02',N'Nam',N'Sẵn sàng'),
	('00020','10',N'Lê Thanh Bình',N'Hà nội','','344555','55553434','535355','1988-04-02',N'Nam',N'Sẵn sàng')
GO
--Du lieu bang KhachHang
INSERT INTO [dbo].[KhachHang] ([MaKhach],[TenKhach],[GioiTinh] ,[DiaChi],[SDT],[SoCMND],[SoTaiKhoan],[SoDiemThuong])
VALUES
	('00001',N'Nguyễn Thị Phượng',N'Nữ',N'Ha noi','2344','2334','22235',77),
	('00002',N'Phan Thị Bích',N'Nữ',N'Hà Nội','4455656','565656','3232434',43),
	('00003',N'Nguyễn Hoài Nam',N'Nữ',N'Hà Nội','22323','213213','213123',93),
	('00007',N'Phan Văn Bình',N'Nam',N'Hà Nội','3242343','323434','323424',0),
	('00004',N'Lương Quốc Huy',N'Nam',N'Hà Nội','343242','323434','323434',0),
	('00008',N'Hoàng Tú Bình',N'Nữ',N'Hà Nội','32434','3424','4323424',0),
	('00005',N'Nguyễn Lan Phương',N'Nữ',N'Hà Nội','3545345','45455','43435',0),
	('00009',N'Trần Quốc Tuấn',N'Nam',N'Hà Nội','34234','34234','32434',0),
	('00010',N'Đinh Văn Tài',N'Nam',N'Hà Nội','342343','3234','342434',0),
	('00006',N'Lê Đức Thọ',N'Nam',N'Hà Nội','3235345','45435','353453',0)
GO

--Du lieu bang NhaCC
INSERT INTO [dbo].[NhaCC] ([MaNCC],[TenNCC],[DiaChi],[SDT],[SoFax],[SoTaiKhoan],[MaSoThue],[No],[Co])
VALUES			
	('NCC00001',N'Công ty Thực phẩm An Phú',N'102 Nguyễn Du; 64-66 Trần Hưng Đạo, Quận 1','4345345','43545','543535','45345345',240000000,294000000),
	('NCC00002',N'Công ty Thực phẩm Thiên Luân',N'Hà Nội','35354646','565757','4665657','454546',160000000,174500000),
	('NCC00003',N'Công ty TNHH Ninh An',N'Hà Nội','3423434','342434','34234234','342434',140000000,143000000),
	('NCC00004',N'Công ty Bánh kẹo Biscafun',N'Hà Nội','3324324','323424','3424234','32343',12000000,12000000),
	('NCC00005',N'Công ty Philips Việt Nam',N'Tầng 16, Tòa nhà Ladeco, 266 Đội Cấn, Quận Ba Đình','(04) 3 7346484','(04) 3 7346482','4566','65656',0,0),
	('NCC00006',N'CÔNG TY Nước giải khát Hòa Bình',N'248A Nơ Trang Long, Phường 12, Quận Bình Thạnh, Tp. Hồ Chí Minh','(08) 3841 4488','(08) 3841 4477','6566','656665',30000000,36000000),
	('NCC00007',N'Công ty Cổ phần Sản xuất và Thương mại Dược phẩm Hông Phúc',N'Tầng 35, tòa nhà Keangnam Landmark Tower, Phạm Hùng, Hà nội','04.39345110','564767','56456','55667',28000000,85300000)
GO	
--Du lieu bang CongNoNCC
INSERT INTO [dbo].[CongNoNCC] ([Ngay],[SoHoaDon] ,[MaNCC],[DauKy],[PhatSinhTang],[PhatSinhGiam] ,[CuoiKy],[DienGiai])
VALUES
	('2013-03-21 00:00:00.000','PNH00001','NCC00001',0,65000000,60000000,5000000,null),
	('2013-03-21 00:00:00.000','PNH00002','NCC00001',5000000,91000000,75000000,21000000,null),	
	('2013-03-21 00:00:00.000','PNH00003','NCC00001',21000000,25000000,15000000,31000000,null),	
	('2013-03-21 00:00:00.000','PNH00004','NCC00002',0,89500000,80000000,9500000,null),
	('2013-03-21 00:00:00.000','PNH00005','NCC00002',9500000,85000000,80000000,14500000,null),	
	('2013-03-21 00:00:00.000','PNH00006','NCC00007',0,56500000,0,56500000,null),	
	('2013-03-21 00:00:00.000','PNH00007','NCC00007',56500000,28800000,28000000,57300000,null),	
	('2013-03-21 00:00:00.000','PNH00008','NCC00004',0,12000000,12000000,0,null),
	('2013-03-21 00:00:00.000','PNH00009','NCC00001',31000000,45000000,30000000,46000000,null),	
	('2013-03-21 00:00:00.000','PNH00010','NCC00006',0,36000000,30000000,6000000,null),
	('2013-03-21 00:00:00.000','PNH00011','NCC00008',0,18000000,18000000,0,null),
	('2013-03-21 00:00:00.000','PNH00012','NCC00003',0,40500000,40000000,500000,null),
	('2013-03-21 00:00:00.000','PNH00013','NCC00001',46000000,68000000,60000000,54000000,null),	
	('2013-03-21 00:00:00.000','PNH00014','NCC00003',500000,102500000,100000000,3000000,null)
GO


--Du lieu bang HangSX
INSERT INTO [dbo].[HangSX] ([MaHangSX],[TenHangSX])
VALUES
	('01',N'An Phú'),
	('02',N'Hảo Hảo'),
	('03',N'Thiên Ân'),
	('04',N'Kinh Đô'),
	('05',N'Nestlé'),
	('06',N'Hai Lúa'),
	('07',N'PS'),
	('08',N'Clear'),
	('09',N'Listerine'),
	('11',N'Lays'),
	('12',N'Posca'),
	('13',N'Oshi'),
	('14',N'Dures')
GO

--Du lieu bang LoaiSanPham
INSERT INTO [dbo].[LoaiSanPham] ([MaLoaiSanPham],[TenLoaiSanPham])
VALUES
	('01',N'Đồ ăn'),
	('02',N'Đồ uống'),
	('03',N'Hàng thông dùng')
GO
--Du lieu bang NhomHang
INSERT INTO [dbo].[NhomHang] ([MaNhomHang],[TenNhomHang],[MaLoaiSanPham])
VALUES
	('DoHop',N'Đồ hộp','01'),       
	('Mi',N'Mì','01'),        
	('BanhBao',N'Bánh bao','01'),        
	('BanhTuoi',N'Bánh tươi','01'),        
	('Snack',N'Sanck','01'),        
	('CaPheVN',N'Cà phê Việt Nam','02'),        
	('TraSua',N'Trà Sữa','02'),        
	('HoaMyPham',N'Hóa mỹ phẩm','03'),        
	('BanhKeo',N'Bánh kẹo','01'),        
	('Ruou',N'Rượu','02'),        
	('NuocGK',N'Nước giải khát','02'),        
	('Bia',N'Bia','02')      
	        
GO
--Du lieu bang MatHang
INSERT INTO [dbo].[MatHang] ([MaHang],[MaNhomHang],[MaHangSX],[TenHang],[DonViTinh]
			,[GiaBan],[VAT],[TonQuay],[TonKho],[TonQuayToiThieu],[TonKhoToiThieu])
VALUES
	('DGN1','DoHop','01',N'Đùi gà nướng vị cay',N'Chiếc',30000,12,3,4,2,5),
	('DGN2','DoHop','01',N'Đùi gà nướng vị Teriyaki',N'Chiếc',35000,2,0,2,2,5),
	('MIT1','Mi','02',N'Mì trộn xúc xích trứng chiên',N'Hộp',19000,2,0,10,1,4),
	('BBA1','BanhBao','03',N'Bánh bao trứng cút',N'Chiếc',23000,2,0,0,1,4),
	('BBA2','BanhBao','03',N'Bánh bao khoai môn',N'Chiếc',25000,2,0,0,2,6),
	('BTU1','BanhTuoi','04',N'Bánh mì sữa Kinh Đô',N'Chiếc',11000,2,0,8,1,4),
	('BTU2','BanhTuoi','04',N'Bánh mì chà bông Kinh Đô',N'Chiếc',11000,2,0,0,1,4),
	('CFF1','CaPheVN','05',N'Cà phê phin sữa nóng',N'Ly',20000,2,0,3,1,4),
	('CFF2','CaPheVN','05',N'Cà phê sữa tươi',N'Ly',19000,2,0,10,1,4),
	('TSU1','TraSua','06',N'Trà sữa Thái (Xanh)',N'Ly',25000,2,0,3,1,4),
	('KDR1','HoaMyPham','07',N'Kem đánh răng PS',N'Hộp',42900,10,-1,3,1,4),
	('DGD1','HoaMyPham','08',N'Dầu gội đầu Clear',N'Chai',90000,2,0,4,1,4),
	('NSM1','HoaMyPham','09',N'Nước súc miệng Listerine',N'Chai',100000,2,0,9,1,4),
	('SNK1','Snack','10',N'Snack khoai tây Lays',N'Bịch',10000,2,0,4,2,5),
	('SNK2','Snack','11',N'Snack Pocas vị Mực lăn muối ớt',N'Bịch',10000,2,0,5,1,4),
	('SNK3','Snack','12',N'Snack Oshi vị tôm cay',N'Bịch',10000,2,0,8,1,4)
GO

--Du lieu bang LoaiHoaDon
INSERT INTO [dbo].[LoaiHoaDon] ([MaLoaiHoaDon] ,[TenLoaiHoaDon])
VALUES	   
	('HDB',N'Hóa đơn bán hàng'),
	('PNH',N'Phiếu nhập hàng'),
	('HDQ',N'Hóa đơn xuất quầy'),
	('PCC',N'Phiếu chi')
GO

--Du lieu bang HoaDonBanHang
INSERT INTO [dbo].[HoaDonBanHang] ([SoHoaDon],[MaLoaiHoaDon],[MaNV],[MaKhach],[TenKhachHang],[DiaChi]
			,[SDT],[NgayThang],[TongTien],[ChietKhauHoaDon],[DaThanhToan],[KetQua]
			,[MaPhieuQuaTang],[TriGiaPQT],[DuocNhanPQT])
VALUES
	('HDB00001','HDB','00001','00001',N'Nguyễn Thị Phượng',N'Ha noi','2344','2013-03-21 00:00:00.000',348000,0,300000,'',NULL,0,'False'),
	('HDB00002','HDB','00002','00002',N'Phan Thị Bích',N'Hà Nội','4455656','2013-03-21 00:00:00.000',460000,0,360000,'',NULL,0,'False'),
	('HDB00003','HDB','00003','00003',N'Nguyễn Hoài Nam',N'Hà Nội','22323','2013-03-21 00:00:00.000',206000,0,0,'',NULL,0,'False'),
	('HDB00004','HDB','00004','00004',N'Lương Quốc Huy',N'Hà Nội','343242','2013-03-21 00:00:00.000',675000,0,400000,'',NULL,0,'False'),
	('HDB00005','HDB','00005','00005',N'Nguyễn Lan Phương',N'Hà Nội','3545345','2013-03-21 00:00:00.000',310000,0,300000,'',NULL,0,'False'),
	('HDB00006','HDB','00006','00006',N'Lê Đức Thọ',N'Hà Nội','3235345','2013-03-21 00:00:00.000',440000,0,400000,'',NULL,0,'False')
GO
--Du lieu bang ChiTietHoaDonBH
INSERT INTO [dbo].[ChiTietHoaDonBH] ([SoHoaDon],[MaHang],[SoLo],[SoLuong],[GiaBan],[ChietKhauMatHang],[ThanhTien])
VALUES 
	('HDB00001','DGN1',1,3,72000,0,216000),
	('HDB00001','SNK1',1,3,44000,0,132000),
	('HDB00002','BBA1',1,5,60000,0,300000),
	('HDB00002','BTU2',1,2,80000,0,160000),
	('HDB00003','CFF2',1,2,103000,0,206000),
	('HDB00004','DGN1',1,2,120000,0,240000),
	('HDB00004','CFF2',1,2,145000,0,290000),
	('HDB00004','CFF1',2,1,145000,0,145000),
	('HDB00005','SNK1',1,3,70000,0,210000),
	('HDB00005','DGN1',1,2,50000,0,100000),
	('HDB00006','BBA1',1,2,145000,0,290000),
	('HDB00006','BTU2',1,3,50000,0,150000),
	('HDL00001','KDR1',1,1,149000,0,149900),
	('HDL00002','DGN1',1,1,42900,0,429000),
	('HDQ00001','KDR1',1,1,77400,0,77400),
	('HDQ00002','KDR1',1,1,42900,0,42900)
GO

--Du lieu bang HoaDonNhapHang
INSERT INTO [dbo].[HoaDonNhapHang] ([SoHoaDon],[MaLoaiHoaDon],[MaNV],[MaNCC],[NgayThang]
			,[SoHoaDonLienQuan],[TongTien],[ChietKhauHoaDon],[DaThanhToan])
VALUES
	('PNH00001','PNH','00012','NCC00001','2013-03-21 00:00:00.000','443434',650000,0,600000),
	('PNH00002','PNH','00012','NCC00001','2013-03-21 00:00:00.000','46543333',910000,0,7500000),
	('PNH00003','PNH','00012','NCC00001','2013-03-21 00:00:00.000','333333',250000,0,1500000),
	('PNH00004','PNH','00012','NCC00002','2013-03-21 00:00:00.000','45545',895000,0,8000000),
	('PNH00005','PNH','00013','NCC00002','2013-03-21 00:00:00.000','22323',850000,0,8000000),
	('PNH00006','PNH','00013','NCC00007','2013-03-21 00:00:00.000','4343',565000,0,0),
	('PNH00007','PNH','00013','NCC00007','2013-03-21 00:00:00.000','45454',288000,0,2800000),
	('PNH00008','PNH','00013','NCC00004','2013-03-21 00:00:00.000','33434',120000,0,1200000),
	('PNH00009','PNH','00013','NCC00001','2013-03-21 00:00:00.000','3343434',4500000,0,3000000),
	('PNH00010','PNH','00014','NCC00006','2013-03-21 00:00:00.000','3424324',360000,0,3000000),
	('PNH00011','PNH','00014','NCC00008','2013-03-21 00:00:00.000','3434355',180000,0,1800000),
	('PNH00012','PNH','00014','NCC00003','2013-03-21 00:00:00.000','6655555',400000,0,400000),
	('PNH00013','PNH','00014','NCC00001','2013-03-21 00:00:00.000','4353709',680000,0,600000),
	('PNH00014','PNH','00014','NCC00003','2013-03-21 00:00:00.000','54456456',1050000,0,1000000)
GO

--Du lieu bang ChiTietHoaDonNH
INSERT INTO [dbo].[ChiTietHoaDonNH] ([SoHoaDon],[MaHang],[SoLo],[SoLuong],[GiaNhap],[ChietKhauMatHang],[ThanhTien]) 
VALUES
	('PNH00001','DGN1',1,5,13000000,0,65000000),
	('PNH00002','DGN2',2,5,13200000,0,66000000),
	('PNH00002','NSM1',1,5,5000000,0,25000000),
	('PNH00003','BBA1',1,5,5000000,0,25000000),
	('PNH00004','SNK1',1,7,6500000,0,45500000),
	('PNH00004','SNK2',1,4,11000000,0,44000000),
	('PNH00005','CFF1',1,5,13000000,0,65000000),
	('PNH00005','CFF2',1,5,4000000,0,20000000),
	('PNH00006','DGD1',1,5,700000,0,3500000),
	('PNH00006','KDR1',1,5,430000,0,2150000),
	('PNH00007','KDR1',1,4,270000,0,1080000),
	('PNH00007','KDR1',2,4,450000,0,1800000),
	('PNH00008','TSU1',1,4,300000,0,1200000),
	('PNH00009','TSU1',1,5,900000,0,4500000),
	('PNH00010','SNK3',1,3,120000,0,3600000),
	('PNH00011','SNK3',1,3,600000,0,1800000),
	('PNH00012','BTU1',1,3,350000,0,1050000),
	('PNH00012','BTU2',1,3,100000,0,3000000),
	('PNH00013','BTU1',2,5,460000,0,2300000),
	('PNH00013','CFF1',2,5,900000,0,4500000),
	('PNH00014','CFF1',2,5,350000,0,1750000),
	('PNH00015','CFF2',2,5,1300000,0,6500000),
	('PNH00016','CFF2',2,5,400000,0,2000000)
GO
--Du lieu bang PhieuChi

--Du lieu bang PhieuChuyenKho

--Du lieu bang PhieuQuaTang
INSERT INTO [dbo].[PhieuQuaTang] ([MaPhieuQuaTang],[TriGiaPhieu],[HanSuDung],[TrangThai],NgayCapNhat)
VALUES
	('2131317333001',100000,'2013-03-23 14:36:48.000','False',NULL),
	('2131317333002',100000,'2013-03-23 14:36:48.000','False',NULL),
	('2131317333003',100000,'2013-03-23 14:36:48.000','False',NULL),
	('2131317333004',100000,'2013-03-23 14:36:48.000','False',NULL),
	('2131317333005',100000,'2013-03-23 14:36:48.000','False',NULL),
	('2131317333006',100000,'2013-03-23 14:36:48.000','False',NULL),
	('2131317333007',100000,'2013-03-23 14:36:48.000','False',NULL)
GO

--Du lieu bang tblUser
INSERT INTO [dbo].[tblUser] ([TenDangNhap],[MatKhau],[MaNV],[Role])
VALUES
	('admin','12345','00001',N'Admin'),
	('BichVan','12345','00013',N'Nhập hàng'),
	('Huong','12345','00002',N'Bán hàng'),
	('Ngan','12345','00003',N'Bán hàng'),
	('Phuong','12345','00001',N'Bán hàng'),
	('Tai','12345','00012',N'Bán hàng')
GO

--Check FK constraints
ALTER TABLE [dbo].[ChiTietHoaDonBH] CHECK CONSTRAINT fk_ChiTietHoaDonBH_HoaDonBanHang;
ALTER TABLE [dbo].[ChiTietHoaDonBH] CHECK CONSTRAINT fk_ChiTietHoaDonBH_MatHang;
ALTER TABLE [dbo].[ChiTietHoaDonNH] CHECK CONSTRAINT fk_ChiTietHoaDonMH_HoaDonMuaHang;
ALTER TABLE [dbo].[ChiTietHoaDonNH] CHECK CONSTRAINT fk_ChiTietHoaDonMH_MatHang;
ALTER TABLE [dbo].[ChucVu] CHECK CONSTRAINT fk_ChucVu_BoPhan;
ALTER TABLE [dbo].[HoaDonBanHang] CHECK CONSTRAINT fk_HoaDonBanHang_KhachHang;
ALTER TABLE [dbo].[HoaDonBanHang] CHECK CONSTRAINT fk_HoaDonBanHang_LoaiHoaDon;
ALTER TABLE [dbo].[HoaDonBanHang] CHECK CONSTRAINT fk_HoaDonBanHang_NhanVien;
ALTER TABLE [dbo].[HoaDonBanHang] CHECK CONSTRAINT fk_HoaDonBanHang_PhieuQuaTang;
ALTER TABLE [dbo].[HoaDonNhapHang] CHECK CONSTRAINT fk_HoaDonMuaHang_NhaCC;
ALTER TABLE [dbo].[HoaDonNhapHang] CHECK CONSTRAINT fk_HoaDonNhapHang_NhanVien;
ALTER TABLE [dbo].[CongNoNCC] CHECK CONSTRAINT fk_CongNoNCC_NhaCC;
ALTER TABLE [dbo].[MatHang] CHECK CONSTRAINT fk_MatHang_HangSX;
ALTER TABLE [dbo].[MatHang] CHECK CONSTRAINT fk_MatHang_NhomHang;
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT fk_NhanVien_ChucVu;
ALTER TABLE [dbo].[NhomHang] CHECK CONSTRAINT fk_NhomHang_LoaiSanPham;