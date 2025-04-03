using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    /// <summary>
    /// Определение класса ConsoleInputOutput, который реализует интерфейс IInputOutput
    /// </summary>
    public class ConsoleInputOutput : IInputOutput
    {
        /// <summary>
        /// Метод для получения числа от пользователя с отображением сообщения
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public int GetNumber(string message)
        {
            Console.Write(message);
            // Преобразование строки от пользователя в целое число
            return int.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Метод для отображения сообщения
        /// </summary>
        /// <param name="message"></param>
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Метод для отображения результата
        /// </summary>
        /// <param name="message"></param>
        public void DisplayResult(string message)
        {
            Console.WriteLine(message);
        }
    }
}

