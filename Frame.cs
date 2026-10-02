using System;
using System.Collections.Generic;

// ----------------------TRANG THAI DON HANG (ENUM)
public enum TrangThaiDon
{
    ChoXacNhan,
    DangLam,
    DaThanhToan,
    DangGiao,
    HoanThanh,
    DaHuy
}

// -----------------------NGUOI DUNG
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
    }

    public virtual void Nhap()
    {
    }

    public virtual void Xuat()
    {
    }

    public abstract void TinhToanTien(double soTien);
}

// ------------------------KHACH HANG
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
    }

    public override void Nhap()
    {
    }

    public override void Xuat()
    {
    }

    public override void TinhToanTien(double soTien)
    {
    }
}

// ------------------------CHU QUAN
public class ChuQuan : NguoiDung
{
    private List<Quan> dsQuan;
    private double dTongDoanhThu;

    public double TongDoanhThu { get { return dTongDoanhThu; } }

    public ChuQuan()
    {
    }

    public ChuQuan(string ma, string ten, string sdt, string email)
        : base(ma, ten, sdt, email)
    {
    }

    public void ThemQuan(Quan quan)
    {
    }

    public Quan TimQuan(string ma)
    {
        return null;
    }

    public void HienThiDsQuan()
    {
    }

    public override void Xuat()
    {
    }

    public override void TinhToanTien(double soTien)
    {
    }
}

// --------------------------TAI XE
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
    }

    public TaiXe(string ma, string ten, string sdt, string email, string bienSo)
        : base(ma, ten, sdt, email)
    {
    }

    public override void TinhToanTien(double soTien)
    {
    }

    public override void Nhap()
    {
    }

    public override void Xuat()
    {
    }

    public void HoanThanhGiao()
    {
    }
}

// -------------------------MON AN
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
            dGia = value;
        }
    }

    public MonAn() { }

    public MonAn(string ma, string ten, double gia)
    {
    }

    public virtual void Nhap()
    {
    }

    public virtual void HienThi()
    {
    }
}

// -----------------------CHI TIET DON
public class ChiTietDon
{
    private MonAn mon;
    private int iSoLuong;

    public MonAn Mon { get { return mon; } set { mon = value; } }
    public int SoLuong { get { return iSoLuong; } set { iSoLuong = value; } }

    public ChiTietDon() { }

    public ChiTietDon(MonAn mon, int soLuong)
    {
    }

    public double ThanhTien()
    {
        return 0;
    }

    public void HienThi()
    {
    }
}

// ---------------------------VOUCHER
public class Voucher
{
    private string sMa;
    private string sTen;
    private double dPhanTram;
    private bool bConSuDung;

    public string Ma { get { return sMa; } set { sMa = value; } }
    public string Ten { get { return sTen; } set { sTen = value; } }
    public double PhanTram { get { return dPhanTram; } set { dPhanTram = value; } }
    public bool ConSuDung { get { return bConSuDung; } }

    public Voucher() { }

    public Voucher(string ma, string ten, double phanTram)
    {
    }

    public double TinhGiam(double tienMon)
    {
    }

    public void SuDung()
    {
    }

    public void Nhap()
    {
    }

    public void Xuat()
    {
    }
}

// --------------------------QUAN
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
    }

    public Quan(string ma, string ten, string diaChi)
    {
    }

    public void Nhap()
    {
    }

    public void ThemMon(MonAn mon)
    {
    }

    public MonAn TimMon(string ma)
    {
    }

    public void HienThiMenu()
    {
    }

    public void ThemVoucher(Voucher v)
    {
    }

    public Voucher TimVoucher(string ma)
    {
    }

    public bool CoVoucher()
    {
    }

    public void HienThiVoucherConDung()
    {
    }

    public void HienThiVoucherDaDung()
    {
    }

    public void Xuat()
    {
    }

    public void NhanDon(DonHang don)
    {
    }
}

// ------------------------PHUONG THUC THANH TOAN
public abstract class PhuongThucThanhToan
{
    public abstract bool XuLyThanhToan(double soTien);
}

public class TienMat : PhuongThucThanhToan
{
    public override bool XuLyThanhToan(double soTien)
    {
    }
}

public class ViDienTu : PhuongThucThanhToan
{
    private double dSoDu;

    public ViDienTu() { }

    public ViDienTu(double soDu)
    {
    }

    public void Nhap()
    {
    }

    public override bool XuLyThanhToan(double soTien)
    {
    }
}

public class The : PhuongThucThanhToan
{
    private const double PHI_GIAO_DICH_MAC_DINH = 3000;

    private string sSoTheCuoi;
    private double dPhiGiaoDich;

    public The()
    {
    }

    public The(string soTheCuoi)
    {
    }

    public void Nhap()
    {
    }

    public override bool XuLyThanhToan(double soTien)
    {
    }
}

// ---------------------------DON HANG
public class DonHang
{
    private string sMa;
    private KhachHang khach;
    private Quan quan;
    private TaiXe taiXe;
    private List<ChiTietDon> dsChiTiet;
    private double dKhoangCachKm;
    private TrangThaiDon trangThai;
    private PhuongThucThanhToan thanhToan;
    private double dSoTienDaThanhToan;
    private double dSoTienGiamGia;

    public string Ma { get { return sMa; } }
    public TrangThaiDon TrangThai { get { return trangThai; } }

    public DonHang(string ma, KhachHang khach, Quan quan)
    {
    }

    public void GoiMon(MonAn mon, int soLuong)
    {
    }

    public void Nhap()
    {
    }

    public void CapNhatTrangThai(TrangThaiDon trangThaiMoi)
    {
    }

    public void Xuat()
    {
    }

    public double TongTienMon()
    {
    }

    public double TinhPhiShip()
    {
    }

    public double TinhGiamGia(string maVoucher)
    {
    }

    public double TongThanhToan(string maVoucher)
    {
    }

    public void GanTaiXe(TaiXe tx)
    {
    }

    public bool ThanhToan(PhuongThucThanhToan ptTT, string maVoucher)
    {
    }

    public void HoanThanhDon()
    {
    }

    public void HuyDon()
    {
    }

    public void InHoaDon()
    {
    }
}

// ------------------------UNG DUNG (LOP TONG)
public class UngDung
{
    private List<KhachHang> dsKhachHang;
    private List<ChuQuan> dsChuQuan;
    private List<TaiXe> dsTaiXe;
    private List<Quan> dsQuan;
    private List<DonHang> dsDonHang;

    public UngDung()
    {
    }

    public void ThemKhachHang(KhachHang kh)
    {
    }

    public void ThemChuQuan(ChuQuan cq)
    {
    }

    public void ThemTaiXe(TaiXe tx)
    {
    }

    public void ThemQuan(Quan q)
    {
    }

    public TaiXe TimTaiXeRanh()
    {
    }

    public void TimTaiXeRanhVaGanDon(DonHang don)
    {
    }

    public DonHang TaoDonHang(string ma, KhachHang kh, Quan quan)
    {
    }

    public void BaoCao()
    {
    }
}

class Program
{
    static void NhapMenu(Quan quan)
    {
    }

    static void NhapVoucher(Quan quan)
    {
    }

    static PhuongThucThanhToan ChonPhuongThucThanhToan()
    {
    }

    static string ChonVoucher(Quan quan)
    {
    }

    static void Main(string[] args)
    {
    }
}