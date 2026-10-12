using System;
using System.Collections.Generic;
using System.Text;

namespace ITFood
{
    public abstract class NguoiDung
    {
        protected string sMa;
        protected string sTen;
        protected string sSDT;
        protected string sEmail;

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
        public string SDT
        {
            get { return this.sSDT; }
            set { this.sSDT = value; }
        }
        public string Email
        {
            get { return this.sEmail; }
            set { this.sEmail = value; }
        }

        public NguoiDung() { }

        public NguoiDung(string ma, string ten, string sdt, string email)
        {
            this.Ma = ma;
            this.Ten = ten;
            this.SDT = sdt;
            this.Email = email;
        }

        ~NguoiDung() { }

        public virtual void Nhap()
        {
            Console.Write("Nhap ma: ");
            this.Ma = Console.ReadLine();
            Console.Write("Nhap ten: ");
            this.Ten = Console.ReadLine();
            Console.Write("Nhap so dien thoai: ");
            this.SDT = Console.ReadLine();
            Console.Write("Nhap email: ");
            this.Email = Console.ReadLine();
        }

        public virtual void Nhap(string ma, string ten, string sdt, string email)
        {
            this.Ma = ma;
            this.Ten = ten;
            this.SDT = sdt;
            this.Email = email;
        }

        public virtual void Xuat()
        {
            Console.WriteLine($"Ma: {this.Ma}");
            Console.WriteLine($"Ten: {this.Ten}");
            Console.WriteLine($"So dien thoai: {this.SDT}");
            Console.WriteLine($"Email: {this.Email}");
        }

        public abstract void TinhToanTien(double soTien);
    }
}