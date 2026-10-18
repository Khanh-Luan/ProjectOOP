class MonAn:
    def __init__(self, ma="", ten="", gia=None):
        self._sMa = ma
        self._sTen = ten
        self._dGia = 0.0
        if gia is not None:
            self._dGia = gia

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
    def Ten(self, value):
        self._sTen = value

    @property
    def Gia(self):
        return self._dGia
    @Gia.setter
    def Gia(self, value):
        if value <= 0:
            raise ValueError("Gia cua mon an phai > 0.")
        self._dGia = value

    def Nhap(self):
        print("Mon an")
        self._sMa = input("Nhap ma mon an: ")
        self._sTen = input("Nhap ten mon an: ")
        self._dGia = float(input("Nhap gia mon an: "))

    def HienThi(self):
        print(f"Mon an: {self._sMa} - {self._sTen} - {self._dGia}")
