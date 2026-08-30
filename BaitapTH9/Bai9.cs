using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        Console.Write("Lương Gross (VNĐ): ");
        decimal gross = decimal.Parse(Console.ReadLine());

        Console.Write("Số người phụ thuộc: ");
        int dependents = int.Parse(Console.ReadLine());

        decimal insurance = gross * 0.105m;
        decimal personalDeduction = 11000000m;
        decimal dependentDeduction = dependents * 4400000m;

        decimal taxableIncome = gross - insurance - personalDeduction - dependentDeduction;
        if (taxableIncome < 0)
        {
            taxableIncome = 0;
        }

        decimal tax = CalculatePersonalIncomeTax(taxableIncome);
        decimal net = gross - insurance - tax;

        Console.WriteLine("\n--- OUTPUT ---");
        Console.WriteLine($"Giảm trừ Bảo hiểm (10.5%): {insurance:N0} VNĐ");
        Console.WriteLine($"Thu nhập chịu thuế: {taxableIncome:N0} VNĐ");
        Console.WriteLine($"Thuế TNCN phải nộp: {tax:N0} VNĐ");
        Console.WriteLine($"LƯƠNG NET THỰC NHẬN: {net:N0} VNĐ");
    }

    static decimal CalculatePersonalIncomeTax(decimal income)
    {
        decimal tax = 0m;

        if (income > 80000000m)
        {
            tax += (income - 80000000m) * 0.35m;
            income = 80000000m;
        }
        if (income > 52000000m)
        {
            tax += (income - 52000000m) * 0.30m;
            income = 52000000m;
        }
        if (income > 32000000m)
        {
            tax += (income - 32000000m) * 0.25m;
            income = 32000000m;
        }
        if (income > 18000000m)
        {
            tax += (income - 18000000m) * 0.20m;
            income = 18000000m;
        }
        if (income > 10000000m)
        {
            tax += (income - 10000000m) * 0.15m;
            income = 10000000m;
        }
        if (income > 5000000m)
        {
            tax += (income - 5000000m) * 0.10m;
            income = 5000000m;
        }
        if (income > 0m)
        {
            tax += income * 0.05m;
        }

        return tax;
    }
}