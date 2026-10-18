from nguoi_dung import NguoiDung


class TaiXe(NguoiDung):
    def __init__(self, ma="", ten="", sdt="", email="", bienSo=""):
        super().__init__(ma, ten, sdt, email)
        self.__sBienSo = bienSo
        self.__bDangRanh = True
        self.__iSoDonDaGiao = 0
        self.__dTongThuNhap = 0.0

    @property
    def BienSo(self):
        return self.__sBienSo
    @BienSo.setter
    def BienSo(self, value):
        self.__sBienSo = value

    @property
    def DangRanh(self):
        return self.__bDangRanh
    @DangRanh.setter
    def DangRanh(self, value):
        self.__bDangRanh = value

    @property
    def SoDonDaGiao(self):
        return self.__iSoDonDaGiao
    @SoDonDaGiao.setter
    def SoDonDaGiao(self, value):
        self.__iSoDonDaGiao = value

    def TinhToanTien(self, soTien):
        self.__dTongThuNhap += soTien

    def Nhap(self):
        super().Nhap()
        self.__sBienSo = input("Nhap bien so xe: ")

    def Xuat(self):
        print("THONG TIN TAI XE: ")
        super().Xuat()
        print(f"Bien so xe: {self.__sBienSo}")
        print(f"Dang ranh: {self.__bDangRanh}")
        print(f"So don da giao: {self.__iSoDonDaGiao}")
        print(f"Tong thu nhap: {self.__dTongThuNhap}")

    def HoanThanhGiao(self):
        self.__iSoDonDaGiao += 1
        self.__bDangRanh = True
