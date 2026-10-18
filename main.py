from trang_thai_don import TrangThaiDon
from chu_quan import ChuQuan
from quan import Quan
from khach_hang import KhachHang
from tai_xe import TaiXe
from tien_mat import TienMat
from ung_dung import UngDung


def main():
    app = UngDung()

    lua_chon = -1
    while lua_chon != 0:
        print("----------------- HE THONG ITFOOD -----------------")
        print("1. Nhap du lieu he thong (Khach, Quan, Menu, Tai Xe)")
        print("2. Khach hang Tao don & Thanh toan")
        print("3. Hien thi ket qua (Bao cao he thong, Doanh thu)")
        print("0. Thoat")
        print("---------------------------------------------------")
        lua_chon = int(input("Chon chuc nang: "))

        if lua_chon == 1:
            print("\n--- CHON PHUONG THUC NHAP DU LIEU ---")
            print("1. Nap nhanh du lieu mau (2 Quan, 2 Khach, 2 Tai xe)")
            print("2. Nhap thu cong tu ban phim")
            chon_nhap = input("Lua chon cua ban: ")

            if chon_nhap == "1":
                app.KhoiTaoDuLieuMau()
            else:
                cq = ChuQuan()
                quan = Quan()
                kh = KhachHang()
                tx = TaiXe()

                print("\n--- NHAP THONG TIN CHU QUAN ---")
                cq.Nhap()
                app.ThemChuQuan(cq)

                print("\n--- NHAP THONG TIN QUAN ---")
                quan.Nhap()
                cq.ThemQuan(quan)
                app.ThemQuan(quan)

                quan.NhapMenu()
                quan.NhapVoucher()

                print("\n--- NHAP THONG TIN KHACH HANG ---")
                kh.Nhap()
                app.ThemKhachHang(kh)

                print("\n--- NHAP THONG TIN TAI XE ---")
                tx.Nhap()
                app.ThemTaiXe(tx)

        elif lua_chon == 2:
            while True:  # vong chay 1 lan, de "break" thoat khoi case 2
                if len(app.DsQuan) == 0 or len(app.DsKhachHang) == 0:
                    print("Chua co du lieu he thong! Vui long chon chuc nang 1.")
                    break

                app.HienThiDsKhachHang()
                ma_khach_chon = input("Nhap MA k/h dat don (vi du KH01): ")
                kh_chon = app.TimKhachHang(ma_khach_chon)
                if kh_chon is None:
                    print("Khong tim thay khach hang nay! Huy thao tac.")
                    break

                app.HienThiDsQuan()
                ma_quan_chon = input("Nhap MA quan dat k/h dat (vi du Q01, Q02): ")
                quan_chon = app.TimQuan(ma_quan_chon)
                if quan_chon is None:
                    print("Khong tim thay quan nay! Huy thao tac.")
                    break

                print("\n--- TAO DON HANG ---")
                ma_don = input("Nhap ma don hang (vi du DH01): ")
                don = app.TaoDonHang(ma_don, kh_chon, quan_chon)

                if don is None:
                    print("Khong the tao don hang. Ket thuc.")
                    break

                don.Nhap()
                don.Xuat()

                print("\n---- QUAN NHAN DON ----")
                quan_chon.NhanDon(don)

                huy_chon = input("Ban co muon huy don khong? (y/n): ")
                if huy_chon == "y" or huy_chon == "Y":
                    don.HuyDon()
                    print("\n---- HOA DON ----")
                    don.InHoaDon()
                    break

                print("\n---- THANH TOAN ----")
                pt_tt = kh_chon.ChonPhuongThucThanhToan()
                ma_voucher = quan_chon.ChonVoucher()

                thanh_cong = don.ThanhToan(pt_tt, ma_voucher)
                if not thanh_cong:
                    print("Chuyen sang thanh toan bang tien mat.")
                    pt_tt = TienMat()
                    thanh_cong = don.ThanhToan(pt_tt, ma_voucher)

                if not thanh_cong:
                    print("Khong the thanh toan don hang.")
                    break

                print("\n---- PHAN CONG TAI XE ----")
                app.TimTaiXeRanhVaGanDon(don)

                print("\n---- GIAO HANG ----")
                if don.TrangThai == TrangThaiDon.DangGiao:
                    don.HoanThanhDon()
                else:
                    print("Don hang chua duoc giao vi chua co tai xe.")

                print("\n---- HOA DON ----")
                don.InHoaDon()
                break  # ket thuc case 2

        elif lua_chon == 3:
            if len(app.DsQuan) == 0:
                print("Chua co du lieu he thong ! Vui long chon chuc nang 1.")
            else:
                for q in app.DsQuan:
                    q.Xuat()
                    q.HienThiVoucherDaDung()
                    print()
                for k in app.DsKhachHang:
                    k.Xuat()
                    print()
                app.BaoCao()

        elif lua_chon == 0:
            print("Ket thuc chuong trinh !!!")

        else:
            print("Chuc nang khong hop le.")

        if lua_chon != 0:
            input("\n[Nhan Enter de quay lai Menu...]")


if __name__ == "__main__":
    main()
