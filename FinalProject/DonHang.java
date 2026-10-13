package FinalProject;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;

public class DonHang 
{
    //fields
    private static double Chiet_khau_cua_quan= 0.25;
    private static double Chiet_khau_cua_tai_xe= 0.20;
    private static double Phi_nen_tang= 3000;
    private String sMa;
    private KhachHang khach;
    private Quan quan;
    private TaiXe taiXe;
    private List<ChiTietDon> dsChiTiet; //dùng chi tiết đơn thay vì list monAn và list soLuong
    private double dKhoangCachKm;
    private TrangThaiDon trangThai; //dùng enum cố định tránh nhập sai
    private PhuongThucThanhToan thanhToan;
    private double dSoTienDaThanhToan;
    private double dSoTienGiamGia; //lưu số tiền giảm giá để in hóa đơn
    //properties
    public static double getChiet_khau_cua_quan() 
    {
        return Chiet_khau_cua_quan;
    }
    public static void setChiet_khau_cua_quan(double chiet_khau_cua_quan) 
    {
        Chiet_khau_cua_quan = chiet_khau_cua_quan;
    }
    public static double getChiet_khau_cua_tai_xe() 
    {
        return Chiet_khau_cua_tai_xe;
    }
    public static void setChiet_khau_cua_tai_xe(double chiet_khau_cua_tai_xe) 
    {
        Chiet_khau_cua_tai_xe = chiet_khau_cua_tai_xe;
    }
    public static double getPhi_nen_tang() 
    {
        return Phi_nen_tang;
    }
    public static void setPhi_nen_tang(double phi_nen_tang) 
    {
        Phi_nen_tang = phi_nen_tang;
    }
    public String getMa() 
    {
        return sMa;
    }
    public void setMa(String ma) 
    {
        this.sMa = ma;
    }
    public KhachHang getKhach() 
    {
        return khach;
    }
    public void setKhach(KhachHang khach) 
    {
        this.khach = khach;
    }
    public Quan getQuan() 
    {
        return quan;
    }
    public void setQuan(Quan quan) 
    {
        this.quan = quan;
    }
    public TaiXe getTaiXe() 
    {
        return taiXe;
    }
    public void setTaiXe(TaiXe taiXe) 
    {
        this.taiXe = taiXe;
    }
    public List<ChiTietDon> getDsChiTiet() 
    {
        return dsChiTiet;
    }
    public void setDsChiTiet(List<ChiTietDon> dsChiTiet) 
    {
        this.dsChiTiet = dsChiTiet;
    }
    public double getKhoangCachKm() 
    {
        return dKhoangCachKm;
    }
    public void setKhoangCachKm(double khoangCachKm) 
    {
        this.dKhoangCachKm = khoangCachKm;
    }
    public TrangThaiDon getTrangThai() 
    {
        return trangThai;
    }
    public void setTrangThai(TrangThaiDon trangThai) 
    {
        this.trangThai = trangThai;
    }
    public PhuongThucThanhToan getThanhToan() 
    {
        return thanhToan;
    }
    public void setThanhToan(PhuongThucThanhToan thanhToan) 
    {
        this.thanhToan = thanhToan;
    }
    public double getSoTienDaThanhToan() 
    {
        return dSoTienDaThanhToan;
    }
    public void setSoTienDaThanhToan(double soTienDaThanhToan) 
    {
        this.dSoTienDaThanhToan = soTienDaThanhToan;
    }
    public double getSoTienGiamGia() 
    {
        return dSoTienGiamGia;
    }
    public void setSoTienGiamGia(double soTienGiamGia) 
    {
        this.dSoTienGiamGia = soTienGiamGia;
    }
    //constructor
    public DonHang(String ma, KhachHang khach, Quan quan) 
    {
        this.sMa = ma;
        this.khach = khach;
        this.quan = quan;
        this.dsChiTiet= new ArrayList<ChiTietDon>();
        this.trangThai= TrangThaiDon.ChoXacNhan;
    }
    //hàm gọi món
    public void GoiMon(MonAn mon, int soLuong) 
    {
        ChiTietDon ct = new ChiTietDon(mon, soLuong);
        this.dsChiTiet.add(ct);
    }
    //khách nhập thông tin đặt hàng: chọn món trong menu của quán, nhập khoảng cách giao (do là project nhỏ nên chưa xử lí được)
    public void Nhap() throws IOException
    {
        quan.HienThiMenu();
        InputStreamReader isr = new InputStreamReader(System.in);
        BufferedReader br = new BufferedReader(isr);
        System.out.println("Nhap so mon muon dat: ");
        int soMon= Integer.parseInt(br.readLine());
        for (int i = 0; i < soMon; i++) 
        {
            System.out.println("Nhap ma mon:");
            String maMon= br.readLine();
            System.out.println("Nhap so luong: ");
            int soLuong= Integer.parseInt(br.readLine());
            MonAn mon= quan.TimMon(maMon);
            if(mon!= null) 
            {
                GoiMon(mon, soLuong);
            }
            else 
            {
                System.out.println("Khong tim thay mon co ma "+maMon +".Bo qua...");            
            }
        }
        System.out.println("Nhap khoang cach giao (km): ");
        this.dKhoangCachKm= Double.parseDouble(br.readLine());
        this.trangThai= TrangThaiDon.ChoXacNhan;
    }
    public void CapNhatTrangThai(TrangThaiDon trangThaiMoi)
    {
        this.trangThai= trangThaiMoi;
    }
    public void Xuat()
    {
        System.out.println("---DON HANG "+this.sMa+"---");
        for(int i= 0; i< this.dsChiTiet.size(); i++)
        {
            this.dsChiTiet.get(i).Xuat();
        }
        System.out.println("Trang thai: "+ this.trangThai);
    }
    public double TongTienMon()
    {
        double tong= 0;
        for(int i= 0; i<this.dsChiTiet.size(); i++)
        {
            tong = tong+ this.dsChiTiet.get(i).ThanhTien();
        }
        return tong;
    }
    public double TinhPhiShip()
    {
        if(this.dKhoangCachKm<=3) return 15000;
        if(this.dKhoangCachKm<=7) return 25000;
        return 40000;
    }
    public double TinhGiamGia(String maVoucher)
    {
        if(maVoucher == null) return 0;
        Voucher v= quan.TimVoucher(maVoucher);
        if(v == null) return 0;
        return v.TinhGiam(TongTienMon());
    }
    public double TongThanhToan(String maVoucher)
    {
        return TongTienMon() - TinhGiamGia(maVoucher) + TinhPhiShip() + Phi_nen_tang;
    }
    public void GanTaiXe(TaiXe tx)
    {
        this.taiXe= tx;
        tx.setDangRanh(false);
        this.trangThai= TrangThaiDon.DangGiao;
        System.out.println("[Thong bao tai xe "+tx.getTen()+"] Ban duoc phan cong giao don"+ this.sMa);  
    }
    //Thanh toán (trả về true nếu thanh toán thành công, false nếu thất bại)
    public boolean ThanhToan(PhuongThucThanhToan ptTT, String maVoucher)
    {
        this.thanhToan= ptTT;
        double giam= TinhGiamGia(maVoucher);
        double tongTien= TongThanhToan(maVoucher);
        this.dSoTienDaThanhToan= tongTien;
        this.dSoTienGiamGia= giam;
        boolean thanhCong= thanhToan.XuLyThanhToan(tongTien);
        if(thanhCong)
        //thanh toán thành công nhưng đơn chưa được giao
        // Đơn chỉ được chuyển sang HoanThanh ngay sau khi tài xế done
        {
            this.trangThai= TrangThaiDon.DaThanhToan;
            if(maVoucher!= null)
            {
                Voucher v= quan.TimVoucher(maVoucher);
                if(v != null)
                {
                    v.SuDung();
                }
            }
            khach.TinhToanTien(tongTien);
            double tienCuaQuan= (TongTienMon()- giam)* (1- Chiet_khau_cua_quan);
            this.quan.getChuCuaQuan().TinhToanTien(tienCuaQuan);
        }
        else
        {
            System.out.println("Thanh toan that bai! Don hang chua duoc thanh toan");
        }
        return thanhCong;
    }
    //hoàn tất giao hàng sau khi thanh toán và đã có tài xế
    public void HoanThanhDon()
    {
        if (this.trangThai != TrangThaiDon.DangGiao) 
        {
            System.out.println("Don hang chua du dieu kien de hoan thanh.");
            return;
        }
        if (this.taiXe != null) 
        {
            double tienCuaTaiXe = TinhPhiShip() * (1 - Chiet_khau_cua_tai_xe);
            this.taiXe.TinhToanTien(tienCuaTaiXe);
            this.taiXe.HoanThanhGiao();
        }
        this.trangThai = TrangThaiDon.HoanThanh;
        System.out.println("Don hang " + this.sMa + " da giao thanh cong.");
    }
    public void HuyDon()
    {
        if(this.trangThai == TrangThaiDon.HoanThanh)
        {
            System.out.println("Khong the huy don da hoan thanh");
            return;
        }
        this.trangThai= TrangThaiDon.DaHuy;
        if(this.taiXe != null)
        {
            this.taiXe.setDangRanh(true);
        }
        System.out.println("Don hang "+ this.sMa+ " da bi huy");
    }
    public void InHoaDon()
    {
        System.out.println("---HOA DON "+ this.sMa+ " ---");
        for(int i=0; i< this.dsChiTiet.size(); i++)
        {
            this.dsChiTiet.get(i).Xuat();
        }
        System.out.println("Tien mon: "+ TongTienMon()+ "VND");
        if(this.dSoTienGiamGia>0) 
        {
            System.out.println("Giam gia Voucher: -" + this.dSoTienGiamGia +"VND");
        }
        System.out.println("Phi ship: "+ TinhPhiShip()+ "VND");
        System.out.println("Tong thanh toan: "+ this.dSoTienDaThanhToan+ "VND");
        System.out.println("Trang thai: "+ this.trangThai);
    }
}
