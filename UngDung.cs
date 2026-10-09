using ProjectOOP;
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

        public UngDung()
        {
            dsKhachHang = new List<KhachHang>();
            dsChuQuan = new List<ChuQuan>();
            dsTaiXe = new List<TaiXe>();
            dsQuan = new List<Quan>();
            dsDonHang = new List<DonHang>();
        }

        public void ThemKhachHang(KhachHang kh)
        {
            dsKhachHang.Add(kh);
        }

        public void ThemChuQuan(ChuQuan cq)
        {
            dsChuQuan.Add(cq);
        }

        public void ThemTaiXe(TaiXe tx)
        {
            dsTaiXe.Add(tx);
        }

        public void ThemQuan(Quan q)
        {
            dsQuan.Add(q);
        }

        public TaiXe TimTaiXeRanh()
        {
            foreach (TaiXe tx in dsTaiXe)
            {
                if (tx.DangRanh) return tx;
            }
            return null;
        }

        public void TimTaiXeRanhVaGanDon(DonHang don)
        {
            TaiXe tx = TimTaiXeRanh();
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
            dsDonHang.Add(don);
            return don;
        }

        public void BaoCao()
        {
            Console.WriteLine("----- BAO CAO HE THONG -----");
            int soDonHoanThanh = 0;
            int soDonHuy = 0;   
            for (int i = 0; i < dsDonHang.Count; i++)
            {
                if (dsDonHang[i].TrangThai == TrangThaiDon.HoanThanh)
                    soDonHoanThanh++;
                if (dsDonHang[i].TrangThai == TrangThaiDon.DaHuy)
                    soDonHuy++;
            }
            Console.WriteLine($"Don hoan thanh: {soDonHoanThanh}");
            Console.WriteLine($"Don da huy: {soDonHuy}");

            Console.WriteLine("--- Thong tin tai xe ---");
            foreach (TaiXe tx in dsTaiXe)
            {
                tx.Xuat();
                Console.WriteLine();
            }
        }
    }
}
