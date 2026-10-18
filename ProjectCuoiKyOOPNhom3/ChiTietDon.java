package ProjectCuoiKyOOPNhom3;

public class ChiTietDon 
{
    private MonAn mon;
    private int iSoLuong;
    
    public MonAn getMon() 
    {
        return mon;
    }
    public void setMon(MonAn mon) 
    {
        this.mon = mon;
    }
    public int getSoLuong() 
    {
        return iSoLuong;
    }
    public void setSoLuong(int iSoLuong) 
    {
        this.iSoLuong = iSoLuong;
    }
    
    public ChiTietDon()
    {

    }
    public ChiTietDon(MonAn mon, int soLuong)
    {
        this.mon = mon;
        this.iSoLuong = soLuong;
    }
    
    public double ThanhTien()
    {
        return this.mon.getGia() * this.iSoLuong;
    }
    
    public void Xuat()
    {
        System.out.println("Thanh tien: " +this.mon.getMa() + "-" + this.mon.getTen() + "-" + this.mon.getGia() + " x " + this.iSoLuong + "= " + ThanhTien() + "VND");
    }
}
