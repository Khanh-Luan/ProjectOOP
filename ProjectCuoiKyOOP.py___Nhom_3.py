from abc import ABC, abstractmethod
from enum import Enum 

class TrangThaiDon(Enum):
    ChoXacNhan=0
    DangLam=1
    DaThanhToan=2
    DangGiao=3
    HoanThanh=4
    DaHuy=5

class NguoiDung(ABC):
    def __init__(self, ma="", ten="", sdt="", email=""):
        self._sMa=ma
        self._sTen=ten
        self._sSdt=sdt
        self._sEmail=email

    @property
    def Ma(self):
        return self._sMa
    @Ma.setter
    def Ma(self, value):
        self._sMa=value

    @property
    def Ten(self):
        return self._sTen
    @Ten.setter
    def Ten(self, value):
        self._sTen=value

    @property
    def SDT(self):
        return self._sSdt
    @SDT.setter
    def SDT(self, value):
        self._sSdt=value

    @property
    def Email(self):
        return self._sEmail
    @Email.setter
    def Email(self, value):
        self._sEmail=value

    def Nhap(self):
        self._sMa=input("Nhap ma: ")
        self._sTen=input("Nhap ten: ")
        self._sSdt=input("Nhap so dien thoai: ")
        self._sEmail=input("Nhap email: ")

    def Xuat(self):
        print(f"Ma: {self._sMa}")
        print(f"Ten: {self._sTen}")
        print(f"So dien thoai: {self._sSdt}")
        print(f"Dia chi email: {self._sEmail}")

    @abstractmethod
    def TinhToanTien(self, soTien):
        pass

class KhachHang(NguoiDung):
    def __init__(self, ma="", ten="", sdt="", email="", diaChi="") :
        super().__init__(ma, ten, sdt, email)

        self.__sDiaChiGiao=diaChi
        self.__iDiemTichLuyITFood=0
        self.__dTongDaChi=0.0

    @property
    def DiaChiGiao(self):
        return self.__sDiaChiGiao
    @DiaChiGiao.setter
    def DiaChiGiao(self, value):
        self.__sDiaChiGiao=value

    @property
    def DiemTichLuyITFood(self):
        return self.__iDiemTichLuyITFood
    @DiemTichLuyITFood.setter
    def DiemTichLuyITFood(self, value):
        self.__iDiemTichLuyITFood=value

    @property
    def TongDaChi(self):
        return self.__dTongDaChi
    @TongDaChi.setter
    def TongDaChi(self, value):
        self.__dTongDaChi=value

    def Nhap(self):
        super().Nhap()
        print("Khach Hang")
        self.__sDiaChiGiao=input("Nhap dia chi giao hang: ")

    def Xuat(self):
        print("THONG TIN KHACH HANG: ")
        super().Xuat()
        print(f"Dia chi giao: {self.__sDiaChiGiao}")
        print(f"Diem tich luy IT Food: {self.__iDiemTichLuyITFood}")
        print(f"Tong da chi: {self.__dTongDaChi} đ")

    def TinhToanTien(self, soTien):
        self.__dTongDaChi+=soTien
        self.__iDiemTichLuyITFood+=int(soTien/10000)

    def ChonPhuongThucThanhToan(self):
        print("Chon phuong thuc thanh toan:")
        print("1 - Tien mat")
        print("2 - Vi dien tu")
        print("3 - The")
        chon = input("Lua chon: ")

        if chon == "2":
            vi = ViDienTu()
            vi.Nhap()
            return vi
        elif chon == "3":
            the = The()
            the.Nhap()
            return the
        else:
            return TienMat()

class ChuQuan(NguoiDung):
    def __init__(self, ma="", ten="", sdt="", email="") :
        super().__init__(ma, ten, sdt, email)
        self.__dsQuan=[]
        self.__dTongDoanhThu=0.0

    @property
    def DsQuan(self):
        return self.__dsQuan
    @DsQuan.setter
    def DsQuan(self, value):
        self.__dsQuan=value

    @property
    def TongDoanhThu(self):
        return self.__dTongDoanhThu
    @TongDoanhThu.setter
    def TongDoanhThu(self, value):
        self.__dTongDoanhThu=value

    def ThemQuan(self, quan):
        self.__dsQuan.append(quan)
        quan.ChuCuaQuan=self

    def TimQuan(self, ma):
        for quan in self.__dsQuan:
            if quan.Ma==ma:
                return quan
        return None

    def HienThiDsQuan(self):
        print(f"Danh sach quan cua chu quan {self._sTen}")
        for quan in self.__dsQuan:
            print(f"{quan.Ma} - {quan.Ten} - {quan.DiaChi} ")

    def Xuat(self):
        print("THONG TIN CHU QUAN: ")
        super().Xuat()
        print(f"So quan chu so huu: {len(self.__dsQuan)}")
        print(F"Tong doanh thu: {self.__dTongDoanhThu} đ")

    def TinhToanTien(self, soTien):
        self.__dTongDoanhThu+=soTien

class TaiXe(NguoiDung):
    def __init__(self, ma="", ten="", sdt="", email="", bienSo="") :
        super().__init__(ma, ten, sdt, email)

        self.__sBienSo=bienSo
        self.__bDangRanh=True
        self.__iSoDonDaGiao=0
        self.__dTongThuNhap=0.0

    @property
    def BienSo(self):
        return self.__sBienSo
    @BienSo.setter
    def BienSo(self, value):
        self.__sBienSo=value

    @property
    def DangRanh(self):
        return self.__bDangRanh
    @DangRanh.setter
    def DangRanh(self, value):
        self.__bDangRanh=value

    @property
    def SoDonDaGiao(self):
        return self.__iSoDonDaGiao
    @SoDonDaGiao.setter
    def SoDonDaGiao(self, value):
        self.__iSoDonDaGiao=value

    def TinhToanTien(self, soTien):
        self.__dTongThuNhap += soTien

    def Nhap(self):
        super().Nhap()
        self.__sBienSo=input("Nhap bien so xe: ")
        
    def Xuat(self):
        print("THONG TIN TAI XE: ")
        super().Xuat()
        print(f"Bien so xe: {self.__sBienSo}")
        print(f"Dang ranh: {self.__bDangRanh}")
        print(f"So don da giao: {self.__iSoDonDaGiao}")
        print(f"Tong thu nhap: {self.__dTongThuNhap}")

    def HoanThanhGiao(self):
        self.__iSoDonDaGiao+=1
        self.__bDangRanh=True

class MonAn:
    def __init__(self, ma="", ten="", gia=None):
        self._sMa=ma
        self._sTen=ten
        self._dGia=0.0
        if gia is not None:
            self._dGia=gia

    @property
    def Ma(self):
        return self._sMa
    @Ma.setter
    def Ma(self, value):
        self._sMa=value

    @property
    def Ten(self):
        return self._sTen
    @Ten.setter
    def Ten(self, value):
        self._sTen=value

    @property
    def Gia(self):
        return self._dGia
    @Gia.setter
    def Gia(self, value):
        if value<=0:
            raise ValueError("Gia cua mon an phai > 0.")
        self._dGia=value

    def Nhap(self):
        print("Mon an")
        self._sMa=input("Nhap ma mon an: ")
        self._sTen=input("Nhap ten mon an: ")
        self._dGia=float(input("Nhap gia mon an: "))

    def HienThi(self):
        print(f"Mon an: {self._sMa} - {self._sTen} - {self._dGia}")

class ChiTietDon:
    def __init__(self, mon=None, soLuong=0):
        self.__mon=mon
        self.__iSoLuong=soLuong

    @property
    def Mon(self):
        return self.__mon
    @Mon.setter
    def Mon(self, value):
        self.__mon=value

    @property
    def SoLuong(self):
        return self.__iSoLuong
    @SoLuong.setter
    def SoLuong(self, value):
        self.__iSoLuong=value

    def ThanhTien(self):
        return float(self.__mon.Gia * self.__iSoLuong)

    def HienThi(self):
        print(f"{self.__mon.Ten}-{self.__iSoLuong}-{self.ThanhTien()} đ")

class Voucher:
    def __init__(self, ma="", ten="", phanTram=None):
        self.__sMa=ma
        self.__sTen=ten
        self.__bConSuDung=True
        self.__dPhanTram=0.0
        if phanTram is not None:
            self.__dPhanTram=phanTram

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
    def PhanTram(self):
        return self.__dPhanTram
    @PhanTram.setter
    def PhanTram(self, value):
        if value <=0 or value >100:
            raise ValueError("Phan tram giam phai lon hon 0% va khong vuot qua 100%.")
        self.__dPhamTram=value

    @property
    def ConSuDung(self):
        return self.__bConSuDung
    @ConSuDung.setter
    def ConSuDung(self, value):
        self.__bConSuDung=value

    def TinhGiam(self, tienMon):
        if self.__bConSuDung:
            return tienMon * self.__dPhanTram/100
        return 0

    def SuDung(self):
        self.__bConSuDung=False

    def Nhap(self):
        self.__sMa=input("Nhap ma cua voucher: ")
        self.__sTen=input("Nhap ten cua voucher: ")
        print("Nhap phan tram cua voucher (1-100): ")
        self.__dPhanTram=float(input())
        self.__bConSuDung=True

    def Xuat(self):
        print(f"Voucher: {self.__sMa} - {self.__sTen} | GIAM : {self.__dPhanTram}% | Con su dung: {self.__bConSuDung}")

class Quan:
    def __init__(self, ma="", ten="", diaChi=""):
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
    def Menu(self):
        return self.__menu
    @Menu.setter
    def Menu(self, value):
        self.__menu = value
 
    @property
    def DsVoucher(self):
        return self.__dsVoucher
    @DsVoucher.setter
    def DsVoucher(self, value):
        self.__dsVoucher = value
     
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
     
    def TimMon(self, ma):
        for mon in self.__menu:
            if mon.Ma == ma:
                return mon
        return None
 
    def HienThiMenu(self):
        print(f"--- Menu cua quan {self.__sTen} ---")
        for mon in self.__menu:
            print(f" {mon.Ma} - {mon.Ten} - {mon.Gia} ")

    def NhapMenu(self):
        so_mon = int(input("Nhap so mon trong menu: "))
        for i in range(so_mon):
            print(f"\n--- Nhap mon {i + 1} ---")
            mon = MonAn()
            mon.Nhap()
            self.ThemMon(mon)
 
    def ThemVoucher(self, v):
        self.__dsVoucher.append(v)
 
    def TimVoucher(self, ma):
        for v in self.__dsVoucher:
            if v.Ma==ma:
                return v
        return None
 
    def CoVoucher(self):
        return any(v.ConSuDung for v in self.__dsVoucher)
 
    def HienThiVoucherConDung(self):
        print(f"Voucher hien co cua quan {self.__sTen}: ")
        for v in self.__dsVoucher:
            if v.ConSuDung:
                v.Xuat()
 
    def HienThiVoucherDaDung(self):
        print("VOUCHER DA DUNG: ")
        print(f"Voucher da dung cua quan {self.__sTen}: ")
        for v in self.__dsVoucher:
            if not v.ConSuDung:
                v.Xuat()

    def NhapVoucher(self):
        so_voucher = int(input("Nhap so voucher cua quan: "))
        for i in range(so_voucher):
            print(f"\n--- Nhap voucher {i + 1} ---")
            v = Voucher()
            v.Nhap()
            self.ThemVoucher(v)

    def ChonVoucher(self):
        if not self.CoVoucher():
            print("Quan nay hien khong co voucher khuyen mai.")
            return None

        self.HienThiVoucherConDung()
        return input("Nhap ma voucher muon dung (bo trong neu khong dung): ")
 
    def Xuat(self):
        print("THONG TIN QUAN :")
        print(f"Ma quan: {self.__sMa}")
        print(f"Ten quan: {self.__sTen}")
        print(f"Dia chi: {self.__sDiaChi}")
        print(f"Dang mo cua: {self.__bDangMoCua}")
        print(f"So mon trong menu: {len(self.__menu)}")
        print(f"So voucher: {len(self.__dsVoucher)}")
        if self.__chuQuan is not None:
            print(f"Chu quan: {self.__chuQuan.Ten} (Ma: {self.__chuQuan.Ma})")
            print(f"Doanh thu cua chu: {self.__chuQuan.TongDoanhThu}d")
 
    def NhanDon(self, don):
        print(f"[Thong bao quan {self.__sTen}] Nhan duoc don {don.Ma}, bat dau lam mon!!!")
        don.CapNhatTrangThai(TrangThaiDon.DangLam)

class PhuongThucThanhToan(ABC):
    @abstractmethod
    def XuLyThanhToan(self, soTien):
        pass

class TienMat(PhuongThucThanhToan):
    def XuLyThanhToan(self, soTien):
        print(f"Thanh toan {soTien}đ bang tien mat khi nhan hang.")
        return True

class ViDienTu(PhuongThucThanhToan):
    def __init__(self, soDu=0.0):
        self.__dSoDu=soDu

    @property
    def SoDu(self):
        return self.__dSoDu
    @SoDu.setter
    def SoDu(self, value):
        self.__dSoDu=value

    def Nhap(self):
        print("Nhap so du vi: ")
        self.__dSoDu=float(input())

    def XuLyThanhToan(self, soTien):
        if self.__dSoDu<soTien:
            print("So du vi hien tai khong du!")
            return False
        self.__dSoDu-=soTien
        print(f"Da thanh toan {soTien}đ bang vi dien tu. So du con lai: {self.__dSoDu}đ")
        return True

class The(PhuongThucThanhToan):
    PHI_GIAO_DICH_MAC_DINH = 3000.0

    def __init__(self, soThe=""):
        self.__sSoThe=soThe
        self.__dPhiGiaoDich=The.PHI_GIAO_DICH_MAC_DINH

    @property
    def SoThe(self):
        return self.__sSoThe
    @SoThe.setter
    def SoThe(self, value):
        self.__sSoThe=value

    @property
    def PhiGiaoDich(self):
        return self.__dPhiGiaoDich
    @PhiGiaoDich.setter
    def PhiGiaoDich(self, value):
        self.__dPhiGiaoDich=value

    def Nhap(self):
        print("Nhap ID the: ")
        self.__sSoThe=input()
        self.__dPhiGiaoDich=The.PHI_GIAO_DICH_MAC_DINH

    def XuLyThanhToan(self, soTien):
        tongTien=soTien+self.__dPhiGiaoDich
        print(f"Da thanh toan {soTien}đ bang the {self.SoThe}+ phi giao dich {self.__dPhiGiaoDich}đ (Tong tru vao the: {tongTien}đ)")
        return True

class DonHang:
    __CHIET_KHAU_CUA_QUAN=0.25
    __CHIET_KHAU_CUA_TAI_XE=0.20
    __PHI_NEN_TANG=3000.0

    @classmethod
    def ChietKhauCuaQuan(cls):
        return cls.__CHIET_KHAU_CUA_QUAN
    @classmethod
    def ChietKhauCuaQuan(cls, value):
        cls.__CHIET_KHAU_CUA_QUAN=value

    @classmethod
    def ChietKhauCuaTaiXe(cls):
        return cls.__CHIET_KHAU_CUA_TAI_XE
    @classmethod
    def ChietKhauCuaTaiXe(cls, value):
        cls.__CHIET_KHAU_CUA_TAI_XE=value

    @classmethod
    def PhiNenTang(cls):
        return cls.__PHI_NEN_TANG
    @classmethod
    def PhiNenTang(cls, value):
        cls.__PHI_NEN_TANG=value

    def __init__(self, ma="", khach=None, quan=None):
        self.__sMa=ma
        self.__KhachHang=khach
        self.__Quan=quan
        self.__TaiXe=None
        self.__dsChiTiet=[]
        self.__dKhoangCachKm=0.0
        self.__trangThai=TrangThaiDon.ChoXacNhan
        self.__thanhToan=None
        self.__dSoTienDaThanhToan=0.0
        self.__dSoTienGiamGia=0.0

    @property
    def Ma(self):
        return self.__sMa
    @Ma.setter
    def Ma(self, value):
        self.__sMa=value

    @property
    def Khach(self):
        return self.__KhachHang
    @Khach.setter
    def Khach(self, value):
        self.__KhachHang=value

    @property
    def Quan(self):
        return self.__Quan
    @Quan.setter
    def Quan(self, value):
        self.__Quan=value

    @property
    def TaiXe(self):
        return self.__taiXe
    @TaiXe.setter
    def TaiXe(self, value):
        self.__taiXe=value

    @property
    def DsChiTiet(self):
        return self.__dsChiTiet
    @DsChiTiet.setter
    def DsChiTiet(self, value):
        self.__dsChiTiet=value

    @property
    def KhoangCachKm(self):
        return self.__dKhoangCachKm
    @KhoangCachKm.setter
    def KhoangCachKm(self, value):
        self.__dKhoangCachKm=value

    @property
    def TrangThai(self):
        return self.__trangThai
    @TrangThai.setter
    def TrangThai(self, value):
        self.__trangThai=value

    @property
    def PtThanhToan(self):
        return self.__thanhToan
    @PtThanhToan.setter
    def PtThanhToan(self, value):
        self.__thanhToan=value

    @property
    def SoTienDaThanhToan(self):
        return self.__dSoTienDaThanhToan
    @SoTienDaThanhToan.setter
    def SoTienDaThanhToan(self, value):
        self.__dSoTienDaThanhToan=value

    @property
    def SoTienGiamGia(self):
        return self.__dSoTienGiamGia
    @SoTienGiamGia.setter
    def SoTienGiamGia(self, value):
        self.__dSoTienGiamGia=value

    def GoiMon(self, mon, soLuong):
        self.__dsChiTiet.append(ChiTietDon(mon, soLuong))

    def Nhap(self):
        self.Quan.HienThiMenu()
        soMon=int(input("Nhap so mon muon dat: "))
        for i in range(soMon):
            print("Nhap ma mon: ")
            maMon=input()
            print("Nhap so luong mon: ")
            soLuong=int(input())
            mon=self.__Quan.TimMon(maMon)

            if mon is not None:
                self.GoiMon(mon, soLuong)
            else:
                 print(f"Khong tim thay mon co ma '{maMon}'. Bo qua...")

        self.__dKhoangCachKm=float(input("Nhap khoang cach giao(km): "))
        self.__trangThai=TrangThaiDon.ChoXacNhan
        
    def CapNhatTrangThai(self, trangThaiMoi):
        self.__trangThai=trangThaiMoi

    def Xuat(self):
        print(f"DON HANG :{self.__sMa}")
        for ct in self.__dsChiTiet:
            ct.HienThi()
        print(f"Trang thai: {self.__trangThai.name}")

    def TongTienMon(self):
        tong=0
        for ct in self.__dsChiTiet:
            tong=tong+ct.ThanhTien()
        return tong

    def TinhPhiShip(self):
        if self.__dKhoangCachKm <=3:
            return 15000
        if self.__dKhoangCachKm <=7:
            return 25000
        return 40000

    def TinhGiamGia(self, maVoucher):
        if maVoucher is None:
            return 0
        v = self.__Quan.TimVoucher(maVoucher)
        if v is None:
            return 0
        return v.TinhGiam(self.TongTienMon())

    def TongThanhToan(self, maVoucher):
        return (self.TongTienMon() - self.TinhGiamGia(maVoucher)
                + self.TinhPhiShip() + DonHang.__PHI_NEN_TANG)

    def GanTaiXe(self, tx):
        self.__TaiXe=tx
        tx.DangRanh=False
        self.__trangThai=TrangThaiDon.DangGiao
        print(f"[Thong bao tai xe {tx.Ten}] Ban duoc phan cong giao don {self.__sMa}.")
 
    def ThanhToan(self, ptTT, maVoucher):
        self.__thanhToan=ptTT
        giam = self.TinhGiamGia(maVoucher)
        tongTien = self.TongThanhToan(maVoucher)
        self.__dSoTienDaThanhToan=tongTien
        self.__dSoTienGiamGia=giam
        thanhCong = self.__thanhToan.XuLyThanhToan(tongTien)
        if thanhCong:
            self.__trangThai = TrangThaiDon.DaThanhToan
            if maVoucher is not None:
                v = self.__Quan.TimVoucher(maVoucher)
                if v is not None:
                    v.SuDung()
            self.__KhachHang.TinhToanTien(tongTien)
            tienCuaQuan = (self.TongTienMon() - giam) * (1 - DonHang.__CHIET_KHAU_CUA_QUAN)
            self.__Quan.ChuCuaQuan.TinhToanTien(tienCuaQuan)
        else:
            print("Thanh toan that bai! Don hang chua duoc thanh toan.")
        return thanhCong
 
    def HoanThanhDon(self):
        if self.__trangThai != TrangThaiDon.DangGiao:
            print("Don hang chua du dieu kien de hoan thanh.")
            return
        if self.__TaiXe is not None:
            tienCuaTaiXe = self.TinhPhiShip() * (1 - DonHang.__CHIET_KHAU_CUA_TAI_XE)
            self.__TaiXe.TinhToanTien(tienCuaTaiXe)
            self.__TaiXe.HoanThanhGiao()
        self.__trangThai = TrangThaiDon.HoanThanh
        print(f"Don hang {self.__sMa} da giao thanh cong.")
 
    def HuyDon(self):
        if self.__trangThai == TrangThaiDon.HoanThanh:
            print("Khong the huy don da hoan thanh.")
            return
        self.__trangThai = TrangThaiDon.DaHuy
        if self.__TaiXe is not None:
            self.__TaiXe.DangRanh = True
        print(f"Don hang {self.__sMa} da bi huy.")
 
    def InHoaDon(self):
        print(f"---- HOA DON {self.__sMa} ----")
        for ct in self.__dsChiTiet:
            ct.HienThi()
        print(f"Tien mon: {self.TongTienMon()}đ")
        if self.__dSoTienGiamGia > 0:
            print(f"Giam gia voucher: -{self.__dSoTienGiamGia}đ")
        print(f"Phi ship: {self.TinhPhiShip()}đ")
        print(f"Phi nen tang: {DonHang.__PHI_NEN_TANG}đ")
        print(f"Tong thanh toan: {self.SoTienDaThanhToan}đ")
        print(f"Trang thai: {self.__trangThai.name}")

class UngDung:
    def __init__(self, dsKhachHang=None, dsChuQuan=None, dsTaiXe=None, dsQuan=None, dsDonHang=None):
        self.__dsKhachHang = dsKhachHang if dsKhachHang is not None else []
        self.__dsChuQuan = dsChuQuan if dsChuQuan is not None else []
        self.__dsTaiXe = dsTaiXe if dsTaiXe is not None else []
        self.__dsQuan = dsQuan if dsQuan is not None else []
        self.__dsDonHang = dsDonHang if dsDonHang is not None else []
  
    @property
    def DsKhachHang(self):
        return self.__dsKhachHang
    @DsKhachHang.setter
    def DsKhachHang(self, value):
        self.__dsKhachHang = value

    @property
    def DsChuQuan(self):
        return self.__dsChuQuan
    @DsChuQuan.setter
    def DsChuQuan(self, value):
        self.__dsChuQuan = value

    @property
    def DsTaiXe(self):
        return self.__dsTaiXe
    @DsTaiXe.setter
    def DsTaiXe(self, value):
        self.__dsTaiXe = value
       
    @property
    def DsQuan(self):
        return self.__dsQuan
    @DsQuan.setter
    def DsQuan(self, value):
        self.__dsQuan = value
   
    @property
    def DsDonHang(self):
        return self.__dsDonHang
    @DsDonHang.setter
    def DsDonHang(self, value):
        self.__dsDonHang = value

    def ThemKhachHang(self, kh):
        self.__dsKhachHang.append(kh)
 
    def ThemChuQuan(self, cq):
        self.__dsChuQuan.append(cq)
 
    def ThemTaiXe(self, tx):
        self.__dsTaiXe.append(tx)
 
    def ThemQuan(self, q):
        self.__dsQuan.append(q)
 
    def TimTaiXeRanh(self):
        for tx in self.__dsTaiXe:
            if tx.DangRanh:
                return tx
        return None
 
    def TimTaiXeRanhVaGanDon(self, don):
        tx = self.TimTaiXeRanh()
        if tx is not None:
            don.GanTaiXe(tx)
        else:
            print("Khong co tai xe ranh !!!")
 
    def TaoDonHang(self, ma, kh, quan):
        if not quan.DangMoCua:
            print("Quan hien dang dong cua, khong the dat hang !!!")
            return None
        don = DonHang(ma, kh, quan)
        self.__dsDonHang.append(don)
        return don
 
    def BaoCao(self):
        print("----- BAO CAO HE THONG -----")
        soDonHoanThanh = 0
        soDonHuy = 0

        for don in self.DsDonHang:
            if don.TrangThai == TrangThaiDon.HoanThanh:
                soDonHoanThanh += 1

            if don.TrangThai == TrangThaiDon.DaHuy:
                soDonHuy += 1

        print(f"Don hoan thanh: {soDonHoanThanh}")
        print(f"Don da huy: {soDonHuy}")

        print("THONG TIN TAI XE")

        for tx in self.DsTaiXe:
            tx.Xuat()
            print()

    def TimQuan(self, ma):
        for q in self.DsQuan:
            if q.Ma == ma:
                return q
        return None

    def TimKhachHang(self, ma):
        for kh in self.DsKhachHang:
            if kh.Ma == ma:
                return kh
        return None

    def HienThiDsQuan(self):
        print("\n--- DANH SACH QUAN HIEN CO ---")
        for q in self.DsQuan:
            print(f"[{q.Ma}] {q.Ten} - Dia chi: {q.DiaChi}")

    def HienThiDsKhachHang(self):
        print("\n--- DANH SACH KHACH HANG ---")
        for kh in self.DsKhachHang:
            print(f"[{kh.Ma}] {kh.Ten} - SDT: {kh.SDT}")

    def KhoiTaoDuLieuMau(self):
        cq1 = ChuQuan("CQ01", "Nguyen Van Chu", "0901111111", "chu1@food.vn")
        cq2 = ChuQuan("CQ02", "Tran Thi Chu", "0902222222", "chu2@food.vn")
        self.ThemChuQuan(cq1)
        self.ThemChuQuan(cq2)

        q1 = Quan("Q01", "Com Tam Sai Gon", "123 Nguyen Trai, Q5")
        cq1.ThemQuan(q1)
        q1.ThemMon(MonAn("M01", "Com Suon Bi Cha", 45000))
        q1.ThemMon(MonAn("M02", "Com Suon Trung", 40000))
        q1.ThemMon(MonAn("M03", "Canh Kho Qua", 15000))
        q1.ThemVoucher(Voucher("GIAM10", "Giam 10%", 10))
        q1.ThemVoucher(Voucher("GIAM20", "Giam 20%", 20))
        self.ThemQuan(q1)

        q2 = Quan("Q02", "Tra Sua Gong Cha", "456 Le Loi, Q1")
        cq2.ThemQuan(q2)
        q2.ThemMon(MonAn("TS01", "Tra Sua Tran Chau", 35000))
        q2.ThemMon(MonAn("TS02", "Tra Dao Cam Sa", 30000))
        q2.ThemVoucher(Voucher("GIAM15", "Giam 15%", 15))
        self.ThemQuan(q2)

        kh1 = KhachHang("KH01", "Nguyen Van An", "0911222333", "an@gmail.com", "789 Tran Hung Dao")
        kh2 = KhachHang("KH02", "Le Thi Binh", "0944555666", "binh@gmail.com", "101 Nguyen Hue")
        self.ThemKhachHang(kh1)
        self.ThemKhachHang(kh2)

        tx1 = TaiXe("TX01", "Tran Van Chay", "0977888999", "chay@food.vn", "59X1-12345")
        tx2 = TaiXe("TX02", "Pham Van Giao", "0988777666", "giao@food.vn", "59Y2-67890")
        self.ThemTaiXe(tx1)
        self.ThemTaiXe(tx2)

        print(">> Da nhap thanh cong: 2 Quan (kem Menu, Voucher), 2 Khach hang, 2 Tai xe!")

def main():
    app = UngDung()
    cq = ChuQuan()
    quan = Quan()
    kh = KhachHang()
    tx = TaiXe()

    lua_chon = -1
    while lua_chon != 0:
        print("----------------- HE THONG ITFOOD -----------------")
        print("1. Nhap du lieu he thong (Khach, Quan, Menu, Tai Xe)")
        print("2. Khach hang Tao don & Thanh toan")
        print("3. Hien thi ket qua (Bao cao he thong, Doanh thu)")
        print("0. Thoat")
        print("---------------------------------------------------")
        lua_chon = int(input("Chon chuc nang: "))

        if lua_chon == 1:
            print("\n--- CHON PHUONG THUC NHAP DU LIEU ---")
            print("1. Nap nhanh du lieu mau (2 Quan, 2 Khach, 2 Tai xe)")
            print("2. Nhap thu cong tu ban phim")
            chon_nhap = input("Lua chon cua ban: ")

            if chon_nhap == "1":
                app.KhoiTaoDuLieuMau()
            else:
                cq = ChuQuan()
                quan = Quan()
                kh = KhachHang()
                tx = TaiXe()

                print("\n--- NHAP THONG TIN CHU QUAN ---")
                cq.Nhap()
                app.ThemChuQuan(cq)

                print("\n--- NHAP THONG TIN QUAN ---")
                quan.Nhap()
                cq.ThemQuan(quan)
                app.ThemQuan(quan)

                quan.NhapMenu()
                quan.NhapVoucher()

                print("\n--- NHAP THONG TIN KHACH HANG ---")
                kh.Nhap()
                app.ThemKhachHang(kh)

                print("\n--- NHAP THONG TIN TAI XE ---")
                tx.Nhap()
                app.ThemTaiXe(tx)

        elif lua_chon == 2:
            while True:  
                if len(app.DsQuan) == 0 or len(app.DsKhachHang) == 0:
                    print("Chua co du lieu he thong! Vui long chon chuc nang 1.")
                    break

                app.HienThiDsKhachHang()
                ma_khach_chon = input("Nhap MA k/h dat don (vi du KH01): ")
                kh_chon = app.TimKhachHang(ma_khach_chon)
                if kh_chon is None:
                    print("Khong tim thay khach hang nay! Huy thao tac.")
                    break

                app.HienThiDsQuan()
                ma_quan_chon = input("Nhap MA quan dat k/h dat (vi du Q01, Q02): ")
                quan_chon = app.TimQuan(ma_quan_chon)
                if quan_chon is None:
                    print("Khong tim thay quan nay! Huy thao tac.")
                    break

                print("\n--- TAO DON HANG ---")
                ma_don = input("Nhap ma don hang (vi du DH01): ")
                don = app.TaoDonHang(ma_don, kh_chon, quan_chon)

                if don is None:
                    print("Khong the tao don hang. Ket thuc.")
                    break

                don.Nhap()
                don.Xuat()

                print("\n---- QUAN NHAN DON ----")
                quan_chon.NhanDon(don)

                huy_chon = input("Ban co muon huy don khong? (y/n): ")
                if huy_chon == "y" or huy_chon == "Y":
                    don.HuyDon()
                    print("\n---- HOA DON ----")
                    don.InHoaDon()
                    break

                print("\n---- THANH TOAN ----")
                pt_tt = kh_chon.ChonPhuongThucThanhToan()
                ma_voucher = quan_chon.ChonVoucher()

                thanh_cong = don.ThanhToan(pt_tt, ma_voucher)
                if not thanh_cong:
                    print("Chuyen sang thanh toan bang tien mat.")
                    pt_tt = TienMat()
                    thanh_cong = don.ThanhToan(pt_tt, ma_voucher)

                if not thanh_cong:
                    print("Khong the thanh toan don hang.")
                    break

                print("\n---- PHAN CONG TAI XE ----")
                app.TimTaiXeRanhVaGanDon(don)

                print("\n---- GIAO HANG ----")
                if don.TrangThai == TrangThaiDon.DangGiao:
                    don.HoanThanhDon()
                else:
                    print("Don hang chua duoc giao vi chua co tai xe.")

                print("\n---- HOA DON ----")
                don.InHoaDon()
                break  

        elif lua_chon == 3:
            if len(app.DsQuan) == 0:
                print("Chua co du lieu he thong ! Vui long chon chuc nang 1.")
            else:
                for q in app.DsQuan:
                    q.Xuat()
                    q.HienThiVoucherDaDung()
                    print()
                for k in app.DsKhachHang:
                    k.Xuat()
                    print()
                app.BaoCao()

        elif lua_chon == 0:
            print("Ket thuc chuong trinh !!!")

        else:
            print("Chuc nang khong hop le.")

        if lua_chon != 0:
            input("\n[Nhan Enter de quay lai Menu...]")


if __name__ == "__main__":
    main()    


















        
















   

    


    
























    





