using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patternPrototype
{
    // Промежуточный класс Computer
    class Computer : Device, IMyCloneable<Computer>, ICloneable
    {
        public string Processor { get; set; }

        public Computer(string brand, decimal price, string processor) : base(brand, price)
        {
            Processor = processor;
        }

        // Клонирование через конструктор родителя
        public new Computer MyClone()
        {
            return new Computer(this.Brand, this.Price, this.Processor);
        }

        // Реализация ICloneable через свой метод
        public new object Clone()
        {
            return MyClone();
        }

        public override string ToString()
        {
            return base.ToString() + $", Процессор: {Processor}";
        }
    }

}
