using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patternPrototype
{
    // Базовый класс Device
    class Device : IMyCloneable<Device>, ICloneable
    {
        public string Brand { get; set; }
        public decimal Price { get; set; }

        public Device(string brand, decimal price)
        {
            Brand = brand;
            Price = price;
        }

        // Клонирование через конструктор (глубокое копирование)
        public Device MyClone()
        {
            return new Device(this.Brand, this.Price);
        }

        // Реализация ICloneable через свой метод
        public object Clone()
        {
            return MyClone();
        }

        public override string ToString()
        {
            return $"Устройство: {Brand}, Цена: {Price} $";
        }
    }

}
