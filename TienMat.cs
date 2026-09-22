public class TienMat : PhuongThucThanhToan
{
    public override bool XuLyThanhToan(double soTien)
    {
        Console.WriteLine($"Thanh toan {soTien}d bang tien mat khi nhan hang.");
        return true;
    }
}
