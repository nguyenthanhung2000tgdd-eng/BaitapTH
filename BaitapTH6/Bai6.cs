using System;
using System.Text;
using System.Globalization;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        Console.Write("Nhập họ tên thô: ");
        string input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Dữ liệu không hợp lệ!");
            return;
        }

        string[] parts = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < parts.Length; i++)
        {
            parts[i] = char.ToUpper(parts[i][0]) + parts[i].Substring(1).ToLower();
        }

        string ho = parts[0];
        string ten = parts.Length > 1 ? parts[parts.Length - 1] : "";

        string tenDem = "";
        if (parts.Length > 2)
        {
            tenDem = string.Join(" ", parts, 1, parts.Length - 2);
        }

        string chuanHoa = string.Join(" ", parts);

        string usernameRaw = ten + "." + ho + tenDem.Replace(" ", "");
        string username = RemoveDiacritics(usernameRaw).ToLower();
        string email = $"{username}@company.edu.vn";

        Console.WriteLine("\n--- OUTPUT ---");
        Console.WriteLine($"Họ tên chuẩn hóa: {chuanHoa}");
        Console.WriteLine($"Họ: {ho} | Tên đệm: {tenDem} | Tên: {ten}");
        Console.WriteLine($"Username tạo tự động: {username}");
        Console.WriteLine($"Email cấp phát: {email}");
    }

    static string RemoveDiacritics(string text)
    {
        var normalizedString = text.Normalize(NormalizationForm.FormD);
        var stringBuilder = new StringBuilder();

        foreach (var c in normalizedString)
        {
            var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
            if (unicodeCategory != UnicodeCategory.NonSpacingMark)
            {
                stringBuilder.Append(c);
            }
        }

        return stringBuilder.ToString().Normalize(NormalizationForm.FormC)
            .Replace("Đ", "D")
            .Replace("đ", "d");
    }
}