using System;
using System.Collections.Generic;
using System.Text;

namespace ITFood
{
    public class ChuQuan : NguoiDung
    {
        private List<Quan> dsQuan;
        private double dTongDoanhThu;

        public List<Quan> DsQuan
        {
            get { return this.dsQuan; }
            set { this.dsQuan = value; }
        }
        public double TongDoanhThu
        {
            get { return this.dTongDoanhThu; }
            set { this.dTongDoanhThu = value; }
        }

        public ChuQuan()
        {
            this.DsQuan = new List<Quan>();
            this.TongDoanhThu = 0;
        }

        public ChuQuan(string ma, string ten, string sdt, string email)
            : base(ma, ten, sdt, email)
        {
            this.DsQuan = new List<Quan>();
            this.TongDoanhThu = 0;
        }

        ~ChuQuan() { }

        public void ThemQuan(Quan quan)
        {
            this.dsQuan.Add(quan);
            quan.ChuCuaQuan = this; // Gán chủ quán cho quán vừa thêm
        }

        public Quan TimQuan(string ma)
        {
            foreach (Quan quan in this.dsQuan)
            {
                if (quan.Ma == ma) return quan;
            }
            return null;
        }

        public void HienThiDsQuan()
        {
            Console.WriteLine($"Danh sach quan cua chu quan {this.sTen}");
            foreach (Quan quan in this.dsQuan)
            {
                Console.WriteLine($" {quan.Ma} - {quan.Ten} - {quan.DiaChi}");
            }
        }

        public override void Xuat()
        {
            Console.WriteLine("---Thong tin chu quan---");
            base.Xuat();
            Console.WriteLine($"So quan chu so huu: {this.dsQuan.Count}");
            Console.WriteLine($"Tong doanh thu: {this.dTongDoanhThu}đ");
        }

        // ham tinh toan so tien: cong doanh thu tu don hang cua quan minh
        public override void TinhToanTien(double soTien)
        {
            this.dTongDoanhThu = this.dTongDoanhThu + soTien;
        }
    }
}
