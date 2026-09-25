using System;
using System.Collections.Generic;

// ================= TRANG THAI DON HANG (ENUM) =================
// dung enum thay cho string de gioi han cac gia tri hop le, tranh go sai
public enum TrangThaiDon
{
    ChoXacNhan,
    DangLam,
    DaThanhToan,
    DangGiao,
    HoanThanh,
    DaHuy
}

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

    public string DiaChiGiao { get { return sDiaChiGiao; } set { sDiaChiGiao = value; } }
    public int DiemTichLuyITFood { get { return iDiemTichLuyITFood; } set { iDiemTichLuyITFood = value; } }
    public double TongDaChi { get { return dTongDaChi; } }

    public KhachHang() { }

    public KhachHang(string ma, string ten, string sdt, string email, string diaChi)
        : base(ma, ten, sdt, email)
    {
        this.sDiaChiGiao = diaChi;
        this.iDiemTichLuyITFood = 0;
        this.dTongDaChi = 0;
    }

    public override void Nhap()
    {
        base.Nhap();
        Console.WriteLine("Khach hang!!!");
        Console.WriteLine("Nhap dia chi giao: ");
        sDiaChiGiao = Console.ReadLine();
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine($"Dia chi giao: {sDiaChiGiao}");
        Console.WriteLine($"Diem tich luy: {iDiemTichLuyITFood}");
        Console.WriteLine($"Tong da chi: {dTongDaChi}d");
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
        quan.ChuCuaQuan = this;
    }

    public Quan TimQuan(string ma)
    {
        for (int i = 0; i < dsQuan.Count; i++)
        {
            if (dsQuan[i].Ma == ma)
                return dsQuan[i];
        }
        return null;
    }

    public void HienThiDsQuan()
    {
        Console.WriteLine($"Danh sach quan cua {sTen}:");
        for (int i = 0; i < dsQuan.Count; i++)
        {
            Console.WriteLine($"  {dsQuan[i].Ma} - {dsQuan[i].Ten} - {dsQuan[i].DiaChi}");
        }
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine($"So quan so huu: {dsQuan.Count}");
        Console.WriteLine($"Tong doanh thu: {dTongDoanhThu}d");
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

        Console.WriteLine("Tai Xe!!!");
        Console.WriteLine("Nhap bien so xe: ");
        sBienSo = Console.ReadLine();
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine($"Bien so xe: {sBienSo}");
        Console.WriteLine($"Dang ranh: {bDangRanh}");
        Console.WriteLine($"So don da giao: {iSoDonDaGiao}");
        Console.WriteLine($"Tong thu nhap: {dTongThuNhap}d");
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

// ================= CHI TIET DON =================
// gop MonAn + SoLuong vao 1 class thay vi 2 list rieng le, de quan ly hon
public class ChiTietDon
{
    private MonAn mon;
    private int iSoLuong;

    public MonAn Mon { get { return mon; } set { mon = value; } }
    public int SoLuong { get { return iSoLuong; } set { iSoLuong = value; } }

    public ChiTietDon() { }

    public ChiTietDon(MonAn mon, int soLuong)
    {
        this.mon = mon;
        this.iSoLuong = soLuong;
    }

    public double ThanhTien()
    {
        return mon.Gia * iSoLuong;
    }

    public void HienThi()
    {
        Console.WriteLine($"{mon.Ten} x{iSoLuong} = {ThanhTien()}d");
    }
}

// ================= VOUCHER =================
public class Voucher
{
    private string sMa;
    private string sTen;
    private double dPhanTram;
    private bool bConSuDung;

    public string Ma { get { return sMa; } set { sMa = value; } }
    public string Ten { get { return sTen; } set { sTen = value; } }
    public double PhanTram { get { return dPhanTram; } set { dPhanTram = value; } } // Sửa lại set giới hạn từ 0-100
    public bool ConSuDung { get { return bConSuDung; } }

    public Voucher() { }

    public Voucher(string ma, string ten, double phanTram)
    {
        this.sMa = ma;
        this.sTen = ten;
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
        Console.WriteLine("Nhap ten voucher: ");
        sTen = Console.ReadLine();
        Console.WriteLine("Nhap phan tram giam: ");
        dPhanTram = Convert.ToDouble(Console.ReadLine());
        bConSuDung = true;
    }

    public void Xuat()
    {
        Console.WriteLine($"{sMa} - {sTen} - Giam {dPhanTram}% - Con su dung: {bConSuDung}");
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
    private List<Voucher> dsVoucher;
    private ChuQuan chuQuan;

    public string Ma { get { return sMa; } set { sMa = value; } }
    public string Ten { get { return sTen; } set { sTen = value; } }
    public string DiaChi { get { return sDiaChi; } set { sDiaChi = value; } }
    public bool DangMoCua { get { return bDangMoCua; } set { bDangMoCua = value; } }
    public ChuQuan ChuCuaQuan { get { return chuQuan; } set { chuQuan = value; } }

    public Quan()
    {
        this.menu = new List<MonAn>();
        this.dsVoucher = new List<Voucher>();
        this.bDangMoCua = true;
    }

    public Quan(string ma, string ten, string diaChi)
    {
        this.sMa = ma;
        this.sTen = ten;
        this.sDiaChi = diaChi;
        this.bDangMoCua = true;
        this.menu = new List<MonAn>();
        this.dsVoucher = new List<Voucher>();
    }

    // chi nhap thong tin cua quan, viec gan chu quan do ChuQuan.ThemQuan() lo
    public void Nhap()
    {
        Console.WriteLine("Nhap ma quan: ");
        sMa = Console.ReadLine();
        Console.WriteLine("Nhap ten quan: ");
        sTen = Console.ReadLine();
        Console.WriteLine("Nhap dia chi: ");
        sDiaChi = Console.ReadLine();
        bDangMoCua = true;
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
        Console.WriteLine($"--- Menu cua quan {sTen} ---");
        for (int i = 0; i < menu.Count; i++)
        {
            menu[i].HienThi();
        }
    }

    // ===== QUAN LY VOUCHER CUA QUAN =====
    public void ThemVoucher(Voucher v)
    {
        dsVoucher.Add(v);
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

    public bool CoVoucher()
    {
        for (int i = 0; i < dsVoucher.Count; i++)
        {
            if (dsVoucher[i].ConSuDung)
                return true;
        }
        return false;
    }

    public void HienThiVoucherConDung()
    {
        Console.WriteLine($"Voucher hien co cua quan {sTen}:");
        for (int i = 0; i < dsVoucher.Count; i++)
        {
            if (dsVoucher[i].ConSuDung)
                dsVoucher[i].Xuat();
        }
    }

    public void HienThiVoucherDaDung()
    {
        Console.WriteLine($"Voucher da su dung cua quan {sTen}:");
        for (int i = 0; i < dsVoucher.Count; i++)
        {
            if (!dsVoucher[i].ConSuDung)
                dsVoucher[i].Xuat();
        }
    }

    // quan la class chinh nen Xuat hien thi day du thong tin, gom ca chu quan
    public void Xuat()
    {
        Console.WriteLine($"===== THONG TIN QUAN =====");
        Console.WriteLine($"Ma quan: {sMa}");
        Console.WriteLine($"Ten quan: {sTen}");
        Console.WriteLine($"Dia chi: {sDiaChi}");
        Console.WriteLine($"Dang mo cua: {bDangMoCua}");
        Console.WriteLine($"So mon trong menu: {menu.Count}");
        Console.WriteLine($"So voucher: {dsVoucher.Count}");
        if (chuQuan != null)
        {
            Console.WriteLine($"Chu quan: {chuQuan.Ten} (Ma: {chuQuan.Ma})");
            Console.WriteLine($"Doanh thu cua chu: {chuQuan.TongDoanhThu}d");
        }
    }

    public void NhanDon(DonHang don)
    {
        Console.WriteLine($"[Thong bao quan {sTen}] Nhan duoc don {don.Ma}, bat dau lam mon.");
        don.CapNhatTrangThai(TrangThaiDon.DangLam);
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
    private List<ChiTietDon> dsChiTiet; // dung ChiTietDon thay vi 2 list rieng le
    private double dKhoangCachKm;
    private TrangThaiDon trangThai; // dung enum thay vi string
    private PhuongThucThanhToan thanhToan;
    private double dSoTienDaThanhToan;
    private double dSoTienGiamGia; // luu lai de in hoa don

    public string Ma { get { return sMa; } }
    public TrangThaiDon TrangThai { get { return trangThai; } }

    public DonHang(string ma, KhachHang khach, Quan quan)
    {
        this.sMa = ma;
        this.khach = khach;
        this.quan = quan;
        this.dsChiTiet = new List<ChiTietDon>();
        this.trangThai = TrangThaiDon.ChoXacNhan;
    }

    public void GoiMon(MonAn mon, int soLuong)
    {
        ChiTietDon ct = new ChiTietDon(mon, soLuong);
        dsChiTiet.Add(ct);
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
            {
                GoiMon(mon, soLuong);
            }
            else
            {
                Console.WriteLine($"Khong tim thay mon co ma '{maMon}'. Bo qua.");
            }
        }
        Console.WriteLine("Nhap khoang cach giao (km): ");
        dKhoangCachKm = Convert.ToDouble(Console.ReadLine());
        trangThai = TrangThaiDon.ChoXacNhan;
        Xuat();
    }

    public void CapNhatTrangThai(TrangThaiDon trangThaiMoi)
    {
        trangThai = trangThaiMoi;
    }

    public void Xuat()
    {
        Console.WriteLine($"----- DON HANG {sMa} -----");
        for (int i = 0; i < dsChiTiet.Count; i++)
        {
            dsChiTiet[i].HienThi();
        }
        Console.WriteLine($"Trang thai: {trangThai}");
    }

    public double TongTienMon()
    {
        double tong = 0;
        for (int i = 0; i < dsChiTiet.Count; i++)
        {
            tong = tong + dsChiTiet[i].ThanhTien();
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
        Voucher v = quan.TimVoucher(maVoucher);
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
        this.trangThai = TrangThaiDon.DangGiao;
        Console.WriteLine($"[Thong bao tai xe {tx.Ten}] Ban duoc phan cong giao don {sMa}.");
    }

    // tra ve true neu thanh toan thanh cong, false neu that bai
    public bool ThanhToan(PhuongThucThanhToan ptTT, string maVoucher)
    {
        this.thanhToan = ptTT;
        double giam = TinhGiamGia(maVoucher);
        double tongTien = TongThanhToan(maVoucher);
        this.dSoTienDaThanhToan = tongTien;
        this.dSoTienGiamGia = giam;
        bool thanhCong = thanhToan.XuLyThanhToan(tongTien);
        if (thanhCong)
        {
            // Thanh toan thanh cong nhung don chua hoan thanh giao hang.
            // Don chi duoc chuyen sang HoanThanh sau khi tai xe giao xong.
            this.trangThai = TrangThaiDon.DaThanhToan;

            if (maVoucher != null)
            {
                Voucher v = quan.TimVoucher(maVoucher);
                if (v != null)
                    v.SuDung();
            }

            khach.TinhToanTien(tongTien);
            quan.ChuCuaQuan.TinhToanTien(TongTienMon() - giam);
        }
        else
        {
            Console.WriteLine("Thanh toan that bai! Don hang chua duoc thanh toan.");
        }
        return thanhCong;
    }

    // Hoan tat giao hang sau khi thanh toan va da co tai xe.
    public void HoanThanhDon()
    {
        if (trangThai != TrangThaiDon.DangGiao)
        {
            Console.WriteLine("Don hang chua du dieu kien de hoan thanh.");
            return;
        }

        if (taiXe != null)
        {
            taiXe.TinhToanTien(TinhPhiShip());
            taiXe.HoanThanhGiao();
        }

        trangThai = TrangThaiDon.HoanThanh;
        Console.WriteLine($"Don hang {sMa} da giao thanh cong.");
    }

    public void HuyDon()
    {
        if (trangThai == TrangThaiDon.HoanThanh)
        {
            Console.WriteLine("Khong the huy don da hoan thanh.");
            return;
        }
        trangThai = TrangThaiDon.DaHuy;
        if (taiXe != null)
        {
            taiXe.DangRanh = true;
        }
        Console.WriteLine($"Don hang {sMa} da bi huy.");
    }

    public void InHoaDon()
    {
        Console.WriteLine($"----- HOA DON {sMa} -----");
        for (int i = 0; i < dsChiTiet.Count; i++)
        {
            dsChiTiet[i].HienThi();
        }
        Console.WriteLine($"Tien mon: {TongTienMon()}d");
        if (dSoTienGiamGia > 0)
            Console.WriteLine($"Giam gia voucher: -{dSoTienGiamGia}d");
        Console.WriteLine($"Phi ship: {TinhPhiShip()}d");
        Console.WriteLine($"Tong thanh toan: {dSoTienDaThanhToan}d");
        Console.WriteLine($"Trang thai: {trangThai}");
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
        // kiem tra quan co dang mo cua khong
        if (!quan.DangMoCua)
        {
            Console.WriteLine("Quan hien dang dong cua, khong the dat hang.");
            return null;
        }
        DonHang don = new DonHang(ma, kh, quan);
        dsDonHang.Add(don);
        return don;
    }

    public void BaoCao()
    {
        Console.WriteLine("===== BAO CAO HE THONG =====");
        Console.WriteLine($"Tong so don hang: {dsDonHang.Count}");

        // dem don hoan thanh va don huy
        int soHoanThanh = 0;
        int soHuy = 0;
        for (int i = 0; i < dsDonHang.Count; i++)
        {
            if (dsDonHang[i].TrangThai == TrangThaiDon.HoanThanh)
                soHoanThanh = soHoanThanh + 1;
            if (dsDonHang[i].TrangThai == TrangThaiDon.DaHuy)
                soHuy = soHuy + 1;
        }
        Console.WriteLine($"Don hoan thanh: {soHoanThanh}");
        Console.WriteLine($"Don da huy: {soHuy}");

        Console.WriteLine("--- Thong tin tai xe ---");
        for (int i = 0; i < dsTaiXe.Count; i++)
        {
            dsTaiXe[i].Xuat();
            Console.WriteLine();
        }
    }
}

// ================= CHAY THU =================
class Program
{
    static void NhapMenu(Quan quan)
    {
        Console.WriteLine("Nhap so mon trong menu: ");
        int soMonMenu = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < soMonMenu; i++)
        {
            Console.WriteLine($"\n--- Nhap mon {i + 1} ---");
            MonAn mon = new MonAn();
            mon.Nhap();
            quan.ThemMon(mon);
        }
    }

    static void NhapVoucher(Quan quan)
    {
        Console.WriteLine("Nhap so voucher cua quan: ");
        int soVoucher = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < soVoucher; i++)
        {
            Console.WriteLine($"\n--- Nhap voucher {i + 1} ---");
            Voucher v = new Voucher();
            v.Nhap();
            quan.ThemVoucher(v);
        }
    }

    static PhuongThucThanhToan ChonPhuongThucThanhToan()
    {
        Console.WriteLine("Chon phuong thuc thanh toan:");
        Console.WriteLine("1 - Tien mat");
        Console.WriteLine("2 - Vi dien tu");
        Console.WriteLine("3 - The");
        Console.Write("Lua chon: ");

        string chon = Console.ReadLine();

        switch (chon)
        {
            case "2":
                ViDienTu vi = new ViDienTu();
                vi.Nhap();
                return vi;

            case "3":
                The the = new The();
                the.Nhap();
                return the;

            default:
                return new TienMat();
        }
    }

    static string ChonVoucher(Quan quan)
    {
        if (!quan.CoVoucher())
        {
            Console.WriteLine("Quan nay hien khong co voucher khuyen mai.");
            return null;
        }

        quan.HienThiVoucherConDung();
        Console.WriteLine("Nhap ma voucher muon dung (bo trong neu khong dung): ");
        string maVoucher = Console.ReadLine();

        if (string.IsNullOrEmpty(maVoucher))
            return null;

        return maVoucher;
    }

    static void Main(string[] args)
    {
        UngDung app = new UngDung();

        // ================= 1. KHOI TAO DU LIEU =================
        ChuQuan cq = new ChuQuan();
        cq.Nhap();
        app.ThemChuQuan(cq);

        Quan quan = new Quan();
        quan.Nhap();
        cq.ThemQuan(quan);
        app.ThemQuan(quan);

        NhapMenu(quan);
        NhapVoucher(quan);

        KhachHang kh = new KhachHang();
        kh.Nhap();
        app.ThemKhachHang(kh);

        TaiXe tx = new TaiXe();
        tx.Nhap();
        app.ThemTaiXe(tx);

        // ================= 2. TAO DON HANG =================
        Console.WriteLine("Nhap ma don hang: ");
        string maDon = Console.ReadLine();
        DonHang don = app.TaoDonHang(maDon, kh, quan);

        if (don == null)
        {
            Console.WriteLine("Khong the tao don hang. Ket thuc.");
            Console.ReadLine();
            return;
        }

        don.Nhap();

        // ================= 3. QUAN NHAN DON =================
        Console.WriteLine("\n===== BUOC 1: QUAN NHAN DON =====");
        quan.NhanDon(don);

        // ================= 4. THANH TOAN =================
        // Thanh toan truoc, sau do moi phan cong tai xe.
        Console.WriteLine("\n===== BUOC 2: THANH TOAN =====");
        PhuongThucThanhToan ptTT = ChonPhuongThucThanhToan();
        string maVoucher = ChonVoucher(quan);

        bool thanhCong = don.ThanhToan(ptTT, maVoucher);

        // Neu vi dien tu khong du tien, cho khach chuyen sang tien mat.
        if (!thanhCong)
        {
            Console.WriteLine("Chuyen sang thanh toan bang tien mat.");
            ptTT = new TienMat();
            thanhCong = don.ThanhToan(ptTT, maVoucher);
        }

        if (!thanhCong)
        {
            Console.WriteLine("Khong the thanh toan don hang.");
            Console.ReadLine();
            return;
        }

        // ================= 5. PHAN CONG TAI XE =================
        Console.WriteLine("\n===== BUOC 3: PHAN CONG TAI XE =====");
        app.TimTaiXeRanhVaGanDon(don);

        // ================= 6. GIAO HANG =================
        Console.WriteLine("\n===== BUOC 4: GIAO HANG =====");
        if (don.TrangThai == TrangThaiDon.DangGiao)
            don.HoanThanhDon();
        else
            Console.WriteLine("Don hang chua duoc giao vi chua co tai xe.");

        // ================= 7. HIEN THI KET QUA =================
        Console.WriteLine("\n===== HOA DON =====");
        don.InHoaDon();

        Console.WriteLine();
        quan.Xuat();

        Console.WriteLine();
        quan.HienThiVoucherDaDung();

        Console.WriteLine();
        kh.Xuat();

        Console.WriteLine();
        app.BaoCao();

        Console.ReadLine();
    }
}