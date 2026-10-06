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
            Console.WriteLine("--- Thong tin cua quan ---");
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

        public MonAn TimMon(string ma) // string thì trả về chuỗi chữ, Class trả về một object
        {
            foreach (MonAn mon in menu)
            {
                if (mon.Ma == ma) return mon;
            }
            return null;
        }

        public void HienThiMenu()
        {
            Console.WriteLine($"--- Menu cua quan {this.sTen} ---");
            foreach (MonAn mon in menu)
            {
                Console.WriteLine($" {mon.Ma} - {mon.Ten} - {mon.Gia} ");
            }
        }
        // Quản lí voucher của quán
        public void ThemVoucher(Voucher v)
        {
            dsVoucher.Add(v);
        }

        public Voucher TimVoucher(string ma)
        {
            foreach (Voucher v in dsVoucher)
            {
                if (v.Ma == ma) return v;
            }
            return null;
        }

        public bool CoVoucher()
        {
            foreach (Voucher v in dsVoucher)
            {
                if (v.ConSuDung) return true;
            }
            return false;
        }

        public void HienThiVoucherConDung()
        {
            Console.WriteLine($"Voucher hien co cua quan {this.sTen}: ");
            foreach (Voucher v in dsVoucher)
            {
                if (v.ConSuDung) v.Xuat();
            }
        }

        public void HienThiVoucherDaDung()
        {
            Console.WriteLine($"Voucher da dung cua quan {this.sTen}: ");
            foreach (Voucher v in dsVoucher)
            {
                if (!v.ConSuDung) v.Xuat();
            }
        }

        public void Xuat()
        {
            Console.WriteLine($"===== THONG TIN QUAN =====");
            Console.WriteLine($"Ma quan: {this.sMa}");
            Console.WriteLine($"Ten quan: {this.sTen}");
            Console.WriteLine($"Dia chi: {this.sDiaChi}");
            Console.WriteLine($"Dang mo cua: {this.bDangMoCua}");
            Console.WriteLine($"So mon trong menu: {menu.Count}");
            Console.WriteLine($"So voucher: {dsVoucher.Count}");
            if (chuQuan != null)
            {
                Console.WriteLine($"Chu quan: {chuQuan.Ten} (Ma: {chuQuan.Ma})");
                Console.WriteLine($"Doanh thu cua chu: {chuQuan.TongDoanhThu}d");
            }
        }

        //public void NhanDon(DonHang don)
        //{
        //    Console.WriteLine($"[Thong bao quan {this.sTen}] Nhan duoc don {don.Ma}, bat dau lam mon!!!");
        //    don.CapNhatTrangThai(TrangThaiDon.DangLam);
        //}
    }
}
