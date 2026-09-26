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

        public string Ma { get { return sMa; } set { sMa = value; } }
        public string Ten { get { return sTen; } set { sTen = value; } }
        public double PhanTram { get { return dPhanTram; } set { dPhanTram = value; } }
        public bool ConSuDung { get { return bConSuDung; } }

        public Voucher() { }

        public Voucher(string ma, string ten, double phanTram)
        {
        }

        public double TinhGiam(double tienMon)
        {
        }

        public void SuDung()
        {
        }

        public void Nhap()
        {
        }

        public void Xuat()
        {
        }
    }
}
