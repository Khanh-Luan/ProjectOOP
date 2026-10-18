package ProjectCuoiKyOOPNhom3;

import java.util.ArrayList;
import java.util.List;

public class UngDung 
{
    private List<KhachHang> dsKhachHang;
    private List<ChuQuan> dsChuQuan;
    private List<TaiXe> dsTaiXe;
    private List<Quan> dsQuan;
    private List<DonHang> dsDonHang;
    
    public List<KhachHang> getDsKhachHang()
    {
        return dsKhachHang;
    }
    public void setDsKhachHang(List<KhachHang> dsKhachHang)
    {
        this.dsKhachHang= dsKhachHang;
    }
    public List<ChuQuan> getDsChuQuan()
    {
        return dsChuQuan;
    }
    public void setDsChuQuan(List<ChuQuan> dsChuQuan)
    {
        this.dsChuQuan= dsChuQuan;
    }
    public List<TaiXe> getDsTaiXe()
    {
        return dsTaiXe;
    }
    public void setDsTaiXe(List<TaiXe> dsTaiXe)
    {
        this.dsTaiXe= dsTaiXe;
    }
    public List<Quan> getDsQuan()
    {
        return dsQuan;
    }
    public void setDsQuan(List<Quan> dsQuan)
    {
        this.dsQuan= dsQuan;
    }
    public List<DonHang> getDsDonHang()
    {
        return dsDonHang;
    }
    public void setDsDonHang(List<DonHang> dsDonHang)
    {
        this.dsDonHang= dsDonHang;
    }
    
    public UngDung()
    {
        this.dsKhachHang= new ArrayList<KhachHang>();
        this.dsChuQuan= new ArrayList<ChuQuan>();
        this.dsTaiXe= new ArrayList<TaiXe>();
        this.dsQuan= new ArrayList<Quan>();
        this.dsDonHang= new ArrayList<DonHang>();     
    }
    public UngDung(List<KhachHang> dsKhachHang, List<ChuQuan> dsChuQuan, List<TaiXe> dsTaiXe, List<Quan> dsQuan, List<DonHang> dsDonHang)
    {
        this.dsKhachHang= dsKhachHang;
        this.dsChuQuan= dsChuQuan;
        this.dsTaiXe= dsTaiXe;
        this.dsQuan= dsQuan;
        this.dsDonHang= dsDonHang;
    }
    
    public void ThemKhachHang(KhachHang kh)
    {
        this.dsKhachHang.add(kh);
    }
    
    public void ThemChuQuan(ChuQuan cq)
    {
        this.dsChuQuan.add(cq);
    }
    
    public void ThemTaiXe(TaiXe tx)
    {
        this.dsTaiXe.add(tx);
    }
    
    public void ThemQuan(Quan q)
    {
        this.dsQuan.add(q);
    }
    
    public TaiXe TimTaiXeRanh()
    {
        for(int i=0; i< this.dsTaiXe.size(); i++)
        {
            if(this.dsTaiXe.get(i).isDangRanh()) return this.dsTaiXe.get(i);
        }
        return null;
    }
    
    public void TimTaiXeRanhVaGanDon(DonHang don)
    {
        TaiXe tx= this.TimTaiXeRanh();
        if(tx != null) don.GanTaiXe(tx);
        else System.out.println("Khong co tai xe ranh!");
        
    }
    
    public DonHang TaoDonHang(String ma, KhachHang kh, Quan quan)
    {
        if(!quan.isDangMoCua())
        {
            System.out.println("Quan hien dang dong cua, hien khong the dat hang");
            return null;
        }
        DonHang don= new DonHang(ma, kh, quan);
        this.dsDonHang.add(don);
        return don;
    }
    
    public void BaoCao()
    {
        System.out.println("---BAO CAO HE THONG---");
        int soDonHoanThanh= 0;
        int soDonHuy= 0;
        for(int i=0; i< this.dsDonHang.size(); i++)
        {
            if(this.dsDonHang.get(i).getTrangThai() == TrangThaiDon.HoanThanh)
            {
                soDonHoanThanh++;
            }
            if(this.dsDonHang.get(i).getTrangThai() == TrangThaiDon.DaHuy)
            {
                soDonHuy++;
            }
        }
        System.out.println("Don hoan thanh: "+ soDonHoanThanh);
        System.out.println("Don da huy: "+ soDonHuy);
        System.out.println("--Thong tin tai xe--");
        for(int i=0; i< this.dsTaiXe.size(); i++)
        {
            this.dsTaiXe.get(i).Xuat();
            System.out.println();
        }
    }
    // 1. Tìm kiếm Quán theo mã (dùng for truyền thống)
    public Quan TimQuan(String ma) 
    {
        for (int i = 0; i < this.dsQuan.size(); i++) 
        {
            Quan q = this.dsQuan.get(i);
            if (q.getMa().equals(ma)) 
            {
                return q;
            }
        }
        return null;
    }

    // 2. Tìm kiếm Khách hàng theo mã (dùng for truyền thống)
    public KhachHang TimKhachHang(String ma) 
    {
        for (int i = 0; i < this.dsKhachHang.size(); i++) 
        {
            KhachHang kh = this.dsKhachHang.get(i);
            if (kh.getMa().equals(ma)) 
            {
                return kh;
            }
        }
        return null;
    }

    // 3. Hiển thị danh sách Quán hiện có (dùng for truyền thống)
    public void HienThiDsQuan() 
    {
        System.out.println("\n--- DANH SACH QUAN HIEN CO ---");
        for (int i = 0; i < this.dsQuan.size(); i++) 
        {
            Quan q = this.dsQuan.get(i);
            System.out.println("[" + q.getMa() + "] " + q.getTen() + " - Dia chi: " + q.getDiaChi());
        }
    }

    // 4. Hiển thị danh sách Khách hàng hiện có (dùng for truyền thống)
    public void HienThiDsKhachHang() 
    {
        System.out.println("\n--- DANH SACH KHACH HANG ---");
        for (int i = 0; i < this.dsKhachHang.size(); i++) 
        {
            KhachHang kh = this.dsKhachHang.get(i);
            System.out.println("[" + kh.getMa() + "] " + kh.getTen() + " - SDT: " + kh.getSdt());
        }
    }

    // 5. HÀM NẠP DỮ LIỆU MẪU (Mock Data)
    public void KhoiTaoDuLieuMau() {
        // Tạo 2 chủ quán
        ChuQuan cq1 = new ChuQuan("CQ01", "Nguyen Van Chu", "0901111111", "chu1@food.vn");
        ChuQuan cq2 = new ChuQuan("CQ02", "Tran Thi Chu", "0902222222", "chu2@food.vn");
        this.ThemChuQuan(cq1);
        this.ThemChuQuan(cq2);

        // Quán 1: Cơm Tấm
        Quan q1 = new Quan("Q01", "Com Tam Sai Gon", "123 Nguyen Trai, Q5");
        cq1.ThemQuan(q1);
        q1.ThemMon(new MonAn("M01", "Com Suon Bi Cha", 45000));
        q1.ThemMon(new MonAn("M02", "Com Suon Trung", 40000));
        q1.ThemMon(new MonAn("M03", "Canh Kho Qua", 15000));
        q1.ThemVoucher(new Voucher("GIAM10", "Giam 10%", 10));
        q1.ThemVoucher(new Voucher("GIAM20", "Giam 20%", 20));
        this.ThemQuan(q1);

        // Quán 2: Trà Sữa
        Quan q2 = new Quan("Q02", "Tra Sua Gong Cha", "456 Le Loi, Q1");
        cq2.ThemQuan(q2);
        q2.ThemMon(new MonAn("TS01", "Tra Sua Tran Chau", 35000));
        q2.ThemMon(new MonAn("TS02", "Tra Dao Cam Sa", 30000));
        q2.ThemVoucher(new Voucher("GIAM15", "Giam 15%", 15));
        this.ThemQuan(q2);

        // Tạo 2 khách hàng
        KhachHang kh1 = new KhachHang("KH01", "Nguyen Van An", "0911222333", "an@gmail.com", "789 Tran Hung Dao");
        KhachHang kh2 = new KhachHang("KH02", "Le Thi Binh", "0944555666", "binh@gmail.com", "101 Nguyen Hue");
        this.ThemKhachHang(kh1);
        this.ThemKhachHang(kh2);

        // Tạo 2 tài xế
        TaiXe tx1 = new TaiXe("TX01", "Tran Van Chay", "0977888999", "chay@food.vn", "59X1-12345");
        TaiXe tx2 = new TaiXe("TX02", "Pham Van Giao", "0988777666", "giao@food.vn", "59Y2-67890");
        this.ThemTaiXe(tx1);
        this.ThemTaiXe(tx2);

        System.out.println(">> Da nhap thanh cong: 2 Quan (kem Menu, Voucher), 2 Khach hang, 2 Tai xe!");
    }
}
