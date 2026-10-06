using System;
using System.Collections.Generic;
using ITFood;
using ProjectOOP;
namespace ITFood
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Để hiển thị tiếng Việt
            Console.WriteLine("======= TEST 1: TẠO MÓN ĂN & VOUCHER =======");
            MonAn mon1 = new MonAn("M01", "Phở Bò Kobe", 50000);
            MonAn mon2 = new MonAn("M02", "Cơm Tấm Sườn Bì", 40000);
            Voucher v1 = new Voucher("KM20", "Giảm 20% sinh viên", 20);
            Console.WriteLine("\n======= TEST 2: CHỦ QUÁN & QUÁN (QUAN HỆ 2 CHIỀU) =======");
            ChuQuan ongChu = new ChuQuan("CQ01", "Chú Hùng", "0988123456", "hung@gmail.com");
            Quan quanPho = new Quan("Q01", "Phở Gia Truyền", "123 Lê Lợi");

            // Gắn kết quán cho chủ (Test quan hệ 2 chiều)
            ongChu.ThemQuan(quanPho);

            // Thêm món và voucher vào quán
            quanPho.ThemMon(mon1);
            quanPho.ThemMon(mon2);
            quanPho.ThemVoucher(v1);
            // Xuất thông tin quán (Sẽ thấy có cả thông tin ông chủ ở dưới cùng)
            quanPho.Xuat();
            Console.WriteLine();
            quanPho.HienThiMenu();
            Console.WriteLine("\n======= TEST 3: KHÁCH HÀNG & TÀI XẾ CHI TIỀN =======");
            KhachHang kh = new KhachHang("KH01", "Nguyễn Văn Khách", "0123456", "kh@gmail.com", "456 Nguyễn Trãi");
            TaiXe tx = new TaiXe("TX01", "Trần Văn Xe", "0789789", "tx@gmail.com", "59A-123.45");
            // Khách hàng mua đơn 100k
            kh.TinhToanTien(100000);
            // Tài xế nhận phí ship 15k, và hoàn thành chuyến xe
            tx.TinhToanTien(15000);
            tx.HoanThanhGiao();
            // Chủ quán nhận doanh thu 100k
            ongChu.TinhToanTien(100000);
            // In ra xem kết quả cập nhật tiền bạc
            kh.Xuat();
            Console.WriteLine();
            tx.Xuat();
            Console.WriteLine();
            ongChu.Xuat(); // Xem ông chủ đã nhận được tiền chưa
            Console.ReadLine(); // Dừng màn hình để xem
        }
    }
}