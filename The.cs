using System;
using System.Collections.Generic;
using System.Text;

namespace ITFood
{
    public class The : PhuongThucThanhToan
    {
        private static double PHI_GIAO_DICH_MAC_DINH = 3000;

        private string sSoThe;
        private double dPhiGiaoDich;
        public static double PhiGiaoDichMacDinh
        {
            get { return The.PHI_GIAO_DICH_MAC_DINH; }
            set { The.PHI_GIAO_DICH_MAC_DINH = value; }
        }
        public string SoThe
        {
            get { return this.sSoThe; }
            set { this.sSoThe = value; }
        }
        public double PhiGiaoDich
        {
            get { return this.dPhiGiaoDich; }
            set { this.dPhiGiaoDich = value; }
        }

        public The()
        {
            this.PhiGiaoDich = The.PHI_GIAO_DICH_MAC_DINH;
        }

        public The(string soThe)
        {
            this.SoThe = soThe;
            this.PhiGiaoDich = The.PHI_GIAO_DICH_MAC_DINH;
        }

        public void Nhap()
        {
            Console.WriteLine("Nhap ID the: ");
            this.SoThe = Console.ReadLine();
            this.PhiGiaoDich = The.PHI_GIAO_DICH_MAC_DINH;
        }

        public override bool XuLyThanhToan(double soTien)
        {
            double tongTien = soTien + this.dPhiGiaoDich;
            Console.WriteLine($"Da thanh toan {soTien}đ bang the {this.sSoThe} + phi giao dich {this.dPhiGiaoDich}đ (Tong tru vao the: {tongTien}đ)");
            return true;
        }
    }
}
