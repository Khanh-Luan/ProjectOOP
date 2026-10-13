package FinalProject;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class ViDienTu extends PhuongThucThanhToan
{
    //fields
    private double dSoDu;
    //properties
    public double getSoDu()
    {
        return dSoDu;
    }
    public void setSoDu(double dSoDu)
    {
        this.dSoDu= dSoDu;
    }
    //constructor
    public ViDienTu()
    {
        this.dSoDu= 0;
    }
    public ViDienTu(double soDu)
    {
        this.dSoDu= soDu;
    }
    //hàm nhập
    public void Nhap() throws IOException
    {
        System.out.println("Nhap so du vi: ");
        InputStreamReader isr = new InputStreamReader(System.in);
        BufferedReader br = new BufferedReader(isr);
        this.dSoDu= Double.parseDouble(br.readLine());
    }
    @Override 
    public boolean XuLyThanhToan(double soTien)
    {
        if (this.dSoDu < soTien) 
        {
            System.out.println("So du vi dien tu khong du!");
            return false;
        }
        this.dSoDu = this.dSoDu - soTien;
        System.out.println("Da thanh toan " + soTien + "VND bang vi dien tu. So du con lai: " + this.dSoDu + "VND");
        return true;
    }
}
