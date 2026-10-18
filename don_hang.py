from chi_tiet_don import ChiTietDon
from trang_thai_don import TrangThaiDon


class DonHang:
    __CHIET_KHAU_CUA_QUAN = 0.25
    __CHIET_KHAU_CUA_TAI_XE = 0.20
    __PHI_NEN_TANG = 3000.0

    # Da sua: moi gia tri co 1 ham Lay (get) va 1 ham Dat (set) rieng,
    # vi ban cu dat trung ten nen ham sau ghi de ham truoc.
    @classmethod
    def LayChietKhauCuaQuan(cls):
        return cls.__CHIET_KHAU_CUA_QUAN

    @classmethod
    def DatChietKhauCuaQuan(cls, value):
        cls.__CHIET_KHAU_CUA_QUAN = value

    @classmethod
    def LayChietKhauCuaTaiXe(cls):
        return cls.__CHIET_KHAU_CUA_TAI_XE

    @classmethod
    def DatChietKhauCuaTaiXe(cls, value):
        cls.__CHIET_KHAU_CUA_TAI_XE = value

    @classmethod
    def LayPhiNenTang(cls):
        return cls.__PHI_NEN_TANG

    @classmethod
    def DatPhiNenTang(cls, value):
        cls.__PHI_NEN_TANG = value

    def __init__(self, ma="", khach=None, quan=None):
        self.__sMa = ma
        self.__khachHang = khach
        self.__quan = quan
        self.__taiXe = None          # da sua: dung thong nhat __taiXe
        self.__dsChiTiet = []
        self.__dKhoangCachKm = 0.0
        self.__trangThai = TrangThaiDon.ChoXacNhan
        self.__thanhToan = None
        self.__dSoTienDaThanhToan = 0.0
        self.__dSoTienGiamGia = 0.0

    @property
    def Ma(self):
        return self.__sMa
    @Ma.setter
    def Ma(self, value):
        self.__sMa = value

    @property
    def Khach(self):
        return self.__khachHang
    @Khach.setter
    def Khach(self, value):
        self.__khachHang = value

    @property
    def Quan(self):
        return self.__quan
    @Quan.setter
    def Quan(self, value):
        self.__quan = value

    @property
    def TaiXe(self):
        return self.__taiXe
    @TaiXe.setter
    def TaiXe(self, value):
        self.__taiXe = value

    @property
    def DsChiTiet(self):
        return self.__dsChiTiet
    @DsChiTiet.setter
    def DsChiTiet(self, value):
        self.__dsChiTiet = value

    @property
    def KhoangCachKm(self):
        return self.__dKhoangCachKm
    @KhoangCachKm.setter
    def KhoangCachKm(self, value):
        self.__dKhoangCachKm = value

    @property
    def TrangThai(self):
        return self.__trangThai
    @TrangThai.setter
    def TrangThai(self, value):
        self.__trangThai = value

    @property
    def PtThanhToan(self):
        return self.__thanhToan
    @PtThanhToan.setter
    def PtThanhToan(self, value):
        self.__thanhToan = value

    @property
    def SoTienDaThanhToan(self):
        return self.__dSoTienDaThanhToan
    @SoTienDaThanhToan.setter
    def SoTienDaThanhToan(self, value):
        self.__dSoTienDaThanhToan = value

    @property
    def SoTienGiamGia(self):
        return self.__dSoTienGiamGia
    @SoTienGiamGia.setter
    def SoTienGiamGia(self, value):
        self.__dSoTienGiamGia = value

    def GoiMon(self, mon, soLuong):
        self.__dsChiTiet.append(ChiTietDon(mon, soLuong))

    def Nhap(self):
        self.__quan.HienThiMenu()
        soMon = int(input("Nhap so mon muon dat: "))
        for i in range(soMon):
            print("Nhap ma mon: ")
            maMon = input()
            print("Nhap so luong mon: ")
            soLuong = int(input())
            mon = self.__quan.TimMon(maMon)

            if mon is not None:
                self.GoiMon(mon, soLuong)
            else:
                print(f"Khong tim thay mon co ma '{maMon}'. Bo qua...")

        self.__dKhoangCachKm = float(input("Nhap khoang cach giao(km): "))
        self.__trangThai = TrangThaiDon.ChoXacNhan

    def CapNhatTrangThai(self, trangThaiMoi):
        self.__trangThai = trangThaiMoi

    def Xuat(self):
        print(f"DON HANG :{self.__sMa}")
        for ct in self.__dsChiTiet:
            ct.HienThi()
        print(f"Trang thai: {self.__trangThai.name}")

    def TongTienMon(self):
        tong = 0
        for ct in self.__dsChiTiet:
            tong = tong + ct.ThanhTien()
        return tong

    def TinhPhiShip(self):
        if self.__dKhoangCachKm <= 3:
            return 15000
        if self.__dKhoangCachKm <= 7:
            return 25000
        return 40000

    def TinhGiamGia(self, maVoucher):
        if maVoucher is None:
            return 0
        v = self.__quan.TimVoucher(maVoucher)
        if v is None:
            return 0
        return v.TinhGiam(self.TongTienMon())

    def TongThanhToan(self, maVoucher):
        return (self.TongTienMon() - self.TinhGiamGia(maVoucher)
                + self.TinhPhiShip() + DonHang.__PHI_NEN_TANG)

    def GanTaiXe(self, tx):
        self.__taiXe = tx
        tx.DangRanh = False
        self.__trangThai = TrangThaiDon.DangGiao
        print(f"[Thong bao tai xe {tx.Ten}] Ban duoc phan cong giao don {self.__sMa}.")

    def ThanhToan(self, ptTT, maVoucher):
        self.__thanhToan = ptTT
        giam = self.TinhGiamGia(maVoucher)
        tongTien = self.TongThanhToan(maVoucher)
        self.__dSoTienDaThanhToan = tongTien
        self.__dSoTienGiamGia = giam
        thanhCong = self.__thanhToan.XuLyThanhToan(tongTien)
        if thanhCong:
            self.__trangThai = TrangThaiDon.DaThanhToan
            if maVoucher is not None:
                v = self.__quan.TimVoucher(maVoucher)
                if v is not None:
                    v.SuDung()
            self.__khachHang.TinhToanTien(tongTien)
            tienCuaQuan = (self.TongTienMon() - giam) * (1 - DonHang.__CHIET_KHAU_CUA_QUAN)
            self.__quan.ChuCuaQuan.TinhToanTien(tienCuaQuan)
        else:
            print("Thanh toan that bai! Don hang chua duoc thanh toan.")
        return thanhCong

    def HoanThanhDon(self):
        if self.__trangThai != TrangThaiDon.DangGiao:
            print("Don hang chua du dieu kien de hoan thanh.")
            return
        if self.__taiXe is not None:
            tienCuaTaiXe = self.TinhPhiShip() * (1 - DonHang.__CHIET_KHAU_CUA_TAI_XE)
            self.__taiXe.TinhToanTien(tienCuaTaiXe)
            self.__taiXe.HoanThanhGiao()
        self.__trangThai = TrangThaiDon.HoanThanh
        print(f"Don hang {self.__sMa} da giao thanh cong.")

    def HuyDon(self):
        if self.__trangThai == TrangThaiDon.HoanThanh:
            print("Khong the huy don da hoan thanh.")
            return
        self.__trangThai = TrangThaiDon.DaHuy
        if self.__taiXe is not None:
            self.__taiXe.DangRanh = True
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
