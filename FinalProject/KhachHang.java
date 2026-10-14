package FinalProject;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class KhachHang extends NguoiDung
{
    //fields
    private String sDiaChiGiao;
    private int iDiemTichLuyITFood;
    private double dTongDaChi;
    //properties
    public String getDiaChiGiao() 
    {
        return sDiaChiGiao;
    }
    public void setDiaChiGiao(String diaChiGiao) 
    {
        this.sDiaChiGiao = diaChiGiao;
    }
    public int getDiemTichLuyITFood() 
    {
        return iDiemTichLuyITFood;
    }
    public void setDiemTichLuyITFood(int diemTichLuyITFood) 
    {
        this.iDiemTichLuyITFood = diemTichLuyITFood;
    }
    public double getTongDaChi()
    { 
        return dTongDaChi;
    }
    public void setTongDaChi(double tongDaChi) 
    {
        this.dTongDaChi = tongDaChi;
    }
    //constructor
    public KhachHang() 
    {
        this.iDiemTichLuyITFood= 0;
        this.dTongDaChi= 0;
    }
    public KhachHang(String ma, String ten, String sdt, String email, String diaChi) 
    {
        super(ma, ten, sdt, email);
        this.sDiaChiGiao = diaChi;
        this.iDiemTichLuyITFood = 0;
        this.dTongDaChi = 0;
    }
    //hàm nhập
    @Override
    public void Nhap() throws IOException
    {
        super.Nhap();
        
        System.out.println("Nhap dia chi giao: ");
        InputStreamReader isr = new InputStreamReader(System.in);
        BufferedReader br = new BufferedReader(isr);
        this.sDiaChiGiao = br.readLine();
    }
    //hàm xuất
    @Override
    public void Xuat() 
    {
        System.out.println("----Thong tin khach hang----");
        super.Xuat();
        System.out.println("Dia chi giao: " + this.sDiaChiGiao);
        System.out.println("Diem tich luy: " + this.iDiemTichLuyITFood);
        System.out.println("Tong da chi: " + this.dTongDaChi + "VND");
    }
    // hàm tính tóan số tiền: cộng dồn đã chi và điểm tích lũy
    @Override
    public void TinhToanTien(double soTien) 
    {
        this.dTongDaChi = this.dTongDaChi + soTien;
        this.iDiemTichLuyITFood = this.iDiemTichLuyITFood + (int)(soTien / 10000);
    }
}
