using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace serialization
{
    public class ReflectionSerializer
    {
        //сериализация - преобразование объекта в csv-строку
        public static string SerializeToCsv<T>(T obj)
        {
            var type = typeof(T);
            var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var values = props.Select(p => p.GetValue(obj)?.ToString() ?? "").ToArray();
            return string.Join(";", values);
        }

        //десериализация - создание объекта из csv-строки
        public static T DeserializeFromCsv<T>(string csv) where T : new()
        {
            var obj = new T();
            var type = typeof(T);
            var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var values = csv.Split(';');

            for (int i = 0; i < props.Length && i < values.Length; i++)
            {
                object value = Convert.ChangeType(values[i], props[i].PropertyType);
                props[i].SetValue(obj, value);
            }
            return obj;
        }

        //сохранение сериализованного объекта в файл
        public void SaveToFile<T>(T obj, string filename)
        {
            var csv = SerializeToCsv(obj);
            File.WriteAllText(filename, csv);
        }

        //загрузка данных из файла и десериализация
        public T LoadFromFile<T>(string filename) where T : new()
        {
            var csv = File.ReadAllText(filename);
            return DeserializeFromCsv<T>(csv);
        }
    }
}
