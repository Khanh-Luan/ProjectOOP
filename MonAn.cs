using System;
using System.Collections.Generic;
using System.Text;

namespace ITFood
{
    public class MonAn
    {
        protected string sMa;
        protected string sTen;
        protected double dGia;

        public string Ma { get { return sMa; } set { sMa = value; } }
        public string Ten { get { return sTen; } set { sTen = value; } }
        public double Gia
        {
            get { return dGia; }
            set
            {
                dGia = value;
            }
        }

        public MonAn() { }

        public MonAn(string ma, string ten, double gia)
        {
        }

        public virtual void Nhap()
        {
        }

        public virtual void HienThi()
        {
        }
    }
}
