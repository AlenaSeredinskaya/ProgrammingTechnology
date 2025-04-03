using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Text;  
using System.Threading.Tasks;  

namespace homework2  
{
    public class GuessingGame 
    {
        /// <summary>
        /// Поле для хранения объекта, реализующего интерфейс IInputOutput для ввода/вывода
        /// </summary>
        private IInputOutput _inputOutput;

        /// <summary>
        /// Поле для хранения объекта с методом генерации случайного числа
        /// </summary>
        private IRandomNumberGenerator _numberGenerator;


        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="inputOutput"></param>
        /// <param name="numberGenerator"></param>
        public GuessingGame(IInputOutput inputOutput, IRandomNumberGenerator numberGenerator)  
        {
            _inputOutput = inputOutput;  
            _numberGenerator = numberGenerator;  
        }


        /// <summary>
        /// Метод, который запускает игру
        /// </summary>
        public void Start()  
        {
            int x = _inputOutput.GetNumber("Введите 1-ое число: "); 
            int y = _inputOutput.GetNumber("Введите 2-ое число: ");

            // Генерация случайного числа k в диапазоне от x до y
            int k = _numberGenerator.Generate(x, y);  
            int count = 0;  // Переменная для отслеживания количества попыток
            int userGuess = 0;  // Переменная для хранения текущего предположения пользователя

            _inputOutput.DisplayMessage($"Угадайте число в интервале от {x} до {y}\n");

            do  
            {
                userGuess = _inputOutput.GetNumber("Ваш вариант: ");  

                if (userGuess < k)  
                    _inputOutput.DisplayMessage("Задуманное число больше");
                else if (userGuess > k)
                    _inputOutput.DisplayMessage("Задуманное число меньше");

                count++;  // Увеличиваем количество попыток
            }
            while (userGuess != k);

            _inputOutput.DisplayMessage($"Вы угадали с {count} попытки");
        }
    }
}
