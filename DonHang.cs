using ProjectOOP;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITFood
{
    public class DonHang
    {
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

        public string Ma { get { return sMa; } }
        public TrangThaiDon TrangThai { get { return trangThai; } }

        public DonHang(string ma, KhachHang khach, Quan quan)
        {
        }

        public void GoiMon(MonAn mon, int soLuong)
        {
        }

        public void Nhap()
        {
        }

        public void CapNhatTrangThai(TrangThaiDon trangThaiMoi)
        {
        }

        public void Xuat()
        {
        }

        public double TongTienMon()
        {
        }

        public double TinhPhiShip()
        {
        }

        public double TinhGiamGia(string maVoucher)
        {
        }

        public double TongThanhToan(string maVoucher)
        {
        }

        public void GanTaiXe(TaiXe tx)
        {
        }

        public bool ThanhToan(PhuongThucThanhToan ptTT, string maVoucher)
        {
        }

        public void HoanThanhDon()
        {
        }

        public void HuyDon()
        {
        }

        public void InHoaDon()
        {
        }
    }
}
