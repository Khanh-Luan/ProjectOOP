using System;
using System.Collections.Generic;

// ================= TRANG THAI DON HANG (ENUM) =================
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
        // TODO: gan cac tham so vao thuoc tinh
    }

    public virtual void Nhap()
    {
        // TODO: nhap ma, ten, sdt, email tu ban phim
    }

    public virtual void Xuat()
    {
        // TODO: in ra ma, ten, sdt, email
    }

    public abstract void TinhToanTien(double soTien);
}

// ================= KHACH HANG =================
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
        // TODO: gan dia chi giao, khoi tao diem = 0, tong da chi = 0
    }

    public override void Nhap()
    {
        // TODO: goi base.Nhap() roi nhap them dia chi giao
    }

    public override void Xuat()
    {
        // TODO: goi base.Xuat() roi in them dia chi, diem tich luy, tong da chi
    }

    public override void TinhToanTien(double soTien)
    {
        // TODO: cong don tong da chi, tinh diem tich luy (soTien / 10000)
    }
}

// ================= CHU QUAN =================
public class ChuQuan : NguoiDung
{
    private List<Quan> dsQuan;
    private double dTongDoanhThu;

    public double TongDoanhThu { get { return dTongDoanhThu; } }

    public ChuQuan()
    {
        // TODO: khoi tao dsQuan
    }

    public ChuQuan(string ma, string ten, string sdt, string email)
        : base(ma, ten, sdt, email)
    {
        // TODO: khoi tao dsQuan, dTongDoanhThu = 0
    }

    public void ThemQuan(Quan quan)
    {
        // TODO: them quan vao dsQuan, gan quan.ChuCuaQuan = this
    }

    public Quan TimQuan(string ma)
    {
        // TODO: duyet dsQuan tim theo ma, return null neu khong thay
        return null;
    }

    public void HienThiDsQuan()
    {
        // TODO: in danh sach quan (ma, ten, dia chi)
    }

    public override void Xuat()
    {
        // TODO: goi base.Xuat() roi in so quan so huu, tong doanh thu
    }

    public override void TinhToanTien(double soTien)
    {
        // TODO: cong don doanh thu
    }
}

// ================= TAI XE =================
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
        // TODO: khoi tao bDangRanh = true
    }

    public TaiXe(string ma, string ten, string sdt, string email, string bienSo)
        : base(ma, ten, sdt, email)
    {
        // TODO: gan bien so, bDangRanh = true, so don = 0, thu nhap = 0
    }

    public override void TinhToanTien(double soTien)
    {
        // TODO: cong don thu nhap
    }

    public override void Nhap()
    {
        // TODO: goi base.Nhap() roi nhap them bien so xe
    }

    public override void Xuat()
    {
        // TODO: goi base.Xuat() roi in bien so, trang thai ranh, so don, thu nhap
    }

    public void HoanThanhGiao()
    {
        // TODO: tang so don da giao, dat bDangRanh = true
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
            // TODO: kiem tra value > 0, nem exception neu khong hop le
            dGia = value;
        }
    }

    public MonAn() { }

    public MonAn(string ma, string ten, double gia)
    {
        // TODO: gan ma, ten, gia (dung property Gia de validate)
    }

    public virtual void Nhap()
    {
        // TODO: nhap ma, ten, gia tu ban phim
    }

    public virtual void HienThi()
    {
        // TODO: in ra ma - ten - gia
    }
}

// ================= CHI TIET DON =================
public class ChiTietDon
{
    private MonAn mon;
    private int iSoLuong;

    public MonAn Mon { get { return mon; } set { mon = value; } }
    public int SoLuong { get { return iSoLuong; } set { iSoLuong = value; } }

    public ChiTietDon() { }

    public ChiTietDon(MonAn mon, int soLuong)
    {
        // TODO: gan mon va so luong
    }

    public double ThanhTien()
    {
        // TODO: return gia mon * so luong
        return 0;
    }

    public void HienThi()
    {
        // TODO: in ten mon x so luong = thanh tien
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
    public double PhanTram { get { return dPhanTram; } set { dPhanTram = value; } }
    public bool ConSuDung { get { return bConSuDung; } }

    public Voucher() { }

    public Voucher(string ma, string ten, double phanTram)
    {
        // TODO: gan ma, ten, phan tram, bConSuDung = true
    }

    public double TinhGiam(double tienMon)
    {
        // TODO: neu con su dung thi return tienMon * phanTram / 100, nguoc lai return 0
        return 0;
    }

    public void SuDung()
    {
        // TODO: dat bConSuDung = false
    }

    public void Nhap()
    {
        // TODO: nhap ma, ten, phan tram tu ban phim, bConSuDung = true
    }

    public void Xuat()
    {
        // TODO: in ma, ten, phan tram, trang thai con su dung
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
        // TODO: khoi tao menu, dsVoucher, bDangMoCua = true
    }

    public Quan(string ma, string ten, string diaChi)
    {
        // TODO: gan ma, ten, diaChi, bDangMoCua = true, khoi tao menu va dsVoucher
    }

    public void Nhap()
    {
        // TODO: nhap ma, ten, dia chi, dat bDangMoCua = true
    }

    public void ThemMon(MonAn mon)
    {
        // TODO: them mon vao menu
    }

    public MonAn TimMon(string ma)
    {
        // TODO: duyet menu tim theo ma, return null neu khong thay
        return null;
    }

    public void HienThiMenu()
    {
        // TODO: in tieu de menu cua quan roi duyet in tung mon
    }

    public void ThemVoucher(Voucher v)
    {
        // TODO: them voucher vao dsVoucher
    }

    public Voucher TimVoucher(string ma)
    {
        // TODO: duyet dsVoucher tim theo ma, return null neu khong thay
        return null;
    }

    public bool CoVoucher()
    {
        // TODO: duyet dsVoucher, return true neu co bat ky voucher nao con su dung
        return false;
    }

    public void HienThiVoucherConDung()
    {
        // TODO: in cac voucher con su dung
    }

    public void HienThiVoucherDaDung()
    {
        // TODO: in cac voucher da su dung
    }

    public void Xuat()
    {
        // TODO: in day du thong tin quan (ma, ten, dia chi, trang thai, so mon, so voucher, chu quan)
    }

    public void NhanDon(DonHang don)
    {
        // TODO: in thong bao nhan don, cap nhat trang thai don sang DangLam
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
        // TODO: in thong bao thanh toan tien mat, return true
        return false;
    }
}

public class ViDienTu : PhuongThucThanhToan
{
    private double dSoDu;

    public ViDienTu() { }

    public ViDienTu(double soDu)
    {
        // TODO: gan so du
    }

    public void Nhap()
    {
        // TODO: nhap so du vi tu ban phim
    }

    public override bool XuLyThanhToan(double soTien)
    {
        // TODO: kiem tra so du >= soTien, tru tien, return true/false
        return false;
    }
}

public class The : PhuongThucThanhToan
{
    private const double PHI_GIAO_DICH_MAC_DINH = 3000;

    private string sSoTheCuoi;
    private double dPhiGiaoDich;

    public The()
    {
        // TODO: gan phi giao dich mac dinh
    }

    public The(string soTheCuoi)
    {
        // TODO: gan so the cuoi, phi giao dich mac dinh
    }

    public void Nhap()
    {
        // TODO: nhap 4 so cuoi the tu ban phim
    }

    public override bool XuLyThanhToan(double soTien)
    {
        // TODO: tinh tong = soTien + phi, in thong bao, return true
        return false;
    }
}

// ================= DON HANG =================
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
        // TODO: gan ma, khach, quan, khoi tao dsChiTiet, trangThai = ChoXacNhan
    }

    public void GoiMon(MonAn mon, int soLuong)
    {
        // TODO: tao ChiTietDon moi va them vao dsChiTiet
    }

    public void Nhap()
    {
        // TODO: hien thi menu quan, cho khach chon mon + so luong, nhap khoang cach, in don
    }

    public void CapNhatTrangThai(TrangThaiDon trangThaiMoi)
    {
        // TODO: gan trang thai moi
    }

    public void Xuat()
    {
        // TODO: in ma don, danh sach chi tiet don, trang thai
    }

    public double TongTienMon()
    {
        // TODO: cong thanh tien cua tat ca chi tiet don
        return 0;
    }

    public double TinhPhiShip()
    {
        // TODO: <= 3km: 15000, <= 7km: 25000, > 7km: 40000
        return 0;
    }

    public double TinhGiamGia(string maVoucher)
    {
        // TODO: tim voucher trong quan, tinh tien giam, return 0 neu khong co
        return 0;
    }

    public double TongThanhToan(string maVoucher)
    {
        // TODO: return TongTienMon - TinhGiamGia + TinhPhiShip
        return 0;
    }

    public void GanTaiXe(TaiXe tx)
    {
        // TODO: gan tai xe, dat tai xe khong ranh, trang thai = DangGiao, in thong bao
    }

    public bool ThanhToan(PhuongThucThanhToan ptTT, string maVoucher)
    {
        // TODO: xu ly thanh toan, neu thanh cong thi:
        //   - cap nhat trang thai = DaThanhToan
        //   - su dung voucher (neu co)
        //   - tinh toan tien cho khach hang va chu quan
        // return true/false
        return false;
    }

    public void HoanThanhDon()
    {
        // TODO: kiem tra trang thai DangGiao, tinh tien cho tai xe, hoan thanh giao, trang thai = HoanThanh
    }

    public void HuyDon()
    {
        // TODO: kiem tra khong the huy don da hoan thanh
        //   - trang thai = DaHuy
        //   - tra tai xe ve trang thai ranh (neu co)
    }

    public void InHoaDon()
    {
        // TODO: in chi tiet don, tien mon, giam gia, phi ship, tong thanh toan, trang thai
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
        // TODO: khoi tao tat ca cac list
    }

    public void ThemKhachHang(KhachHang kh)
    {
        // TODO: them vao dsKhachHang
    }

    public void ThemChuQuan(ChuQuan cq)
    {
        // TODO: them vao dsChuQuan
    }

    public void ThemTaiXe(TaiXe tx)
    {
        // TODO: them vao dsTaiXe
    }

    public void ThemQuan(Quan q)
    {
        // TODO: them vao dsQuan
    }

    public TaiXe TimTaiXeRanh()
    {
        // TODO: duyet dsTaiXe, return tai xe dau tien dang ranh, null neu khong co
        return null;
    }

    public void TimTaiXeRanhVaGanDon(DonHang don)
    {
        // TODO: tim tai xe ranh, neu co thi gan vao don, neu khong in thong bao
    }

    public DonHang TaoDonHang(string ma, KhachHang kh, Quan quan)
    {
        // TODO: kiem tra quan dang mo cua, tao don moi, them vao dsDonHang, return don
        return null;
    }

    public void BaoCao()
    {
        // TODO: in tong so don, dem don hoan thanh/da huy, in thong tin tai xe
    }
}

// ================= CHAY THU =================
class Program
{
    static void NhapMenu(Quan quan)
    {
        // TODO: nhap so mon, vong lap nhap tung mon roi them vao quan
    }

    static void NhapVoucher(Quan quan)
    {
        // TODO: nhap so voucher, vong lap nhap tung voucher roi them vao quan
    }

    static PhuongThucThanhToan ChonPhuongThucThanhToan()
    {
        // TODO: hien menu chon (1-TienMat, 2-ViDienTu, 3-The), return phuong thuc tuong ung
        return null;
    }

    static string ChonVoucher(Quan quan)
    {
        // TODO: kiem tra quan co voucher khong, hien thi danh sach, cho nhap ma voucher
        return null;
    }

    static void Main(string[] args)
    {
        // TODO: 1. KHOI TAO DU LIEU
        //   - Tao UngDung
        //   - Nhap chu quan, quan, menu, voucher
        //   - Nhap khach hang, tai xe

        // TODO: 2. TAO DON HANG
        //   - Nhap ma don, tao don, cho khach nhap mon

        // TODO: 3. QUAN NHAN DON

        // TODO: 4. HUY DON (NEU MUON)
        //   - Hoi khach co muon huy khong, neu co thi huy va ket thuc

        // TODO: 5. THANH TOAN
        //   - Chon phuong thuc thanh toan, chon voucher
        //   - Neu vi dien tu that bai thi chuyen sang tien mat

        // TODO: 6. PHAN CONG TAI XE

        // TODO: 7. GIAO HANG
        //   - Neu dang giao thi hoan thanh don

        // TODO: 8. HIEN THI KET QUA
        //   - In hoa don, thong tin quan, voucher da dung, thong tin khach, bao cao
    }
}