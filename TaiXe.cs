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

        public string BienSo { get { return sBienSo; } set { sBienSo = value; } }
        public bool DangRanh { get { return bDangRanh; } set { bDangRanh = value; } }
        public int SoDonDaGiao { get { return iSoDonDaGiao; } set { iSoDonDaGiao = value; } }
        public double TongThuNhap { get { return dTongThuNhap; } }

        public TaiXe()
        {
        }

        public TaiXe(string ma, string ten, string sdt, string email, string bienSo)
            : base(ma, ten, sdt, email)
        {
        }

        public override void TinhToanTien(double soTien)
        {
        }

        public override void Nhap()
        {
        }

        public override void Xuat()
        {
        }

        public void HoanThanhGiao()
        {
        }
    }
}
