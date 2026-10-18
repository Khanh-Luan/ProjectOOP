from nguoi_dung import NguoiDung
from tien_mat import TienMat
from vi_dien_tu import ViDienTu
from the import The


class KhachHang(NguoiDung):
    def __init__(self, ma="", ten="", sdt="", email="", diaChi=""):
        super().__init__(ma, ten, sdt, email)
        self.__sDiaChiGiao = diaChi
        self.__iDiemTichLuyITFood = 0
        self.__dTongDaChi = 0.0

    @property
    def DiaChiGiao(self):
        return self.__sDiaChiGiao
    @DiaChiGiao.setter
    def DiaChiGiao(self, value):
        self.__sDiaChiGiao = value

    @property
    def DiemTichLuyITFood(self):
        return self.__iDiemTichLuyITFood
    @DiemTichLuyITFood.setter
    def DiemTichLuyITFood(self, value):
        self.__iDiemTichLuyITFood = value

    @property
    def TongDaChi(self):
        return self.__dTongDaChi
    @TongDaChi.setter
    def TongDaChi(self, value):
        self.__dTongDaChi = value

    def Nhap(self):
        super().Nhap()
        print("Khach Hang")
        self.__sDiaChiGiao = input("Nhap dia chi giao hang: ")

    def Xuat(self):
        print("THONG TIN KHACH HANG: ")
        super().Xuat()
        print(f"Dia chi giao: {self.__sDiaChiGiao}")
        print(f"Diem tich luy IT Food: {self.__iDiemTichLuyITFood}")
        print(f"Tong da chi: {self.__dTongDaChi} đ")

    def TinhToanTien(self, soTien):
        self.__dTongDaChi += soTien
        self.__iDiemTichLuyITFood += int(soTien / 10000)

    def ChonPhuongThucThanhToan(self):
        print("Chon phuong thuc thanh toan:")
        print("1 - Tien mat")
        print("2 - Vi dien tu")
        print("3 - The")
        chon = input("Lua chon: ")

        if chon == "2":
            vi = ViDienTu()
            vi.Nhap()
            return vi
        elif chon == "3":
            the = The()
            the.Nhap()
            return the
        else:
            return TienMat()
