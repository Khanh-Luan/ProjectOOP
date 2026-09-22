public class TaiXe : NguoiDung
{
    private string sBienSo;
    private bool bDangRanh;
    private int iSoDonDaGiao;
    private double dTongThuNhap;

    public string BienSo { get { return sBienSo; } set { sBienSo = value; } }
    public bool DangRanh { get { return bDangRanh; } set { bDangRanh = value; } }
    public int SoDonDaGiao { get { return iSoDonDaGiao; } set { iSoDonDaGiao = value; } }
    public double TongThuNhap { get { return dTongThuNhap; } }

    public TaiXe(string ma, string ten, string sdt, string email, string bienSo)
        : base(ma, ten, sdt, email)
    {
        this.sBienSo = bienSo;
        this.bDangRanh = true;
        this.iSoDonDaGiao = 0;
        this.dTongThuNhap = 0;
    }

    // ham tinh toan so tien: tai xe nhan het phi ship cua don da giao
    public void TinhThuNhap(double phiShip)
    {
        dTongThuNhap = dTongThuNhap + phiShip;
    }

    public void HoanThanhGiao()
    {
        iSoDonDaGiao = iSoDonDaGiao + 1;
        bDangRanh = true;
    }

    public override void XemThongTin()
    {
        Console.WriteLine($"[Tai xe] {sMa} - {sTen} - Da giao: {iSoDonDaGiao} - Thu nhap: {dTongThuNhap}d");
    }
}
