using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    /// <summary>
    /// Объявление публичного интерфейса IInputOutput
    /// </summary>
    public interface IInputOutput
    {
        /// <summary>
        /// Метод для получения числа. Принимает строку message и возвращает целое число
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        int GetNumber(string message);

        /// <summary>
        /// Метод для отображения сообщения
        /// </summary>
        /// <param name="message"></param>
        void DisplayMessage(string message);

        /// <summary>
        /// Метод для отображения результата
        /// </summary>
        /// <param name="message"></param>
        void DisplayResult(string message);
    }
}

