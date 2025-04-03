using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text; 
using System.Threading.Tasks;

namespace homework2
{ 
    /// <summary>
    /// Интерфейс IRandomNumberGenerator определяет генерации случайных чисел
    /// </summary>
    public interface IRandomNumberGenerator
    {
        // Метод Generate принимает два значения (min и max) и возвращает случайное число
        int Generate(int min, int max);
    }

    /// <summary>
    /// Класс RandomNumberGenerator реализует интерфейс IRandomNumberGenerator
    /// </summary>
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        // Поле _random хранит экземпляр класса Random, который используется для генерации случайных чисел
        private Random _random = new Random();

        public int Generate(int min, int max)
        {
            // Используем метод Next объекта _random для получения случайного числа
            return _random.Next(min, max);
        }
    }
}
