class ChiTietDon:
    def __init__(self, mon=None, soLuong=0):
        self.__mon = mon
        self.__iSoLuong = soLuong

    @property
    def Mon(self):
        return self.__mon
    @Mon.setter
    def Mon(self, value):
        self.__mon = value

    @property
    def SoLuong(self):
        return self.__iSoLuong
    @SoLuong.setter
    def SoLuong(self, value):
        self.__iSoLuong = value

    def ThanhTien(self):
        return float(self.__mon.Gia * self.__iSoLuong)

    def HienThi(self):
        print(f"{self.__mon.Ten}-{self.__iSoLuong}-{self.ThanhTien()} đ")
