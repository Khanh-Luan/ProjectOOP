package OOPwithJava;
import java.util.ArrayList;
import java.util.List;

enum TrangThaiDon{   //trạng thái đơn hàng(ở đây sài enum)
    ChoXacNhan,
    DangLam,
    DaThanhToan,
    DangGiao,
    HoanThanh,
    DaHuy,
}
//người dùng
abstract class NguoiDung
{   //fields
    protected String sMa;
    protected String sTen;
    protected String sSdt;
    protected String sEmail;
    //properties
    public String getMa()
    {
        return sMa;
    }
    public void setMa(String ma) {}
    public String getTen()
    {
        return sTen;
    }
    public void setTen(String ten) {}
    public String getSdt()
    {
        return sSdt;
    }
    public void setSdt(String sdt) {}
    public String getEmail()
    {
        return sEmail;
    }
    public void setEmail(String email) {}
    //constructor
    public NguoiDung() { }
    public NguoiDung(String ma, String ten, String sdt, String email) { }
    //nhap
    public void Nhap() { }
    //xuat
    public void Xuat() { }
    //phương thức tính tiền
    public abstract void TinhToanTien(double soTien);
}
//Khách hàng
class KhachHang extends NguoiDung 
{
    //fields
    private String sDiaChiGiao;
    private int iDiemTichLuyITFood;
    private double dTongDaChi;
    //properties
    public String getDiaChiGiao() 
    {
        return sDiaChiGiao; 
    }
    public void setDiaChiGiao(String diaChiGiao) { }
    public int getDiemTichLuyITFood() 
    {
        return iDiemTichLuyITFood;
    }
    public void setDiemTichLuyITFood(int diemTichLuyITFood) { }
    public double getTongDaChi() 
    {
        return dTongDaChi;
    }
    //constructors
    public KhachHang() { }
    public KhachHang(String ma, String ten, String sdt, String email, String diaChi) { }
    //nhap
    @Override
    public void Nhap() { }
    //xuat
    @Override
    public void Xuat() { }
    //phương thức tính tiền
    @Override
    public void TinhToanTien(double soTien) { }
}
//Chủ quán
class ChuQuan extends NguoiDung 
{
    //fields
    private List<Quan> dsQuan;
    private double dTongDoanhThu;
    //properties
    public double getTongDoanhThu() 
    {
        return dTongDoanhThu;
    }
    //constructor
    public ChuQuan() { }
    public ChuQuan(String ma, String ten, String sdt, String email) { }
    //thêm quán vào dsQuan, gán quan.ChuCuaQuan=this
    public void ThemQuan(Quan quan) { }
    //tìm quán
    public Quan TimQuan(String ma) 
    {
        return null;
    }
    //in dsQuan
    public void HienThiDsQuan() { }
    //xuat
    @Override
    public void Xuat() { }
    //Tính doanh thu quán
    @Override
    public void TinhToanTien(double soTien) { }
}
//tài xế
class TaiXe extends NguoiDung 
{
    //fields
    private String sBienSo;
    private boolean bDangRanh;
    private int iSoDonDaGiao;
    private double dTongThuNhap;
    //properties
    public String getBienSo() 
    {
        return sBienSo;
    }
    public void setBienSo(String bienSo) { }
    public boolean isDangRanh() 
    {
        return bDangRanh;
    }
    public void setDangRanh(boolean dangRanh) { }
    public int getSoDonDaGiao() 
    {
        return iSoDonDaGiao;
    }
    public void setSoDonDaGiao(int soDonDaGiao) { }
    public double getTongThuNhap() 
    {
        return dTongThuNhap;
    }
    //constructor
    public TaiXe() { }
    public TaiXe(String ma, String ten, String sdt, String email, String bienSo) { }
    //Tính thu nhập
    @Override
    public void TinhToanTien(double soTien) { }
    //nhap
    @Override
    public void Nhap() { }
    //xuat
    @Override
    public void Xuat() { }
    //tăng số đơn đã giao, đặt dDangRanh= true
    public void HoanThanhGiao() { }
}
//Món ăn
class MonAn 
{
    //fields
    protected String sMa;
    protected String sTen;
    protected double dGia;
    //properties
    public String getMa() 
    {
        return sMa;
    }
    public void setMa(String ma) { }
    public String getTen() 
    {
        return sTen;
    }
    public void setTen(String ten) { }
    public double getGia() 
    {
        return dGia;
    }
    public void setGia(double value) { }
    //constructor
    public MonAn() { }
    public MonAn(String ma, String ten, double gia) { }
    //nhap
    public void Nhap() { }
    //in ra mã, tên, giá
    public void HienThi() { }
}
//Chi tiết đơn
class ChiTietDon 
{
    //fields
    private MonAn mon;
    private int iSoLuong;
    //properties
    public MonAn getMon() 
    {
        return mon;
    }
    public void setMon(MonAn mon) { }
    public int getSoLuong() 
    {
        return iSoLuong;
    }
    public void setSoLuong(int soLuong) { }
    //constructor
    public ChiTietDon() { }
    public ChiTietDon(MonAn mon, int soLuong) { }
    //Thành tiền = Giá món *Số lượng
    public double ThanhTien() 
    {
        return 0;
    }
    //in tên, số lượng, thành tiền
    public void HienThi() { }
}
//Voucher
class Voucher 
{
    //fields
    private String sMa;
    private String sTen;
    private double dPhanTram;
    private boolean bConSuDung;
    //properties
    public String getMa() 
    {
        return sMa;
    }
    public void setMa(String ma) { }
    public String getTen() 
    {
        return sTen;
    }
    public void setTen(String ten) { }
    public double getPhanTram() 
    {
        return dPhanTram;
    }
    public void setPhanTram(double phanTram) { }
    public boolean isConSuDung()
    {
        return bConSuDung;
    }
    //constructor
    public Voucher() { }
    public Voucher(String ma, String ten, double phanTram) { }
    //Nếu còn sử dụng được thì return tienMon*phanTram/100, còn k thì return 0
    public double TinhGiam(double tienMon) 
    {
        return 0;
    }
    //đặt bConSuDung= false
    public void SuDung() { }
    //nhap
    public void Nhap() { }
    //xuat
    public void Xuat() { }
}
//Quán
class Quan 
{
    //fields
    private String sMa;
    private String sTen;
    private String sDiaChi;
    private boolean bDangMoCua;
    private List<MonAn> menu;
    private List<Voucher> dsVoucher;
    private ChuQuan chuQuan;
    //properties
    public String getMa() 
    {
        return sMa;
    }
    public void setMa(String ma) { }
    public String getTen() 
    {
        return sTen;
    }
    public void setTen(String ten) { }
    public String getDiaChi() 
    {
        return sDiaChi;
    }
    public void setDiaChi(String diaChi) { }
    public boolean isDangMoCua() 
    {
        return bDangMoCua;
    }
    public void setDangMoCua(boolean dangMoCua) { }
    public ChuQuan getChuCuaQuan() 
    {
        return chuQuan;
    }
    public void setChuCuaQuan(ChuQuan chuQuan) { }
    //constructor
    public Quan() { }
    public Quan(String ma, String ten, String diaChi) { }
    //nhap
    public void Nhap() { }
    //thêm món vào menu
    public void ThemMon(MonAn mon) { }
    //tìm món theo mã
    public MonAn TimMon(String ma) 
    {
        return null;
    }
    //in menu
    public void HienThiMenu() { }
    //thêm voucher
    public void ThemVoucher(Voucher v) { }
    //tìm voucher
    public Voucher TimVoucher(String ma) 
    {
        return null;
    }
    //duyệt voucher, return true nếu voucher sử dụng được, ngược lại false
    public boolean CoVoucher() 
    {
        return false;
    }
    //in các voucher còn sd
    public void HienThiVoucherConDung() { }
    //in các voucher đã sd
    public void HienThiVoucherDaDung() { }
    //xuất hết thông tin
    public void Xuat() { }
    //Thông báo nhận đơn, cập nhập trạng thái đơn  sang DangLam
    public void NhanDon(DonHang don) { }
}
//Phương thức thanh toán
abstract class PhuongThucThanhToan 
{
    public abstract boolean XuLyThanhToan(double soTien);
}
class TienMat extends PhuongThucThanhToan 
{
    @Override
    public boolean XuLyThanhToan(double soTien) { return false; }
}
class ViDienTu extends PhuongThucThanhToan 
{
    //fields
    private double dSoDu;
    //constructor
    public ViDienTu() { }
    public ViDienTu(double soDu) { }
    //nhập số dư tài khoản
    public void Nhap() { }
    //Check số dư >= soTien, trừ tiền, return true or false
    @Override
    public boolean XuLyThanhToan(double soTien) 
    {
        return false;
    }
}
class The extends PhuongThucThanhToan 
{
    //fields
    private static final double PHI_GIAO_DICH_MAC_DINH = 3000;
    private String sSoTheCuoi;
    private double dPhiGiaoDich;
    //constructor
    public The() { }
    public The(String soTheCuoi) { }
    //nhập 4 số cuối thẻ
    public void Nhap() { }
    //Tính tổng= soTien+phi, in thông báo, return true
    @Override
    public boolean XuLyThanhToan(double soTien) 
    {
        return false;
    }
}
//Đơn hàng
class DonHang 
{
    //fields
    private String sMa;
    private KhachHang khach;
    private Quan quan;
    private TaiXe taiXe;
    private List<ChiTietDon> dsChiTiet;
    private double dKhoangCachKm;
    private TrangThaiDon trangThai;
    private PhuongThucThanhToan thanhToan;
    private double dSoTienDaThanhToan;
    private double dSoTienGiamGia;
    //properties
    public String getMa() 
    {
        return sMa;
    }
    public TrangThaiDon getTrangThai() 
    {
        return trangThai;
    }
    //constructor
    public DonHang(String ma, KhachHang khach, Quan quan) { }
    //tạo ChiTietDon mới và thêm vào dsChiTiet
    public void GoiMon(MonAn mon, int soLuong) { }
    //Khách chọn món, số lượng, nhập khoảng cách, in đơn
    public void Nhap() { }
    //Gán trạng thái mới
    public void CapNhatTrangThai(TrangThaiDon trangThaiMoi) { }
    //xuất mã đơn, dsChiTietDon, trạng thái
    public void Xuat() { }
    //tổng thành tiền
    public double TongTienMon() 
    {
        return 0;
    }
    //<= 3km: 15000, <= 7km: 25000, > 7km: 40000
    public double TinhPhiShip() 
    {
        return 0;
    }
    //Áp voucher, return 0 nếu k có
    public double TinhGiamGia(String maVoucher) 
    {
        return 0; 
    }
    //TongThanhToan= return TongTienMon - TinhGiamGia + TinhPhiShip
    public double TongThanhToan(String maVoucher) 
    {
        return 0;
    }
    //gán tài xế, đặt tài xế k rảnh , trạng thái =DangGiao, in thông báo
    public void GanTaiXe(TaiXe tx) { }
    //xử lí thanh toán
    public boolean ThanhToan(PhuongThucThanhToan ptTT, String maVoucher) 
    {
        return false;
    }
    //kiểm tra trạng thái DangGiao, tính tiền cho tài xế, hoàn thành giao, trạng thái =HoanThanh
    public void HoanThanhDon() { }
    //hủy đơn
    public void HuyDon() { }
    //in hóa đơn
    public void InHoaDon() { }
}
//Ứng dụng
class UngDung 
{
    //fields
    private List<KhachHang> dsKhachHang;
    private List<ChuQuan> dsChuQuan;
    private List<TaiXe> dsTaiXe;
    private List<Quan> dsQuan;
    private List<DonHang> dsDonHang;
    //constructor
    public UngDung() { }
    public void ThemKhachHang(KhachHang kh) { }
    public void ThemChuQuan(ChuQuan cq) { }
    public void ThemTaiXe(TaiXe tx) { }
    public void ThemQuan(Quan q) { }
    public TaiXe TimTaiXeRanh() 
    {
        return null;
    }
    public void TimTaiXeRanhVaGanDon(DonHang don) { }
    public DonHang TaoDonHang(String ma, KhachHang kh, Quan quan) 
    {
        return null;
    }
    public void BaoCao() { }
}
//main
public class Main 
{
    static void NhapMenu(Quan quan) { }
    static void NhapVoucher(Quan quan) { }
    static PhuongThucThanhToan ChonPhuongThucThanhToan() 
    {
        return null;
    }
    static String ChonVoucher(Quan quan) 
    {
        return null;
    }
    public static void main(String[] args) 
    {
    }
}


