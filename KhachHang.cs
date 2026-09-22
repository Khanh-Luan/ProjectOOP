public class KhachHang : NguoiDung
{
    private string sDiaChiGiao;
    private int iDiemTichLuy;
    private double dTongDaChi;
    private List<Voucher> dsVoucher;

    public string DiaChiGiao { get { return sDiaChiGiao; } set { sDiaChiGiao = value; } }
    public int DiemTichLuy { get { return iDiemTichLuy; } set { iDiemTichLuy = value; } }
    public double TongDaChi { get { return dTongDaChi; } }

    public KhachHang(string ma, string ten, string sdt, string email, string diaChi)
        : base(ma, ten, sdt, email)
    {
        this.sDiaChiGiao = diaChi;
        this.iDiemTichLuy = 0;
        this.dTongDaChi = 0;
        this.dsVoucher = new List<Voucher>();
    }

    public void ThemVoucher(Voucher v)
    {
        dsVoucher.Add(v);
    }

    public Voucher TimVoucher(string ma)
    {
        for (int i = 0; i < dsVoucher.Count; i++)
        {
            if (dsVoucher[i].Ma == ma)
                return dsVoucher[i];
        }
        return null;
    }

    // ham tinh toan so tien: cong don da chi va diem tich luy
    public void TinhTienDaChi(double soTien)
    {
        dTongDaChi = dTongDaChi + soTien;
        iDiemTichLuy = iDiemTichLuy + (int)(soTien / 10000);
    }

    public override void XemThongTin()
    {
        Console.WriteLine($"[Khach hang] {sMa} - {sTen} - Da chi: {dTongDaChi}d - Diem: {iDiemTichLuy}");
    }
}
