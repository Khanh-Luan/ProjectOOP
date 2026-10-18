package ProjectCuoiKyOOPNhom3;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Program
{
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
                    System.out.println("\n--- CHON PHUONG THUC NHAP DU LIEU ---");
                    System.out.println("1. Nap nhanh du lieu mau (2 Quan, 2 Khach, 2 Tai xe)");
                    System.out.println("2. Nhap thu cong tu ban phim");
                    System.out.print("Lua chon cua ban: ");
                    String chonNhap = br.readLine(); 

                    if (chonNhap.equals("1"))
                    {
                        app.KhoiTaoDuLieuMau();
                    }
                    else
                    {
                        cq = new ChuQuan();
                        quan = new Quan();
                        kh = new KhachHang();
                        tx = new TaiXe();

                        System.out.println("\n--- NHAP THONG TIN CHU QUAN ---");
                        cq.Nhap();
                        app.ThemChuQuan(cq);

                        System.out.println("\n--- NHAP THONG TIN QUAN ---");
                        quan.Nhap();
                        cq.ThemQuan(quan);
                        app.ThemQuan(quan);
                        quan.NhapMenu();
                        quan.NhapVoucher();

                        System.out.println("\n--- NHAP THONG TIN KHACH HANG ---");
                        kh.Nhap();
                        app.ThemKhachHang(kh);

                        System.out.println("\n--- NHAP THONG TIN TAI XE ---");
                        tx.Nhap();
                        app.ThemTaiXe(tx);
                    }
                    break;

                case 2:
                    if(app.getDsQuan().size() == 0 || app.getDsKhachHang().size() == 0)
                    {
                        System.out.println("Chua co du lieu he thong! Vui long chon chuc nang 1.");
                        break;
                    }
                    app.HienThiDsKhachHang();
                    System.out.println("Nhap MA k/h dat don (vi du KH01): ");
                    String maKhachChon= br.readLine();
                    KhachHang khChon= app.TimKhachHang(maKhachChon);
                    if(khChon==null)
                    {
                        System.out.println("Khong tim thay khach hang nay! Huy thao tac.");
                        break;
                    }
                    
                    app.HienThiDsQuan();
                    System.out.println("Nhap MA quan dat k/h dat (vi du Q01, Q02): ");
                    String maQuanChon= br.readLine();
                    Quan quanChon = app.TimQuan(maQuanChon);
                    if(quanChon==null)
                    {
                        System.out.println("Khong tim thay quan nay! Huy thao tac.");
                        break;
                    }

                    System.out.println("---TAO DON HANG---");
                    System.out.println("Nhap ma don hang (VD: DH01): ");
                    String maDon= br.readLine();
                    DonHang don= app.TaoDonHang(maDon, khChon, quanChon);

                    if(don == null)
                    {
                        System.out.println("Khong the tao don hang. Ket thuc.");
                        break;
                    }
                    don.Nhap();
                    don.Xuat();

                    System.out.println("\n---QUAN NHAN DON---");
                    quan.NhanDon(don);

                    System.out.println("Ban co muon huy don khong? (y/n): ");
                    String huyChon= br.readLine();
                    if(huyChon.equals("y") || huyChon.equals("Y"))
                    {
                        don.HuyDon();
                        System.out.println("\n---HOA DON---");
                        don.InHoaDon();
                        break;
                    }

                    System.out.println("\n---THANH TOAN---");
                    PhuongThucThanhToan ptTT= khChon.ChonPhuongThucThanhToan();
                    String maVoucher = quanChon.ChonVoucher();
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

                    System.out.println("---PHAN CONG TAI XE---");
                    app.TimTaiXeRanhVaGanDon(don);

                    System.out.println("---GIAO HANG---");
                    if(don.getTrangThai() == TrangThaiDon.DangGiao)
                    {
                        don.HoanThanhDon();
                    }
                    else System.out.println("Don hang chua duoc giao vi chua co tai xe.");

                    System.out.println("\n---HOA DON---");
                    don.InHoaDon();
                    break;
                
                case 3:
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
