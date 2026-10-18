from nguoi_dung import NguoiDung


class ChuQuan(NguoiDung):
    def __init__(self, ma="", ten="", sdt="", email=""):
        super().__init__(ma, ten, sdt, email)
        self.__dsQuan = []
        self.__dTongDoanhThu = 0.0

    @property
    def DsQuan(self):
        return self.__dsQuan
    @DsQuan.setter
    def DsQuan(self, value):
        self.__dsQuan = value

    @property
    def TongDoanhThu(self):
        return self.__dTongDoanhThu
    @TongDoanhThu.setter
    def TongDoanhThu(self, value):
        self.__dTongDoanhThu = value

    def ThemQuan(self, quan):
        self.__dsQuan.append(quan)
        quan.ChuCuaQuan = self

    def TimQuan(self, ma):
        for quan in self.__dsQuan:
            if quan.Ma == ma:
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
        print(f"Tong doanh thu: {self.__dTongDoanhThu} đ")

    def TinhToanTien(self, soTien):
        self.__dTongDoanhThu += soTien
