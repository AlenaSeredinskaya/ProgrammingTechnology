using System;
using System.Diagnostics;
using Newtonsoft.Json;

namespace serialization
{
    class Program
    {
        static void Main()
        {
            int iterations = 1000;
            var obj = F.Get();
            var serializer = new ReflectionSerializer(); //класс

            //сериализация с Reflection csv
            var sw = Stopwatch.StartNew();
            string csvResult = "";
            for (int i = 0; i < iterations; i++)
                csvResult = ReflectionSerializer.SerializeToCsv(obj);
            long reflectionSerializeTime = sw.ElapsedMilliseconds;

            //вывод результата и замер времени на вывод
            sw.Restart();
            Console.WriteLine($"CSV Result: {csvResult}");
            long consoleWriteTime = sw.ElapsedMilliseconds;

            //сохранение csv в файл
            string csvFilePath = "data.csv";
            serializer.SaveToFile(obj, csvFilePath);
            Console.WriteLine($"Данные сохранены в {csvFilePath}");

            //загрузка csv из файла
            var obj2 = serializer.LoadFromFile<F>(csvFilePath);
            Console.WriteLine("Данные загружены из csv файла");

            //десериализация с Reflection csv
            sw.Restart();
            for (int i = 0; i < iterations; i++)
                ReflectionSerializer.DeserializeFromCsv<F>(csvResult);
            long reflectionDeserializeTime = sw.ElapsedMilliseconds;

            //сериализация с json
            sw.Restart();
            string json = "";
            for (int i = 0; i < iterations; i++)
                json = JsonConvert.SerializeObject(obj);
            long jsonSerializeTime = sw.ElapsedMilliseconds;

            //сохранение json в файл
            string jsonFilePath = "data.json";
            File.WriteAllText(jsonFilePath, json);
            Console.WriteLine($"Данные сохранены в {jsonFilePath}");

            //загрузка json из файла
            var obj3 = JsonConvert.DeserializeObject<F>(File.ReadAllText(jsonFilePath));
            Console.WriteLine("Данные загружены из json файла");

            //десериализация с json
            sw.Restart();
            for (int i = 0; i < iterations; i++)
                JsonConvert.DeserializeObject<F>(json);
            long jsonDeserializeTime = sw.ElapsedMilliseconds;       

            //вывод результатов
            Console.WriteLine("\nСериализуемый класс: class F { int i1, i2, i3, i4, i5; }");
            Console.WriteLine($"Количество замеров: {iterations} итераций");
            Console.WriteLine("\nМой Reflection:");
            Console.WriteLine($"Время на сериализацию = {reflectionSerializeTime} мс");
            Console.WriteLine($"Время на десериализацию = {reflectionDeserializeTime} мс");
            Console.WriteLine($"Время на вывод в консоль = {consoleWriteTime} мс");
            Console.WriteLine("\nСтандартный механизм (Newtonsoft.Json):");
            Console.WriteLine($"Время на сериализацию = {jsonSerializeTime} мс");
            Console.WriteLine($"Время на десериализацию = {jsonDeserializeTime} мс");

            //сравнение
            Console.WriteLine("\nСравнение:");
            Console.WriteLine($"Reflection сериализация быстрее json на {jsonSerializeTime - reflectionSerializeTime} мс");
            Console.WriteLine($"Reflection десериализация быстрее json на {jsonDeserializeTime - reflectionDeserializeTime} мс");
        }
    }

}
//Install-Package Newtonsoft.Json