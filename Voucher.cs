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
        private bool bConSuDung;
        // properties

        public string Ma { 
            get { return this.sMa; } 
            set { this.sMa = value; } 
        }
        public double PhanTram { 
            get { return this.dPhanTram; } 
            set { this.dPhanTram = value; } 
        }
        public bool ConSuDung
        {
            get { return this.bConSuDung; }
            set { this.bConSuDung = value; }
        }
        // Constructors
        public Voucher() {}
        public Voucher(string ma, double phanTram, bool suDung)
        {
            this.Ma = ma;
            this.PhanTram = phanTram;
            this.ConSuDung = false;
        }
        //method
        public void Nhap()
        {
            Console.WriteLine("Nhap ma voucher: ");
            this.sMa = Console.ReadLine();
            Console.WriteLine("Nhap pham tram: ");
            this.dPhanTram = Convert.ToDouble(Console.ReadLine());
            bConSuDung = false;
        }
        public double TinhGiam(double tienMon)
        {
            if (bConSuDung)
                return 0;
            return tienMon * dPhanTram / 100;
        }
    }
}
