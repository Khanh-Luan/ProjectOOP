using System;
using System.Collections.Generic;
using System.Text;

namespace ITFood
{
    class Program
    {
        static void Main(string[] args)
        {
            UngDung app = new UngDung();
            ChuQuan cq = new ChuQuan();
            Quan quan = new Quan();
            KhachHang kh = new KhachHang();
            TaiXe tx = new TaiXe();

            int luaChon = -1;
            do
            {
                Console.WriteLine("----------------- HE THONG ITFOOD -----------------");
                Console.WriteLine("1. Nhap du lieu he thong (Khach, Quan, Menu, Tai Xe)");
                Console.WriteLine("2. Khach hang Tao don & Thanh toan");
                Console.WriteLine("3. Hien thi ket qua (Bao cao he thong, Doanh thu)");
                Console.WriteLine("0. Thoat");
                Console.WriteLine("---------------------------------------------------");
                Console.Write("Chon chuc nang: ");
                luaChon = Convert.ToInt32(Console.ReadLine());

                switch (luaChon)
                {
                    case 1:
                        Console.WriteLine("\n--- CHON PHUONG THUC NHAP DU LIEU ---");
                        Console.WriteLine("1. Nap nhanh du lieu mau (2 Quan, 2 Khach, 2 Tai xe)");
                        Console.WriteLine("2. Nhap thu cong tu ban phim");
                        Console.Write("Lua chon cua ban: ");
                        string chonNhap = Console.ReadLine();

                        if (chonNhap == "1")
                        {
                            app.KhoiTaoDuLieuMau();
                        }
                        else
                        {
                            cq = new ChuQuan();
                            quan = new Quan();
                            kh = new KhachHang();
                            tx = new TaiXe();

                            Console.WriteLine("\n--- NHAP THONG TIN CHU QUAN ---");
                            cq.Nhap();
                            app.ThemChuQuan(cq);

                            Console.WriteLine("\n--- NHAP THONG TIN QUAN ---");
                            quan.Nhap();
                            cq.ThemQuan(quan);
                            app.ThemQuan(quan);

                            quan.NhapMenu();
                            quan.NhapVoucher();

                            Console.WriteLine("\n--- NHAP THONG TIN KHACH HANG ---");
                            kh.Nhap();
                            app.ThemKhachHang(kh);

                            Console.WriteLine("\n--- NHAP THONG TIN TAI XE ---");
                            tx.Nhap();
                            app.ThemTaiXe(tx);
                        }
                        break;

                    case 2:
                        if (app.DsQuan.Count == 0 || app.DsKhachHang.Count == 0)
                        {
                            Console.WriteLine("Chua co du lieu he thong! Vui long chon chuc nang 1.");
                            break;
                        }

                        // 1. Cho chọn Khách hàng
                        app.HienThiDsKhachHang();
                        Console.Write("Nhap MA k/h dat don (vi du KH01): ");
                        string maKhachChon = Console.ReadLine();
                        KhachHang khChon = app.TimKhachHang(maKhachChon);
                        if (khChon == null)
                        {
                            Console.WriteLine("Khong tim thay khach hang nay! Huy thao tac.");
                            break;
                        }

                        // 2. Cho chọn Quán
                        app.HienThiDsQuan();
                        Console.Write("Nhap MA quan dat k/h dat (vi du Q01, Q02): ");
                        string maQuanChon = Console.ReadLine();
                        Quan quanChon = app.TimQuan(maQuanChon);
                        if (quanChon == null)
                        {
                            Console.WriteLine("Khong tim thay quan nay! Huy thao tac.");
                            break;
                        }

                        // 3. Bắt đầu tạo đơn
                        Console.WriteLine("\n--- TAO DON HANG ---");
                        Console.Write("Nhap ma don hang (vi du DH01): ");
                        string maDon = Console.ReadLine();
                        DonHang don = app.TaoDonHang(maDon, khChon, quanChon);

                        if (don == null)
                        {
                            Console.WriteLine("Khong the tao don hang. Ket thuc.");
                            break;
                        }

                        don.Nhap();
                        don.Xuat();

                        // Quán nhận đơn
                        Console.WriteLine("\n---- QUAN NHAN DON ----");
                        quanChon.NhanDon(don);

                        // Hủy đơn (nếu khách hàng muốn)
                        Console.Write("Ban co muon huy don khong? (y/n): ");
                        string huyChon = Console.ReadLine();
                        if (huyChon == "y" || huyChon == "Y")
                        {
                            don.HuyDon();
                            Console.WriteLine("\n---- HOA DON ----");
                            don.InHoaDon();
                            break;
                        }

                        // Thanh toán (Khách chọn phương thức, Quán chọn voucher)
                        Console.WriteLine("\n---- THANH TOAN ----");
                        PhuongThucThanhToan ptTT = khChon.ChonPhuongThucThanhToan();
                        string maVoucher = quanChon.ChonVoucher();

                        bool thanhCong = don.ThanhToan(ptTT, maVoucher);
                        if (!thanhCong)
                        {
                            Console.WriteLine("Chuyen sang thanh toan bang tien mat.");
                            ptTT = new TienMat();
                            thanhCong = don.ThanhToan(ptTT, maVoucher);
                        }

                        if (!thanhCong)
                        {
                            Console.WriteLine("Khong the thanh toan don hang.");
                            break;
                        }

                        // Phân công tài xế
                        Console.WriteLine("\n---- PHAN CONG TAI XE ----");
                        app.TimTaiXeRanhVaGanDon(don);

                        // Giao hàng
                        Console.WriteLine("\n---- GIAO HANG ----");
                        if (don.TrangThai == TrangThaiDon.DangGiao)
                            don.HoanThanhDon();
                        else
                            Console.WriteLine("Don hang chua duoc giao vi chua co tai xe.");

                        // In hóa đơn
                        Console.WriteLine("\n---- HOA DON ----");
                        don.InHoaDon();
                        break;

                    case 3:
                        // 7. Hiển thị kết quả
                        if (app.DsQuan.Count == 0)
                        {
                            Console.WriteLine("Chua co du lieu he thong ! Vui long chon chuc nang 1.");
                            break;
                        }
                        foreach (Quan q in app.DsQuan)
                        {
                            q.Xuat();
                            q.HienThiVoucherDaDung();
                            Console.WriteLine();
                        }
                        foreach (KhachHang k in app.DsKhachHang)
                        {
                            k.Xuat();
                            Console.WriteLine();
                        }
                        app.BaoCao();
                        break;

                    case 0:
                        Console.WriteLine("Ket thuc chuong trinh !!!");
                        break;

                    default:
                        Console.WriteLine("Chuc nang khong hop le.");
                        break;
                }

                if (luaChon != 0)
                {
                    Console.WriteLine("\n[Nhan Enter de quay lai Menu...]");
                    Console.ReadLine();
                }

            } while (luaChon != 0);
        }
    }
}