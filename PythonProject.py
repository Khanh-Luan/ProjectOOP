#DỰ ÁN IT FOOD
#Các thư viện:
from abc import ABC, abstractmethod
from enum import Enum

# ================= TRANG THAI DON HANG (ENUM) =================
class TrangThaiDon(Enum):
    ChoXacNhan=1
    DangLam=2
    DaThanhToan=3
    DangGiao=4
    HoanThanh=5
    DaHuy=6


# ================= NGUOI DUNG =================
class NguoiDung(ABC):
    def __init__(self,ma="",ten="",sdt="",email=""):
        self._sMa=ma
        self._sTen=ten
        self._sSdt=sdt
        self._sEmail=email

    @property
    def Ma(self):
        return self._sMa

    @Ma.setter
    def Ma(self,value):
        self._sMa=value

    @property
    def Ten(self):
        return self._sTen

    @Ten.setter
    def Ten(self,value):
        self._sTen=value

    @property
    def Sdt(self):
        return self._sSdt

    @Sdt.setter
    def Sdt(self,value):
        self._sSdt=value

    @property
    def Email(self):
        return self._sEmail

    @Email.setter
    def Email(self,value):
        self._sEmail=value

    # Virtual
    def Nhap(self):
        self._sMa=input("Nhap ma: ")
        self._sTen=input("Nhap ten: ")
        self._sSdt=input("Nhap so dien thoai: ")
        self._sEmail=input("Nhap email: ")
    # Virtual

    def Xuat(self):
        print(f"Ma: {self._sMa}")
        print(f"Ten: {self._sTen}")
        print(f"So dien thoai: {self._sSdt}")
        print(f"Email: {self._sEmail}")

    @abstractmethod
    def TinhToanTien(self, soTien):
        pass

# ================= KHACH HANG =================
class KhachHang(NguoiDung):
    def __init__(self,ma="",ten="",sdt="",email="",diaChi=""):
        super().__init__(ma,ten,sdt,email)

        self.__sDiaChiGiao=diaChi
        self.__iDiemTichLuyITFood=0
        self.__dTongDaChi=0

    @property
    def DiaChiGiao(self):
        return self.__sDiaChiGiao

    @DiaChiGiao.setter
    def DiaChiGiao(self,value):
        self.__sDiaChiGiao=value

    @property
    def DiemTichLuyITFood(self):
        return self.__iDiemTichLuyITFood

    @DiemTichLuyITFood.setter
    def DiemTichLuyITFood(self,value):
        self.__iDiemTichLuyITFood=value

    @property
    def TongDaChi(self):
        return self.__dTongDaChi

    # Override
    def Nhap(self):
        super().Nhap()
        print("Khach hang ")
        self.__sDiaChiGiao=input("Nhap dia chi giao hang: ")

    # Override
    def Xuat(self):
        super().Xuat()
        print(f"Dia chi giao: {self.__sDiaChiGiao}")
        print(f"Diem tich luy ITFood: {self.__iDiemTichLuyITFood}")
        print(f"Tong da chi: {self.__dTongDaChi} VND ")
    # Override
    def TinhToanTien(self,soTien):
        self.__dTongDaChi+=soTien
        self.__iDiemTichLuyITFood+=int(soTien/10000)
      
# ================= CHU QUAN =================
class ChuQuan(NguoiDung):
    def __init__(self,ma="",ten="",sdt="",email=""):
        super().__init__(ma,ten,sdt,email)

        self.__dsQuan=[]
        self.__dTongDoanhThu=0

    @property
    def TongDoanhThu(self):
        return self.__dTongDoanhThu

    def ThemQuan(self,quan):
        self.__dsQuan.append(quan)
        quan.ChuCuaQuan=self

    def TimQuan(self,ma):
        for i in range(len(self.__dsQuan)):
            if self.__dsQuan[i].Ma==ma:
                return self.__dsQuan[i]
        return None

    def HienThiDsQuan(self):
        print(f"Danh sach quan cua {self._sTen}:")
        for i in range(len(self.__dsQuan)):
            print(f"  {self.__dsQuan[i].Ma} - {self.__dsQuan[i].Ten} - {self.__dsQuan[i].DiaChi}")

    # Override
    def Xuat(self):
        super().Xuat()
        print(f"So quan so huu: {len(self.__dsQuan)}")
        print(f"Tong doanh thu: {self.__dTongDoanhThu} VND ")

    # Override
    def TinhToanTien(self,soTien):
        self.__dTongDoanhThu=self.__dTongDoanhThu+soTien
      
# ================= TAI XE =================
class TaiXe(NguoiDung):
    def __init__(self, ma="", ten="", sdt="", email="", bienSo=""):
        super().__init__(ma, ten, sdt, email)

        self.__sBienSo=bienSo
        self.__bDangRanh=True
        self.__iSoDonDaGiao=0
        self.__dTongThuNhap=0

    @property
    def BienSo(self):
        return self.__sBienSo

    @BienSo.setter
    def BienSo(self,value):
        self.__sBienSo=value

    @property
    def DangRanh(self):
        return self.__bDangRanh

    @DangRanh.setter
    def DangRanh(self,value):
        self.__bDangRanh=value

    @property
    def SoDonDaGiao(self):
        return self.__iSoDonDaGiao

    @SoDonDaGiao.setter
    def SoDonDaGiao(self,value):
        self.__iSoDonDaGiao=value

    @property
    def TongThuNhap(self):
        return self.__dTongThuNhap

    # Override
    def TinhToanTien(self,soTien):
        self.__dTongThuNhap=self.__dTongThuNhap+soTien

    # Override
    def Nhap(self):
        super().Nhap()
        print("Tai xe ")
        self.__sBienSo=input("Nhap bien so xe: ")

    # Override
    def Xuat(self):
        super().Xuat()
        print(f"Bien so xe: {self.__sBienSo}")
        print(f"Dang ranh: {self.__bDangRanh}")
        print(f"So don da giao: {self.__iSoDonDaGiao}")
        print(f"Tong thu nhap: {self.__dTongThuNhap} VND ")
  
    def HoanThanhGiao(self):
        self.__iSoDonDaGiao=self.__iSoDonDaGiao + 1
        self.__bDangRanh=True
        
# ================= MON AN =================
class MonAn:
    def __init__(self,ma="",ten="",gia=0):
        self._sMa=ma
        self._sTen=ten
        self._dGia=gia

    @property
    def Ma(self):
        return self._sMa

    @Ma.setter
    def Ma(self, value):
        self._sMa = value

    @property
    def Ten(self):
        return self._sTen

    @Ten.setter
    def Ten(self,value):
        self._sTen=value

    @property
    def Gia(self):
        return self._dGia

    @Gia.setter
    def Gia(self,value):
        if value<=0:
            raise ValueError("Gia phai > 0")
        self._dGia=value

    # Virtual
    def Nhap(self):
        self._sMa=input("Nhap ma mon: ")
        self._sTen=input("Nhap ten mon: ")
        print("Nhap gia: ")
        self.Gia=float(input())

    # Virtual
    def HienThi(self):
        print(f"{self._sMa} - {self._sTen} - {self._dGia} VND ")

# ================= CHI TIET DON =================
class ChiTietDon:
    def __init__(self,mon=None,soLuong=0):
        self.__mon=mon
        self.__iSoLuong=soLuong

    @property
    def Mon(self):
        return self.__mon

    @Mon.setter
    def Mon(self,value):
        self.__mon=value

    @property
    def SoLuong(self):
        return self.__iSoLuong

    @SoLuong.setter
    def SoLuong(self,value):
        self.__iSoLuong=value

    def ThanhTien(self):
        return self.__mon.Gia * self.__iSoLuong

    def HienThi(self):
        print(f"{self.__mon.Ten}x{self.__iSoLuong}={self.ThanhTien()} VND ")
        
# ================= VOUCHER =================
class Voucher:
    def __init__(self,ma="",ten="",phanTram=0):
        self.__sMa=ma
        self.__sTen=ten
        self.__dPhanTram=phanTram
        self.__bConSuDung=True

    @property
    def Ma(self):
        return self.__sMa

    @Ma.setter
    def Ma(self,value):
        self.__sMa=value

    @property
    def Ten(self):
        return self.__sTen

    @Ten.setter
    def Ten(self,value):
        self.__sTen=value

    @property
    def PhanTram(self):
        return self.__dPhanTram

    @PhanTram.setter
    def PhanTram(self,value):
        self.__dPhanTram=value

    @property
    def ConSuDung(self):
        return self.__bConSuDung

    def TinhGiam(self, tienMon):
        if not self.__bConSuDung:
            return 0
        return tienMon * self.__dPhanTram/100

    def SuDung(self):
        self.__bConSuDung=False

    def Nhap(self):
        self.__sMa=input("Nhap ma voucher: ")
        self.__sTen=input("Nhap ten voucher: ")
        print("Nhap phan tram giam: ")
        self.__dPhanTram=float(input())
        self.__bConSuDung=True

    def Xuat(self):
        print(f"{self.__sMa}-{self.__sTen}-Giam {self.__dPhanTram}%-Con su dung: {self.__bConSuDung}")
        
# ================= QUAN =================
class Quan:
    def __init__(self,ma="",ten="",diaChi=""):
        self.__sMa=ma
        self.__sTen=ten
        self.__sDiaChi=diaChi
        self.__bDangMoCua=True
        self.__menu=[]
        self.__dsVoucher=[]
        self.__chuQuan=None

    @property
    def Ma(self):
        return self.__sMa

    @Ma.setter
    def Ma(self, value):
        self.__sMa=value

    @property
    def Ten(self):
        return self.__sTen

    @Ten.setter
    def Ten(self, value):
        self.__sTen=value

    @property
    def DiaChi(self):
        return self.__sDiaChi

    @DiaChi.setter
    def DiaChi(self,value):
        self.__sDiaChi=value

    @property
    def DangMoCua(self):
        return self.__bDangMoCua

    @DangMoCua.setter
    def DangMoCua(self,value):
        self.__bDangMoCua=value

    @property
    def ChuCuaQuan(self):
        return self.__chuQuan

    @ChuCuaQuan.setter
    def ChuCuaQuan(self,value):
        self.__chuQuan=value

    def Nhap(self):
        self.__sMa=input("Nhap ma quan: ")
        self.__sTen=input("Nhap ten quan: ")
        self.__sDiaChi=input("Nhap dia chi: ")
        self.__bDangMoCua=True

    def ThemMon(self,mon):
        self.__menu.append(mon)

    def TimMon(self,ma):
        for i in range(len(self.__menu)):
            if self.__menu[i].Ma==ma:
                return self.__menu[i]
        return None

    def HienThiMenu(self):
        print(f"Menu cua quan {self.__sTen} :")
        for i in range(len(self.__menu)):
            self.__menu[i].HienThi()

    # QUAN LY VOUCHER CUA QUAN

    def ThemVoucher(self,v):
        self.__dsVoucher.append(v)

    def TimVoucher(self,ma):
        for i in range(len(self.__dsVoucher)):
            if self.__dsVoucher[i].Ma==ma:
                return self.__dsVoucher[i]
        return None

    def CoVoucher(self):
        for i in range(len(self.__dsVoucher)):
            if self.__dsVoucher[i].ConSuDung:
                return True
        return False

    def HienThiVoucherConDung(self):
        print(f"Voucher hien co cua quan {self.__sTen}: ")
        for i in range(len(self.__dsVoucher)):
            if self.__dsVoucher[i].ConSuDung:
                self.__dsVoucher[i].Xuat()
        
    def HienThiVoucherDaDung(self):
        print(f"Voucher da su dung cua quan {self.__sTen}: ")
        for i in range(len(self.__dsVoucher)):
            if not self.__dsVoucher[i].ConSuDung:
                self.__dsVoucher[i].Xuat()
        
    def Xuat(self):
        print("THONG TIN QUAN: ")
        print(f"Ma quan: {self.__sMa}")
        print(f"Ten quan: {self.__sTen}")
        print(f"Dia chi: {self.__sDiaChi}")
        print(f"Dang mo cua: {self.__bDangMoCua}")
        print(f"So mon trong menu: {len(self.__menu)}")
        print(f"So voucher: {len(self.__dsVoucher)}")

        if self.__chuQuan is not None:
            print(f"Chu quan: {self.__chuQuan.Ten}(Ma:{self.__chuQuan.Ma})")
            print(f"Doanh thu cua chu: "f"{self.__chuQuan.TongDoanhThu} VND ")

    def NhanDon(self, don):
        print(f"[Thong bao quan {self.__sTen}]Nhan duoc don {don.Ma}, bat dau lam mon.")
        don.CapNhatTrangThai(TrangThaiDon.DangLam)
       
# ================= PHUONG THUC THANH TOAN =================
class PhuongThucThanhToan(ABC):
    @abstractmethod
    def XuLyThanhToan(self, soTien):
        pass

class TienMat(PhuongThucThanhToan):

    # Override
    def XuLyThanhToan(self, soTien):
        print(f"Thanh toan {soTien} VND bang tien mat khi nhan hang.")
        return True
        
class ViDienTu(PhuongThucThanhToan):
    def __init__(self,soDu=0):
        self.__dSoDu=soDu

    def Nhap(self):
        print("Nhap so du vi: ")
        self.__dSoDu=float(input())

    # Override
    def XuLyThanhToan(self,soTien):
        if self.__dSoDu<soTien:
            print("So du vi dien tu khong du.")
            return False
        self.__dSoDu=self.__dSoDu - soTien
        print(f"Da thanh toan {soTien} VND bang vi dien tu.")
        return True

class The(PhuongThucThanhToan):
    PHI_GIAO_DICH_MAC_DINH=3000

    def __init__(self,soTheCuoi=""):
        self.__sSoTheCuoi=soTheCuoi
        self.__dPhiGiaoDich=self.PHI_GIAO_DICH_MAC_DINH

    def Nhap(self):
        self.__sSoTheCuoi=input("Nhap 4 so cuoi the: ")
        self.__dPhiGiaoDich=self.PHI_GIAO_DICH_MAC_DINH
        
    # Override
    def XuLyThanhToan(self, soTien):
        tongTien=soTien+self.__dPhiGiaoDich
        print(f"Da thanh toan {tongTien} VND bang the ***{self.__sSoTheCuoi} gom phi {self.__dPhiGiaoDich} VND ")
        return True

# ================= DON HANG =================
class DonHang:
    def __init__(self,ma,khach,quan):
        self.__sMa=ma
        self.__khach=khach
        self.__quan=quan
        self.__taiXe=None
        self.__dsChiTiet=[]
        self.__dKhoangCachKm=0
        self.__trangThai=TrangThaiDon.ChoXacNhan
        self.__thanhToan=None
        self.__dSoTienDaThanhToan=0
        self.__dSoTienGiamGia=0

    @property
    def Ma(self):
        return self.__sMa

    @property
    def TrangThai(self):
        return self.__trangThai

    def GoiMon(self,mon,soLuong):
        ct=ChiTietDon(mon,soLuong)
        self.__dsChiTiet.append(ct)
       
    def Nhap(self):
        self.__quan.HienThiMenu()

        print("Nhap so mon muon dat: ")
        soMon=int(input())

        for i in range(soMon):
            print("Nhap ma mon: ")
            maMon=input()
            print("Nhap so luong mon: ")
            soLuong=int(input())
            mon=self.__quan.TimMon(maMon)

            if mon is not None:
                self.GoiMon(mon, soLuong)
            else:
                print(f"Khong tim thay mon co ma {maMon}.Bo qua.")

        print("Nhap khoang cach giao (km): ")
        self.__dKhoangCachKm=float(input())
        self.__trangThai=TrangThaiDon.ChoXacNhan
        self.Xuat()

    def CapNhatTrangThai(self,trangThaiMoi):
        self.__trangThai=trangThaiMoi
        
    def Xuat(self):
        print(f"DON HANG {self.__sMa}")
        for i in range(len(self.__dsChiTiet)):
            self.__dsChiTiet[i].HienThi()
        print(f"Trang Thai: {self.__trangThai.name}")
        
    def TongTienMon(self):
        tong=0
        for i in range(len(self.__dsChiTiet)):
            tong=tong+self.__dsChiTiet[i].ThanhTien()
        return tong

    def TinhPhiShip(self):
        if self.__dKhoangCachKm<=3:
            return 15000

        if self.__dKhoangCachKm<=7:
            return 25000
        return 40000
        
    def TinhGiamGia(self,maVoucher):
        if maVoucher is None:
            return 0

        v=self.__quan.TimVoucher(maVoucher)

        if v is None:
            return 0
        return v.TinhGiam(self.TongTienMon())

    def TongThanhToan(self,maVoucher):
        return(self.TongTienMon()-self.TinhGiamGia(maVoucher)+self.TinhPhiShip())
        
    def GanTaiXe(self, tx):
        self.__taiXe=tx
        tx.DangRanh=False
        self.__trangThai=TrangThaiDon.DangGiao

        print(f"[Thong bao tai xe {tx.Ten}] Ban duoc phan cong giao don {self.__sMa}.")
      

    def ThanhToan(self,ptTT,maVoucher):
        self.__thanhToan = ptTT

        giam = self.TinhGiamGia(maVoucher)
        tongTien = self.TongThanhToan(maVoucher)

        self.__dSoTienDaThanhToan=tongTien
        self.__dSoTienGiamGia=giam

        thanhCong = self.__thanhToan.XuLyThanhToan(tongTien)

        if thanhCong:
            self.__trangThai=TrangThaiDon.DaThanhToan

            if maVoucher is not None:
                v = self.__quan.TimVoucher(maVoucher)

                if v is not None:
                    v.SuDung()

            self.__khach.TinhToanTien(tongTien)

            self.__quan.ChuCuaQuan.TinhToanTien(self.TongTienMon() - giam)
        else:
            print("Thanh toan that bai! Don hang chua duoc thanh toan.")
        return thanhCong

    def HoanThanhDon(self):
        if self.__trangThai!=TrangThaiDon.DangGiao:
            print("Don hang chua du dieu kien de hoan thanh.")
            return

        if self.__taiXe is not None:
            self.__taiXe.TinhToanTien(self.TinhPhiShip())
            self.__taiXe.HoanThanhGiao()
        self.__trangThai = TrangThaiDon.HoanThanh
        print(f"Don hang {self.__sMa}  da giao thanh cong.")

    def HuyDon(self):
        if self.__trangThai==TrangThaiDon.HoanThanh:
            print("Khong the huy don da hoan thanh.")
            return

        self.__trangThai=TrangThaiDon.DaHuy
        if self.__taiXe is not None:
            self.__taiXe.DangRanh=True
        print(f"Don hang {self.__sMa} da bi huy.")

    def InHoaDon(self):
        print(f"----- HOA DON {self.__sMa} -----")

        for i in range(len(self.__dsChiTiet)):
            self.__dsChiTiet[i].HienThi()

        print(f"Tien mon: {self.TongTienMon()} VND")

        if self.__dSoTienGiamGia>0:
            print(f"Giam gia voucher:"f"-{self.__dSoTienGiamGia} VND ")

        print(f"Phi ship:{self.TinhPhiShip()} VND ")
        print(f"Tong thanh toan:{self.__dSoTienDaThanhToan} VND ")
        print(f"Trang thai:{self.__trangThai.name}")

# ================= UNG DUNG (LOP TONG) =================
class UngDung:
    def __init__(self):
        self.__dsKhachHang=[]
        self.__dsChuQuan=[]
        self.__dsTaiXe=[]
        self.__dsQuan=[]
        self.__dsDonHang=[]

    def ThemKhachHang(self,kh):
        self.__dsKhachHang.append(kh)

    def ThemChuQuan(self,cq):
        self.__dsChuQuan.append(cq)

    def ThemTaiXe(self,tx):
        self.__dsTaiXe.append(tx)

    def ThemQuan(self,q):
        self.__dsQuan.append(q)

    def TimTaiXeRanh(self):
        for i in range(len(self.__dsTaiXe)):
            if self.__dsTaiXe[i].DangRanh:
                return self.__dsTaiXe[i]
        return None
        
    def TimTaiXeRanhVaGanDon(self,don):
        tx=self.TimTaiXeRanh()
        if tx is not None:
            don.GanTaiXe(tx)
        else:
            print("Khong co tai xe ranh.")

    def TaoDonHang(self,ma,kh,quan):
        if not quan.DangMoCua:
            print( "Quan hien dang dong cua, khong the dat hang.")
            return None

        don=DonHang(ma,kh,quan)
        self.__dsDonHang.append(don)
        return don

    def BaoCao(self):
        print("===== BAO CAO HE THONG =====")
        print(f"Tong so don hang: {len(self.__dsDonHang)}")
        soHoanThanh=0
        soHuy=0
        for i in range(len(self.__dsDonHang)):
            if (self.__dsDonHang[i].TrangThai==TrangThaiDon.HoanThanh):
                soHoanThanh=soHoanThanh + 1

            if (self.__dsDonHang[i].TrangThai==TrangThaiDon.DaHuy):
                soHuy=soHuy + 1

        print(f"Don hoan thanh: {soHoanThanh}")
        print(f"Don da huy: {soHuy}")

        print("Thong tin tai xe")

        for i in range(len(self.__dsTaiXe)):
            self.__dsTaiXe[i].Xuat()
            print()

# ================= CHAY THU =================
def NhapMenu(quan):
    print("Nhap so mon trong menu: ")
    soMonMenu=int(input())

    for i in range(soMonMenu):
        print(f"Nhap mon {i + 1} ")
        mon=MonAn()
        mon.Nhap()
        quan.ThemMon(mon)

def NhapVoucher(quan):
    print("Nhap so voucher cua quan: ")
    soVoucher=int(input())

    for i in range(soVoucher):
        print(f"Nhap voucher {i + 1} ")
        v=Voucher()
        v.Nhap()
        quan.ThemVoucher(v)

def ChonPhuongThucThanhToan():
    print("Chon phuong thuc thanh toan:")
    print("1-Tien mat")
    print("2-Vi dien tu")
    print("3-The")
    print("Lua chon: ")

    chon=input()

    if chon=="2":
        vi=ViDienTu()
        vi.Nhap()
        return vi

    if chon== "3":
        the=The()
        the.Nhap()
        return the
    return TienMat()

def ChonVoucher(quan):
    if not quan.CoVoucher():
        print("Quan nay hien khong co voucher khuyen mai.")
        return None

    quan.HienThiVoucherConDung()
    print("Nhap ma voucher muon dung (bo trong neu khong dung): ")
    maVoucher=input()

    if maVoucher=="":
        return None
    return maVoucher


def Main():
    app=UngDung()
    # ================= 1. KHOI TAO DU LIEU =================
    cq=ChuQuan()
    cq.Nhap()
    app.ThemChuQuan(cq)

    quan=Quan()
    quan.Nhap()
    cq.ThemQuan(quan)
    app.ThemQuan(quan)

    NhapMenu(quan)
    NhapVoucher(quan)

    kh=KhachHang()
    kh.Nhap()
    app.ThemKhachHang(kh)

    tx=TaiXe()
    tx.Nhap()
    app.ThemTaiXe(tx)

    # ================= 2. TAO DON HANG =================
    print("Nhap ma don hang: ")
    maDon=input()

    don=app.TaoDonHang(maDon, kh, quan)

    if don is None:
        print("Khong the tao don hang. Ket thuc.")
        return

    don.Nhap()

    # ================= 3. QUAN NHAN DON =================
    print("===== BUOC 1: QUAN NHAN DON =====")
    quan.NhanDon(don)

    # ================= HUY DON (NEU MUON) =================
    print("Ban co muon huy don khong?")
    huyChon=input()

    if huyChon=="y"or huyChon== "Y":
        don.HuyDon()

        print("===== HOA DON =====")
        don.InHoaDon()
        print()
        app.BaoCao()
        return

    # ================= 4. THANH TOAN =================
    print("===== BUOC 2: THANH TOAN =====")

    ptTT=ChonPhuongThucThanhToan()
    maVoucher=ChonVoucher(quan)

    thanhCong=don.ThanhToan(ptTT, maVoucher)

    # Neu vi dien tu khong du tien,cho khach chuyen sang tien mat.
    if not thanhCong:
        print("Chuyen sang thanh toan bang tien mat.")
        ptTT=TienMat()
        thanhCong=don.ThanhToan(ptTT, maVoucher)

    if not thanhCong:
        print("Khong the thanh toan don hang.")
        return

    # ================= 5. PHAN CONG TAI XE =================
    print("===== BUOC 3: PHAN CONG TAI XE =====")
    app.TimTaiXeRanhVaGanDon(don)

    # ================= 6. GIAO HANG =================
    print("===== BUOC 4: GIAO HANG =====")

    if don.TrangThai==TrangThaiDon.DangGiao:
        don.HoanThanhDon()
    else:
        print("Don hang chua duoc giao vi chua co tai xe.")

    # ================= 7. HIEN THI KET QUA =================
    print("===== HOA DON =====")
    don.InHoaDon()

    print()
    quan.Xuat()

    print()
    quan.HienThiVoucherDaDung()

    print()
    kh.Xuat()

    print()
    app.BaoCao()


if __name__ == "__main__":
    Main()

