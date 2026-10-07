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
            this.dPhiGiaoDich = PHI_GIAO_DICH_MAC_DINH;
        }

        public The(string soThe)
        {
            this.SoThe = soThe;
            this.dPhiGiaoDich = PHI_GIAO_DICH_MAC_DINH;
        }

        public void Nhap()
        {
            Console.WriteLine("Nhap ID the: ");
            this.sSoThe = Console.ReadLine();
            this.dPhiGiaoDich = PHI_GIAO_DICH_MAC_DINH;
        }

        public override bool XuLyThanhToan(double soTien)
        {
            double tongTien = soTien + this.dPhiGiaoDich;
            Console.WriteLine($"Da thanh toan {soTien}đ bang the {this.sSoThe} ( bao gom phi giao dich {this.dPhiGiaoDich}đ)");
            return true;
        }
    }
}
