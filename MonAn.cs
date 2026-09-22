
// ================= MON AN =================
public class MonAn
{
    protected string sMa;
    protected string sTen;
    protected double dGia;

    public string Ma { get { return sMa; } set { sMa = value; } }
    public string Ten { get { return sTen; } set { sTen = value; } }
    public double Gia
    {
        get { return dGia; }
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Gia phai > 0");
            dGia = value;
        }
    }

    public MonAn(string ma, string ten, double gia)
    {
        this.sMa = ma;
        this.sTen = ten;
        this.Gia = gia;
    }

    public virtual void HienThi()
    {
        Console.WriteLine($"{sMa} - {sTen} - {dGia}d");
    }
}
