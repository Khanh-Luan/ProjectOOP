package FinalProject;

public class TienMat extends PhuongThucThanhToan
{
    //constructor
    public TienMat()
    {

    }
    //xử lý thanh toán
    @Override
    public boolean XuLyThanhToan(double soTien) 
    {
        System.out.println("Thanh toan tien mat: " + soTien + "VND khi nhan hang");
        return true;
    }
}
