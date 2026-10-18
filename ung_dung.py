from trang_thai_don import TrangThaiDon
from chu_quan import ChuQuan
from quan import Quan
from mon_an import MonAn
from voucher import Voucher
from khach_hang import KhachHang
from tai_xe import TaiXe
from don_hang import DonHang


class UngDung:
    def __init__(self, dsKhachHang=None, dsChuQuan=None, dsTaiXe=None, dsQuan=None, dsDonHang=None):
        self.__dsKhachHang = dsKhachHang if dsKhachHang is not None else []
        self.__dsChuQuan = dsChuQuan if dsChuQuan is not None else []
        self.__dsTaiXe = dsTaiXe if dsTaiXe is not None else []
        self.__dsQuan = dsQuan if dsQuan is not None else []
        self.__dsDonHang = dsDonHang if dsDonHang is not None else []

    @property
    def DsKhachHang(self):
        return self.__dsKhachHang
    @DsKhachHang.setter
    def DsKhachHang(self, value):
        self.__dsKhachHang = value

    @property
    def DsChuQuan(self):
        return self.__dsChuQuan
    @DsChuQuan.setter
    def DsChuQuan(self, value):
        self.__dsChuQuan = value

    @property
    def DsTaiXe(self):
        return self.__dsTaiXe
    @DsTaiXe.setter
    def DsTaiXe(self, value):
        self.__dsTaiXe = value

    @property
    def DsQuan(self):
        return self.__dsQuan
    @DsQuan.setter
    def DsQuan(self, value):
        self.__dsQuan = value

    @property
    def DsDonHang(self):
        return self.__dsDonHang
    @DsDonHang.setter
    def DsDonHang(self, value):
        self.__dsDonHang = value

    def ThemKhachHang(self, kh):
        self.__dsKhachHang.append(kh)

    def ThemChuQuan(self, cq):
        self.__dsChuQuan.append(cq)

    def ThemTaiXe(self, tx):
        self.__dsTaiXe.append(tx)

    def ThemQuan(self, q):
        self.__dsQuan.append(q)

    def TimTaiXeRanh(self):
        for tx in self.__dsTaiXe:
            if tx.DangRanh:
                return tx
        return None

    def TimTaiXeRanhVaGanDon(self, don):
        tx = self.TimTaiXeRanh()
        if tx is not None:
            don.GanTaiXe(tx)
        else:
            print("Khong co tai xe ranh !!!")

    def TaoDonHang(self, ma, kh, quan):
        if not quan.DangMoCua:
            print("Quan hien dang dong cua, khong the dat hang !!!")
            return None
        don = DonHang(ma, kh, quan)
        self.__dsDonHang.append(don)
        return don

    def BaoCao(self):
        print("----- BAO CAO HE THONG -----")
        soDonHoanThanh = 0
        soDonHuy = 0

        for don in self.DsDonHang:
            if don.TrangThai == TrangThaiDon.HoanThanh:
                soDonHoanThanh += 1
            if don.TrangThai == TrangThaiDon.DaHuy:
                soDonHuy += 1

        print(f"Don hoan thanh: {soDonHoanThanh}")
        print(f"Don da huy: {soDonHuy}")

        print("THONG TIN TAI XE")
        for tx in self.DsTaiXe:
            tx.Xuat()
            print()

    def TimQuan(self, ma):
        for q in self.DsQuan:
            if q.Ma == ma:
                return q
        return None

    def TimKhachHang(self, ma):
        for kh in self.DsKhachHang:
            if kh.Ma == ma:
                return kh
        return None

    def HienThiDsQuan(self):
        print("\n--- DANH SACH QUAN HIEN CO ---")
        for q in self.DsQuan:
            print(f"[{q.Ma}] {q.Ten} - Dia chi: {q.DiaChi}")

    def HienThiDsKhachHang(self):
        print("\n--- DANH SACH KHACH HANG ---")
        for kh in self.DsKhachHang:
            print(f"[{kh.Ma}] {kh.Ten} - SDT: {kh.SDT}")

    def KhoiTaoDuLieuMau(self):
        cq1 = ChuQuan("CQ01", "Nguyen Van Chu", "0901111111", "chu1@food.vn")
        cq2 = ChuQuan("CQ02", "Tran Thi Chu", "0902222222", "chu2@food.vn")
        self.ThemChuQuan(cq1)
        self.ThemChuQuan(cq2)

        q1 = Quan("Q01", "Com Tam Sai Gon", "123 Nguyen Trai, Q5")
        cq1.ThemQuan(q1)
        q1.ThemMon(MonAn("M01", "Com Suon Bi Cha", 45000))
        q1.ThemMon(MonAn("M02", "Com Suon Trung", 40000))
        q1.ThemMon(MonAn("M03", "Canh Kho Qua", 15000))
        q1.ThemVoucher(Voucher("GIAM10", "Giam 10%", 10))
        q1.ThemVoucher(Voucher("GIAM20", "Giam 20%", 20))
        self.ThemQuan(q1)

        q2 = Quan("Q02", "Tra Sua Gong Cha", "456 Le Loi, Q1")
        cq2.ThemQuan(q2)
        q2.ThemMon(MonAn("TS01", "Tra Sua Tran Chau", 35000))
        q2.ThemMon(MonAn("TS02", "Tra Dao Cam Sa", 30000))
        q2.ThemVoucher(Voucher("GIAM15", "Giam 15%", 15))
        self.ThemQuan(q2)

        kh1 = KhachHang("KH01", "Nguyen Van An", "0911222333", "an@gmail.com", "789 Tran Hung Dao")
        kh2 = KhachHang("KH02", "Le Thi Binh", "0944555666", "binh@gmail.com", "101 Nguyen Hue")
        self.ThemKhachHang(kh1)
        self.ThemKhachHang(kh2)

        tx1 = TaiXe("TX01", "Tran Van Chay", "0977888999", "chay@food.vn", "59X1-12345")
        tx2 = TaiXe("TX02", "Pham Van Giao", "0988777666", "giao@food.vn", "59Y2-67890")
        self.ThemTaiXe(tx1)
        self.ThemTaiXe(tx2)

        print(">> Da nhap thanh cong: 2 Quan (kem Menu, Voucher), 2 Khach hang, 2 Tai xe!")
