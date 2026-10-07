using System;
using System.Collections.Generic;
using System.Text;

namespace ITFood
{
    public class ViDienTu : PhuongThucThanhToan
    {
        private double dSoDu;
        public double SoDu
        {
            get { return this.dSoDu; }
            set { this.dSoDu = value; }
        }

        public ViDienTu() { }

        public ViDienTu(double soDu)
        {
            this.SoDu = soDu;
        }

        public void Nhap()
        {
            Console.WriteLine("Nhap so du vi: ");
            this.dSoDu = Convert.ToDouble(Console.ReadLine());
        }

        public override bool XuLyThanhToan(double soTien)
        {
            if (this.dSoDu < soTien)
            {
                Console.WriteLine("So du vi hien tai khong du!!!");
                return false;
            }
            this.dSoDu = this.dSoDu - soTien;
            Console.WriteLine($"Da thanh toan {soTien}đ bang vi dien tu. So du con lai: {this.dSoDu}đ");
            return true;
        }
    }
}
