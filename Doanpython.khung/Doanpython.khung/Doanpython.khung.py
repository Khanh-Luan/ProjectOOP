#DỰ ÁN IT FOOD - PHIÊN BẢN 1
#XÂY DỰNG KHUNG CHO DỰ ÁN:
#Các thư viện:
from abc import ABC, abstractmethod


#1.LỚP NGƯỜI DÙNG ( LỚP CHA )
class NguoiDung(ABC):
#Public property Ma
    @property
    def Ma(self):
        return self._Ma
    @Ma.setter
    def Ma(self,value):
        self._Ma=value

#Public property Ten
    @property
    def Ten(Self):
        return self._Ten
    @Ten.setter
    def Ten(self,value):
        self._Ten=value

#Public property Sđt
    @property
    def Sdt(self):
        self._Sdt
    @Sdt.setter
    def Sdt(self,value):
        self._Sdt=value

#Public property Email
    @property 
    def Email(self):
        self._Email
    @Email.setter
    def Email(self,value):
        self._Email=value

#Constructor
    def __init__(self,ma=" ",ten=" ",sdt=" ",email=" "):
#Protected
        self._Ma=ma
        self._Ten=ten
        self._Sdt=sdt
        self._Email=email
#virtual
    def Xuat(self):
        pass
#abstract
    @abstractmethod
    def TinhToanTien(self,soTien):
        pass

#2.LỚP KHÁCH HÀNG ( LỚP CON )
class KhachHang(NguoiDung):
#CONSTRUCTOR
    def __init__(self, ma="", ten="", sdt="", email="", diachigiao=""):
        super().__init__(ma, ten, sdt, email)
#Thuộc tính private 
        self.__DiaChiGiao = diachigiao
        self.__DiemTichLuy = 0
        self.__TongDaChi = 0
        self.__DSVoucher = []
#Property DiaChiGiao
    @property 
    def DiaChiGiao(self):
        return self.__DiaChiGiao
    @DiaChiGiao.setter
    def DiaChiGiao(self,value):
        self.__DiaChiGiao=value
#Property DiemTichLuy
    @property
    def DiemTichLuy(self):
        return self.__DiemTichLuy
    @DiemTichLuy.setter
    def DiemTichLuy(self,value):
        self.__DiemTichLuy=value
#Property TongDaChi
    @property
    def TongDaChi(self):
        return self.__TongDaChi
#Thêm voucher
    def ThemVoucher(self,v):
        pass
#Xóa voucher
    def XoaVoucher(self,ma):
        pass
#Override Nhap()
    def Xuat(self):
        pass
#Tim voucher
    def TimVoucher(self,ma):
        pass
#Override TinhToanTien()
    def TinhToanTien(self,soTien):
        pass

#3.LỚP CHỦ QUÁN ( LỚP CON)
class ChuQuan(NguoiDung):
#Constructor
    def __init__(self, ma="", ten="", sdt="", email=""):
        super().__init__(ma, ten, sdt, email)
#Thuộc tính Private
        self.__DSQuan = []
        self.__TongDoanhThu = 0
#Property TongDoanhThu
    @property
    def TongDoanhThu(self):
        return self.__TongDoanhThu
#Thêm Quán
    def ThemQuan(self,quan):
        pass
#Xuat
    def Xuat(self):
        pass
#Override TinhToanTien()
    def TinhToanTien(self,soTien):
        pass

#4.Lớp Tài Xế ( lớp con ):
class TaiXe(NguoiDung):
#Constructor
    def __init__(self,ma=" ", ten=" ",sdt=" ",email=" ",bienso=" "):
        super().__init__(ma,ten,sdt,email)

        self.__BienSo=bienso
        self.__DangRanh=True
        self.__SoDonDaGiao=0
        self.__TongThuNhap=0
#Property Biển Số
    @property
    def BienSo(self):
        return self.__BienSo
    @BienSo.setter
    def BienSo(self,value):
        self.__BienSo=value
#Property Đang Rảnh
    @property
    def DangRanh(self):
        return self.__DangRanh
    @DangRanh.setter
    def DangRanh(self,value):
        self.__DangRanh=value
#Property Số đơn đã giao:
    @property
    def SoDonDaGiao(self):
        return self.__SoDonDaGiao
    @SoDonDaGiao.setter
    def SoDonDaGiao(self,value):
        self.__SoDonDaGiao=value
#Property Tổng Thu Nhập:
    @property
    def TongThuNhap(self):
        return self.__TongThuNhap
#Override Tính Toán Tiền
    def TinhToanTien(self,soTien):
        pass
#Override Nhap:
    def Nhap(self):
        pass
#Override Xuat:
    def Xuat(self):
        pass
#Hoàn thành giao:
    def HoanThanhGiao(self):
        pass

#4.LỚP MÓN ĂN 
class MonAn:
    def __init__(self,ma=" ",ten=" ",gia=0):
        self._Ma=ma
        self._Ten=ten
#Property Mã
    @property
    def Ma(self):
        return self._Ma
    @Ma.setter
    def Ma(self,value):
        self._Ma=value
#Property Tên
    @property
    def Ten(self):
        return self._Ten
    @Ten.setter
    def Ten(self,value):
        self._Ten=value
#Property Gía
    @property 
    def Gia(self):
        return self._Gia
    @Gia.setter
    def Gia(self,value):
        if value <=0:
            raise ValueError("Gia phai > 0.")
        self._Gia=value
#Virtual 
    def Nhap(self):
        pass
#Virtual
    def HienThi(self):
        pass

#5. LỚP VOUCHER 
class Voucher:
#Constructor
    def __init__(self,ma=" ", phantram=0):
        self.__Ma=ma
        self.__PhanTram=phantram
        self.__ConSuDung= True
#Property Mã
    @property
    def Ma(self):
        return self.__Ma
    @Ma.setter
    def Ma(self,value):
        self.__Ma=value
#Property Phần Trăm
    @property
    def PhanTram(self):
        return self.__PhanTram
    @PhanTram.setter
    def PhanTram(self,value):
        self.__PhanTram=value
#Property Đã Dùng
    @property
    def ConSuDung(self):
        return self.__ConSuDung
#Tính Số Tiền Được Gỉam
    def TinhGiam(self,tienMon):
        pass
#Đánh dấu voucher đã sử dụng
    def SuDung(self):
        pass
#Nhập thông tin voucher
    def Nhap(self):
        pass
#Xuất thông tin voucher
    def Xuat(self):
        pass

#6.LỚP QUÁN: 
class Quan: 
#Constructor
    def __init__(self,ma=" ",ten=" ", diachi=" ",chuquan=None):
#Thuộc tính private
        self.__Ma=ma
        self.__Ten=ten
        self.__DiaChi=diachi
        self.__DangMoCua=True
    #Danh sách món ăn
        self._menu=[ ]
    #Chủ quán
        self._ChuQuan=chuquan
#Property Mã
    @property
    def Ma(self):
        return self._Ma
    @Ma.setter
    def Ma(self,value):
        self.__Ma=value
#Property Tên
    @property
    def Ten(self):
        return self._Ten
    @Ten.setter
    def Ten(self,value):
        self.__Ten=value
#Property Địa Chỉ
    @property
    def DiaChi(self):
        return self._DiaChi
    @DiaChi.setter
    def DiaChi(self,value):
        self.__DiaChi=value
#Property Đang Mở Cửa
    @property
    def DangMoCua(self):
        return self._DangMoCua
    @DangMoCua.setter
    def DangMoCua(self,value):
        self.__DangMoCua=value
#Property Chủ Quán
    @property
    def ChuQuan(self):
        return self._ChuQuan
    @ChuQuan.setter
    def ChuQuan(self,value):
        self.__ChuQuan=value
#Nhập thông tin quán
    def Nhap(self,ChuSoHuu):
        pass
#Thêm món vào menu
    def ThemMon(self,mon):
        pass
#Tìm món theo mã
    def TimMon(self,ma):
        pass
#Hiển thị menu
    def HienThiMenu(self):
        pass
#Nhận đơn hàng
    def NhanDon(self,don):
        pass

#7.LỚP PHƯƠNG THỨC THANH TOÁN (LỚP CHA)
class PhuongThucThanhToan(ABC): 
#Abstract method
    @abstractmethod
    def XuLyThanhToan(self,soTien):
        pass
#8.LỚP TIỀN MẶT ( LỚP CON KẾ THỪA PHƯƠNG THỨC THANH TOÁN )
class TienMat(PhuongThucThanhToan):
#Override phuong thuc XulyThanhToan
    def XuLyThanhToan(self,soTien):
        pass

#9.LỚP VÍ ĐIỆN TỬ ( LỚP CON KẾ THỪA PHƯƠNG THỨC THANH TOÁN )
class ViDienTu(PhuongThucThanhToan):
#Constructor
    def __init__(self, sodu=0):
#Thuộc tính private
        self.__SoDu=sodu
#Nhập thông tin ví điện tử:
    def Nhap(self):
        pass
#Override phương thức XuLyThanhToan
    def XuLyThanhToan(self,soTien):
        pass

#10.LỚP THẺ ( LỚP CON KẾ THỪA PHƯƠNG THỨC THANH TOÁN )
class The(PhuongThucThanhToan):
#Constructor
    def __init__(self, sothecuoi=" ",phigiaodich=0):
#Thuộc tính private
        self.__SoTheCuoi=sothecuoi
        self.__PhiGiaoDich=phigiaodich
#Nhập thông tin thẻ
    def Nhap(self):
        pass
#Override Phương Thức XuLyThanhToan
    def XuLyThanhToan(self,soTien):
        pass

#11.LỚP ĐƠN HÀNG
class DonHang:
    def __init__(self,ma=" ",khach=None,quan=None):
        self.__Ma=ma
        self.__Khach=khach
        self.__Quan=quan
        self.__TaiXe=None
        self.__DSMon=[]
        self.__DSSoLuong=[]
        self.__KhoangCachKm=0
        self.__TrangThai=" Cho xac nhan "
        self._ThanhToan=None
        self._SoTienDaThanhToan=0
#Property Mã
    @property
    def Ma(self):
        return self._Ma
#Property Trạng Thái
    @property
    def TrangThai(self):
        return self._TrangThai
#GỌI MÓN
    def GoiMon(self,mon,soluong):
        pass
#Nhập đơn hàng
    def Nhap(self):
        pass
#Cập nhật trạng thái:
    def CapNhatTrangThai(self,trangthaimoi):
        pass
#Xuất đơn hàng
    def Xuat(self):
        pass
#Tính tiền món:
    def TongTienMon(self):
        pass
#Tính phí ship:
    def TinhPhiShip(self):
        pass
#Tính giảm giá:
    def TinhGiamGia(self,mavoucher):
        pass
#Tính tổng thanh toán:
    def TongThanhToan(self,mavoucher):
        pass
#Gán tài xế:
    def GanTaiXe(self,tx):
        pass
#Thanh Toán:
    def ThanhToan(self,pttt,mavoucher):
        pass
#In Hóa Đơn:
    def InHoaDon(self):
        pass

#.12.LỚP ỨNG DỤNG:
class UngDung:
    def __init__(self):
        self.__DSKhachHang=[]
        self.__DSChuQuan=[]
        self.__DSTaiXe=[]
        self.__DSQuan=[]
        self.__DSDonHang=[]
#Thêm khách hàng
    def ThemKhachHang(self,kh):
        pass
#Thêm chủ quán:
    def ThemChuQuan(self,cq):
        pass
#Tìm tài xế rảnh:
    def TimTaiXeRanh(self):
        pass
#Tìm tài xế rảnh và gần đơn
    def TimTaiXeRanhVaGanDon(self,don):
        pass
#Tạo đơn hàng:
    def TaoDonHang(self,ma,kh,quan):
        pass
#Báo cáo:
    def BaoCao(self):
        pass


    





    
    

    

    














        










    


