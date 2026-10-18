from phuong_thuc_thanh_toan import PhuongThucThanhToan


class The(PhuongThucThanhToan):
    PHI_GIAO_DICH_MAC_DINH = 3000.0

    def __init__(self, soThe=""):
        self.__sSoThe = soThe
        self.__dPhiGiaoDich = The.PHI_GIAO_DICH_MAC_DINH

    @property
    def SoThe(self):
        return self.__sSoThe
    @SoThe.setter
    def SoThe(self, value):
        self.__sSoThe = value

    @property
    def PhiGiaoDich(self):
        return self.__dPhiGiaoDich
    @PhiGiaoDich.setter
    def PhiGiaoDich(self, value):
        self.__dPhiGiaoDich = value

    def Nhap(self):
        print("Nhap ID the: ")
        self.__sSoThe = input()
        self.__dPhiGiaoDich = The.PHI_GIAO_DICH_MAC_DINH

    def XuLyThanhToan(self, soTien):
        tongTien = soTien + self.__dPhiGiaoDich
        print(f"Da thanh toan {soTien}đ bang the {self.SoThe}+ phi giao dich {self.__dPhiGiaoDich}đ (Tong tru vao the: {tongTien}đ)")
        return True
