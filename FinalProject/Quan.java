package FinalProject;

import java.util.ArrayList;
import java.util.List;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Quan 
{
    //fields
    private String sMa;
    private String sTen;
    private String sDiaChi;
    private boolean bDangMoCua;
    private List<MonAn> menu;
    private List<Voucher> dsVoucher;
    private ChuQuan chuQuan;
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
    public String getDiaChi() 
    {
        return sDiaChi;
    }
    public void setDiaChi(String diaChi) 
    {
        this.sDiaChi = diaChi;
    }
    public boolean isDangMoCua() 
    {
        return bDangMoCua;
    }
    public void setDangMoCua(boolean dangMoCua) 
    { 
        this.bDangMoCua = dangMoCua;
    }
    public List<MonAn> getMenu() 
    { 
        return menu; 
    }
    public void setMenu(List<MonAn> menu) 
    { 
        this.menu = menu; 
    }
    public List<Voucher> getDsVoucher() 
    { 
        return dsVoucher; 
    }
    public void setDsVoucher(List<Voucher> dsVoucher) 
    { 
        this.dsVoucher = dsVoucher; 
    }
    public ChuQuan getChuCuaQuan() 
    {
        return chuQuan; 
    }
    public void setChuCuaQuan(ChuQuan chuQuan) 
    { 
        this.chuQuan = chuQuan;
    }
    //constructor
    public Quan()
    {
        this.menu = new ArrayList<MonAn>();
        this.dsVoucher = new ArrayList<Voucher>();
        this.bDangMoCua = true;
    }
    public Quan(String ma, String ten, String diaChi) 
    {
        this.sMa = ma;
        this.sTen = ten;
        this.sDiaChi = diaChi;
        this.bDangMoCua = true;
        this.menu = new ArrayList<MonAn>();
        this.dsVoucher = new ArrayList<Voucher>();
    }
    // chỉ nhập thông tin của quán, việc gán chủ quán do ChuQuan.ThemQuan() lo
    public void Nhap() throws IOException 
    {
        InputStreamReader isr = new InputStreamReader(System.in);
        BufferedReader br = new BufferedReader(isr);

        System.out.println("Nhap ma quan: ");
        this.sMa = br.readLine();
        System.out.println("Nhap ten quan: ");
        this.sTen = br.readLine();
        System.out.println("Nhap dia chi: ");
        this.sDiaChi = br.readLine();
        this.bDangMoCua = true;
    }

    public void ThemMon(MonAn mon) 
    {
        this.menu.add(mon);
    }

    public MonAn TimMon(String ma) 
    {
        for (int i = 0; i < this.menu.size(); i++) 
        {
            if (this.menu.get(i).getMa().equals(ma)) return this.menu.get(i);
        }
        return null;
    }

    public void HienThiMenu() 
    {
        System.out.println("--- Menu cua quan " + this.sTen + " ---");
        for (int i = 0; i < this.menu.size(); i++) 
        {
            this.menu.get(i).Xuat();
        }
    }

    //quản lí voucher của quán
    public void ThemVoucher(Voucher v) 
    {
        this.dsVoucher.add(v);
    }

    public Voucher TimVoucher(String ma) 
    {
        for (int i = 0; i < this.dsVoucher.size(); i++) {
            if (this.dsVoucher.get(i).getMa().equals(ma)) return this.dsVoucher.get(i);
        }
        return null;
    }

    public boolean CoVoucher() 
    {
        for (int i = 0; i < this.dsVoucher.size(); i++) 
        {
            if (this.dsVoucher.get(i).isConSuDung())
                return true;
        }
        return false;
    }

    public void HienThiVoucherConDung() 
    {
        System.out.println("Voucher hien co cua quan " + this.sTen + ":");
        for (int i = 0; i < this.dsVoucher.size(); i++) 
        {
            if (this.dsVoucher.get(i).isConSuDung()) this.dsVoucher.get(i).Xuat();
        }
    }

    public void HienThiVoucherDaDung() 
    {
        System.out.println("---VOUCHER DA DUNG---");
        System.out.println("Voucher da su dung cua quan " + this.sTen + ":");
        for (int i = 0; i < this.dsVoucher.size(); i++) 
        {
            if (!this.dsVoucher.get(i).isConSuDung()) this.dsVoucher.get(i).Xuat();
        }
    }

    //quán là class chính nên Xuất hiện thi đầy đủ thông tin, gồm cả chủ quán
    public void Xuat() {
        System.out.println("---THONG TIN QUAN---");
        System.out.println("Ma quan: " + this.sMa);
        System.out.println("Ten quan: " + this.sTen);
        System.out.println("Dia chi: " + this.sDiaChi);
        System.out.println("Dang mo cua: " + this.bDangMoCua);
        System.out.println("So mon trong menu: " + this.menu.size());
        System.out.println("So voucher: " + this.dsVoucher.size());
        if (this.chuQuan != null) {
            System.out.println("Chu quan: " + this.chuQuan.getTen() + " (Ma: " + this.chuQuan.getMa() + ")");
            System.out.println("Doanh thu cua chu: " + this.chuQuan.getTongDoanhThu() + "d");
        }
    }

    public void NhanDon(DonHang don) 
    {
        System.out.println("[Thong bao quan " + this.sTen + "] Nhan duoc don " + don.getMa() + ", bat dau lam mon.");
        don.CapNhatTrangThai(TrangThaiDon.DangLam);
    }
}
