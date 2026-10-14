package FinalProject;

public class ChiTietDon 
{
    //fields
    private MonAn mon;
    private int iSoLuong;
    //properties
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
    //constructor
    public ChiTietDon()
    {

    }
    public ChiTietDon(MonAn mon, int soLuong)
    {
        this.mon = mon;
        this.iSoLuong = soLuong;
    }
    //Thành tiền
    public double ThanhTien()
    {
        return this.mon.getGia() * this.iSoLuong;
    }
    //hàm xuất
    public void Xuat()
    {
        System.out.println("Thanh tien: " +this.mon.getMa() + "-" + this.mon.getTen() + "-" + this.mon.getGia() + " x " + this.iSoLuong + "= " + ThanhTien() + "VND");
    }
}
