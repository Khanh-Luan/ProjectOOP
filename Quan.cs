
// ================= QUAN =================
public class Quan
{
    private string sMa;
    private string sTen;
    private string sDiaChi;
    private bool bDangMoCua;
    private List<MonAn> menu;
    private ChuQuan chuQuan;

    public string Ma { get { return sMa; } set { sMa = value; } }
    public string Ten { get { return sTen; } set { sTen = value; } }
    public string DiaChi { get { return sDiaChi; } set { sDiaChi = value; } }
    public bool DangMoCua { get { return bDangMoCua; } set { bDangMoCua = value; } }
    public ChuQuan ChuCuaQuan { get { return chuQuan; } set { chuQuan = value; } }

    public Quan(string ma, string ten, string diaChi, ChuQuan chuQuan)
    {
        this.sMa = ma;
        this.sTen = ten;
        this.sDiaChi = diaChi;
        this.bDangMoCua = true;
        this.menu = new List<MonAn>();
        this.chuQuan = chuQuan;
    }

    public void ThemMon(MonAn mon)
    {
        menu.Add(mon);
    }

    public MonAn TimMon(string ma)
    {
        for (int i = 0; i < menu.Count; i++)
        {
            if (menu[i].Ma == ma)
                return menu[i];
        }
        return null;
    }

    public void HienThiMenu()
    {
        for (int i = 0; i < menu.Count; i++)
        {
            menu[i].HienThi();
        }
    }
}
