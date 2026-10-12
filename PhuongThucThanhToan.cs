using System;
using System.Collections.Generic;
using System.Text;

namespace ITFood
{
    public abstract class PhuongThucThanhToan
    {
        public PhuongThucThanhToan() { }

        ~PhuongThucThanhToan() { }

        public abstract bool XuLyThanhToan(double soTien);
    }
}
