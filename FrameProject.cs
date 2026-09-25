using System;
using System.Collections.Generic;

// ----------------------NGUOI DUNG
public abstract class NguoiDung
{
    protected string sMa;
    protected string sTen;
    protected string sSdt;
    protected string sEmail;

    public string Ma { get; set; }
    public string Ten { get; set; }
    public string Sdt { get; set; }
    public string Email { get; set; }

    public NguoiDung();
    public NguoiDung(string ma, string ten, string sdt, string email);

    public virtual void Nhap();
    public virtual void Xuat();
    public abstract void TinhToanTien(double soTien);
}

public class KhachHang : NguoiDung
{
    private string sDiaChiGiao;
    private int iDiemTichLuyITFood;
    private double dTongDaChi;
    private List<Voucher> dsVoucher;

    public string DiaChiGiao { get; set; }
    public int iDiemTichLuyITFood { get; set; }
    public double TongDaChi { get; }

    public KhachHang();
    public KhachHang(string ma, string ten, string sdt, string email, string diaChi);

    public void ThemVoucher(Voucher v);
    public void XoaVoucher(string ma);
    public void HienThiVoucherDaDung();
    public Voucher TimVoucher(string ma);

    public override void Nhap();
    public override void Xuat();
    public override void TinhToanTien(double soTien);
}

public class ChuQuan : NguoiDung
{
    private List<Quan> dsQuan;
    private double dTongDoanhThu;

    public double TongDoanhThu { get; }

    public ChuQuan();
    public ChuQuan(string ma, string ten, string sdt, string email);

    public void ThemQuan(Quan quan);

    public override void Xuat();
    public override void TinhToanTien(double soTien);
}

public class TaiXe : NguoiDung
{
    private string sBienSo;
    private bool bDangRanh;
    private int iSoDonDaGiao;
    private double dTongThuNhap;

    public string BienSo { get; set; }
    public bool DangRanh { get; set; }
    public int SoDonDaGiao { get; set; }
    public double TongThuNhap { get; }

    public TaiXe();
    public TaiXe(string ma, string ten, string sdt, string email, string bienSo);

    public void HoanThanhGiao();

    public override void Nhap();
    public override void Xuat();
    public override void TinhToanTien(double soTien);
}

// -----------------------------MON AN
public class MonAn
{
    protected string sMa;
    protected string sTen;
    protected double dGia;

    public string Ma { get; set; }
    public string Ten { get; set; }
    public double Gia { get; set; }

    public MonAn();
    public MonAn(string ma, string ten, double gia);

    public virtual void Nhap();
    public virtual void HienThi();
}

// ----------------------------Voucher
public class Voucher
{
    private string sMa;
    private double dPhanTram;
    private bool bConSuDung;

    public string Ma { get; set; }
    public double PhanTram { get; set; }
    public bool ConSuDung { get; }

    public Voucher();
    public Voucher(string ma, double phanTram);

    public double TinhGiam(double tienMon);
    public void SuDung();
    public void Nhap();
    public void Xuat();
}

// ------------------------QUAN
public class Quan
{
    private string sMa;
    private string sTen;
    private string sDiaChi;
    private bool bDangMoCua;
    private List<MonAn> menu;
    private ChuQuan chuQuan;

    public string Ma { get; set; }
    public string Ten { get; set; }
    public string DiaChi { get; set; }
    public bool DangMoCua { get; set; }
    public ChuQuan ChuCuaQuan { get; set; }

    public Quan();
    public Quan(string ma, string ten, string diaChi, ChuQuan chuQuan);

    public void Nhap(ChuQuan chuSoHuu);
    public void ThemMon(MonAn mon);
    public MonAn TimMon(string ma);
    public void HienThiMenu();
    public void NhanDon(DonHang don);
}

// -----------------------------PHUONG THUC THANH TOAN
public abstract class PhuongThucThanhToan
{
    public abstract bool XuLyThanhToan(double soTien);
}

public class TienMat : PhuongThucThanhToan
{
    public override bool XuLyThanhToan(double soTien);
}

public class ViDienTu : PhuongThucThanhToan
{
    private double dSoDu;

    public ViDienTu();
    public ViDienTu(double soDu);

    public void Nhap();
    public override bool XuLyThanhToan(double soTien);
}

public class The : PhuongThucThanhToan
{
    private string sSoTheCuoi;
    private double dPhiGiaoDich;

    public The();
    public The(string soTheCuoi, double phiGiaoDich);

    public void Nhap();
    public override bool XuLyThanhToan(double soTien);
}

// ----------------------------------------------DON HANG
public class DonHang
{
    private string sMa;
    private KhachHang khach;
    private Quan quan;
    private TaiXe taiXe;
    private List<MonAn> dsMon;
    private List<int> dsSoLuong;
    private double dKhoangCachKm;
    private string sTrangThai;
    private PhuongThucThanhToan thanhToan;
    private double dSoTienDaThanhToan;

    public string Ma { get; }
    public string TrangThai { get; }

    public DonHang(string ma, KhachHang khach, Quan quan);

    public void GoiMon(MonAn mon, int soLuong);
    public void Nhap();
    public void CapNhatTrangThai(string trangThaiMoi);
    public void Xuat();
    public double TongTienMon();
    public double TinhPhiShip();
    public double TinhGiamGia(string maVoucher);
    public double TongThanhToan(string maVoucher);
    public void GanTaiXe(TaiXe tx);
    public void ThanhToan(PhuongThucThanhToan ptTT, string maVoucher);
    public void InHoaDon();
}

// -----------------------------------------------UNG DUNG (LOP TONG)
public class UngDung
{
    private List<KhachHang> dsKhachHang;
    private List<ChuQuan> dsChuQuan;
    private List<TaiXe> dsTaiXe;
    private List<Quan> dsQuan;
    private List<DonHang> dsDonHang;

    public UngDung();

    public void ThemKhachHang(KhachHang kh);
    public void ThemChuQuan(ChuQuan cq);
    public void ThemTaiXe(TaiXe tx);
    public void ThemQuan(Quan q);
    public TaiXe TimTaiXeRanh();
    public void TimTaiXeRanhVaGanDon(DonHang don);
    public DonHang TaoDonHang(string ma, KhachHang kh, Quan quan);
    public void BaoCao();
}

// ----------------------------------Program
class Program
{
    static void Main(string[] args);
}