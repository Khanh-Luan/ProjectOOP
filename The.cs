public class The : PhuongThucThanhToan
{
    private string sSoTheCuoi;
    private double dPhiGiaoDich;

    public The(string soTheCuoi, double phiGiaoDich)
    {
        this.sSoTheCuoi = soTheCuoi;
        this.dPhiGiaoDich = phiGiaoDich;
    }

    public override bool XuLyThanhToan(double soTien)
    {
        double tongTien = soTien + dPhiGiaoDich;
        Console.WriteLine($"Da thanh toan {tongTien}d bang the ***{sSoTheCuoi} (gom phi {dPhiGiaoDich}d)");
        return true;
    }
}
