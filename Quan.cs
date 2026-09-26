using ProjectOOP;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITFood
{
    public class Quan
    {
        private string sMa;
        private string sTen;
        private string sDiaChi;
        private bool bDangMoCua;
        private List<MonAn> menu;
        private List<Voucher> dsVoucher;
        private ChuQuan chuQuan;

        public string Ma { get { return sMa; } set { sMa = value; } }
        public string Ten { get { return sTen; } set { sTen = value; } }
        public string DiaChi { get { return sDiaChi; } set { sDiaChi = value; } }
        public bool DangMoCua { get { return bDangMoCua; } set { bDangMoCua = value; } }
        public ChuQuan ChuCuaQuan { get { return chuQuan; } set { chuQuan = value; } }

        public Quan()
        {
        }

        public Quan(string ma, string ten, string diaChi)
        {
        }

        public void Nhap()
        {
        }

        public void ThemMon(MonAn mon)
        {
        }

        public MonAn TimMon(string ma)
        {
        }

        public void HienThiMenu()
        {
        }

        public void ThemVoucher(Voucher v)
        {
        }

        public Voucher TimVoucher(string ma)
        {
        }

        public bool CoVoucher()
        {
        }

        public void HienThiVoucherConDung()
        {
        }

        public void HienThiVoucherDaDung()
        {
        }

        public void Xuat()
        {
        }

        public void NhanDon(DonHang don)
        {
        }
    }
}
