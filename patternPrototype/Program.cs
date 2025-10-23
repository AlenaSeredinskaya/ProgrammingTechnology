using System;
namespace patternPrototype
{
    class Program
    {
        static void Main()
        {
            // Создаём прототип ноутбука
            Laptop prototypeLaptop = new Laptop("Lenovo", 1200m, "Intel Core i7-1260P", 1.13, 8);
            Console.WriteLine("Прототип: " + prototypeLaptop);

            // Клонируем и модифицируем
            Laptop cloneLaptop = prototypeLaptop.MyClone();
            cloneLaptop.Battery = 12; // Изменяем батарею
            Console.WriteLine("Клон: " + cloneLaptop);

            // Создаём прототип десктопа
            Desktop prototypeDesktop = new Desktop("Asus", 1500m, "AMD Ryzen 7 5800X", "32.4 x 22.22 x 1.99", 500);
            Console.WriteLine("Прототип: " + prototypeDesktop);

            Desktop cloneDesktop = prototypeDesktop.MyClone();
            cloneDesktop.PowerSupply = 550; // Изменяем мощность блока питания
            Console.WriteLine("Клон: " + cloneDesktop);
        }
    }

}
