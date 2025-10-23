using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patternPrototype
{
    // Потомок Desktop
    class Desktop : Computer, IMyCloneable<Desktop>, ICloneable
    {
        public string CaseSize { get; set; }
        public int PowerSupply { get; set; }

        public Desktop(string brand, decimal price, string processor, string caseSize, int powerSupply)
            : base(brand, price, processor)
        {
            CaseSize = caseSize;
            PowerSupply = powerSupply;
        }

        // Клонирование через конструктор родителя
        public new Desktop MyClone()
        {
            return new Desktop(this.Brand, this.Price, this.Processor, this.CaseSize, this.PowerSupply);
        }

        // Реализация ICloneable через свой метод
        public new object Clone()
        {
            return MyClone();
        }

        public override string ToString()
        {
            return base.ToString() + $", Размер корпуса: {CaseSize}, Мощность блока питания: {PowerSupply}W";
        }
    }

}
