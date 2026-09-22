
// ================= VOUCHER =================
public class Voucher
{
    private string sMa;
    private double dPhanTram;
    private bool bDaDung;

    public string Ma { get { return sMa; } set { sMa = value; } }
    public double PhanTram { get { return dPhanTram; } set { dPhanTram = value; } }
    public bool DaDung { get { return bDaDung; } set { bDaDung = value; } }

    public Voucher(string ma, double phanTram)
    {
        this.sMa = ma;
        this.dPhanTram = phanTram;
        this.bDaDung = false;
    }

    public double TinhGiam(double tienMon)
    {
        if (bDaDung)
            return 0;
        return tienMon * dPhanTram / 100;
    }
}
