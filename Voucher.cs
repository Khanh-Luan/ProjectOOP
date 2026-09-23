using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOOP
{
    internal class Voucher
    {
        // fields
        private string sMa;
        private double dPhanTram;
        private bool bConSuDungDuoc;
        // properties

        public string Ma { 
            get { return this.sMa; } 
            set { this.sMa = value; } 
        }
        public double PhanTram { 
            get { return this.dPhanTram; } 
            set { this.dPhanTram = value; } 
        }
        public bool ConSuDungDuoc
        {
            get { return this.bConSuDungDuoc; }
            set { this.bConSuDungDuoc = value; }
        }
        // Constructors
        public Voucher() {}
        public Voucher(string ma, double phanTram, bool suDung)
        {
            this.Ma = ma;
            this.PhanTram = phanTram;
            this.bConSuDungDuoc = suDung;
        }
        //method
        public void Nhap()
        {
            Console.WriteLine("Nhap ma voucher: ");
            this.sMa = Console.ReadLine();
            Console.WriteLine("Nhap pham tram: ");
            this.dPhanTram = Convert.ToDouble(Console.ReadLine());
            bConSuDungDuoc = true;
        }
        public double TinhGiam(double tienMon)
        {
            if (!bConSuDungDuoc)
                return 0;
            return tienMon * dPhanTram / 100;
        }
        public void Xuat()
        {
            Console.WriteLine($"Ma voucher: {sMa} - Giam {dPhanTram}% - Con su dung duoc {bConSuDungDuoc}");
        }
    }
}
