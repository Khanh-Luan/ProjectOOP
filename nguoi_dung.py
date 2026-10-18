from abc import ABC, abstractmethod


class NguoiDung(ABC):
    def __init__(self, ma="", ten="", sdt="", email=""):
        self._sMa = ma
        self._sTen = ten
        self._sSdt = sdt
        self._sEmail = email

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
    def SDT(self):
        return self._sSdt
    @SDT.setter
    def SDT(self, value):
        self._sSdt = value

    @property
    def Email(self):
        return self._sEmail
    @Email.setter
    def Email(self, value):
        self._sEmail = value

    def Nhap(self):
        self._sMa = input("Nhap ma: ")
        self._sTen = input("Nhap ten: ")
        self._sSdt = input("Nhap so dien thoai: ")
        self._sEmail = input("Nhap email: ")

    def Xuat(self):
        print(f"Ma: {self._sMa}")
        print(f"Ten: {self._sTen}")
        print(f"So dien thoai: {self._sSdt}")
        print(f"Dia chi email: {self._sEmail}")

    @abstractmethod
    def TinhToanTien(self, soTien):
        pass
