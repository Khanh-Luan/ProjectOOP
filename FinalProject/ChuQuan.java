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
    //constructor
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
    //hàm thêm quán vào danh sách quán của chủ quán, đồng thời gán chủ quán cho quán đó
    public void ThemQuan(Quan quan) 
    {
        this.dsQuan.add(quan);
        quan.setChuCuaQuan(this); //gán chú quán cho quán vừa thêm
    }
    //hàm tìm quán trong danh sách quán của chủ quán theo mã quán
    public Quan TimQuan(String ma) 
    {
        for (int i = 0; i < this.dsQuan.size(); i++) 
            {
            if (this.dsQuan.get(i).getMa().equals(ma)) return this.dsQuan.get(i);
            }
        return null;
    }
    //hàm hiển thị danh sách quán của chủ quán
    public void HienThiDsQuan() 
    {
        System.out.println("Danh sach quan cua " + this.sTen + ":");
        for (int i = 0; i < this.dsQuan.size(); i++) 
        {
            System.out.println("  " + this.dsQuan.get(i).getMa() + " - " + this.dsQuan.get(i).getTen() + " - " + this.dsQuan.get(i).getDiaChi());
        }
    }
    //hàm xuất
    @Override
    public void Xuat() 
    {
        System.out.println("----Thong tin chu quan----");
        super.Xuat();
        System.out.println("So quan chu so huu: " + this.dsQuan.size());
        System.out.println("Tong doanh thu: " + this.dTongDoanhThu + "d");
    }
    //hàm tính tóan số tiền: cộng doanh thu từ đơn hàng của quán mình
    @Override
    public void TinhToanTien(double soTien) {
        this.dTongDoanhThu = this.dTongDoanhThu + soTien;
    }
}
