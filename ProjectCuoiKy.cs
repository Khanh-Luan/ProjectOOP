using System;

public abstract class MonAn
{
    // fields
    protected string sMaMon;
    protected string sTenMon;
    protected double dGiaMon;
    protected double dGiaBan;
    // properties
    public string MaMon
    {
        get { return this.sMaMon; }
        set { this.sMaMon = value; }
    }

    public string TenMon
    {
        get { return this.sTenMon; }
        set { this.sTenMon = value; }
    }
    public double GiaMon
    {
        get { return this.dGiaMon; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(value)}, the price must be greater than 0.");
            }
            this.dGiaMon = value;
        }
    }
    public double GiaBan
    {
        get { return this.dGiaBan; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(value)}, the price must be greater than 0.");
            }
            this.dGiaBan = value;
        }
    }
    // constructors
    public MonAn()
    {
    }
    public MonAn(string maMon, string tenMon, double giaMon, double giaBan)
    {
        this.MaMon = maMon;
        this.TenMon = tenMon;
        this.GiaMon = giaMon;
        this.GiaBan = giaBan;
    }
    //destructors
    ~MonAn() { }

    // method
    // Hàm nhập
    public virtual void Nhap()
    {
        Console.WriteLine("Nhap ma cua mon an: ");
        this.MaMon = Console.ReadLine();
        Console.WriteLine("Nhap ten cua mon an: ");
        this.TenMon = Console.ReadLine();
        Console.WriteLine("Nhap gia ban cua mon an: ");
        this.GiaMon = Convert.ToDouble(Console.ReadLine());
    }
    public virtual void Nhap(string maMon, string tenMon, double giaMon)
    {
        this.MaMon = maMon;
        this.TenMon = tenMon;
        this.GiaMon = giaMon;
    }
    // Hàm xuất
    public virtual void Xuat()
    {
        Console.WriteLine($"Ma cua mon an: {this.sMaMon}");
        Console.WriteLine($"Ten cua mon an: {this.sTenMon}");
        Console.WriteLine($"Gia ban cua mon an: {this.dGiaMon}");
    }
    // Hàm tính toán
    public virtual void TinhGiaBan()
    {
        this.dGiaBan = dGiaMon;
    }
}

