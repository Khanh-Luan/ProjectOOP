using System;
using System.Collections.Generic;
using System.Text;

namespace ITFood
{
    public class TienMat : PhuongThucThanhToan
    {
        public override bool XuLyThanhToan(double soTien)
        {
            Console.WriteLine($"Thanh toan {soTien}đ bang tien mat khi nhan hang.");
            return true;
        }
    }
}
