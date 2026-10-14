package FinalProject;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class TaiXe extends NguoiDung
{
    //fields
    private String sBienSo;
    private boolean bDangRanh;
    private int iSoDonDaGiao;
    private double dTongThuNhap;
    //properties
    public String getBienSo() 
    {
        return sBienSo;
    }
    public void setBienSo(String bienSo) 
    {
        this.sBienSo = bienSo;
    }
    public boolean isDangRanh() 
    {
        return bDangRanh;
    }
    public void setDangRanh(boolean dangRanh) 
    {
        this.bDangRanh = dangRanh;
    }
    public int getSoDonDaGiao() 
    {
        return iSoDonDaGiao;
    }
    public void setSoDonDaGiao(int soDonDaGiao) 
    {
        this.iSoDonDaGiao = soDonDaGiao;
    }
    public double getTongThuNhap() 
    {
        return dTongThuNhap;
    }
    public void setTongThuNhap(double tongThuNhap) 
    {
        this.dTongThuNhap = tongThuNhap;
    }
    //constructor
    public TaiXe() 
    {
        this.bDangRanh = true;
        this.iSoDonDaGiao = 0;
        this.dTongThuNhap = 0;
    }
    public TaiXe(String ma, String ten, String sdt, String email, String bienSo) 
    {
        super(ma, ten, sdt, email);
        this.sBienSo = bienSo;
        this.bDangRanh = true;
        this.iSoDonDaGiao = 0;
        this.dTongThuNhap = 0;
    }
    //hàm tính toán thu nhập của tài xế(tài xế nhận 100% phí ship)
    @Override
    public void TinhToanTien(double soTien) 
    {
        this.dTongThuNhap = this.dTongThuNhap + soTien;
    }
    //hàm nhập
    @Override
    public void Nhap() throws IOException
    {
        super.Nhap();
        System.out.println("~TAI XE: ");
        System.out.println("Nhap bien so xe: ");
        InputStreamReader isr = new InputStreamReader(System.in);
        BufferedReader br = new BufferedReader(isr);
        this.sBienSo = br.readLine();
    }
    //hàm xuất
    @Override 
    public void Xuat()
    {
        System.out.println("----Thong tin tai xe----");
        super.Xuat();
        System.out.println("Bien so xe: " + this.sBienSo);
        System.out.println("Dang ranh: " + this.bDangRanh);
        System.out.println("So don da giao: " + this.iSoDonDaGiao);
        System.out.println("Tong thu nhap: " + this.dTongThuNhap + "d");
    }
    public void HoanThanhGiao()
    {
        this.iSoDonDaGiao= this.iSoDonDaGiao + 1;
        this.bDangRanh = true;
    }
}
