using System.Text;

string filePath = @"C:\Users\dsgnrr\Desktop\1.txt";
string filePath2 = @"C:\Users\dsgnrr\Desktop\2.txt";

try
{
    using (StreamReader reader = new StreamReader(filePath))
    using (StreamWriter writer = new StreamWriter(filePath2, false, Encoding.UTF8))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            writer.WriteLine(line.Replace(':', ','));
        }
    }

    Console.WriteLine("Файл успешно создан и записан.");
}
catch (FileNotFoundException)
{
    Console.WriteLine("Файл не найден.");
}
catch (IOException)
{
    Console.WriteLine("Ошибка ввода-вывода при чтении файла.");
}