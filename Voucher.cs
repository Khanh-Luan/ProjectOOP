using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOOP
{
    public class Voucher
    {
        private string sMa;
        private string sTen;
        private double dPhanTram;
        private bool bConSuDung;

        public string Ma { 
            get { return this.sMa; } 
            set { this.sMa = value; } 
        }
        public string Ten { 
            get { return this.sTen; } 
            set { this.sTen = value; } 
        }
        public double PhanTram { 
            get { return this.dPhanTram; }
            set { if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Phan tram giam phai lon hon 0%.");
                  this.dPhanTram = value; }
        }
        public bool ConSuDung { 
            get { return this.bConSuDung; }
        }

        public Voucher() { }

        public Voucher(string ma, string ten, double phanTram)
        {
            this.Ma = ma;
            this.Ten = ten;
            this.PhanTram = phanTram;
            this.bConSuDung = true;
        }

        public double TinhGiam(double tienMon)
        {
            if (bConSuDung) 
                return tienMon * PhanTram / 100;
            return 0;
        }

        public void SuDung()
        {
            this.bConSuDung = false;
        }

        public void Nhap()
        {
            Console.Write("Nhap ma cua voucher: ");
            this.Ma = Console.ReadLine();
            Console.Write("Nhap ten cua voucher: ");
            this.Ten = Console.ReadLine();
            Console.Write("Nhap phan tram cua voucher: ");
            this.PhanTram = Convert.ToDouble(Console.ReadLine());
            this.bConSuDung = true;
        }

        public void HienThi()
        {
            Console.WriteLine($"Voucher {this.sMa} - {this.sTen} - Giam {this.dPhanTram}% - Con su dung: {this.bConSuDung}");
        }
    }
}
