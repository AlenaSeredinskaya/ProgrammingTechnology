using System;

namespace lesson0
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new(161, 50, DateTime.Parse("15.12.2004"), "Mark", "Winston");
            Console.WriteLine(person);

            person.ChangeHeight(166);
            Console.WriteLine(person);
      
        }
    }
}
