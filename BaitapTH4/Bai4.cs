using System;
using System.Globalization;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.Write("Nhập ngày sinh (dd/MM/yyyy): ");
        string input = Console.ReadLine();

        if (DateTime.TryParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dob))
        {
            DateTime today = DateTime.Now.Date;

            int age = today.Year - dob.Year;
            if (today < dob.AddYears(age))
            {
                age--;
            }

            int totalDays = (int)(today - dob).TotalDays;

            DateTime nextBirthday = dob.AddYears(today.Year - dob.Year);
            if (nextBirthday < today)
            {
                nextBirthday = nextBirthday.AddYears(1);
            }

            int daysToNextBirthday = (int)(nextBirthday - today).TotalDays;

            Console.WriteLine("\n--- OUTPUT ---");
            Console.WriteLine($"Tuổi hiện tại: {age} tuổi");
            Console.WriteLine($"Bạn đã sống tổng cộng: {totalDays:N0} ngày");
            Console.WriteLine($"Sinh nhật tiếp theo còn: {daysToNextBirthday} ngày nữa");
        }
        else
        {
            Console.WriteLine("Ngày sinh không hợp lệ!");
        }
    }
}