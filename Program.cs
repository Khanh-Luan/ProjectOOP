using System;
using System.Collections.Generic;
using ITFood;
using ProjectOOP;
class Program
{
    public static void Main(string[] args)
    {
        NguoiDung a = new KhachHang();
        NguoiDung b = new TaiXe();
        a.Nhap();
        b.Nhap();
    }
}