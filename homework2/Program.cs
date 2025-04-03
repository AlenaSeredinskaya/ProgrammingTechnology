using System;

namespace homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            /// <summary>
            /// Создание экземпляра класса ConsoleInputOutput, реализующего интерфейс IInputOutput
            /// </summary>
            IInputOutput io = new ConsoleInputOutput();

            /// <summary>
            /// Создание экземпляра класса RandomNumberGenerator, реализующего интерфейс IRandomNumberGenerator
            /// </summary>
            IRandomNumberGenerator rng = new RandomNumberGenerator();

            /// <summary>
            /// Создание экземпляра класса GuessingGame, передавая интерфейсы ввода-вывода и генерации случайных чисел
            /// </summary>
            GuessingGame game = new GuessingGame(io, rng);

            game.Start(); // Вызов метода Start() у объекта game для начала игры
        }
    }
}

