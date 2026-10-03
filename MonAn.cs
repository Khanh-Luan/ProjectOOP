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

        public string Ma { 
            get { return this.sMa; } 
            set { this.sMa = value; } 
        }
        public string Ten { 
            get { return this.sTen; } 
            set { this.sTen = value; }
        }
        public double Gia
        {
            get { return this.dGia; }
            set { if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Gia cua mon an phai > 0.");
                this.dGia = value;
            }
        }

        public MonAn() { }

        public MonAn(string ma, string ten, double gia)
        {
            this.Ma = ma;
            this.Ten = ten;
            this.Gia = gia;
        }

        public void Nhap()
        {
            Console.Write("Nhap ma mon an: ");
            this.Ma = Console.ReadLine();
            Console.Write("Nhap ten mon an: ");
            this.Ten = Console.ReadLine();
            Console.Write("Nhap gia mon an: ");
            this.Gia = Convert.ToDouble(Console.ReadLine());
        }

        public void HienThi()
        {
            Console.WriteLine($"Mon an {this.sMa} - {this.sTen} | Gia tien: {this.dGia}");
        }
    }
}
