using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitapTH1
{
    internal class Bai2
    {
        static void Main2(string[] args)
        {
            
                Console.OutputEncoding = Encoding.UTF8;

                Console.Write("Nhập chỉ số điện cũ (kWh): ");
                decimal cu = decimal.Parse(Console.ReadLine());
                Console.Write("Nhập chỉ số điện mới (kWh): ");
                decimal moi = decimal.Parse(Console.ReadLine());

                if (moi < cu)
                {
                    Console.WriteLine("Chỉ số mới phải lớn hơn hoặc bằng chỉ số cũ!");
                    return;
                }

                decimal kwh = moi - cu, temp = kwh, tien = 0;
                int[] limits = { 50, 50, 100, 100 };
                decimal[] prices = { 1806m, 1866m, 2167m, 2729m, 3050m };

                for (int i = 0; i < limits.Length; i++)
                {
                    decimal used = Math.Min(temp, limits[i]);
                    if (used <= 0) break;
                    tien += used * prices[i];
                    temp -= used;
                }
                if (temp > 0) tien += temp * prices[4];

                decimal vat = Math.Round(tien * 0.08m, MidpointRounding.AwayFromZero);

                Console.WriteLine($"\n--- OUTPUT ---");
                Console.WriteLine($"Số điện tiêu thụ: {kwh} kWh");
                Console.WriteLine($"Tiền điện chưa thuế: {tien:N0} VNĐ");
                Console.WriteLine($"Thuế VAT (8%): {vat:N0} VNĐ");
                Console.WriteLine($"Tổng thanh toán: {tien + vat:N0} VNĐ");
        }
    }
    }
}
