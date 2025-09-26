using System;
using System.Collections.Generic;
using System.Reflection;

namespace serialization
{
    //класс F
    internal class F
    {
        public int i1 { get; set; }
        public int i2 { get; set; }
        public int i3 { get; set; }
        public int i4 { get; set; }
        public int i5 { get; set; }
        public int[] mas;

        public F()
        {
            i1 = 1; i2 = 2; i3 = 3; i4 = 4; i5 = 5;
            mas = new int[] { 7, 5, 11, 9, 3};

        }

        public static F Get() => new F();
    }
}

