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

        public string DiaChiGiao { get { return sDiaChiGiao; } set { sDiaChiGiao = value; } }
        public int DiemTichLuyITFood { get { return iDiemTichLuyITFood; } set { iDiemTichLuyITFood = value; } }
        public double TongDaChi { get { return dTongDaChi; } }

        public KhachHang() { }

        public KhachHang(string ma, string ten, string sdt, string email, string diaChi)
            : base(ma, ten, sdt, email)
        {
        }

        public override void Nhap()
        {
        }

        public override void Xuat()
        {
        }

        public override void TinhToanTien(double soTien)
        {
        }
    }
}
  