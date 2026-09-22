using System;
using System.Collections.Generic;

// ================= CHAY THU =================
class Program
{
    static void Main(string[] args)
    {
        UngDung app = new UngDung();

        ChuQuan cq = new ChuQuan("CQ01", "Anh Ba", "0900000000", "ba@gmail.com");
        app.ThemChuQuan(cq);

        Quan quan = new Quan("Q01", "Com Tam Ba Ba", "123 Le Loi", cq);
        quan.ThemMon(new MonAn("M01", "Com suon", 35000));
        quan.ThemMon(new MonAn("M02", "Canh chua", 20000));
        cq.ThemQuan(quan);
        app.ThemQuan(quan);

        KhachHang kh = new KhachHang("KH01", "Nguyen An", "0911111111", "an@gmail.com", "45 Nguyen Trai");
        kh.ThemVoucher(new Voucher("VC10", 10));
        app.ThemKhachHang(kh);

        TaiXe tx = new TaiXe("TX01", "Van Hung", "0922222222", "hung@gmail.com", "59A1-12345");
        app.ThemTaiXe(tx);

        quan.HienThiMenu();

        DonHang don = app.TaoDonHang("DH001", kh, quan, 4.5);
        don.GoiMon(quan.TimMon("M01"), 2);
        don.GoiMon(quan.TimMon("M02"), 1);

        TaiXe taiXeRanh = app.TimTaiXeRanh();
        if (taiXeRanh != null)
            don.GanTaiXe(taiXeRanh);

        don.ThanhToan(new ViDienTu(200000), "VC10");
        don.InHoaDon();

        app.BaoCao();
        cq.XemThongTin();
        kh.XemThongTin();

        Console.ReadLine();
    }
}