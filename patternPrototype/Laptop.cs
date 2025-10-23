using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patternPrototype
{
    // Потомок Laptop
    class Laptop : Computer, IMyCloneable<Laptop>, ICloneable
    {
        public double Weight { get; set; }
        public int Battery { get; set; }

        public Laptop(string brand, decimal price, string processor, double weight, int battery)
            : base(brand, price, processor)
        {
            Weight = weight;
            Battery = battery;
        }

        // Клонирование через конструктор родителя
        public new Laptop MyClone()
        {
            return new Laptop(this.Brand, this.Price, this.Processor, this.Weight, this.Battery);
        }

        // Реализация ICloneable через свой метод
        public new object Clone()
        {
            return MyClone();
        }

        public override string ToString()
        {
            return base.ToString() + $", Вес: {Weight}kg, Батарея: {Battery}h";
        }
    }

}
