using System;
using System.Collections.Generic;
using System.Text;

namespace ITFood
{
    public class DonHang
    {
        private static double Chiet_khau_cua_quan = 0.25;
        private static double Chiet_khau_cua_tai_xe = 0.20;
        private static double Phi_nen_tang = 3000;
        private string sMa;
        private KhachHang khach;
        private Quan quan;
        private TaiXe taiXe;
        private List<ChiTietDon> dsChiTiet;
        private double dKhoangCachKm;
        private TrangThaiDon trangThai;
        private PhuongThucThanhToan thanhToan;
        private double dSoTienDaThanhToan;
        private double dSoTienGiamGia;

        public static double ChietKhauCuaQuan
        {
            get { return DonHang.Chiet_khau_cua_quan; }
            set { DonHang.Chiet_khau_cua_quan = value; }
        }
        public static double ChietKhauCuaTaiXe
        {
            get { return DonHang.Chiet_khau_cua_tai_xe; }
            set { DonHang.Chiet_khau_cua_tai_xe = value; }
        }
        public static double PhiNenTang
        {
            get { return DonHang.Phi_nen_tang; }
            set { DonHang.Phi_nen_tang = value; }
        }
        public string Ma
        {
            get { return this.sMa; }
            set { this.sMa = value; }
        }
        public KhachHang Khach
        {
            get { return this.khach; }
            set { this.khach = value; }
        }
        public Quan Quan
        {
            get { return this.quan; }
            set { this.quan = value; }
        }
        public TaiXe TaiXe
        {
            get { return this.taiXe; }
            set { this.taiXe = value; }
        }
        public List<ChiTietDon> DsChiTiet
        {
            get { return this.dsChiTiet; }
            set { this.dsChiTiet = value; }
        }
        public double KhoangCachKm
        {
            get { return this.dKhoangCachKm; }
            set { this.dKhoangCachKm = value; }
        }
        public TrangThaiDon TrangThai
        {
            get { return this.trangThai; }
            set { this.trangThai = value; }
        }
        public PhuongThucThanhToan PtThanhToan
        {
            get { return this.thanhToan; }
            set { this.thanhToan = value; }
        }
        public double SoTienDaThanhToan
        {
            get { return this.dSoTienDaThanhToan; }
            set { this.dSoTienDaThanhToan = value; }
        }
        public double SoTienGiamGia
        {
            get { return this.dSoTienGiamGia; }
            set { this.dSoTienGiamGia = value; }
        }

        public DonHang()
        {
            this.DsChiTiet = new List<ChiTietDon>();
            this.TrangThai = TrangThaiDon.ChoXacNhan;
            this.SoTienDaThanhToan = 0;
            this.SoTienGiamGia = 0;
        }

        public DonHang(string ma, KhachHang khach, Quan quan)
        {
            this.Ma = ma;
            this.Khach = khach;
            this.Quan = quan;
            this.DsChiTiet = new List<ChiTietDon>();
            this.TrangThai = TrangThaiDon.ChoXacNhan;
            this.SoTienDaThanhToan = 0;
            this.SoTienGiamGia = 0;
        }

        ~DonHang() { }

        public void GoiMon(MonAn mon, int soLuong)
        {
            ChiTietDon ct = new ChiTietDon(mon, soLuong);
            this.dsChiTiet.Add(ct);
        }

        public void Nhap()
        {
            this.quan.HienThiMenu();
            Console.WriteLine("Nhap so mon muon dat: ");
            int soMon = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < soMon; i++)
            {
                Console.WriteLine("Nhap ma mon: ");
                string maMon = Console.ReadLine();
                Console.WriteLine("Nhap so luong: ");
                int soLuong = Convert.ToInt32(Console.ReadLine());
                MonAn mon = this.quan.TimMon(maMon);
                if (mon != null)
                {
                    this.GoiMon(mon, soLuong);
                }
                else
                {
                    Console.WriteLine($"Khong tim thay mon co ma '{maMon}'. Bo qua...");
                }
            }
            Console.WriteLine("Nhap khoang cach giao (km): ");
            this.KhoangCachKm = Convert.ToDouble(Console.ReadLine());
            this.TrangThai = TrangThaiDon.ChoXacNhan;
        }

        public void CapNhatTrangThai(TrangThaiDon trangThaiMoi)
        {
            this.trangThai = trangThaiMoi;
        }

        public void Xuat()
        {
            Console.WriteLine($"---- DON HANG {this.sMa} ----");
            foreach (ChiTietDon ct in this.dsChiTiet)
            {
                ct.HienThi();
            }
            Console.WriteLine($"Trang thai: {this.trangThai}");
        }

        public double TongTienMon()
        {
            double tong = 0;
            foreach (ChiTietDon ct in this.dsChiTiet)
            {
                tong = tong + ct.ThanhTien();
            }
            return tong;
        }

        public double TinhPhiShip()
        {
            if (this.dKhoangCachKm <= 3) 
                return 15000;
            if (this.dKhoangCachKm <= 7) 
                return 25000;
            return 40000;
        }

        public double TinhGiamGia(string maVoucher)
        {
            if (maVoucher == null) 
                return 0;
            Voucher v = this.quan.TimVoucher(maVoucher);
            if (v == null) 
                return 0;
            return v.TinhGiam(this.TongTienMon());
        }

        public double TongThanhToan(string maVoucher)
        {
            return this.TongTienMon() - this.TinhGiamGia(maVoucher) + this.TinhPhiShip() + DonHang.Phi_nen_tang;
        }

        public void GanTaiXe(TaiXe tx)
        {
            this.taiXe = tx;
            tx.DangRanh = false;
            this.trangThai = TrangThaiDon.DangGiao;
            Console.WriteLine($"[Thong bao tai xe {tx.Ten}] Ban duoc phan cong giao don {this.sMa}.");
        }

        public bool ThanhToan(PhuongThucThanhToan ptTT, string maVoucher)
        {
            this.thanhToan = ptTT;
            double giam = this.TinhGiamGia(maVoucher);
            double tongTien = this.TongThanhToan(maVoucher);
            this.dSoTienDaThanhToan = tongTien;
            this.dSoTienGiamGia = giam;
            bool thanhCong = this.thanhToan.XuLyThanhToan(tongTien);
            if (thanhCong)
            {
                // thanh toán thành công nhưng đơn chưa được giao
                // Đơn chỉ được chuyển sang HoanThanh ngay sau khi tài xế done
                this.trangThai = TrangThaiDon.DaThanhToan;

                if (maVoucher != null)
                {
                    Voucher v = this.quan.TimVoucher(maVoucher);
                    if (v != null)
                    {
                        v.SuDung();
                    }
                }

                this.khach.TinhToanTien(tongTien);
                double tienCuaQuan = (this.TongTienMon() - giam) * (1 - DonHang.Chiet_khau_cua_quan);
                this.quan.ChuCuaQuan.TinhToanTien(tienCuaQuan);
            }
            else
            {
                Console.WriteLine("Thanh toan that bai! Don hang chua duoc thanh toan.");
            }
            return thanhCong;
        }

        // Hoàn tất giao hàng sau khi thanh toán và đã có tài xế
        public void HoanThanhDon()
        {
            if (this.trangThai != TrangThaiDon.DangGiao)
            {
                Console.WriteLine("Don hang chua du dieu kien de hoan thanh.");
                return;
            }
            if (this.taiXe != null)
            {
                double tienCuaTaiXe = this.TinhPhiShip() * (1 - DonHang.Chiet_khau_cua_tai_xe);
                this.taiXe.TinhToanTien(tienCuaTaiXe);
                this.taiXe.HoanThanhGiao();
            }

            this.trangThai = TrangThaiDon.HoanThanh;
            Console.WriteLine($"Don hang {this.sMa} da giao thanh cong.");
        }

        public void HuyDon()
        {
            if (this.trangThai == TrangThaiDon.HoanThanh)
            {
                Console.WriteLine("Khong the huy don da hoan thanh.");
                return;
            }
            this.trangThai = TrangThaiDon.DaHuy;
            if (this.taiXe != null)
            {
                this.taiXe.DangRanh = true;
            }
            Console.WriteLine($"Don hang {this.sMa} da bi huy.");
        }

        public void InHoaDon()
        {
            Console.WriteLine($"---- HOA DON {this.sMa} ----");
            foreach (ChiTietDon ct in this.dsChiTiet)
            {
                ct.HienThi();
            }
            Console.WriteLine($"Tien mon: {this.TongTienMon()}đ");
            if (this.dSoTienGiamGia > 0)
                Console.WriteLine($"Giam gia voucher: -{this.dSoTienGiamGia}đ");
            Console.WriteLine($"Phi ship: {this.TinhPhiShip()}đ");
            Console.WriteLine($"Phi nen tang: {DonHang.Phi_nen_tang}đ");
            Console.WriteLine($"Tong thanh toan: {this.dSoTienDaThanhToan}đ");
            Console.WriteLine($"Trang thai: {this.trangThai}");
        }
    }
}
