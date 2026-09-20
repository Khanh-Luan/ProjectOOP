using System;
using System.Collections.Generic;

public class NhanVien
{
    //các fields của class cha nên để protected để class con có thể truy cập
    protected string sMaNV;
    protected string sHoTen;
    protected int iCMND;
    protected int iNamSinh;
    protected double dLuongCoBan;
    protected double dLuong;

    //các properties nên để public để bên ngoài có thể truy cập
    public string MaNV
    {
        get { return this.sMaNV; }
        set { this.sMaNV = value; }
    }
    public string HoTen
    {
        get { return this.sHoTen; }
        set { this.sHoTen = value; }
    }
    public int CMND
    {
        get { return this.iCMND; }
        set { this.iCMND = value; }
    }
    public int NamSinh
    {
        get { return this.iNamSinh; }
        set { this.iNamSinh = value; }
    }
    public double LuongCoBan
    {
        get { return this.dLuongCoBan; }
        set { this.dLuongCoBan = value; }
    }
    public double Luong
    {
        get { return this.dLuong; }
        set { this.dLuong = value; }
    }

    // Các constructors
    public NhanVien(string maNV, string hoTen, int cMND, int namSinh, double luongCoBan, double luong)
    {
        this.MaNV = maNV;
        this.HoTen = hoTen;
        this.CMND = cMND;
        this.NamSinh = namSinh;
        this.LuongCoBan = luongCoBan;
        this.Luong = luong;
    }
    public NhanVien() { }

    // destructors
    ~NhanVien() { }

    // Các method
    // Hàm nhập
    public virtual void Nhap()
    {
        Console.WriteLine("Nhap ma nhan vien: ");
        this.MaNV = Console.ReadLine();
        Console.WriteLine("Nhap ho ten: ");
        this.HoTen = Console.ReadLine();
        Console.WriteLine("Chung minh nhan dan: ");
        this.CMND = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Nhap nam sinh: ");
        this.NamSinh = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Nhap luong co ban: ");
        this.LuongCoBan = Convert.ToDouble(Console.ReadLine());
    }
    public virtual void Nhap(string maNV, string hoTen, int cMND, int namSinh, double luongCoBan)
    {
        this.MaNV = maNV;
        this.HoTen = hoTen;
        this.CMND = cMND;
        this.NamSinh = namSinh;
        this.LuongCoBan = luongCoBan;
    }
    // Hàm xuất 
    public virtual void Xuat()
    {
        Console.WriteLine("Ma nhan vien: " + this.sMaNV);
        Console.WriteLine("Ho ten: " + this.sHoTen);
        Console.WriteLine("CMND: " + this.iCMND);
        Console.WriteLine("Nam sinh: " + this.iNamSinh);
        Console.WriteLine("Luong co ban: " + this.dLuongCoBan);
    }
    public void CapNhatNamSinh(string maNV, int iNamSinhMoi)
    {
        if (this.sMaNV == maNV)
        {
            this.iNamSinh = iNamSinhMoi;
            Console.WriteLine("Da cap nhat nam sinh");
        }
        else
        {
            Console.WriteLine("Khong tim thay ma nhan vien");
        }
    }
    // Hàm tính toán
    public virtual void TinhLuong()
    {
        this.dLuong = this.dLuongCoBan;
    }
}

public class NVKeToan : NhanVien
{
    //field class con không ai kế thừa nên để private
    private double dPhuCap;

    public double PhuCap
    {
        get { return this.dPhuCap; }
        set { this.dPhuCap = value; }
    }
    public NVKeToan(double phuCap)
    {
        this.PhuCap = phuCap;
    }
    public NVKeToan() { }
    ~NVKeToan() { }

    public override void Nhap()
    {
        base.Nhap();
        Console.WriteLine("Nhap Phu cap: ");
        this.PhuCap = Convert.ToDouble(Console.ReadLine());
    }
    public virtual void Nhap(double phuCap)
    {
        this.PhuCap = phuCap;
    }
    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine("Phu cap: " + this.dPhuCap);
        Console.WriteLine("Luong: " + this.dLuong);
    }

    public override void TinhLuong()
    {
        this.dLuong = this.dLuongCoBan + this.dPhuCap;
    }
}


public class NVKinhDoanh : NhanVien
{
    private double dPhuCap;
    private int iSoHopDong;

    public double PhuCap
    {
        get { return this.dPhuCap; }
        set { this.dPhuCap = value; }
    }
    public int SoHopDong
    {
        get { return this.iSoHopDong; }
        set { this.iSoHopDong = value; }
    }
    public NVKinhDoanh(double phuCap, int soHopDong)
    {
        this.PhuCap = phuCap;
        this.SoHopDong = soHopDong;
    }
    public NVKinhDoanh() { }
    ~NVKinhDoanh() { }

    public override void Nhap()
    {
        base.Nhap();
        Console.WriteLine("Nhap Phu cap: ");
        this.PhuCap = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Nhap So hop dong: ");
        this.SoHopDong = Convert.ToInt32(Console.ReadLine());
    }

    public virtual void Nhap(double phuCap, int soHopDong)
    {
        this.PhuCap = phuCap;
        this.SoHopDong = soHopDong;
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine("Phu cap: " + this.dPhuCap);
        Console.WriteLine("So hop dong: " + this.iSoHopDong);
        Console.WriteLine("Luong: " + this.dLuong);
    }

    public override void TinhLuong()
    {
        this.dLuong = this.dLuongCoBan + (this.dPhuCap * this.iSoHopDong);
    }
}


public class NVBaoVe : NhanVien
{
    private double dPhuCap;
    private int iSoHopDong;
    private int iCaDangKyViecLam;

    public double PhuCap
    {
        get { return this.dPhuCap; }
        set { this.dPhuCap = value; }
    }
    public int SoHopDong
    {
        get { return this.iSoHopDong; }
        set { this.iSoHopDong = value; }
    }
    public int CaDangKyLamViec
    {
        get { return this.iCaDangKyViecLam; }
        set { this.iCaDangKyViecLam = value; }
    }
    public NVBaoVe(double phuCap, int soHopDong, int soCaDangKyLamViec)
    {
        this.PhuCap = phuCap;
        this.SoHopDong = soHopDong;
        this.CaDangKyLamViec = soCaDangKyLamViec;
    }
    public NVBaoVe() { }
    ~NVBaoVe() { }

    public override void Nhap()
    {
        base.Nhap();
        Console.WriteLine("Nhap Phu cap: ");
        this.PhuCap = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Nhap So hop dong: ");
        this.SoHopDong = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Nhap so ca dang ky lam viec: ");
        this.CaDangKyLamViec = Convert.ToInt32(Console.ReadLine());
    }

    public virtual void Nhap(double phuCap, int soHopDong, int soCaDangKyLamViec)

    {
        this.PhuCap = phuCap;
        this.SoHopDong = soHopDong;
        this.CaDangKyLamViec = soCaDangKyLamViec;
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine("Phu cap: " + this.dPhuCap);
        Console.WriteLine("So hop dong: " + this.iSoHopDong);
        Console.WriteLine("Luong: " + this.dLuongCoBan);
    }

    public override void TinhLuong()
    {
        this.dLuong = this.dLuongCoBan;
    }
}

class CongTy
{
    private string sTenCongTy;
    private List<NhanVien> lNV;

    public string TenCongTy
    {
        get { return this.sTenCongTy; }
        set { this.sTenCongTy = value; }
    }

    // Constructor
    public CongTy()
    {
        this.lNV = new List<NhanVien>();
    }

    public CongTy(string tenCongTy)
    {
        this.TenCongTy = tenCongTy;
        this.lNV = new List<NhanVien>();
    }

    ~CongTy() { }

    public void Nhap()
    {
        Console.WriteLine("Nhap ten cong ty: ");
        this.TenCongTy = Console.ReadLine();
    }

    public void Xuat()
    {
        Console.WriteLine("Ten Cong Ty: " + this.TenCongTy);
    }

    public void ThemNhanVien(NhanVien nv)
    {
        this.lNV.Add(nv);
    }

    public void NhapNhanVien()
    {
        foreach (NhanVien nv in this.lNV)
        {
            nv.Nhap();
            nv.TinhLuong();
        }
    }

    public void XuatNhanVien()
    {
        foreach (NhanVien nv in this.lNV)
        {
            nv.Xuat();
        }
    }

    public void SapXepNhanVienTheoLuong()
    {
        for (int i = 0; i < this.lNV.Count - 1; i++)
        {
            for (int j = i + 1; j < this.lNV.Count; j++)
            {
                if (this.lNV[i].Luong > this.lNV[j].Luong)
                {
                    NhanVien luongcao = this.lNV[i];
                    this.lNV[i] = this.lNV[j];
                    this.lNV[j] = luongcao;
                }
            }
        }
    }

    public List<NhanVien> TimKNhanVienCoLuongCaoNhat(int n)
    {
        List<NhanVien> danhSach = new List<NhanVien>();
        foreach (NhanVien nv in this.lNV)
        {
            danhSach.Add(nv);
        }

        for (int i = 0; i < danhSach.Count - 1; i++)
        {
            for (int j = i + 1; j < danhSach.Count; j++)
            {
                if (danhSach[i].Luong < danhSach[j].Luong)
                {
                    NhanVien t = danhSach[i];
                    danhSach[i] = danhSach[j];
                    danhSach[j] = t;
                }
            }
        }

        List<NhanVien> ketQua = new List<NhanVien>();
        int soLuongLay = n;
        if (soLuongLay > danhSach.Count)
        {
            soLuongLay = danhSach.Count;
        }

        for (int i = 0; i < soLuongLay; i++)
        {
            ketQua.Add(danhSach[i]);
        }

        return ketQua;
    }

    public bool SaThaiNhanVien(string maNV)
    {
        for (int i = 0; i < this.lNV.Count; i++)
        {
            if (this.lNV[i].MaNV == maNV)
            {
                this.lNV.RemoveAt(i);
                return true;
            }
        }
        return false;
    }

    public void CapNhatNamSinh(string maNV, int iNamSinhMoi)
    {
        foreach (NhanVien nv in this.lNV)
        {
            if (nv.MaNV == maNV)
            {
                nv.NamSinh = iNamSinhMoi;
                Console.WriteLine("Da cap nhat nam sinh");
            }
            else
            {
                Console.WriteLine("Khong tim thay ma nhan vien");
            }
        }
    }
}

class Program
{
    public static void Main()
    {
        CongTy ct = new CongTy();
        ct.Nhap();

        NhanVien a = new NVKeToan();
        NhanVien b = new NVKinhDoanh();
        NhanVien c = new NVBaoVe();

        ct.ThemNhanVien(a);
        ct.ThemNhanVien(b);
        ct.ThemNhanVien(c);

        int luachon = 0;
        while (luachon != 7)
        {
            Console.WriteLine("MENU QUAN LI NHAN VIEN");
            Console.WriteLine("1. Nhap thong tin cac nhan vien");
            Console.WriteLine("2. Xuat danh sach nhan vien");
            Console.WriteLine("3. Cap nhat nam sinh moi");
            Console.WriteLine("4. Sap xep nhan vien theo luong");
            Console.WriteLine("5. Tim k nhan vien co luong cao nhat");
            Console.WriteLine("6. Sa thai nhan vien");
            Console.WriteLine("7. Thoat");
            Console.WriteLine("Chon chuc nang (1 - 7): ");
            luachon = Convert.ToInt32(Console.ReadLine());

            switch (luachon)
            {
                case 1:
                    ct.NhapNhanVien();
                    break;
                case 2:
                    ct.XuatNhanVien();
                    break;
                case 3:
                    Console.WriteLine("Nhap ma nhan vien muon sua nam sinh: ");
                    string maSua = Console.ReadLine();
                    int iNamSinhMoi = Convert.ToInt32(Console.ReadLine());
                    ct.CapNhatNamSinh(maSua, iNamSinhMoi);
                    break;
                case 4:
                    ct.SapXepNhanVienTheoLuong();
                    break;
                case 5:
                    Console.WriteLine("Nhap so luong k nhan vien muon tim: ");
                    int n = Convert.ToInt32(Console.ReadLine());

                    List<NhanVien> topDanhSach = ct.TimKNhanVienCoLuongCaoNhat(n);
                    Console.WriteLine($"TOP {n} NHAN CO LUONG CAO NHAT");
                    foreach (NhanVien nv in topDanhSach)
                    {
                        nv.Xuat();
                    }
                    break;
                case 6:
                    Console.WriteLine("Nhan vien can sa thai: ");
                    string maSaThai = Console.ReadLine();
                    if (ct.SaThaiNhanVien(maSaThai) == true)
                    {
                        Console.WriteLine("Sa thai nhan vien thanh cong");
                    }
                    else
                    {
                        Console.WriteLine("Khong tim thay ma nhan vien");
                    }
                    break;
                case 7:
                    Console.WriteLine("bye");
                    break;
                default:
                    Console.WriteLine("Khong hop le. Hay chon lai");
                    break;
            }
        }
    }
}