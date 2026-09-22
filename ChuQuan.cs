public class ChuQuan : NguoiDung
{
    private List<Quan> dsQuan;
    private double dTongDoanhThu;

    public double TongDoanhThu { get { return dTongDoanhThu; } }

    public ChuQuan(string ma, string ten, string sdt, string email)
        : base(ma, ten, sdt, email)
    {
        dsQuan = new List<Quan>();
        dTongDoanhThu = 0;
    }

    public void ThemQuan(Quan quan)
    {
        dsQuan.Add(quan);
    }

    // ham tinh toan so tien: cong doanh thu tu don hang cua quan minh
    public void TinhDoanhThu(double soTien)
    {
        dTongDoanhThu = dTongDoanhThu + soTien;
    }

    public override void XemThongTin()
    {
        Console.WriteLine($"[Chu quan] {sMa} - {sTen} - So quan: {dsQuan.Count} - Doanh thu: {dTongDoanhThu}d");
    }
}
