using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitapTH1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.Write("Nhập chỉ số điện cũ (kWh): ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal chiSoCu) || chiSoCu < 0)
            {
                Console.WriteLine("Chỉ số điện cũ không hợp lệ!");
                return;
            }

            Console.Write("Nhập chỉ số điện mới (kWh): ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal chiSoMoi) || chiSoMoi < 0)
            {
                Console.WriteLine("Chỉ số điện mới không hợp lệ!");
                return;
            }

            if (chiSoMoi < chiSoCu)
            {
                Console.WriteLine("Lỗi: Chỉ số điện mới phải lớn hơn hoặc bằng chỉ số điện cũ!");
                return;
            }

            decimal dienTieuThu = chiSoMoi - chiSoCu;

            decimal tienChuaThue = TinhTienDienChuaThue(dienTieuThu);

            decimal tienThueVAT = Math.Round(tienChuaThue * 0.08m, MidpointRounding.AwayFromZero);

            decimal tongThanhToan = tienChuaThue + tienThueVAT;

            Console.WriteLine("\n--- OUTPUT ---");
            Console.WriteLine($"Số điện tiêu thụ: {dienTieuThu} kWh");
            Console.WriteLine($"Tiền điện chưa thuế: {tienChuaThue:N0} VNĐ");
            Console.WriteLine($"Thuế VAT (8%): {tienThueVAT:N0} VNĐ");
            Console.WriteLine($"Tổng thanh toán: {tongThanhToan:N0} VNĐ");
        }

        static decimal TinhTienDienChuaThue(decimal kWh)
        {
            decimal tongTien = 0m;
            decimal temp = kWh;

            if (temp > 300)
            {
                tongTien += (temp - 300) * 3050m;
                temp = 300;
            }
          
            if (temp > 200)
            {
                tongTien += (temp - 200) * 2729m;
                temp = 200;
            }
           
            if (temp > 100)
            {
                tongTien += (temp - 100) * 2167m;
                temp = 100;
            }
         
            if (temp > 50)
            {
                tongTien += (temp - 50) * 1866m;
                temp = 50;
            }
         
            if (temp > 0)
            {
                tongTien += temp * 1806m;
            }

            return Math.Round(tongTien, MidpointRounding.AwayFromZero);
        }
    }
}
