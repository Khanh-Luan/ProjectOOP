package FinalProject;

import java.util.ArrayList;
import java.util.List;

public class UngDung 
{
    //fields
    private List<KhachHang> dsKhachHang;
    private List<ChuQuan> dsChuQuan;
    private List<TaiXe> dsTaiXe;
    private List<Quan> dsQuan;
    private List<DonHang> dsDonHang;
    //properties
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
    //constructor
    public UngDung()
    {
        this.dsKhachHang= new ArrayList<KhachHang>();
        this.dsChuQuan= new ArrayList<ChuQuan>();
        this.dsTaiXe= new ArrayList<TaiXe>();
        this.dsQuan= new ArrayList<Quan>();
        this.dsDonHang= new ArrayList<DonHang>();     
    }
    //thêm quán
    public void ThemKhachHang(KhachHang kh)
    {
        this.dsKhachHang.add(kh);
    }
    //thêm chủ quán
    public void ThemChuQuan(ChuQuan cq)
    {
        this.dsChuQuan.add(cq);
    }
    //thêm tài xế
    public void ThemTaiXe(TaiXe tx)
    {
        this.dsTaiXe.add(tx);
    }
    //thêm quán
    public void ThemQuan(Quan q)
    {
        this.dsQuan.add(q);
    }
    //tìm tài xế rảnh
    public TaiXe TimTaiXeRanh()
    {
        for(int i=0; i< this.dsTaiXe.size(); i++)
        {
            if(this.dsTaiXe.get(i).isDangRanh()) return this.dsTaiXe.get(i);
        }
        return null;
    }
    //tìm tài xế rảnh và gần đơn
    public void TimTaiXeRanhVaGanDon(DonHang don)
    {
        TaiXe tx= this.TimTaiXeRanh();
        if(tx != null) don.GanTaiXe(tx);
        else System.out.println("Khong co tai xe ranh!");
        
    }
    //hàm tạo đơn hàng
    public DonHang TaoDonHang(String ma, KhachHang kh, Quan quan)
    {
        //Kiểm tra quán có mở cửa không
        if(!quan.isDangMoCua())
        {
            System.out.println("Quan hien dang dong cua, hien khong the dat hang");
            return null;
        }
        DonHang don= new DonHang(ma, kh, quan);
        this.dsDonHang.add(don);
        return don;
    }
    //hàm báo cáo
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
}
