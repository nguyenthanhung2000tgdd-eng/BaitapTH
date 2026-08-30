using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        Console.Write("Quãng đường (km): ");
        double quangDuong = double.Parse(Console.ReadLine());

        Console.Write("Mức tiêu hao (L/100km): ");
        double mucTieuHao = double.Parse(Console.ReadLine());

        Console.Write("Giá xăng (VNĐ/Lít): ");
        decimal giaXang = decimal.Parse(Console.ReadLine());

        Console.Write("Số người đi: ");
        int soNguoi = int.Parse(Console.ReadLine());

        double tongNhienLieu = (quangDuong / 100.0) * mucTieuHao;
        decimal tongChiPhi = (decimal)tongNhienLieu * giaXang;

        decimal chiPhiMoiNguoi = tongChiPhi / soNguoi;
        decimal chiPhiLamTron = Math.Ceiling(chiPhiMoiNguoi / 1000m) * 1000m;

        Console.WriteLine("\n--- OUTPUT ---");
        Console.WriteLine($"Tổng nhiên liệu tiêu thụ: {tongNhienLieu:F2} Lít");
        Console.WriteLine($"Tổng chi phí xăng dầu: {tongChiPhi:N0} VNĐ");
        Console.WriteLine($"Chi phí mỗi người: {chiPhiLamTron:N0} VNĐ");
    }
}