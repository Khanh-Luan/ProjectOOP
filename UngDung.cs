using System;
using System.Collections.Generic;
using System.Text;

namespace ITFood
{
    public class UngDung
    {
        private List<KhachHang> dsKhachHang;
        private List<ChuQuan> dsChuQuan;
        private List<TaiXe> dsTaiXe;
        private List<Quan> dsQuan;
        private List<DonHang> dsDonHang;

        public List<KhachHang> DsKhachHang
        {
            get { return this.dsKhachHang; }
            set { this.dsKhachHang = value; }
        }
        public List<ChuQuan> DsChuQuan
        {
            get { return this.dsChuQuan; }
            set { this.dsChuQuan = value; }
        }
        public List<TaiXe> DsTaiXe
        {
            get { return this.dsTaiXe; }
            set { this.dsTaiXe = value; }
        }
        public List<Quan> DsQuan
        {
            get { return this.dsQuan; }
            set { this.dsQuan = value; }
        }
        public List<DonHang> DsDonHang
        {
            get { return this.dsDonHang; }
            set { this.dsDonHang = value; }
        }

        public UngDung()
        {
            this.DsKhachHang = new List<KhachHang>();
            this.DsChuQuan = new List<ChuQuan>();
            this.DsTaiXe = new List<TaiXe>();
            this.DsQuan = new List<Quan>();
            this.DsDonHang = new List<DonHang>();
        }

        public UngDung(List<KhachHang> dsKhachHang, List<ChuQuan> dsChuQuan, List<TaiXe> dsTaiXe, List<Quan> dsQuan, List<DonHang> dsDonHang)
        {
            this.DsKhachHang = dsKhachHang;
            this.DsChuQuan = dsChuQuan;
            this.DsTaiXe = dsTaiXe;
            this.DsQuan = dsQuan;
            this.DsDonHang = dsDonHang;
        }

        ~UngDung() { }

        public void ThemKhachHang(KhachHang kh)
        {
            this.dsKhachHang.Add(kh);
        }

        public void ThemChuQuan(ChuQuan cq)
        {
            this.dsChuQuan.Add(cq);
        }

        public void ThemTaiXe(TaiXe tx)
        {
            this.dsTaiXe.Add(tx);
        }

        public void ThemQuan(Quan q)
        {
            this.dsQuan.Add(q);
        }

        public TaiXe TimTaiXeRanh()
        {
            foreach (TaiXe tx in this.dsTaiXe)
            {
                if (tx.DangRanh) return tx;
            }
            return null;
        }

        public void TimTaiXeRanhVaGanDon(DonHang don)
        {
            TaiXe tx = this.TimTaiXeRanh();
            if (tx != null) 
                don.GanTaiXe(tx);   
            else 
                Console.WriteLine("Khong co tai xe ranh !!!");
        }

        public DonHang TaoDonHang(string ma, KhachHang kh, Quan quan)
        {
            //kiểm tra xem quán có mở cửa ko
            if (!quan.DangMoCua)
            {
                Console.WriteLine("Quan hien dang dong cua, khong the dat hang !!!");
                return null;
            }
            DonHang don = new DonHang(ma, kh, quan);
            this.dsDonHang.Add(don);
            return don;
        }

        public void BaoCao()
        {
            Console.WriteLine("----- BAO CAO HE THONG -----");
            int soDonHoanThanh = 0;
            int soDonHuy = 0;   
            for (int i = 0; i < this.dsDonHang.Count; i++)
            {
                if (this.dsDonHang[i].TrangThai == TrangThaiDon.HoanThanh)
                    soDonHoanThanh++;
                if (this.dsDonHang[i].TrangThai == TrangThaiDon.DaHuy)
                    soDonHuy++;
            }
            Console.WriteLine($"Don hoan thanh: {soDonHoanThanh}");
            Console.WriteLine($"Don da huy: {soDonHuy}");

            Console.WriteLine("--- Thong tin tai xe ---");
            foreach (TaiXe tx in this.dsTaiXe)
            {
                tx.Xuat();
                Console.WriteLine();
            }
        }
    }
}
