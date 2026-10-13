package FinalProject;


import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

abstract class NguoiDung 
{
    //fields
    protected String sMa;
    protected String sTen;
    protected String sSdt;
    protected String sEmail;
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
    public String getSdt() 
    {
        return this.sSdt;
    }
    public void setSdt(String sdt) 
    {
        this.sSdt = sdt;
    }
    public String getEmail() 
    {
        return this.sEmail;
    }
    public void setEmail(String email) 
    {
        this.sEmail = email;
    }
    //constructor
    public NguoiDung() { }
    public NguoiDung(String ma, String ten, String sdt, String email) 
    {
        this.sMa = ma;
        this.sTen = ten;
        this.sSdt = sdt;
        this.sEmail = email;
    }
    //ham nhap
    public void Nhap() throws IOException 
    {
        InputStreamReader isr = new InputStreamReader(System.in);
        BufferedReader br = new BufferedReader(isr);

        System.out.println("Nhap ma: ");
        this.sMa = br.readLine();
        System.out.println("Nhap ten: ");
        this.sTen = br.readLine();
        System.out.println("Nhap sdt: ");
        this.sSdt = br.readLine();
        System.out.println("Nhap email: ");
        this.sEmail = br.readLine();
    }

    public void Xuat() 
    {
        System.out.println("Ma: " + this.sMa);
        System.out.println("Ten: " + this.sTen);
        System.out.println("Sdt: " + this.sSdt);
        System.out.println("Email: " + this.sEmail);
    }

    // moi loai nguoi dung tinh tien theo cach rieng cua minh
    public abstract void TinhToanTien(double soTien);
}
