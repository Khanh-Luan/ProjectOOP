
// ================= DON HANG =================
public class DonHang
{
    private string sMa;
    private KhachHang khach;
    private Quan quan;
    private TaiXe taiXe;
    private List<MonAn> dsMon;
    private List<int> dsSoLuong;
    private double dKhoangCachKm;
    private string sTrangThai; // ChoXacNhan, DangGiao, HoanThanh, DaHuy
    private PhuongThucThanhToan thanhToan;
    private double dSoTienDaThanhToan;

    public string TrangThai { get { return sTrangThai; } }

    public DonHang(string ma, KhachHang khach, Quan quan, double khoangCachKm)
    {
        this.sMa = ma;
        this.khach = khach;
        this.quan = quan;
        this.dKhoangCachKm = khoangCachKm;
        this.dsMon = new List<MonAn>();
        this.dsSoLuong = new List<int>();
        this.sTrangThai = "ChoXacNhan";
    }

    public void GoiMon(MonAn mon, int soLuong)
    {
        dsMon.Add(mon);
        dsSoLuong.Add(soLuong);
    }

    public double TongTienMon()
    {
        double tong = 0;
        for (int i = 0; i < dsMon.Count; i++)
        {
            tong = tong + dsMon[i].Gia * dsSoLuong[i];
        }
        return tong;
    }

    public double TinhPhiShip()
    {
        if (dKhoangCachKm <= 3)
            return 15000;
        if (dKhoangCachKm <= 7)
            return 25000;
        return 40000;
    }

    public double TongThanhToan(string maVoucher)
    {
        double tienMon = TongTienMon();
        double giam = 0;
        if (maVoucher != null)
        {
            Voucher v = khach.TimVoucher(maVoucher);
            if (v != null)
                giam = v.TinhGiam(tienMon);
        }
        return tienMon - giam + TinhPhiShip();
    }

    public void GanTaiXe(TaiXe tx)
    {
        this.taiXe = tx;
        tx.DangRanh = false;
        this.sTrangThai = "DangGiao";
    }

    public void ThanhToan(PhuongThucThanhToan ptTT, string maVoucher)
    {
        this.thanhToan = ptTT;
        double tongTien = TongThanhToan(maVoucher);
        this.dSoTienDaThanhToan = tongTien;
        bool thanhCong = thanhToan.XuLyThanhToan(tongTien);
        if (thanhCong)
        {
            this.sTrangThai = "HoanThanh";
            if (maVoucher != null)
            {
                Voucher v = khach.TimVoucher(maVoucher);
                if (v != null)
                    v.DaDung = true;
            }
            khach.TinhTienDaChi(tongTien);
            quan.ChuCuaQuan.TinhDoanhThu(TongTienMon());
            if (taiXe != null)
            {
                taiXe.TinhThuNhap(TinhPhiShip());
                taiXe.HoanThanhGiao();
            }
        }
    }

    public void InHoaDon()
    {
        Console.WriteLine($"----- HOA DON {sMa} -----");
        for (int i = 0; i < dsMon.Count; i++)
        {
            Console.WriteLine($"{dsMon[i].Ten} x{dsSoLuong[i]} = {dsMon[i].Gia * dsSoLuong[i]}d");
        }
        Console.WriteLine($"Tien mon: {TongTienMon()}d");
        Console.WriteLine($"Phi ship: {TinhPhiShip()}d");
        Console.WriteLine($"Tong thanh toan: {dSoTienDaThanhToan}d");
        Console.WriteLine($"Trang thai: {sTrangThai}");
    }
}
