using System;
using System.Text;

enum CurrencyType
{
    USD = 1,
    EUR,
    JPY,
    GBP
}

class Program
{
    static void Main()
    {
       Console.OutputEncoding = Encoding.UTF8;

        Console.Write("Nhập số tiền VNĐ: ");
        decimal vnd = decimal.Parse(Console.ReadLine());

        Console.Write("Chọn ngoại tệ (1-USD, 2-EUR, 3-JPY, 4-GBP): ");
        CurrencyType currency = (CurrencyType)int.Parse(Console.ReadLine());

        decimal rate = 0m;
        switch (currency)
        {
            case CurrencyType.USD:
                rate = 25400m;
                break;
            case CurrencyType.EUR:

                rate = 27200m;
                break;
            case CurrencyType.JPY:
                rate = 165m;
                break;
            case CurrencyType.GBP:
                rate = 32100m;
                break;
        }

        if (rate == 0m)
        {
            Console.WriteLine("Loại ngoại tệ chọn không hợp lệ!");
            return;
        }

        decimal fee = vnd * 0.005m;
        decimal vndAfterFee = vnd - fee;
        decimal foreignAmount = vndAfterFee / rate;

        Console.WriteLine("\n--- OUTPUT ---");
        Console.WriteLine($"Phí dịch vụ (0.5%): {fee:N0} VNĐ");
        Console.WriteLine($"Số tiền VNĐ tính đổi: {vndAfterFee:N0} VNĐ");
        Console.WriteLine($"Số tiền {currency} nhận được: {foreignAmount:F2} {currency}");
    }
}