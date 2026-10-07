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
            // ================= 1. TẠO SẴN DỮ LIỆU GIẢ LẬP =================
            // Tạo Khách
            KhachHang kh = new KhachHang("KH01", "Nguyen Van A", "0901234567", "a@gmail.com", "123 Le Loi");

            // Tạo Chủ quán & Quán
            ChuQuan cq = new ChuQuan("CQ01", "Tran B", "0987654321", "b@gmail.com");
            Quan quan = new Quan("Q01", "Pho Pasteur", "456 Pasteur");
            cq.ThemQuan(quan); // Liên kết quán này thuộc về chủ CQ01

            // Thêm món vào Menu
            quan.ThemMon(new MonAn("M01", "Pho Bo Tai", 50000));
            quan.ThemMon(new MonAn("M02", "Tra Da", 5000));

            // Thêm Voucher giảm 20%
            Voucher v = new Voucher("GIAM20", "Giam 20 phan tram", 20);
            quan.ThemVoucher(v);

            // Tạo Tài xế
            TaiXe tx = new TaiXe("TX01", "Le Van C", "0911111111", "c@gmail.com", "59X1-12345");


            // ================= 2. BẮT ĐẦU LUỒNG ĐẶT HÀNG =================
            Console.WriteLine("====== KHACH HANG DAT DON ======");
            DonHang don = new DonHang("DH001", kh, quan);

            // Gọi hàm Nhap() để hiện Menu và cho khách nhập món, nhập km
            don.Nhap();


            // ================= 3. QUÁN NHẬN VÀ LÀM MÓN =================
            Console.WriteLine("\n====== QUAN XAC NHAN ======");
            quan.NhanDon(don);


            // ================= 4. THANH TOAN =================
            Console.WriteLine("\n====== THANH TOAN ======");
            // Giả lập khách hàng xài Ví điện tử, nạp sẵn 200.000đ vào ví
            ViDienTu vi = new ViDienTu(200000);

            // Khách tiến hành thanh toán và áp mã "GIAM20"
            don.ThanhToan(vi, "GIAM20");


            // ================= 5. GIAO HÀNG =================
            Console.WriteLine("\n====== GIAO HANG ======");
            don.GanTaiXe(tx);
            don.HoanThanhDon();


            // ================= 6. BÁO CÁO NGHIỆP VỤ (KIỂM TRA CHIA TIỀN) =================
            Console.WriteLine("\n====== KET QUA KINH DOANH SAU 1 DON HANG ======");
            don.InHoaDon();
            Console.WriteLine("-------------------------------------------------");

            // Kiểm tra xem tiền có chia đúng theo chiết khấu 25% (Quán) và 20% (Tài xế) không
            Console.WriteLine($"Tong tien Khach Hang da chi ra: {kh.TongDaChi}đ");
            Console.WriteLine($"Doanh thu Chu Quan (Da bi app tru 25%): {cq.TongDoanhThu}đ");
            Console.WriteLine($"Thu nhap Tai Xe (Da bi app tru 20%): {tx.TongThuNhap}đ");

            Console.ReadLine(); // Dừng màn hình để xem kết quả
        }
    }
}