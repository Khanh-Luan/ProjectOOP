public class ViDienTu : PhuongThucThanhToan
{
    private double dSoDu;

    public ViDienTu(double soDu)
    {
        this.dSoDu = soDu;
    }

    public override bool XuLyThanhToan(double soTien)
    {
        if (dSoDu < soTien)
        {
            Console.WriteLine("So du vi dien tu khong du.");
            return false;
        }
        dSoDu = dSoDu - soTien;
        Console.WriteLine($"Da thanh toan {soTien}d bang vi dien tu. Con lai: {dSoDu}d");
        return true;
    }
}
