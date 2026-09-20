using System;
using System.Collections.Generic;


public class Diem
{
    protected float fX;
    protected float fY;

    public float X
    {
        get { return this.fX; }
        set { this.fX = value; }
    }
    public float Y
    {
        get { return this.fY; }
        set { this.fY = value; }
    }

    public Diem(float x, float y)
    {
        this.fX = x;
        this.fY = y;
    }
    public Diem() { }

    ~Diem() { }

    public void Nhap()
    {
        Console.Write("Nhap hoanh do x: ");
        this.X = float.Parse(Console.ReadLine());
        Console.Write("Nhap tung do y: ");
        this.Y = float.Parse(Console.ReadLine());
    }

    public void Xuat()
    {
        Console.Write($"({this.fX}, {this.fY})");
    }
}

public class Hinh
{
    protected int iID;
    protected Diem d1;
    protected Diem d2;

    public int ID
    {
        get { return this.iID; }
        set { this.iID = value; }
    }
    public Diem Diem1
    {
        get { return this.d1; }
        set { this.d1 = value; }
    }
    public Diem Diem2
    {
        get { return this.d2; }
        set { this.d2 = value; }
    }

    public Hinh(int id, Diem p1, Diem p2)
    {
        this.iID = id;
        this.d1 = p1;
        this.d2 = p2;
    }
    public Hinh()
    {
        this.d1 = new Diem();
        this.d2 = new Diem();
    }

    ~Hinh() { }

    public virtual void Nhap()
    {
        Console.WriteLine("Nhap ID hinh: ");
        this.ID = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Nhap toa do Diem thu 1:");
        this.d1.Nhap();
        Console.WriteLine("Nhap toa do Diem thu 2:");
        this.d2.Nhap();
    }

    public virtual void Nhap(int id, Diem p1, Diem p2)
    {
        this.ID = id;
        this.d1 = p1;
        this.d2 = p2;
    }

    public virtual void Xuat()
    {
        Console.Write($"ID: {this.iID} | Diem 1: ");
        this.d1.Xuat();
        Console.Write(" | Diem 2: ");
        this.d2.Xuat();
    }

    public virtual float TinhDienTich()
    {
        return 0;
    }

    public void CapNhatToaDo(int targetID, float x1, float y1, float x2, float y2)
    {
        if (this.iID == targetID)
        {
            this.d1.X = x1;
            this.d1.Y = y1;
            this.d2.X = x2;
            this.d2.Y = y2;
            Console.WriteLine("Da cap nhat toa do thanh cong");
        }
    }
}


public class DoanThang : Hinh
{
    public DoanThang(int id, Diem p1, Diem p2) : base(id, p1, p2) { }
    public DoanThang() : base() { }
    ~DoanThang() { }

    public override void Nhap()
    {
        Console.WriteLine("NHAP DOAN THANG");
        base.Nhap();
    }

    public override void Xuat()
    {
        Console.WriteLine("Doan Thang ");
        base.Xuat();
        Console.WriteLine($"Dien tich: {this.TinhDienTich()}");
    }

    public override float TinhDienTich()
    {
        return 0;
    }
}
public class HinhChuNhat : Hinh
{
    private float fChieuDai;
    private float fChieuRong;

    public float ChieuDai
    {
        get { return this.fChieuDai; }
        set { this.fChieuDai = value; }
    }
    public float ChieuRong
    {
        get { return this.fChieuRong; }
        set { this.fChieuRong = value; }
    }

    public HinhChuNhat(float chieuDai, float chieuRong)
    {
        this.fChieuDai = chieuDai;
        this.fChieuRong = chieuRong;
    }
    public HinhChuNhat() : base() { }
    ~HinhChuNhat() { }

    public override void Nhap()
    {
        Console.WriteLine("NHAP HINH CHU NHAT");
        base.Nhap();
        Console.Write("Nhap chieu dai: ");
        this.ChieuDai = float.Parse(Console.ReadLine());
        Console.Write("Nhap chieu rong: ");
        this.ChieuRong = float.Parse(Console.ReadLine());
    }

    public virtual void Nhap(float chieuDai, float chieuRong)
    {
        this.ChieuDai = chieuDai;
        this.ChieuRong = chieuRong;
    }

    public override void Xuat()
    {
        Console.WriteLine("Hinh Chu Nhat ");
        base.Xuat();
        Console.WriteLine($"Chieu dai: {this.fChieuDai} | Chieu rong: {this.fChieuRong} | Dien tich: {this.TinhDienTich()}");
    }

    public override float TinhDienTich()
    {
        return this.fChieuDai * this.fChieuRong;
    }
}
public class HinhTamGiac : Hinh
{
    private float fCanhDay;
    private float fChieuCao;

    public float CanhDay
    {
        get { return this.fCanhDay; }
        set { this.fCanhDay = value; }
    }
    public float ChieuCao
    {
        get { return this.fChieuCao; }
        set { this.fChieuCao = value; }
    }

    public HinhTamGiac(float canhDay, float chieuCao)
    {
        this.fCanhDay = canhDay;
        this.fChieuCao = chieuCao;
    }
    public HinhTamGiac() : base() { }
    ~HinhTamGiac() { }

    public override void Nhap()
    {
        Console.WriteLine("NHAP HINH TAM GIAC");
        base.Nhap();
        Console.Write("Nhap do dai canh day: ");
        this.CanhDay = float.Parse(Console.ReadLine());
        Console.Write("Nhap chieu cao: ");
        this.ChieuCao = float.Parse(Console.ReadLine());
    }

    public virtual void Nhap(float canhDay, float chieuCao)
    {
        this.CanhDay = canhDay;
        this.ChieuCao = chieuCao;
    }

    public override void Xuat()
    {
        Console.WriteLine("Hinh Tam Giac ");
        base.Xuat();
        Console.WriteLine($" Canh day: {this.fCanhDay} | Chieu cao: {this.fChieuCao} | Dien tich: {this.TinhDienTich()}");
    }

    public override float TinhDienTich()
    {
        return 0.5f * this.fCanhDay * this.fChieuCao;
    }
}

public class DoHoa
{
    private string sTenDoHoa;
    private List<Hinh> lHinh;

    public string TenDoHoa
    {
        get { return this.sTenDoHoa; }
        set { this.sTenDoHoa = value; }
    }

    // Constructors
    public DoHoa()
    {
        this.lHinh = new List<Hinh>();
    }
    public DoHoa(string tenDoHoa)
    {
        this.sTenDoHoa = tenDoHoa;
        this.lHinh = new List<Hinh>();
    }

    ~DoHoa() { }

    public void Nhap()
    {
        Console.WriteLine("NHAP THONG TIN DO HOA");
        Console.Write("Nhap ten ban ve do hoa: ");
        this.TenDoHoa = Console.ReadLine();

        Console.Write("Nhap so luong hinh can them: ");
        int n = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nChon loai hinh can nhap ({i + 1}/{n}):");
            Console.WriteLine("1. Doan Thang");
            Console.WriteLine("2. Hinh Chu Nhat");
            Console.WriteLine("3. Hinh Tam Giac");
            Console.Write("Lua chon cua ban: ");
            int loai = Convert.ToInt32(Console.ReadLine());

            Hinh h = null;
            switch (loai)
            {
                case 1:
                    h = new DoanThang();
                    break;
                case 2:
                    h = new HinhChuNhat();
                    break;
                case 3:
                    h = new HinhTamGiac();
                    break;
                default:
                    Console.WriteLine("Lua chon khong hop le! Xin vui long nhap lai.");
                    i--;
                    continue;
            }
            h.Nhap(); this.lHinh.Add(h);
        }
    }
    public void Xuat()
    {
        Console.WriteLine($"\nDANH SACH CAC HINH CUA BAN VE: {this.sTenDoHoa}"); if (this.lHinh.Count == 0) { Console.WriteLine("Danh sach dang trong."); return; }
        foreach (Hinh h in this.lHinh) { Console.WriteLine(" "); h.Xuat(); }
        Console.WriteLine(" ");
    }
    public void CapNhatToaDoTrongDanhSach(int targetID, float x1, float y1, float x2, float y2)
    {
        bool timThay = false; foreach (Hinh h in this.lHinh) { if (h.ID == targetID) { h.CapNhatToaDo(targetID, x1, y1, x2, y2); timThay = true; break; } }
        if (!timThay) { Console.WriteLine("Khong tim thay ma hinh"); }
    }
    public void XoaHinhTheoID(int targetID)
    {
        Hinh hinhCanXoa = this.lHinh.Find(h => h.ID == targetID); if (hinhCanXoa != null) { this.lHinh.Remove(hinhCanXoa); Console.WriteLine($"-> Da xoa hinh co ID: [{targetID}] ra khoi danh sach."); }
        else
        {
            Console.WriteLine("Khong tim thay ma hinh");
        }
    }
}

class Program
{
    static void Main()
    {
        DoHoa app = new DoHoa();
        app.Nhap();
        app.Xuat();
        Console.WriteLine("\nCAP NHAT TOA DO HINH");
        Console.Write("Nhap ID hinh can sua: ");
        int idSua = Convert.ToInt32(Console.ReadLine());
        Console.Write("Nhap hoanh do x1 moi: ");
        float x1 = float.Parse(Console.ReadLine());

        Console.Write("Nhap tung do y1 moi: ");
        float y1 = float.Parse(Console.ReadLine());
        Console.Write("Nhap hoanh do x2 moi: ");
        float x2 = float.Parse(Console.ReadLine());
        Console.Write("Nhap tung do y2 moi: ");
        float y2 = float.Parse(Console.ReadLine());
        app.CapNhatToaDoTrongDanhSach(idSua, x1, y1, x2, y2);
        app.Xuat();
        Console.WriteLine("\nXOA HINH");
        Console.Write("Nhap ID hinh muon xoa: ");
        int idXoa = Convert.ToInt32(Console.ReadLine());
        app.XoaHinhTheoID(idXoa);
        app.Xuat();
        Console.ReadKey();
    }
}
