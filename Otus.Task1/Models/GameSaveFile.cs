using ProtoBuf;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Otus.Task1.Models
{
    public enum Gender
    {
        None = 0,
        Male = 1,
        Female = 2,
    }

    // Конвертер для JSON (enum как m/f)
    public class GenderJsonConverter : JsonConverter<Gender>
    {
        public override Gender Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string value = reader.GetString();
            return value switch
            {
                "m" => Gender.Male,
                "f" => Gender.Female,
                _ => Gender.None
            };
        }

        public override void Write(Utf8JsonWriter writer, Gender value, JsonSerializerOptions options)
        {
            string result = value switch
            {
                Gender.Male => "m",
                Gender.Female => "f",
                _ => ""
            };
            writer.WriteStringValue(result);
        }
    }

    [Serializable]
    [ProtoContract]
    public class Item
    {
        private int _quantity;

        [ProtoMember(1)]
        public string Name { get; set; }

        [ProtoMember(2)]
        public int Quantity
        {
            get => _quantity;
            set => _quantity = value;
        }
    }

    [Serializable]
    [ProtoContract]
    public class User
    {
        [XmlAttribute("level")]
        [ProtoMember(1)]
        public int Level { get; set; }

        [ProtoMember(2)]
        public string Name { get; set; }

        [ProtoIgnore]
        [JsonIgnore]
        [ProtoMember(3)]
        public Gender Gender { get; set; }

        // JSON - сериализация через конвертер
        [JsonPropertyName("gender")]
        [JsonConverter(typeof(GenderJsonConverter))]
        public Gender JsonGender
        {
            get => Gender;
            set => Gender = value;
        }

        // XML - сериализация как m/f
        [XmlElement("gender")]
        [JsonIgnore]
        public string XmlGender
        {
            get => Gender switch
            {
                Gender.Male => "m",
                Gender.Female => "f",
                _ => ""
            };
            set
            {
                Gender = value switch
                {
                    "m" => Gender.Male,
                    "f" => Gender.Female,
                    _ => Gender.None
                };
            }
        }
    }

    [Serializable]
    [ProtoContract]
    [ProtoInclude(100, typeof(SaveFile))]
    public class GameStatus
    {
        [ProtoMember(1)]
        public string CurrentLocation { get; set; }

        [JsonPropertyName("u")]
        [XmlElement("u")]
        [ProtoMember(2)]
        public User User { get; set; }

        [ProtoMember(3)]
        public Item[] Items { get; set; }

        [XmlIgnore]
        [JsonIgnore]
        [ProtoIgnore] 
        public (double, double) Coords { get; set; }
    }

    [ProtoContract]
    public class SaveFile : GameStatus
    {
        [ProtoMember(4)]
        public DateTime CreatedDate { get; set; }

        [ProtoMember(5)]
        public DateTime? SaveDate { get; set; }

        [ProtoMember(6)]
        public string FileName { get; set; }
    }
}
