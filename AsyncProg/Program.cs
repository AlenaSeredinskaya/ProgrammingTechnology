using AsyncProg;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AsyncProg
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string folderPath = @"C:\Users\user\Desktop\технологии программирования\AsyncProg";

            // Check if the folder exists
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine("Папка не существует. Проверьте правильность указанного пути.");
                return;
            }

            // Create a counter instance
            FileSpaceCounter counter = new FileSpaceCounter();

            // Scenario 1: Reading the entire file
            Console.WriteLine("Сценарий 1: Чтение всего файла целиком");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            ProcessingResult result1 = await counter.CountSpacesInFilesAsync(folderPath, readWholeFile: true);
            stopwatch.Stop();
            result1.ElapsedTime = stopwatch.Elapsed;
            Console.WriteLine($"Общее количество пробелов: {result1.TotalSpaces}");
            Console.WriteLine($"Время выполнения: {result1.ElapsedTime.TotalMilliseconds} мс\n");

            // Scenario 2: Reading line by line
            Console.WriteLine("Сценарий 2: Построчное чтение");
            stopwatch.Restart();
            ProcessingResult result2 = await counter.CountSpacesInFilesAsync(folderPath, readWholeFile: false);
            stopwatch.Stop();
            result2.ElapsedTime = stopwatch.Elapsed;
            Console.WriteLine($"Общее количество пробелов: {result2.TotalSpaces}");
            Console.WriteLine($"Время выполнения: {result2.ElapsedTime.TotalMilliseconds} мс");
        }
    }
}
