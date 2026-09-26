using System;
using System.Collections.Generic;
using System.Text;

namespace ITFood
{
    public class ChiTietDon
    {
        private MonAn mon;
        private int iSoLuong;

        public MonAn Mon { get { return mon; } set { mon = value; } }
        public int SoLuong { get { return iSoLuong; } set { iSoLuong = value; } }

        public ChiTietDon() { }

        public ChiTietDon(MonAn mon, int soLuong)
        {
        }

        public double ThanhTien()
        {
            return 0;
        }

        public void HienThi()
        {
        }
    }
}
