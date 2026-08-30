using System;
using System.Text;
using System.Globalization;

enum StockStatus
{
    OutOfStock,
    LowStock,
    InStock,
    Discontinued
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        Console.Write("Mã sản phẩm: ");
        string productCode = Console.ReadLine();

        Console.Write("Tên sản phẩm: ");
        string productName = Console.ReadLine();

        Console.Write("Số lượng tồn kho (Enter để bỏ trống/null): ");
        string qInput = Console.ReadLine();
        int? quantity = string.IsNullOrWhiteSpace(qInput) ? (int?)null : int.Parse(qInput);

        int minThreshold = 10;

        Console.Write("Restock Date - dd/MM/yyyy (Enter để bỏ trống/null): ");
        string dInput = Console.ReadLine();
        DateTime? restockDate = string.IsNullOrWhiteSpace(dInput) ? (DateTime?)null : DateTime.ParseExact(dInput, "dd/MM/yyyy", CultureInfo.InvariantCulture);

        int displayQuantity = quantity ?? 0;
        string warning = quantity == null ? " (Cảnh báo: Dữ liệu trống)" : "";

        StockStatus status;
        string statusText;

        if (quantity == null || quantity == 0)
        {
            status = StockStatus.OutOfStock;
            statusText = "OutOfStock (Hết hàng)";
        }
        else if (quantity < minThreshold)
        {
            status = StockStatus.LowStock;
            statusText = "LowStock (Sắp hết hàng)";
        }
        else
        {
            status = StockStatus.InStock;
            statusText = "InStock (Còn hàng)";
        }

        string restockMsg = restockDate?.ToString("dd/MM/yyyy") ?? "Chưa có lịch nhập hàng";

        Console.WriteLine("\n--- OUTPUT ---");
        Console.WriteLine($"Sản phẩm: {productName} (Mã: {productCode})");
        Console.WriteLine($"Số lượng hiển thị: {displayQuantity}{warning}");
        Console.WriteLine($"Trạng thái kho: {statusText}");
        Console.WriteLine($"Dự kiến nhập hàng: {restockMsg}");
    }
}