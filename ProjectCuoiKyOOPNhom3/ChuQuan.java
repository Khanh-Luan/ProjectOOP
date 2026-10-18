package ProjectCuoiKyOOPNhom3;

import java.util.ArrayList;
import java.util.List;

public class ChuQuan extends NguoiDung
{
    private List<Quan> dsQuan;
    private double dTongDoanhThu;
    
    public double getTongDoanhThu() 
    { 
        return dTongDoanhThu;
    }
    public void setTongDoanhThu(double tongDoanhThu) 
    {
        this.dTongDoanhThu = tongDoanhThu;
    }
    public List<Quan> getDsQuan() 
    {
        return dsQuan;
    }
    public void setDsQuan(List<Quan> dsQuan) 
    {
        this.dsQuan = dsQuan;
    }
    
    public ChuQuan() 
    {
        this.dsQuan = new ArrayList<Quan>();
        this.dTongDoanhThu = 0;
    }
    public ChuQuan(String ma, String ten, String sdt, String email) 
    {
        super(ma, ten, sdt, email);
        this.dsQuan = new ArrayList<Quan>();
        this.dTongDoanhThu = 0;
    }
    
    public void ThemQuan(Quan quan) 
    {
        this.dsQuan.add(quan);
        quan.setChuCuaQuan(this); 
    }
    
    public Quan TimQuan(String ma) 
    {
        for (int i = 0; i < this.dsQuan.size(); i++) 
            {
            if (this.dsQuan.get(i).getMa().equals(ma)) return this.dsQuan.get(i);
            }
        return null;
    }
    
    public void HienThiDsQuan() 
    {
        System.out.println("Danh sach quan cua " + this.sTen + ":");
        for (int i = 0; i < this.dsQuan.size(); i++) 
        {
            System.out.println("  " + this.dsQuan.get(i).getMa() + " - " + this.dsQuan.get(i).getTen() + " - " + this.dsQuan.get(i).getDiaChi());
        }
    }
    
    @Override
    public void Xuat() 
    {
        System.out.println("----Thong tin chu quan----");
        super.Xuat();
        System.out.println("So quan chu so huu: " + this.dsQuan.size());
        System.out.println("Tong doanh thu: " + this.dTongDoanhThu + "d");
    }
    
    @Override
    public void TinhToanTien(double soTien) 
    {
        this.dTongDoanhThu = this.dTongDoanhThu + soTien;
    }
}
