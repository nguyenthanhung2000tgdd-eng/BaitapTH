using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        string systemOtp = "839201";
        DateTime creationTime = DateTime.Now;

        Console.Write("Mã OTP nhận được: ");
        string inputOtp = Console.ReadLine();

        Console.Write("Thời gian trôi qua (phút): ");
        int minutes = int.Parse(Console.ReadLine());

        Console.Write("Thời gian trôi qua (giây): ");
        int seconds = int.Parse(Console.ReadLine());

        // Giả lập thời điểm xác thực
        TimeSpan elapsed = new TimeSpan(0, minutes, seconds);
        DateTime verificationTime = creationTime.Add(elapsed);

        Console.WriteLine("\n--- OUTPUT ---");

        // 1. Kiểm tra độ dài 6 ký tự và toàn là số
        bool isNumber = int.TryParse(inputOtp, out _);
        if (inputOtp.Length != 6 || !isNumber)
        {
            Console.WriteLine("Trạng thái xác thực: LỖI - Định dạng không hợp lệ (Phải là 6 chữ số).");
            return;
        }

        // 2. Kiểm tra khớp mã hệ thống
        if (inputOtp != systemOtp)
        {
            Console.WriteLine("Trạng thái xác thực: LỖI - Mã OTP không chính xác.");
            return;
        }

        // 3. Kiểm tra thời gian hiệu lực
        TimeSpan timePassed = verificationTime - creationTime;
        if (timePassed.TotalSeconds > 300)
        {
            Console.WriteLine("Trạng thái xác thực: LỖI - Mã OTP đã hết hạn (Vượt quá 5 phút).");
            return;
        }

        Console.WriteLine("Trạng thái xác thực: THÀNH CÔNG - Giao dịch đã được phê duyệt.");
    }
}