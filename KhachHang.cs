using System;
using System.Collections.Generic;
using System.Text;

namespace ITFood
{
    public class KhachHang : NguoiDung
    {
        private string sDiaChiGiao;
        private int iDiemTichLuyITFood;
        private double dTongDaChi;

        public string DiaChiGiao
        {
            get { return this.sDiaChiGiao; }
            set { this.sDiaChiGiao = value; }
        }
        public int DiemTichLuyITFood
        {
            get { return this.iDiemTichLuyITFood; }
            set { this.iDiemTichLuyITFood = value; }
        }
        public double TongDaChi
        {
            get { return this.dTongDaChi; }
            set { this.dTongDaChi = value; }
        }

        public KhachHang()
        {
            this.DiemTichLuyITFood = 0;
            this.TongDaChi = 0;
        }

        public KhachHang(string ma, string ten, string sdt, string email, string diaChi)
            : base(ma, ten, sdt, email)
        {
            this.DiaChiGiao = diaChi;
            this.DiemTichLuyITFood = 0;
            this.TongDaChi = 0; 
        }

        ~KhachHang() { }

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhap dia chi giao: ");
            this.DiaChiGiao = Console.ReadLine();
        }

        public override void Xuat()
        {

            Console.WriteLine("---- Thong tin khach hang ----");
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

        public PhuongThucThanhToan ChonPhuongThucThanhToan()
        {
            Console.WriteLine("Chon phuong thuc thanh toan:");
            Console.WriteLine("1 - Tien mat");
            Console.WriteLine("2 - Vi dien tu");
            Console.WriteLine("3 - The");
            Console.Write("Lua chon: ");

            string chon = Console.ReadLine();

            switch (chon)
            {
                case "2":
                    ViDienTu vi = new ViDienTu();
                    vi.Nhap();
                    return vi;
                case "3":
                    The the = new The();
                    the.Nhap();
                    return the;
                default:
                    return new TienMat();
            }
        }
    }
}
