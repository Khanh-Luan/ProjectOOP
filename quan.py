from mon_an import MonAn
from voucher import Voucher
from trang_thai_don import TrangThaiDon


class Quan:
    def __init__(self, ma="", ten="", diaChi=""):
        self.__sMa = ma
        self.__sTen = ten
        self.__sDiaChi = diaChi
        self.__bDangMoCua = True
        self.__menu = []
        self.__dsVoucher = []
        self.__chuQuan = None

    @property
    def Ma(self):
        return self.__sMa
    @Ma.setter
    def Ma(self, value):
        self.__sMa = value

    @property
    def Ten(self):
        return self.__sTen
    @Ten.setter
    def Ten(self, value):
        self.__sTen = value

    @property
    def DiaChi(self):
        return self.__sDiaChi
    @DiaChi.setter
    def DiaChi(self, value):
        self.__sDiaChi = value

    @property
    def DangMoCua(self):
        return self.__bDangMoCua
    @DangMoCua.setter
    def DangMoCua(self, value):
        self.__bDangMoCua = value

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
    def ChuCuaQuan(self, value):
        self.__chuQuan = value

    def Nhap(self):
        self.__sMa = input("Nhap ma quan: ")
        self.__sTen = input("Nhap ten quan: ")
        self.__sDiaChi = input("Nhap dia chi: ")
        self.__bDangMoCua = True

    def ThemMon(self, mon):
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
            if v.Ma == ma:
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
