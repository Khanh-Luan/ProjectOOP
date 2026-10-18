package ProjectCuoiKyOOPNhom3;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class The extends PhuongThucThanhToan
{
    private static final double PHI_GIAO_DICH_MAC_DING= 3000;
    private String sSoThe;
    private double dPhiGiaoDich;
    
    public String getSoThe()
    {
        return sSoThe;
    }
    public void setSoThe(String soThe)
    {
        this.sSoThe= soThe;
    }
    public double getPhiGiaoDich()
    {
        return dPhiGiaoDich;
    }
    public void setPhiGiaoDich(double phiGiaoDich)
    {
        this.dPhiGiaoDich= phiGiaoDich;
    }
    
    public The()
    {
        this.dPhiGiaoDich= PHI_GIAO_DICH_MAC_DING;
    }
    public The(String soThe)
    {
        this.sSoThe= soThe;
        this.dPhiGiaoDich= PHI_GIAO_DICH_MAC_DING;
    }
    
    public void Nhap() throws IOException
    {
        System.out.println("Nhap ID the: ");
        InputStreamReader isr = new InputStreamReader(System.in);
        BufferedReader br = new BufferedReader(isr);
        this.sSoThe= br.readLine();
    }
    
    @Override 
    public boolean XuLyThanhToan(double soTien)
    {
        double tongTien= soTien+ this.dPhiGiaoDich;
        System.out.println("Da thanh toan "+ tongTien+"VND bang the "+ this.sSoThe+ " (bao gom phi giao dich "+ this.dPhiGiaoDich+"VND)");
        return true;
    }
}
