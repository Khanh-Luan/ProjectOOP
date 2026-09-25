using System;
    enum PhepToan   //cau3
    {
        Cong=1,
        Tru=2,
        Nhan=3,
        Chia=4,
        ChiaLayDu=5
    }
class UsingEnum
{
static void Main()
    {
        Console.WriteLine("Phep toan: ");
        Console.WriteLine("Cong: 1");
        Console.WriteLine("Tru: 2");
        Console.WriteLine("Nhan: 3");
        Console.WriteLine("Chia: 4");
        Console.WriteLine("Chia lay du: 5");
        Console.Write("Nhap phep toan: ");
        PhepToan choice = (PhepToan)int.Parse(Console.ReadLine());
        Console.Write("Nhap so thu nhat a= ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Nhap so thu hai b= ");
        double b = double.Parse(Console.ReadLine());

        double result = 0;  
        switch ((PhepToan)choice)
        {
            case PhepToan.Cong:
                result = a + b;
                break;
            case PhepToan.Tru:
                result = a - b;
                break;
            case PhepToan.Nhan:
                result = a * b;
                break;
            case PhepToan.Chia:
                if (b != 0)
                    result = a / b;
                else
                    Console.WriteLine("Khong the chia cho 0");
                break;
            case PhepToan.ChiaLayDu:
                if (b != 0)
                    result = a % b;
                else
                    Console.WriteLine("Khong the chia cho 0");
                break;
            default:
                Console.WriteLine("Chiu, nhap phep toan khong hop le");
                break;
        }
        Console.WriteLine("Ket qua: " + result);

    }
} 