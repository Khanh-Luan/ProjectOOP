package FinalProject;

public class ChiTietDon 
{
    //fields
    private MonAn mon;
    private int iSoLuong;
    //properties
    public MonAn getMon() 
    {
        return this.mon;
    }
    public void setMon(MonAn mon) 
    {
        this.mon = mon;
    }
    public int getSoLuong() 
    {
        return this.iSoLuong;
    }
    public void setSoLuong(int iSoLuong) 
    {
        this.iSoLuong = iSoLuong;
    }
    //constructor
    public ChiTietDon()
    {

    }
    public ChiTietDon(MonAn mon, int iSoLuong)
    {
        this.mon = mon;
        this.iSoLuong = iSoLuong;
    }
    //Thành tiền
    public double ThanhTien()
    {
        return this.mon.getGia() * this.iSoLuong;
    }
    //hàm xuất
    public void Xuat()
    {
        System.out.println(this.mon.getMa() + "-" + this.mon.getTen() + "-" + this.mon.getGia() + "-" + this.iSoLuong + "- Thanh tien: " + ThanhTien());
    }
}
