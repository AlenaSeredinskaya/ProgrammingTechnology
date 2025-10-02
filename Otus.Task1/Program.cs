using Otus.Task1.Models;
using ProtoBuf;
using System;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

class Program
{
    static SaveFile Generate1()
    {
        var res = new SaveFile();
        res.Coords = (1241.44, 124145.4);
        res.CurrentLocation = "Dungeon";
        res.User = new User { Level = 10, Name = "Пушкин", Gender = Gender.Male };
        res.Items = new[] { new Item() { Name = "Топор", Quantity = 2 } };
        res.CreatedDate = DateTime.Now;
        res.SaveDate = DateTime.Now;
        res.FileName = "SaveGame1";
        return res;
    }

    static SaveFile Generate2()
    {
        var res = new SaveFile();
        res.Coords = (121.44, 124.4);
        res.CurrentLocation = "Subway";
        res.User = new User { Level = 10, Name = "Feodorov", Gender = Gender.Female };
        res.Items = new[] { new Item() { Name = "Stick", Quantity = -2 } }; // вызовет exception
        res.CreatedDate = DateTime.Now;
        res.SaveDate = null;
        res.FileName = "SaveGame2";
        return res;
    }

    /// <summary>
    /// Бинарная сериализация
    /// </summary>
    /// <param name="sf"></param>
    /// <exception cref="Exception"></exception>
    static void SerializeBinary(SaveFile sf)
    {
        foreach (var item in sf.Items)
        {
            if (item.Quantity < 0)
                throw new Exception("Количество не может быть < 0.");
        }

        using (FileStream fs = new FileStream($"{sf.FileName}.bin", FileMode.Create))
        {
            Serializer.Serialize(fs, sf);
        }
    }

    /// <summary>
    /// Сериализация JSON
    /// </summary>
    /// <param name="sf"></param>
    /// <exception cref="Exception"></exception>
    static void SerializeJson(SaveFile sf)
    {
        foreach (var item in sf.Items)
        {
            if (item.Quantity < 0)
                throw new Exception("Количество не может быть < 0.");
        }

        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        var json = JsonSerializer.Serialize(sf, options);
        File.WriteAllText($"{sf.FileName}.json", json);
    }

    /// <summary>
    /// Сериализация XML
    /// </summary>
    /// <param name="sf"></param>
    /// <exception cref="Exception"></exception>
    static void SerializeXml(SaveFile sf)
    {
        foreach (var item in sf.Items)
        {
            if (item.Quantity < 0)
                throw new Exception("Количество не может быть < 0.");
        }

        var serializer = new XmlSerializer(typeof(SaveFile));
        using (FileStream fs = new FileStream($"{sf.FileName}.xml", FileMode.Create))
        {
            try
            {
                serializer.Serialize(fs, sf);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка сериализации XML {ex.Message}");
            }
        }
    }

    static SaveFile DeserializeBinary(string filePath)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.Open))
        {
            return Serializer.Deserialize<SaveFile>(fs);
        }
    }

    static void Main(string[] args)
    {
        var g1 = Generate1();
        var g2 = Generate2();

        try
        {
            SerializeBinary(g1);
            SerializeJson(g1);
            SerializeXml(g1);

            var loadedG1 = DeserializeBinary($"{g1.FileName}.bin");
            Console.WriteLine($"Десериализованный: Location={loadedG1.CurrentLocation}, User={loadedG1.User.Name}, Level={loadedG1.User.Level}");

            SerializeBinary(g2); 
            SerializeJson(g2);
            SerializeXml(g2);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
