// ================= CHAY THU =================
using ITFood;
using ProjectOOP;

class Program
{
    static void NhapMenu(Quan quan)
    {
        Console.WriteLine("Nhap so mon trong menu: ");
        int soMonMenu = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < soMonMenu; i++)
        {
            Console.WriteLine($"\n--- Nhap mon {i + 1} ---");
            MonAn mon = new MonAn();
            mon.Nhap();
            quan.ThemMon(mon);
        }
    }

    static void NhapVoucher(Quan quan)
    {
        Console.WriteLine("Nhap so voucher cua quan: ");
        int soVoucher = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < soVoucher; i++)
        {
            Console.WriteLine($"\n--- Nhap voucher {i + 1} ---");
            Voucher v = new Voucher();
            v.Nhap();
            quan.ThemVoucher(v);
        }
    }

    static PhuongThucThanhToan ChonPhuongThucThanhToan()
    {
        Console.WriteLine("Chon phuong thuc thanh toan:");
        Console.WriteLine("1 - Tien mat");
        Console.WriteLine("2 - Vi dien tu");
        Console.WriteLine("3 - The");
        Console.Write("Lua chon: ");

        string chon = Console.ReadLine();

        switch (chon)
        {
            case "2":
                ViDienTu vi = new ViDienTu();
                vi.Nhap();
                return vi;
            case "3":
                The the = new The();
                the.Nhap();
                return the;
            default:
                return new TienMat();
        }
    }

    static string ChonVoucher(Quan quan)
    {
        if (!quan.CoVoucher())
        {
            Console.WriteLine("Quan nay hien khong co voucher khuyen mai.");
            return null;
        }

        quan.HienThiVoucherConDung();
        Console.WriteLine("Nhap ma voucher muon dung (bo trong neu khong dung): ");
        string maVoucher = Console.ReadLine();

        if (string.IsNullOrEmpty(maVoucher))
            return null;

        return maVoucher;
    }

    static void Main(string[] args)
    {
        UngDung app = new UngDung();

        // Khai báo sẵn các biến chứa dữ liệu (Không dùng static, chuẩn bài trên lớp)
        ChuQuan cq = new ChuQuan();
        Quan quan = new Quan();
        KhachHang kh = new KhachHang();
        TaiXe tx = new TaiXe();

        int luaChon = -1;
        do
        {
            Console.WriteLine("================ HE THONG ITFOOD ================");
            Console.WriteLine("1. Nhap du lieu he thong (Khach, Quan, Menu, Tai Xe)");
            Console.WriteLine("2. Khach hang Tao don & Thanh toan");
            Console.WriteLine("3. Hien thi ket qua (Bao cao he thong, Doanh thu)");
            Console.WriteLine("0. Thoat");
            Console.WriteLine("=================================================");
            Console.Write("Chon chuc nang: ");
            luaChon = Convert.ToInt32(Console.ReadLine());

            switch (luaChon)
            {
                case 1:
                    // 1. Khởi tạo dư liệu
                    Console.WriteLine("\n--- NHAP THONG TIN CHU QUAN ---");
                    cq.Nhap();
                    app.ThemChuQuan(cq);

                    Console.WriteLine("\n--- NHAP THONG TIN QUAN ---");
                    quan.Nhap();
                    cq.ThemQuan(quan);
                    app.ThemQuan(quan);

                    NhapMenu(quan);
                    NhapVoucher(quan);

                    Console.WriteLine("\n--- NHAP THONG TIN KHACH HANG ---");
                    kh.Nhap();
                    app.ThemKhachHang(kh);

                    Console.WriteLine("\n--- NHAP THONG TIN TAI XE ---");
                    tx.Nhap();
                    app.ThemTaiXe(tx);
                    break;

                case 2:
                    // 2. Tạo đơn hàng
                    Console.WriteLine("\n--- TAO DON HANG ---");
                    Console.WriteLine("Nhap ma don hang: ");
                    string maDon = Console.ReadLine();
                    DonHang don = app.TaoDonHang(maDon, kh, quan);

                    if (don == null)
                    {
                        Console.WriteLine("Khong the tao don hang. Ket thuc.");
                        break; // Dùng break thay vì return để không bị văng khỏi vòng lặp
                    }

                    don.Nhap();

                    // 3. Quán nhận đơn
                    Console.WriteLine("\n---- QUAN NHAN DON ----");
                    quan.NhanDon(don);

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

                    // 4. Thanh toán
                    Console.WriteLine("\n---- THANH TOAN ----");
                    PhuongThucThanhToan ptTT = ChonPhuongThucThanhToan();
                    string maVoucher = ChonVoucher(quan);

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

                    // 5. Phân công tài xế
                    Console.WriteLine("\n---- PHAN CONG TAI XE ----");
                    app.TimTaiXeRanhVaGanDon(don);

                    // 6. Giao hàng
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
                    quan.Xuat();
                    quan.HienThiVoucherDaDung();
                    kh.Xuat();
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