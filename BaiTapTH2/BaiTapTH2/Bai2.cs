using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.Write("Chiều cao (m): ");
        double h = double.Parse(Console.ReadLine());

        Console.Write("Cân nặng (kg): ");
        double w = double.Parse(Console.ReadLine());

        double bmi = w / Math.Pow(h, 2);

        string status;
        if (bmi < 18.5)
            status = "Gầy (Thiếu cân)";
        else if (bmi < 23.0)
            status = "Bình thường (Lý tưởng)";
        else if (bmi < 25.0)
            status = "Thừa cân (Tiền béo phì)";
        else
            status = "Béo phì";

        double minW = 18.5 * Math.Pow(h, 2);
        double maxW = 22.9 * Math.Pow(h, 2);

        Console.WriteLine("\n--- OUTPUT ---");
        Console.WriteLine($"Chỉ số BMI của bạn: {bmi:F2}");
        Console.WriteLine($"Phân loại sức khỏe: {status}");
        Console.WriteLine($"Khuyên dùng: Cân nặng lý tưởng của bạn nên từ {minW:F2} kg đến {maxW:F2} kg.");
    }
}