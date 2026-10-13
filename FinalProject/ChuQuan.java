package FinalProject;

import java.util.ArrayList;
import java.util.List;

public class ChuQuan extends NguoiDung
{
    //fields
    private List<Quan> dsQuan;
    private double dTongDoanhThu;
    //properties
    public double getTongDoanhThu() 
    { 
        return this.dTongDoanhThu;
    }
    public void setTongDoanhThu(double tongDoanhThu) 
    {
        this.dTongDoanhThu = tongDoanhThu;
    }
    public List<Quan> getDsQuan() 
    {
        return this.dsQuan;
    }
    public void setDsQuan(List<Quan> dsQuan) 
    {
        this.dsQuan = dsQuan;
    }
    //constructor
    public ChuQuan() 
    {
        this.dsQuan = new ArrayList<Quan>();
    }
    public ChuQuan(String ma, String ten, String sdt, String email) 
    {
        super(ma, ten, sdt, email);
        this.dsQuan = new ArrayList<Quan>();
        this.dTongDoanhThu = 0;
    }
    //ham them quan vao danh sach quan cua chu quan, dong thoi gan chu quan cho quan do
    public void ThemQuan(Quan quan) 
    {
        this.dsQuan.add(quan);
        quan.setChuCuaQuan(this);
    }
    //ham tim quan trong danh sach quan cua chu quan theo ma quan
    public Quan TimQuan(String ma) 
    {
        for (int i = 0; i < this.dsQuan.size(); i++) 
            {
            if (this.dsQuan.get(i).getMa().equals(ma)) return this.dsQuan.get(i);
            }
        return null;
    }
    //ham hien thi danh sach quan cua chu quan
    public void HienThiDsQuan() 
    {
        System.out.println("Danh sach quan cua " + this.sTen + ":");
        for (int i = 0; i < this.dsQuan.size(); i++) 
        {
            System.out.println("  " + this.dsQuan.get(i).getMa() + " - " + this.dsQuan.get(i).getTen() + " - " + this.dsQuan.get(i).getDiaChi());
        }
    }
    //ham xuat
    @Override
    public void Xuat() 
    {
        super.Xuat();
        System.out.println("So quan so huu: " + this.dsQuan.size());
        System.out.println("Tong doanh thu: " + this.dTongDoanhThu + "d");
    }
    // ham tinh toan so tien: cong doanh thu tu don hang cua quan minh
    @Override
    public void TinhToanTien(double soTien) {
        this.dTongDoanhThu = this.dTongDoanhThu + soTien;
    }
}
