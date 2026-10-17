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

        // 1. Tìm kiếm Quán theo mã
        public Quan TimQuan(string ma)
        {
            foreach (Quan q in this.dsQuan)
            {
                if (q.Ma == ma) return q;
            }
            return null;
        }

        // 2. Tìm kiếm Khách hàng theo mã
        public KhachHang TimKhachHang(string ma)
        {
            foreach (KhachHang kh in this.dsKhachHang)
            {
                if (kh.Ma == ma) return kh;
            }
            return null;
        }

        // 3. Hiển thị danh sách Quán hiện có
        public void HienThiDsQuan()
        {
            Console.WriteLine("\n--- DANH SACH QUAN HIEN CO ---");
            foreach (Quan q in this.dsQuan)
            {
                Console.WriteLine($"[{q.Ma}] {q.Ten} - Dia chi: {q.DiaChi}");
            }
        }

        // 4. Hiển thị danh sách Khách hàng hiện có
        public void HienThiDsKhachHang()
        {
            Console.WriteLine("\n--- DANH SACH KHACH HANG ---");
            foreach (KhachHang kh in this.dsKhachHang)
            {
                Console.WriteLine($"[{kh.Ma}] {kh.Ten} - SDT: {kh.SDT}");
            }
        }

        // 5. HÀM NẠP DỮ LIỆU MẪU (Mock Data)
        public void KhoiTaoDuLieuMau()
        {
            // Tạo 2 chủ quán
            ChuQuan cq1 = new ChuQuan("CQ01", "Nguyen Van Chu", "0901111111", "chu1@food.vn");
            ChuQuan cq2 = new ChuQuan("CQ02", "Tran Thi Chu", "0902222222", "chu2@food.vn");
            this.ThemChuQuan(cq1);
            this.ThemChuQuan(cq2);

            // Quán 1: Cơm Tấm
            Quan q1 = new Quan("Q01", "Com Tam Sai Gon", "123 Nguyen Trai, Q5");
            cq1.ThemQuan(q1);
            q1.ThemMon(new MonAn("M01", "Com Suon Bi Cha", 45000));
            q1.ThemMon(new MonAn("M02", "Com Suon Trung", 40000));
            q1.ThemMon(new MonAn("M03", "Canh Kho Qua", 15000));
            q1.ThemVoucher(new Voucher("GIAM10", "Giam 10%", 10));
            q1.ThemVoucher(new Voucher("GIAM20", "Giam 20%", 20));
            this.ThemQuan(q1);

            // Quán 2: Trà Sữa
            Quan q2 = new Quan("Q02", "Tra Sua Gong Cha", "456 Le Loi, Q1");
            cq2.ThemQuan(q2);
            q2.ThemMon(new MonAn("TS01", "Tra Sua Tran Chau", 35000));
            q2.ThemMon(new MonAn("TS02", "Tra Dao Cam Sa", 30000));
            q2.ThemVoucher(new Voucher("GIAM15", "Giam 15%", 15));
            this.ThemQuan(q2);

            // Tạo 2 khách hàng
            KhachHang kh1 = new KhachHang("KH01", "Nguyen Van An", "0911222333", "an@gmail.com", "789 Tran Hung Dao");
            KhachHang kh2 = new KhachHang("KH02", "Le Thi Binh", "0944555666", "binh@gmail.com", "101 Nguyen Hue");
            this.ThemKhachHang(kh1);
            this.ThemKhachHang(kh2);

            // Tạo 2 tài xế
            TaiXe tx1 = new TaiXe("TX01", "Tran Van Chay", "0977888999", "chay@food.vn", "59X1-12345");
            TaiXe tx2 = new TaiXe("TX02", "Pham Van Giao", "0988777666", "giao@food.vn", "59Y2-67890");
            this.ThemTaiXe(tx1);
            this.ThemTaiXe(tx2);

            Console.WriteLine(">> Da nhap thanh cong: 2 Quan (kem Menu, Voucher), 2 Khach hang, 2 Tai xe!");
        }
    }
}
