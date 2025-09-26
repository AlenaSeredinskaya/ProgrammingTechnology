using System;
using System.Reflection;
using System.Text;

public static class CsvSerializer
{
    // Сериализация CSV
    public static string SerializeToCsv(object obj)
    {
        Type type = obj.GetType();
        FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        StringBuilder sb = new StringBuilder();

        foreach (FieldInfo field in fields)
        {
            object value = field.GetValue(obj);

            // Проверка, если массив
            if (value is Array array)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    sb.Append(array.GetValue(i).ToString());
                    if (i < array.Length - 1)
                        sb.Append(";");
                }
            }
            else
            {
                sb.Append(value.ToString());
            }

            sb.Append(",");
        }

        if (sb.Length > 0)
            sb.Length--; // удалить последнюю запятую

        return sb.ToString();
    }

    // Десериализация CSV
    public static T DeserializeFromCsv<T>(string csv) where T : new()
    {
        T obj = new T();
        Type type = typeof(T);
        FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        string[] values = csv.Split(',');

        for (int i = 0; i < fields.Length && i < values.Length; i++)
        {
            FieldInfo field = fields[i];
            // Если массив
            if (field.FieldType.IsArray)
            {
                string[] elements = values[i].Split(';');
                Type elementType = field.FieldType.GetElementType();
                Array array = Array.CreateInstance(elementType, elements.Length);
                for (int j = 0; j < elements.Length; j++)
                {
                    object elementValue = Convert.ChangeType(elements[j], elementType);
                    array.SetValue(elementValue, j);
                }
                field.SetValue(obj, array);
            }
            else
            {
                object fieldValue = Convert.ChangeType(values[i], field.FieldType);
                field.SetValue(obj, fieldValue);
            }
        }

        return obj;
    }
}
