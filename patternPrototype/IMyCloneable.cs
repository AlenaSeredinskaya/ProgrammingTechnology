using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patternPrototype
{
    // Дженерик интерфейс для паттерна "Прототип"
    interface IMyCloneable<T>
    {
        T MyClone(); // Метод для клонирования
    }

}
