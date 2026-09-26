using System;
using System.Collections.Generic;
using System.Text;

namespace ITFood
{
    public class ChuQuan : NguoiDung
    {
        private List<Quan> dsQuan;
        private double dTongDoanhThu;

        public double TongDoanhThu { get { return dTongDoanhThu; } }

        public ChuQuan()
        {
        }

        public ChuQuan(string ma, string ten, string sdt, string email)
            : base(ma, ten, sdt, email)
        {
        }

        public void ThemQuan(Quan quan)
        {
        }

        public Quan TimQuan(string ma)
        {
            return null;
        }

        public void HienThiDsQuan()
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
