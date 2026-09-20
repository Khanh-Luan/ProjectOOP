using System;

public class SanPham
{
    // fields
    protected string sMaSP;
    protected string sTenSP;
    protected string sMauSac;
    protected double dGiaCoBan;
    protected double dGiaBan;
    //properties
    public string MaSP
    {
        get { return this.sMaSP; }
        set { this.sMaSP = value; }
    }
    public string TenSP
    {
        get { return this.sTenSP; }
        set { this.sTenSP = value; }
    }
    public string MauSac
    {
        get { return this.sMauSac; }
        set { this.sMauSac = value; }
    }
    public double GiaCoBan
    {
        get { return this.dGiaCoBan; }
        set { this.dGiaCoBan = value; }
    }
    public double GiaBan
    {
        get { return this.dGiaBan; }
        set { this.dGiaBan = value; }
    }
    //constructors
    public SanPham(string maSP, string tenSP, string mauSac, double giaCoBan, double giaBan)
    {
        this.MaSP = maSP;
        this.TenSP = tenSP;
        this.MauSac = mauSac;
        this.GiaCoBan = giaCoBan;
        this.GiaBan = giaBan;
    }
    public SanPham() { }

    //destructors
    ~SanPham() { }

    // các method
    // hàm nhập
    public virtual void Nhap()
    {
        Console.WriteLine("Nhap ma san pham: ");
        this.MaSP = Console.ReadLine();
        Console.WriteLine("Nhap ten san pham: ");
        this.TenSP = Console.ReadLine();
        Console.WriteLine("Nhap mau sac: ");
        this.MauSac = Console.ReadLine();
        Console.WriteLine("Nhap gia co ban: ");
        this.GiaCoBan = Convert.ToDouble(Console.ReadLine());
    }

    public virtual void Nhap(string maSP, string tenSP, string mauSac, double giaCoBan)
    {
        this.MaSP = maSP;
        this.TenSP = tenSP;
        this.MauSac = mauSac;
        this.GiaCoBan = giaCoBan;
    }
    //Hàm xuất
    public virtual void Xuat()
    {
        Console.WriteLine("Ma san pham: " + this.sMaSP);
        Console.WriteLine("Ten san pham: " + this.sTenSP);
        Console.WriteLine("Mau sac: " + this.sMauSac);
        Console.WriteLine("Gia co ban: " + this.dGiaCoBan);
    }
    //hàm tính toán
    public virtual void Cost()
    {
        this.dGiaBan = this.dGiaCoBan;
    }
}


public class TiVi : SanPham
{
    private double dKichThuoc;
    public double KichThuoc
    {
        get { return this.dKichThuoc; }
        set { this.dKichThuoc = value; }
    }

    public TiVi(double kichThuoc)
    {
        this.KichThuoc = kichThuoc;
    }

    public TiVi() { }
    ~TiVi() { }

    public override void Nhap()
    {
        base.Nhap();
        Console.WriteLine("Nhap kich thuoc: ");
        this.dKichThuoc = Convert.ToDouble(Console.ReadLine());
    }

    public virtual void Nhap(double kichThuoc)
    {
        this.KichThuoc = kichThuoc;
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine("Kich Thuoc: " + this.dKichThuoc);
        Console.WriteLine("Gia ban: " + this.dGiaBan);
    }
    public override void Cost()
    {
        this.dGiaBan = this.dGiaCoBan + this.dKichThuoc * 0.1;
    }
}

public class DienThoai : SanPham
{
    private int iBoNho;
    public int BoNho
    {
        get { return this.iBoNho; }
        set { this.iBoNho = value; }
    }
    public DienThoai(int boNho)
    {
        this.BoNho = boNho;
    }

    public DienThoai() { }
    ~DienThoai() { }

    public override void Nhap()
    {
        base.Nhap();
        Console.WriteLine("Nhap bo nho: ");
        this.iBoNho = Convert.ToInt32(Console.ReadLine());
    }

    public virtual void Nhap(int boNho)
    {
        this.BoNho = boNho;
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine("Gia ban: " + this.dGiaBan);
        Console.WriteLine("Bo nho: " + this.iBoNho);
    }
    public override void Cost()
    {
        this.dGiaBan = this.dGiaCoBan + this.iBoNho * 0.2;
    }
}

public class MayLanh : SanPham
{
    private double dCongSuat;
    public double CongSuat
    {
        get { return this.dCongSuat; }
        set { this.dCongSuat = value; }
    }
    public MayLanh(double congSuat)
    {
        this.CongSuat = congSuat;
    }

    public MayLanh() { }
    ~MayLanh() { }

    public override void Nhap()
    {
        base.Nhap();
        Console.WriteLine("Nhap Cong suat: ");
        this.dCongSuat = Convert.ToDouble(Console.ReadLine());
    }

    public virtual void Nhap(double congSuat)
    {
        this.CongSuat = congSuat;
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine("Gia ban: " + this.dGiaBan);
        Console.WriteLine("Cong suat: " + this.dCongSuat);
    }
    public override void Cost()
    {
        this.dGiaBan = this.dGiaCoBan + this.dCongSuat * 0.1;
    }
}

class CongTy
{
    private string sTenCongTy;
    private List<SanPham> lSP;
    public string TenCongTy
    {
        get { return this.sTenCongTy; }
        set { this.sTenCongTy = value; }
    }
    //constructors
    public CongTy()
    {
        this.lSP = new List<SanPham>();
    }
    public CongTy(string tenCongTy)
    {
        this.TenCongTy = tenCongTy;
        this.lSP = new List<SanPham>();
    }
    ~CongTy() { }
    //method
    public void Nhap()
    {
        Console.WriteLine("Nhap ten cong ty: ");
        this.TenCongTy = Console.ReadLine();
    }
    public void Xuat()
    {
        Console.WriteLine("Ten cong ty: " + this.TenCongTy);
    }
    public void ThemSanPham(SanPham sp)
    {
        this.lSP.Add(sp);
    }

    public void NhapSanPham()
    {
        foreach (SanPham sp in this.lSP)
        {
            sp.Nhap();
            sp.Cost();
        }
    }
    public void XuatSanPham()
    {
        foreach (SanPham sp in this.lSP)
        {
            sp.Xuat();
        }
    }
    // thêm
    public void SapXepTheoGiaCoBan()
    {
        for (int i = 0; i < this.lSP.Count - 1; i++)
        {
            for (int j = i + 1; j < this.lSP.Count; j++)
            {
                if (this.lSP[i].GiaCoBan > this.lSP[j].GiaCoBan)
                {
                    SanPham temp = this.lSP[i];
                    this.lSP[i] = this.lSP[j];
                    this.lSP[j] = temp;
                }
            }
        }
    }

    public List<SanPham> TimKSanPhamGiaBanCaoNhat(int k)
    {
        List<SanPham> danhSachCopy = new List<SanPham>();
        foreach (SanPham sp in this.lSP)
        {
            danhSachCopy.Add(sp);
        }

        for (int i = 0; i < danhSachCopy.Count - 1; i++)
        {
            for (int j = i + 1; j < danhSachCopy.Count; j++)
            {
                if (danhSachCopy[i].GiaBan < danhSachCopy[j].GiaBan)
                {
                    SanPham temp = danhSachCopy[i];
                    danhSachCopy[i] = danhSachCopy[j];
                    danhSachCopy[j] = temp;
                }
            }
        }

        List<SanPham> ketQua = new List<SanPham>();
        int soLuongLay = k;
        if (soLuongLay > danhSachCopy.Count)
        {
            soLuongLay = danhSachCopy.Count;
        }

        for (int i = 0; i < soLuongLay; i++)
        {
            ketQua.Add(danhSachCopy[i]);
        }

        return ketQua;
    }

    public bool CapNhatSanPham(string maSP)
    {
        foreach (SanPham sp in this.lSP)
        {
            if (sp.MaSP.ToLower() == maSP.ToLower())
            {
                Console.WriteLine("Nhap thong tin moi");
                sp.Nhap();
                sp.Cost();
                return true;
            }
        }
        return false;
    }

    public bool XoaSanPham(string maSP)
    {
        for (int i = 0; i < this.lSP.Count; i++)
        {
            if (this.lSP[i].MaSP.ToLower() == maSP.ToLower())
            {
                this.lSP.RemoveAt(i);
                return true;
            }
        }
        return false;
    }
}

class Program
{
    public static void Main()
    {
        CongTy ct = new CongTy();
        ct.Nhap();

        TiVi tv = new TiVi();
        DienThoai dt = new DienThoai();
        MayLanh ml = new MayLanh();

        ct.ThemSanPham(tv);
        ct.ThemSanPham(dt);
        ct.ThemSanPham(ml);

        int luonchon = 0;
        while (luonchon != 7)
        {
            Console.WriteLine("MENU Quan li san pham");
            Console.WriteLine("1. Nhap thong tin cac san pham");
            Console.WriteLine("2. Xuat danh sach san pham hien tai");
            Console.WriteLine("3. Sap xep san pham theo gia co ban tang dan");
            Console.WriteLine("4. Tim k san pham co gia ban cao nhat");
            Console.WriteLine("5. Cap nhat thong tin san pham");
            Console.WriteLine("6. Xoa san pham");
            Console.WriteLine("7. Thoat chuong trinh");
            Console.Write("Chon chuc nang (1 - 7): ");
            luonchon = Convert.ToInt32(Console.ReadLine());
            switch (luonchon)
            {
                case 1:
                    ct.NhapSanPham();
                    break;
                case 2:
                    ct.XuatSanPham();
                    break;
                case 3:
                    ct.SapXepTheoGiaCoBan();
                    break;
                case 4:
                    Console.WriteLine("Nhap so luong k san pham muon tim: ");
                    int k = Convert.ToInt32(Console.ReadLine());

                    List<SanPham> topDanhSach = ct.TimKSanPhamGiaBanCaoNhat(k);
                    Console.WriteLine($"TOP {k} SAN PHAM CO GIA BAN CAO NHAT");
                    foreach (SanPham sp in topDanhSach)
                    {
                        sp.Xuat();
                    }
                    break;
                case 5:
                    Console.Write("\nNhap MaSP can cap nhat: ");
                    string maSua = Console.ReadLine();

                    if (ct.CapNhatSanPham(maSua) == true)
                    {
                        Console.WriteLine("-> Cap nhat thanh cong");
                    }
                    else
                    {
                        Console.WriteLine("-> Khong tim thay MaSP de cap nhat");
                    }
                    break;
                case 6:
                    Console.Write("\nNhap san pham can xoa: ");
                    string maXoa = Console.ReadLine();
                    if (ct.XoaSanPham(maXoa) == true)
                    {
                        Console.WriteLine("-> Xoa san pham thanh cong");
                    }
                    else
                    {
                        Console.WriteLine("-> Khong tim thay maXoa de xoa");
                    }
                    break;
                case 7:
                    Console.WriteLine("Bye");
                    break;
                default:
                    Console.WriteLine("Khong hop le. Chon lai");
                    break;
            }
        }
    }
}