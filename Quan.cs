using ProjectOOP;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITFood
{
    public class Quan
    {
        private string sMa;
        private string sTen;
        private string sDiaChi;
        private bool bDangMoCua;
        private List<MonAn> menu;
        private List<Voucher> dsVoucher;
        private ChuQuan chuQuan;

        public string Ma { 
            get { return this.sMa; } 
            set { this.sMa = value; } 
        }
        public string Ten { 
            get { return this.sTen; } 
            set { this.sTen = value; } 
        }
        public string DiaChi { 
            get { return this.sDiaChi; } 
            set { this.sDiaChi = value; } 
        }
        public bool DangMoCua { 
            get { return this.bDangMoCua; } 
            set { this.bDangMoCua = value; } 
        }
        public ChuQuan ChuCuaQuan { 
            get { return this.chuQuan; } 
            set { this.chuQuan = value; } 
        }

        public Quan() // Quán sẽ có menu dang sách món ăn, danh sách voucher
        {
            this.menu = new List<MonAn>();
            this.dsVoucher = new List<Voucher>();
            this.bDangMoCua = true;
        }

        public Quan(string ma, string ten, string diaChi)
        {
            this.Ma = ma;
            this.Ten = ten;
            this.DiaChi = diaChi;
            this.bDangMoCua = true;
            this.menu = new List<MonAn>();
            this.dsVoucher = new List<Voucher>();
        }

        public void Nhap()
        {
            Console.WriteLine("Nhap ma quan: ");
            this.Ma = Console.ReadLine();
            Console.WriteLine("Nhap ten quan: ");
            this.Ten = Console.ReadLine();
            Console.WriteLine("Nhap dia chi cua quan: ");
            this.DiaChi = Console.ReadLine();
            this.bDangMoCua = true;
        }

        public void ThemMon(MonAn mon)
        {
            menu.Add(mon);
        }

        public MonAn TimMon(string ma)
        {
            foreach (MonAn mon in menu)
            {
                if (mon.Ma == ma) return mon;
            }
            return null;
        }

        public void HienThiMenu()
        {
        }

        public void ThemVoucher(Voucher v)
        {
        }

        public Voucher TimVoucher(string ma)
        {
        }

        public bool CoVoucher()
        {
        }

        public void HienThiVoucherConDung()
        {
        }

        public void HienThiVoucherDaDung()
        {
        }

        public void Xuat()
        {
        }

        public void NhanDon(DonHang don)
        {
        }
    }
}
