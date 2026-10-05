using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOOP
{
    public class KhachHang : NguoiDung
    {
        private string sDiaChiGiao;
        private int iDiemTichLuyITFood;
        private double dTongDaChi;

        public string DiaChiGiao { 
            get { return this.sDiaChiGiao; } 
            set { this.sDiaChiGiao = value; } 
        }
        public int DiemTichLuyITFood { 
            get { return this.iDiemTichLuyITFood; }
            set { this.iDiemTichLuyITFood = value; }
        }
        public double TongDaChi { 
            get { return this.dTongDaChi; }
            set { this.dTongDaChi = value; }
        }

        public KhachHang() { }

        public KhachHang(string ma, string ten, string sdt, string email, string diaChi)
            : base(ma, ten, sdt, email)
        {
            this.DiaChiGiao = diaChi;
            this.DiemTichLuyITFood = 0;
            this.TongDaChi = 0; 
        }

        public override void Nhap()
        {
            Console.WriteLine("!! Khach hang !!");
            base.Nhap();
            Console.Write("Nhap dia chi giao: ");
            this.DiaChiGiao = Console.ReadLine();
        }

        public override void Xuat()
        {

            Console.WriteLine("---Thong tin khach hang---");
            base.Xuat();
            Console.WriteLine($"Dia chi giao: {this.sDiaChiGiao}");
            Console.WriteLine($"Diem tich luy ITFood: {this.iDiemTichLuyITFood}");
            Console.WriteLine($"Tong da chi: {this.dTongDaChi}đ");
        }

        public override void TinhToanTien(double soTien) // Cong don tong da chi va diem tich luy
        {
            this.dTongDaChi = this.dTongDaChi + soTien;
            this.iDiemTichLuyITFood = this.iDiemTichLuyITFood + (int)(soTien / 10000);
        }
    }
}
