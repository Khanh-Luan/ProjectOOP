using System;
using System.Collections.Generic;
using System.Text;

namespace ITFood
{
    public class TaiXe : NguoiDung
    {
        private string sBienSo;
        private bool bDangRanh;
        private int iSoDonDaGiao;
        private double dTongThuNhap;

        public string BienSo { 
            get { return this.sBienSo; } 
            set { this.sBienSo = value; } 
        }
        public bool DangRanh { 
            get { return this.bDangRanh; } 
            set { this.bDangRanh = value; } 
        }
        public int SoDonDaGiao { 
            get { return this.iSoDonDaGiao; } 
            set { this.iSoDonDaGiao = value; } 
        }
        public double TongThuNhap { 
            get { return this.dTongThuNhap; } 
            set { this.dTongThuNhap = value; }
        }

        public TaiXe()
        {
            this.DangRanh = true;
        }

        public TaiXe(string ma, string ten, string sdt, string email, string bienSo)
            : base(ma, ten, sdt, email)
        {
            this.BienSo = bienSo;
            this.DangRanh = true;
            this.SoDonDaGiao = 0;
            this.TongThuNhap = 0;
        }

        public override void TinhToanTien(double soTien) // Tai xe nhan het phi ship cua don hang
        {
            this.TongThuNhap = this.TongThuNhap + soTien;   
        }

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhap bien so xe: ");
            this.BienSo = Console.ReadLine();
        }

        public override void Xuat()
        {
            Console.WriteLine("---Thong tin tai xe---");
            base.Xuat();
            Console.WriteLine($"Bien so xe {this.sBienSo}");
            Console.WriteLine($"Dang ranh: {this.bDangRanh}");
            Console.WriteLine($"So don da giao: {this.iSoDonDaGiao}");
            Console.WriteLine($"Tong thu nhap: {this.dTongThuNhap}");
        }

        public void HoanThanhGiao()
        {
            this.iSoDonDaGiao = this.iSoDonDaGiao + 1;
            this.bDangRanh = true;
        }
    }
}
