using System;
using System.Diagnostics;
using Newtonsoft.Json;
using serialization;

class Program
{
    static void Main()
    {
        const int iterations = 1000;
        var obj = new F();

        Console.WriteLine("Код сериализации-десериализации: ");

        Console.WriteLine();
        Console.WriteLine($"Количество замеров: {iterations} итераций");
        Console.WriteLine();

        Console.WriteLine("Мой Reflection: ");

        Stopwatch sw = new Stopwatch();

        // Моя сериализация
        sw.Start();
        string csvResult = null;
        for (int i = 0; i < iterations; i++)
        {
            csvResult = CsvSerializer.SerializeToCsv(obj);
        }
        sw.Stop();
        long csvSerializationTime = sw.ElapsedMilliseconds;
        Console.WriteLine("Сериализованная CSV строка: " + csvResult);
        Console.WriteLine($"Время на сериализацию = {csvSerializationTime} мс");

        // Моя десериализация
        sw.Restart();
        for (int i = 0; i < iterations; i++)
        {
            F newObj = CsvSerializer.DeserializeFromCsv<F>(csvResult);
        }
        sw.Stop();
        long csvDeserializationTime = sw.ElapsedMilliseconds;
        Console.WriteLine($"Время на десериализацию = {csvDeserializationTime} мс");

        Console.WriteLine();
        Console.WriteLine("Стандартный механизм (NewtonsoftJson):");


        // JSON сериализация
        sw.Restart();
        string jsonResult = null;
        for (int i = 0; i < iterations; i++)
        {
            jsonResult = JsonConvert.SerializeObject(obj);
        }
        sw.Stop();
        long jsonSerializationTime = sw.ElapsedMilliseconds;
        Console.WriteLine("Сериализованная JSON строка: " + jsonResult);
        Console.WriteLine($"Время на сериализацию = {jsonSerializationTime} мс");

        // JSON десериализация
        sw.Restart();
        for (int i = 0; i < iterations; i++)
        {
            F jsonObj = JsonConvert.DeserializeObject<F>(jsonResult);
        }
        sw.Stop();
        long jsonDeserializationTime = sw.ElapsedMilliseconds;
        Console.WriteLine($"Время на десериализацию = {jsonDeserializationTime} мс");

        // Вывод сравнения времени
        Console.WriteLine();
        Console.WriteLine("Сравнение времени:");
        Console.WriteLine($"Разница во времени сериализации (CSV - JSON): {csvSerializationTime - jsonSerializationTime} мс");
        Console.WriteLine($"Разница во времени десериализации (CSV - JSON): {csvDeserializationTime - jsonDeserializationTime} мс");
    }
}
