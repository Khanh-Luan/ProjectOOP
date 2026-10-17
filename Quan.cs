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

        public string Ma
        {
            get { return this.sMa; }
            set { this.sMa = value; }
        }
        public string Ten
        {
            get { return this.sTen; }
            set { this.sTen = value; }
        }
        public string DiaChi
        {
            get { return this.sDiaChi; }
            set { this.sDiaChi = value; }
        }
        public bool DangMoCua
        {
            get { return this.bDangMoCua; }
            set { this.bDangMoCua = value; }
        }
        public List<MonAn> Menu
        {
            get { return this.menu; }
            set { this.menu = value; }
        }
        public List<Voucher> DsVoucher
        {
            get { return this.dsVoucher; }
            set { this.dsVoucher = value; }
        }
        public ChuQuan ChuCuaQuan
        {
            get { return this.chuQuan; }
            set { this.chuQuan = value; }
        }

        public Quan()
        {
            this.Menu = new List<MonAn>();
            this.DsVoucher = new List<Voucher>();
            this.DangMoCua = true;
        }

        public Quan(string ma, string ten, string diaChi)
        {
            this.Ma = ma;
            this.Ten = ten;
            this.DiaChi = diaChi;
            this.DangMoCua = true;
            this.Menu = new List<MonAn>();
            this.DsVoucher = new List<Voucher>();
        }

        ~Quan() { }

        public void Nhap()
        {
            Console.Write("Nhap ma quan: ");
            this.Ma = Console.ReadLine();
            Console.Write("Nhap ten quan: ");
            this.Ten = Console.ReadLine();
            Console.Write("Nhap dia chi cua quan: ");
            this.DiaChi = Console.ReadLine();
            this.DangMoCua = true;
        }

        public void ThemMon(MonAn mon)
        {
            this.menu.Add(mon);
        }

        public MonAn TimMon(string ma)
        {
            foreach (MonAn mon in this.menu)
            {
                if (mon.Ma == ma) return mon;
            }
            return null;
        }

        public void HienThiMenu()
        {
            Console.WriteLine($"--- Menu cua quan {this.sTen} ---");
            foreach (MonAn mon in this.menu)
            {
                Console.WriteLine($" {mon.Ma} - {mon.Ten} - {mon.Gia} ");
            }
        }
        // Quản lí voucher của quán
        public void ThemVoucher(Voucher v)
        {
            this.dsVoucher.Add(v);
        }

        public Voucher TimVoucher(string ma)
        {
            foreach (Voucher v in this.dsVoucher)
            {
                if (v.Ma == ma) return v;
            }
            return null;
        }

        public bool CoVoucher()
        {
            foreach (Voucher v in this.dsVoucher)
            {
                if (v.ConSuDung) return true;
            }
            return false;
        }

        public void HienThiVoucherConDung()
        {
            Console.WriteLine($"Voucher hien co cua quan {this.sTen}: ");
            foreach (Voucher v in this.dsVoucher)
            {
                if (v.ConSuDung) v.Xuat();
            }
        }

        public void HienThiVoucherDaDung()
        {
            Console.WriteLine("\n---- VOUCHER DA DUNG ----");
            Console.WriteLine($"Voucher da dung cua quan {this.sTen}: ");
            foreach (Voucher v in this.dsVoucher)
            {
                if (!v.ConSuDung) v.Xuat();
            }
        }

        public void Xuat()
        {
            Console.WriteLine($"---- THONG TIN QUAN ----");
            Console.WriteLine($"Ma quan: {this.sMa}");
            Console.WriteLine($"Ten quan: {this.sTen}");
            Console.WriteLine($"Dia chi: {this.sDiaChi}");
            Console.WriteLine($"Dang mo cua: {this.bDangMoCua}");
            Console.WriteLine($"So mon trong menu: {this.menu.Count}");
            Console.WriteLine($"So voucher: {this.dsVoucher.Count}");
            if (this.chuQuan != null)
            {
                Console.WriteLine($"Chu quan: {this.chuQuan.Ten} (Ma: {this.chuQuan.Ma})");
                Console.WriteLine($"Doanh thu cua chu: {this.chuQuan.TongDoanhThu}d");
            }
        }

        public void NhanDon(DonHang don)
        {
            Console.WriteLine($"[Thong bao quan {this.sTen}] Nhan duoc don {don.Ma}, bat dau lam mon!!!");
            don.CapNhatTrangThai(TrangThaiDon.DangLam);
        }

        public void NhapMenu()
        {
            Console.WriteLine("Nhap so mon trong menu: ");
            int soMonMenu = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < soMonMenu; i++)
            {
                Console.WriteLine($"\n--- Nhap mon {i + 1} ---");
                MonAn mon = new MonAn();
                mon.Nhap();
                this.ThemMon(mon);
            }
        }

        public void NhapVoucher()
        {
            Console.WriteLine("Nhap so voucher cua quan: ");
            int soVoucher = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < soVoucher; i++)
            {
                Console.WriteLine($"\n--- Nhap voucher {i + 1} ---");
                Voucher v = new Voucher();
                v.Nhap();
                this.ThemVoucher(v);
            }
        }

        public string ChonVoucher()
        {
            if (!this.CoVoucher())
            {
                Console.WriteLine("Quan nay hien khong co voucher khuyen mai.");
                return null;
            }

            this.HienThiVoucherConDung();
            Console.WriteLine("Nhap ma voucher muon dung (bo trong neu khong dung): ");
            string maVoucher = Console.ReadLine();
            return maVoucher;
        }
    }
}
