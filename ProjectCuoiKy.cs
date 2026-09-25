using System;
using System.Collections.Generic;

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

    public NguoiDung() { }

    public NguoiDung(string ma, string ten, string sdt, string email)
    {
        this.sMa = ma;
        this.sTen = ten;
        this.sSdt = sdt;
        this.sEmail = email;
    }

    public virtual void Nhap()
    {
        Console.WriteLine("Nhap ma: ");
        sMa = Console.ReadLine();
        Console.WriteLine("Nhap ten: ");
        sTen = Console.ReadLine();
        Console.WriteLine("Nhap sdt: ");
        sSdt = Console.ReadLine();
        Console.WriteLine("Nhap email: ");
        sEmail = Console.ReadLine();
    }

    public virtual void Xuat()
    {
        Console.WriteLine($"Ma: {sMa}");
        Console.WriteLine($"Ten: {sTen}");
        Console.WriteLine($"Sdt: {sSdt}");
        Console.WriteLine($"Email: {sEmail}");
    }

    // moi loai nguoi dung tinh tien theo cach rieng cua minh
    public abstract void TinhToanTien(double soTien);
}

public class KhachHang : NguoiDung
{
    private string sDiaChiGiao;
    private int iDiemTichLuyITFood;
    private double dTongDaChi;
    private List<Voucher> dsVoucher;

    public string DiaChiGiao { get { return sDiaChiGiao; } set { sDiaChiGiao = value; } }
    public int DiemTichLuyITFood { get { return iDiemTichLuyITFood; } set { iDiemTichLuyITFood = value; } }
    public double TongDaChi { get { return dTongDaChi; } }

    public KhachHang()
    {
        this.dsVoucher = new List<Voucher>();
    }

    public KhachHang(string ma, string ten, string sdt, string email, string diaChi)
        : base(ma, ten, sdt, email)
    {
        this.sDiaChiGiao = diaChi;
        this.iDiemTichLuyITFood = 0;
        this.dTongDaChi = 0;
        this.dsVoucher = new List<Voucher>();
    }

    public void ThemVoucher(Voucher v)
    {
        dsVoucher.Add(v);
    }

    public void XoaVoucher(string ma)
    {
        Voucher v = TimVoucher(ma);
        if (v != null)
            dsVoucher.Remove(v);
    }

    public void HienThiVoucherDaDung()
    {
        Console.WriteLine("Voucher da su dung:");
        for (int i = 0; i < dsVoucher.Count; i++)
        {
            if (!dsVoucher[i].ConSuDung)
                dsVoucher[i].Xuat();
        }
    }

    public void HienThiVoucherConDung()
    {
        Console.WriteLine("Voucher hien co:");
        for (int i = 0; i < dsVoucher.Count; i++)
        {
            if (dsVoucher[i].ConSuDung)
                dsVoucher[i].Xuat();
        }
    }

    public override void Nhap()
    {
        base.Nhap();
        Console.WriteLine("Nhap dia chi giao: ");
        sDiaChiGiao = Console.ReadLine();
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine($"Dia chi giao: {sDiaChiGiao}");
        Console.WriteLine($"Diem tich luy: {iDiemTichLuyITFood}");
    }

    public Voucher TimVoucher(string ma)
    {
        for (int i = 0; i < dsVoucher.Count; i++)
        {
            if (dsVoucher[i].Ma == ma)
                return dsVoucher[i];
        }
        return null;
    }

    // ham tinh toan so tien: cong don da chi va diem tich luy
    public override void TinhToanTien(double soTien)
    {
        dTongDaChi = dTongDaChi + soTien;
        iDiemTichLuyITFood = iDiemTichLuyITFood + (int)(soTien / 10000);
    }
}

public class ChuQuan : NguoiDung
{
    private List<Quan> dsQuan;
    private double dTongDoanhThu;

    public double TongDoanhThu { get { return dTongDoanhThu; } }

    public ChuQuan()
    {
        dsQuan = new List<Quan>();
    }

    public ChuQuan(string ma, string ten, string sdt, string email)
        : base(ma, ten, sdt, email)
    {
        dsQuan = new List<Quan>();
        dTongDoanhThu = 0;
    }

    public void ThemQuan(Quan quan)
    {
        dsQuan.Add(quan);
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine($"So quan so huu: {dsQuan.Count}");
    }

    // ham tinh toan so tien: cong doanh thu tu don hang cua quan minh
    public override void TinhToanTien(double soTien)
    {
        dTongDoanhThu = dTongDoanhThu + soTien;
    }
}

public class TaiXe : NguoiDung
{
    private string sBienSo;
    private bool bDangRanh;
    private int iSoDonDaGiao;
    private double dTongThuNhap;

    public string BienSo { get { return sBienSo; } set { sBienSo = value; } }
    public bool DangRanh { get { return bDangRanh; } set { bDangRanh = value; } }
    public int SoDonDaGiao { get { return iSoDonDaGiao; } set { iSoDonDaGiao = value; } }
    public double TongThuNhap { get { return dTongThuNhap; } }

    public TaiXe()
    {
        this.bDangRanh = true;
    }

    public TaiXe(string ma, string ten, string sdt, string email, string bienSo)
        : base(ma, ten, sdt, email)
    {
        this.sBienSo = bienSo;
        this.bDangRanh = true;
        this.iSoDonDaGiao = 0;
        this.dTongThuNhap = 0;
    }

    // ham tinh toan so tien: tai xe nhan het phi ship cua don da giao
    public override void TinhToanTien(double soTien)
    {
        dTongThuNhap = dTongThuNhap + soTien;
    }

    public override void Nhap()
    {
        base.Nhap();
        Console.WriteLine("Nhap bien so xe: ");
        sBienSo = Console.ReadLine();
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine($"Bien so xe: {sBienSo}");
        Console.WriteLine($"Dang ranh: {bDangRanh}");
    }

    public void HoanThanhGiao()
    {
        iSoDonDaGiao = iSoDonDaGiao + 1;
        bDangRanh = true;
    }
}

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

    public MonAn() { }

    public MonAn(string ma, string ten, double gia)
    {
        this.sMa = ma;
        this.sTen = ten;
        this.Gia = gia;
    }

    public virtual void Nhap()
    {
        Console.WriteLine("Nhap ma mon: ");
        sMa = Console.ReadLine();
        Console.WriteLine("Nhap ten mon: ");
        sTen = Console.ReadLine();
        Console.WriteLine("Nhap gia: ");
        Gia = Convert.ToDouble(Console.ReadLine());
    }

    public virtual void HienThi()
    {
        Console.WriteLine($"{sMa} - {sTen} - {dGia}d");
    }
}

// ================= VOUCHER =================
public class Voucher
{
    private string sMa;
    private double dPhanTram;
    private bool bConSuDung;

    public string Ma { get { return sMa; } set { sMa = value; } }
    public double PhanTram { get { return dPhanTram; } set { dPhanTram = value; } }
    public bool ConSuDung { get { return bConSuDung; } }

    public Voucher() { }

    public Voucher(string ma, double phanTram)
    {
        this.sMa = ma;
        this.dPhanTram = phanTram;
        this.bConSuDung = true;
    }

    public double TinhGiam(double tienMon)
    {
        if (!bConSuDung)
            return 0;
        return tienMon * dPhanTram / 100;
    }

    public void SuDung()
    {
        bConSuDung = false;
    }

    public void Nhap()
    {
        Console.WriteLine("Nhap ma voucher: ");
        sMa = Console.ReadLine();
        Console.WriteLine("Nhap phan tram giam: ");
        dPhanTram = Convert.ToDouble(Console.ReadLine());
        bConSuDung = true;
    }

    public void Xuat()
    {
        Console.WriteLine($"{sMa} - Giam {dPhanTram}% - Con su dung: {bConSuDung}");
    }
}

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

    public Quan() { }

    public Quan(string ma, string ten, string diaChi, ChuQuan chuQuan)
    {
        this.sMa = ma;
        this.sTen = ten;
        this.sDiaChi = diaChi;
        this.bDangMoCua = true;
        this.menu = new List<MonAn>();
        this.chuQuan = chuQuan;
    }

    public void Nhap(ChuQuan chuSoHuu)
    {
        Console.WriteLine("Nhap ma quan: ");
        sMa = Console.ReadLine();
        Console.WriteLine("Nhap ten quan: ");
        sTen = Console.ReadLine();
        Console.WriteLine("Nhap dia chi: ");
        sDiaChi = Console.ReadLine();
        bDangMoCua = true;
        menu = new List<MonAn>();
        chuQuan = chuSoHuu;
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

    public void NhanDon(DonHang don)
    {
        Console.WriteLine($"[Thong bao quan {sTen}] Nhan duoc don {don.Ma}, bat dau lam mon.");
        don.CapNhatTrangThai("DangLam");
    }
}

// ================= PHUONG THUC THANH TOAN =================
public abstract class PhuongThucThanhToan
{
    public abstract bool XuLyThanhToan(double soTien);
}

public class TienMat : PhuongThucThanhToan
{
    public override bool XuLyThanhToan(double soTien)
    {
        Console.WriteLine($"Thanh toan {soTien}d bang tien mat khi nhan hang.");
        return true;
    }
}

public class ViDienTu : PhuongThucThanhToan
{
    private double dSoDu;

    public ViDienTu() { }

    public ViDienTu(double soDu)
    {
        this.dSoDu = soDu;
    }

    public void Nhap()
    {
        Console.WriteLine("Nhap so du vi: ");
        dSoDu = Convert.ToDouble(Console.ReadLine());
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

public class The : PhuongThucThanhToan
{
    private const double PHI_GIAO_DICH_MAC_DINH = 3000; // he thong tu dat theo thuc te

    private string sSoTheCuoi;
    private double dPhiGiaoDich;

    public The()
    {
        dPhiGiaoDich = PHI_GIAO_DICH_MAC_DINH;
    }

    public The(string soTheCuoi)
    {
        this.sSoTheCuoi = soTheCuoi;
        this.dPhiGiaoDich = PHI_GIAO_DICH_MAC_DINH;
    }

    public void Nhap()
    {
        Console.WriteLine("Nhap 4 so cuoi the: ");
        sSoTheCuoi = Console.ReadLine();
        dPhiGiaoDich = PHI_GIAO_DICH_MAC_DINH;
    }

    public override bool XuLyThanhToan(double soTien)
    {
        double tongTien = soTien + dPhiGiaoDich;
        Console.WriteLine($"Da thanh toan {tongTien}d bang the ***{sSoTheCuoi} (gom phi {dPhiGiaoDich}d)");
        return true;
    }
}

// ================= DON HANG =================
public class DonHang
{
    private string sMa;
    private KhachHang khach;
    private Quan quan;
    private TaiXe taiXe;
    private List<MonAn> dsMon;
    private List<int> dsSoLuong;
    private double dKhoangCachKm;
    private string sTrangThai; // ChoXacNhan, DangGiao, HoanThanh, DaHuy
    private PhuongThucThanhToan thanhToan;
    private double dSoTienDaThanhToan;

    public string Ma { get { return sMa; } }
    public string TrangThai { get { return sTrangThai; } }

    public DonHang(string ma, KhachHang khach, Quan quan)
    {
        this.sMa = ma;
        this.khach = khach;
        this.quan = quan;
        this.dsMon = new List<MonAn>();
        this.dsSoLuong = new List<int>();
        this.sTrangThai = "ChoXacNhan";
    }

    public void GoiMon(MonAn mon, int soLuong)
    {
        dsMon.Add(mon);
        dsSoLuong.Add(soLuong);
    }

    // khach nhap thong tin dat hang: chon mon trong menu cua quan, nhap khoang cach giao
    public void Nhap()
    {
        quan.HienThiMenu();
        Console.WriteLine("Nhap so mon muon dat: ");
        int soMon = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < soMon; i++)
        {
            Console.WriteLine("Nhap ma mon: ");
            string maMon = Console.ReadLine();
            Console.WriteLine("Nhap so luong: ");
            int soLuong = Convert.ToInt32(Console.ReadLine());
            MonAn mon = quan.TimMon(maMon);
            if (mon != null)
                GoiMon(mon, soLuong);
        }
        Console.WriteLine("Nhap khoang cach giao (km): ");
        dKhoangCachKm = Convert.ToDouble(Console.ReadLine());
        sTrangThai = "ChoXacNhan";
        Xuat();
    }

    public void CapNhatTrangThai(string trangThaiMoi)
    {
        sTrangThai = trangThaiMoi;
    }

    public void Xuat()
    {
        Console.WriteLine($"----- DON HANG {sMa} -----");
        for (int i = 0; i < dsMon.Count; i++)
        {
            Console.WriteLine($"{dsMon[i].Ten} x{dsSoLuong[i]}");
        }
        Console.WriteLine($"Trang thai: {sTrangThai}");
    }

    public double TongTienMon()
    {
        double tong = 0;
        for (int i = 0; i < dsMon.Count; i++)
        {
            tong = tong + dsMon[i].Gia * dsSoLuong[i];
        }
        return tong;
    }

    public double TinhPhiShip()
    {
        if (dKhoangCachKm <= 3)
            return 15000;
        if (dKhoangCachKm <= 7)
            return 25000;
        return 40000;
    }

    public double TinhGiamGia(string maVoucher)
    {
        if (maVoucher == null)
            return 0;
        Voucher v = khach.TimVoucher(maVoucher);
        if (v == null)
            return 0;
        return v.TinhGiam(TongTienMon());
    }

    public double TongThanhToan(string maVoucher)
    {
        return TongTienMon() - TinhGiamGia(maVoucher) + TinhPhiShip();
    }

    public void GanTaiXe(TaiXe tx)
    {
        this.taiXe = tx;
        tx.DangRanh = false;
        this.sTrangThai = "DangGiao";
        Console.WriteLine($"[Thong bao tai xe {tx.Ten}] Ban duoc phan cong giao don {sMa}.");
    }

    public void ThanhToan(PhuongThucThanhToan ptTT, string maVoucher)
    {
        this.thanhToan = ptTT;
        double giam = TinhGiamGia(maVoucher);
        double tongTien = TongThanhToan(maVoucher);
        this.dSoTienDaThanhToan = tongTien;
        bool thanhCong = thanhToan.XuLyThanhToan(tongTien);
        if (thanhCong)
        {
            this.sTrangThai = "HoanThanh";
            if (maVoucher != null)
            {
                Voucher v = khach.TimVoucher(maVoucher);
                if (v != null)
                    v.SuDung();
            }
            khach.TinhToanTien(tongTien);
            quan.ChuCuaQuan.TinhToanTien(TongTienMon() - giam);
            if (taiXe != null)
            {
                taiXe.TinhToanTien(TinhPhiShip());
                taiXe.HoanThanhGiao();
            }
        }
    }

    public void InHoaDon()
    {
        Console.WriteLine($"----- HOA DON {sMa} -----");
        for (int i = 0; i < dsMon.Count; i++)
        {
            Console.WriteLine($"{dsMon[i].Ten} x{dsSoLuong[i]} = {dsMon[i].Gia * dsSoLuong[i]}d");
        }
        Console.WriteLine($"Tien mon: {TongTienMon()}d");
        Console.WriteLine($"Phi ship: {TinhPhiShip()}d");
        Console.WriteLine($"Tong thanh toan: {dSoTienDaThanhToan}d");
        Console.WriteLine($"Trang thai: {sTrangThai}");
    }
}

// ================= UNG DUNG (LOP TONG) =================
public class UngDung
{
    private List<KhachHang> dsKhachHang;
    private List<ChuQuan> dsChuQuan;
    private List<TaiXe> dsTaiXe;
    private List<Quan> dsQuan;
    private List<DonHang> dsDonHang;

    public UngDung()
    {
        dsKhachHang = new List<KhachHang>();
        dsChuQuan = new List<ChuQuan>();
        dsTaiXe = new List<TaiXe>();
        dsQuan = new List<Quan>();
        dsDonHang = new List<DonHang>();
    }

    public void ThemKhachHang(KhachHang kh) { dsKhachHang.Add(kh); }
    public void ThemChuQuan(ChuQuan cq) { dsChuQuan.Add(cq); }
    public void ThemTaiXe(TaiXe tx) { dsTaiXe.Add(tx); }
    public void ThemQuan(Quan q) { dsQuan.Add(q); }

    public TaiXe TimTaiXeRanh()
    {
        for (int i = 0; i < dsTaiXe.Count; i++)
        {
            if (dsTaiXe[i].DangRanh)
                return dsTaiXe[i];
        }
        return null;
    }

    public void TimTaiXeRanhVaGanDon(DonHang don)
    {
        TaiXe tx = TimTaiXeRanh();
        if (tx != null)
            don.GanTaiXe(tx);
        else
            Console.WriteLine("Khong co tai xe ranh.");
    }

    public DonHang TaoDonHang(string ma, KhachHang kh, Quan quan)
    {
        DonHang don = new DonHang(ma, kh, quan);
        dsDonHang.Add(don);
        return don;
    }

    public void BaoCao()
    {
        Console.WriteLine("===== BAO CAO =====");
        Console.WriteLine($"So don hang: {dsDonHang.Count}");
        for (int i = 0; i < dsTaiXe.Count; i++)
        {
            dsTaiXe[i].Xuat();
        }
    }
}

// ================= CHAY THU =================
class Program
{
    static void Main(string[] args)
    {
        UngDung app = new UngDung();

        ChuQuan cq = new ChuQuan();
        cq.Nhap();
        app.ThemChuQuan(cq);

        Quan quan = new Quan();
        quan.Nhap(cq);
        cq.ThemQuan(quan);
        app.ThemQuan(quan);

        Console.WriteLine("Nhap so mon trong menu: ");
        int soMonMenu = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < soMonMenu; i++)
        {
            MonAn mon = new MonAn();
            mon.Nhap();
            quan.ThemMon(mon);
        }

        KhachHang kh = new KhachHang();
        kh.Nhap();
        app.ThemKhachHang(kh);

        Console.WriteLine("Nhap co voucher hay khong (co/khong): ");
        if (Console.ReadLine() == "co")
        {
            Voucher v = new Voucher();
            v.Nhap();
            kh.ThemVoucher(v);
        }

        TaiXe tx = new TaiXe();
        tx.Nhap();
        app.ThemTaiXe(tx);

        // 1. Khach dat hang -> don o trang thai cho
        Console.WriteLine("Nhap ma don hang: ");
        string maDon = Console.ReadLine();
        DonHang don = app.TaoDonHang(maDon, kh, quan);
        don.Nhap();

        // 2. Quan nhan thong bao, len don, lam mon
        quan.NhanDon(don);

        // 3. He thong bao tai xe dang ranh va gan don
        app.TimTaiXeRanhVaGanDon(don);

        Console.WriteLine("Chon phuong thuc thanh toan (1-Tien mat, 2-Vi dien tu, 3-The): ");
        string chon = Console.ReadLine();
        PhuongThucThanhToan ptTT;
        if (chon == "2")
        {
            ViDienTu vi = new ViDienTu();
            vi.Nhap();
            ptTT = vi;
        }
        else if (chon == "3")
        {
            The the = new The();
            the.Nhap();
            ptTT = the;
        }
        else
        {
            ptTT = new TienMat();
        }

        kh.HienThiVoucherConDung();
        Console.WriteLine("Nhap ma voucher muon dung (bo trong neu khong dung): ");
        string maVoucher = Console.ReadLine();
        if (string.IsNullOrEmpty(maVoucher))
            maVoucher = null;

        don.ThanhToan(ptTT, maVoucher);
        don.InHoaDon();

        app.BaoCao();
        cq.Xuat();
        kh.Xuat();
        kh.HienThiVoucherDaDung();

        Console.ReadLine();
    }
}