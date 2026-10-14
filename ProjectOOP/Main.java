package ProjectOOP;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
// dung enum thay cho string de gioi han cac gia tri hop le, tranh go sai
enum TrangThaiDon {
    ChoXacNhan,
    DangLam,
    DaThanhToan,
    DangGiao,
    HoanThanh,
    DaHuy
}
//nguoi dung
abstract class NguoiDung 
{
    //fields
    protected String sMa;
    protected String sTen;
    protected String sSdt;
    protected String sEmail;
    //properties
    public String getMa() 
    {
        return sMa;
    }
    public void setMa(String ma) 
    {
        this.sMa = ma;
    }
    public String getTen() 
    {
        return sTen;
    }
    public void setTen(String ten) 
    {
        this.sTen = ten;
    }
    public String getSdt() 
    {
        return sSdt;
    }
    public void setSdt(String sdt) 
    {
        this.sSdt = sdt;
    }
    public String getEmail() 
    {
        return sEmail;
    }
    public void setEmail(String email) 
    {
        this.sEmail = email;
    }
    //constructor
    public NguoiDung() { }
    public NguoiDung(String ma, String ten, String sdt, String email) 
    {
        this.sMa = ma;
        this.sTen = ten;
        this.sSdt = sdt;
        this.sEmail = email;
    }
    //ham nhap
    public void Nhap() {
        System.out.println("Nhap ma: ");
        sMa = Main.scanner.nextLine();
        System.out.println("Nhap ten: ");
        sTen = Main.scanner.nextLine();
        System.out.println("Nhap sdt: ");
        sSdt = Main.scanner.nextLine();
        System.out.println("Nhap email: ");
        sEmail = Main.scanner.nextLine();
    }

    public void Xuat() {
        System.out.println("Ma: " + sMa);
        System.out.println("Ten: " + sTen);
        System.out.println("Sdt: " + sSdt);
        System.out.println("Email: " + sEmail);
    }

    // moi loai nguoi dung tinh tien theo cach rieng cua minh
    public abstract void TinhToanTien(double soTien);
}

class KhachHang extends NguoiDung {
    private String sDiaChiGiao;
    private int iDiemTichLuyITFood;
    private double dTongDaChi;

    public String getDiaChiGiao() { return sDiaChiGiao; }
    public void setDiaChiGiao(String diaChiGiao) { this.sDiaChiGiao = diaChiGiao; }

    public int getDiemTichLuyITFood() { return iDiemTichLuyITFood; }
    public void setDiemTichLuyITFood(int diemTichLuyITFood) { this.iDiemTichLuyITFood = diemTichLuyITFood; }

    public double getTongDaChi() { return dTongDaChi; }

    public KhachHang() { }

    public KhachHang(String ma, String ten, String sdt, String email, String diaChi) {
        super(ma, ten, sdt, email);
        this.sDiaChiGiao = diaChi;
        this.iDiemTichLuyITFood = 0;
        this.dTongDaChi = 0;
    }

    @Override
    public void Nhap() {
        super.Nhap();
        System.out.println("Khach hang!!!");
        System.out.println("Nhap dia chi giao: ");
        sDiaChiGiao = Main.scanner.nextLine();
    }

    @Override
    public void Xuat() {
        super.Xuat();
        System.out.println("Dia chi giao: " + sDiaChiGiao);
        System.out.println("Diem tich luy: " + iDiemTichLuyITFood);
        System.out.println("Tong da chi: " + dTongDaChi + "d");
    }

    // ham tinh toan so tien: cong don da chi va diem tich luy
    @Override
    public void TinhToanTien(double soTien) {
        dTongDaChi = dTongDaChi + soTien;
        iDiemTichLuyITFood = iDiemTichLuyITFood + (int)(soTien / 10000);
    }
}

class ChuQuan extends NguoiDung {
    private List<Quan> dsQuan;
    private double dTongDoanhThu;

    public double getTongDoanhThu() { return dTongDoanhThu; }

    public ChuQuan() {
        dsQuan = new ArrayList<>();
    }

    public ChuQuan(String ma, String ten, String sdt, String email) {
        super(ma, ten, sdt, email);
        dsQuan = new ArrayList<>();
        dTongDoanhThu = 0;
    }

    public void ThemQuan(Quan quan) {
        dsQuan.add(quan);
        quan.setChuCuaQuan(this);
    }

    public Quan TimQuan(String ma) {
        for (int i = 0; i < dsQuan.size(); i++) {
            if (dsQuan.get(i).getMa().equals(ma))
                return dsQuan.get(i);
        }
        return null;
    }

    public void HienThiDsQuan() {
        System.out.println("Danh sach quan cua " + sTen + ":");
        for (int i = 0; i < dsQuan.size(); i++) {
            System.out.println("  " + dsQuan.get(i).getMa() + " - " + dsQuan.get(i).getTen() + " - " + dsQuan.get(i).getDiaChi());
        }
    }

    @Override
    public void Xuat() {
        super.Xuat();
        System.out.println("So quan so huu: " + dsQuan.size());
        System.out.println("Tong doanh thu: " + dTongDoanhThu + "d");
    }

    // ham tinh toan so tien: cong doanh thu tu don hang cua quan minh
    @Override
    public void TinhToanTien(double soTien) {
        dTongDoanhThu = dTongDoanhThu + soTien;
    }
}

class TaiXe extends NguoiDung {
    private String sBienSo;
    private boolean bDangRanh;
    private int iSoDonDaGiao;
    private double dTongThuNhap;

    public String getBienSo() { return sBienSo; }
    public void setBienSo(String bienSo) { this.sBienSo = bienSo; }

    public boolean isDangRanh() { return bDangRanh; }
    public void setDangRanh(boolean dangRanh) { this.bDangRanh = dangRanh; }

    public int getSoDonDaGiao() { return iSoDonDaGiao; }
    public void setSoDonDaGiao(int soDonDaGiao) { this.iSoDonDaGiao = soDonDaGiao; }

    public double getTongThuNhap() { return dTongThuNhap; }

    public TaiXe() {
        this.bDangRanh = true;
    }

    public TaiXe(String ma, String ten, String sdt, String email, String bienSo) {
        super(ma, ten, sdt, email);
        this.sBienSo = bienSo;
        this.bDangRanh = true;
        this.iSoDonDaGiao = 0;
        this.dTongThuNhap = 0;
    }

    // ham tinh toan so tien: tai xe nhan het phi ship cua don da giao
    @Override
    public void TinhToanTien(double soTien) {
        dTongThuNhap = dTongThuNhap + soTien;
    }

    @Override
    public void Nhap() {
        super.Nhap();

        System.out.println("Tai Xe!!!");
        System.out.println("Nhap bien so xe: ");
        sBienSo = Main.scanner.nextLine();
    }

    @Override
    public void Xuat() {
        super.Xuat();
        System.out.println("Bien so xe: " + sBienSo);
        System.out.println("Dang ranh: " + bDangRanh);
        System.out.println("So don da giao: " + iSoDonDaGiao);
        System.out.println("Tong thu nhap: " + dTongThuNhap + "d");
    }

    public void HoanThanhGiao() {
        iSoDonDaGiao = iSoDonDaGiao + 1;
        bDangRanh = true;
    }
}

// ================= MON AN =================
class MonAn {
    protected String sMa;
    protected String sTen;
    protected double dGia;

    public String getMa() { return sMa; }
    public void setMa(String ma) { this.sMa = ma; }

    public String getTen() { return sTen; }
    public void setTen(String ten) { this.sTen = ten; }

    public double getGia() { return dGia; }
    public void setGia(double value) {
        if (value <= 0)
            throw new IllegalArgumentException("Gia phai > 0");
        dGia = value;
    }

    public MonAn() { }

    public MonAn(String ma, String ten, double gia) {
        this.sMa = ma;
        this.sTen = ten;
        setGia(gia);
    }

    public void Nhap() {
        System.out.println("Nhap ma mon: ");
        sMa = Main.scanner.nextLine();
        System.out.println("Nhap ten mon: ");
        sTen = Main.scanner.nextLine();
        System.out.println("Nhap gia: ");
        setGia(Double.parseDouble(Main.scanner.nextLine()));
    }

    public void HienThi() {
        System.out.println(sMa + " - " + sTen + " - " + dGia + "d");
    }
}

// ================= CHI TIET DON =================
// gop MonAn + SoLuong vao 1 class thay vi 2 list rieng le, de quan ly hon
class ChiTietDon {
    private MonAn mon;
    private int iSoLuong;

    public MonAn getMon() { return mon; }
    public void setMon(MonAn mon) { this.mon = mon; }

    public int getSoLuong() { return iSoLuong; }
    public void setSoLuong(int soLuong) { this.iSoLuong = soLuong; }

    public ChiTietDon() { }

    public ChiTietDon(MonAn mon, int soLuong) {
        this.mon = mon;
        this.iSoLuong = soLuong;
    }

    public double ThanhTien() {
        return mon.getGia() * iSoLuong;
    }

    public void HienThi() {
        System.out.println(mon.getTen() + " x" + iSoLuong + " = " + ThanhTien() + "d");
    }
}

// ================= VOUCHER =================
class Voucher {
    private String sMa;
    private String sTen;
    private double dPhanTram;
    private boolean bConSuDung;

    public String getMa() { return sMa; }
    public void setMa(String ma) { this.sMa = ma; }

    public String getTen() { return sTen; }
    public void setTen(String ten) { this.sTen = ten; }

    public double getPhanTram() { return dPhanTram; }
    public void setPhanTram(double phanTram) { this.dPhanTram = phanTram; } // Sửa lại set giới hạn từ 0-100

    public boolean isConSuDung() { return bConSuDung; }

    public Voucher() { }

    public Voucher(String ma, String ten, double phanTram) {
        this.sMa = ma;
        this.sTen = ten;
        this.dPhanTram = phanTram;
        this.bConSuDung = true;
    }

    public double TinhGiam(double tienMon) {
        if (!bConSuDung)
            return 0;
        return tienMon * dPhanTram / 100;
    }

    public void SuDung() {
        bConSuDung = false;
    }

    public void Nhap() {
        System.out.println("Nhap ma voucher: ");
        sMa = Main.scanner.nextLine();
        System.out.println("Nhap ten voucher: ");
        sTen = Main.scanner.nextLine();
        System.out.println("Nhap phan tram giam: ");
        dPhanTram = Double.parseDouble(Main.scanner.nextLine());
        bConSuDung = true;
    }

    public void Xuat() {
        System.out.println(sMa + " - " + sTen + " - Giam " + dPhanTram + "% - Con su dung: " + bConSuDung);
    }
}

// ================= QUAN =================
class Quan {
    private String sMa;
    private String sTen;
    private String sDiaChi;
    private boolean bDangMoCua;
    private List<MonAn> menu;
    private List<Voucher> dsVoucher;
    private ChuQuan chuQuan;

    public String getMa() { return sMa; }
    public void setMa(String ma) { this.sMa = ma; }

    public String getTen() { return sTen; }
    public void setTen(String ten) { this.sTen = ten; }

    public String getDiaChi() { return sDiaChi; }
    public void setDiaChi(String diaChi) { this.sDiaChi = diaChi; }

    public boolean isDangMoCua() { return bDangMoCua; }
    public void setDangMoCua(boolean dangMoCua) { this.bDangMoCua = dangMoCua; }

    public ChuQuan getChuCuaQuan() { return chuQuan; }
    public void setChuCuaQuan(ChuQuan chuQuan) { this.chuQuan = chuQuan; }

    public Quan() {
        this.menu = new ArrayList<>();
        this.dsVoucher = new ArrayList<>();
        this.bDangMoCua = true;
    }

    public Quan(String ma, String ten, String diaChi) {
        this.sMa = ma;
        this.sTen = ten;
        this.sDiaChi = diaChi;
        this.bDangMoCua = true;
        this.menu = new ArrayList<>();
        this.dsVoucher = new ArrayList<>();
    }

    // chi nhap thong tin cua quan, viec gan chu quan do ChuQuan.ThemQuan() lo
    public void Nhap() {
        System.out.println("Nhap ma quan: ");
        sMa = Main.scanner.nextLine();
        System.out.println("Nhap ten quan: ");
        sTen = Main.scanner.nextLine();
        System.out.println("Nhap dia chi: ");
        sDiaChi = Main.scanner.nextLine();
        bDangMoCua = true;
    }

    public void ThemMon(MonAn mon) {
        menu.add(mon);
    }

    public MonAn TimMon(String ma) {
        for (int i = 0; i < menu.size(); i++) {
            if (menu.get(i).getMa().equals(ma))
                return menu.get(i);
        }
        return null;
    }

    public void HienThiMenu() {
        System.out.println("--- Menu cua quan " + sTen + " ---");
        for (int i = 0; i < menu.size(); i++) {
            menu.get(i).HienThi();
        }
    }

    // ===== QUAN LY VOUCHER CUA QUAN =====
    public void ThemVoucher(Voucher v) {
        dsVoucher.add(v);
    }

    public Voucher TimVoucher(String ma) {
        for (int i = 0; i < dsVoucher.size(); i++) {
            if (dsVoucher.get(i).getMa().equals(ma))
                return dsVoucher.get(i);
        }
        return null;
    }

    public boolean CoVoucher() {
        for (int i = 0; i < dsVoucher.size(); i++) {
            if (dsVoucher.get(i).isConSuDung())
                return true;
        }
        return false;
    }

    public void HienThiVoucherConDung() {
        System.out.println("Voucher hien co cua quan " + sTen + ":");
        for (int i = 0; i < dsVoucher.size(); i++) {
            if (dsVoucher.get(i).isConSuDung())
                dsVoucher.get(i).Xuat();
        }
    }

    public void HienThiVoucherDaDung() {
        System.out.println("Voucher da su dung cua quan " + sTen + ":");
        for (int i = 0; i < dsVoucher.size(); i++) {
            if (!dsVoucher.get(i).isConSuDung())
                dsVoucher.get(i).Xuat();
        }
    }

    // quan la class chinh nen Xuat hien thi day du thong tin, gom ca chu quan
    public void Xuat() {
        System.out.println("===== THONG TIN QUAN =====");
        System.out.println("Ma quan: " + sMa);
        System.out.println("Ten quan: " + sTen);
        System.out.println("Dia chi: " + sDiaChi);
        System.out.println("Dang mo cua: " + bDangMoCua);
        System.out.println("So mon trong menu: " + menu.size());
        System.out.println("So voucher: " + dsVoucher.size());
        if (chuQuan != null) {
            System.out.println("Chu quan: " + chuQuan.getTen() + " (Ma: " + chuQuan.getMa() + ")");
            System.out.println("Doanh thu cua chu: " + chuQuan.getTongDoanhThu() + "d");
        }
    }

    public void NhanDon(DonHang don) {
        System.out.println("[Thong bao quan " + sTen + "] Nhan duoc don " + don.getMa() + ", bat dau lam mon.");
        don.CapNhatTrangThai(TrangThaiDon.DangLam);
    }
}

// ================= PHUONG THUC THANH TOAN =================
abstract class PhuongThucThanhToan {
    public abstract boolean XuLyThanhToan(double soTien);
}

class TienMat extends PhuongThucThanhToan {
    @Override
    public boolean XuLyThanhToan(double soTien) {
        System.out.println("Thanh toan " + soTien + "d bang tien mat khi nhan hang.");
        return true;
    }
}

class ViDienTu extends PhuongThucThanhToan {
    private double dSoDu;

    public ViDienTu() { }

    public ViDienTu(double soDu) {
        this.dSoDu = soDu;
    }

    public void Nhap() {
        System.out.println("Nhap so du vi: ");
        dSoDu = Double.parseDouble(Main.scanner.nextLine());
    }

    @Override
    public boolean XuLyThanhToan(double soTien) {
        if (dSoDu < soTien) {
            System.out.println("So du vi dien tu khong du.");
            return false;
        }
        dSoDu = dSoDu - soTien;
        System.out.println("Da thanh toan " + soTien + "d bang vi dien tu. Con lai: " + dSoDu + "d");
        return true;
    }
}

class The extends PhuongThucThanhToan {
    private static final double PHI_GIAO_DICH_MAC_DINH = 3000; // he thong tu dat theo thuc te

    private String sSoTheCuoi;
    private double dPhiGiaoDich;

    public The() {
        dPhiGiaoDich = PHI_GIAO_DICH_MAC_DINH;
    }

    public The(String soTheCuoi) {
        this.sSoTheCuoi = soTheCuoi;
        this.dPhiGiaoDich = PHI_GIAO_DICH_MAC_DINH;
    }

    public void Nhap() {
        System.out.println("Nhap 4 so cuoi the: ");
        sSoTheCuoi = Main.scanner.nextLine();
        dPhiGiaoDich = PHI_GIAO_DICH_MAC_DINH;
    }

    @Override
    public boolean XuLyThanhToan(double soTien) {
        double tongTien = soTien + dPhiGiaoDich;
        System.out.println("Da thanh toan " + tongTien + "d bang the ***" + sSoTheCuoi + " (gom phi " + dPhiGiaoDich + "d)");
        return true;
    }
}

// ================= DON HANG =================
class DonHang {
    private String sMa;
    private KhachHang khach;
    private Quan quan;
    private TaiXe taiXe;
    private List<ChiTietDon> dsChiTiet; // dung ChiTietDon thay vi 2 list rieng le
    private double dKhoangCachKm;
    private TrangThaiDon trangThai; // dung enum thay vi string
    private PhuongThucThanhToan thanhToan;
    private double dSoTienDaThanhToan;
    private double dSoTienGiamGia; // luu lai de in hoa don

    public String getMa() { return sMa; }
    public TrangThaiDon getTrangThai() { return trangThai; }

    public DonHang(String ma, KhachHang khach, Quan quan) {
        this.sMa = ma;
        this.khach = khach;
        this.quan = quan;
        this.dsChiTiet = new ArrayList<>();
        this.trangThai = TrangThaiDon.ChoXacNhan;
    }

    public void GoiMon(MonAn mon, int soLuong) {
        ChiTietDon ct = new ChiTietDon(mon, soLuong);
        dsChiTiet.add(ct);
    }

    // khach nhap thong tin dat hang: chon mon trong menu cua quan, nhap khoang cach giao
    public void Nhap() {
        quan.HienThiMenu();
        System.out.println("Nhap so mon muon dat: ");
        int soMon = Integer.parseInt(Main.scanner.nextLine());
        for (int i = 0; i < soMon; i++) {
            System.out.println("Nhap ma mon: ");
            String maMon = Main.scanner.nextLine();
            System.out.println("Nhap so luong: ");
            int soLuong = Integer.parseInt(Main.scanner.nextLine());
            MonAn mon = quan.TimMon(maMon);
            if (mon != null) {
                GoiMon(mon, soLuong);
            } else {
                System.out.println("Khong tim thay mon co ma '" + maMon + "'. Bo qua.");
            }
        }
        System.out.println("Nhap khoang cach giao (km): ");
        dKhoangCachKm = Double.parseDouble(Main.scanner.nextLine());
        trangThai = TrangThaiDon.ChoXacNhan;
        Xuat();
    }

    public void CapNhatTrangThai(TrangThaiDon trangThaiMoi) {
        trangThai = trangThaiMoi;
    }

    public void Xuat() {
        System.out.println("----- DON HANG " + sMa + " -----");
        for (int i = 0; i < dsChiTiet.size(); i++) {
            dsChiTiet.get(i).HienThi();
        }
        System.out.println("Trang thai: " + trangThai);
    }

    public double TongTienMon() {
        double tong = 0;
        for (int i = 0; i < dsChiTiet.size(); i++) {
            tong = tong + dsChiTiet.get(i).ThanhTien();
        }
        return tong;
    }

    public double TinhPhiShip() {
        if (dKhoangCachKm <= 3)
            return 15000;
        if (dKhoangCachKm <= 7)
            return 25000;
        return 40000;
    }

    public double TinhGiamGia(String maVoucher) {
        if (maVoucher == null)
            return 0;
        Voucher v = quan.TimVoucher(maVoucher);
        if (v == null)
            return 0;
        return v.TinhGiam(TongTienMon());
    }

    public double TongThanhToan(String maVoucher) {
        return TongTienMon() - TinhGiamGia(maVoucher) + TinhPhiShip();
    }

    public void GanTaiXe(TaiXe tx) {
        this.taiXe = tx;
        tx.setDangRanh(false);
        this.trangThai = TrangThaiDon.DangGiao;
        System.out.println("[Thong bao tai xe " + tx.getTen() + "] Ban duoc phan cong giao don " + sMa + ".");
    }

    // tra ve true neu thanh toan thanh cong, false neu that bai
    public boolean ThanhToan(PhuongThucThanhToan ptTT, String maVoucher) {
        this.thanhToan = ptTT;
        double giam = TinhGiamGia(maVoucher);
        double tongTien = TongThanhToan(maVoucher);
        this.dSoTienDaThanhToan = tongTien;
        this.dSoTienGiamGia = giam;
        boolean thanhCong = thanhToan.XuLyThanhToan(tongTien);
        if (thanhCong) {
            // Thanh toan thanh cong nhung don chua hoan thanh giao hang.
            // Don chi duoc chuyen sang HoanThanh sau khi tai xe giao xong.
            this.trangThai = TrangThaiDon.DaThanhToan;

            if (maVoucher != null) {
                Voucher v = quan.TimVoucher(maVoucher);
                if (v != null)
                    v.SuDung();
            }

            khach.TinhToanTien(tongTien);
            quan.getChuCuaQuan().TinhToanTien(TongTienMon() - giam);
        } else {
            System.out.println("Thanh toan that bai! Don hang chua duoc thanh toan.");
        }
        return thanhCong;
    }

    // Hoan tat giao hang sau khi thanh toan va da co tai xe.
    public void HoanThanhDon() 
    {
    if (this.trangThai != TrangThaiDon.DangGiao) {
        System.out.println("Don hang chua du dieu kien de hoan thanh.");
        return;
    }
    
    if (this.taiXe != null) {
        double tienCuaTaiXe = TinhPhiShip() * (1 - Chiet_khau_cua_tai_xe);
        this.taiXe.TinhToanTien(tienCuaTaiXe);
        this.taiXe.HoanThanhGiao();
    }

    this.trangThai = TrangThaiDon.HoanThanh;
    System.out.println("Don hang " + this.sMa + " da giao thanh cong.");
    }
    public void HuyDon() {
        if (trangThai == TrangThaiDon.HoanThanh) {
            System.out.println("Khong the huy don da hoan thanh.");
            return;
        }
        trangThai = TrangThaiDon.DaHuy;
        if (taiXe != null) {
            taiXe.setDangRanh(true);
        }
        System.out.println("Don hang " + sMa + " da bi huy.");
    }

    public void InHoaDon() {
        System.out.println("----- HOA DON " + sMa + " -----");
        for (int i = 0; i < dsChiTiet.size(); i++) {
            dsChiTiet.get(i).HienThi();
        }
        System.out.println("Tien mon: " + TongTienMon() + "d");
        if (dSoTienGiamGia > 0)
            System.out.println("Giam gia voucher: -" + dSoTienGiamGia + "d");
        System.out.println("Phi ship: " + TinhPhiShip() + "d");
        System.out.println("Tong thanh toan: " + dSoTienDaThanhToan + "d");
        System.out.println("Trang thai: " + trangThai);
    }
}

// ================= UNG DUNG (LOP TONG) =================
class UngDung {
    private List<KhachHang> dsKhachHang;
    private List<ChuQuan> dsChuQuan;
    private List<TaiXe> dsTaiXe;
    private List<Quan> dsQuan;
    private List<DonHang> dsDonHang;

    public UngDung() {
        dsKhachHang = new ArrayList<>();
        dsChuQuan = new ArrayList<>();
        dsTaiXe = new ArrayList<>();
        dsQuan = new ArrayList<>();
        dsDonHang = new ArrayList<>();
    }

    public void ThemKhachHang(KhachHang kh) { dsKhachHang.add(kh); }
    public void ThemChuQuan(ChuQuan cq) { dsChuQuan.add(cq); }
    public void ThemTaiXe(TaiXe tx) { dsTaiXe.add(tx); }
    public void ThemQuan(Quan q) { dsQuan.add(q); }

    public TaiXe TimTaiXeRanh() {
        for (int i = 0; i < dsTaiXe.size(); i++) {
            if (dsTaiXe.get(i).isDangRanh())
                return dsTaiXe.get(i);
        }
        return null;
    }

    public void TimTaiXeRanhVaGanDon(DonHang don) {
        TaiXe tx = TimTaiXeRanh();
        if (tx != null)
            don.GanTaiXe(tx);
        else
            System.out.println("Khong co tai xe ranh.");
    }

    public DonHang TaoDonHang(String ma, KhachHang kh, Quan quan) {
        // kiem tra quan co dang mo cua khong
        if (!quan.isDangMoCua()) {
            System.out.println("Quan hien dang dong cua, khong the dat hang.");
            return null;
        }
        DonHang don = new DonHang(ma, kh, quan);
        dsDonHang.add(don);
        return don;
    }

    public void BaoCao() {
        System.out.println("===== BAO CAO HE THONG =====");
        System.out.println("Tong so don hang: " + dsDonHang.size());

        // dem don hoan thanh va don huy
        int soHoanThanh = 0;
        int soHuy = 0;
        for (int i = 0; i < dsDonHang.size(); i++) {
            if (dsDonHang.get(i).getTrangThai() == TrangThaiDon.HoanThanh)
                soHoanThanh = soHoanThanh + 1;
            if (dsDonHang.get(i).getTrangThai() == TrangThaiDon.DaHuy)
                soHuy = soHuy + 1;
        }
        System.out.println("Don hoan thanh: " + soHoanThanh);
        System.out.println("Don da huy: " + soHuy);

        System.out.println("--- Thong tin tai xe ---");
        for (int i = 0; i < dsTaiXe.size(); i++) {
            dsTaiXe.get(i).Xuat();
            System.out.println();
        }
    }
}

// ================= CHAY THU =================
public class Main {
    public static Scanner scanner = new Scanner(System.in);

    static void NhapMenu(Quan quan) {
        System.out.println("Nhap so mon trong menu: ");
        int soMonMenu = Integer.parseInt(scanner.nextLine());

        for (int i = 0; i < soMonMenu; i++) {
            System.out.println("\n--- Nhap mon " + (i + 1) + " ---");
            MonAn mon = new MonAn();
            mon.Nhap();
            quan.ThemMon(mon);
        }
    }

    static void NhapVoucher(Quan quan) {
        System.out.println("Nhap so voucher cua quan: ");
        int soVoucher = Integer.parseInt(scanner.nextLine());

        for (int i = 0; i < soVoucher; i++) {
            System.out.println("\n--- Nhap voucher " + (i + 1) + " ---");
            Voucher v = new Voucher();
            v.Nhap();
            quan.ThemVoucher(v);
        }
    }

    static PhuongThucThanhToan ChonPhuongThucThanhToan() {
        System.out.println("Chon phuong thuc thanh toan:");
        System.out.println("1 - Tien mat");
        System.out.println("2 - Vi dien tu");
        System.out.println("3 - The");
        System.out.print("Lua chon: ");

        String chon = scanner.nextLine();

        switch (chon) {
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

    static String ChonVoucher(Quan quan) {
        if (!quan.CoVoucher()) {
            System.out.println("Quan nay hien khong co voucher khuyen mai.");
            return null;
        }

        quan.HienThiVoucherConDung();
        System.out.println("Nhap ma voucher muon dung (bo trong neu khong dung): ");
        String maVoucher = scanner.nextLine();

        if (maVoucher == null || maVoucher.isEmpty())
            return null;

        return maVoucher;
    }

    public static void main(String[] args) {
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
        System.out.println("Nhap ma don hang: ");
        String maDon = scanner.nextLine();
        DonHang don = app.TaoDonHang(maDon, kh, quan);

        if (don == null) {
            System.out.println("Khong the tao don hang. Ket thuc.");
            scanner.nextLine();
            return;
        }

        don.Nhap();

        // ================= 3. QUAN NHAN DON =================
        System.out.println("\n===== BUOC 1: QUAN NHAN DON =====");
        quan.NhanDon(don);

        // ================= HUY DON (NEU MUON) =================
        System.out.print("Ban co muon huy don khong? (y/n): ");
        String huyChon = scanner.nextLine();
        if (huyChon.equals("y") || huyChon.equals("Y")) {
            don.HuyDon();
            System.out.println("\n===== HOA DON =====");
            don.InHoaDon();
            System.out.println();
            app.BaoCao();
            scanner.nextLine();
            return;
        }

        // ================= 4. THANH TOAN =================
        // Thanh toan truoc, sau do moi phan cong tai xe.
        System.out.println("\n===== BUOC 2: THANH TOAN =====");
        PhuongThucThanhToan ptTT = ChonPhuongThucThanhToan();
        String maVoucher = ChonVoucher(quan);

        boolean thanhCong = don.ThanhToan(ptTT, maVoucher);

        // Neu vi dien tu khong du tien, cho khach chuyen sang tien mat.
        if (!thanhCong) {
            System.out.println("Chuyen sang thanh toan bang tien mat.");
            ptTT = new TienMat();
            thanhCong = don.ThanhToan(ptTT, maVoucher);
        }

        if (!thanhCong) {
            System.out.println("Khong the thanh toan don hang.");
            scanner.nextLine();
            return;
        }

        // ================= 5. PHAN CONG TAI XE =================
        System.out.println("\n===== BUOC 3: PHAN CONG TAI XE =====");
        app.TimTaiXeRanhVaGanDon(don);

        // ================= 6. GIAO HANG =================
        System.out.println("\n===== BUOC 4: GIAO HANG =====");
        if (don.getTrangThai() == TrangThaiDon.DangGiao)
            don.HoanThanhDon();
        else
            System.out.println("Don hang chua duoc giao vi chua co tai xe.");

        // ================= 7. HIEN THI KET QUA =================
        System.out.println("\n===== HOA DON =====");
        don.InHoaDon();

        System.out.println();
        quan.Xuat();

        System.out.println();
        quan.HienThiVoucherDaDung();

        System.out.println()y;
        kh.Xuat();

        System.out.println();
        app.BaoCao();

        scanner.nextLine();
    }
}
