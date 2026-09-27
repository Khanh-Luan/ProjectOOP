#DỰ ÁN IT FOOD - PHIÊN BẢN 1
#XÂY DỰNG KHUNG CHO DỰ ÁN:
#Các thư viện:
from abc import ABC, abstractmethod
from enum import Enum

# ================= TRANG THAI DON HANG (ENUM) =================
class TrangThaiDon(Enum):
    ChoXacNhan = 1
    DangLam = 2
    DaThanhToan = 3
    DangGiao = 4
    HoanThanh = 5
    DaHuy = 6


# ================= NGUOI DUNG =================
class NguoiDung(ABC):
    def __init__(self, ma="", ten="", sdt="", email=""):
        # TODO: gan cac tham so vao thuoc tinh
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
    def Sdt(self):
        return self._sSdt

    @Sdt.setter
    def Sdt(self, value):
        self._sSdt = value

    @property
    def Email(self):
        return self._sEmail

    @Email.setter
    def Email(self, value):
        self._sEmail = value

    # Virtual
    def Nhap(self):
        # TODO: nhap ma, ten, sdt, email tu ban phim
        pass

    # Virtual
    def Xuat(self):
        # TODO: in ra ma, ten, sdt, email
        pass

    @abstractmethod
    def TinhToanTien(self, soTien):
        pass


# ================= KHACH HANG =================
class KhachHang(NguoiDung):
    def __init__(self, ma="", ten="", sdt="", email="", diaChi=""):
        super().__init__(ma, ten, sdt, email)

        self.__sDiaChiGiao = diaChi
        self.__iDiemTichLuyITFood = 0
        self.__dTongDaChi = 0

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

    # Override
    def Nhap(self):
        # TODO: goi super().Nhap() roi nhap them dia chi giao
        pass

    # Override
    def Xuat(self):
        # TODO: goi super().Xuat() roi in them dia chi,
        # diem tich luy, tong da chi
        pass

    # Override
    def TinhToanTien(self, soTien):
        # TODO: cong don tong da chi,
        # tinh diem tich luy (soTien / 10000)
        pass


# ================= CHU QUAN =================
class ChuQuan(NguoiDung):
    def __init__(self, ma="", ten="", sdt="", email=""):
        super().__init__(ma, ten, sdt, email)

        self.__dsQuan = []
        self.__dTongDoanhThu = 0

    @property
    def TongDoanhThu(self):
        return self.__dTongDoanhThu

    def ThemQuan(self, quan):
        # TODO: them quan vao dsQuan,
        # gan quan.ChuCuaQuan = self
        pass

    def TimQuan(self, ma):
        # TODO: duyet dsQuan tim theo ma,
        # return None neu khong thay
        return None

    def HienThiDsQuan(self):
        # TODO: in danh sach quan
        # (ma, ten, dia chi)
        pass

    # Override
    def Xuat(self):
        # TODO: goi super().Xuat() roi in so quan so huu,
        # tong doanh thu
        pass

    # Override
    def TinhToanTien(self, soTien):
        # TODO: cong don doanh thu
        pass


# ================= TAI XE =================
class TaiXe(NguoiDung):
    def __init__(self, ma="", ten="", sdt="", email="", bienSo=""):
        super().__init__(ma, ten, sdt, email)

        self.__sBienSo = bienSo
        self.__bDangRanh = True
        self.__iSoDonDaGiao = 0
        self.__dTongThuNhap = 0

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

    @property
    def TongThuNhap(self):
        return self.__dTongThuNhap

    # Override
    def TinhToanTien(self, soTien):
        # TODO: cong don thu nhap
        pass

    # Override
    def Nhap(self):
        # TODO: goi super().Nhap() roi nhap them bien so xe
        pass

    # Override
    def Xuat(self):
        # TODO: goi super().Xuat() roi in bien so,
        # trang thai ranh, so don, thu nhap
        pass

    def HoanThanhGiao(self):
        # TODO: tang so don da giao,
        # dat bDangRanh = True
        pass


# ================= MON AN =================
class MonAn:
    def __init__(self, ma="", ten="", gia=0):
        self._sMa = ma
        self._sTen = ten
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
        # TODO: kiem tra value > 0,
        # raise exception neu khong hop le
        self._dGia = value

    # Virtual
    def Nhap(self):
        # TODO: nhap ma, ten, gia tu ban phim
        pass

    # Virtual
    def HienThi(self):
        # TODO: in ra ma - ten - gia
        pass


# ================= CHI TIET DON =================
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
        # TODO: return gia mon * so luong
        return 0

    def HienThi(self):
        # TODO: in ten mon x so luong = thanh tien
        pass


# ================= VOUCHER =================
class Voucher:
    def __init__(self, ma="", ten="", phanTram=0):
        self.__sMa = ma
        self.__sTen = ten
        self.__dPhanTram = phanTram
        self.__bConSuDung = True

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
        self.__dPhanTram = value

    @property
    def ConSuDung(self):
        return self.__bConSuDung

    def TinhGiam(self, tienMon):
        # TODO: neu con su dung thi
        # return tienMon * phanTram / 100
        # nguoc lai return 0
        return 0

    def SuDung(self):
        # TODO: dat bConSuDung = False
        pass

    def Nhap(self):
        # TODO: nhap ma, ten, phan tram tu ban phim,
        # bConSuDung = True
        pass

    def Xuat(self):
        # TODO: in ma, ten, phan tram,
        # trang thai con su dung
        pass


# ================= QUAN =================
class Quan:
    def __init__(self, ma="", ten="", diaChi=""):
        self.__sMa = ma
        self.__sTen = ten
        self.__sDiaChi = diaChi
        self.__bDangMoCua = True
        self.__menu = []
        self.__dsVoucher = []
        self.__chuQuan = None

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
    def DiaChi(self):
        return self.__sDiaChi

    @DiaChi.setter
    def DiaChi(self, value):
        self.__sDiaChi = value

    @property
    def DangMoCua(self):
        return self.__bDangMoCua

    @DangMoCua.setter
    def DangMoCua(self, value):
        self.__bDangMoCua = value

    @property
    def ChuCuaQuan(self):
        return self.__chuQuan

    @ChuCuaQuan.setter
    def ChuCuaQuan(self, value):
        self.__chuQuan = value

    def Nhap(self):
        # TODO: nhap ma, ten, dia chi,
        # dat bDangMoCua = True
        pass

    def ThemMon(self, mon):
        # TODO: them mon vao menu
        pass

    def TimMon(self, ma):
        # TODO: duyet menu tim theo ma,
        # return None neu khong thay
        return None

    def HienThiMenu(self):
        # TODO: in tieu de menu cua quan
        # roi duyet in tung mon
        pass

    def ThemVoucher(self, v):
        # TODO: them voucher vao dsVoucher
        pass

    def TimVoucher(self, ma):
        # TODO: duyet dsVoucher tim theo ma,
        # return None neu khong thay
        return None

    def CoVoucher(self):
        # TODO: duyet dsVoucher,
        # return True neu co voucher con su dung
        return False

    def HienThiVoucherConDung(self):
        # TODO: in cac voucher con su dung
        pass

    def HienThiVoucherDaDung(self):
        # TODO: in cac voucher da su dung
        pass

    def Xuat(self):
        # TODO: in day du thong tin quan
        # (ma, ten, dia chi, trang thai,
        # so mon, so voucher, chu quan)
        pass

    def NhanDon(self, don):
        # TODO: in thong bao nhan don,
        # cap nhat trang thai don sang DangLam
        pass


# ================= PHUONG THUC THANH TOAN =================
class PhuongThucThanhToan(ABC):

    @abstractmethod
    def XuLyThanhToan(self, soTien):
        pass


class TienMat(PhuongThucThanhToan):

    # Override
    def XuLyThanhToan(self, soTien):
        # TODO: in thong bao thanh toan tien mat,
        # return True
        return False


class ViDienTu(PhuongThucThanhToan):
    def __init__(self, soDu=0):
        self.__dSoDu = soDu

    def Nhap(self):
        # TODO: nhap so du vi tu ban phim
        pass

    # Override
    def XuLyThanhToan(self, soTien):
        # TODO: kiem tra so du >= soTien,
        # tru tien, return True/False
        return False


class The(PhuongThucThanhToan):
    PHI_GIAO_DICH_MAC_DINH = 3000

    def __init__(self, soTheCuoi=""):
        self.__sSoTheCuoi = soTheCuoi
        self.__dPhiGiaoDich = self.PHI_GIAO_DICH_MAC_DINH

    def Nhap(self):
        # TODO: nhap 4 so cuoi the tu ban phim
        pass

    # Override
    def XuLyThanhToan(self, soTien):
        # TODO: tinh tong = soTien + phi,
        # in thong bao, return True
        return False


# ================= DON HANG =================
class DonHang:
    def __init__(self, ma, khach, quan):
        self.__sMa = ma
        self.__khach = khach
        self.__quan = quan
        self.__taiXe = None
        self.__dsChiTiet = []
        self.__dKhoangCachKm = 0
        self.__trangThai = TrangThaiDon.ChoXacNhan
        self.__thanhToan = None
        self.__dSoTienDaThanhToan = 0
        self.__dSoTienGiamGia = 0

    @property
    def Ma(self):
        return self.__sMa

    @property
    def TrangThai(self):
        return self.__trangThai

    def GoiMon(self, mon, soLuong):
        # TODO: tao ChiTietDon moi
        # va them vao dsChiTiet
        pass

    def Nhap(self):
        # TODO: hien thi menu quan,
        # cho khach chon mon + so luong,
        # nhap khoang cach, in don
        pass

    def CapNhatTrangThai(self, trangThaiMoi):
        # TODO: gan trang thai moi
        pass

    def Xuat(self):
        # TODO: in ma don,
        # danh sach chi tiet don, trang thai
        pass

    def TongTienMon(self):
        # TODO: cong thanh tien cua
        # tat ca chi tiet don
        return 0

    def TinhPhiShip(self):
        # TODO:
        # <= 3km: 15000
        # <= 7km: 25000
        # > 7km: 40000
        return 0

    def TinhGiamGia(self, maVoucher):
        # TODO: tim voucher trong quan,
        # tinh tien giam, return 0 neu khong co
        return 0

    def TongThanhToan(self, maVoucher):
        # TODO:
        # return TongTienMon - TinhGiamGia + TinhPhiShip
        return 0

    def GanTaiXe(self, tx):
        # TODO: gan tai xe,
        # dat tai xe khong ranh,
        # trang thai = DangGiao,
        # in thong bao
        pass

    def ThanhToan(self, ptTT, maVoucher):
        # TODO: xu ly thanh toan,
        # neu thanh cong thi:
        # - cap nhat trang thai = DaThanhToan
        # - su dung voucher neu co
        # - tinh toan tien cho khach hang
        # - tinh toan tien cho chu quan
        # return True/False
        return False

    def HoanThanhDon(self):
        # TODO: kiem tra trang thai DangGiao,
        # tinh tien cho tai xe,
        # hoan thanh giao,
        # trang thai = HoanThanh
        pass

    def HuyDon(self):
        # TODO: kiem tra khong the huy don da hoan thanh
        # - trang thai = DaHuy
        # - tra tai xe ve trang thai ranh neu co
        pass

    def InHoaDon(self):
        # TODO: in chi tiet don,
        # tien mon, giam gia, phi ship,
        # tong thanh toan, trang thai
        pass


# ================= UNG DUNG (LOP TONG) =================
class UngDung:
    def __init__(self):
        # TODO: khoi tao tat ca cac list
        self.__dsKhachHang = []
        self.__dsChuQuan = []
        self.__dsTaiXe = []
        self.__dsQuan = []
        self.__dsDonHang = []

    def ThemKhachHang(self, kh):
        # TODO: them vao dsKhachHang
        pass

    def ThemChuQuan(self, cq):
        # TODO: them vao dsChuQuan
        pass

    def ThemTaiXe(self, tx):
        # TODO: them vao dsTaiXe
        pass

    def ThemQuan(self, q):
        # TODO: them vao dsQuan
        pass

    def TimTaiXeRanh(self):
        # TODO: duyet dsTaiXe,
        # return tai xe dau tien dang ranh,
        # None neu khong co
        return None

    def TimTaiXeRanhVaGanDon(self, don):
        # TODO: tim tai xe ranh,
        # neu co thi gan vao don,
        # neu khong in thong bao
        pass

    def TaoDonHang(self, ma, kh, quan):
        # TODO: kiem tra quan dang mo cua,
        # tao don moi,
        # them vao dsDonHang,
        # return don
        return None

    def BaoCao(self):
        # TODO: in tong so don,
        # dem don hoan thanh/da huy,
        # in thong tin tai xe
        pass


# ================= CHAY THU =================
def NhapMenu(quan):
    # TODO: nhap so mon,
    # vong lap nhap tung mon roi them vao quan
    pass


def NhapVoucher(quan):
    # TODO: nhap so voucher,
    # vong lap nhap tung voucher roi them vao quan
    pass


def ChonPhuongThucThanhToan():
    # TODO: hien menu chon
    # 1 - TienMat
    # 2 - ViDienTu
    # 3 - The
    # return phuong thuc tuong ung
    return None


def ChonVoucher(quan):
    # TODO: kiem tra quan co voucher khong,
    # hien thi danh sach,
    # cho nhap ma voucher
    return None


def main():
    # TODO: 1. KHOI TAO DU LIEU
    # - Tao UngDung
    # - Nhap chu quan, quan, menu, voucher
    # - Nhap khach hang, tai xe

    # TODO: 2. TAO DON HANG
    # - Nhap ma don
    # - tao don
    # - cho khach nhap mon

    # TODO: 3. QUAN NHAN DON

    # TODO: 4. HUY DON (NEU MUON)
    # - Hoi khach co muon huy khong
    # - neu co thi huy va ket thuc

    # TODO: 5. THANH TOAN
    # - Chon phuong thuc thanh toan
    # - Chon voucher
    # - Neu vi dien tu that bai thi chuyen sang tien mat

    # TODO: 6. PHAN CONG TAI XE

    # TODO: 7. GIAO HANG
    # - Neu dang giao thi hoan thanh don

    # TODO: 8. HIEN THI KET QUA
    # - In hoa don
    # - thong tin quan
    # - voucher da dung
    # - thong tin khach
    # - bao cao
    pass


if __name__ == "__main__":
    main()


    


