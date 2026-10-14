package FinalProject;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class MonAn 
{
    //fields
    protected String sMa;
    protected String sTen;
    protected double dGia;
    //properties
    public String getMa() 
    {
        return sMa;
    }
    public void setMa(String ma) 
    {
        this.sMa = ma;
    }
    public String getTen() 
    {
        return sTen;
    }
    public void setTen(String ten) 
    {
        this.sTen = ten;
    }
    public double getGia() 
    {
        return dGia;
    }
    public void setGia(double value) 
    {
        if(value<=0) throw new IllegalArgumentException("Gia cua mon an phai > 0");
        this.dGia = value;
    }
    //constructor
    public MonAn()
    {

    }
    public MonAn(String ma, String ten, double gia) 
    {
        this.sMa = ma;
        this.sTen = ten;
        setGia(gia);
    }
    //hàm nhập
    public void Nhap() throws IOException
    {
        InputStreamReader isr = new InputStreamReader(System.in);
        BufferedReader br = new BufferedReader(isr);
        
        System.out.println("Nhap ma mon an: ");
        this.sMa = br.readLine();
        System.out.println("Nhap ten mon an: ");
        this.sTen = br.readLine();
        System.out.println("Nhap gia mon an: ");
        setGia(Double.parseDouble(br.readLine()));
    }
    //hàm xuất
    public void Xuat()
    {
        System.out.println("Mon an: "+this.sMa + " - " + this.sTen + " - " + this.dGia + " VND");
    }
}
