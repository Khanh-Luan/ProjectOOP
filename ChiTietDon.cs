using System;
using System.Collections.Generic;
using System.Text;

namespace ITFood
{
    public class ChiTietDon
    {
        private MonAn mon;
        private int iSoLuong;

        public MonAn Mon { 
            get { return this.mon; } 
            set { this.mon = value; } 
        }
        public int SoLuong { 
            get { return this.iSoLuong; } 
            set { this.iSoLuong = value; } 
        }

        public ChiTietDon() { }

        public ChiTietDon(MonAn mon, int soLuong)
        {
            this.mon = mon;
            this.SoLuong = soLuong;
        }

        public double ThanhTien()
        {
            return this.mon.Gia * this.iSoLuong;
        }

        public void HienThi()
        {
            Console.WriteLine($"{this.mon.Ten} x {this.iSoLuong} = {ThanhTien()}đ");
        }
    }
}
