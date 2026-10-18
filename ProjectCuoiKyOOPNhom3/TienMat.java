package ProjectCuoiKyOOPNhom3;

public class TienMat extends PhuongThucThanhToan
{
    public TienMat()
    {

    }
    @Override
    public boolean XuLyThanhToan(double soTien) 
    {
        System.out.println("Thanh toan tien mat: " + soTien + "VND khi nhan hang");
        return true;
    }
}
