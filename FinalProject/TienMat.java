package FinalProject;

public class TienMat extends PhuongThucThanhToan
{
    @Override
    public boolean XuLyThanhToan(double soTien) 
    {
        System.out.println("Thanh toan tien mat: " + soTien + "VND");
        return true;
    }
}
