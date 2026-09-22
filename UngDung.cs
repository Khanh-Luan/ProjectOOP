
// ================= UNG DUNG (LOP TONG) =================
public class UngDung
{
    private List<KhachHang> dsKhachHang;
    private List<ChuQuan> dsChuQuan;
    private List<TaiXe> dsTaiXe;
    private List<Quan> dsQuan;
    private List<DonHang> dsDonHang;

    public UngDung()
    {
        dsKhachHang = new List<KhachHang>();
        dsChuQuan = new List<ChuQuan>();
        dsTaiXe = new List<TaiXe>();
        dsQuan = new List<Quan>();
        dsDonHang = new List<DonHang>();
    }

    public void ThemKhachHang(KhachHang kh) { dsKhachHang.Add(kh); }
    public void ThemChuQuan(ChuQuan cq) { dsChuQuan.Add(cq); }
    public void ThemTaiXe(TaiXe tx) { dsTaiXe.Add(tx); }
    public void ThemQuan(Quan q) { dsQuan.Add(q); }

    public TaiXe TimTaiXeRanh()
    {
        for (int i = 0; i < dsTaiXe.Count; i++)
        {
            if (dsTaiXe[i].DangRanh)
                return dsTaiXe[i];
        }
        return null;
    }

    public DonHang TaoDonHang(string ma, KhachHang kh, Quan quan, double khoangCach)
    {
        DonHang don = new DonHang(ma, kh, quan, khoangCach);
        dsDonHang.Add(don);
        return don;
    }

    public void BaoCao()
    {
        Console.WriteLine("===== BAO CAO =====");
        Console.WriteLine($"So don hang: {dsDonHang.Count}");
        for (int i = 0; i < dsTaiXe.Count; i++)
        {
            dsTaiXe[i].XemThongTin();
        }
    }
}
