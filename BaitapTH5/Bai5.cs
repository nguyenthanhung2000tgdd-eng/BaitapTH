using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.Write("Nhập điểm C#: ");
        double diemCS = double.Parse(Console.ReadLine());
        Console.Write("Nhập số tín chỉ C#: ");
        int tcCS = int.Parse(Console.ReadLine());

        Console.Write("Nhập điểm Toán rời rạc: ");
        double diemToan = double.Parse(Console.ReadLine());
        Console.Write("Nhập số tín chỉ Toán rời rạc: ");
        int tcToan = int.Parse(Console.ReadLine());

        Console.Write("Nhập điểm Tiếng Anh: ");
        double diemAnh = double.Parse(Console.ReadLine());
        Console.Write("Nhập số tín chỉ Tiếng Anh: ");
        int tcAnh = int.Parse(Console.ReadLine());

        int tongTC = tcCS + tcToan + tcAnh;
        double scoreAvg = (diemCS * tcCS + diemToan * tcToan + diemAnh * tcAnh) / tongTC;

        char diemChu;
        double gpa4;
        string xepLoai;

        if (scoreAvg >= 8.5)
        {
            diemChu = 'A';
            gpa4 = 4.0;
            xepLoai = "Giỏi";
        }
        else if (scoreAvg >= 7.0)
        {
            diemChu = 'B';
            gpa4 = 3.0;
            xepLoai = "Khá";
        }
        else if (scoreAvg >= 5.5)
        {
            diemChu = 'C';
            gpa4 = 2.0;
            xepLoai = "Trung bình";
        }
        else if (scoreAvg >= 4.0)
        {
            diemChu = 'D';
            gpa4 = 1.0;
            xepLoai = "Yếu";
        }
        else
        {
            diemChu = 'F';
            gpa4 = 0.0;
            xepLoai = "Kém (Trượt)";
        }

        Console.WriteLine("\n--- OUTPUT ---");
        Console.WriteLine($"Điểm TB Thang 10: {scoreAvg:F2}");
        Console.WriteLine($"Điểm Chữ Quy Đổi: {diemChu}");
        Console.WriteLine($"Điểm GPA Thang 4: {gpa4:F1}");
        Console.WriteLine($"Xếp Loại Học Lực: {xepLoai}");
    }
}