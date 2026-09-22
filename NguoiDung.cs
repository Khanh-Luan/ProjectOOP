
// ================= NGUOI DUNG =================
public abstract class NguoiDung
{
    protected string sMa;
    protected string sTen;
    protected string sSdt;
    protected string sEmail;

    public string Ma { get { return sMa; } set { sMa = value; } }
    public string Ten { get { return sTen; } set { sTen = value; } }
    public string Sdt { get { return sSdt; } set { sSdt = value; } }
    public string Email { get { return sEmail; } set { sEmail = value; } }

    public NguoiDung(string ma, string ten, string sdt, string email)
    {
        this.sMa = ma;
        this.sTen = ten;
        this.sSdt = sdt;
        this.sEmail = email;
    }

    public abstract void XemThongTin();
}
