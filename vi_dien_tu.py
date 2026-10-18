from phuong_thuc_thanh_toan import PhuongThucThanhToan


class ViDienTu(PhuongThucThanhToan):
    def __init__(self, soDu=0.0):
        self.__dSoDu = soDu

    @property
    def SoDu(self):
        return self.__dSoDu
    @SoDu.setter
    def SoDu(self, value):
        self.__dSoDu = value

    def Nhap(self):
        print("Nhap so du vi: ")
        self.__dSoDu = float(input())

    def XuLyThanhToan(self, soTien):
        if self.__dSoDu < soTien:
            print("So du vi hien tai khong du!")
            return False
        self.__dSoDu -= soTien
        print(f"Da thanh toan {soTien}đ bang vi dien tu. So du con lai: {self.__dSoDu}đ")
        return True
