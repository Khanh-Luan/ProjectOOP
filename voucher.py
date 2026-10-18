class Voucher:
    def __init__(self, ma="", ten="", phanTram=None):
        self.__sMa = ma
        self.__sTen = ten
        self.__bConSuDung = True
        self.__dPhanTram = 0.0
        if phanTram is not None:
            self.__dPhanTram = phanTram

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
    def PhanTram(self):
        return self.__dPhanTram
    @PhanTram.setter
    def PhanTram(self, value):
        if value <= 0 or value > 100:
            raise ValueError("Phan tram giam phai lon hon 0% va khong vuot qua 100%.")
        self.__dPhanTram = value   # da sua loi go sai: __dPhamTram -> __dPhanTram

    @property
    def ConSuDung(self):
        return self.__bConSuDung
    @ConSuDung.setter
    def ConSuDung(self, value):
        self.__bConSuDung = value

    def TinhGiam(self, tienMon):
        if self.__bConSuDung:
            return tienMon * self.__dPhanTram / 100
        return 0

    def SuDung(self):
        self.__bConSuDung = False

    def Nhap(self):
        self.__sMa = input("Nhap ma cua voucher: ")
        self.__sTen = input("Nhap ten cua voucher: ")
        print("Nhap phan tram cua voucher (1-100): ")
        self.__dPhanTram = float(input())
        self.__bConSuDung = True

    def Xuat(self):
        print(f"Voucher: {self.__sMa} - {self.__sTen} | GIAM : {self.__dPhanTram}% | Con su dung: {self.__bConSuDung}")
