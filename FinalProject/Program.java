package FinalProject;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Program
{
    public static void NhapMenu(Quan quan) throws IOException
    {
        InputStreamReader isr = new InputStreamReader(System.in);
        BufferedReader br = new BufferedReader(isr);
        System.out.println("Nhap so mon trong menu: ");
        int soMonMenu= Integer.parseInt(br.readLine());
        for(int i=0; i< soMonMenu; i++)
        {
            System.out.println("\n---Nhap mon "+ (i+1) +" ---");
            MonAn mon= new MonAn();
            mon.Nhap();
            quan.ThemMon(mon);
        }
    }
    public static void NhapVoucher(Quan quan) throws IOException
    {
        InputStreamReader isr = new InputStreamReader(System.in);
        BufferedReader br = new BufferedReader(isr);
        System.out.println("Nhap so Voucher cua quan: ");
        int soVoucher= Integer.parseInt(br.readLine());
        for(int i=0; i< soVoucher; i++)
        {
            System.out.println("\n---Nhap Voucher "+ (i+1)+" ---");
            Voucher v = new Voucher();
            v.Nhap();
            quan.ThemVoucher(v);
        }
    }
    public static PhuongThucThanhToan ChonPhuongThucThanhToan() throws IOException
    {
        System.out.println("Chon phuong thuc thanh toan:");
        System.out.println("1 - Tien mat");
        System.out.println("2 - Vi dien tu");
        System.out.println("3 - The");
        System.out.print("Lua chon: ");
        InputStreamReader isr = new InputStreamReader(System.in);
        BufferedReader br = new BufferedReader(isr);
        String chon= br.readLine();
        
        switch(chon)
        {
            case "2":
                ViDienTu vi= new ViDienTu();
                vi.Nhap();
                return vi;
            case "3":
                The the= new The();
                the.Nhap();
                return the;
            default:
                return new TienMat();
        }
    }
    public static String ChonVoucher(Quan quan) throws IOException
    {
        if(!quan.CoVoucher())
        {
            System.out.println("Quan nay hien khong co voucher khuyen mai");
            return null;
        }
        quan.HienThiVoucherConDung();
        System.out.println("Nhap ma voucher muon dung (bo trong neu khong dung): ");
        InputStreamReader isr = new InputStreamReader(System.in);
        BufferedReader br = new BufferedReader(isr);
        String maVoucher= br.readLine(); 
        return maVoucher;
    }
    public static void main(String[] args) throws IOException
    {
        InputStreamReader isr = new InputStreamReader(System.in);
        BufferedReader br = new BufferedReader(isr);

        UngDung app = new UngDung();
        ChuQuan cq = new ChuQuan();
        Quan quan = new Quan();
        KhachHang kh = new KhachHang();
        TaiXe tx = new TaiXe();

        int luaChon= -1;
        do
        {
            System.out.println("----------------- HE THONG ITFOOD -----------------");
            System.out.println("1. Nhap du lieu he thong (Khach, Quan, Menu, Tai Xe)");
            System.out.println("2. Khach hang Tao don & Thanh toan");
            System.out.println("3. Hien thi ket qua (Bao cao he thong, Doanh thu)");
            System.out.println("0. Thoat");
            System.out.println("---------------------------------------------------");
            System.out.println("Chon chuc nang: ");
            luaChon= Integer.parseInt(br.readLine());

            switch(luaChon)
            {
                case 1:
                    //1. Khởi tạo dữ liệu
                    cq = new ChuQuan();
                    quan = new Quan();
                    kh = new KhachHang();
                    tx = new TaiXe();

                    System.out.println("\n---NHAP THONG TIN CHU QUAN---");
                    cq.Nhap();
                    app.ThemChuQuan(cq);
                    System.out.println("\n---NHAP THONG TIN QUAN---");
                    quan.Nhap();
                    cq.ThemQuan(quan);
                    app.ThemQuan(quan);
                    NhapMenu(quan);
                    NhapVoucher(quan);
                    System.out.println("---NHAP THONG TIN KHACH HANG---");
                    kh.Nhap();
                    app.ThemKhachHang(kh);
                    System.out.println("---NHAP THONG TIN TAI XE---");
                    tx.Nhap();
                    app.ThemTaiXe(tx);

                    break;

                case 2:
                    //2. Tạo đơn hàng
                    if(app.getDsQuan().size() == 0)
                    {
                        System.out.println("Chua co du lieu he thong! Vui long chon chuc nang 1.");
                        break;
                    }
                    System.out.println("---TAO DON HANG---");
                    System.out.println("Nhap ma don hang: ");
                    String maDon= br.readLine();
                    DonHang don= app.TaoDonHang(maDon, kh, quan);

                    if(don == null)
                    {
                        System.out.println("Khong the tao don hang. Ket thuc.");
                        break;
                    }
                    don.Nhap();
                    don.Xuat();

                    //3. Quán nhận đơn
                    System.out.println("\n---QUAN NHAN DON---");
                    quan.NhanDon(don);

                    //hủy đơn nếu khách hàng muốn
                    System.out.println("Ban co muon huy don khong? (y/n): ");
                    String huyChon= br.readLine();
                    if(huyChon.equals("y") || huyChon.equals("Y"))
                    {
                        don.HuyDon();
                        System.out.println("\n---HOA DON---");
                        don.InHoaDon();
                        break;
                    }

                    //4.Thanh toán
                    System.out.println("\n---THANH TOAN---");
                    PhuongThucThanhToan ptTT= ChonPhuongThucThanhToan();
                    String maVoucher = ChonVoucher(quan);
                    boolean thanhCong= don.ThanhToan(ptTT, maVoucher);

                    if(!thanhCong)
                    {
                        System.out.println("Chuyen sang thanh toan bang tien mat.");
                        ptTT = new TienMat();
                        thanhCong = don.ThanhToan(ptTT, maVoucher);
                    }
                    if(!thanhCong)
                    {
                        System.out.println("Khong the thanh toan don hang.");
                        break;
                    }

                    //5. Phân công tài xế
                    System.out.println("---PHAN CONG TAI XE---");
                    app.TimTaiXeRanhVaGanDon(don);

                    //6. Giao hàng
                    System.out.println("---GIAO HANG---");
                    if(don.getTrangThai() == TrangThaiDon.DangGiao)
                    {
                        don.HoanThanhDon();
                    }
                    else System.out.println("Don hang chua duoc giao vi chua co tai xe.");

                    //In hóa đơn
                    System.out.println("\n---HOA DON---");
                    don.InHoaDon();
                    break;
                
                case 3:
                    //7. Hiển thị kết quả
                    if(app.getDsQuan().size()==0)
                    {
                        System.out.println("Chua co du lieu he thong! Vui long chon chuc nang 1.");
                        break;
                    }
                    for(int i=0; i < app.getDsQuan().size(); i++)
                    {
                        Quan q = app.getDsQuan().get(i);
                        q.Xuat();
                        q.HienThiVoucherDaDung();
                        System.out.println();
                    }
                    for(int i=0; i< app.getDsKhachHang().size(); i++)
                    {
                        KhachHang k = app.getDsKhachHang().get(i);
                        k.Xuat();
                        System.out.println();
                    }
                    app.BaoCao();
                    break;

                case 0:
                    System.out.println("Ket thuc chuong trinh!");
                    break;
                
                default:
                    System.out.println("Chuc nang khong hop le.");
                    break;
            }
            if(luaChon!=0)
            {
                System.out.println("\n[Nhan Enter de quay lai Menu...]");
                System.out.println();
            }
        }
        while (luaChon != 0);
    }
}
