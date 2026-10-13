package FinalProject;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Voucher 
{
    //fields
    private String sMa;
    private String sTen;
    private double dPhanTram;
    private boolean bConSuDung;
    //properties
    public String getMa() 
    {
        return this.sMa;
    }
    public void setMa(String ma) 
    {
        this.sMa = ma;
    }
    public String getTen() 
    {
        return this.sTen;
    }
    public void setTen(String ten) 
    {
        this.sTen = ten;
    }
    public double getPhanTram() 
    {
        return this.dPhanTram;
    }
    public void setPhanTram(double phanTram) 
    {
        if(phanTram<=0 || phanTram>100) throw new IllegalArgumentException("Phan tram giam gia phai > 0 va <= 100");
        this.dPhanTram = phanTram;
    }
    public boolean isConSuDung() 
    {
        return this.bConSuDung;
    }
    public void setConSuDung(boolean conSuDung) 
    {
        this.bConSuDung = conSuDung;
    }
    //constructor
    public Voucher() 
    {

    }
    public Voucher(String ma, String ten, double phanTram) 
    {
        this.sMa = ma;
        this.sTen = ten;
        this.dPhanTram = phanTram;
        this.bConSuDung = true;
    }
    //Tính giảm giá
    public double TinhGiam(double tienMon)
    {
        if(this.bConSuDung)
        {
            return tienMon * this.dPhanTram / 100;
        }
        else
        {
            return 0;
        }
    }
    //đã sử dụng voucher
    public void SuDung()
    {
        this.bConSuDung = false;
    }
    //hàm nhập
    public void Nhap() throws IOException
    {
        InputStreamReader isr = new InputStreamReader(System.in);
        BufferedReader br = new BufferedReader(isr);

        System.out.println("Nhap ma cua voucher: ");
        this.sMa= br.readLine();
        System.out.println("Nhap ten voucher: ");
        this.sTen= br.readLine();
        System.out.println("Nhap phan tram giam gia: ");
        setPhanTram(Double.parseDouble(br.readLine()));
        this.bConSuDung = true;
    }
    //hàm xuất
    public void Xuat()
    {
        System.out.println("Voucher: " + this.sMa + "-" + this.sTen + "-" + this.dPhanTram + "% - " + (this.bConSuDung ? "Con su dung" : "Da su dung"));
    }
}
