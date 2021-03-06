USE [master]
GO
/****** Object:  Database [BTL_HSK]    Script Date: 11/24/2021 9:12:23 AM ******/
CREATE DATABASE [BTL_HSK]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BTL_HSK', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\BTL_HSK.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BTL_HSK_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\BTL_HSK_log.ldf' , SIZE = 784KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BTL_HSK] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BTL_HSK].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BTL_HSK] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BTL_HSK] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BTL_HSK] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BTL_HSK] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BTL_HSK] SET ARITHABORT OFF 
GO
ALTER DATABASE [BTL_HSK] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BTL_HSK] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [BTL_HSK] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BTL_HSK] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BTL_HSK] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BTL_HSK] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BTL_HSK] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BTL_HSK] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BTL_HSK] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BTL_HSK] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BTL_HSK] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BTL_HSK] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BTL_HSK] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BTL_HSK] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BTL_HSK] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BTL_HSK] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BTL_HSK] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BTL_HSK] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BTL_HSK] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BTL_HSK] SET  MULTI_USER 
GO
ALTER DATABASE [BTL_HSK] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BTL_HSK] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BTL_HSK] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BTL_HSK] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [BTL_HSK]
GO
/****** Object:  StoredProcedure [dbo].[nhanvien_get]    Script Date: 11/24/2021 9:12:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[nhanvien_get]
as
begin
	select * from tbl_nhanvien
end
GO
/****** Object:  StoredProcedure [dbo].[quyen_get]    Script Date: 11/24/2021 9:12:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[quyen_get]
as
begin
	select * from tbl_quyen
end
GO
/****** Object:  StoredProcedure [dbo].[sp_dangnhap]    Script Date: 11/24/2021 9:12:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[sp_dangnhap] @sTendangnhap varchar(50), @sMatkhau varchar(255)
as
begin
	select * from tbl_taikhoan
	inner join tbl_quyen on tbl_taikhoan.FK_QuyenID = tbl_quyen.PK_QuyenID where sTendangnhap = @sTendangnhap and sMatkhau = @sMatkhau
end

GO
/****** Object:  StoredProcedure [dbo].[sp_doimatkhau]    Script Date: 11/24/2021 9:12:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_doimatkhau] @sTendangnhap varchar(50), @sMatkhaumoi varchar(255)
as
begin
	update tbl_taikhoan
	set sMatkhau = @sMatkhaumoi
	where sTendangnhap = @sTendangnhap
end
GO
/****** Object:  StoredProcedure [dbo].[sp_PhongbanDelete]    Script Date: 11/24/2021 9:12:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_PhongbanDelete] @PK_PhongbanID int
as
begin
	delete from tbl_phongban where PK_PhongbanID = @PK_PhongbanID
end

GO
/****** Object:  StoredProcedure [dbo].[sp_Phongbanget]    Script Date: 11/24/2021 9:12:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_Phongbanget]
as
begin
select * from tbl_phongban
	
end
GO
/****** Object:  StoredProcedure [dbo].[sp_PhongbanInsert]    Script Date: 11/24/2021 9:12:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[sp_PhongbanInsert] @sTenphong nvarchar(50), @sPhutrach nvarchar(50), @dNgaythanhlap smalldatetime
as
begin

INSERT INTO [dbo].[tbl_phongban]
           ([sTenphong]
           ,[sPhutrach]
           ,[dNgaythanhlap])
     VALUES
           (@sTenphong
           ,@sPhutrach
           ,@dNgaythanhlap)
end

GO
/****** Object:  StoredProcedure [dbo].[sp_PhongbanUpdate]    Script Date: 11/24/2021 9:12:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[sp_PhongbanUpdate] @PK_PhongbanID int, @sTenphong nvarchar(50), @sPhutrach nvarchar(50), @dNgaythanhlap smalldatetime
as
begin
	update tbl_phongban
	set sTenphong = @sTenphong,
	sPhutrach = @sPhutrach,
	dNgaythanhlap = @dNgaythanhlap
	where PK_PhongbanID = @PK_PhongbanID
end
GO
/****** Object:  StoredProcedure [dbo].[sp_taikhoanDelete]    Script Date: 11/24/2021 9:12:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_taikhoanDelete] @PK_TaikhoanID int
as
begin
	delete from tbl_taikhoan where PK_TaikhoanID = @PK_TaikhoanID
end
GO
/****** Object:  StoredProcedure [dbo].[spTaikhoan_Delete]    Script Date: 11/24/2021 9:12:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[spTaikhoan_Delete]  @PK_TaikhoanID int
as
begin
	delete from tbl_taikhoan
	where PK_TaikhoanID = @PK_TaikhoanID
end
GO
/****** Object:  StoredProcedure [dbo].[spTaikhoan_Insert]    Script Date: 11/24/2021 9:12:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spTaikhoan_Insert] @PK_TaikhoanID int OUTPUT, @sTendangnhap nvarchar(50),@sMatkhau varchar(255), @FK_NhanvienID int, @FK_QuyenID int
as
begin
	INSERT INTO [dbo].[tbl_taikhoan]
           ([sTendangnhap]
           ,[sMatkhau]
           ,[FK_NhanvienID]
           ,[FK_QuyenID])
     VALUES
           (@sTendangnhap
           ,@sMatkhau
           ,@FK_NhanvienID
           ,@FK_QuyenID)
	Set @PK_TaikhoanID = @@IDENTITY
end 
GO
/****** Object:  StoredProcedure [dbo].[spTaikhoan_Update]    Script Date: 11/24/2021 9:12:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[spTaikhoan_Update] @PK_TaikhoanID int , @sTendangnhap nvarchar(50), @FK_NhanvienID int, @FK_QuyenID int
as
begin
	UPDATE [dbo].[tbl_taikhoan]
	set [sTendangnhap] = @sTendangnhap
		, [FK_NhanvienID] = @FK_NhanvienID
		, [FK_QuyenID] = @FK_QuyenID
	where PK_TaikhoanID = @PK_TaikhoanID
end 
GO
/****** Object:  StoredProcedure [dbo].[taikhoan_get]    Script Date: 11/24/2021 9:12:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[taikhoan_get]
as
begin
	select * from tbl_taikhoan
	inner join tbl_nhanvien on tbl_nhanvien.PK_NhanvienID = tbl_taikhoan.FK_NhanvienID
	inner join tbl_quyen on tbl_quyen.PK_QuyenID = tbl_taikhoan.FK_QuyenID
end

select * from tbl_taikhoan
	inner join tbl_nhanvien on tbl_nhanvien.PK_NhanvienID = tbl_taikhoan.FK_NhanvienID
	inner join tbl_quyen on tbl_quyen.PK_QuyenID = tbl_taikhoan.FK_QuyenID
GO
/****** Object:  Table [dbo].[tbl_congtrinh]    Script Date: 11/24/2021 9:12:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_congtrinh](
	[PK_CongtrinhID] [int] IDENTITY(1,1) NOT NULL,
	[sTencongtrinh] [nvarchar](255) NULL,
	[dNgaycapphep] [smalldatetime] NULL,
	[dNgaykhoicong] [smalldatetime] NULL,
	[dNgayhoanthanh] [smalldatetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[PK_CongtrinhID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_nhanvien]    Script Date: 11/24/2021 9:12:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_nhanvien](
	[PK_NhanvienID] [int] IDENTITY(1,1) NOT NULL,
	[sHoten] [nvarchar](50) NULL,
	[dNgaysinh] [smalldatetime] NULL,
	[bGioitinh] [bit] NULL,
	[sDiachi] [nvarchar](255) NULL,
	[sDienthoai] [varchar](20) NULL,
	[sChucvu] [varchar](255) NULL,
	[FK_PhongbanID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PK_NhanvienID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_phongban]    Script Date: 11/24/2021 9:12:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_phongban](
	[PK_PhongbanID] [int] IDENTITY(1,1) NOT NULL,
	[sTenphong] [nvarchar](50) NULL,
	[sPhutrach] [nvarchar](50) NULL,
	[dNgaythanhlap] [smalldatetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[PK_PhongbanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_quyen]    Script Date: 11/24/2021 9:12:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_quyen](
	[PK_QuyenID] [int] IDENTITY(1,1) NOT NULL,
	[sTenquyen] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[PK_QuyenID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_taikhoan]    Script Date: 11/24/2021 9:12:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_taikhoan](
	[PK_TaikhoanID] [int] IDENTITY(1,1) NOT NULL,
	[sTendangnhap] [varchar](50) NULL,
	[sMatkhau] [varchar](255) NULL,
	[FK_NhanvienID] [int] NOT NULL,
	[FK_QuyenID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PK_TaikhoanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_thicong]    Script Date: 11/24/2021 9:12:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_thicong](
	[FK_CongtrinhID] [int] IDENTITY(1,1) NOT NULL,
	[FK_NhanvienID] [int] NOT NULL,
	[dNgaybatdau] [smalldatetime] NULL,
	[dNgayketthuc] [smalldatetime] NULL,
	[iSongaycong] [int] NULL,
 CONSTRAINT [PK_tblthicong] PRIMARY KEY CLUSTERED 
(
	[FK_CongtrinhID] ASC,
	[FK_NhanvienID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[tbl_nhanvien] ON 

INSERT [dbo].[tbl_nhanvien] ([PK_NhanvienID], [sHoten], [dNgaysinh], [bGioitinh], [sDiachi], [sDienthoai], [sChucvu], [FK_PhongbanID]) VALUES (1, N'Nguyễn Văn Hào', CAST(N'2011-09-12 00:00:00' AS SmallDateTime), 1, N'Hà Nội', N'0335448775', N'Nhân Viên', 1)
SET IDENTITY_INSERT [dbo].[tbl_nhanvien] OFF
SET IDENTITY_INSERT [dbo].[tbl_phongban] ON 

INSERT [dbo].[tbl_phongban] ([PK_PhongbanID], [sTenphong], [sPhutrach], [dNgaythanhlap]) VALUES (1, N'Hành chính', N'Hành chính sửa sửa', CAST(N'2021-11-24 00:00:00' AS SmallDateTime))
INSERT [dbo].[tbl_phongban] ([PK_PhongbanID], [sTenphong], [sPhutrach], [dNgaythanhlap]) VALUES (4, N'Nhân sự', N'Nhân sự', CAST(N'2019-01-14 00:00:00' AS SmallDateTime))
SET IDENTITY_INSERT [dbo].[tbl_phongban] OFF
SET IDENTITY_INSERT [dbo].[tbl_quyen] ON 

INSERT [dbo].[tbl_quyen] ([PK_QuyenID], [sTenquyen]) VALUES (1, N'Admin')
INSERT [dbo].[tbl_quyen] ([PK_QuyenID], [sTenquyen]) VALUES (2, N'User')
SET IDENTITY_INSERT [dbo].[tbl_quyen] OFF
SET IDENTITY_INSERT [dbo].[tbl_taikhoan] ON 

INSERT [dbo].[tbl_taikhoan] ([PK_TaikhoanID], [sTendangnhap], [sMatkhau], [FK_NhanvienID], [FK_QuyenID]) VALUES (3, N'vanhao12', N'vanhao', 1, 2)
INSERT [dbo].[tbl_taikhoan] ([PK_TaikhoanID], [sTendangnhap], [sMatkhau], [FK_NhanvienID], [FK_QuyenID]) VALUES (4, N'admin', N'1', 1, 1)
SET IDENTITY_INSERT [dbo].[tbl_taikhoan] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__tbl_taik__5347950512E04242]    Script Date: 11/24/2021 9:12:23 AM ******/
ALTER TABLE [dbo].[tbl_taikhoan] ADD UNIQUE NONCLUSTERED 
(
	[sTendangnhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_nhanvien]  WITH CHECK ADD FOREIGN KEY([FK_PhongbanID])
REFERENCES [dbo].[tbl_phongban] ([PK_PhongbanID])
GO
ALTER TABLE [dbo].[tbl_taikhoan]  WITH CHECK ADD FOREIGN KEY([FK_NhanvienID])
REFERENCES [dbo].[tbl_nhanvien] ([PK_NhanvienID])
GO
ALTER TABLE [dbo].[tbl_taikhoan]  WITH CHECK ADD FOREIGN KEY([FK_QuyenID])
REFERENCES [dbo].[tbl_quyen] ([PK_QuyenID])
GO
ALTER TABLE [dbo].[tbl_thicong]  WITH CHECK ADD FOREIGN KEY([FK_CongtrinhID])
REFERENCES [dbo].[tbl_congtrinh] ([PK_CongtrinhID])
GO
ALTER TABLE [dbo].[tbl_thicong]  WITH CHECK ADD FOREIGN KEY([FK_NhanvienID])
REFERENCES [dbo].[tbl_nhanvien] ([PK_NhanvienID])
GO
USE [master]
GO
ALTER DATABASE [BTL_HSK] SET  READ_WRITE 
GO
