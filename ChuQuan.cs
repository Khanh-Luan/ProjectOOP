using System;
using System.Collections.Generic;
using System.Text;

namespace ITFood
{
    public class ChuQuan : NguoiDung
    {
        private List<Quan> dsQuan;
        private double dTongDoanhThu;

        public double TongDoanhThu { 
            get { return this.dTongDoanhThu; } 
            set { this.dTongDoanhThu = value; }
        }

        public ChuQuan()
        {
            dsQuan = new List<Quan>();
        }

        public ChuQuan(string ma, string ten, string sdt, string email)
            : base(ma, ten, sdt, email)
        {
            dsQuan = new List<Quan>();
            dTongDoanhThu = 0;
        }

        public void ThemQuan(Quan quan)
        {
            dsQuan.Add(quan);
            quan.ChuCuaQuan = this; // sau khi thêm quán vào danh sách quán của mình thì cũng phải gán mình là chủ
        }

        public Quan TimQuan(string ma)
        {
            foreach (Quan quan in dsQuan)
            {
                if (quan.Ma == ma) return quan;
            }
            return null;
        }

        public void HienThiDsQuan()
        {
            Console.WriteLine($"Danh sach quan cua chu quan {this.sTen}");
            foreach (Quan quan in dsQuan)
            {
                Console.WriteLine($" {quan.Ma} - {quan.Ten} - {quan.DiaChi}");
            }
        }

        public override void Xuat()
        {
            Console.WriteLine("---Thong tin chu quan---");
            base.Xuat();
            Console.WriteLine($"So quan chu so huu: {dsQuan.Count}");
            Console.WriteLine($"Tong doanh thu: {this.dTongDoanhThu}đ");
        }

        // ham tinh toan so tien: cong doanh thu tu don hang cua quan minh
        public override void TinhToanTien(double soTien)
        {
            this.dTongDoanhThu = this.dTongDoanhThu + soTien;
        }
    }
}
